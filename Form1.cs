using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp4.images;
namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private MySQLDatabaseHelper dbHelper;
        private int _ooperator;  //_ooperator-ը աշխատողի Id-ն է
        private int _holl;  //_holl-ը սրահի համարն է
        private int _restaurant;  //_restaurant-ը ռեստորանի համարն է
        private DataTable Resize = new DataTable();
        public Form1(int opperator, int holl, int restaurant)
        {

            InitializeComponent();
           // InitForm();
            _ooperator = opperator;
            _holl = holl;
            _restaurant = restaurant;
            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
            MySqlConnection connection = dbHelper.GetConnection();
            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);

        }




        private void main11_Click(object sender, EventArgs e)
        {
            order orderInstance = new order(_ooperator, _holl, _restaurant);
            orderInstance.Show();
        }

        private void main45_Click(object sender, EventArgs e)
        {
            users user = new users();
            user.Show();
        }

        private void main47_Click(object sender, EventArgs e)
        {
            Powers powers = new Powers();
            powers.Show();
        }

        private void Updater_215_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=kafe_arm;User ID=root;Password='';CharSet = utf8mb4;";
            string jsonFilePath = "d:\\hayrik\\programmer\\json\\json_215.json";
            // Call the static method from another class
            TableUpdater.UpdateTableFromJson(connectionString, jsonFilePath, "215");
        }

        private void update_211_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=kafe_arm;User ID=root;Password='';CharSet = utf8mb4;";
            string jsonFilePath = "d:\\hayrik\\programmer\\json\\json_211.json";
            // Call the static method from another class
            TableUpdater.UpdateTableFromJson(connectionString, jsonFilePath, "211");
        }

        private void update213_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=kafe_arm;User ID=root;Password='';CharSet = utf8mb4;";
            string jsonFilePath = "d:\\hayrik\\programmer\\json\\json_213.json";
            // Call the static method from another class
            TableUpdater.UpdateTableFromJson(connectionString, jsonFilePath, "213");
        }

        private void main21_Click(object sender, EventArgs e)
        {
            Foods FoodsInstance = new Foods();
            FoodsInstance.Show();
        }

        private void main22_Click(object sender, EventArgs e)
        {
            Materials MaterialsInstance = new Materials();
            MaterialsInstance.Show();

        }

        private void main12_Click(object sender, EventArgs e)
        {
            Purchase PurchaseInstance = new Purchase(_ooperator, _restaurant);
            PurchaseInstance.Show();
        }

        private void main23_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=kafe_arm;User ID=root;Password='';CharSet = utf8mb4;";
            string jsonFilePath = "d:\\hayrik\\programmer\\json\\json_111.json";
            // Call the static method from another class
            TableUpdater.UpdateTableFromJson(connectionString, jsonFilePath, "111");
        }

        private void main42_Click(object sender, EventArgs e)
        {
            Nest NestInstance = new Nest();
            NestInstance.Show();
        }

        private void main43_Click(object sender, EventArgs e)
        {
            FoodsGroup FoodsGroup = new FoodsGroup();
            FoodsGroup.Show();
        }

        private void group_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=kafe_arm;User ID=root;Password='';CharSet = utf8mb4;";
            string jsonFilePath = "d:\\hayrik\\programmer\\json\\group.json";
            // Call the static method from another class
            TableUpdater.UpdateTableFromJson(connectionString, jsonFilePath, "group");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=kafe_arm;User ID=root;Password='';CharSet = utf8mb4;";
            string jsonFilePath = "d:\\hayrik\\programmer\\json\\AdditionGroups.json";
            // Call the static method from another class
            TableUpdater.UpdateTableFromJson(connectionString, jsonFilePath, "addition");
        }

        private void main44_Click(object sender, EventArgs e)
        {
            Additions Additions = new Additions();
            Additions.Show();
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
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

        }

        private void main13_Click(object sender, EventArgs e)
        {
            Inventory InventoryInstance = new Inventory(_ooperator, _restaurant, 0);
            InventoryInstance.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Inventory InventoryInstance = new Inventory(_ooperator, _restaurant, 1);
            InventoryInstance.Show();
        }

        private void main31_Click(object sender, EventArgs e)
        {
            GoodsMovement GoodsMovementInstance = new GoodsMovement(_restaurant);
            GoodsMovementInstance.Show();
        }

        private void main41_Click(object sender, EventArgs e)
        {

        }

        private void main23_Click_1(object sender, EventArgs e)
        {
            Standart StandartInstance = new Standart(_restaurant);
            StandartInstance.Show();
        }

        private void main15_Click(object sender, EventArgs e)
        {

        }

        private void main14_Click(object sender, EventArgs e)
        {
            provisional provisionalInstance = new provisional(_ooperator, _holl, _restaurant);
            provisionalInstance.Show();
        }
    }
}
