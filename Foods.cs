using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Security.Policy;
using System.Windows.Forms.VisualStyles;
using Mysqlx.Crud;

namespace WindowsFormsApp4
{
    public partial class Foods : Form
    {
        private MySQLDatabaseHelper dbHelper;
        private DataTable Table_215 = new DataTable();   //Ճաշացուցակն է։

        private DataTable Table_215_Semi = new DataTable();// ճաշերի կիսապատրաստուկներն են

        private DataTable Table_211 = new DataTable();// նյութերն են  

        private DataTable Table_211_Component = new DataTable();// բաղադրիրների ֆայլն է։ Table_211-ի կլոնն է

        private DataTable Resize = new DataTable();

        private DataTable EnterCell = new DataTable();

        private DataView dataView;
          
        private DataTable Table_Composition = new DataTable();



        public int TextBox_KeyPress { get; private set; }

        public Foods()
        {
            InitializeComponent();
            //InitForm();


            EnterCell.Columns.Add("value", typeof(string));
            EnterCell.Columns.Add("type", typeof(string));
            EnterCell.Rows.Add("", "");

            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");


            string query1 = $"SELECT * FROM `table_211` WHERE 1 ";
            Table_211 = dbHelper.ExecuteQuery(query1);



            //*******************dataGridView4 - ն ենք կառուցում

            string query1_0 = $"SELECT `Code`,`Name_1`,`Unit`,`Quantity`,`Name_2`,`Name_3`,`CostPrice` FROM `table_211` WHERE 1 ";
            Table_211_Component = dbHelper.ExecuteQuery(query1_0);
            // Table_211_Component.Columns.Add("Quantity", typeof(float));
            dataView = new DataView(Table_211_Component);
            dataGridView4.DataSource = dataView;
            dataGridView4.Columns[0].DataPropertyName = "Code";
            dataGridView4.Columns[1].DataPropertyName = "Name_1";
            dataGridView4.Columns[2].DataPropertyName = "Unit";
            dataGridView4.Columns[3].DataPropertyName = "Quantity";

            foreach (DataGridViewColumn column in dataGridView4.Columns)
            {
                string name = column.DataPropertyName;
                if (column.Index > 3)
                {
                    column.Visible = false;
                }

            }


            //******************* dataGridView3-ն ենք կառուցում

            string query2_0 = $"SELECT `Code`,`Name_1`,`Unit`,`Quantity`,`Name_2`,`Name_3`,`CostPrice` FROM `table_215` WHERE `SemiPrepared`=true ";
            Table_215_Semi = dbHelper.ExecuteQuery(query2_0);
            // Table_211_Component.Columns.Add("Quantity", typeof(float));
            dataView = new DataView(Table_215_Semi);
            dataGridView3.DataSource = dataView;
            dataGridView3.Columns[0].DataPropertyName = "Code";
            dataGridView3.Columns[1].DataPropertyName = "Name_1";
            dataGridView3.Columns[2].DataPropertyName = "Unit";
            dataGridView3.Columns[3].DataPropertyName = "Quantity";

            foreach (DataGridViewColumn column in dataGridView3.Columns)
            {
                string name = column.DataPropertyName;
                if (column.Index > 3)
                {
                    column.Visible = false;
                }

            }



            //*******************  dataGridView1-ն ենք կառուցում
            string query3 = $"SELECT * FROM `table_215` WHERE 1 ";
            Table_215 = dbHelper.ExecuteQuery(query3);
            Table_215.Columns.Add("Changed", typeof(int));// DB - ում ֆայլը խմբագրելու համար է
            dataView = new DataView(Table_215);

            dataGridView1.DataSource = dataView;
            dataGridView1.Columns[0].DataPropertyName = "Code";
            dataGridView1.Columns[1].DataPropertyName = "Name_1";
            dataGridView1.Columns[2].DataPropertyName = "Name_2";
            dataGridView1.Columns[3].DataPropertyName = "Name_3";
            dataGridView1.Columns[4].DataPropertyName = "Department";
            dataGridView1.Columns[5].DataPropertyName = "SemiPrepared";
            dataGridView1.Columns[6].DataPropertyName = "Price1";
            dataGridView1.Columns[7].DataPropertyName = "Price2";
            dataGridView1.Columns[8].DataPropertyName = "Price3";
            dataGridView1.Columns[9].DataPropertyName = "Price4";
            dataGridView1.Columns[10].DataPropertyName = "Group";
            dataGridView1.Columns[11].DataPropertyName = "Printer";
            dataGridView1.Columns[12].DataPropertyName = "ATG";
            dataGridView1.Columns[13].DataPropertyName = "InHoll";
            dataGridView1.Columns[0].ReadOnly = true;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index > 13)
                {
                    column.Visible = false;
                }
            }
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;

