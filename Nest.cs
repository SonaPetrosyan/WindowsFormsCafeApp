using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Linq;
using Mysqlx.Crud;

namespace WindowsFormsApp4
{
    public partial class Nest : Form
    {
        private MySQLDatabaseHelper dbHelper;
        private DataTable Nest_1 = new DataTable();
        private DataTable Nest_2 = new DataTable();
        private DataTable Nest_3 = new DataTable();
        private DataTable Nest_4 = new DataTable();
        private DataTable Nest_5 = new DataTable();
        private DataTable Nest_6 = new DataTable();
        private DataTable Nest_7 = new DataTable();
        private DataTable Nest_8 = new DataTable();
        private DataTable Nest_9 = new DataTable();
        private DataTable Nest_10 = new DataTable();
        private DataTable Nest_Group = new DataTable();
        private DataTable Resize = new DataTable();
        private DataTable Exist = new DataTable();
        private DataView dataView;
        public Nest()
        {
            InitializeComponent();

            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");


            string query1 = $"SELECT `Nest`,`Service`,`Discount`,`Group`,`Holl` FROM `tablenest` WHERE `Holl`=1 ";
            Nest_1 = dbHelper.ExecuteQuery(query1);
            dataGridView1.DataSource = Nest_1;
            dataGridView1.Columns[0].DataPropertyName = "Nest";
            dataGridView1.Columns[1].DataPropertyName = "Service";
            dataGridView1.Columns[2].DataPropertyName = "Discount";
            dataGridView1.Columns[3].DataPropertyName = "Group";
            dataGridView1.DataSource = Nest_1;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index > 3)
                {
                    column.Visible = false;
                }
            }
            string query2 = $"SELECT `Nest`,`Service`,`Discount`,`Group`,`Holl` FROM `tablenest` WHERE `Holl`=2 ";
            Nest_2 = dbHelper.ExecuteQuery(query2);
            string query3 = $"SELECT `Nest`,`Service`,`Discount`,`Group`,`Holl` FROM `tablenest` WHERE `Holl`=3 ";
            Nest_3 = dbHelper.ExecuteQuery(query3);
            string query4 = $"SELECT `Nest`,`Service`,`Discount`,`Group`,`Holl` FROM `tablenest` WHERE `Holl`=4 ";
            Nest_4 = dbHelper.ExecuteQuery(query4);
            string query5 = $"SELECT `Nest`,`Service`,`Discount`,`Group`,`Holl` FROM `tablenest` WHERE `Holl`=5 ";
            Nest_5 = dbHelper.ExecuteQuery(query5);
            string query6 = $"SELECT `Nest`,`Service`,`Discount`,`Group`,`Holl` FROM `tablenest` WHERE `Holl`=6 ";
            Nest_6 = dbHelper.ExecuteQuery(query6);
            string query7 = $"SELECT `Nest`,`Service`,`Discount`,`Group`,`Holl` FROM `tablenest` WHERE `Holl`=7 ";
            Nest_7 = dbHelper.ExecuteQuery(query7);
            string query8 = $"SELECT `Nest`,`Service`,`Discount`,`Group`,`Holl` FROM `tablenest` WHERE `Holl`=8 ";
            Nest_8 = dbHelper.ExecuteQuery(query8);
            string query9 = $"SELECT `Nest`,`Service`,`Discount`,`Group`,`Holl` FROM `tablenest` WHERE `Holl`=9 ";
            Nest_9 = dbHelper.ExecuteQuery(query9);
            string query10 = $"SELECT `Nest`,`Service`,`Discount`,`Group`,`Holl` FROM `tablenest` WHERE `Holl`=10 ";
            Nest_10 = dbHelper.ExecuteQuery(query10);
            string query11 = $"SELECT `Groupp`,`Name_1` FROM `NestGroup` WHERE 1 ";
            Nest_Group = dbHelper.ExecuteQuery(query11);



