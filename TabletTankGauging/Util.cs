using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Text;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data;


namespace TabletTankGauging
{
    class Util
    {
      static  DataTable tanks;
        public static string currentUsername;
        public static string currentDepartment;
        public static TankGaugingReport currentReport;
        public static int currentTankIndex;
        public static bool CheckForCrude()
        {
            string path = @"c:\\Tablet_Tank_Gauging\\UnitType.dat";
            string readText = "";
            try
            {
              readText = File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                readText = "";
            }
         
            Boolean isCrude = false;
            if (readText.Equals("CrudeUnit"))
            {
                isCrude = true;
            }
            return isCrude;
        }
        public static void UpdateTodaysTankInfoOnDisk()
        {
            if (!Directory.Exists("C:\\Tablet_Tank_Gauging\\"))
            {
                Directory.CreateDirectory("C:\\Tablet_Tank_Gauging\\");

            }


            string path = "C:\\Tablet_Tank_Gauging\\";
            path = path + "\\TodaysTankInfo.tdt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            DateTime lastUpdate = File.GetLastWriteTime(path);
            double numHours = (DateTime.Now - lastUpdate).TotalHours;
            if (numHours > 1)
            {
                {
                    SqlDataReader adInfo = getTodaysTankInfo();
                    using (System.IO.StreamWriter file =
                   new System.IO.StreamWriter(@path, false, Encoding.Default, 1000))
                    {
                        if (adInfo.HasRows)
                        {
                            while (adInfo.Read())
                            {

                                string newRow = adInfo["TankNumber"].ToString();
                             

                                file.WriteLine(newRow);
                            }
                        }




                    }


                }
            }







        }
        public static void UpdateProductTempRangesInfoOnDisk()
        {
            if (!Directory.Exists("C:\\Tablet_Tank_Gauging\\"))
            {
                Directory.CreateDirectory("C:\\Tablet_Tank_Gauging\\");

            }


            string path = "C:\\Tablet_Tank_Gauging\\";
            path = path + "\\ProductTempRanges.tdt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            DateTime lastUpdate = File.GetLastWriteTime(path);
            double numHours = (DateTime.Now - lastUpdate).TotalHours;
            if (numHours > 1)
            {
                {
                    SqlDataReader adInfo = getProductTempRangesInfo();
                    using (System.IO.StreamWriter file =
                   new System.IO.StreamWriter(@path, false, Encoding.Default, 1000))
                    {
                        if (adInfo.HasRows)
                        {
                            while (adInfo.Read())
                            {

                                string newRow = adInfo["ProdCode"].ToString();
                                newRow = newRow + "\t" + adInfo["LowTemp"].ToString();
                                newRow = newRow + "\t" + adInfo["HighTemp"].ToString();
                                file.WriteLine(newRow);
                            }
                        }




                    }


                }
            }







        }
        public static void UpdateTankInfoOnDisk()
        {
            if (!Directory.Exists("C:\\Tablet_Tank_Gauging\\"))
            {
                Directory.CreateDirectory("C:\\Tablet_Tank_Gauging\\");
         
            }


            string path = "C:\\Tablet_Tank_Gauging\\";
            path = path + "\\TankInfo.tdt";


            DateTime lastUpdate = File.GetLastWriteTime(path);
            double numHours = (DateTime.Now - lastUpdate).TotalHours;
            if (numHours > 1)
            {
                {
                    SqlDataReader adInfo = getNewTankInfo();
                    using (System.IO.StreamWriter file =
                   new System.IO.StreamWriter(@path, false, Encoding.Default, 1000))
                    {
                        if (adInfo.HasRows)
                        {
                            while (adInfo.Read())
                            {

                                string newRow = adInfo["TCUNIT"].ToString();
                                newRow = newRow + "\t" + adInfo["TCTANK"].ToString();
                                newRow = newRow + "\t" + adInfo["THPRCD"].ToString();
                                newRow = newRow + "\t" + adInfo["TPDESC"].ToString();

                                file.WriteLine(newRow);
                            }
                        }




                    }


                }
            }







        }
        public static DataTable GetTankInfoDataTable( )
        {
            string path = "C:\\Tablet_Tank_Gauging\\";
            path = path + "\\TankInfo.tdt";
            int count = 0;

            DataTable adTable = new DataTable();
            adTable.Columns.Add("TCUNIT");
            adTable.Columns.Add("TCTANK");
            adTable.Columns.Add("THPRCD");
            adTable.Columns.Add("TPDESC");

            using (var rd = new StreamReader(path))
            {



                while (!rd.EndOfStream)
                {

                    var rawLine = rd.ReadLine();

                    var splits = rawLine.Split('\t');

                    string TCUNIT, TCTANK, THPRCD, TPDESC;
                    if (splits.Length > 1)
                    {

                        TCUNIT = splits[0];

                        TCTANK = splits[1];

                        THPRCD = splits[2];

                        TPDESC = splits[3];

                        DataRow dr = adTable.NewRow();
                        dr[0] = TCUNIT;
                        dr[1] = TCTANK;
                        dr[2] = THPRCD;
                        dr[3] = TPDESC;
                        adTable.Rows.Add(dr);
                    }

                    count++;

                }
            }


            return adTable;

        }
        public static DataTable GetProductTempRangesDataTable()
        {
            string path = "C:\\Tablet_Tank_Gauging\\";
            path = path + "\\ProductTempRanges.tdt";
            int count = 0;

            DataTable adTable = new DataTable();
            adTable.Columns.Add("ProdCode");
            adTable.Columns.Add("LowTemp");
            adTable.Columns.Add("HighTemp");
         

            using (var rd = new StreamReader(path))
            {



                while (!rd.EndOfStream)
                {

                    var rawLine = rd.ReadLine();

                    var splits = rawLine.Split('\t');

                    string TCUNIT, TCTANK, THPRCD, TPDESC;
                    if (splits.Length > 1)
                    {

                        TCUNIT = splits[0];

                        TCTANK = splits[1];

                        THPRCD = splits[2];
 

                        DataRow dr = adTable.NewRow();
                        dr[0] = TCUNIT;
                        dr[1] = TCTANK;
                        dr[2] = THPRCD;
                     
                        adTable.Rows.Add(dr);
                    }

                    count++;

                }
            }


            return adTable;

        }
        public static bool AlreadyHaveTank(string TankNumber)
        {
            if (tanks == null)
            {
                tanks = Util.GetTodaysTankInfoDataTable();
            }
             
            int count = 0;
            bool foundOne = false;
            while (count < tanks.Rows.Count)
            {
                DataRow thisRow = tanks.Rows[count];
                string doneTankNumber = thisRow[0].ToString();
                if (doneTankNumber.ToString().ToLower().Equals(TankNumber.ToString().ToLower()))
                {
                    foundOne = true;
                }
                count++;
            }
            return foundOne;
        }
        public static void SaveLogEntry(string entry)
        {
            string logFileName = "";
            DateTime rightNow = DateTime.Now;
            logFileName = rightNow.Year.ToString() + rightNow.Month.ToString() + rightNow.Day.ToString();

            using (StreamWriter w = File.AppendText("C:\\Tablet_Tank_Gauging\\Log_" + logFileName + ".txt"))
            {
                Log(entry, w);
              
            }
        }
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }
        public static DataTable GetTodaysTankInfoDataTable()
        {
            string path = "C:\\Tablet_Tank_Gauging\\";
            path = path + "\\TodaysTankInfo.tdt";
            int count = 0;

            DataTable adTable = new DataTable();
            adTable.Columns.Add("TankNumber");
        

            using (var rd = new StreamReader(path))
            {



                while (!rd.EndOfStream)
                {
                    var rawLine = rd.ReadLine();
   
                        DataRow dr = adTable.NewRow();
                        dr[0] = rawLine;
                        adTable.Rows.Add(dr);
                    count++;

                }
            }


            return adTable;

        }

