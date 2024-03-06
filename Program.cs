using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp4
{
    internal static partial class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // եթե \SEANS\SEANS.DBF - չկա, ապա ստեղծել 
            string CurrentDirectoryEnv = Environment.CurrentDirectory; // ընթացիկ պանակ **  current directory

            int position = CurrentDirectoryEnv.IndexOf("WindowsForms");
            string file = CurrentDirectoryEnv.Substring(position) + @"\SEANS";
            string filepath = Path.Combine(file, "SEANS.DBF");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //    Application.Run(new Form1(CurrentDirectoryEnv));
             Application.Run(new Login());
            // Application.Run(new users());

        }
    }

}

