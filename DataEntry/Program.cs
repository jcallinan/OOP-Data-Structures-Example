using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
namespace DataEntry
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit); 
        }
        static void OnProcessExit(object sender, EventArgs e)
        {
            StoreStatus("AppInfo", "Ending DataEntry, AD Name:" + Environment.UserName + ", Machine Name:" + Environment.MachineName);
        }
        public static bool StoreStatus(string activity, string Message)
        {
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ARGReports;Persist Security Info=True;Trusted_Connection=true");

            try
            {

                conn.Open();

                // create a SqlCommand object for this connection
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "insert into applicationLog ([appName],[appfunction], [appdetails], [datedone]) values ('TankGaugingImport-DataEntry','" + activity + "','" + Message + "'," + "getdate()) ";
                command.CommandType = CommandType.Text;


                command.ExecuteNonQuery();
            }
            catch (Exception et)
            {
                MessageBox.Show(et.ToString());
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
    }
}
