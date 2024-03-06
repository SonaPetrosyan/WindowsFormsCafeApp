using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Relational;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Windows.Forms;
using static Mysqlx.Notice.SessionStateChanged.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using Button = System.Windows.Forms.Button;


namespace WindowsFormsApp4
{
    public partial class Standart : Form
    {
        private int _restaurant;
        private DataTable Department = new DataTable();
        private DataTable Table_215 = new DataTable();
        private DataTable Standart_215 = new DataTable();
        private DataTable Table_215_groups = new DataTable();
        private DataTable Current_order = new DataTable();  
        private DataTable Table_Restaurants = new DataTable();
        private MySQLDatabaseHelper dbHelper;
        private DataView dataView;
        public Standart(int restaurant)
        {
            InitializeComponent();
            _restaurant = restaurant;
            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");

            string query6 = $"SELECT * FROM `standart_215` WHERE  `Restaurant`='{_restaurant}' ";
            Standart_215 = dbHelper.ExecuteQuery(query6);

            string query5 = $"SELECT * FROM `department` WHERE `Restaurant`='{_restaurant}' ";
            Department = dbHelper.ExecuteQuery(query5);

            string query4 = $"SELECT * FROM `table_215_groups` WHERE  `Restaurant`='{_restaurant}' ";
            Table_215_groups = dbHelper.ExecuteQuery(query4);


            string query1 = $"SELECT * FROM `table_215` WHERE `Price`>0 AND `Restaurant`='{_restaurant}' ";
            Table_215 = dbHelper.ExecuteQuery(query1);
            foreach (DataRow row in Table_215.Rows)
            {
                row["existent"] = 0;
            }

            dataGridView1.DataSource = Table_215;
            dataGridView1.Columns[0].DataPropertyName = "Name_1";
            dataGridView1.Columns[1].DataPropertyName = "Price";

            //// Կազմավորվում է պատվերի աղյուսակը



            Current_order.Columns.Add("name", typeof(string));
            Current_order.Columns.Add("price", typeof(float));
            Current_order.Columns.Add("qanak", typeof(string));
            Current_order.Columns.Add("salesamount", typeof(float));
            Current_order.Columns.Add("printer", typeof(int));
            Current_order.Columns.Add("departmentout", typeof(int));
            Current_order.Columns.Add("code", typeof(string));
            Current_order.Columns.Add("quantity", typeof(float));
            Current_order.Columns.Add("number", typeof(int));
            Current_order.Columns.Add("accepted", typeof(bool));
            Current_order.Columns.Add("current", typeof(bool));
            Current_order.Columns.Add("debet", typeof(string));
            Current_order.Columns.Add("kredit", typeof(string));
            Current_order.Columns.Add("id", typeof(int));
            Current_order.Columns.Add("restaurant", typeof(int));

            dataGridView2.DataSource = Current_order;
            dataGridView2.Columns[0].DataPropertyName = "name";
            dataGridView2.Columns[1].DataPropertyName = "Price";
            dataGridView2.Columns[2].DataPropertyName = "qanak";
            dataGridView2.Columns[3].DataPropertyName = "salesamount";

        }

