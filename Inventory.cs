using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp4
{
    public partial class Inventory : Form
    {
        private int _parameter1;
        private int _parameter3;
        private int _parameter4;
        private MySQLDatabaseHelper dbHelper;

        private DataTable Table_215 = new DataTable();
        private DataTable Table_211 = new DataTable();
        private DataTable Table_213 = new DataTable();
        private DataTable Table_111 = new DataTable();
        private DataTable Table_Inventory = new DataTable();
        private DataTable Table_Inventory215 = new DataTable();
        private DataTable Table_Department = new DataTable();
        private DataTable Resize = new DataTable();
        private DataTable Exist = new DataTable();
        private DataTable Table_Number = new DataTable();
        private DataTable Table_LastInventory = new DataTable();
        private DataTable Table_Action = new DataTable();
        private DataTable Table_Composite = new DataTable();
        
        private DataView dataView;
        public Inventory(int ooperator, int restaurant, int update)
        {
            _parameter1 = ooperator;
            _parameter3 = restaurant;
            _parameter4 = update;
            InitializeComponent();



            dateTimePicker1.Value = DateTime.Now;
            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");

            string query1 = $"SELECT * FROM `department` WHERE `Alloved`=true ";
            Table_Department = dbHelper.ExecuteQuery(query1);
            DepartmentComboBox.DataSource = Table_Department.DefaultView;
            DepartmentComboBox.Text = "";
            DepartmentComboBox.DisplayMember = "Name_1";

            string query2 = $"SELECT `Code`,`Name_1`,`Unit`,`CostPrice` FROM `table_211` WHERE `Restaurant`= '{_parameter3}' ";
            Table_211 = dbHelper.ExecuteQuery(query2);

            string query3 = $"SELECT `Code`,`Name_1`,`Unit` FROM `table_215` WHERE `Restaurant`= '{_parameter3}' ";
            Table_215 = dbHelper.ExecuteQuery(query3);
            if (_parameter4 == 1) UpdateInventory();

            string query4 = $"SELECT `Code`,`Name_1`,`Unit`,`CostPrice`,`Actually1`,`Actually2`,`Actually3`,`Actually4`,`Actually5`," +
    $"`Act215_1`,`Act215_2`,`Act215_3`,`Act215_4`,`Act215_5` FROM `inventory` WHERE `Restaurant`='{_parameter3}' ";
            Table_Inventory = dbHelper.ExecuteQuery(query4);
            Table_Inventory.Columns.Add("Calcul", typeof(float));
            Table_Inventory.Columns.Add("Over", typeof(float));
            Table_Inventory.Columns.Add("Lack", typeof(float));

            foreach (DataRow row in Table_Inventory.Rows)
            {
                row["Calcul"] = 0;
                row["Over"] = Math.Max(0, (float.Parse(row["Actually1"].ToString()) + float.Parse(row["Act215_1"].ToString()) - float.Parse(row["Calcul"].ToString())));
                row["Lack"] = Math.Max(0, (float.Parse(row["Calcul"].ToString()) - float.Parse(row["Actually1"].ToString()) - float.Parse(row["Act215_1"].ToString())));
            }
            dataView = new DataView(Table_Inventory);
            dataGridView1.DataSource = dataView;
            dataGridView1.Columns[0].DataPropertyName = "Code";
            dataGridView1.Columns[1].DataPropertyName = "Name_1";
            dataGridView1.Columns[2].DataPropertyName = "Unit";
            dataGridView1.Columns[3].DataPropertyName = "CostPrice";
            dataGridView1.Columns[4].DataPropertyName = "Actually1";
            dataGridView1.Columns[5].DataPropertyName = "Act215_1";
            dataGridView1.Columns[6].DataPropertyName = "Calcul";
            dataGridView1.Columns[7].DataPropertyName = "Over";
            dataGridView1.Columns[8].DataPropertyName = "Lack";
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index > 8)
                {
                    column.Visible = false;
                }

            }

            string query5 = $"SELECT `Code`,`Name_1`,`Unit`,`Act215_1`,`Act215_2`,`Act215_3`,`Act215_4`,`Act215_5` FROM `inventory_215` WHERE `Restaurant`='{_parameter3}' ";
            Table_Inventory215 = dbHelper.ExecuteQuery(query5);
            int co = Table_Inventory215.Rows.Count;
            dataView = new DataView(Table_Inventory215);
            dataGridView2.DataSource = dataView;
            dataGridView2.Columns[0].DataPropertyName = "Code";
            dataGridView2.Columns[1].DataPropertyName = "Name_1";
            dataGridView2.Columns[2].DataPropertyName = "Unit";
            dataGridView2.Columns[3].DataPropertyName = "Act215_1";
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                if (column.Index > 3)
                {
                    column.Visible = false;
                }

            }
            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);

            string SelectQuery = "SELECT * FROM `actions`";
            Table_LastInventory = dbHelper.ExecuteQuery(SelectQuery);
            int co1 = Table_LastInventory.Rows.Count;


        }

        private void UpdateInventory()
        {
            MySqlConnection connection = dbHelper.GetConnection();
            connection.Open();
            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
            int c = Table_211.Rows.Count;
            foreach (DataRow row in Table_211.Rows)
            {
                string query = $"SELECT * FROM `inventory` WHERE `Code` = '{row["Code"]}' AND `Restaurant` = '{_parameter3}' ";
                Exist = dbHelper.ExecuteQuery(query);
                int count = Exist.Rows.Count;
                if (count > 0)
                {
                    string UpdateQuery = $"UPDATE `inventory` SET `Name_1`= '{row["Name_1"]}'," +
                    $"`Unit`= '{row["Unit"]}',`CostPrice`= '{row["CostPrice"]}' WHERE `Code` = '{row["Code"]}' AND `Restaurant` = '{_parameter3}'";
                    using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
                        updatCommand.ExecuteNonQuery();
                }
                else
                {
                    string InsertQuery = $"INSERT `inventory` SET `Code`= '{row["Code"]}',`Name_1`= '{row["Name_1"]}'," +
                    $"`Unit`= '{row["Unit"]}',`CostPrice`= '{row["CostPrice"]}',`Restaurant` = '{_parameter3}' ";
                    using (MySqlCommand updatCommand = new MySqlCommand(InsertQuery, connection))
                        updatCommand.ExecuteNonQuery();
                }
                connection.Close();
            }

            c = Table_215.Rows.Count;
            foreach (DataRow row in Table_215.Rows)
            {
                string query = $"SELECT * FROM `inventory_215` WHERE `Code` = '{row["Code"]}' AND `Restaurant` = '{_parameter3}' ";
                Exist = dbHelper.ExecuteQuery(query);
                int count = Exist.Rows.Count;
                if (count > 0)
                {
                    string UpdateQuery = $"UPDATE `inventory_215` SET `Name_1`= '{row["Name_1"]}'," +
                    $"`Unit`= '{row["Unit"]}' WHERE `Code` = '{row["Code"]}' AND `Restaurant` = '{_parameter3}'";
                    using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
                        updatCommand.ExecuteNonQuery();
                }
                else
                {
                    string InsertQuery = $"INSERT `inventory_215` SET `Code`= '{row["Code"]}',`Name_1`= '{row["Name_1"]}'," +
                    $"`Unit`= '{row["Unit"]}',`Restaurant` = '{_parameter3}' ";
                    using (MySqlCommand updatCommand = new MySqlCommand(InsertQuery, connection))
                        updatCommand.ExecuteNonQuery();
                }
            }
        }
        private void LastInventory(int parameter)
        {
            execute.BackColor = Color.Snow;
            execute.Enabled=true;
            DateTime last = DateTime.Parse("01-01-1900 00:00:00");
            string connectionString = "Server=localhost;Database=kafe_arm;User ID=root;Password='';CharSet = utf8mb4;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
                int department = parameter;
                string inv = "INVENTORY";
                connection.Open();
                string SelectQuery = $"SELECT `Date` FROM `actions`  WHERE `Note`='{inv}' AND (`DepartmentIn`='{department}' OR `DepartmentOut`='{department}')  ORDER BY `Date`";
                Table_LastInventory = dbHelper.ExecuteQuery(SelectQuery);
                int count = Table_LastInventory.Rows.Count;
                LastLabel.Text = "";
                foreach (DataRow row in Table_LastInventory.Rows)
                {
                    last = DateTime.Parse(row["Date"].ToString());
                    LastLabel.Text = last.ToString();//"yyyy-MM-dd HH:mm:ss");

                }
                if (dateTimePicker1.Value <= last)
                {
                    execute.BackColor = Color.Orange;
                    execute.Enabled = false;
                }
                connection.Close();
            }
        }
        private void Over_Lack()
        {
            if (DepartmentComboBox.DataSource == Table_Department.DefaultView)
            {
                DataRow[] foundRows = Table_Department.Select($"Name_1 = '{DepartmentComboBox.Text}' ");
                DepartmentIdBox.Text = foundRows[0]["Id"].ToString();
                if (DepartmentIdBox.Text == "1")
                {
                    dataGridView1.Columns[4].DataPropertyName = "Actually1";
                    dataGridView1.Columns[9].DataPropertyName = "Act215_1";

                    dataGridView2.Columns[3].DataPropertyName = "Act215_1";

                    foreach (DataRow row in Table_Inventory.Rows)
                    {
                        row["Over"] = Math.Max(0, (float.Parse(row["Actually1"].ToString()) + float.Parse(row["Act215_1"].ToString()) - float.Parse(row["Calcul"].ToString())));
                        row["Lack"] = Math.Max(0, (float.Parse(row["Calcul"].ToString()) - float.Parse(row["Actually1"].ToString()) - float.Parse(row["Act215_1"].ToString())));
                    }


                }

                if (DepartmentIdBox.Text == "2")
                {
                    dataGridView1.Columns[4].DataPropertyName = "Actually2";
                    dataGridView1.Columns[9].DataPropertyName = "Act215_2";

                    dataGridView2.Columns[3].DataPropertyName = "Act215_2";

                    foreach (DataRow row in Table_Inventory.Rows)
                    {
                        row["Over"] = Math.Max(0, (float.Parse(row["Actually2"].ToString()) + float.Parse(row["Act215_2"].ToString()) - float.Parse(row["Calcul"].ToString())));
                        row["Lack"] = Math.Max(0, (float.Parse(row["Calcul"].ToString()) - float.Parse(row["Actually2"].ToString()) - float.Parse(row["Act215_2"].ToString())));
                    }
                }
                if (DepartmentIdBox.Text == "3")
                {
                    dataGridView1.Columns[4].DataPropertyName = "Actually3";
                    dataGridView1.Columns[9].DataPropertyName = "Act215_3";

                    foreach (DataRow row in Table_Inventory.Rows)
                    {
                        row["Over"] = Math.Max(0, (float.Parse(row["Actually3"].ToString()) + float.Parse(row["Act215_3"].ToString()) - float.Parse(row["Calcul"].ToString())));
                        row["Lack"] = Math.Max(0, (float.Parse(row["Calcul"].ToString()) - float.Parse(row["Actually3"].ToString()) - float.Parse(row["Act215_3"].ToString())));
                    }
                }
                if (DepartmentIdBox.Text == "4")
                {
                    dataGridView1.Columns[4].DataPropertyName = "Actually4";
                    dataGridView1.Columns[9].DataPropertyName = "Act215_4";

                    foreach (DataRow row in Table_Inventory.Rows)
                    {
                        row["Over"] = Math.Max(0, (float.Parse(row["Actually4"].ToString()) + float.Parse(row["Act215_4"].ToString()) - float.Parse(row["Calcul"].ToString())));
                        row["Lack"] = Math.Max(0, (float.Parse(row["Calcul"].ToString()) - float.Parse(row["Actually4"].ToString()) - float.Parse(row["Act215_4"].ToString())));
                    }
                }
                if (DepartmentIdBox.Text == "5")
                {
                    dataGridView1.Columns[4].DataPropertyName = "Actually5";
                    dataGridView1.Columns[9].DataPropertyName = "Act215_5";

                    foreach (DataRow row in Table_Inventory.Rows)
                    {
                        row["Over"] = Math.Max(0, (float.Parse(row["Actually5"].ToString()) + float.Parse(row["Act215_5"].ToString()) - float.Parse(row["Calcul"].ToString())));
                        row["Lack"] = Math.Max(0, (float.Parse(row["Calcul"].ToString()) - float.Parse(row["Actually5"].ToString()) - float.Parse(row["Act215_5"].ToString())));
                    }
                }
                LastInventory(int.Parse(DepartmentIdBox.Text));
            }

        }
        private void DepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
                DataRow[] foundRows = Table_Department.Select($"Name_1 = '{DepartmentComboBox.Text}' ");
                DepartmentIdBox.Text = foundRows[0]["Id"].ToString();
                calculation();

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Savebutton1.Visible = true;
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string txt = SearchBox.Text.Trim();
            dataView = new DataView(Table_Inventory);
            dataView.RowFilter = $"(Code+Name_1) LIKE '%{txt}%'";
            dataGridView1.DataSource = dataView;
        }

        private void SearchBox1_TextChanged(object sender, EventArgs e)
        {
            string txt = SearchBox1.Text.Trim();
            dataView = new DataView(Table_Inventory215);
            dataView.RowFilter = $"(Code+Name_1) LIKE '%{txt}%'";
            dataGridView2.DataSource = dataView;
        }

        private void SearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Down) && dataGridView1.Columns.Count > 0 && dataGridView1.RowCount > 0)
            {
                int desiredColumnIndex = 0;
                int desiredRowIndex = 0; // Index of the first row in the filtered data
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (column.HeaderText == "Exist")
                    {
                        desiredColumnIndex = column.Index;
                        this.Text = "column.Index=" + column.Index.ToString() + " column.DataPropertyName " + column.DataPropertyName;
                        dataGridView1.CurrentCell = dataGridView1.Rows[desiredRowIndex].Cells[desiredColumnIndex];
                        dataGridView1.BeginEdit(true);
                    }

                }


            }
        }

        private void SearchBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Down) && dataGridView2.Columns.Count > 0 && dataGridView2.RowCount > 0)
            {
                int desiredColumnIndex = 0;
                int desiredRowIndex = 0; // Index of the first row in the filtered data
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    if (column.HeaderText == "Exist")
                    {
                        desiredColumnIndex = column.Index;
                        this.Text = "column.Index=" + column.Index.ToString() + " column.DataPropertyName " + column.DataPropertyName;
                        dataGridView2.CurrentCell = dataGridView2.Rows[desiredRowIndex].Cells[desiredColumnIndex];
                        dataGridView2.BeginEdit(true);
                    }

                }


            }
        }

        private void Inventory_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }

        }

        private void Inventory_ResizeEnd(object sender, EventArgs e)
        {
            float kw = 0;
            float kh = 0;
            foreach (DataRow row in Resize.Rows)
            {
                row["EndWidth"] = this.Width;
                row["EndHeight"] = this.Height;
                kw = float.Parse(row["EndWidth"].ToString()) / float.Parse(row["BeginWidth"].ToString());
                kh = float.Parse(row["EndHeight"].ToString()) / float.Parse(row["BeginHeight"].ToString());
            }
            foreach (Control control in this.Controls)
            {
                control.Left = (int)(control.Left * (double)kw);
                control.Top = (int)(control.Top * (double)kh);
                control.Width = (int)(control.Width * (double)kw);
                control.Height = (int)(control.Height * (double)kh);
            }

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = (int)(column.Width * kw);
            }
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                column.Width = (int)(column.Width * kw);
            }


            foreach (Control control in panel1.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }
            foreach (Control control in panel2.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }
            foreach (Control control in panel3.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }
            foreach (Control control in panel4.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }
            foreach (Control control in panel5.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }
            foreach (Control control in panel6.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }
            foreach (Control control in panel8.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (button2.Text == "Զրոյացնել բաժինը")
            {
                button2.Text = "Զրոյացնել բաժինը ?";
                button2.BackColor = Color.Yellow;
            }
            else
            {
                foreach (DataRow row in Table_Inventory215.Rows)
                {
                    if (DepartmentIdBox.Text == "1") row["Act215_1"] = 0;
                    if (DepartmentIdBox.Text == "2") row["Act215_2"] = 0;
                    if (DepartmentIdBox.Text == "3") row["Act215_3"] = 0;
                    if (DepartmentIdBox.Text == "4") row["Act215_4"] = 0;
                    if (DepartmentIdBox.Text == "5") row["Act215_5"] = 0;
                }
                foreach (DataRow row in Table_Inventory.Rows)
                {
                    if (DepartmentIdBox.Text == "1") row["Act215_1"] = 0; row["Actually1"] = 0;
                    if (DepartmentIdBox.Text == "2") row["Act215_2"] = 0; row["Actually2"] = 0;
                    if (DepartmentIdBox.Text == "3") row["Act215_3"] = 0; row["Actually3"] = 0;
                    if (DepartmentIdBox.Text == "4") row["Act215_4"] = 0; row["Actually4"] = 0;
                    if (DepartmentIdBox.Text == "5") row["Act215_5"] = 0; row["Actually5"] = 0;
                }
                button2.Text = "Զրոյացնել բաժինը";
                button2.BackColor = Color.White;
                Savebutton1.Visible = true;
            }
        }


        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Savebutton2.Visible = true;
        }

        private void Savebutton2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = dbHelper.GetConnection();
            if (connection.State != ConnectionState.Open) connection.Open();
            foreach (DataRow row in Table_Inventory215.Rows)
            {
                string UpdateQuery = $"UPDATE `inventory_215` SET `Act215_1`= '{row["Act215_1"]}',`Act215_2`= '{row["Act215_2"]}'," +
                    $"`Act215_3`= '{row["Act215_3"]}',`Act215_4`= '{row["Act215_4"]}',`Act215_5`= '{row["Act215_5"]}'" +
                    $" WHERE `Code` = '{row["Code"]}' AND `Restaurant` = '{_parameter3}'";
                using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
                    updatCommand.ExecuteNonQuery();

            }
            Savebutton2.Visible = false;
            connection.Close();
        }

        private void Savebutton1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = dbHelper.GetConnection();
            connection.Open();
            foreach (DataRow row in Table_Inventory.Rows)
            {
                string UpdateQuery = $"UPDATE `inventory` SET  `Actually1`= '{row["Actually1"]}',`Actually2`= '{row["Actually2"]}'," +
                    $" `Actually3`= '{row["Actually3"]}',`Actually4`= '{row["Actually4"]}',`Actually5`= '{row["Actually5"]}'," +
                    $" `Act215_1`= '{row["Act215_1"]}',`Act215_2`= '{row["Act215_2"]}'," +
                    $"`Act215_3`= '{row["Act215_3"]}',`Act215_4`= '{row["Act215_4"]}',`Act215_5`= '{row["Act215_5"]}'" +
                    $" WHERE `Code` = '{row["Code"]}' AND `Restaurant` = '{_parameter3}'";
                using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
                    updatCommand.ExecuteNonQuery();

            }
            Savebutton1.Visible = false;
            connection.Close();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && int.TryParse(e.Value.ToString(), out int cellValue) && cellValue == 0)
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && int.TryParse(e.Value.ToString(), out int cellValue) && cellValue == 0)
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void execute_Click(object sender, EventArgs e)
        {

            MySqlConnection connection = dbHelper.GetConnection();
            connection.Open();
            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
            string query = $"SELECT `Number` FROM `actions` WHERE `Restaurant`=  {_parameter3}";
            Table_Number = dbHelper.ExecuteQuery(query);
            int number = 0;
            foreach (DataRow row in Table_Number.Rows)
            {
                if (int.Parse(row["Number"].ToString()) > number)
                {
                    number = int.Parse(row["Number"].ToString());
                }
            }
            number = number + 1;

            string note = "INVENTORY";
            string debet = "";
            string kredit = "";
            int departmentin = 0;
            int departmentout = 0;
            float quantity = 0;
            float costamount = 0;
            foreach (DataRow row in Table_Inventory.Rows)
            {
                debet = "";
                kredit = "";
                departmentin = 0;
                departmentout = 0;
                float over = float.Parse(row["Over"].ToString());
                float lack = float.Parse(row["Lack"].ToString());
                if (over == 0 && lack == 0) continue;
                if (over > 0)
                {
                    debet = "2111";
                    kredit = "6311";
                    departmentin = int.Parse(DepartmentIdBox.Text);
                    quantity = over;
                    costamount = quantity * float.Parse(row["Costprice"].ToString());

                }
                if (lack > 0)
                {
                    debet = "7166";
                    kredit = "2111";
                    departmentout = int.Parse(DepartmentIdBox.Text);
                    quantity = lack;
                    costamount = quantity * float.Parse(row["Costprice"].ToString());
                }
                string InsertQuery = $"INSERT INTO `actions`  (`Number`,`Code`,`Date`,`DateOfEntry`,`DepartmentIn`," +
                    $" `DepartmentOut`,`Debet`,`Kredit`,`Quantity`,`CostAmount`, `Operator`,`Note`, " +
                    $"`RestaurantIn`,`RestaurantOut`, `Restaurant`) VALUES  (@number, @code, @date, @dateofentry, @departmentin,@departmentout," +
                    $"  @debet, @kredit, @quantity, @costamount, @operator, @note, @restaurantin, @restaurantout, @restaurant)";
                using (MySqlCommand updatCommand = new MySqlCommand(InsertQuery, connection))
                {
                    updatCommand.Parameters.AddWithValue("@number", number);
                    updatCommand.Parameters.AddWithValue("@code", row["Code"]);
                    updatCommand.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                    updatCommand.Parameters.AddWithValue("@dateofentry", DateTime.Now);
                    updatCommand.Parameters.AddWithValue("@departmentin", departmentin);
                    updatCommand.Parameters.AddWithValue("@departmentout", departmentout);
                    updatCommand.Parameters.AddWithValue("@debet", debet);
                    updatCommand.Parameters.AddWithValue("@kredit", kredit);
                    updatCommand.Parameters.AddWithValue("@quantity", quantity);
                    updatCommand.Parameters.AddWithValue("@costamount", costamount);
                    updatCommand.Parameters.AddWithValue("@operator", _parameter1);
                    updatCommand.Parameters.AddWithValue("@note", note);
                    updatCommand.Parameters.AddWithValue("@restaurantin", 0);
                    updatCommand.Parameters.AddWithValue("@restaurantout", 0);
                    updatCommand.Parameters.AddWithValue("@restaurant", _parameter3);

                    updatCommand.ExecuteNonQuery();
                }
            }
            connection.Close();
        }
        private void calculation()
        {
            MySqlConnection connection = dbHelper.GetConnection();
            connection.Open();
            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
            execute.BackColor = Color.Snow;
            execute.Enabled = true;
            string deb = "";
            string code = "";
            float quantity = 0;
            float quan = 0;
            DateTime dateTime = dateTimePicker1.Value;
            int dep = int.Parse(DepartmentIdBox.Text);
            if (radioButton6.Checked) deb = "2111";
            if (radioButton7.Checked) deb = "2131";
            if (radioButton11.Checked) deb = "1111";
            foreach (DataRow row in Table_Inventory.Rows)
            {
                if (dep == 1) row["Act215_1"] = 0;
                if (dep == 2) row["Act215_2"] = 0;
                if (dep == 3) row["Act215_3"] = 0;
                if (dep == 4) row["Act215_4"] = 0;
                if (dep == 5) row["Act215_5"] = 0;
                quantity = 0;
                code = row["Code"].ToString();
                string query = $"SELECT `Quantity`,`Date` FROM `actions` WHERE `Restaurant`=  '{_parameter3}' AND `Debet`='{deb}' AND `DepartmentIn`='{dep}'  AND `Code`='{code}'";
                Table_Action = dbHelper.ExecuteQuery(query);

                foreach (DataRow row1 in Table_Action.Rows)
                {
                    DateTime dat1 = DateTime.Parse(row1["Date"].ToString());
                    if (dat1 > dateTime) continue;
                    quantity = quantity + float.Parse(row1["Quantity"].ToString());
                }
                row["Calcul"] = quantity;

                string query1 = $"SELECT `Quantity`,`Date` FROM `actions` WHERE `Restaurant`=  '{_parameter3}' AND `Kredit`='{deb}' AND `DepartmentOut`='{dep}' AND `Code`='{code}'";
                Table_Action = dbHelper.ExecuteQuery(query1);
                quantity = 0;
                foreach (DataRow row1 in Table_Action.Rows)
                {
                    DateTime dat1 = DateTime.Parse(row1["Date"].ToString());
                    if (dat1 > dateTime) continue;
                    quantity = quantity + float.Parse(row1["Quantity"].ToString());
                }
                row["Calcul"] = float.Parse(row["Calcul"].ToString()) - quantity;
            }
            float quant = 0;
            foreach (DataRow row in Table_Inventory215.Rows)
            {
                if (dep == 1)
                {
                    quant = float.Parse(row["Act215_1"].ToString());
                    if (quant == 0) continue;
                }
                if (dep == 2)
                {
                    quant = float.Parse(row["Act215_2"].ToString());
                    if (quant == 0) continue; 
                }
                if (dep == 3)
                {
                    quant = float.Parse(row["Act215_3"].ToString());
                    if (quant == 0) continue;
                }
                if (dep == 4)
                {
                    quant = float.Parse(row["Act215_4"].ToString());
                    if (quant == 0) continue;
                }
                if (dep == 5)
                {
                    quant = float.Parse(row["Act215_5"].ToString());
                    if (quant == 0) continue;
                }
                string query = $"SELECT `Code_215`,`Code_211`,`Quantity` FROM `composite` WHERE `Code_215`=  '{row["Code"]}' ";
                Table_Composite = dbHelper.ExecuteQuery(query);
                string code215 = row["Code"].ToString();
                foreach (DataRow row1 in Table_Composite.Rows)
                {
                    string code_211 = row1["Code_211"].ToString();
                    float q = float.Parse(row1["Quantity"].ToString());
                    quan = quant * float.Parse(row1["Quantity"].ToString());
                    DataRow[] foundRows = Table_Inventory.Select($"Code = '{row1["Code_211"]}' ");
                    string code211 = row1["Code_211"].ToString();
                    if (dep == 1) foundRows[0]["Act215_1"] = Math.Round(float.Parse(foundRows[0]["Act215_1"].ToString()) + quan, 5);
                    if (dep == 2) foundRows[0]["Act215_2"] = Math.Round(float.Parse(foundRows[0]["Act215_2"].ToString()) + quan, 5);
                    if (dep == 3) foundRows[0]["Act215_3"] = Math.Round(float.Parse(foundRows[0]["Act215_3"].ToString()) + quan, 5);
                    if (dep == 4) foundRows[0]["Act215_4"] = Math.Round(float.Parse(foundRows[0]["Act215_4"].ToString()) + quan, 5);
                    if (dep == 5) foundRows[0]["Act215_5"] = Math.Round(float.Parse(foundRows[0]["Act215_5"].ToString()) + quan, 5);
                }

            }
            Over_Lack();
            int paramrter = int.Parse(DepartmentIdBox.Text);
            LastInventory(paramrter);
            connection.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            calculation();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            execute.Enabled = true;
            execute.BackColor = Color.White;
            DateTime last = DateTime.Parse(LastLabel.Text.Trim());
            if (last >= dateTimePicker1.Value)
            {
                execute.Enabled = false;
                execute.BackColor = Color.Orange;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.Snow)
            {
                button4.Text = "Ջնջել ?";
                button4.BackColor = Color.Yellow;
            }
            else
            {
                int dep = int.Parse(DepartmentIdBox.Text);
                MySqlConnection connection = dbHelper.GetConnection();
                connection.Open();
                dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
                string query = "SELECT COLUMN_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'kafe_arm' AND TABLE_NAME = 'actions' AND COLUMN_NAME = 'Date'";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    string columnType = (string)command.ExecuteScalar();

                    string dateFormat = "yyyy-MM-dd HH:mm:ss";

                    DateTime myDate = DateTime.ParseExact(LastLabel.Text, dateFormat, CultureInfo.InvariantCulture);

                    // Format myDate to match the datetime format expected by MySQL
                    string formattedDate = myDate.ToString(dateFormat);

                    string DeleteQuery = $"DELETE FROM `actions` WHERE `Date` = '{formattedDate}' AND  `Note` = 'INVENTORY' AND (`DepartmentIn`='{dep}' OR `DepartmentOut`='{dep}')";
                    using (MySqlCommand deleteCommand = new MySqlCommand(DeleteQuery, connection))
                    {
                        deleteCommand.ExecuteNonQuery();
                    }
                }
                connection.Close();
                button4.Text = "Ջնջել";
                button4.BackColor = Color.Snow;
            }
        }
    }
}

