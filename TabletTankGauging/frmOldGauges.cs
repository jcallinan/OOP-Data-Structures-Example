using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabletTankGauging
{
    public partial class frmOldGauges : Form
    {
        public bool gridLoaded = false;
        public frmOldGauges()
        {

            InitializeComponent();
            string path = "C:\\Tablet_Tank_Gauging";


            if (!gridLoaded)
            {
                gridLoaded = true;
                if (File.Exists(path))
                {
                    // This path is a file
                    ProcessFile(path);
                }
                else if (Directory.Exists(path))
                {
                    // This path is a directory
                    ProcessDirectory(path);
                }
                else
                {

                }

            }
            
        }
     
        public void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        // Insert logic for processing found files here.
        public void ProcessFile(string path)
        {
            try
            {

                string[] newRow = new string[] { path, File.GetCreationTime(path).ToShortDateString() };
                dgOldReports.Rows.Add(newRow);
            }
            catch (Exception ex) { }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string path = "C:\\Tablet_Tank_Gauging";
            string[] fileEntries = Directory.GetFiles(path);
            string errorString = "";
            foreach (string fileName in fileEntries)
            {
                System.IO.FileInfo thisFile = new FileInfo(fileName);
                if (thisFile.Extension == ".tdt-processed")
                {
                    try
                    {
                        System.IO.File.Delete(fileName);
                    }
                    catch (Exception ex)
                    {
                        errorString = errorString + ex.ToString();
                    }


                }
            }
            dgOldReports.Visible = false;
            button1.Visible = false;
            btnSendToDatabase.Visible = false;
            lblResults.Text = "All processed files have been deleted. You can click 'Exit' below now." + errorString;
        }
        public void ProcessDirectoryForDatabase(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                try
                {
                    ProcessFileForDatabase(fileName);
                }
                catch (Exception ex)
                {
                    Util.SaveLogEntry("Error processing saved gauges - " + fileName + " Exception - "+  ex.ToString());

                }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectoryForDatabase(subdirectory);
        }

        // Insert logic for processing found files here.
        public void ProcessFileForDatabase(string path)
        {
            string extenstion = "tdt";
            if (path.EndsWith("tdt") && !path.EndsWith("TankInfo.tdt") && !path.EndsWith("ADUsers.tdt"))
            {
                int count = 0;

                using (var rd = new StreamReader(path))
                {
                 
                    DateTime dateTimeStored = File.GetCreationTime(path);

 

                    while (!rd.EndOfStream)
                    {

                        var rawLine = rd.ReadLine();

                        var splits = rawLine.Split('\t');

                        string Tank, product, ProductCodeDescription, TankStatus, dateTimeDone;
                        int feet, inches,inchesPart, quarterInch, temperature;
                        bool HazardConditions = false, WaterCheck = false, EmergContainmentValve = false, ActionRequired = false;
                        if (splits.Length > 1)
                        {

                            Tank = splits[0];
                            
                            product = splits[1];
                             ProductCodeDescription= splits[2];
                            try { feet = int.Parse(splits[3]); }
                            catch (Exception dte) { feet = 0; }
                            try { inches = int.Parse(splits[4]); }
                            catch (Exception dte) { inches = 0; }
                            try { inchesPart = int.Parse(splits[5]); }
                            catch (Exception dte) { inchesPart = 0; }
                            try { temperature = int.Parse(splits[6]); }
                            catch (Exception dte) { temperature = 0; }
                        



                            TankStatus = splits[7];
                            dateTimeDone = splits[8];
                            try
                            {
                                HazardConditions = bool.Parse(splits[9]);
                            }
                            catch (Exception ex) { }

                            try
                            {
                                 WaterCheck = bool.Parse(splits[10]);
                            }
                            catch (Exception ex) { }

                            try
                            {
                                 EmergContainmentValve = bool.Parse(splits[11]);
                            }
                            catch (Exception ex) { }

                            try
                            {
                                ActionRequired = bool.Parse(splits[12]);
                            }
                            catch (Exception ex) { }


                            if (!Tank.ToLower().Equals("tank") )
                            {

                                InsertOneRecord(Tank, dateTimeDone, feet, inches, inchesPart, temperature, "Y", product, ProductCodeDescription, TankStatus, HazardConditions, WaterCheck, EmergContainmentValve, ActionRequired);
                              
                                
                            }
                           

                          

                        }

                        count++;

                    }
                }
                System.IO.File.Copy(path, path + "-processed");
                System.IO.File.Delete(path);
            }


        }
        public static bool InsertOneRecord(String tankNumber, String dateTimeTaken, int feet, int inches, int inchesPart, int temperature, string Inspection, string ProdCode, string ProductCodeDescription, string TankStatus, bool HazardConditions, bool WaterCheck, bool EmergContainmentValve, bool ActionRequired)
        {
            DateTime today = DateTime.Today;
            String todaysDate = today.ToString("dd-MM-yyyy");
            bool returnStatus = true;
            //   AppendToStatusFile("InsertOneRecord called:" + tankNumber + "," + dateTimeTaken.ToString() + "," + feet.ToString() + "," + inches.ToString() + "," + inchesPart.ToString() + "," + temperature.ToString() + "," + Inspection.ToString() + "," + ProdCode.ToString() + "," + ProductCodeDescription.ToString() + "," + InOutage.ToString());
            SqlConnection conn =
            new SqlConnection("Data Source=localhost;Initial Catalog=ARGReports;Trusted_Connection=True;");

            conn.Open();
            ProductCodeDescription = ProductCodeDescription.Replace("#", "").Replace("'", "");
            //get bokey
            String commandToDo = "";
            commandToDo = "INSERT INTO [ARGReports].[dbo].[TankGaugingData] ([TankNumber],[DateTimeTaken],[Feet],[Inches],[InchesPart],[Temperature],[Inspection],[ProdCode],[ProdDescription],[TankStatus],[HazardConditions],[WaterCheck],[EmergContainmentValve],[ActionRequired])";
            commandToDo = commandToDo + " VALUES ";
            commandToDo = commandToDo + " ('" + tankNumber + "','" + dateTimeTaken.ToString() + "'," + feet.ToString() + "," + inches.ToString() + "," + inchesPart.ToString() + "," + temperature.ToString() + ",'" + Inspection.ToString() + "','" + ProdCode.ToString() + "','" + ProductCodeDescription.ToString().Trim() + "','" + TankStatus.ToString() + "','" + HazardConditions.ToString() + "','" + WaterCheck.ToString() + "','" + EmergContainmentValve.ToString() + "','" + ActionRequired.ToString() + "') ";
            //   AppendToStatusFile("SQL command: " + commandToDo);
            SqlCommand commandKey = conn.CreateCommand();
            commandKey.CommandText = commandToDo;

            commandKey.CommandType = CommandType.Text;


            commandKey.ExecuteNonQuery();

            conn.Close();
            conn.Dispose();

            return returnStatus;
        }   
         
        private void btnSendToDatabase_Click(object sender, EventArgs e)
        {
            //try
            //{
                string path = "C:\\Tablet_Tank_Gauging";

                if (File.Exists(path))
                {
                    // This path is a file
                    try
                {
                    ProcessFileForDatabase(path);
                }
                    catch (Exception ex)
                {
                    Util.SaveLogEntry("Error processing saved gauges - " + ex.ToString());

                }

                }
                else if (Directory.Exists(path))
                {
                    // This path is a directory
                    ProcessDirectoryForDatabase(path);
                }
                else
                {

                }
                dgOldReports.Visible = false;
                button1.Visible = false;
                lblResults.Visible = true;
                btnSendToDatabase.Visible = false;
                lblResults.Text = "Gauge data has been updated in the database - click on 'View Reports' to check the gauges in Report Builder.";
             
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Couldn't sync to databse , please make sure you're online and try again, error -" + ex.ToString());

            //}
          
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://argreports.intranet.amref.com/Tank_Gauging_Live_Data.aspx");
        }

        private void dgOldReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            String filePath = "";
            filePath = dgOldReports.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (filePath.EndsWith("tdt-autosave")) {
                try
                {
                    LoadFileInForm(filePath);
                }
                catch (Exception ex) {

                    MessageBox.Show("Error loading autosave file, try closing and reopening the app.");
                }


            }
            Cursor.Current = Cursors.Default;

        }

        public void LoadFileInForm(string path)
        {


            int count = 0;
            //string checklistID;
            //string checklistName;


            //Util.selectedChecklistID = checklistID;
            //Util.selectedChecklistName = checklistName;

            using (var rd = new StreamReader(path))
            {


                string userName = "";
                // userName = path.Replace("C:\\Tablet_Checklist_App\\","");
                // userName = userName.Substring(0,userName.IndexOf("-"));
                userName = Environment.UserName;
                DateTime dateTimeStored = File.GetCreationTime(path);
                string checklistID, checklistName;
                checklistID = path.Replace("C:\\Tablet_Tank_Gauging\\", "");
                checklistID = checklistID.Substring(0, checklistID.IndexOf("-"));
                int checklistInt;
                checklistInt = 17;
                int checklistNameStartPos, checklistNameEndPos;
                string tempPath = path.Replace("C:\\Tablet_Tank_Gauging\\", "");

                string deptOfFile = "";


                if (path.IndexOf("AM-") > 0) {
                  deptOfFile = path.Substring(path.IndexOf("AM-") + 3, path.IndexOf(".tdt-autosave") - (path.IndexOf("AM-") + 3));
              
                } else
                {
                    deptOfFile = path.Substring(path.IndexOf("PM-") + 3, path.IndexOf(".tdt-autosave") - (path.IndexOf("PM-") + 3));
                }

                if (deptOfFile.Equals("RoseExtract"))
                {
                    deptOfFile = "Rose/Extract";
                }
               Util.currentDepartment = deptOfFile;
                checklistNameStartPos = tempPath.IndexOf("-");
                checklistNameEndPos = tempPath.IndexOf("-", tempPath.IndexOf("-", 1));
                //    checklistName = tempPath.Substring(checklistNameStartPos + 1, tempPath.IndexOf("-", checklistNameEndPos + 1) - 2);
                //   checklistName = checklistName.Trim();
                //    checklistName = checklistName + " ";

         
                while (!rd.EndOfStream)
                {

                    var rawLine = rd.ReadLine();

                    var splits = rawLine.Split('\t');

                    string Tanks= "", Products = "", Feet = "", Inches = "", InageOutage = "", InchesPart = "", Temperature = "", Descriptions = "", TankStatus = "", DateTimeDone = "";
                    bool EmergContainmentValve = false, HazardConditions = false, WaterCheck = false, ActionRequired = false;
                    if (splits.Length > 1 && count <= Util.currentReport.Tanks.Length)
                    {
                        if (splits.Length > 21)
                        {
                         Tanks = splits[0];
                        Products = splits[2];
                        Feet = splits[4];
                        Inches = splits[6];
                        InchesPart = splits[8];
                        Temperature = splits[12];
                        Descriptions = splits[14];

                         if (Descriptions.Length < 1)
                            {
                                Descriptions = splits[8];
                            }
                            if (Descriptions.Length < 1)
                            {
                                Descriptions = splits[10];
                            }

                            InageOutage = splits[8];
                        DateTimeDone = splits[18];
                        TankStatus = splits[16];

                            bool use20 =false;
                            try
                            {
                           bool ex = bool.Parse(splits[19].Replace("\"",""));
                                EmergContainmentValve = ex;
                            }
                            catch (Exception ex) {
                                use20 = true;
                                bool ex2 = bool.Parse(splits[20].Replace("\"", ""));
                                EmergContainmentValve = ex2;
                            }
                            try
                            {
                                if (use20)
                                {
                                    bool ex = bool.Parse(splits[22].Replace("\"", ""));
                                    HazardConditions = ex;
                                }
                                else
                                {
                                    bool ex = bool.Parse(splits[21].Replace("\"", ""));
                                    HazardConditions = ex;
                                }
                            
                            }
                            catch (Exception ex)
                            {

                            }
                            try
                            {
                                if (use20)
                                {
                                    bool ex = bool.Parse(splits[24].Replace("\"", ""));
                                    WaterCheck = ex;
                                }
                                else
                                {
                                    bool ex = bool.Parse(splits[23].Replace("\"", ""));
                                    WaterCheck = ex;
                                }
                                   
                            }
                            catch (Exception ex)
                            {

                            }




                            try
                            {
                                if (use20)
                                {
                                    bool ex = bool.Parse(splits[26].Replace("\"", ""));
                                    ActionRequired = ex;
                                } else
                                {
                                bool ex = bool.Parse(splits[25].Replace("\"", ""));
                                ActionRequired = ex;
                                }

                               
                            }
                            catch (Exception ex)
                            {

                            }

                        }
                        else
                        {
                            Tanks = splits[0];
                            Products = splits[2];
                            Feet = splits[4];
                            Inches = "0";
                            InchesPart = "0";
                            Temperature = "0";
                            Descriptions = splits[9];
                            InageOutage = "";
                            DateTimeDone = "";
                            TankStatus = "";
                            EmergContainmentValve = false;
                            HazardConditions = false;
                            WaterCheck = false;

                            ActionRequired = false;
                        }
                 

                        if (Feet.Replace("\"", "").Length > 0 )
                        {
                            Util.currentTankIndex = count ;
                        }
                        if (InageOutage.Equals("False"))
                        {
                            InageOutage = "";
                        }
                        if (InageOutage.Equals("True"))
                        {
                            InageOutage = "";
                        }
                        if (Tanks.Replace("\"", "").Length > 0 && !Tanks.Equals("Tanks") && !Tanks.Replace("\"", "").Equals(""))
                        {
                            //addQuestionAndAnswer(reportID, QuestionText1, QuestionText2, YesOrNo, Comments, DateTimeTaken, Lat, Lon);
                            Util.currentReport.Tanks[count] = Tanks.Replace("\"","");
                            Util.currentReport.Products[count] = Products.Replace("\"", "");
                            Util.currentReport.Feet[count ] = Feet.Replace("\"", "");
                            Util.currentReport.Inches[count ] = Inches.Replace("\"", "");
                            Util.currentReport.InchesPart[count ] = InchesPart.Replace("\"", "");
                            Util.currentReport.Temperature[count ] = Temperature.Replace("\"", "");
                            Util.currentReport.Descriptions[count ] = Descriptions.Replace("\"", "");
                            Util.currentReport.InageOutage[count ] = InageOutage.Replace("\"", "");
                            Util.currentReport.DateTimeDone[count ] = DateTimeDone.Replace("\"", "");
                            Util.currentReport.TankStatus[count] = TankStatus.Replace("\"", "");
                            Util.currentReport.EmergContainmentValve[count ] = EmergContainmentValve;
                            Util.currentReport.HazardConditions[count ] = HazardConditions;
                            Util.currentReport.WaterCheck[count ] = WaterCheck;
                            Util.currentReport.ActionRequired[count] = ActionRequired;
                             count++;
                        }

                    }


                
                }
                Util.currentReport.TankCount = count-1;



                if (Util.currentTankIndex == Util.currentReport.TankCount)
                {
                     frmReviewAndSave frmReview = new frmReviewAndSave(Util.currentReport);
                    rd.Close();
                    frmReview.ShowDialog();
                    this.Close();
                } else
                {

                    Util.currentTankIndex++;
                    Form1 f1 = new Form1(deptOfFile, Util.currentTankIndex);
                        f1.CurrentTankIndex = Util.currentTankIndex;
                        f1.Show();
                  
                }
             
                

            }



        }

    }
}
