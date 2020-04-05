using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Sql;
namespace ImportToiSeries
{
    public partial class Form1 : Form
    {
 //       public String ConnectionString = "Data Source=localhost;Initial Catalog=ARGReports;Trusted_Connection=true";
        public String ConnectionString = "Data Source=localhost;Initial Catalog=ARGReports;Trusted_Connection=true";
        public String ErrorString = "";
        public bool heightError = false;
        public string heightErrorString = "";
        public bool productError = false;
        public string productErrorString = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void tankGaugingDataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tankGaugingDataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tankGaugingData);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tankGaugingData._TankGaugingData' table. You can move, or remove it, as needed.
            this.tankGaugingDataTableAdapter.Fill(this.tankGaugingData._TankGaugingData);
            StoreStatus("AppInfo", "Starting iSeriesImport, AD Name:" + Environment.UserName + ", Machine Name:" + Environment.MachineName);
            chkInspectionRec.Checked = true;

        }
        public static bool StoreStatus(string activity, string Message)
        {
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ARGReports;Persist Security Info=True;Trusted_Connection=true");

            try
            {

                conn.Open();

                // create a SqlCommand object for this connection
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "insert into applicationLog ([appName],[appfunction], [appdetails], [datedone]) values ('TankGaugingImport-iSeriesImport','" + activity + "','" + Message + "'," + "getdate()) ";
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
        public void CheckForTooTallReadings()
        {
            //check for any readings higher than the tank height
            SqlConnection conn =
       new SqlConnection(ConnectionString);
            conn.Open();
             int recordCount = tankGaugingDataDataGridView.RowCount;
             string tankNumber="";
             int inchPart,  feet, inches;
             double totalHeight;
           
             
            for (int i = 0; i < recordCount - 1; i++)
             {
                 tankNumber = tankGaugingDataDataGridView.Rows[i].Cells[0].Value.ToString();
                 inchPart = int.Parse(tankGaugingDataDataGridView.Rows[i].Cells[4].Value.ToString());
             
                 feet = int.Parse(tankGaugingDataDataGridView.Rows[i].Cells[2].Value.ToString());
                 inches = int.Parse(tankGaugingDataDataGridView.Rows[i].Cells[3].Value.ToString());
                 totalHeight = (feet * 12) + inches;
                 if (inchPart > 0) {
                 totalHeight = totalHeight + (inchPart / 100); 
                 }
                int result = CheckFeetAndInches(tankNumber, totalHeight.ToString(), conn) ;
                 if (result < 1)
                 {

                 }
                 else
                 {
                     heightError = true;
                     heightErrorString=heightErrorString+ Environment.NewLine + " The reading for tank # " + tankNumber + " is higher than the actual height of the tank, which is " + result + " inches.";
                 }




             }

        }
        public void CheckForNewTankReadings()
        {
            //see if there are any that have not been entered yesterday
            SqlConnection conn =
       new SqlConnection(ConnectionString);
            conn.Open();
             int recordCount = tankGaugingDataDataGridView.RowCount;
             string tankNumber="", prodCode="";
             int temperature;
             double totalHeight;
           
             
            for (int i = 0; i < recordCount - 1; i++)
             {
                 tankNumber = tankGaugingDataDataGridView.Rows[i].Cells[0].Value.ToString();
                 prodCode =tankGaugingDataDataGridView.Rows[i].Cells[7].Value.ToString();
             
               try
                {
                    temperature = int.Parse(tankGaugingDataDataGridView.Rows[i].Cells[5].Value.ToString());
                }
                catch (Exception)
                {
                    temperature = 0;
                }
                bool result = CheckForProductYesterday(tankNumber,prodCode, temperature,conn) ;
                 if (result)
                 {

                 }
                 else
                 {
                     productError = true;
                     productErrorString = productErrorString + Environment.NewLine + " The reading for tank # " + tankNumber + " requires a temperature - there is no previous reading for that tank with the same product to take the temp from.";
                 }




             }


        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public string CallStoredProcToCheck(string FileGroup)
        {
            System.Data.Odbc.OdbcConnection OdbcCon = null;
            System.Data.Odbc.OdbcCommand OdbcCmd = null;
            string param2 = "PC", param3 = "CHK", param4 = "";
            //Instantiate new instances
            OdbcCon = new System.Data.Odbc.OdbcConnection();
            OdbcCmd = new System.Data.Odbc.OdbcCommand();

            //Open a connection to an iSeries data source       
            OdbcCon.ConnectionString = "Driver={iSeries Access ODBC Driver};System=10.1.1.2;Uid=TANK;Pwd=INVENTORY;";

            //Set up the procedure call
            OdbcCmd.CommandText = "{CALL QS36F.IN075C( ?, ?, ?, ?,?)}";
            OdbcCmd.CommandType = CommandType.StoredProcedure;
            //Accosicate the command with the connection
            OdbcCmd.Connection = OdbcCon;
            //Open the connection
            OdbcCon.Open();

            string dateIs = recordDate.SelectionStart.ToShortDateString();
            string formattedDate = dateIs.Substring(dateIs.LastIndexOf("/") + 1);
            string day = dateIs.Substring(dateIs.IndexOf("/") + 1, (dateIs.LastIndexOf("/")) - dateIs.IndexOf("/") - 1);
            string month = dateIs.Substring(0, dateIs.IndexOf("/"));
            int dayI = int.Parse(day);
            int monthI = int.Parse(month);
            day = dayI.ToString("00");
            month = monthI.ToString("00");
           // MessageBox.Show(formattedDate + "month=" + month + "day=" + day);
            string finalDate = formattedDate + month + day;


            //Create the parameter objects to pass and get data from procedure
            OdbcCmd.Parameters.Add(FileGroup, System.Data.Odbc.OdbcType.Char, 1).Direction = ParameterDirection.InputOutput;
            OdbcCmd.Parameters.Add(finalDate, System.Data.Odbc.OdbcType.Char, 8).Direction = ParameterDirection.InputOutput;
            
            OdbcCmd.Parameters.Add(param2, System.Data.Odbc.OdbcType.Char, 2).Direction = ParameterDirection.InputOutput;
            OdbcCmd.Parameters.Add(param3, System.Data.Odbc.OdbcType.Char, 3).Direction = ParameterDirection.InputOutput;
            OdbcCmd.Parameters.Add(param4, System.Data.Odbc.OdbcType.Char, 100).Direction = ParameterDirection.InputOutput;



            //set the value of the parms to pass
            OdbcCmd.Parameters[0].Value = FileGroup;
            OdbcCmd.Parameters[1].Value = finalDate;
            OdbcCmd.Parameters[2].Value = param2;
            OdbcCmd.Parameters[3].Value = param3;
            OdbcCmd.Parameters[4].Value = param4;

            //call the procedure
            OdbcCmd.ExecuteNonQuery();
            //put the results into a textbox control
            FileGroup = OdbcCmd.Parameters[0].Value.ToString();
            finalDate = OdbcCmd.Parameters[1].Value.ToString();
            param2 = OdbcCmd.Parameters[2].Value.ToString();
            param3 = OdbcCmd.Parameters[3].Value.ToString();
            param4 = OdbcCmd.Parameters[4].Value.ToString();


            //close the connection
            OdbcCon.Close();
            return param4;

        }
        public string CallStoredProcToRun(string FileGroup)
        {
            System.Data.Odbc.OdbcConnection OdbcCon = null;
            System.Data.Odbc.OdbcCommand OdbcCmd = null;
            string param2 = "PC", param3 = "RUN", param4 = "";
            //Instantiate new instances
            OdbcCon = new System.Data.Odbc.OdbcConnection();
            OdbcCmd = new System.Data.Odbc.OdbcCommand();

            //Open a connection to an iSeries data source       
            OdbcCon.ConnectionString = "Driver={iSeries Access ODBC Driver};System=10.1.1.2;Uid=TANK;Pwd=INVENTORY;";

            //Set up the procedure call
            OdbcCmd.CommandText = "{CALL QS36F.IN075C( ?, ?, ?, ?,?)}";
            OdbcCmd.CommandType = CommandType.StoredProcedure;
            //Accosicate the command with the connection
            OdbcCmd.Connection = OdbcCon;
            //Open the connection
            OdbcCon.Open();

            string dateIs = recordDate.SelectionStart.ToShortDateString();
            string formattedDate = dateIs.Substring(dateIs.LastIndexOf("/") + 1);
            string day = dateIs.Substring(dateIs.IndexOf("/") + 1, (dateIs.LastIndexOf("/")) - dateIs.IndexOf("/") - 1);
            string month = dateIs.Substring(0, dateIs.IndexOf("/"));
            int dayI = int.Parse(day);
            int monthI = int.Parse(month);
            day = dayI.ToString("00");
            month = monthI.ToString("00");
            // MessageBox.Show(formattedDate + "month=" + month + "day=" + day);
            string finalDate = formattedDate + month + day;


            //Create the parameter objects to pass and get data from procedure
            OdbcCmd.Parameters.Add(FileGroup, System.Data.Odbc.OdbcType.Char, 1).Direction = ParameterDirection.InputOutput;
            OdbcCmd.Parameters.Add(finalDate, System.Data.Odbc.OdbcType.Char, 8).Direction = ParameterDirection.InputOutput;

            OdbcCmd.Parameters.Add(param2, System.Data.Odbc.OdbcType.Char, 2).Direction = ParameterDirection.InputOutput;
            OdbcCmd.Parameters.Add(param3, System.Data.Odbc.OdbcType.Char, 3).Direction = ParameterDirection.InputOutput;
            OdbcCmd.Parameters.Add(param4, System.Data.Odbc.OdbcType.Char, 100).Direction = ParameterDirection.InputOutput;



            //set the value of the parms to pass
            OdbcCmd.Parameters[0].Value = FileGroup;
            OdbcCmd.Parameters[1].Value = finalDate;
            OdbcCmd.Parameters[2].Value = param2;
            OdbcCmd.Parameters[3].Value = param3;
            OdbcCmd.Parameters[4].Value = param4;

            //call the procedure
            OdbcCmd.ExecuteNonQuery();
            //put the results into a textbox control
            FileGroup = OdbcCmd.Parameters[0].Value.ToString();
            finalDate = OdbcCmd.Parameters[1].Value.ToString();
            param2 = OdbcCmd.Parameters[2].Value.ToString();
            param3 = OdbcCmd.Parameters[3].Value.ToString();
            param4 = OdbcCmd.Parameters[4].Value.ToString();


            //close the connection
            OdbcCon.Close();
            return param4;

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int recordCount = tankGaugingDataDataGridView.RowCount;
            //first, check to see if there are any errors
 String tankNumber = "", ProductCode = "", ProductCodeDescription = "",Inspection = "",InOutage = "";
            DateTime DateTimeTaken = DateTime.Now;
            int temperature= 0;
            int feet = 0, inches = 0, inchPart = 0;

            bool inchError = false;
            bool tempError = false;
            bool inchPartError = false;

           /* CheckForTooTallReadings();


            CheckForNewTankReadings();

            if (heightError)
            {
                MessageBox.Show(heightErrorString);
            }
            if (productError)
            {
                MessageBox.Show(productErrorString);
            }
            */

            for (int i = 0; i < recordCount - 1; i++)
            {
                inches = int.Parse(tankGaugingDataDataGridView.Rows[i].Cells[3].Value.ToString());
                if (inches > 11)
                {
                    inchError = true;
                }
                try
                {
                    temperature = int.Parse(tankGaugingDataDataGridView.Rows[i].Cells[5].Value.ToString());
                }
                catch (Exception)
                {
                    temperature = 0;
                }
                if (temperature > 999)
                {
                    tempError = true;
                }
                String inchPartString = "";

                inchPartString = tankGaugingDataDataGridView.Rows[i].Cells[4].Value.ToString();
                if (inchPartString.Length > 2)
                {
                    inchPartError = true;
                }
                tankGaugingDataDataGridView.Rows[i].Cells[4].Value = inchPartString.Replace(".", "");

                //fix inchpart if has decimal
               

                // error off if inches > 11
            }

            if (inchError)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("One of the entries has an inch value great than 11.");

                    
            }
            if (inchPartError)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("One of the entries has an inch part value greater than 99.");


            }
            if (tempError)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("One of the entries has an temperature value great than 999.");


            }
            Cursor.Current = Cursors.Default;
            if (!inchError && !tempError && !productError && !heightError && !inchPartError)
            {

                Cursor.Current = Cursors.WaitCursor;

        string returnProc = CallStoredProcToCheck("G");
                if (returnProc.Trim().Length < 1)
                {

                //go through each record
                List<String> listSent = new List<String>();

                for (int i = 0; i < recordCount - 1; i++)
                {
                  
                    tankNumber = tankGaugingDataDataGridView.Rows[i].Cells[0].Value.ToString();
                    bool inList = listSent.Contains(tankNumber);

                    if (!inList)
                    {
                        inchPart = int.Parse( tankGaugingDataDataGridView.Rows[i].Cells[4].Value.ToString());
                        DateTimeTaken = DateTime.Parse(tankGaugingDataDataGridView.Rows[i].Cells[1].Value.ToString());
                        feet = int.Parse(tankGaugingDataDataGridView.Rows[i].Cells[2].Value.ToString());
                        inches = int.Parse(tankGaugingDataDataGridView.Rows[i].Cells[3].Value.ToString());
                        try
                        {
                            temperature = int.Parse(tankGaugingDataDataGridView.Rows[i].Cells[5].Value.ToString());
                        }
                        catch (Exception)
                        {
                            temperature = 0;
                        }
                        Inspection = tankGaugingDataDataGridView.Rows[i].Cells[6].Value.ToString();
                        if (Inspection.Length < 1)
                        {
                            Inspection = "Y";
                        }
                        ProductCode = tankGaugingDataDataGridView.Rows[i].Cells[7].Value.ToString();
                        while (ProductCode.Length < 4)
                        {
                            ProductCode = "0" + ProductCode;
                        }
                        ProductCodeDescription = tankGaugingDataDataGridView.Rows[i].Cells[8].Value.ToString();
                        InOutage = tankGaugingDataDataGridView.Rows[i].Cells[9].Value.ToString();
                        InOutage = InOutage.ToUpper();
                        if (feet == 0 && inches == 0 && inchPart == 0)
                        {
                            temperature = 0;
                        }

                        SendRecordToISeries(tankNumber, DateTimeTaken, feet, inches, inchPart, temperature, Inspection, ProductCode, ProductCodeDescription, InOutage);
                        listSent.Add(tankNumber);
                    }
                }
             
                    returnProc = CallStoredProcToRun("G");
                }
                else
                {
                   // Cursor.Current = Cursors.Default;
                  //  MessageBox.Show("There was an error sending the data to production, try again later");
                }


                if (returnProc.Trim().Length > 0)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("There was an error sending the data to the iBox: " + returnProc);
                }
                 
                // if there is an error message, show it
                if (ErrorString.Length > 0)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("There has been errors importing. The errors will show up below, please create a help desk ticket and send them to IT.");
                    tankGaugingDataDataGridView.Visible = false;
                    txtErrorText.Text = ErrorString;
                    txtErrorText.Left = 20;
                    txtErrorText.Top = 75;
                    txtErrorText.Width = 900;
                    txtErrorText.Height = 300;

                }
                else
                {
                    if (returnProc.Trim().Length > 0)
                    {

                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Import is complete! You can now access these records in the iSeries.");
                        tankGaugingDataDataGridView.Visible = false;
                    }
                    }
                Cursor.Current = Cursors.Default;
            }


        }
        public bool SendRecordToISeries(String tankNumber, DateTime dateTimeTaken, int feet, int inches, int inchesPart, int temperature, string Inspection, string ProdCode, string ProdCodeDescription, string InOutage)
        {
            bool returnStatus = true;
            string SQLStr = null;
            string ConnString = null;
            string result = "good";
            String commandToDo = "";
            try
            {

                //Connstring = Server Name, Database Name, Windows Authentication 
                ConnString = "Driver={iSeries Access ODBC Driver};System=10.1.1.2;Uid=TANK;Pwd=INVENTORY;";



                //Write to SQL

                System.Data.Odbc.OdbcConnection SQLConn = new System.Data.Odbc.OdbcConnection();
                //The SQL Connection
                System.Data.Odbc.OdbcCommand SQLCmd = new System.Data.Odbc.OdbcCommand();
                //The SQL Command

                SQLConn.ConnectionString = ConnString;
                //Set the Connection String
                SQLConn.Open();
                //Open the connection
                String dateTimeTakenAsiSeries = "",rightNowAsISeries ="";
                String fourDigitTankNumber = tankNumber.ToString();
                while (fourDigitTankNumber.Length < 4)
                {
                    fourDigitTankNumber = "0" + fourDigitTankNumber;
                }
                DateTime RightNow = DateTime.Now;
                dateTimeTakenAsiSeries = dateTimeTaken.ToString("yyyyMMddHHmm");
                rightNowAsISeries = RightNow.ToString("yyyyMMddHHmm");
                commandToDo = "INSERT INTO QS36F.GINTKGA (IGCO,IGLOC,IGXKEY,IGPRCD,IGTANK,IGDTTM,IGTOFT,IGTOIN,IGTFIN,IGIO,IGTEMP,IGFRIN,IGGSDT)";
                commandToDo = commandToDo + " VALUES ";
                commandToDo = commandToDo + " (10,'001','      ','" + ProdCode.ToString() + "','" + fourDigitTankNumber.ToString() + "'," + dateTimeTakenAsiSeries + "," + feet.ToString() + "," + inches.ToString() + "," + inchesPart.ToString() + ",'" + InOutage.ToString() + "'," + temperature.ToString() + ",100,'" + rightNowAsISeries + "') ";
        
              
                SQLCmd.Connection = SQLConn;
                //Sets the Connection to use with the SQL Command
                SQLCmd.CommandText = commandToDo;
                //Sets the SQL String
                SQLCmd.ExecuteNonQuery();
                //Executes SQL Commands Non-Querys only
              
                //Close the connection 
                SQLConn.Close();
                MoveRecordToImportedTable(tankNumber, dateTimeTaken, feet, inches, inchesPart, temperature, Inspection, ProdCode,ProdCodeDescription, InOutage);
             
            }
            catch (Exception e)
            {

                AppendToErrorString("Sending data to iBox error:" + Environment.NewLine + "SQL Command tried:" + Environment.NewLine + commandToDo + Environment.NewLine + "Exception:" + e.ToString());
            }
          
            return returnStatus;
        }
        public int CheckFeetAndInches(string tankNumber, string totalInches, SqlConnection conn)
        {

            int totalSize = 0;

            new SqlConnection(ConnectionString);

        

            //get bokey
            String commandToDo = "";
            commandToDo = "select (TCHTFT*12) + (TCHTIN) as TotalInches from GINCHRT where TCTANK = " + tankNumber;
           

            SqlCommand commandKey = conn.CreateCommand();
            commandKey.CommandText = commandToDo;

            commandKey.CommandType = CommandType.Text;

            SqlDataReader results = commandKey.ExecuteReader();
            int totalInchesReturned = 0;
            int returnVal = 0;
            if (results.Read())
            {
                totalInchesReturned = int.Parse(results["TotalInches"].ToString());
            }
            if (totalInchesReturned > int.Parse(totalInches))
            {
                returnVal = 0;
            }
            else
            {
                returnVal = totalInchesReturned;
            }

            results.Close();
            return returnVal;


        }
        public bool CheckForProductYesterday(string tankNumber, string prodCode, int temp, SqlConnection conn)
        {
            bool hadProduct = true;
            if (temp > 0)
            {
                hadProduct = true;
            }
            else
            {
                new SqlConnection(ConnectionString);

              //  conn.Open();

                //get bokey
                String commandToDo = "";
                commandToDo = "select [ISODate]  ,[THTANK]      ,[THEFDT]      ,[THPRCD]      ,[THEFD8]      ,[THF001] from [GINTKHS] where THTANK = '" + tankNumber + "' and THLOC = 001 and THCO = 10 order by isodate desc";


                SqlCommand commandKey = conn.CreateCommand();
                commandKey.CommandText = commandToDo;

                commandKey.CommandType = CommandType.Text;

                SqlDataReader results = commandKey.ExecuteReader();
                if (results.Read())
                {
                    if (results["THPRCD"].ToString().Equals(prodCode))
                    {
                        hadProduct = true;
                    }
                    else
                    {
                        hadProduct = false;
                    }
                }
                else
                {
                    hadProduct = false;
                }
                results.Close();
            }

            return hadProduct;
        }

        public bool MoveRecordToImportedTable(String tankNumber, DateTime dateTimeTaken, int feet, int inches, int inchesPart, int temperature, string Inspection, string ProdCode, string ProductCodeDescription, string InOutage)
        {
            bool returnStatus = true;
            // copy to imported table
            SqlConnection conn =
          new SqlConnection(ConnectionString);

            conn.Open();

            //get bokey
            String commandToDo = "";
            commandToDo = "INSERT INTO [ARGReports].[dbo].[ImportedTankGaugingData]([TankNumber],[DateTimeTaken],[Feet],[Inches],[InchesPart],[Temperature],[Inspection],[ProdCode],[ProdDescription],[InOutage])";
            commandToDo = commandToDo + " VALUES ";
            commandToDo = commandToDo + " ('" + tankNumber + "','" + dateTimeTaken.ToString() + "'," + feet.ToString() + "," + inches.ToString() + "," + inchesPart.ToString() + "," + temperature.ToString() + ",'" + Inspection.ToString() + "','" + ProdCode.ToString() + "','" + ProductCodeDescription.ToString() + "','" + InOutage.ToString() + "') ";
         
           
            SqlCommand commandKey = conn.CreateCommand();
            commandKey.CommandText = commandToDo;

            commandKey.CommandType = CommandType.Text;
        String  commandToDo2 ="";
            try
            {
              /*  commandKey.ExecuteNonQuery();


                commandToDo2 = "delete from TankGaugingData where tankNumber = '" + tankNumber + "' and datetimeTaken = '" + dateTimeTaken.ToString() + "' and feet = '" + feet.ToString() + "' and inches = '" + inches.ToString() + "' and temperature = '" + temperature.ToString() + "' and ProdCode = '" + ProdCode.ToString() + "'";

                commandKey.CommandText = commandToDo2;
             commandKey.ExecuteNonQuery(); */
            }
            catch (Exception e)
            {




                AppendToErrorString("Error saving to backup table: " + Environment.NewLine + e.ToString() + Environment.NewLine + "SQL Statement for backup attempted:" + Environment.NewLine + commandToDo+ Environment.NewLine + "SQL Statement for delete attempted:" + Environment.NewLine + commandToDo2);

            }


            conn.Close();
            conn.Dispose();

            //remove from current table

            return returnStatus;
        }
        public void AppendToErrorString(String message)
        {
            ErrorString = ErrorString + Environment.NewLine + message;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string returnProc = CallStoredProcToCheck("Z");
            if (returnProc.Trim().Length < 1)
            {
                returnProc = CallStoredProcToRun("Z");
            }
            else
            {
                MessageBox.Show("There was an error sending the data to production, try again later");
            }


            if ((returnProc.Trim().Length) > 0)
            {
                MessageBox.Show("There was an error sending the data to production: " + returnProc);
            }
        }

        private void recordDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (chkInspectionRec.Checked)
            {
                this.tankGaugingDataTableAdapter.Adapter.SelectCommand.CommandText = ("SELECT     TankNumber, DateTimeTaken, Feet, Inches, InchesPart, Temperature, Inspection, ProdCode, ProdDescription, InOutage FROM    TankGaugingData WHERE  InspectionRecord = 1 and    (DATEPART(hh, DateTimeTaken) < 10) AND (DATEPART(dy, DateTimeTaken) = DATEPART(dy, '" + recordDate.SelectionStart.ToShortDateString() + "')) AND (DATEPART(yy, DateTimeTaken) = DATEPART(yy, '" + recordDate.SelectionStart.ToShortDateString() + "')) AND (DATEPART(hh, DateTimeTaken) > 1) ORDER BY DateTimeTaken DESC");

                this.tankGaugingDataTableAdapter.Fill(this.tankGaugingData._TankGaugingData);
                tankGaugingDataDataGridView.Visible = true;
            } else
            {
                this.tankGaugingDataTableAdapter.Adapter.SelectCommand.CommandText = ("SELECT     TankNumber, DateTimeTaken, Feet, Inches, InchesPart, Temperature, Inspection, ProdCode, ProdDescription, InOutage FROM    TankGaugingData WHERE     (DATEPART(hh, DateTimeTaken) < 10) AND (DATEPART(dy, DateTimeTaken) = DATEPART(dy, '" + recordDate.SelectionStart.ToShortDateString() + "')) AND (DATEPART(yy, DateTimeTaken) = DATEPART(yy, '" + recordDate.SelectionStart.ToShortDateString() + "')) AND (DATEPART(hh, DateTimeTaken) > 1) ORDER BY DateTimeTaken DESC");

                this.tankGaugingDataTableAdapter.Fill(this.tankGaugingData._TankGaugingData);
                tankGaugingDataDataGridView.Visible = true;
            }
          
       
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            string dateIs = recordDate.SelectionStart.ToShortDateString();
            string formattedDate = dateIs.Substring(dateIs.LastIndexOf("/")+1);
            string day = dateIs.Substring(dateIs.IndexOf("/") + 1, (dateIs.LastIndexOf("/"))- dateIs.IndexOf("/")-1);
            string month = dateIs.Substring(0, dateIs.IndexOf("/"));
            int dayI = int.Parse(day);
            int monthI = int.Parse(month);
            day = dayI.ToString("00");
            month = monthI.ToString("00");
            MessageBox.Show(formattedDate + "month=" + month + "day=" + day);
        }

        private void tankGaugingDataBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void tankGaugingDataDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void tankGaugingDataDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                lblCurTank.Text = tankGaugingDataDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
         

            //        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ARGReports;Persist Security Info=True;Trusted_Connection=true");
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ARGReports;Persist Security Info=True;Trusted_Connection=true");
            conn.Open();

            SqlCommand commandKey = conn.CreateCommand();

            string commdnToDo = "select distinct TCUNIT from ARGReports.dbo.localTanksWithLatestProducts where TCTANK = '" + lblCurTank.Text + "'";

            commandKey.CommandText = commdnToDo;
            commandKey.CommandType = CommandType.Text;

            SqlDataReader results = commandKey.ExecuteReader(CommandBehavior.CloseConnection);
            if (results.Read())
            {
                lblUnit.Text = results["TCUNIT"].ToString();
            }
            }
            catch (Exception ex)
            {

            }
         
        }

        private void chkInspectionRec_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInspectionRec.Checked)
            {
                this.tankGaugingDataTableAdapter.Adapter.SelectCommand.CommandText = ("SELECT     TankNumber, DateTimeTaken, Feet, Inches, InchesPart, Temperature, Inspection, ProdCode, ProdDescription, InOutage FROM    TankGaugingData WHERE  InspectionRecord = 1 and    (DATEPART(hh, DateTimeTaken) < 10) AND (DATEPART(dy, DateTimeTaken) = DATEPART(dy, '" + recordDate.SelectionStart.ToShortDateString() + "')) AND (DATEPART(yy, DateTimeTaken) = DATEPART(yy, '" + recordDate.SelectionStart.ToShortDateString() + "')) AND (DATEPART(hh, DateTimeTaken) > 1) ORDER BY DateTimeTaken DESC");

                this.tankGaugingDataTableAdapter.Fill(this.tankGaugingData._TankGaugingData);
                tankGaugingDataDataGridView.Visible = true;
            } else
            {
                this.tankGaugingDataTableAdapter.Adapter.SelectCommand.CommandText = ("SELECT     TankNumber, DateTimeTaken, Feet, Inches, InchesPart, Temperature, Inspection, ProdCode, ProdDescription, InOutage FROM    TankGaugingData WHERE     (DATEPART(hh, DateTimeTaken) < 10) AND (DATEPART(dy, DateTimeTaken) = DATEPART(dy, '" + recordDate.SelectionStart.ToShortDateString() + "')) AND (DATEPART(yy, DateTimeTaken) = DATEPART(yy, '" + recordDate.SelectionStart.ToShortDateString() + "')) AND (DATEPART(hh, DateTimeTaken) > 1) ORDER BY DateTimeTaken DESC");

                this.tankGaugingDataTableAdapter.Fill(this.tankGaugingData._TankGaugingData);
                tankGaugingDataDataGridView.Visible = true;
            }
        }
    }
}
