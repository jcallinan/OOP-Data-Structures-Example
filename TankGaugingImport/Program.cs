using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.Odbc;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Sql;
namespace TankGaugingImport
{
    class Program
    {
     private StringBuilder m_Sb;
     public static string ConnectionString;
        public static string DirectoryToCheck;
        static void Main(string[] args)
        {
            //ConnectionString = "Data Source=localhost;Initial Catalog=ARGReports;Trusted_Connection=true";
            ConnectionString = "Data Source=localhost;Initial Catalog=ARGReports;Trusted_Connection=true";
            DirectoryToCheck = "\\\\file-server\\General\\Tank Gauging Data\\Temp\\";
            var txtFiles = System.IO.Directory.EnumerateFiles(DirectoryToCheck, "*.csv");
            //get a list of files in the folder
            foreach (string currentFile in txtFiles)
            {
                FileInfo f = new FileInfo(currentFile);
                long s1 = f.Length;
                if (s1 > 0)
                {
                    bool uploadStat = false;
                    try
                    {
                        uploadStat = UploadFile(currentFile);
                    }
                    catch (Exception e)
                    {
                        uploadStat = false;
                    }
                    if (uploadStat)
                    {
                        MoveFile(currentFile, DirectoryToCheck + "Backup\\");
                    }
                }
            }
            
           
            

            
          


            //email report
           // Console.ReadLine();


        }