        private void group1_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group1.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group2_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group2.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group3_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group3.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group4_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group4.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group5_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group5.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group6_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group6.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group7_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group7.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group8_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group8.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group9_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group9.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group10_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group10.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group11_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group11.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group12_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group12.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group13_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group13.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group14_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group14.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group15_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group15.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group16_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group16.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group17_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group17.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group18_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group18.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group19_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group19.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group20_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group20.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group21_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group21.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group22_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group22.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group23_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group23.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group24_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group24.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group25_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group25.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group26_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group26.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group27_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group27.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group28_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group28.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group29_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group29.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group30_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group30.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void department1_Click(object sender, EventArgs e)
        {
            this.DepartmentClick.Tag = "1";
            this.DepartmentClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void department2_Click(object sender, EventArgs e)
        {
            this.DepartmentClick.Tag = "2";
            this.DepartmentClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void GroupClick_Click(object sender, EventArgs e)
        {
            dataView = new DataView(Table_215);
            dataView.RowFilter = $"department = " + DepartmentClick.Tag.ToString() + " AND group = " + GroupClick.Tag.ToString();//բաժինը և խումբը ընտրվածներն են

            dataGridView1.DataSource = dataView;
        }

        private void DepartmentClick_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button[] groupArray = new Button[30] { group1, group2, group3, group4, group5, group6, group7, group8, group9, group10,
                group11, group12, group13, group14, group15, group16, group17, group18, group19, group20,
                group21, group22, group23, group24, group25, group26, group27,group28, group29, group30 };
            for (int j = 0; j < 30; j++)
            {
                groupArray[j].Visible = false;
                groupArray[j].Tag = "0";
            }
            string dep = DepartmentClick.Tag.ToString();
            department1.BackColor = Color.White;
            department2.BackColor = Color.White;

            if (dep == "1")
            {
                department1.BackColor = Color.LimeGreen;
            }
            if (dep == "2")
            {
                department2.BackColor = Color.LimeGreen;
            }
            dataView = new DataView(Table_215);
            dataView.RowFilter = "department = " + dep;




            dataGridView1.DataSource = dataView;
            int i = -1;
            int k = 0;
            foreach (DataRowView rowView in dataView)//տվյալ բաժնի խմբերի կոճակներն ենք կարգավորում

            {
                if (i < 29)
                {
                    DataRow row = rowView.Row;
                    DataRow[] matchingRows = Table_215_groups.Select($"group = {row["group"]}");
                    if (matchingRows.Length > 0)
                    {
                        k = 0;
                        for (int j = 0; j < 29; j++)
                        {
                            if (matchingRows[0]["group"].ToString() == groupArray[j].Tag.ToString()) k = 1;
                        }
                        if (k == 1) continue;
                        i++;
                        groupArray[i].Text = matchingRows[0]["Name_1"].ToString();
                        groupArray[i].Tag = matchingRows[0]["Group"].ToString();
                        groupArray[i].Visible = true;
                    }
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Tag = "inorder";// հայտանիշ է թվերը դնելու համար command կոճակի մեջ օգտագործելու 
            DataGridView dataGridView = (DataGridView)sender;
            object codeValue = dataGridView.Rows[e.RowIndex].Cells["code"].Value;
            object printerValue = dataGridView.Rows[e.RowIndex].Cells["printer"].Value;
            object priceValue = dataGridView.Rows[e.RowIndex].Cells["price"].Value;
            object existValue = dataGridView.Rows[e.RowIndex].Cells["existent"].Value;
            object nameValue = dataGridView.Rows[e.RowIndex].Cells["Name_1"].Value;
            object departmentValue = dataGridView.Rows[e.RowIndex].Cells["Department"].Value;
            if (codeValue != null)
            {
                string code = codeValue.ToString();
                string name = nameValue.ToString();
                float price = float.Parse(priceValue.ToString());
                int printer = int.Parse(printerValue.ToString());
                int department = int.Parse(departmentValue.ToString());
                string exist = existValue.ToString();
                DataRow[] foundRows = Current_order.Select("current = true");  // Locate for current = true


                if (foundRows.Length == 0) 
                {
                    DataRow newRow = Current_order.NewRow(); // Append the new row to the Current_order և լրացնում է ընտրվածով
                    Current_order.Rows.Add(newRow);
                    newRow["current"] = true;
                    newRow["accepted"] = false;
                    newRow["id"] = Current_order.Rows.Count;
                    dataGridView2.Tag = Current_order.Rows.Count;
                    newRow["code"] = code;
                    newRow["name"] = name;
                    newRow["price"] = price;
                    newRow["quantity"] = 0;
                    newRow["salesamount"] = 0;
                    newRow["printer"] = printer;
                    newRow["departmentout"] = department;
                    newRow["qanak"] = "";
                    newRow["debet"] = "2211";
                    newRow["kredit"] = "2151";
                    if (dataGridView2.Rows.Count > 0)
                    {
                        int lastRowIndex = dataGridView2.Rows.Count - 1;
                        for (int colIndex = 0; colIndex < dataGridView2.Columns.Count; colIndex++)
                        {
                            if (dataGridView2.Columns[colIndex].Visible)
                            {
                                dataGridView2.CurrentCell = dataGridView2.Rows[lastRowIndex].Cells[colIndex];
                                dataGridView2.BeginEdit(true);
                                break;
                            }
                        }
                    }
                }


                foreach (DataRow row in Current_order.Rows)//ընթացիկ տողը փոխարինում է նոր ընտրվածով
                {
                    if (row["current"].ToString().ToLower() == "true")
                    {
                        row["code"] = code;
                        row["name"] = name;
                        row["price"] = price;
                        row["quantity"] = 0;
                        row["salesamount"] = 0;
                        row["printer"] = printer;
                        row["qanak"] = "";
                    }
                }
                //dataGridView2.Refresh();

            }

        }
        private void command_Click(object sender, EventArgs e)
        {
          //  if (command.Text == "number" && dataGridView1.Tag.ToString() == "inorder")//պատվերի ընթացքի մեջ ենք և թիվ ենք սեղմել
         //   {
                foreach (DataRow row in Current_order.Rows)
                {

                    if (bool.Parse(row["current"].ToString()) == true)
                    {
                        float inspector = float.Parse(number_enter.Tag.ToString()) + float.Parse((((string)row["qanak"]).Trim() + command.Tag));// 

                        if (inspector < 0) //քանակից ավել մինուս չի թողնում 
                        {
                            break;
                        }
                        if (!(row["qanak"].ToString().IndexOf(".") >= 0 && command.Tag.ToString() == "."))  // որպեսզի երկու կետ չդրվի
                        {
                            row["qanak"] = ((string)row["qanak"]).Trim() + command.Tag;
                        }
                    }
                }
         //   }
        }

        private void number5_Click(object sender, EventArgs e)
        {
            command.Tag = "5";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number6_Click(object sender, EventArgs e)
        {
            command.Tag = "6";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number7_Click(object sender, EventArgs e)
        {
            command.Tag = "7";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number8_Click(object sender, EventArgs e)
        {
            command.Tag = "8";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number9_Click(object sender, EventArgs e)
        {
            command.Tag = "9";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number0_Click(object sender, EventArgs e)
        {
            command.Tag = "0";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number1_Click(object sender, EventArgs e)
        {
            command.Tag = "1";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number2_Click(object sender, EventArgs e)
        {
            command.Tag = "2";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number3_Click(object sender, EventArgs e)
        {
            command.Tag = "3";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number4_Click(object sender, EventArgs e)
        {
            command.Tag = "4";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number_point_Click(object sender, EventArgs e)
        {
            command.Tag = ".";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in Current_order.Rows)
            {
                if (row["id"].ToString() == dataGridView2.Tag.ToString())
                {
                    int L = row["qanak"].ToString().Length;
                    if (L > 0)
                    {
                        row["qanak"] = row["qanak"].ToString().Substring(0, L - 1); //աջից մել սիմվոլ ենք հեռացնում
                    }
                }
            }
        }

        private void number_enter_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Tag.ToString() == "inorder")//պատվերի ընթացքի մեջ ենք և "Enter" ենք սեղմել
            {
                float a_m = 0;
                float w_t = 0;
                float d_q = 0;
                bool acc = false;
                accept.Visible = false;

                foreach (DataRow row in Current_order.Rows)
                {
                    if (bool.Parse(row["current"].ToString()) == true && row["qanak"].ToString().Length > 0 && row["qanak"].ToString() != "-")
                    {

                        acc = true;
                        row["quantity"] = float.Parse(row["qanak"].ToString());
                        row["salesamount"] = float.Parse(row["quantity"].ToString()) * float.Parse(row["price"].ToString());
                        row["current"] = false;
                        dataGridView2.Tag = "none";
                    }
                    a_m += float.Parse(row["quantity"].ToString()) * float.Parse(row["price"].ToString());//սեղանի գումարը 

                }
                amount.Text = a_m.ToString();
                if (acc)
                {
                    accept.Visible = true;
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            string query6 = $"SELECT * FROM `standart_215` WHERE  `Restaurant`='{_restaurant}' ";
            Standart_215 = dbHelper.ExecuteQuery(query6);

            if (numericUpDown1.Value>0) dataGridView1.Enabled= true;
            Current_order.Clear();
            int i = 0;
            foreach (DataRow row in Standart_215.Rows)
            {
                if ((int.Parse(row["Number"].ToString()) != numericUpDown1.Value) || int.Parse(row["Restaurant"].ToString()) != _restaurant) continue;
                i = i + 1;
                DataRow newRow = Current_order.NewRow(); // Append the new row to the Current_order և լրացնում է ընտրվածով
                Current_order.Rows.Add(newRow);
                newRow["id"] = i;
                newRow["Number"] = numericUpDown1.Value;
                newRow["Code"] = row["Code"];
                newRow["Quantity"] = row["Quantity"];
                newRow["SalesAmount"] = row["SalesAmount"];
                newRow["Restaurant"] = _restaurant;
                newRow["Debet"] = row["Debet"];
                newRow["Kredit"] = row["Kredit"];
                newRow["Current"] = false;
                DataRow[] foundRows = Table_215.Select($"`Code`= '{row["Code"]}' AND `Restaurant`= '{_restaurant}' ");
                if (foundRows.Length > 0)
                {
                    newRow["name"] = foundRows[0]["Name_1"];
                    newRow["price"] = foundRows[0]["Price"];
                    newRow["departmentout"] = foundRows[0]["Department"];
                }
                newRow["qanak"] = row["Quantity"].ToString();
            }

        }

        private void accept_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = dbHelper.GetConnection();
            connection.Open();
            string DeleteQuery = $"DELETE FROM `standart_215` WHERE `Number`='{numericUpDown1.Value}' AND `Restaurant`='{_restaurant}'";
            using (MySqlCommand deleteCommand = new MySqlCommand(DeleteQuery, connection))
                deleteCommand.ExecuteNonQuery();

            foreach (DataRow row in Current_order.Rows)
            {
                if (float.Parse(row["Quantity"].ToString()) == 0) { continue; }
                string InsertQuery = $"INSERT INTO `standart_215`  (`Number`,`Code`,`DateOfEntry`," +
                    $" `DepartmentOut`,`Debet`,`Kredit`,`Quantity`,`SalesAmount`, " +
                    $" `Restaurant`) VALUES  (@number, @code, @dateofentry, @departmentout," +
                    $" @debet, @kredit, @quantity, @salesamount, @restaurant)";
                using (MySqlCommand updatCommand = new MySqlCommand(InsertQuery, connection))
                {
                    updatCommand.Parameters.AddWithValue("@number", numericUpDown1.Value);
                    updatCommand.Parameters.AddWithValue("@code", row["Code"]);
                    updatCommand.Parameters.AddWithValue("@dateofentry", DateTime.Now);
                    updatCommand.Parameters.AddWithValue("@departmentout", row["DepartmentOut"]);
                    updatCommand.Parameters.AddWithValue("@debet", row["Debet"]);
                    updatCommand.Parameters.AddWithValue("@kredit", row["Kredit"]);
                    updatCommand.Parameters.AddWithValue("@quantity", row["Quantity"]);
                    updatCommand.Parameters.AddWithValue("@salesamount", row["SalesAmount"]);
                    updatCommand.Parameters.AddWithValue("@restaurant", _restaurant);

                    updatCommand.ExecuteNonQuery();
                }



            }

            connection.Close();
            accept.Visible = false;
        }

        private void number_delete_Click(object sender, EventArgs e)
        {
            int idd = int.Parse(number_delete.Tag.ToString());
            DataRow[] foundRows = Current_order.Select($"id = '{idd}'");
            foundRows[0]["quantity"] = 0;
            foundRows[0]["qanak"] = "";
            number_delete.Enabled = false;
            accept.Visible=true;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {

                dataGridView1.Tag = "inorder";// հայտանիշ է թվերը դնելու համար command կոճակի մեջ օգտագործելու 
                DataGridView dataGridView = (DataGridView)sender;
                object idValue = dataGridView.Rows[e.RowIndex].Cells["id"].Value;
                number_delete.Tag=idValue.ToString();
                number_delete.Enabled = true;
            }
        }
    }
}
