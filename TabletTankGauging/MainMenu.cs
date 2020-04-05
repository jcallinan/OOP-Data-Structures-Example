using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabletTankGauging
{
    public partial class MainMenu : Form
    {
        public enum ORIENTATION_PREFERENCE
        {

            ORIENTATION_PREFERENCE_NONE = 0x0,

            ORIENTATION_PREFERENCE_LANDSCAPE = 0x1,

            ORIENTATION_PREFERENCE_PORTRAIT = 0x2,

            ORIENTATION_PREFERENCE_LANDSCAPE_FLIPPED = 0x4,

            ORIENTATION_PREFERENCE_PORTRAIT_FLIPPED = 0x8
        };

        [DllImport("User32.dll")]
        public static extern bool SetDisplayAutoRotationPreferences(ORIENTATION_PREFERENCE pref);





        public MainMenu()
        {

            bool retval = SetDisplayAutoRotationPreferences(ORIENTATION_PREFERENCE.ORIENTATION_PREFERENCE_LANDSCAPE);
            InitializeComponent();
         
        }

        private void btnNewReport_Click(object sender, EventArgs e)
        {   if (Util.CheckForCrude())
            {

                 Form1 f1 = new Form1("Crude Unit",0);
            }
        else
        {
             PickUnit pu = new PickUnit();
            pu.Show();

        }
           

          
        }

        private void btnOldReport_Click(object sender, EventArgs e)
        {
            frmOldGauges oldG = new frmOldGauges();
            oldG.Show();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

            SyncItAll();



        }
        public void SyncItAll()
        {
            try
            {
                Util.UpdateTodaysTankInfoOnDisk();
                Util.UpdateProductTempRangesInfoOnDisk();

            }
            catch (Exception ex) { }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://intranet.amref.com/Documents/Tablet_AutoSave_Tank_Gaug_Checks.pdf");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Task.Run(() => SyncItAll());
            timer1.Enabled = false;
        }
    }
}