            dataGridView2.DataSource = Nest_Group;
            dataGridView2.Columns[0].DataPropertyName = "Groupp";
            dataGridView2.Columns[1].DataPropertyName = "Name_1";
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                if (column.Index > 1)
                {
                    column.Visible = false;
                }
            }

            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);

            label2.Text = "";
            label3.Text = "";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (Savebutton1.Visible)
            {
                numericUpDown1.Value = int.Parse(numericUpDown1.Tag.ToString());
                DontsaveButton.Visible = true;
            }
            else
            {
                if (numericUpDown1.Value == 1) dataGridView1.DataSource = Nest_1;
                if (numericUpDown1.Value == 2)
                {
                    dataGridView1.DataSource = Nest_2;
                    dataGridView1.Columns[0].DataPropertyName = "Nest";
                    dataGridView1.Columns[1].DataPropertyName = "Service";
                    dataGridView1.Columns[2].DataPropertyName = "Discount";
                    dataGridView1.Columns[3].DataPropertyName = "Group";
                }

                if (numericUpDown1.Value == 3) dataGridView1.DataSource = Nest_3;
                if (numericUpDown1.Value == 4) dataGridView1.DataSource = Nest_4;
                if (numericUpDown1.Value == 5) dataGridView1.DataSource = Nest_5;
                if (numericUpDown1.Value == 6) dataGridView1.DataSource = Nest_6;
                if (numericUpDown1.Value == 7) dataGridView1.DataSource = Nest_7;
                if (numericUpDown1.Value == 8) dataGridView1.DataSource = Nest_8;
                if (numericUpDown1.Value == 9) dataGridView1.DataSource = Nest_9;
                if (numericUpDown1.Value == 10) dataGridView1.DataSource = Nest_10;
                numericUpDown1.Tag = numericUpDown1.Value.ToString();
            }
        }

        private void Nest_ResizeBegin(object sender, EventArgs e)
        {

            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }
        }

        private void Nest_ResizeEnd(object sender, EventArgs e)
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



        }

        private void Addbutton1_Click(object sender, EventArgs e)
        {
            Savebutton1.Visible = true;
            int nest = 0;
            string s = "";
            if (numericUpDown1.Value == 1)
            {

                foreach (DataRow row in Nest_1.Rows)
                {
                    s = row["Nest"].ToString() + "   ";
                    if (int.Parse(s.Substring(2, 3)) > nest) { nest++; }
                }
                string l = numericUpDown1.Value.ToString() + "-" + (nest + 1).ToString();
                DataRow newRow = Nest_1.NewRow();
                newRow["Nest"] = l; newRow["Service"] = 0; newRow["Discount"] = 0; newRow["Group"] = 0;
                Nest_1.Rows.Add(newRow);

                int lastRowIndex = Nest_1.Rows.Count - 1;
                dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[0];

                dataGridView1.BeginEdit(true);
            }
            //*******************************
            if (numericUpDown1.Value == 2)
            {

                foreach (DataRow row in Nest_2.Rows)
                {
                    s = row["Nest"].ToString() + "   ";
                    if (int.Parse(s.Substring(2, 3)) > nest) { nest++; }
                }
                string l = numericUpDown1.Value.ToString() + "-" + (nest + 1).ToString();
                DataRow newRow = Nest_2.NewRow();
                newRow["Nest"] = l; newRow["Service"] = 0; newRow["Discount"] = 0; newRow["Group"] = 0;
                Nest_2.Rows.Add(newRow);
                int lastRowIndex = Nest_2.Rows.Count - 1;
                dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[0];
                dataGridView1.BeginEdit(true);
            }
            //*********************************
            if (numericUpDown1.Value == 3)
            {

                foreach (DataRow row in Nest_3.Rows)
                {
                    s = row["Nest"].ToString() + "   ";
                    if (int.Parse(s.Substring(2, 3)) > nest) { nest++; }
                }
                string l = numericUpDown1.Value.ToString() + "-" + (nest + 1).ToString();
                DataRow newRow = Nest_3.NewRow();
                newRow["Nest"] = l; newRow["Service"] = 0; newRow["Discount"] = 0; newRow["Group"] = 0;
                Nest_3.Rows.Add(newRow);
                int lastRowIndex = Nest_3.Rows.Count - 1;
                dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[0];
                dataGridView1.BeginEdit(true);
            }
            //*********************************************
            if (numericUpDown1.Value == 4)
            {

                foreach (DataRow row in Nest_4.Rows)
                {
                    s = row["Nest"].ToString() + "   ";
                    if (int.Parse(s.Substring(2, 3)) > nest) { nest++; }
                }
                string l = numericUpDown1.Value.ToString() + "-" + (nest + 1).ToString();
                DataRow newRow = Nest_4.NewRow();
                newRow["Nest"] = l; newRow["Service"] = 0; newRow["Discount"] = 0; newRow["Group"] = 0;
                int lastRowIndex = Nest_4.Rows.Count - 1;
                dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[0];
                dataGridView1.BeginEdit(true);
            }
            //*********************************************
            if (numericUpDown1.Value == 5)
            {

                foreach (DataRow row in Nest_5.Rows)
                {
                    s = row["Nest"].ToString() + "   ";
                    if (int.Parse(s.Substring(2, 3)) > nest) { nest++; }
                }
                string l = numericUpDown1.Value.ToString() + "-" + (nest + 1).ToString();
                DataRow newRow = Nest_5.NewRow();
                newRow["Nest"] = l; newRow["Service"] = 0; newRow["Discount"] = 0; newRow["Group"] = 0;
                Nest_5.Rows.Add(newRow);
                int lastRowIndex = Nest_5.Rows.Count - 1;
                dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[0];
                dataGridView1.BeginEdit(true);
            }
            //*********************************************
            if (numericUpDown1.Value == 6)
            {

                foreach (DataRow row in Nest_6.Rows)
                {
                    s = row["Nest"].ToString() + "   ";
                    if (int.Parse(s.Substring(2, 3)) > nest) { nest++; }
                }
                string l = numericUpDown1.Value.ToString() + "-" + (nest + 1).ToString();
                DataRow newRow = Nest_6.NewRow();
                newRow["Nest"] = l; newRow["Service"] = 0; newRow["Discount"] = 0; newRow["Group"] = 0;
                Nest_6.Rows.Add(newRow);
                int lastRowIndex = Nest_6.Rows.Count - 1;
                dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[0];
                dataGridView1.BeginEdit(true);
            }
            //*********************************************
            if (numericUpDown1.Value == 7)
            {

                foreach (DataRow row in Nest_7.Rows)
                {
                    s = row["Nest"].ToString() + "   ";
                    if (int.Parse(s.Substring(2, 3)) > nest) { nest++; }
                }
                string l = numericUpDown1.Value.ToString() + "-" + (nest + 1).ToString();
                DataRow newRow = Nest_7.NewRow();
                newRow["Nest"] = l; newRow["Service"] = 0; newRow["Discount"] = 0; newRow["Group"] = 0;
                Nest_7.Rows.Add(newRow);
                int lastRowIndex = Nest_7.Rows.Count - 1;
                dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[0];
                dataGridView1.BeginEdit(true);
            }
            //*********************************************
            if (numericUpDown1.Value == 8)
            {

                foreach (DataRow row in Nest_8.Rows)
                {
                    s = row["Nest"].ToString() + "   ";
                    if (int.Parse(s.Substring(2, 3)) > nest) { nest++; }
                }
                string l = numericUpDown1.Value.ToString() + "-" + (nest + 1).ToString();
                DataRow newRow = Nest_8.NewRow();
                newRow["Nest"] = l; newRow["Service"] = 0; newRow["Discount"] = 0; newRow["Group"] = 0;
                Nest_8.Rows.Add(newRow);
                int lastRowIndex = Nest_8.Rows.Count - 1;
                dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[0];
                dataGridView1.BeginEdit(true);
            }
            //*********************************************
            if (numericUpDown1.Value == 9)
            {

                foreach (DataRow row in Nest_9.Rows)
                {
                    s = row["Nest"].ToString() + "   ";
                    if (int.Parse(s.Substring(2, 3)) > nest) { nest++; }
                }
                string l = numericUpDown1.Value.ToString() + "-" + (nest + 1).ToString();
                DataRow newRow = Nest_9.NewRow();
                newRow["Nest"] = l; newRow["Service"] = 0; newRow["Discount"] = 0; newRow["Group"] = 0;
                Nest_9.Rows.Add(newRow);
                int lastRowIndex = Nest_9.Rows.Count - 1;
                dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[0];
                dataGridView1.BeginEdit(true);
            }
            //*********************************************
            if (numericUpDown1.Value == 10)
            {

                foreach (DataRow row in Nest_10.Rows)
                {
                    s = row["Nest"].ToString() + "   ";
                    if (int.Parse(s.Substring(2, 3)) > nest) { nest++; }
                }
                string l = numericUpDown1.Value.ToString() + "-" + (nest + 1).ToString();
                DataRow newRow = Nest_10.NewRow();
                newRow["Nest"] = l; newRow["Service"] = 0; newRow["Discount"] = 0; newRow["Group"] = 0; newRow["Holl"] = int.Parse(numericUpDown1.Value.ToString());
                Nest_10.Rows.Add(newRow);
                int lastRowIndex = Nest_10.Rows.Count - 1;
                dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[0];
                dataGridView1.BeginEdit(true);
            }
        }

        private void Savebutton1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = dbHelper.GetConnection();
            connection.Open();
            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {

                    Exist = new DataTable();
                    string nest = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    float service = float.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    float discount = float.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    int group = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    int holl = int.Parse(numericUpDown1.Value.ToString());

                    string query = $"SELECT * FROM `tablenest` WHERE `Nest` = '{nest}' AND `Holl`='{holl}' ";
                    Exist = dbHelper.ExecuteQuery(query);
                    int count = Exist.Rows.Count;
                    if (count > 0)
                    {
                        string UpdateQuery = $"UPDATE `tablenest` SET `Service`= '{service}',`Discount`= '{discount}',`Group`= '{group}'" +
                            $" WHERE `Nest`= '{nest}' AND `Holl`= '{holl}'";
                        using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
                            updatCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        string InsertQuery = $"INSERT `tablenest` SET `Nest`= '{nest}',`Holl`= '{holl}',`Service`= '{service}',`Discount`= '{discount}',`Group`= '{group}'";
                        using (MySqlCommand updatCommand = new MySqlCommand(InsertQuery, connection))
                            updatCommand.ExecuteNonQuery();
                    }
                }
            }
            Savebutton1.Visible = false;
            DontsaveButton.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label2.Text.Length > 0 && label3.Text.Length > 0)
            {
                int rowindex = int.Parse(label3.Tag.ToString());
                dataGridView1.Rows[rowindex].Cells["Group"].Value = int.Parse(label2.Text);
                label3.Text = "";
                dataGridView1.Refresh();
                Savebutton1.Visible = true;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Savebutton1.Visible = true;
        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {
            if (Savebutton1.Visible) { return; }
        }

        private void DontsaveButton_Click(object sender, EventArgs e)
        {
            DontsaveButton.Visible = false;
            Savebutton1.Visible = false;
            button1.Enabled = false;
        }

        private void AddButton2_Click(object sender, EventArgs e)
        {
            Savebutton2.Visible = true;
            int groupp = 0;

            foreach (DataRow row in Nest_Group.Rows)
            {
                groupp = int.Parse(row["Groupp"].ToString());
                if (int.Parse(row["Groupp"].ToString()) > groupp) { groupp++; }
            }
            DataRow newRow = Nest_Group.NewRow();
            newRow["Groupp"] = groupp+1;
            Nest_Group.Rows.Add(newRow);
            int lastRowIndex = Nest_Group.Rows.Count - 1;
            dataGridView2.CurrentCell = dataGridView2.Rows[lastRowIndex].Cells[0];
            dataGridView2.BeginEdit(true);
        }

        private void Savebutton2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = dbHelper.GetConnection();
            connection.Open();
            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");

            for (int i = 0; i < dataGridView2.Rows.Count-1; i++)
            {
                if (dataGridView2.Rows[i].Cells[0].Value != null)
                {

                    Exist = new DataTable();
                    int group = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                    string name = dataGridView2.Rows[i].Cells[1].Value.ToString();

                    string query = $"SELECT * FROM `nestgroup` WHERE `Groupp` = '{group}' ";
                    Exist = dbHelper.ExecuteQuery(query);
                    int count = Exist.Rows.Count;
                    if (count > 0)
                    {
                        string UpdateQuery = $"UPDATE `nestgroup` SET `Name_1`= '{name}' WHERE `Groupp`= '{group}'";
                        using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
                            updatCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        string InsertQuery = $"INSERT `nestgroup` SET `Groupp`= '{group}',`Name_1`= '{name}'";
                        using (MySqlCommand updatCommand = new MySqlCommand(InsertQuery, connection))
                            updatCommand.ExecuteNonQuery();
                    }

                }
            }
            Savebutton2.Visible = false;
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Savebutton2.Visible = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            DataGridViewCell currentCell = dataGridView.CurrentCell;
            label3.Text = dataGridView.Rows[e.RowIndex].Cells["Nest"].Value.ToString();
            label3.Tag = e.RowIndex.ToString();
            button1.Enabled = true;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            DataGridViewCell currentCell = dataGridView.CurrentCell;
            label2.Text = dataGridView.Rows[e.RowIndex].Cells["Groupp"].Value.ToString();
            label2.Tag = e.RowIndex.ToString();
            button1.Enabled = true;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && int.TryParse(e.Value.ToString(), out int cellValue) && cellValue == 0) // Check if cell value is 0
            {
                e.Value = ""; // Set cell value to empty string to hide 0
                e.FormattingApplied = true; // Indicate that the formatting is applied
            }
        }
    }
}