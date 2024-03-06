//using System;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using MySql.Data.MySqlClient;
using System.Xml.Linq;
using System.Linq;

namespace WindowsFormsApp4
{
    public partial class users : Form
    {
        private DataTable dataTableusers = new DataTable();
        private DataTable Resize = new DataTable();
        private MySQLDatabaseHelper dbHelper;
        private DataView dataView;

        public users()
        {
            InitializeComponent();
            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
            string query = $"SELECT `id`,`Login`, `Password`, `Passqart`, `Position`, `Name`, `Holl`,`Restaurant` FROM `users` WHERE 1 ";
            dataTableusers = dbHelper.ExecuteQuery(query);
            dataGridView1.DataSource = dataTableusers;
            dataView = new DataView(dataTableusers);
            dataGridView1.Columns[0].DataPropertyName = "Id";
            dataGridView1.Columns[1].DataPropertyName = "Login";
            dataGridView1.Columns[2].DataPropertyName = "Password";
            dataGridView1.Columns[3].DataPropertyName = "Passqart";
            dataGridView1.Columns[4].DataPropertyName = "Position";
            dataGridView1.Columns[5].DataPropertyName = "Name";
            dataGridView1.Columns[6].DataPropertyName = "Holl";
            dataGridView1.Columns[7].DataPropertyName = "Restaurant";
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index > 7)
                {
                    column.Visible = false;
                }
            }


            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);

            MySqlConnection connection = dbHelper.GetConnection();
            connection.Close();
        }




        public void PopulateDataTableUser()
        {

        }

        public void SaveButton_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = dbHelper.GetConnection();

            foreach (DataRow row in dataTableusers.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string log = row["login"].ToString();
                string passw = row["password"].ToString();
                string passq = row["passqart"].ToString();
                string posi = row["position"].ToString();
                string pow = row["powers"].ToString();
                string end = row["end"].ToString();
                this.Text= posi;
                if (id > 0)
                {
                    connection.Open();
                    //   string updateTable1Query = $"UPDATE users SET login = '{log}',password='{passw}',passqart='{passq}',position='{posi}',powers='{pow}',end='{end}' WHERE id = {id}";
                    string updateTable1Query = $"UPDATE users SET `login` = '{log}',`password`='{passw}',`passqart`='{passq}',`position`='{posi}' WHERE `id` = {id}";
                    using (MySqlCommand updateTable1Command = new MySqlCommand(updateTable1Query, connection))
                        updateTable1Command.ExecuteNonQuery();
                    connection.Close();
                }
                this.Close();
            }
        }

        private void users_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }
        }

        private void users_ResizeEnd(object sender, EventArgs e)
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
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SaveButton.Visible = true;
        }

        private void SearchBox2_TextChanged(object sender, EventArgs e)
        {
            String txt = SearchBox2.Text;
            dataView = new DataView(dataTableusers);
            dataView.RowFilter = $"(Login+Password+Name) LIKE '%{txt}%'";
            dataGridView1.DataSource = dataView;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (dataView.Count > 0)
            {
                int id = 0;
                int _holl = 0;
                int _restaurant = 0;
                foreach (DataRow row in dataTableusers.Rows)
                {
                    if (int.Parse(row["Holl"].ToString()) > 0) _holl = int.Parse(row["Holl"].ToString());
                    if (int.Parse(row["Restaurant"].ToString()) > 0) _restaurant = int.Parse(row["Restaurant"].ToString());
                    if (int.Parse(row["Id"].ToString()) >= id) id = int.Parse(row["Id"].ToString()) + 1;
                }
                DataRow newRow = dataTableusers.NewRow();
                dataTableusers.Rows.Add(newRow);
                newRow["Id"] = id;
                newRow["Holl"] = _holl;
                newRow["Restaurant"] = _restaurant;
                {
                    int lastRowIndex = dataGridView1.Rows.Count - 2;
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
            SaveButton.Visible = true;
        }
        private void SaveButton_Click_1(object sender, EventArgs e)
        {
            int count = 0;
            MySqlConnection connection = dbHelper.GetConnection();
            connection.Open();
            foreach (DataRow row in dataTableusers.Rows)
            {
                string query = $"SELECT COUNT(*) FROM users WHERE Id = @Id ";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", row["Id"]);
                    count = Convert.ToInt32(command.ExecuteScalar());
                }
                if (count == 0)
                {
                  String query1= $"INSERT users SET `Id` = '{row["Id"]}',`Login` = '{row["Login"]}',`Password`='{row["Password"]}'," +
                            $"`Passqart`='{row["Passqart"]}',`Name` = '{row["Name"]}',`Position`='{row["Position"]}'," +
                            $"`Holl`='{row["Holl"]}',`Restaurant` = '{row["Restaurant"]}' ";
                    using (MySqlCommand insertCommand = new MySqlCommand(query1, connection))
                        insertCommand.ExecuteNonQuery();
                }
                else
                {
                    String query1 = $"UPDATE users SET `Login` = '{row["Login"]}',`Password`='{row["Password"]}'," +
                              $"`Passqart`='{row["Passqart"]}',`Name` = '{row["Name"]}',`Position`='{row["Position"]}'," +
                              $"`Holl`='{row["Holl"]}',`Restaurant` = '{row["Restaurant"]}' WHERE `Id` = '{row["Id"]}' ";
                    using (MySqlCommand insertCommand = new MySqlCommand(query1, connection))
                        insertCommand.ExecuteNonQuery();
                }
            }
            connection.Close();
        }
    }
}
