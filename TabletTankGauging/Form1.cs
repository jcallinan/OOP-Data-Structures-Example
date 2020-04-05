using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using System.Collections;

namespace TabletTankGauging
{

    public partial class Form1 : Form
    {


        bool SpeechIsOn;
        static SpeechRecognitionEngine _recognizer = null;
        static ManualResetEvent manualResetEvent = null;
       public  int CurrentTankIndex;
        string selectedUnitName;
        public DataTable autoSaveTable;
         
        int TotalNumberOfTanks;
        public Form1(string unitN, int currentItem)
        {
            //if (Application.OpenForms.OfType<PickUnit>().Count() == 1)
            //{ Application.OpenForms.OfType<PickUnit>().First().Dispose(); }
            autoSaveTable = new DataTable();

            autoSaveTable.Columns.Add("Tanks", typeof(string));
            autoSaveTable.Columns.Add("Products", typeof(string));
            autoSaveTable.Columns.Add("Feet", typeof(string));
            autoSaveTable.Columns.Add("Inches", typeof(string));
            autoSaveTable.Columns.Add("InageOutage", typeof(string));
 

            autoSaveTable.Columns.Add("InchesPart", typeof(string));
            autoSaveTable.Columns.Add("Temperature", typeof(string));
            autoSaveTable.Columns.Add("Descriptions", typeof(string));

            autoSaveTable.Columns.Add("TankStatus", typeof(string));
            autoSaveTable.Columns.Add("DateTimeDone", typeof(string));

            autoSaveTable.Columns.Add("EmergContainmentValve", typeof(bool));
            autoSaveTable.Columns.Add("HazardConditions", typeof(bool));
            autoSaveTable.Columns.Add("WaterCheck", typeof(bool));
            autoSaveTable.Columns.Add("ActionRequired", typeof(bool));

            CurrentTankIndex = currentItem;
        
            TotalNumberOfTanks = 0;
            selectedUnitName = unitN;
            InitializeComponent();
           
            try { Util.UpdateTankInfoOnDisk(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try { Util.UpdateTodaysTankInfoOnDisk(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



            linkLabel1.Visible = false;
            if (Util.currentTankIndex < 1 )
            {
                LoadUnitTanks(unitN.Trim());
            } else
            {
                TotalNumberOfTanks = Util.currentReport.TankCount;
                lblCurrentTankNumber.Text = "Tank " + (CurrentTankIndex+1 ).ToString() + " of " + Util.currentReport.TankCount.ToString();
            }
           
 
            if (TotalNumberOfTanks > 0)
            {
                SetTankInfo();
                lblCurrentTankNumber.Text = "Tank " + (CurrentTankIndex+1 ).ToString() + " of " + Util.currentReport.TankCount.ToString();
                this.Show();
            }
            else {

                this.Close();
                MessageBox.Show("No tanks found for that unit, please select another.");
               }
            //  RecognizeSpeechAndUpdateField();
       
  
        }


        public bool CheckTemp(string sentProdCode, int sentTemp)
        {
            bool statusT = true;
            DataTable prodTemps = Util.GetProductTempRangesDataTable();
            int count = 0;
            while (count < prodTemps.Rows.Count)
            {
                DataRow thisRow = prodTemps.Rows[count];
                string prodCode;
                int lowtemp;
                int hightemp;

                prodCode = thisRow[0].ToString();
                lowtemp = int.Parse(thisRow[1].ToString());
                hightemp = int.Parse(thisRow[2].ToString());
                if (sentProdCode == prodCode)
                {
                    if (sentTemp < lowtemp | sentTemp > hightemp)
                    {
                        MessageBox.Show("WARNING! WARNING! WARNING! WARNING! WARNING! WARNING!    This temperature is OUT OF SPEC,                                                                  Temp. should be between " + lowtemp.ToString() + " and " + hightemp.ToString());
                        statusT = true;
                    }

                }

                count++;
            }
            return statusT;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnNext.Visible = false;
            string errorMessage = "Select feet, inches, 1/4 inch, and temp, and all checkboxes before clicking 'Next'";
            bool error = false;
            string emptyErrorMessage = "If the tank is reading all 0s, please set the status to 'Empty' to continue";

            string currentProductCode = "";
            int selectedTemp = 0;
            int selectedHeight = 0;
            int selectedInches = 0;
            int selectedFeet = 0;

            try
            {
                selectedInches = int.Parse(cbInches.Text + cbInches2.Text);


                selectedFeet = int.Parse(cbFeet.Text + cbFeet2.Text);
                selectedHeight = (selectedInches) + (selectedFeet * 12);
            } catch (Exception ex)
            {
                selectedHeight = 0;
            }

            if (selectedHeight < 1)
            {

            }
            try
            {
                selectedTemp = int.Parse(cbTemperature.Text + cbTemperature2.Text + cbTemperature3.Text);

            }
            catch (Exception ex)
            {

            }
            try
            {
                currentProductCode = lblCurrentProduct.Text.Substring(0, 4);

            }
            catch (Exception ex)
            {

            }

 

            bool checkIt = CheckTemp(currentProductCode, selectedTemp);
            
            if (checkIt)
            {
                     if (!Util.AlreadyHaveTank(lblCurrentTank.Text) && (!chkEmergContainmentValve.Checked || !chkHazardConditions.Checked || !chkWaterCheck.Checked))
            {
                error = true;
            } else
            {
                if (CurrentTankIndex < Util.currentReport.TankCount)
                {
                        //check for temp and not null record
                        // if (cbTemperature.SelectedIndex > -1 && (   (selectedHeight < 1 && cbStatus.SelectedItem.ToString().Equals("Empty")) || (selectedHeight > 1 && !cbStatus.SelectedItem.ToString().Equals("Empty") )))
                        if (cbTemperature.SelectedIndex > -1)
                        {

                        int inches = 0; int feet = 0; int temperature = 0;
                        bool HazardConditions = false, WaterCheck = false, EmergContainmentValve = false, ActionRequired = false;
                        try
                        {
                            inches = int.Parse(cbInches.Text + cbInches2.Text);

                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {
                            feet = int.Parse(cbFeet.Text + cbFeet2.Text);

                        }
                        catch (Exception ex)
                        {

                        }
                        try
                        {
                            temperature = int.Parse(cbTemperature.Text + cbTemperature2.Text + cbTemperature3.Text);

                        }
                        catch (Exception ex)
                        {

                        }
                        Util.currentReport.Inches[CurrentTankIndex] = inches.ToString();
                        Util.currentReport.Feet[CurrentTankIndex] = feet.ToString();

                        string inchesPart = "0";

                        if (cbInchPart.Text == "1/4")
                        {
                            inchesPart = "25";
                        }
                        if (cbInchPart.Text == "1/2")
                        {
                            inchesPart = "50";
                        }
                        if (cbInchPart.Text == "3/4")
                        {
                            inchesPart = "75";
                        }

                        if (chkEmergContainmentValve.Checked)
                        {
                            EmergContainmentValve = true;
                        }


                        if (chkHazardConditions.Checked)
                        {
                            HazardConditions = true;
                        }


                        if (chkWaterCheck.Checked)
                        {
                            WaterCheck = true;
                        }
                        if (chkActionRequired.Checked)
                        {
                            ActionRequired = true;
                        }
                        Util.currentReport.EmergContainmentValve[CurrentTankIndex] = EmergContainmentValve;
                        Util.currentReport.HazardConditions[CurrentTankIndex] = HazardConditions;
                        Util.currentReport.WaterCheck[CurrentTankIndex] = WaterCheck;
                        Util.currentReport.ActionRequired[CurrentTankIndex] = ActionRequired;
                        Util.currentReport.InchesPart[CurrentTankIndex] = inchesPart;
                        Util.currentReport.Temperature[CurrentTankIndex] = temperature.ToString();
                        Util.currentReport.Descriptions[CurrentTankIndex] = lblCurrentProduct.Text;
                        Util.currentReport.TankStatus[CurrentTankIndex] = cbStatus.Text;
                        Util.currentReport.DateTimeDone[CurrentTankIndex] = DateTime.Now.ToString();

                        CurrentTankIndex++;
                        lblCurrentTankNumber.Text = "Tank " + (CurrentTankIndex + 1).ToString() + " of " + Util.currentReport.TankCount.ToString();
                        if (CurrentTankIndex < Util.currentReport.TankCount)
                        {
                            SetTankInfo();
                                AutoSave(Util.currentReport);
                        }
                        if (CurrentTankIndex >= Util.currentReport.TankCount)
                        {
                            ReviewAndReadyToSave();

                        }
                        pnlWiper.Width = 1;

                        while (pnlWiper.Width < 1300)
                        {
                            pnlWiper.Width = pnlWiper.Width + 2;
                        }
                        pnlWiper.Width = 1;
                    }
                    else
                    {
                        error = true;
                          
                    }


                }
                else
                {
                    //save report
                    ReviewAndReadyToSave();
                    // cbStatus.SelectedIndex = 3;
                }
                linkLabel1.Visible = true;
            }
            }
            //check for 72 hr
          
            
            if (error)
            {
                if (selectedHeight < 1 && cbStatus.SelectedItem.ToString() != "Empty")
                {
                    MessageBox.Show(emptyErrorMessage);
                }
                MessageBox.Show(errorMessage);
            }
            
         btnNext.Visible = true;
         cbStatus.SelectedIndex = 3;

        }
        public void ReviewAndReadyToSave()
        {
            frmReviewAndSave frmReview = new frmReviewAndSave(Util.currentReport);

            frmReview.ShowDialog();
            this.Close();
        }
       
         void RecognizeSpeechAndUpdateField()
        {
            SpeechIsOn = true;
            _recognizer = new SpeechRecognitionEngine();
            GrammarBuilder numbers = new GrammarBuilder();

            var c = new Choices();
            for (var i = 0; i <= 100; i++)
                c.Add(i.ToString());
            var gb = new GrammarBuilder(c);
            var g = new Grammar(gb);
            _recognizer.LoadGrammar(g);
          
            _recognizer.SpeechRecognized += _RecognizeSpeechAndUpdateField_SpeechRecognized; // if speech is recognized, call the specified method
            _recognizer.SpeechRecognitionRejected += _recognizeSpeechAndWriteToConsole_SpeechRecognitionRejected; // if recognized speech is rejected, call the specified method
            _recognizer.SetInputToDefaultAudioDevice(); // set the input to the default audio device
            _recognizer.RecognizeAsync(RecognizeMode.Multiple); // recognize speech asynchronous

        }
         void _RecognizeSpeechAndUpdateField_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            lblSpeechResults.Text = "Match:" + e.Result.Text;
            ComboBox cbControl = null;

            try
            {
                cbControl = (ComboBox) GetFocusedControl();
                if (cbControl.FindStringExact(e.Result.Text) > -1)
                {
                    cbControl.SelectedIndex = cbControl.FindStringExact(e.Result.Text);
                }
            }
            catch (Exception ex)
            {
                lblSpeechResults.Text = lblSpeechResults.Text + "Error! - " + ex.ToString();
            }
             
        }
         private Control GetFocusedControl()
         {
             Control focusedControl = null;
             focusedControl = this.ActiveControl;
             return focusedControl;
         }
         void _recognizeSpeechAndWriteToConsole_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            lblSpeechResults.Text = "Could not parse, possible matches (if any): ";
            foreach (RecognizedPhrase r in e.Result.Alternates)
            {
                lblSpeechResults.Text = lblSpeechResults.Text + r.Text;
            }
        }
        public void SetTankInfo()
        {
            

            lblCurrentProduct.Text = Util.currentReport.Products[CurrentTankIndex].ToString() + " " +  Util.currentReport.Descriptions[CurrentTankIndex].ToString();
            lblCurrentTank.Text = Util.currentReport.Tanks[CurrentTankIndex].ToString();
            cbFeet.SelectedIndex = 0;
            cbFeet2.SelectedIndex = 0;

            cbInches.SelectedIndex = 0;
            cbInches2.SelectedIndex = 0;
            cbInchPart.SelectedIndex = 0;
            cbTemperature.SelectedIndex = 0;
            cbTemperature2.SelectedIndex = 0;
            cbTemperature3.SelectedIndex = 0;
            cbStatus.SelectedIndex = 3;
            chkWaterCheck.Checked = false;
            chkHazardConditions.Checked = false;
            chkEmergContainmentValve.Checked = false;
            chkActionRequired.Checked = false;

        }
        public void AddTankToList(string TCTANK, string THPRCD, string TPDESC)
        {
            
            Util.currentReport.Tanks[Util.currentReport.TankCount] = TCTANK;
            Util.currentReport.Products[Util.currentReport.TankCount] = THPRCD;
            Util.currentReport.Descriptions[Util.currentReport.TankCount] = TPDESC;

            Util.currentReport.TankCount++;

            
        }
        public void LoadUnitTanks(string unitName)
        {

            DataTable tanks = Util.GetTankInfoDataTable();
            int count = 0;
            while (count < tanks.Rows.Count)
            {
                DataRow thisRow = tanks.Rows[count];
                string TCUNIT, TCTANK, THPRCD, TPDESC;
                TCUNIT = thisRow[0].ToString();
                TCTANK = thisRow[1].ToString();
                THPRCD = thisRow[2].ToString();
                TPDESC = thisRow[3].ToString();
                if (unitName.Equals("Foster Brook Bulk"))
                {
                    if (TCUNIT.Trim().ToUpper().Equals("FBBULK") || TCTANK.Trim().ToUpper().Equals("0619") || TCTANK.Trim().ToUpper().Equals("0620"))
                    {
                        AddTankToList(TCTANK, THPRCD, TPDESC);
                        TotalNumberOfTanks++;
                    }
                  
                }
                if (unitName.Equals("Barrel House"))
                {
                    if (TCUNIT.Trim().ToUpper().Equals("BRLHSE"))
                    {
                        AddTankToList(TCTANK, THPRCD, TPDESC);
                        TotalNumberOfTanks++;
                    }
                     
                } if (unitName.Equals("Crude Farm"))
                {
                    if (TCUNIT.Trim().ToUpper().Equals("CRDFRM") && !TCTANK.Trim().ToUpper().Equals("0619") && !TCTANK.Trim().ToUpper().Equals("0620"))
                    {
                        AddTankToList(TCTANK, THPRCD, TPDESC);
                        TotalNumberOfTanks++;
                    } 
                } if (unitName.Equals("Rose/Extract"))
                {
                    if (TCUNIT.Trim().ToUpper().Equals("EXTRAC") || TCUNIT.Trim().ToUpper().Equals("ROSE"))
                    {
                        AddTankToList(TCTANK, THPRCD, TPDESC);
                        TotalNumberOfTanks++;
                    }
                } if (unitName.Equals("Boiler House"))
                {
                    if (TCUNIT.Trim().ToUpper().Equals("BOILHS"))
                    {
                        AddTankToList(TCTANK, THPRCD, TPDESC);
                        TotalNumberOfTanks++;
                    } 
                } if (unitName.Equals("Crude Unit"))
                {
                    if (TCUNIT.Trim().ToUpper().Equals("CRDUNT") && !TCTANK.Trim().ToUpper().Equals("0158") && !TCTANK.Trim().ToUpper().Equals("0160"))
                    {
                        AddTankToList(TCTANK, THPRCD, TPDESC);
                        TotalNumberOfTanks++;
                    }  
                } if (unitName.Equals("4 Bay"))
                    // need to add tanks to 4 bay
                {
                    if (TCUNIT.Trim().ToUpper().Equals("4BAYLD") || TCTANK.Trim().ToUpper().Equals("0158") || TCTANK.Trim().ToUpper().Equals("0160"))
                    {
                        AddTankToList(TCTANK, THPRCD, TPDESC);
                        TotalNumberOfTanks++;
                    }   
                } if (unitName.Equals("Rose Unit"))
                {
                    if (TCUNIT.Trim().ToUpper().Equals("ROSE"))
                    {
                        AddTankToList(TCTANK, THPRCD, TPDESC);
                        TotalNumberOfTanks++;
                    }    
                } if (unitName.Equals("Platformer"))
                {
                    if (TCUNIT.Trim().ToUpper().Equals("PLATFO"))
                    {
                        AddTankToList(TCTANK, THPRCD, TPDESC);
                        TotalNumberOfTanks++;
                    }    
                } if (unitName.Equals("MEK"))
                {
                    if (TCUNIT.Trim().ToUpper().Equals("MEK"))
                    {
                        AddTankToList(TCTANK, THPRCD, TPDESC);
                        TotalNumberOfTanks++;
                    }     
                }
                if (unitName.Equals("Packaging Plant"))
                {
                    if (TCUNIT.Trim().ToUpper().Equals("PKGPLT"))
                    {
                        AddTankToList(TCTANK, THPRCD, TPDESC);
                        TotalNumberOfTanks++;
                    }   
                }
                if (unitName.Equals("Foster Brook Blend"))
                {
                    if (TCUNIT.Trim().ToUpper().Equals("FBBLND"))
                    {
                        AddTankToList(TCTANK, THPRCD, TPDESC);
                        TotalNumberOfTanks++;
                    }    
                }
                count++;
            }

        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool needInspection = false;
            ArrayList tanksNeeded = new ArrayList();

            for (int i = 0; i < Util.currentReport.TankCount; i++)
            {
                 
       
             if (!Util.AlreadyHaveTank(Util.currentReport.Tanks[i]) && (!Util.currentReport.EmergContainmentValve[i] || !Util.currentReport.HazardConditions[i] || !Util.currentReport.WaterCheck[i]))
            {
                    needInspection = true;
                    tanksNeeded.Add(Util.currentReport.Tanks[i]);
            }

            }

            if (!needInspection)
            {
                 ReviewAndReadyToSave();
            } else
            {
                String allTanks = "";
                foreach (String i in tanksNeeded)
                {
                    allTanks = allTanks + " " + i + ",";
                }

                MessageBox.Show("There are tanks in the list that need to be inspected that cannot be skipped - " + allTanks);
            }

             
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

         //   if (!Util.AlreadyHaveTank(lblCurrentTank.Text) && (!chkEmergContainmentValve.Checked || !chkHazardConditions.Checked || !chkWaterCheck.Checked))
          //  {
            CurrentTankIndex++;
            lblCurrentTankNumber.Text = "Tank " + (CurrentTankIndex + 1).ToString() + " of " + Util.currentReport.TankCount.ToString();
            if (CurrentTankIndex < Util.currentReport.TankCount)
            {
                SetTankInfo();
            }
            if (CurrentTankIndex >= Util.currentReport.TankCount)
            {
                ReviewAndReadyToSave();

            }
            pnlWiper.Width = 1;

            while (pnlWiper.Width < 1300)
            {
                pnlWiper.Width = pnlWiper.Width + 2;
            }
            pnlWiper.Width = 1;
      //      } else
      //      {
      //          MessageBox.Show("This tank cannot be skipped, it must have a tank gauging entry with a 72 hour inspection.");
      //      }

              
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentTankIndex > 0)
            {
             btnNext.Visible = false;
            linkLabel1.Visible = false;
         

           

                    CurrentTankIndex--;
                    lblCurrentTankNumber.Text = "Tank " + (CurrentTankIndex + 1).ToString() + " of " + Util.currentReport.TankCount.ToString();

                lblCurrentProduct.Text = Util.currentReport.Products[CurrentTankIndex].ToString() + " " + Util.currentReport.Descriptions[CurrentTankIndex].ToString();
                lblCurrentTank.Text = Util.currentReport.Tanks[CurrentTankIndex].ToString();
                //cbFeet.SelectedIndex = 0;
                //cbFeet2.SelectedIndex = 0;

                //cbInches.SelectedIndex = 0;
                //cbInches2.SelectedIndex = 0;
                //cbInchPart.SelectedIndex = 0;
                //cbTemperature.SelectedIndex = 0;
                //cbTemperature2.SelectedIndex = 0;
                //cbTemperature3.SelectedIndex = 0;
                //cbStatus.SelectedIndex = 3;
                //chkWaterCheck.Checked = false;
                //chkHazardConditions.Checked = false;
                //chkEmergContainmentValve.Checked = false;
                //chkActionRequired.Checked = false;




                linkLabel1.Visible = true;
            btnNext.Visible = true;
            }
          
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ActionRequired_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void AutoSave(TankGaugingReport newReport)
        {
            autoSaveTable.Rows.Clear();
            //  InitializeComponent();
            // lblDateTimeUser.Text = newReport.UserName + " - " + DateTime.Now;
            //  lblDateTimeUser2.Text = newReport.UserName + " - " + DateTime.Now;
            for (int i = 0; i < newReport.Tanks.Length; i++)
            {

                string Tanks, Products, Feet, Inches, InchesPart, Temperature, Descriptions, InageOutage, DateTimeDone, TankStatus;
                bool EmergContainmentValve, HazardConditions, WaterCheck, ActionRequired;

                Tanks = newReport.Tanks[i];
                Products = newReport.Products[i];
                Feet = newReport.Feet[i];
                Inches = newReport.Inches[i];
                if (newReport.InchesPart[i] != null)
                {
                InchesPart = newReport.InchesPart[i];
                } else
                {
                    InchesPart = "0";
                }
                
                Temperature = newReport.Temperature[i];
                Descriptions = newReport.Descriptions[i];
                InageOutage = newReport.InageOutage[i];
                DateTimeDone = newReport.DateTimeDone[i];
                TankStatus = newReport.TankStatus[i];
                EmergContainmentValve = newReport.EmergContainmentValve[i];
                HazardConditions = newReport.HazardConditions[i];
                WaterCheck = newReport.WaterCheck[i];
                ActionRequired = newReport.ActionRequired[i];

                autoSaveTable.Rows.Add(Tanks, Products, Feet, Inches, InageOutage, InchesPart, Temperature, Descriptions, TankStatus, DateTimeDone, EmergContainmentValve, HazardConditions, WaterCheck, ActionRequired);

            }

            GridViewExportUtil ge = new GridViewExportUtil();
            ge.ToCSV(autoSaveTable, newReport.Username + " - " + DateTime.Now, true);

        }


    }
}
