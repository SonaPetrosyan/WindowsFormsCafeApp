using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class GoodsMovement : Form
    {
        private int _parameter3;
        private MySQLDatabaseHelper dbHelper;
        private DataTable Table_211 = new DataTable();
        private DataTable Table_213 = new DataTable();
        private DataTable Table_111 = new DataTable();
        private DataTable Resize = new DataTable();
        private DataTable Table_Action = new DataTable();
        private DataTable Table_Department = new DataTable();
        
        private DataView dataView;
        public GoodsMovement(int restaurant)
        {
            _parameter3 = restaurant;
            InitializeComponent();

            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
            string query1 = $"SELECT `Code`,`Name_1`,`Group`,`Unit`,`Costprice` FROM `table_211` WHERE `Restaurant`='{_parameter3}' ";
            Table_211 = dbHelper.ExecuteQuery(query1);
            Table_211.Columns.Add("Rest", typeof(float));
            Table_211.Columns.Add("Purchase", typeof(float));
            Table_211.Columns.Add("+Inventory", typeof(float));
            Table_211.Columns.Add("+FromDep", typeof(float));
            Table_211.Columns.Add("+Other", typeof(float));
            Table_211.Columns.Add("-Food", typeof(float));
            Table_211.Columns.Add("-Inventory", typeof(float));
            Table_211.Columns.Add("-OutDep", typeof(float));
            Table_211.Columns.Add("-Sale", typeof(float));
            Table_211.Columns.Add("-Other", typeof(float));
            Table_211.Columns.Add("End", typeof(float));
            Table_211.Columns.Add("CostAmount", typeof(float));
            Table_211.Columns.Add("TotalPurchase", typeof(float));
            foreach (DataRow row in Table_211.Rows)
            {
                row["Rest"] = 0;
                row["Purchase"] = 0;
                row["+Inventory"] = 0;
                row["+FromDep"] = 0;
                row["+Other"] = 0;
                row["-Food"] = 0;
                row["-Inventory"] = 0;
                row["-OutDep"] = 0;
                row["-Sale"] = 0;
                row["-Other"] = 0;
                row["End"] = 0;
                row["CostAmount"] = 0;
                row["TotalPurchase"] = 0;
            }
            dataView = new DataView(Table_211);
            dataGridView1.DataSource = dataView;
            dataGridView1.Columns[0].DataPropertyName = "Code";
            dataGridView1.Columns[1].DataPropertyName = "Name_1";
            dataGridView1.Columns[2].DataPropertyName = "Group";
            dataGridView1.Columns[3].DataPropertyName = "Unit";
            dataGridView1.Columns[4].DataPropertyName = "CostPrice";
            dataGridView1.Columns[5].DataPropertyName = "Rest";
            dataGridView1.Columns[6].DataPropertyName = "Purchase";
            dataGridView1.Columns[7].DataPropertyName = "+Inventory";
            dataGridView1.Columns[8].DataPropertyName = "+FromDep";
            dataGridView1.Columns[9].DataPropertyName = "+Other";
            dataGridView1.Columns[10].DataPropertyName = "-Food";
            dataGridView1.Columns[11].DataPropertyName = "-Inventory";
            dataGridView1.Columns[12].DataPropertyName = "-OutDep";
            dataGridView1.Columns[13].DataPropertyName = "-Sale";
            dataGridView1.Columns[14].DataPropertyName = "-Other";
            dataGridView1.Columns[15].DataPropertyName = "End";


            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index > 15)
                {
                    column.Visible = false;
                }

            }

            string query2 = $"SELECT `Code`,`Name_1`,`Group`,`Unit`,`Costprice` FROM `table_213` WHERE  `Restaurant`='{_parameter3}' ";
            Table_213 = dbHelper.ExecuteQuery(query2);
            Table_213.Columns.Add("Rest", typeof(float));
            Table_213.Columns.Add("Purchase", typeof(float));
            Table_213.Columns.Add("+Inventory", typeof(float));
            Table_213.Columns.Add("+FromDep", typeof(float));
            Table_213.Columns.Add("+Other", typeof(float));
            Table_213.Columns.Add("-Food", typeof(float));
            Table_213.Columns.Add("-Inventory", typeof(float));
            Table_213.Columns.Add("-OutDep", typeof(float));
            Table_213.Columns.Add("-Sale", typeof(float));
            Table_213.Columns.Add("-Other", typeof(float));
            Table_213.Columns.Add("End", typeof(float));
            Table_213.Columns.Add("CostAmount", typeof(float));
            Table_213.Columns.Add("TotalPurchase", typeof(float));

            string query3 = $"SELECT `Code`,`Name_1`,`Group`,`Unit`,`Costprice` FROM `table_111` WHERE  `Restaurant`='{_parameter3}' ";
            Table_111 = dbHelper.ExecuteQuery(query3);
            Table_111.Columns.Add("Rest", typeof(float));
            Table_111.Columns.Add("Purchase", typeof(float));
            Table_111.Columns.Add("+Inventory", typeof(float));
            Table_111.Columns.Add("+FromDep", typeof(float));
            Table_111.Columns.Add("+Other", typeof(float));
            Table_111.Columns.Add("-Food", typeof(float));
            Table_111.Columns.Add("-Inventory", typeof(float));
            Table_111.Columns.Add("-OutDep", typeof(float));
            Table_111.Columns.Add("-Sale", typeof(float));
            Table_111.Columns.Add("-Other", typeof(float));
            Table_111.Columns.Add("End", typeof(float));
            Table_111.Columns.Add("CostAmount", typeof(float));
            Table_111.Columns.Add("TotalPurchase", typeof(float));

            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);

            string query4 = $"SELECT * FROM `department` WHERE `Alloved`=true ";
            Table_Department = dbHelper.ExecuteQuery(query4);
            DepartmentComboBox.DataSource = Table_Department.DefaultView;
            DepartmentComboBox.Text = "";
            DepartmentComboBox.DisplayMember = "Name_1";


        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && int.TryParse(e.Value.ToString(), out int cellValue) && cellValue == 0)
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void GoodsMovement_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }

        }

        private void GoodsMovement_ResizeEnd(object sender, EventArgs e)
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = dbHelper.GetConnection();
            connection.Open();
            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
            int dep = int.Parse(DepartmentIdBox.Text);
            string deb = "";
            string code = "";
            DateTime dateTime1 = dateTimePicker1.Value;
            DateTime dateTime2 = dateTimePicker2.Value;
            if (radioButton1.Checked)
            {
                deb = "2111";
                foreach (DataRow row in Table_211.Rows)
                {
                    row["Rest"] = 0;
                    row["Purchase"] = 0;
                    row["+Inventory"] = 0;
                    row["+FromDep"] = 0;
                    row["+Other"] = 0;
                    row["-Food"] = 0;
                    row["-Inventory"] = 0;
                    row["-OutDep"] = 0;
                    row["-Sale"] = 0;
                    row["-Other"] = 0;
                    row["End"] = 0;
                    row["CostAmount"] = 0;
                    row["TotalPurchase"] = 0;
                }
            }
            if (radioButton2.Checked)
            {
                deb = "2131";
                foreach (DataRow row in Table_213.Rows)
                {
                    row["Rest"] = 0;
                    row["Purchase"] = 0;
                    row["+Inventory"] = 0;
                    row["+FromDep"] = 0;
                    row["+Other"] = 0;
                    row["-Food"] = 0;
                    row["-Inventory"] = 0;
                    row["-OutDep"] = 0;
                    row["-Sale"] = 0;
                    row["-Other"] = 0;
                    row["End"] = 0;
                    row["CostAmount"] = 0;
                    row["TotalPurchase"] = 0;
                }
            }
            if (radioButton3.Checked)
            {
                deb = "1111";
                foreach (DataRow row in Table_111.Rows)
                {
                    row["Rest"] = 0;
                    row["Purchase"] = 0;
                    row["+Inventory"] = 0;
                    row["+FromDep"] = 0;
                    row["+Other"] = 0;
                    row["-Food"] = 0;
                    row["-Inventory"] = 0;
                    row["-OutDep"] = 0;
                    row["-Sale"] = 0;
                    row["-Other"] = 0;
                    row["End"] = 0;
                    row["CostAmount"] = 0;
                    row["TotalPurchase"] = 0;
                }
            }
            string query1 = $"SELECT * FROM `actions` WHERE `Restaurant`=  '{_parameter3}'  AND (`DepartmentOut`='{dep}' OR `DepartmentIn`='{dep}') AND (`Kredit`='{deb}' OR `Debet`='{deb}')";
            Table_Action = dbHelper.ExecuteQuery(query1);
            int count = Table_Action.Rows.Count;
            float t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0, t7 = 0, t8 = 0, t9 = 0, t10 = 0, t11 = 0;
            foreach (DataRow row1 in Table_Action.Rows)
            {
               // t1 = 0; t2 = 0; t3 = 0; t4 = 0; t5 = 0; t6 = 0; t7 = 0; t8 = 0; t9 = 0; t10 = 0; t11 = 0;
                code = row1["Code"].ToString();
                DateTime dat1 = DateTime.Parse(row1["Date"].ToString());
                if (dat1 > dateTime2) continue;
                DataRow[] foundRows = Table_211.Select($"Code = '{code}' ");
                if (radioButton1.Checked)
                {
                    DataRow[] foundRows1 = Table_211.Select($"Code = '{code}' ");
                    foundRows = foundRows1;
                }
                if (radioButton2.Checked)
                {
                    DataRow[] foundRows2 = Table_213.Select($"Code = '{code}' ");
                    foundRows = foundRows2;
                }
                if (radioButton3.Checked)
                {
                    DataRow[] foundRows3 = Table_111.Select($"Code = '{code}' ");
                    foundRows = foundRows3;
                }


                if (foundRows.Length > 0)
                {
                    if (row1["Kredit"].ToString() == "5211")
                    {
                        foundRows[0]["CostAmount"] = float.Parse(foundRows[0]["Purchase"].ToString()) + float.Parse(row1["CostAmount"].ToString());
                        foundRows[0]["TotalPurchase"] = float.Parse(foundRows[0]["TotalPurchase"].ToString()) + float.Parse(row1["Quantity"].ToString());
                    }
                    if (dat1 < dateTime1)
                    {
                        if (int.Parse(row1["DepartmentIn"].ToString()) == dep) foundRows[0]["Rest"] = float.Parse(foundRows[0]["rest"].ToString()) + float.Parse(row1["Quantity"].ToString());
                        if (int.Parse(row1["DepartmentOut"].ToString()) == dep) foundRows[0]["Rest"] = float.Parse(foundRows[0]["rest"].ToString()) - float.Parse(row1["Quantity"].ToString());
                        
                    }
                    else
                    {
                        if (int.Parse(row1["DepartmentIn"].ToString()) == dep)
                        {
                            if (row1["Kredit"].ToString() == "5211")
                            {
                                foundRows[0]["Purchase"] = float.Parse(foundRows[0]["Purchase"].ToString()) + float.Parse(row1["Quantity"].ToString());
                            }
                            else
                            {

                                if (row1["Note"].ToString() == "INVENTORY")
                                {
                                    foundRows[0]["+Inventory"] = float.Parse(foundRows[0]["+Inventory"].ToString()) + float.Parse(row1["Quantity"].ToString());
                                }
                                else
                                {
                                    if (int.Parse(row1["DepartmentIn"].ToString()) != 0)
                                    {
                                        foundRows[0]["+FromDep"] = float.Parse(foundRows[0]["+FromDep"].ToString()) + float.Parse(row1["Quantity"].ToString());
                                    }
                                    else
                                    {
                                        foundRows[0]["+Other"] = float.Parse(foundRows[0]["+Oher"].ToString()) + float.Parse(row1["Quantity"].ToString());
                                    }
                                }
                            }
                        }
                        if (int.Parse(row1["DepartmentOut"].ToString()) == dep)
                        {
                            if (row1["Debet"].ToString() == "8111")
                            {
                                foundRows[0]["-Food"] = float.Parse(foundRows[0]["-Food"].ToString()) + float.Parse(row1["Quantity"].ToString());
                            }
                            else
                            {

                                if (row1["Note"].ToString() == "INVENTORY")
                                {
                                    foundRows[0]["-Inventory"] = float.Parse(foundRows[0]["-Inventory"].ToString()) + float.Parse(row1["Quantity"].ToString());
                                }
                                else
                                {
                                    if (int.Parse(row1["DepartmentIn"].ToString()) != 0)
                                    {
                                        foundRows[0]["-OutDep"] = float.Parse(foundRows[0]["-OutDep"].ToString()) + float.Parse(row1["Quantity"].ToString());
                                    }
                                    else
                                    {

                                        if (row1["Debet"].ToString() == "7111")
                                        {
                                            foundRows[0]["-Sale"] = float.Parse(foundRows[0]["-Sale"].ToString()) + float.Parse(row1["Quantity"].ToString());
                                        }
                                        else
                                        {
                                            foundRows[0]["-Other"] = float.Parse(foundRows[0]["-OutDep"].ToString()) + float.Parse(row1["Quantity"].ToString());
                                        }
                                    }

                                }
                            }
                        }

                    }
                    foundRows[0]["End"] = float.Parse(foundRows[0]["Rest"].ToString()) +
                        float.Parse(foundRows[0]["Purchase"].ToString()) + float.Parse(foundRows[0]["+Inventory"].ToString()) +
                        float.Parse(foundRows[0]["+FromDep"].ToString()) + float.Parse(foundRows[0]["+Other"].ToString()) -
                        float.Parse(foundRows[0]["-Food"].ToString()) - float.Parse(foundRows[0]["-Inventory"].ToString()) -
                        float.Parse(foundRows[0]["-OutDep"].ToString()) - float.Parse(foundRows[0]["-Other"].ToString());
                    foundRows[0]["End"] = Math.Round(float.Parse(foundRows[0]["End"].ToString()), 5);

                    if (float.Parse(foundRows[0]["TotalPurchase"].ToString())>0)
                    {
                        foundRows[0]["CostPrice"] = float.Parse(foundRows[0]["CostAmount"].ToString()) / float.Parse(foundRows[0]["TotalPurchase"].ToString());
                    }
                }
            }
            if (radioButton1.Checked)
            {
                foreach (DataRow row in Table_211.Rows)
                {
                    t1 = t1 + float.Parse(row["Rest"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t2 = t2 + float.Parse(row["Purchase"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t3 = t3 + float.Parse(row["+Inventory"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t4 = t4 + float.Parse(row["+FromDep"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t5 = t5 + float.Parse(row["+Other"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t6 = t6 + float.Parse(row["-Food"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t7 = t7 + float.Parse(row["-Inventory"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t8 = t8 + float.Parse(row["-OutDep"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t9 = t9 + float.Parse(row["-Sale"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t10 = t10 + float.Parse(row["-Other"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t11 = t11 + float.Parse(row["End"].ToString()) * float.Parse(row["CostPrice"].ToString());
                }
            }
            if (radioButton2.Checked)
            {
                foreach (DataRow row in Table_213.Rows)
                {
                    t1 = t1 + float.Parse(row["Rest"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t2 = t2 + float.Parse(row["Purchase"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t3 = t3 + float.Parse(row["+Inventory"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t4 = t4 + float.Parse(row["+FromDep"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t5 = t5 + float.Parse(row["+Other"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t6 = t6 + float.Parse(row["-Food"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t7 = t7 + float.Parse(row["-Inventory"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t8 = t8 + float.Parse(row["-OutDep"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t9 = t9 + float.Parse(row["-Sale"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t10 = t10 + float.Parse(row["-Other"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t11 = t11 + float.Parse(row["End"].ToString()) * float.Parse(row["CostPrice"].ToString());
                }
            }
            if (radioButton3.Checked)
            {
                foreach (DataRow row in Table_111.Rows)
                {
                    t1 = t1 + float.Parse(row["Rest"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t2 = t2 + float.Parse(row["Purchase"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t3 = t3 + float.Parse(row["+Inventory"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t4 = t4 + float.Parse(row["+FromDep"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t5 = t5 + float.Parse(row["+Other"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t6 = t6 + float.Parse(row["-Food"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t7 = t7 + float.Parse(row["-Inventory"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t8 = t8 + float.Parse(row["-OutDep"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t9 = t9 + float.Parse(row["-Sale"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t10 = t10 + float.Parse(row["-Other"].ToString()) * float.Parse(row["CostPrice"].ToString());
                    t11 = t11 + float.Parse(row["End"].ToString()) * float.Parse(row["CostPrice"].ToString());
                }
            }
            textBox1.Text = t1.ToString();
            textBox2.Text = t2.ToString();
            textBox3.Text = t3.ToString();
            textBox4.Text = t4.ToString();
            textBox5.Text = t5.ToString();
            textBox6.Text = t6.ToString();
            textBox7.Text = t7.ToString();
            textBox8.Text = t8.ToString();
            textBox9.Text = t9.ToString();
            textBox10.Text = t10.ToString();
            textBox11.Text = t11.ToString();
            connection.Close();
        }

        private void DepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] foundRows = Table_Department.Select($"Name_1 = '{DepartmentComboBox.Text}' ");
            DepartmentIdBox.Text = foundRows[0]["Id"].ToString();
            DepartmentIdBox.BackColor = Color.Snow;
        }

        private void SearchBox2_TextChanged(object sender, EventArgs e)
        {
            string txt = SearchBox2.Text.Trim();
            if (dataGridView1.DataSource is DataView dataView1 && dataView1.Table == Table_211)
            {
                dataView = new DataView(Table_211);
                dataView.RowFilter = $"(Code+Name_1) LIKE '%{txt}%'";
                dataGridView1.DataSource = dataView;
            }
            if (dataGridView1.DataSource is DataView dataView2 && dataView2.Table == Table_213)
            {
                dataView = new DataView(Table_213);
                dataView.RowFilter = $"(Code+Name_1) LIKE '%{txt}%'";
                dataGridView1.DataSource = dataView;
            }
            if (dataGridView1.DataSource is DataView dataView3 && dataView3.Table == Table_111)
            {
                dataView = new DataView(Table_111);
                dataView.RowFilter = $"(Code+Name_1) LIKE '%{txt}%'";
                dataGridView1.DataSource = dataView;
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            dataView = new DataView(Table_211);
            dataGridView1.DataSource = dataView;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataView = new DataView(Table_213);
            dataGridView1.DataSource = dataView;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataView = new DataView(Table_111);
            dataGridView1.DataSource = dataView;
        }
    }
}
