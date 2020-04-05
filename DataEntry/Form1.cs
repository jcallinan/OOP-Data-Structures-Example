using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Deployment.Application;
using System.Reflection;
using System.Net.Mail;
namespace DataEntry
{
    public partial class Form1 : Form
    {
        public static string ConnectionString;
        public static string UnitSelected;
        public static Int32 NumberOfTanksOnScreen;
        public static Int32 NumberOfTanksSaved;
        public DateTime[] datesUsed;
        public string errorText;
        public static DateTime CurrentDateTimeUsed;
        private void CreateDesktopIcon()
        {
    
           
            string company, description;
         
                company = "American Refining Group";



                description = "Tank Gauging Import - Data Entry";
          
        
                string desktopPath = string.Empty;
                desktopPath = string.Concat(
                                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                                "\\",
                                description,
                                ".appref-ms");

                string shortcutName = string.Empty;
                shortcutName = string.Concat(
                                 Environment.GetFolderPath(Environment.SpecialFolder.Programs),
                                 "\\",
                                 company,
                                 "\\",
                                 description,
                                 ".appref-ms");
                    if (!File.Exists(desktopPath)) {
                         System.IO.File.Copy(shortcutName, desktopPath, true);
                    }
              
          
        
    }





        public Form1()
        {
            InitializeComponent();
            ConnectionString = "Data Source=localhost;Initial Catalog=ARGReports;Trusted_Connection=true";
            try
            {
                CreateDesktopIcon();

            }
            
            catch (Exception ex)
            {

            }
          
        }


        public static int ErrorInd = 0;

