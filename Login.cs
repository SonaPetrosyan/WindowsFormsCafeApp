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

namespace WindowsFormsApp4
{


    public partial class Login : Form
    {
        private MySQLDatabaseHelper dbHelper;

        public Login()
        {
            InitializeComponent();
            // Initialize the DatabaseHelper with your SQL Server credentials

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close the database connection when the form is closing
            dbHelper.CloseConnection();
        }

        private void loginfield_Enter(object sender, EventArgs e)
        {
            loginfield.Text = "";
            loginfield.BackColor = Color.White;
            buttonlogin.Enabled = false;
        }

        private void loginfield_Leave(object sender, EventArgs e)
        {
            if (loginfield.Text.Length == 0)
            {
                loginfield.BackColor = Color.RosyBrown;
            }
        }

        private void passfield_Enter(object sender, EventArgs e)
        {
            buttonlogin.Enabled = false;
            passfield.Text = "";
            passfield.BackColor = Color.White;
        }

        private void passfield_Leave(object sender, EventArgs e)

        {
            if (passfield.Text.Length == 0)
            {
                passfield.BackColor = Color.RosyBrown;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            loginfield.Text = "";
            loginfield.Focus();
            buttonlogin.Enabled = false;
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            passfield.Text = "";
            passfield.Focus();
            buttonlogin.Enabled = false;
        }

        private void loginfield_TextChanged(object sender, EventArgs e)
        {
            if (loginfield.Text.Length > 0 && passfield.Text.Length > 0)
            {
                buttonlogin.Enabled = true;
            }
        }

        private void passfield_TextChanged(object sender, EventArgs e)
        {
            if (loginfield.Text.Length > 0 && passfield.Text.Length > 0)
            {
                buttonlogin.Enabled = true;
            }
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {

            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
            string log = loginfield.Text;
            string pass = passfield.Text;

            string query = $"SELECT * FROM `users` WHERE `Login` = '{log}' AND `Password` = '{pass}' ";
            DataTable Table_Login = dbHelper.ExecuteQuery(query);
            string q = Table_Login.Rows.Count.ToString();

            string pow = "";
            int opperator = 0;
            int holl = 0;
            int restaurant = 0;
            if (Table_Login.Rows.Count > 0) //user - ը գոյություն ունի
            {
                foreach (DataRow row in Table_Login.Rows)//ստուգում ենք լիազորությունը
                {
                    opperator = Convert.ToInt32(row["Id"]);// աշխատակցի Id-ն
                    holl = Convert.ToInt32(row["Holl"]);//Սրահի համարը
                    restaurant = Convert.ToInt32(row["Restaurant"]);//ռեստորանի համարը
                    //this.Tag = "id" + id + ";" + pow;

                }
                if (pow == "1" || pow == "2")
                {
                   // DataSynchronization();
                   // AccessForm1Controls();//Form1-ի կոճակները հասանելի է դարձնում

                }
                dbHelper.CloseConnection();
                Form1 form1 = new Form1(opperator, holl, restaurant);

                form1.Show();
            }
            else //user - ը գոյություն չունի
            {
                message.Text = "Անվան կամ գաղտնագրի սխալ";
                int porc = int.Parse(message.Tag.ToString()) - 1;
                if (porc == 0)
                {
                    dbHelper.CloseConnection();
                    this.Close();
                }
                string mnac = porc.ToString();
                message.Tag = mnac;
                message.Text = "Անվան կամ գաղտնագրի սխալ։ Ունեք եւս " + mnac + " փորձ";
                message.Visible = true;
            }



            // Bind the DataTable to a DataGridView
            //   dataGridView.DataSource = dataTable;

        }
    }
}