        public static bool UploadFile(String fileName)
        {
            
            bool returnStatus = true;
           // AppendToStatusFile("UploadFile called:" + fileName);

            DataSet ds = new DataSet();
            // Creates and opens an ODBC connection
            string strConnString = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + DirectoryToCheck.Trim() + ";Extensions=csv;MaxScanRows=0;Persist Security Info=False";
		string sql_select;
		OdbcConnection conn;
		conn = new OdbcConnection(strConnString.Trim());
		conn.Open();
        sql_select = "select * from [" +Path.GetFileName( fileName) + "]";

        OdbcCommand commandSourceData =
                    new OdbcCommand(sql_select, conn);

       

        //closes the connection
      
        OdbcDataReader dataReader =
        commandSourceData.ExecuteReader();

        // Creates schema table. 
        // It gives column names for create table command.
        DataTable dt;
        dt = dataReader.GetSchemaTable();
        DateTime OldDate = DateTime.Now.AddYears(-100);
        Boolean dontDoIt = false;
        try
        {
            while (dataReader.Read())
            {
                String tankNumber = "", ProductCode = "", ProductCodeDescription = "", Inspection = "", InOutage = "";
                DateTime DateTimeTaken = DateTime.Now;
                int temperature = 0;
                int feet = 0, inches = 0, inchPart = 0;
                dontDoIt = false;
                tankNumber = dataReader[0].ToString();
                try
                {
                    DateTimeTaken = DateTime.Parse(dataReader[3].ToString());
                }
                catch (Exception ex)
                {
                    DateTimeTaken = OldDate;
                    dontDoIt = true;
                }
                try
                {
                    feet = int.Parse(dataReader[4].ToString());
                }
                catch (Exception ex)
                {
                    feet = 0;
                    AppendToStatusFile("Couldn't get Feet");
                    dontDoIt = true;


                }
                try
                {
                    inches = int.Parse(dataReader[5].ToString());
                }
                catch (Exception ex)
                {
                    inches = 0;
                    dontDoIt = true;
                    AppendToStatusFile("Couldn't get inches");

                }
                try
                {
                    inchPart = int.Parse(dataReader[6].ToString());
                }
                catch (Exception ex)
                {
                    inchPart = 0;
                    //  dontDoIt = true;
                   // AppendToStatusFile("Couldn't get inchPart");

                }

                try
                {
                    temperature = int.Parse(dataReader[7].ToString());
                }
                catch (Exception)
                {
                    temperature = 0; 
                    AppendToStatusFile("Couldn't get temperature");
                }
                Inspection = dataReader[8].ToString(); 
                ProductCode = dataReader[1].ToString();
                ProductCodeDescription = dataReader[2].ToString();
                ProductCodeDescription = ProductCodeDescription.Replace(",", "");
                if (ProductCodeDescription.Length > 50)
                {     
                    ProductCodeDescription = ProductCodeDescription.Substring(0,50);
                } 
                


                InOutage = dataReader[9].ToString();
                if (InOutage.Length > 1)
                {
                    InOutage = "";
                }
                if (DateTimeTaken.Equals(OldDate))
                {
                    AppendToStatusFile("Couldn't format date: " + dataReader[3].ToString());
                }
                else
                {
                    if (!dontDoIt)
                    {
                        if (DateTimeTaken > DateTime.Today.AddDays(-2)) {
                                CheckForRecordAndInsert(tankNumber, DateTimeTaken, feet, inches, inchPart, temperature, Inspection, ProductCode, ProductCodeDescription, InOutage);
                           
                      
                        }
                       
                        dontDoIt = false;
                    }
                    else
                    {
                        AppendToStatusFile("Couldn't enter record: " + dataReader[0].ToString() + "," + dataReader[1].ToString() + "," + dataReader[2].ToString() + "," + dataReader[3].ToString() + "," + dataReader[4].ToString() + "," + dataReader[5].ToString() + "," + dataReader[6].ToString() + "," + dataReader[7].ToString() + "," + dataReader[8].ToString() + "," + dataReader[9].ToString());

                    }
                }

            }
        }
        catch (Exception e) {
          AppendToStatusFile("Couldn't open file:" + e.ToString());
        
        }


             conn.Close();
            return returnStatus;


        }
        public static bool CheckForRecordAndInsert(String tankNumber, DateTime dateTimeTaken, int feet, int inches, int inchesPart, int temperature, string Inspection, string ProdCode, string ProductCodeDescription, string InOutage)
        {
            bool returnStatus = true;
            //   AppendToStatusFile("InsertOneRecord called:" + tankNumber + "," + dateTimeTaken.ToString() + "," + feet.ToString() + "," + inches.ToString() + "," + inchesPart.ToString() + "," + temperature.ToString() + "," + Inspection.ToString() + "," + ProdCode.ToString() + "," + ProductCodeDescription.ToString() + "," + InOutage.ToString());
            SqlConnection conn =
            new SqlConnection(ConnectionString);
                String commandToDo = "";
                commandToDo = "select * from   [ARGReports].[dbo].[TankGaugingData] where [TankNumber] = '" + tankNumber + "' and [DateTimeTaken] = '" + dateTimeTaken.ToString()  +"'";
            //   AppendToStatusFile("SQL command: " + commandToDo);
            SqlCommand commandKey = conn.CreateCommand();
            commandKey.CommandText = commandToDo;

            commandKey.CommandType = CommandType.Text;
            conn.Open();
            SqlDataReader results = commandKey.ExecuteReader(CommandBehavior.CloseConnection);
            if (results.HasRows)
            {
                returnStatus = true;
            } else {
                DateTime today = DateTime.Today;
                String todaysDate = today.ToString("dd-MM-yyyy");
              
                //   AppendToStatusFile("InsertOneRecord called:" + tankNumber + "," + dateTimeTaken.ToString() + "," + feet.ToString() + "," + inches.ToString() + "," + inchesPart.ToString() + "," + temperature.ToString() + "," + Inspection.ToString() + "," + ProdCode.ToString() + "," + ProductCodeDescription.ToString() + "," + InOutage.ToString());
              

             
                if (tankNumber.Equals("356"))
                {
                    String text = "";


                }
                //get bokey
                
                commandToDo = "INSERT INTO [ARGReports].[dbo].[TankGaugingData] ([TankNumber],[DateTimeTaken],[Feet],[Inches],[InchesPart],[Temperature],[Inspection],[ProdCode],[ProdDescription],[InOutage])";
                commandToDo = commandToDo + " VALUES ";
                commandToDo = commandToDo + " ('" + tankNumber + "','" + dateTimeTaken.ToString() + "'," + feet.ToString() + "," + inches.ToString() + "," + inchesPart.ToString() + "," + temperature.ToString() + ",'" + Inspection.ToString() + "','" + ProdCode.ToString() + "','" + ProductCodeDescription.ToString() + "','" + InOutage.ToString() + "') ";
                //   AppendToStatusFile("SQL command: " + commandToDo);
               
                commandKey.CommandText = commandToDo;

                commandKey.CommandType = CommandType.Text;

                
                    commandKey.ExecuteNonQuery();
             
            }
            conn.Close();
            conn.Dispose();

            return returnStatus;

        }
        public static bool InsertOneRecord(String tankNumber, DateTime dateTimeTaken, int feet, int inches, int inchesPart, int temperature, string Inspection, string ProdCode, string ProductCodeDescription,string InOutage)
        {
              DateTime today = DateTime.Today;
            String todaysDate = today.ToString("dd-MM-yyyy");
            bool returnStatus = true;
         //   AppendToStatusFile("InsertOneRecord called:" + tankNumber + "," + dateTimeTaken.ToString() + "," + feet.ToString() + "," + inches.ToString() + "," + inchesPart.ToString() + "," + temperature.ToString() + "," + Inspection.ToString() + "," + ProdCode.ToString() + "," + ProductCodeDescription.ToString() + "," + InOutage.ToString());
            SqlConnection conn =
            new SqlConnection(ConnectionString);

            conn.Open();
            if (tankNumber.Equals("356"))
            {
                String text = "";


            }
            //get bokey
            String commandToDo = "";
            commandToDo = "INSERT INTO [ARGReports].[dbo].[TankGaugingData] ([TankNumber],[DateTimeTaken],[Feet],[Inches],[InchesPart],[Temperature],[Inspection],[ProdCode],[ProdDescription],[InOutage])";
                commandToDo = commandToDo + " VALUES ";
                commandToDo = commandToDo + " ('" + tankNumber + "','" + dateTimeTaken.ToString() + "'," + feet.ToString() + "," + inches.ToString() + "," + inchesPart.ToString() + "," + temperature.ToString() + ",'" + Inspection.ToString() + "','" + ProdCode.ToString() + "','" + ProductCodeDescription.ToString() + "','" + InOutage.ToString() + "') ";
          //   AppendToStatusFile("SQL command: " + commandToDo);
            SqlCommand commandKey = conn.CreateCommand();
            commandKey.CommandText = commandToDo;

            commandKey.CommandType = CommandType.Text;

            try
            {
                commandKey.ExecuteNonQuery();
            }
            catch (Exception e)
            {
              



                AppendToErrorFile(DirectoryToCheck + "\\ErrorRecords\\errorLog-" + todaysDate + ".txt",e.ToString() + " -  data:" +  tankNumber + "," + dateTimeTaken.ToString() + "," + feet.ToString() + "," + inches.ToString() + "," + inchesPart.ToString() + "," + temperature.ToString() + "," + Inspection.ToString() + "," + ProdCode.ToString() + "," + ProductCodeDescription.ToString());

            }
            conn.Close();
            conn.Dispose();
            
            return returnStatus;
        }   
        public static bool MoveFile(String fileName, String destination)
        {
            bool returnStatus = true;
          //  AppendToStatusFile("MoveFile called:" + fileName);
            try
            {  File.Move(fileName, destination + Path.GetFileName(fileName));
            }
            catch (Exception ex)
            {
            }
          
            return returnStatus;
        }
        public static bool AppendToErrorFile(String filename, String textToAppend)
        {
            bool returnStatus = true;
        //    File.AppendAllText(filename, string.Format("{0}{1}", textToAppend, Environment.NewLine));
            return returnStatus;
        }
             public static bool AppendToStatusFile(String textToAppend)
        {
        //    Console.WriteLine(textToAppend);
            bool returnStatus = true;
        //    File.AppendAllText(DirectoryToCheck + "statusLog" + DateTime.Now.ToShortDateString().Replace("/","-") + ".txt", string.Format("{0}{1}",textToAppend, Environment.NewLine));
            return returnStatus;
        }
      
    }
}