        private void miBrlHse_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadTanksAndPutInGrid("Barrel House");
            this.Cursor = Cursors.Default;
        }
        public SqlDataReader LoadTanks(string unitName)
        {


//            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ARGReports;Persist Security Info=True;Trusted_Connection=true");
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ARGReports;Persist Security Info=True;Trusted_Connection=true");
            conn.Open();

            SqlCommand commandKey = conn.CreateCommand();
            string commdnToDo = "select distinct TCTANK, THPRCD,TPDESC from ARGReports.dbo.localTanksWithLatestProducts ";

            if (unitName.Equals("Foster Brook Bulk")) {
                commdnToDo = commdnToDo + "where (ltrim(TCUNIT) = 'FBBULK' or TCTANK = '0619' or TCTANK = '0620') and (TCTANK NOT IN (Select TankNumber from AutomatedTanks)) order by TCTANK";
            }
            if (unitName.Equals("Barrel House"))
            {
                commdnToDo = commdnToDo + "where (ltrim(TCUNIT) = 'BRLHSE') and (TCTANK NOT IN (Select TankNumber from AutomatedTanks))  order by TCTANK";
            } if (unitName.Equals("Crude Farm"))
            {
                commdnToDo = commdnToDo + "where (ltrim(TCUNIT) = 'CRDFRM' and TCTANK != '0619' and TCTANK != '0620') and (TCTANK NOT IN (Select TankNumber from AutomatedTanks))  order by TCTANK";
            } if (unitName.Equals("RoseExtract"))
            {
                commdnToDo = commdnToDo + "where (ltrim(TCUNIT) = 'EXTRAC' or  ltrim(TCUNIT) = 'ROSE') and (TCTANK NOT IN (Select TankNumber from AutomatedTanks))    order by TCTANK";
            } if (unitName.Equals("Boiler House"))
            {
                commdnToDo = commdnToDo + "where (ltrim(TCUNIT) = 'BOILHS' ) and (TCTANK NOT IN (Select TankNumber from AutomatedTanks))  order by TCTANK";
            } if (unitName.Equals("Crude Unit"))
            {
                commdnToDo = commdnToDo + "where (ltrim(TCUNIT) = 'CRDUNT') and (TCTANK NOT IN (Select TankNumber from AutomatedTanks))  order by TCTANK";
            } if (unitName.Equals("4 Bay"))
            {
                commdnToDo = commdnToDo + "where (ltrim(TCUNIT) = '4BAYLD' ) and (TCTANK NOT IN (Select TankNumber from AutomatedTanks))   order by TCTANK";
            } if (unitName.Equals("Rose Unit"))
            {
                commdnToDo = commdnToDo + "where (ltrim(TCUNIT) = 'ROSE') and (TCTANK NOT IN (Select TankNumber from AutomatedTanks))    order by TCTANK";
            } if (unitName.Equals("Platformer"))
            {
                commdnToDo = commdnToDo + "where (ltrim(TCUNIT) = 'PLATFO') and (TCTANK NOT IN (Select TankNumber from AutomatedTanks))  order by TCTANK";
            } if (unitName.Equals("MEK"))
            {
                commdnToDo = commdnToDo + "where (ltrim(TCUNIT) = 'MEK') and (TCTANK NOT IN (Select TankNumber from AutomatedTanks))  order by TCTANK";
            }
            if (unitName.Equals("Packaging Plant"))
            {
                commdnToDo = commdnToDo + "where (ltrim(TCUNIT) = 'PKGPLT') and (TCTANK NOT IN (Select TankNumber from AutomatedTanks))  order by TCTANK";
            }
            if (unitName.Equals("Foster Brook Blend"))
            {
                commdnToDo = commdnToDo + "where (ltrim(TCUNIT) = 'FBBLND') and (TCTANK NOT IN (Select TankNumber from AutomatedTanks))  order by TCTANK";
            }
            commandKey.CommandText = commdnToDo;




            commandKey.CommandType = CommandType.Text;


           return commandKey.ExecuteReader(CommandBehavior.CloseConnection);
            
        }
        public SqlDataReader GetTanksJustInserted(string unitName, DateTime dateTimeTaken)
        {
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ARGReports;Persist Security Info=True;Trusted_Connection=true");
            conn.Open();

            SqlCommand commandKey = conn.CreateCommand();
            string commdnToDo = "select *  from ARGReports.dbo.TankGaugingData where datediff(minute,DateTimeTaken , '" + dateTimeTaken + "') < 10 and TankNumber in (select TCTANK from localTanksWithLatestProducts ";

            if (unitName.Equals("EXTRAC"))
            {
                commdnToDo = commdnToDo + " where (ltrim(TCUNIT) = 'EXTRAC' or ltrim(TCUNIT) = 'ROSE')";
            }
            else
            {
            commdnToDo = commdnToDo + " where (ltrim(TCUNIT) = '" + unitName + "') ";
            }
            
         
            
            
            commdnToDo = commdnToDo + " and (TCTANK NOT IN (Select TankNumber from AutomatedTanks))) ;";
            commandKey.CommandText = commdnToDo;




            commandKey.CommandType = CommandType.Text;
            return commandKey.ExecuteReader(CommandBehavior.CloseConnection);

        }
        public static bool SendEmail(string from, string to, string subject, string message, string username)
        {
            bool stat = false;
            try
            {

                // create the email message 

                MailMessage Mmessage = new MailMessage(
                   from,
                   to,
                   subject,
                   "<strong>Tank Gauging Error:</strong><BR/>" + message + "<br />");
                Mmessage.IsBodyHtml = true;

                string emailServer = "brad-exchange.amref.com";
                SmtpClient client = new SmtpClient(emailServer);

                client.UseDefaultCredentials = true;
                //client.Send(Mmessage);



                //  StoreStatus("Email", "Emailing: " + to + " ,From: " + from + ", Subject: " + subject + "," + "Body: " + message);
                stat = true;
            }

            catch (Exception ex)
            {
                StoreStatus("Failure in SendEmail", "Emailing: " + to + " ,From: " + from + ", Subject: " + subject + "," + "Body: " + message + ",Exception: " + ex.Message.ToString());



            }
            return stat;

        }
        public void CheckForGoodSave(string unitName, DateTime dateTimeTaken)
        {
            errorText = "";


            string iSeriesUnitName = "";

            if (unitName.Equals("Foster Brook Bulk"))
            {
                iSeriesUnitName = "FBBULK";
            }
            if (unitName.Equals("Barrel House"))
            {
                iSeriesUnitName =  "BRLHSE";
            } if (unitName.Equals("Crude Farm"))
            {
                iSeriesUnitName =  "CRDFRM";
            } if (unitName.Equals("RoseExtract"))
            {
                iSeriesUnitName =  "EXTRAC";
            } if (unitName.Equals("Boiler House"))
            {
                iSeriesUnitName =  "BOILHS";
            } if (unitName.Equals("Crude Unit"))
            {
                iSeriesUnitName = "CRDUNT";
            } if (unitName.Equals("4 Bay"))
            {
                iSeriesUnitName = "4BAYLD";
            } if (unitName.Equals("Rose Unit"))
            {
                iSeriesUnitName =  "ROSE";
            } if (unitName.Equals("Platformer"))
            {
                iSeriesUnitName =  "PLATFO";
            } if (unitName.Equals("MEK"))
            {
                iSeriesUnitName =  "MEK";
            }
            if (unitName.Equals("Packaging Plant"))
            {
                iSeriesUnitName =  "PKGPLT";
            }
            if (unitName.Equals("Foster Brook Blend"))
            {
                iSeriesUnitName = "FBBLND";
            }

            SqlDataReader storedData = GetTanksJustInserted(iSeriesUnitName, dateTimeTaken);
                string[,] productCodesAndTanksToFind = new  string[200,2];
                string[,] productCodesAndTanksInData = new string[200,2];
            for (int i = 0; i < tankGaugingDataDataGridView.Rows.Count-1; i++)
            {

                productCodesAndTanksToFind[i, 0] = tankGaugingDataDataGridView.Rows[i].Cells["Tank #"].Value.ToString();
                productCodesAndTanksToFind[i, 1] = tankGaugingDataDataGridView.Rows[i].Cells["Product Code"].Value.ToString();

            }
            int count = 0;
            if (storedData.HasRows)
            {
                while (storedData.Read())
            {

                string currentProductCode = storedData["prodCode"].ToString();
                string currentTank = storedData["TankNumber"].ToString();
                productCodesAndTanksInData[count, 0] = currentTank;
                productCodesAndTanksInData[count, 1] = currentProductCode;

                    
                    
                    count++;
            }
            }
           
            //both arrays are built, let's go

            for (int i = 0; i < 200; i++)
            {

                string prodCodeToCheck = productCodesAndTanksToFind[i, 1];
                string tankNumToCheck = productCodesAndTanksToFind[i, 0];


                if (!string.IsNullOrEmpty(prodCodeToCheck) && !string.IsNullOrEmpty(tankNumToCheck))
                {
                if (checkMDArrayForItem(productCodesAndTanksInData,tankNumToCheck , prodCodeToCheck))
                {

                }
                else {
                // it's missing
                    errorText = errorText + Environment.NewLine + "Tank #: " + tankNumToCheck + ", Product #: " + prodCodeToCheck;
                }
                }
               

            }
            if (errorText.Length > 0)
            {
                MessageBox.Show("We are missing tanks:" + errorText);
                StoreStatus("TankGaugingImport-DataEntry", "Error! Tank gauging data not saved successfully: " + errorText);
                SendEmail("tankgaugingerror@amref.com", "jcallinan@amref.com", "Tank Gauging Error", "Error! Tank gauging data not saved successfully: " + errorText, "tankgauging");
            }


        }
        public bool checkMDArrayForItem(string[,] arrayToCheck, string tankNumber, string prodCode)
        {
            bool status = false;
            for (int i = 0; i < 200; i++ )
            {
                string dbTankNum;
                string dbProdNum;
                dbTankNum = arrayToCheck[i, 0];
                dbProdNum=arrayToCheck[i, 1];

                if (!string.IsNullOrEmpty(dbTankNum) && !string.IsNullOrEmpty(dbProdNum))
                {
                    if (dbTankNum.Equals(tankNumber))
                {
                    if (dbProdNum.Equals(prodCode))
                    {
                        status = true;
                    }
                }
                }
               
            }

            return status;
        }
        public void LoadTanksAndPutInGrid(string unitName) {
            lblTankSaved.Text = "No tanks saved yet.";
            UnitSelected = unitName;
            lblUnit.Text = unitName;
            SqlDataReader listOfTanks = LoadTanks(unitName);
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Tank #", typeof(string)));
            dt.Columns.Add(new DataColumn("Product Code", typeof(string)));
            dt.Columns.Add(new DataColumn("Product Description", typeof(string)));
            dt.Columns.Add(new DataColumn("Date Time", typeof(string)));
            dt.Columns.Add(new DataColumn("Feet", typeof(string)));
            dt.Columns.Add(new DataColumn("Inches", typeof(string)));

          
         //   dt.Columns.Add(new DataColumn("InchesPart", typeof(string)));

           // dt.Columns.Add(inchesPartColumn);
            dt.Columns.Add(new DataColumn("Temperature", typeof(string)));
            dt.Columns.Add(new DataColumn("Inspection", typeof(string)));
            dt.Columns.Add(new DataColumn("InOutage", typeof(string)));
        

            while (listOfTanks.Read()) {
                dr = dt.NewRow();
                DateTime dat;
                dat = System.DateTime.Now;

                dr["Tank #"] = listOfTanks["TCTANK"].ToString();
                dr["Date Time"] = dat.ToString();
                dr["Feet"] = string.Empty;
                dr["Inches"] = string.Empty;
              //  dr["InchesPart"] = string.Empty;
                dr["Temperature"] = string.Empty;
                dr["Inspection"] = "Y";
                dr["Product Code"] = listOfTanks["THPRCD"].ToString();
                dr["Product Description"] = listOfTanks["TPDESC"].ToString().Replace("#","").Replace("'","");
                dr["InOutage"] = string.Empty;
        
                dt.Rows.Add(dr);
            }

            tankGaugingDataDataGridView.DataSource = dt;
            var list11 = new List<String>() { "0", "25", "50", "75" };

            DataGridViewComboBoxColumn inchesPartColumn = new DataGridViewComboBoxColumn();
            inchesPartColumn.Name = "InchesPart";
            inchesPartColumn.ValueType = typeof(string);
            
            inchesPartColumn.DataSource = list11;
            if (tankGaugingDataDataGridView.Columns["InchesPart"] == null)
            {
                    tankGaugingDataDataGridView.Columns.Add(inchesPartColumn);
            }
            

            tankGaugingDataDataGridView.Columns["InchesPart"].DisplayIndex = 6;
            for (int i = 0; i < tankGaugingDataDataGridView.Rows.Count; i++)
            {
                tankGaugingDataDataGridView.Rows[i].Cells["InchesPart"].Value = "0";
            }
            if (UnitSelected.Equals("Barrel House") || UnitSelected.Equals("Foster Book Blend"))
            {
           
            }
            else
            {
 for (int i = 0; i < tankGaugingDataDataGridView.Rows.Count; i++)
            {
                tankGaugingDataDataGridView.Rows[i].Cells["Product Code"].ReadOnly = true;
                tankGaugingDataDataGridView.Rows[i].Cells["Product Description"].ReadOnly = true;
                tankGaugingDataDataGridView.Rows[i].Cells["Tank #"].ReadOnly = true;
            }
            }
         
            //update number of tanks on screen
            int numOfRows = tankGaugingDataDataGridView.Rows.Count;
            numOfRows = numOfRows - 1;
            lblNumTanksLoaded.Text = "Number of Tanks Loaded: " + numOfRows;
          
           
        }