        public static SqlDataReader getNewTankInfo()
        {

            SqlConnection conn =
                  new SqlConnection("Data Source=localhost;Initial Catalog=ARGReports;Trusted_Connection=True;");

            conn.Open();

            //get bokey

            SqlCommand commandKey = conn.CreateCommand();
            commandKey.CommandText = "select distinct TCUNIT,TCTANK, THPRCD,TPDESC, ordinalNumber from ARGReports.dbo.localTanksWithLatestProducts_NoAutomatedTanks order by ordinalNumber";
            commandKey.CommandType = CommandType.Text;

            SqlDataReader adInfo = commandKey.ExecuteReader();
            return adInfo;
        }

        public static SqlDataReader getTodaysTankInfo()
        {

            SqlConnection conn =
                  new SqlConnection("Data Source=localhost;Initial Catalog=ARGReports;Trusted_Connection=True;");

            conn.Open();

            //get bokey

            SqlCommand commandKey = conn.CreateCommand();
            commandKey.CommandText = "select TankNumber from ARGReports.dbo.Todays_Tank_Gauges order by TankNumber";
            commandKey.CommandType = CommandType.Text;

            SqlDataReader adInfo = commandKey.ExecuteReader();
            return adInfo;
        }

        public static SqlDataReader getProductTempRangesInfo()
        {

            SqlConnection conn =
                  new SqlConnection("Data Source=localhost;Initial Catalog=ARGReports;Trusted_Connection=True;");

            conn.Open();

            //get bokey

            SqlCommand commandKey = conn.CreateCommand();
            commandKey.CommandText = "select * from [ARGReports].[dbo].[ProductTempRanges]";
            commandKey.CommandType = CommandType.Text;

            SqlDataReader adInfo = commandKey.ExecuteReader();
            return adInfo;
        }


    }
}
