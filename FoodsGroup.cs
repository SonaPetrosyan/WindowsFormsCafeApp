using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class FoodsGroup : Form
    {
        private MySQLDatabaseHelper dbHelper;
        private DataTable Tablte_215 = new DataTable();
        private DataTable Food_Group = new DataTable();
        private DataTable Resize = new DataTable();
        private DataTable Exist = new DataTable();
        private DataView dataView;
        public FoodsGroup()
        {
            InitializeComponent();

            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");


            string query1 = $"SELECT `Code`,`Name_1`,`Department`,`Group` FROM `table_215` WHERE 1 ";
            Tablte_215 = dbHelper.ExecuteQuery(query1);
            dataGridView1.DataSource = Tablte_215;
            dataGridView1.Columns[0].DataPropertyName = "Code";
            dataGridView1.Columns[1].DataPropertyName = "Name_1";
            dataGridView1.Columns[2].DataPropertyName = "Department";
            dataGridView1.Columns[3].DataPropertyName = "Group";
            dataGridView1.DataSource = Tablte_215;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index > 3)
                {
                    column.Visible = false;
                }
            }

            string query2 = $"SELECT `Group`,`Name_1`,`Name_2`,`Name_3` FROM `foodgroupp` WHERE `Group`>0 ";
            Food_Group = dbHelper.ExecuteQuery(query2);
            dataGridView2.DataSource = Food_Group;
            dataGridView2.Columns[0].DataPropertyName = "Group";
            dataGridView2.Columns[1].DataPropertyName = "Name_1";
            dataGridView2.Columns[2].DataPropertyName = "Name_2";
            dataGridView2.Columns[3].DataPropertyName = "Name_3";
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

            label2.Text = "";
            label3.Text = "";
        }

        private void FoodsGroup_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }
        }

        private void FoodsGroup_ResizeEnd(object sender, EventArgs e)
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

        }

        private void AddButton2_Click(object sender, EventArgs e)
        {
            Savebutton2.Visible = true;
            int groupp = 0;

            foreach (DataRow row in Food_Group.Rows)
            {
                groupp = int.Parse(row["Group"].ToString());
                if (int.Parse(row["Group"].ToString()) > groupp) { groupp++; }
            }
            DataRow newRow = Food_Group.NewRow();
            newRow["Group"] = groupp + 1;
            Food_Group.Rows.Add(newRow);
            int lastRowIndex = Food_Group.Rows.Count - 1;
            dataGridView2.CurrentCell = dataGridView2.Rows[lastRowIndex].Cells[0];
            dataGridView2.BeginEdit(true);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            DataGridViewCell currentCell = dataGridView.CurrentCell;
            label2.Text = dataGridView.Rows[e.RowIndex].Cells["Group"].Value.ToString();
            label2.Tag = e.RowIndex.ToString();
            button1.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            DataGridViewCell currentCell = dataGridView.CurrentCell;
            label3.Text = dataGridView.Rows[e.RowIndex].Cells["Code"].Value.ToString();
            label3.Tag = e.RowIndex.ToString();
            button1.Enabled = true;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Savebutton1.Visible = true;
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Savebutton2.Visible = true;
        }

        private void Savebutton2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = dbHelper.GetConnection();
            connection.Open();
            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                if (dataGridView2.Rows[i].Cells[0].Value != null)
                {

                    Exist = new DataTable();
                    int group = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                    string name1 = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    string name2 = dataGridView2.Rows[i].Cells[2].Value.ToString();
                    string name3 = dataGridView2.Rows[i].Cells[3].Value.ToString();
                    string query = $"SELECT * FROM `FoodGroupp` WHERE `Group` = '{group}'  ";
                    Exist = dbHelper.ExecuteQuery(query);
                    int count = Exist.Rows.Count;
                    if (count > 0)
                    {
                        string UpdateQuery = $"UPDATE `FoodGroupp` SET `Name_1`= '{name1}',`Name_2`= '{name2}',`Name_3`= '{name3}' WHERE `Group`= '{group}'";
                        using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
                            updatCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        string InsertQuery = $"INSERT `FoodGroupp` SET `Group`= '{group}',`Name_1`= '{name1}',`Name_2`= '{name2}',`Name_3`= '{name3}'";
                        using (MySqlCommand updatCommand = new MySqlCommand(InsertQuery, connection))
                            updatCommand.ExecuteNonQuery();
                    }

                }
            }
            Savebutton2.Visible = false;
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

        private void Savebutton1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = dbHelper.GetConnection();
            connection.Open();
            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    string code = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    int group = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    string UpdateQuery = $"UPDATE `table_215` SET `Group`= '{group}' WHERE `Code`= '{code}'";
                    using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
                    updatCommand.ExecuteNonQuery();
                }
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string txt = SearchBox.Text.Trim();
            dataView.RowFilter = $"(Code+Name_1) LIKE '%{txt}%'";
            dataGridView1.DataSource = dataView;
        }
    }
}