            //*******************  dataGridView2-ն ենք կառուցում

            string query4 = $"SELECT * FROM `composition` WHERE 1 ";
            Table_Composition = dbHelper.ExecuteQuery(query4);


            //Table_Composition.Columns.Add("Amount", typeof(float));
            //ReplaceFields.Replace(Table_Composition, "Amount", "CostPrice*Quantity");
            Table_Composition.Columns.Add("Changed", typeof(int));// DB - ում ֆայլը խմբագրելու համար է


            dataView = new DataView(Table_Composition);

            dataGridView2.DataSource = dataView;
            dataGridView2.Columns[0].DataPropertyName = "Code_211";
            dataGridView2.Columns[1].DataPropertyName = "Name_1";
            dataGridView2.Columns[2].DataPropertyName = "Unit";
            dataGridView2.Columns[3].DataPropertyName = "CostPrice";
            dataGridView2.Columns[4].DataPropertyName = "Quantity";
            dataGridView2.Columns[5].DataPropertyName = "Neto";
            dataGridView2.Columns[6].DataPropertyName = "Bruto";
            dataGridView2.Columns[7].DataPropertyName = "Note";

            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {

                if (column.Index > 7)
                {
                    column.Visible = false;
                }

            }
            //string connectionString = "Server=localhost;Database=kafe_arm;User ID=root;Password='';CharSet = utf8mb4;";

            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);


        }


 
        private void Foods_Load(object sender, EventArgs e)
        {

        }

        private void SearchBox_Enter(object sender, EventArgs e)
        {
            SearchBox.Text = string.Empty;
            SearchBox.BackColor = Color.LightGreen;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.ReadOnly == true)
            {
                dataGridView1.ReadOnly = false;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView2.Enabled = true;
                dataGridView3.Enabled = true;
                dataGridView4.Enabled = true;
                EditButton.BackColor = Color.LightGreen;
                AddButton.Visible = true;
            }
            else
            {
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.ReadOnly = true;
                dataGridView2.Enabled = false;
                dataGridView3.Enabled = false;
                dataGridView4.Enabled = false;
                EditButton.BackColor = Color.White;
                AddButton.Visible = false;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (dataView.Count > 0)
            {
                // Use LINQ to find the maximum value in the "Code" column
                string maxCode = dataView.Cast<DataRowView>().Max(row => (string)row["Code"]);
                int maxcode = Convert.ToInt32(maxCode) + 1;
                maxCode = maxcode.ToString();

                DataRow newRow = Table_215.NewRow();
                newRow["Code"] = maxCode;

                // Add the new row to the DataTable
                Table_215.Rows.Add(newRow);


                if (dataGridView1.Rows.Count > 0)
                {
                    // Set the focus to the last row
                    int lastRowIndex = dataGridView1.Rows.Count - 2;
                    // dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[0]; // Assuming you want to set focus to the first column of the last row
                    // dataGridView1.BeginEdit(true); // If you want to start editing the cell immediately

                    for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
                    {
                        if (dataGridView1.Columns[colIndex].Visible)
                        {
                            dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[colIndex];
                            dataGridView1.BeginEdit(true);
                            break;
                        }
                    }


                }
            }

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)//dataGridView2 ֆիլտռւմ ենք dataGridView1-ի Code -ով
        {
            DataGridView dataGridView = (DataGridView)sender;
            DataGridViewCell currentCell = dataGridView.CurrentCell;
            object codeValue = dataGridView.Rows[e.RowIndex].Cells["Code"].Value;
            object priceValue = dataGridView.Rows[e.RowIndex].Cells["Price1"].Value;
            string code_215 = codeValue.ToString();
            float price = float.Parse(priceValue.ToString());
            this.dataGridView4.Tag = code_215;
            textBox2.Text = "";
            textBox1.Text = "";
            dataView = new DataView(Table_Composition);
            dataView.RowFilter = $"Code_215 LIKE '%{code_215}%'";
            dataGridView2.DataSource = dataView;
            float sum = 0;
            DataRow[] foundRows1 = Table_Composition.Select($"Code_215 = '{code_215}'");
            foreach (DataRow row in foundRows1)
            {
                sum = sum + float.Parse(row["CostPrice"].ToString()) * float.Parse(row["Quantity"].ToString());
            }
            textBox1.Text = sum.ToString();
            if (sum != 0)
            {
                textBox2.Text = (price / sum * 100).ToString();
            }

        }

        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridViewCell currentCell = dgv.CurrentCell;

            if (currentCell != null)
            {
                int rowIndex = currentCell.RowIndex;
                int columnIndex = currentCell.ColumnIndex;
                object cellValue = dgv.CurrentCell.Value;

                string codevalue = "";
                string namevalue = "";
                float costprice = 0;

                for (int colIndex = 0; colIndex < Table_215_Semi.Columns.Count; colIndex++)
                {
                    if (dataGridView3.Columns[colIndex].DataPropertyName == "Code")
                    {
                        codevalue = dataGridView3.Rows[rowIndex].Cells[colIndex].Value.ToString();
                    }
                    if (dataGridView3.Columns[colIndex].DataPropertyName == "Name_1")
                    {
                        namevalue = dataGridView3.Rows[rowIndex].Cells[colIndex].Value.ToString();
                    }
                    if (dataGridView3.Columns[colIndex].DataPropertyName == "CostPrice")
                    {
                        costprice = float.Parse(dataGridView3.Rows[rowIndex].Cells[colIndex].Value.ToString());
                    }
                }

                string cname = dataGridView3.Columns[columnIndex].DataPropertyName;
                if (cellValue != null && cellValue.ToString() != string.Empty && cname == "Quantity" && float.Parse(cellValue.ToString()) > 0)
                {

                    DataRow newRow = Table_Composition.NewRow();
                    Table_Composition.Rows.Add(newRow);
                    newRow["Code_215"] = dataGridView4.Tag.ToString();
                    newRow["Code_211"] = codevalue;
                    newRow["Name_1"] = namevalue;
                    newRow["Quantity"] = dgv.CurrentCell.Value;
                    newRow["CostPrice"] = costprice;
                    newRow["Changed"] = 1;

                    dgv.CurrentCell.Value = 0;
                    dgv.EndEdit();
                    SearchBox3.Focus();
                }
            }
        }





        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            dataView = new DataView(Table_215);
            string txt = SearchBox.Text.Trim();
            dataView.RowFilter = $"(Code+Name_1) LIKE '%{txt}%'";
            dataGridView1.DataSource = dataView;
        }
        private void SearchBox3_TextChanged(object sender, EventArgs e)
        {
            dataView = new DataView(Table_215_Semi);
            string txt = SearchBox3.Text.Trim();
            dataView.RowFilter = $"(Code+Name_1) LIKE '%{txt}%'";
            dataGridView3.DataSource = dataView;
        }
        private void SearchBox4_TextChanged(object sender, EventArgs e)
        {
            dataView = new DataView(Table_211_Component);
            string txt = SearchBox4.Text.Trim();
            dataView.RowFilter = $"(Code+Name_1) LIKE '%{txt}%'";
            dataGridView4.DataSource = dataView;
        }

        private void SearchBox4_Enter(object sender, EventArgs e)
        {
            SearchBox4.Text = "";
        }

        private void SearchBox3_Enter(object sender, EventArgs e)
        {
            SearchBox3.Text = "";
        }

        private void SearchBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Down) && dataGridView3.Columns.Count > 0 && dataGridView3.RowCount > 0)
            {
                int desiredColumnIndex = 0;
                int desiredRowIndex = 0; // Index of the first row in the filtered data
                foreach (DataGridViewColumn column in dataGridView3.Columns)
                {
                    if (column.DataPropertyName == "Quantity")
                    {
                        desiredColumnIndex = column.Index;
                        dataGridView3.CurrentCell = dataGridView3.Rows[desiredRowIndex].Cells[desiredColumnIndex];
                        if(dataGridView3.CurrentCell != null) dataGridView3.BeginEdit(true);

                        this.Text = "column.Index=" + column.Index.ToString() + " column.DataPropertyName " + column.DataPropertyName;



                    }

                }


            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Down)
            //{
            //    int desiredRowIndex = 0; // Index of the first row in the filtered data
            //    int desiredColumnIndex = 0; // Index of the first column

            //    if (dataGridView1.Rows.Count > 0)
            //    {
            //        dataGridView1.Columns[0].ReadOnly = true;
            //        // Check if the first column is visible
            //        if (dataGridView1.Columns[desiredColumnIndex].Visible)
            //        {
            //            dataGridView1.CurrentCell = dataGridView1.Rows[desiredRowIndex].Cells[desiredColumnIndex];
            //            dataGridView1.BeginEdit(true);
            //        }
            //        else
            //        {
            //            // Find the first visible column and set the CurrentCell
            //            for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
            //            {
            //                if (dataGridView1.Columns[colIndex].Visible)
            //                {
            //                    dataGridView1.CurrentCell = dataGridView1.Rows[desiredRowIndex].Cells[colIndex];
            //                    dataGridView1.BeginEdit(true);
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}
        }


        private void radioButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[3].Visible = false;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = true;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[3].Visible = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {

                dataGridView.Rows[e.RowIndex].Cells["Changed"].Value = 1;
                SaveButton.Visible = true;

            }
            SaveButton.BackColor = Color.LightGreen;
            SaveButton.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
            MySqlConnection connection = dbHelper.GetConnection();
            DataRow[] foundRows1 = Table_215.Select($"Changed = '{1}'");
            if (foundRows1.Length > 0)
            {
                connection.Open();
                foreach (DataRow row in foundRows1)
                {
                    string code_215 = row["Code"].ToString();
                    int group = int.Parse(row["Group"].ToString());
                    int printer = int.Parse(row["Printer"].ToString());
                    int department = int.Parse(row["Department"].ToString());
                    float price = float.Parse(row["Price"].ToString());
                    float price1 = float.Parse(row["Price1"].ToString());
                    float price2 = float.Parse(row["Price2"].ToString());
                    float price3 = float.Parse(row["Price3"].ToString());
                    float price4 = float.Parse(row["Price4"].ToString());
                    float price5 = float.Parse(row["Price5"].ToString());
                    string atg = row["Atg"].ToString();
                    string inholl = row["Inholl"].ToString();
                    bool semiprepared = bool.Parse(row["SemiPrepared"].ToString());
                    string name_1 = row["Name_1"].ToString();
                    string name_2 = row["Name_2"].ToString();
                    string name_3 = row["Name_3"].ToString();
                    string unit = row["Unit"].ToString();

                    string UpdateQuery = $"UPDATE `table_215` SET `Name_1`= '{name_1}'," +
                        $"`Name_2`= '{name_2}',`Name_3`= '{name_3}'," +
                        $"`Unit`= '{unit}',`Group`= '{group}',`Printer`= '{printer}',`Department`= '{department}'" +
                        $",`Price`= '{price}',`Price1`= '{price1}',`Price2`= '{price2}',`Price3`= '{price3}',`Price4`= '{price4}',`Price5`= '{price5}'" +
                        $",`Atg`= '{atg}',`Inholl`= '{inholl}',`SemiPrepared`= '{semiprepared}'" +
                        $"  WHERE `Code` = '{code_215}'";
                    using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
                        updatCommand.ExecuteNonQuery();
                    SaveButton.Visible = false;
                }
                connection.Close();
            }
        }

        private void Foods_FormClosing(object sender, FormClosingEventArgs e)
        {
            return;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            string name = "";
            if (e.RowIndex >= 0)
            {
                int cellsindex = e.ColumnIndex;
                name = dataGridView.Columns[cellsindex].DataPropertyName;
                object semivalue = dataGridView.Rows[e.RowIndex].Cells["SemiPrepared"].Value;
                bool semi = bool.Parse(semivalue.ToString());
                if (name == "SemiPrepared")
                {
                    if (semi == true)
                    {
                        dataGridView.Rows[e.RowIndex].Cells["SemiPrepared"].Value = false;
                    }
                    else
                    {
                        dataGridView.Rows[e.RowIndex].Cells["SemiPrepared"].Value = true;
                    }
                    dataGridView.Rows[e.RowIndex].Cells["Changed"].Value = 1;
                    SaveButton.BackColor = Color.LightGreen;
                    SaveButton.Enabled = true;
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {


        }
        private void dataGridView4_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridViewCell currentCell = dgv.CurrentCell;

            if (currentCell != null)
            {
                int rowIndex = currentCell.RowIndex;
                int columnIndex = currentCell.ColumnIndex;
                object cellValue = dgv.CurrentCell.Value;

                string codevalue = "";
                string namevalue = "";
                float costprice = 0;

                for (int colIndex = 0; colIndex < Table_211_Component.Columns.Count; colIndex++)
                {
                    if (dataGridView4.Columns[colIndex].DataPropertyName == "Code")
                    {
                        codevalue = dataGridView4.Rows[rowIndex].Cells[colIndex].Value.ToString();
                    }
                    if (dataGridView4.Columns[colIndex].DataPropertyName == "Name_1")
                    {
                        namevalue = dataGridView4.Rows[rowIndex].Cells[colIndex].Value.ToString();
                    }
                    if (dataGridView4.Columns[colIndex].DataPropertyName == "CostPrice")
                    {
                        costprice = float.Parse(dataGridView4.Rows[rowIndex].Cells[colIndex].Value.ToString());
                    }
                }

                string cname = dataGridView4.Columns[columnIndex].DataPropertyName;
                if (cellValue != null && cellValue.ToString() != string.Empty && cname == "Quantity" && float.Parse(cellValue.ToString()) > 0)
                {

                    DataRow newRow = Table_Composition.NewRow();
                    Table_Composition.Rows.Add(newRow);
                    newRow["Code_215"] = dataGridView4.Tag.ToString();
                    newRow["Code_211"] = codevalue;
                    newRow["Name_1"] = namevalue;
                    newRow["Quantity"] = dgv.CurrentCell.Value;
                    newRow["CostPrice"] = costprice;
                    newRow["Changed"] = 1;

                    dgv.CurrentCell.Value = 0;
                    dgv.EndEdit();
                    SearchBox4.Focus();

                }
            }
        }

        private void Foods_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }
        }

        private void Foods_ResizeEnd(object sender, EventArgs e)
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
            foreach (DataGridViewColumn column in dataGridView3.Columns)
            {
                column.Width = (int)(column.Width * kw);
            }
            foreach (DataGridViewColumn column in dataGridView4.Columns)
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
        }

        private void SearchBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Down) && dataGridView4.Columns.Count > 0 && dataGridView4.RowCount > 0)
            {
                int desiredColumnIndex = 0;
                int desiredRowIndex = 0; // Index of the first row in the filtered data
                foreach (DataGridViewColumn column in dataGridView4.Columns)
                {
                    if (column.DataPropertyName == "Quantity")
                    {
                        desiredColumnIndex = column.Index;
                        dataGridView4.CurrentCell = dataGridView4.Rows[desiredRowIndex].Cells[desiredColumnIndex];
                        if (dataGridView4.CurrentCell != null) dataGridView4.BeginEdit(true);

                        this.Text = "column.Index=" + column.Index.ToString() + " column.DataPropertyName " + column.DataPropertyName;



                    }

                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string xm = "<NewDataSet>";
            string IsP = "1";
            foreach (DataRow row in Table_215.Rows)
            {
                if (row["Unit"].ToString() == "հատ") IsP = "0";
                xm = xm + "<Report>";
                xm = xm + "<CodeSort>" + row["Code"].ToString().Substring(3) + "</CodeSort>";
                xm = xm + "<Code>" + row["Code"].ToString().Substring(3) + "</Code>";
                xm = xm + "<GoodName>" + row["Name_1"].ToString() + "</GoodName>";
                xm = xm + "<PriceOut>" + row["Price1"].ToString() + "</PriceOut>";
                xm = xm + "<SellByDate>100</SellByDate>";
                xm = xm + "<IsPiece>" + IsP + "</IsPiece></Report>";
            }
            xm = xm + "</NewDataSet>";
            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
            MySqlConnection connection = dbHelper.GetConnection();
            connection.Open();
            string query = $"TRUNCATE TABLE weigher";
            using (MySqlCommand command = new MySqlCommand(query, connection)) ;

            string query1 = $"INSERT INTO `weigher` (`Json_data`) VALUES (@xm)";
            using (MySqlCommand command = new MySqlCommand(query1, connection))
            {
                command.Parameters.AddWithValue("@xm", xm);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}