        private void tankGaugingDataDataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
               DataGridView.HitTestInfo hitTestInfo = tankGaugingDataDataGridView.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                    tankGaugingDataDataGridView.BeginEdit(true);
                else
                    tankGaugingDataDataGridView.EndEdit();
            }

        }

        private void miFBBlend_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadTanksAndPutInGrid("Foster Brook Blend");
            this.Cursor = Cursors.Default;
        }

        private void miCrudeFarm_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadTanksAndPutInGrid("Crude Farm");
            this.Cursor = Cursors.Default;
        }

        private void miExtract_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadTanksAndPutInGrid("RoseExtract");
            this.Cursor = Cursors.Default;
        }

        private void miBoilerHouse_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadTanksAndPutInGrid("Boiler House");
            this.Cursor = Cursors.Default;
        }

        private void miFosterBrookBulk_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadTanksAndPutInGrid("Foster Brook Bulk");
            this.Cursor = Cursors.Default;
        }

        private void miCrudeUnit_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadTanksAndPutInGrid("Crude Unit");
            this.Cursor = Cursors.Default;
        }

        private void mi4Bay_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadTanksAndPutInGrid("4 Bay");
            this.Cursor = Cursors.Default;
        }

        private void miRoseUnit_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadTanksAndPutInGrid("Rose Unit");
            this.Cursor = Cursors.Default;
        }

        private void miPlatformer_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadTanksAndPutInGrid("Platformer");
            this.Cursor = Cursors.Default;
        }

        private void miMEK_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadTanksAndPutInGrid("MEK");
            this.Cursor = Cursors.Default;
        }

        private void miPackagingPlant_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadTanksAndPutInGrid("Packaging Plant");
            this.Cursor = Cursors.Default;
        }
        public string saveCSV(string unitName)
        {
            StringBuilder sbCSV = new StringBuilder();
            DataTable dt = GetContentAsDataTable(false);
            int intColCount = dt.Columns.Count;
            foreach (DataRowView dr in dt.DefaultView)
            {
                for (int x = 0; x < intColCount; x++)
                {
                    sbCSV.Append(dr[x].ToString());
                    if ((x + 1) != intColCount)
                    {
                        sbCSV.Append(",");
                    }
                }
                sbCSV.Append("\r\n");
            }
            string saveP = "G:\\Tank Gauging Data\\Temp\\" + unitName + "_" + DateTime.Now.ToShortDateString().Replace("/", "-") + "_" + DateTime.Now.ToShortTimeString().Replace(":", "-").Replace(" ", "-") + ".csv";
//            string saveP = "C:\\Tank Gauging Data\\Temp\\" + unitName + "_" + DateTime.Now.ToShortDateString().Replace("/", "-") + "_" + DateTime.Now.ToShortTimeString().Replace(":", "-").Replace(" ", "-") + ".csv";
            using (StreamWriter sw = new StreamWriter(saveP)) 

            {
                sw.Write(sbCSV.ToString());
               
            }
            
            
            return saveP;

        }
        public Boolean saveToDatabase()
        {
            StringBuilder sbCSV = new StringBuilder();
            DataTable dt = GetContentAsDataTable(false);
            int intColCount = dt.Columns.Count;
            string tankNumber;
            DateTime datetimeTaken;
            int feet;
            int inches;
            int inchesPart;
            int temperature;
            string Inspection;
            string ProdCode;
            string ProdCodeDescription;
            string InOutage;
            int countr = 0;
            bool savingStatus = true;
            string errorText = "";

            foreach (DataRowView drT in dt.DefaultView)
            {

                
                int result;
                savingStatus = true;
                if (countr > 0)
                {

                tankNumber = drT["Tank #"].ToString();
                if (int.TryParse(tankNumber, out result))
                {
                    datetimeTaken = DateTime.Parse(drT["Date Time"].ToString());
                    if (int.TryParse(drT["Feet"].ToString(), out result) && drT["Feet"].ToString().Length > 0)
                    {
                       
                    }
                    else
                    {
                        savingStatus = false;
                        errorText = errorText + "Tank: " + tankNumber + "'s Feet is not a number.\r\n";
                    }
                    if (int.TryParse(drT["Inches"].ToString(), out result) && drT["Inches"].ToString().Length > 0)
                    {
                        
                    }
                    else
                    {
                        savingStatus = false;
                        errorText = errorText + "Tank: " + tankNumber + "'s Inches is not a number.\r\n";
                    }
                    string inOutage = "";
                    
                    inOutage = drT["InOutage"].ToString();
                    inOutage = inOutage.ToUpper();
                    //if (inOutage.Equals("I") || inOutage.Equals("O") || inOutage.Equals("E"))
                    //{
                       
                    //}
                    //else
                    //{
                    //    savingStatus = false;
                    //    errorText = errorText + "Tank: " + tankNumber + "'s InOutage field needs to be I, O, or E for empty.\r\nAn outage (O) reading of zero means the tank is full - not empty.\r\n";
                    //}
                    if (int.TryParse(drT["InchesPart"].ToString(), out result) && drT["InchesPart"].ToString().Length > 0)
                    {
                       

                    }
                    else
                    {
                        savingStatus = false;
                        errorText = errorText + "Tank: " + tankNumber + "'s InchesPart is not a number.\r\n";
                    }
                    //if (int.TryParse(drT["Temperature"].ToString(), out result) && drT["Temperature"].ToString().Length > 0)
                    //{
                    //    int.TryParse(drT["Temperature"].ToString(), out result);
                    // //   if (result.Equals(0))
                    //  //  {
                    //   //     savingStatus = false;
                    //    //    errorText = errorText + "Tank: " + tankNumber + "'s Temperature cannot be 0.\r\n";
                    //   // }
                    //}
                    //else
                    //{
                    //    savingStatus = false;
                    //    errorText = errorText + "Tank: " + tankNumber + "'s Temperature is not a number.\r\n";
                    //}



                }

              

                }
                countr++;
              
              
            }
            countr = 0;
            savingStatus = true;
            if (savingStatus)
            {   datetimeTaken = DateTime.Now;
            CurrentDateTimeUsed = datetimeTaken;
                foreach (DataRowView dr in dt.DefaultView)
                {

                    if (countr > 0)
                    {
                        int result;
                        tankNumber = dr["Tank #"].ToString();
                        if (int.TryParse(tankNumber, out result))
                        {
                             

                          
                                try { feet = int.Parse(dr["Feet"].ToString()); }
                                catch (Exception dte) { feet = 0; }
                                try { inches = int.Parse(dr["Inches"].ToString()); }
                                catch (Exception dte) { inches = 0; }
                                try { inchesPart = int.Parse(dr["InchesPart"].ToString()); }
                                catch (Exception dte) { inchesPart = 0; }
                                try { temperature = int.Parse(dr["Temperature"].ToString()); }
                                catch (Exception dte) { temperature = 0; }
                                try { Inspection = dr["Inspection"].ToString(); }
                                catch (Exception dte) { Inspection = "Y"; }
                                try { ProdCode = dr["Product Code"].ToString(); }
                                catch (Exception dte) { ProdCode = "Y"; }
                                try { ProdCodeDescription = dr["Product Description"].ToString();

                                ProdCodeDescription = ProdCodeDescription.Replace("'", "");
                                }
                                catch (Exception dte) { ProdCodeDescription = ""; }
                                try { InOutage = dr["InOutage"].ToString(); }
                                catch (Exception dte) { InOutage = ""; }

                             

                                if (InOutage.Equals("E"))
                                {
                                    feet = 0;
                                    inches = 0;
                                    inchesPart = 0;
                                    temperature = 0;

                                }
                        //feet = int.Parse(dr["Feet"].ToString());
                        //inches = int.Parse(dr["Inches"].ToString());
                        //inchesPart = int.Parse(dr["InchesPart"].ToString());
                        //temperature = int.Parse(dr["Temperature"].ToString());
                        //Inspection = dr["Inspection"].ToString();
                        //ProdCode = dr["Product Code"].ToString();
                        //ProdCodeDescription = dr["Product Description"].ToString();
                        //ProdCodeDescription = ProdCodeDescription.Replace("'", "");
                        //InOutage = dr["InOutage"].ToString();
                    InsertOneRecord(tankNumber, datetimeTaken, feet, inches, inchesPart, temperature, Inspection, ProdCode, ProdCodeDescription, InOutage);


                        



                        }
                       
                    }
                    countr++;



                }
                NumberOfTanksSaved = countr - 1 ;
                lblTankSaved.Text = "Saved: " + NumberOfTanksSaved.ToString();
                if (NumberOfTanksSaved < NumberOfTanksOnScreen)
                {
                    MessageBox.Show("Your data is saved to the database, but not all entries were saved. Click on 'View Tank Gauge Reports' to see what is mising.");
                }
                else
                {
                    MessageBox.Show("Your data is saved to the database, click on the 'View Tank Gauge Reports' to view the current gauges.");
                }
               
               
            }
            else
            {

                MessageBox.Show("Problem with your data -" + errorText);


            }



           
        return true;

        }
        public DataTable GetContentAsDataTable(bool IgnoreHideColumns = false)
        {  DataTable dtSource = new DataTable();
           
                if (tankGaugingDataDataGridView.ColumnCount == 0) return null;
              
                foreach (DataGridViewColumn col in tankGaugingDataDataGridView.Columns)
                {
                    if (IgnoreHideColumns & !col.Visible) continue;
                    if (col.Name == string.Empty) continue;
                    dtSource.Columns.Add(col.Name, col.ValueType);
                    dtSource.Columns[col.Name].Caption = col.HeaderText;
                }
                if (dtSource.Columns.Count == 0) return null;

              
                 DataRow drNewRowStart = dtSource.NewRow();
                 drNewRowStart[0] = "Tank #";
                 drNewRowStart[1] = "Product Code";
                 drNewRowStart[2] = "Product Description";
                 drNewRowStart[3] = "Date Time";
                 drNewRowStart[4] = "Feet";
                 drNewRowStart[5] = "Inches";
                 drNewRowStart[6] = "InchPart";
                 drNewRowStart[7] = "Temperature";
                 drNewRowStart[8] = "Inspection";
                 drNewRowStart[9] = "InOutage";
                 dtSource.Rows.Add(drNewRowStart);

                 int numOfRows = tankGaugingDataDataGridView.Rows.Count;
                 int count = 0;
                foreach (DataGridViewRow row in tankGaugingDataDataGridView.Rows)
                {
                    count++;
                    if (count < numOfRows)
                    {
                        DataRow drNewRow = dtSource.NewRow();
                        foreach (DataColumn col in dtSource.Columns)
                        {
                            
                                drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
                            
                            }
                        if (drNewRow[4].ToString().ToUpper().Equals(""))
                        {
                            drNewRow[4] = "";
                        }
                        if (drNewRow[5].ToString().ToUpper().Equals(""))
                        {
                            drNewRow[5] = "";
                        }
                        if (drNewRow[7].ToString().ToUpper().Equals(""))
                        {
                            drNewRow[7] = "";
                        }
                        //if (drNewRow[9].ToString().ToUpper().Equals("E"))
                        //{
                        //    drNewRow[4] = "0";
                        //    drNewRow[5] = "0";
                        //    drNewRow[6] = "0";
                        //    drNewRow[7] = "0";
                        //    drNewRow[8] = "Y";
                        //}
                       // drNewRow[3] = System.DateTime.Now;

                        dtSource.Rows.Add(drNewRow);
                    }
                }
               
            
          
            return dtSource;
        }

        public void clearGrid()
        {
            tankGaugingDataDataGridView.DataSource = null;
            tankGaugingDataDataGridView.Columns.Remove("inchesPart");

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (lblUnit.Text.Length < 1)
            {
                lblUnit.Text = "Custom";
            }
            tankGaugingDataDataGridView.EndEdit();
            NumberOfTanksSaved = 0;
            NumberOfTanksOnScreen = tankGaugingDataDataGridView.Rows.Count-1;
            saveToDatabase();
            CheckForGoodSave(UnitSelected, CurrentDateTimeUsed);
            clearGrid();
          
        }
        public static bool InsertOneRecord(String tankNumber, DateTime dateTimeTaken, int feet, int inches, int inchesPart, int temperature, string Inspection, string ProdCode, string ProductCodeDescription, string InOutage)
        {
            DateTime today = DateTime.Today;
            String todaysDate = today.ToString("dd-MM-yyyy");
            bool returnStatus = true;
            //   AppendToStatusFile("InsertOneRecord called:" + tankNumber + "," + dateTimeTaken.ToString() + "," + feet.ToString() + "," + inches.ToString() + "," + inchesPart.ToString() + "," + temperature.ToString() + "," + Inspection.ToString() + "," + ProdCode.ToString() + "," + ProductCodeDescription.ToString() + "," + InOutage.ToString());
            SqlConnection conn =
            new SqlConnection(ConnectionString);

            conn.Open();
            ProductCodeDescription = ProductCodeDescription.Replace("#", "").Replace("'", "");
            //get bokey
            String commandToDo = "";
            commandToDo = "INSERT INTO [ARGReports].[dbo].[TankGaugingData] ([TankNumber],[DateTimeTaken],[Feet],[Inches],[InchesPart],[Temperature],[Inspection],[ProdCode],[ProdDescription],[InOutage])";
            commandToDo = commandToDo + " VALUES ";
            commandToDo = commandToDo + " ('" + tankNumber + "','" + dateTimeTaken.ToString() + "'," + feet.ToString() + "," + inches.ToString() + "," + inchesPart.ToString() + "," + temperature.ToString() + ",'" + Inspection.ToString() + "','" + ProdCode.ToString() + "','" + ProductCodeDescription.ToString().Trim() + "','" + InOutage.ToString() + "') ";
            //   AppendToStatusFile("SQL command: " + commandToDo);
            SqlCommand commandKey = conn.CreateCommand();
            commandKey.CommandText = commandToDo;

            commandKey.CommandType = CommandType.Text;

           
                commandKey.ExecuteNonQuery();
            
            conn.Close();
            conn.Dispose();

            return returnStatus;
        }   

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void tankGaugingDataDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        delegate void SetColumnIndex(int i);


        private void tankGaugingDataDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string headerText = tankGaugingDataDataGridView.Columns[e.ColumnIndex].HeaderText;
           
            if (!headerText.Equals("Temperature")) return;
            if (ErrorInd == 1)
            {
                int nextindex = Math.Min(tankGaugingDataDataGridView.Columns.Count - 1, tankGaugingDataDataGridView.CurrentCell.ColumnIndex + 1);
                nextindex = nextindex - 1;
                SetColumnIndex method = new SetColumnIndex(Mymethod);

                tankGaugingDataDataGridView.BeginInvoke(method, nextindex);
                ErrorInd = 0;
            }
        }

        private void Mymethod(int columnIndex)
        {
            //LMS - 9/26/13 - had to use this weird delegate code to trick the app to put the cursor back in the temperature cell when the warning is displayed.  You cannot set currentcell in CellEndEdit or CellValueChanged.
            tankGaugingDataDataGridView.CurrentCell = tankGaugingDataDataGridView.CurrentRow.Cells[columnIndex];
            tankGaugingDataDataGridView.BeginEdit(true);

        }

        public void getCellValueByText(string columnName)
        {

        }

        private void tankGaugingDataDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)  
        {
            
            try
            {
  string headerText = tankGaugingDataDataGridView.Columns[e.ColumnIndex].HeaderText;

  if (!headerText.Equals("Temperature") && !headerText.Equals("Feet") && !headerText.Equals("InOutage") && !headerText.Equals("Inches") && !headerText.Equals("InchesPart")) return;

            //if (headerText.Equals("InOutage"))
            //{

            //    string inOutageEntered = tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["InOutage"].Value.ToString();

            //    if (!(inOutageEntered == "I" || inOutageEntered == "O" || inOutageEntered == "E"))
            //    {

            //        tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["InOutage"].Style.BackColor = Color.Red;
            //        ErrorInd = 1;
            //        tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["InOutage"].ErrorText = "InOutage has to be 'I' or 'O','E'.";
            //        tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["InOutage"].Value = "";
            //    }
            //    else
            //    {
            //        tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["InOutage"].Style.BackColor = Color.White;
            //        tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["InOutage"].ErrorText = "";
            //    }
                
            //}



            if (headerText.Equals("Temperature"))
            {
  string prodCode = tankGaugingDataDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            string TemperatureEntered = tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Temperature"].Value.ToString();

            if (TemperatureEntered != "")
            {
                Int16 result;
                if (!Int16.TryParse(TemperatureEntered, out result))
                {
                    tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Temperature"].Style.BackColor = Color.Red;
                    ErrorInd = 1;
                    tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Temperature"].ErrorText = "Temperature has to be a number!";
                 //   tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Temperature"].Value = "";
                } else  if (checkisTempOutOfRange(prodCode, Int32.Parse(TemperatureEntered)))
                {
                    tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Temperature"].Style.BackColor = Color.Red;
                    ErrorInd = 1;
                    tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Temperature"].ErrorText = "Temperature Warning!";

                }
                else
                {
                    tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Temperature"].Style.BackColor = Color.White;
                    tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Temperature"].ErrorText = "";
                }
            }
            else
            {
                tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Temperature"].ErrorText = "";
            }
            }
            if (headerText.Equals("Feet"))
            {

                string Feet = tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Feet"].Value.ToString();
                Int16 result;
                if (Feet != "")
                {
                    if (!Int16.TryParse(Feet, out result))
                    {
                        tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Feet"].Style.BackColor = Color.Red;
                        ErrorInd = 1;
                        tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Feet"].ErrorText = "Feet has to be a number!";
                      //  tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Feet"].Value = "";
                    }
                    else
                    {
                        Int16.TryParse(Feet, out result);

                        if (result > 100)
                        {
                            tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Feet"].Style.BackColor = Color.Red;
                            ErrorInd = 1;
                            tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Feet"].ErrorText = "Feet has to be less than 100ft!";
                           // tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Feet"].Value = "";
                        }
                        else
                        {
                        tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Feet"].Style.BackColor = Color.White;
                     //   tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Feet"].ErrorText = "";
                        }
                        
                    }
                }
                else
                {
                    tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Feet"].ErrorText = "";
                }
            }
          
            if (headerText.Equals("Inches"))
            {

                string Inches = tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Inches"].Value.ToString();
                Int16 result;
                string Feet = tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Feet"].Value.ToString();
                Int16 Feetresult;
                Int16.TryParse(Feet, out Feetresult);
                if (Inches != "")
                {
                    if (!Int16.TryParse(Inches, out result))
                    {
                        tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Inches"].Style.BackColor = Color.Red;
                        ErrorInd = 1;
                        tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Inches"].ErrorText = "Inches has to be a number!";
                        tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Inches"].Value = "";
                    }
                    else if (Int16.Parse(Inches) > 11 || Int16.Parse(Inches) < 0)
                    {
                        tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Inches"].Style.BackColor = Color.Red;
                        ErrorInd = 1;
                        tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Inches"].ErrorText = "Inches has to be less than 12!";
                        tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Inches"].Value = "";
                    }
                    else if (Int16.Parse(Inches) > 0 && Int16.Parse(Inches) < 3) 
                    {
                        if ((Feetresult < 1))
                        {
                        MessageBox.Show("You have entered less than 2.5 inches - if the tank is empty, it should be changed to 0.");
                        }
                       
                    }
                    else
                    {
                        tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Inches"].Style.BackColor = Color.White;
                        tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Inches"].ErrorText = "";
                    }
                }
                else
                {
                    tankGaugingDataDataGridView.Rows[e.RowIndex].Cells["Inches"].ErrorText = "";
                }
            }
            //if (headerText.Equals("InchesPart"))
            //{

            //    string Feet = tankGaugingDataDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
            //    Int16 result;
            //    if (Feet != "")
            //    {
            //        if (!Int16.TryParse(Feet, out result))
            //        {
            //            tankGaugingDataDataGridView.Rows[e.RowIndex].Cells[6].Style.BackColor = Color.Red;
            //            ErrorInd = 1;
            //            tankGaugingDataDataGridView.Rows[e.RowIndex].Cells[6].ErrorText = "InchesPart has to be a number!";
            //            tankGaugingDataDataGridView.Rows[e.RowIndex].Cells[6].Value = "";
            //        }
            //        else
            //        {
            //            tankGaugingDataDataGridView.Rows[e.RowIndex].Cells[6].Style.BackColor = Color.White;
            //            tankGaugingDataDataGridView.Rows[e.RowIndex].Cells[6].ErrorText = "";
            //        }
            //    }
            //    else
            //    {
            //        tankGaugingDataDataGridView.Rows[e.RowIndex].Cells[6].ErrorText = "";
            //    }
            //}
            }
            catch (Exception eexx)
            {

            }
          
        }


        public bool checkisTempOutOfRange(string prodCode, int temperature)
        {
            bool isOutOfRange = false;

            //        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ARGReports;Persist Security Info=True;Trusted_Connection=true");
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ARGReports;Persist Security Info=True;Trusted_Connection=true");
            conn.Open();

            SqlCommand commandKey = conn.CreateCommand();
           
            string commdnToDo = "SELECT [ProdCode],[LowTemp],[HighTemp] FROM [ARGReports].[dbo].[ProductTempRanges] where prodCode = '" + prodCode + "'";

            commandKey.CommandText = commdnToDo;
            commandKey.CommandType = CommandType.Text;

            SqlDataReader results = commandKey.ExecuteReader(CommandBehavior.CloseConnection);

            int lowtemp = 0;
            int highTemp = 0;
            if (results.Read())
            {
                 lowtemp = int.Parse(results["LowTemp"].ToString());
                 highTemp = int.Parse(results["HighTemp"].ToString());

            }
            else
            {
                lowtemp = 1;
                highTemp = 350;
            }
            String messageforRange = prodCode + " should be between " + lowtemp + " and " + highTemp;
            if (temperature < lowtemp)
            {
                //MessageBox.Show("Temperature is too low for " + prodCode + "!");
                MessageBox.Show(messageforRange);
                isOutOfRange = true;
                string log = "Temperature " + temperature + " is too low for " + prodCode;
                StoreStatus("TankGaugingImport_TemperatureCheck", log);

            }
            if (temperature > highTemp)
            {
               // MessageBox.Show("Temperature is too high for " + prodCode + "!");
                MessageBox.Show(messageforRange);
                isOutOfRange = true;
                string log = "Temperature " + temperature + " is too high for " + prodCode;
                StoreStatus("TankGaugingImport_TemperatureCheck", log);
            }

            if (isOutOfRange)
            {
                return true;
            }
            else
            {
                return false;
            }
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

        private void Form1_Load(object sender, EventArgs e)
        {
            StoreStatus("AppInfo", "Starting DataEntry, AD Name:" + Environment.UserName + ", Machine Name:" + Environment.MachineName);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://argreports.intranet.amref.com/Tank_Gauging_Live_Data.aspx");
            //test
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://intranet.amref.com/Documents/Tank%20Gauging%20Changes%205092016.pdf");
            //TFS update test

        }
    }
}
