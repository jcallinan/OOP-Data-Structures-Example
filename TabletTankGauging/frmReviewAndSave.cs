using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabletTankGauging
{
    public partial class frmReviewAndSave : Form
    {
        TankGaugingReport thisInternalReport;
        public frmReviewAndSave(TankGaugingReport thisReport)
        {
            InitializeComponent();
            thisInternalReport = thisReport;
            FillView(thisReport);
            this.dgReview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgReview_MouseDown);
            this.DeleteRow.Click += new System.EventHandler(this.DeleteRow_Click);
        }
        private void dgReview_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    var hti = dgReview.HitTest(e.X, e.Y);
              
            //    try
            //    {
            //        dgReview.Rows[hti.RowIndex].Selected = true;
            //    }
            //    catch (Exception ex)
            //    {

            //    }
                
            //}
        }

        private void DeleteRow_Click(object sender, EventArgs e)
        {
            Int32 rowToDelete = dgReview.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            dgReview.Rows.RemoveAt(rowToDelete);
            dgReview.ClearSelection();
        }
        public void FillView(TankGaugingReport thisReport)
        {
            for (int i = 0; i < thisReport.TankCount; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dgReview.Rows[0].Clone();

                row.Cells[0].Value = thisReport.Tanks[i];
                row.Cells[1].Value = thisReport.Products[i];
                row.Cells[2].Value = thisReport.Descriptions[i];
                row.Cells[3].Value = thisReport.Feet[i];
                row.Cells[4].Value = thisReport.Inches[i];
                row.Cells[5].Value = thisReport.InchesPart[i];
                row.Cells[6].Value = thisReport.Temperature[i];
                row.Cells[7].Value = thisReport.TankStatus[i];
                row.Cells[8].Value = thisReport.DateTimeDone[i];
                row.Cells[9].Value = thisReport.HazardConditions[i];
                row.Cells[10].Value = thisReport.WaterCheck[i];
                row.Cells[11].Value = thisReport.EmergContainmentValve[i];
                row.Cells[12].Value = thisReport.ActionRequired[i];
                row.Cells[13].Value = thisReport.InspectionRecord[i];
                if (thisReport.Feet[i]== null && (thisReport.Inches[i] == null) &&( thisReport.InchesPart[i] == null) && (thisReport.Temperature[i] == null) )
                {

                } else
                {
                    dgReview.Rows.Add(row);
                }


               

            }

        }
        public void FillViewNoBlanks()
        {

            //for (int i = 0; i < thisReport.TankCount; i++)
            //{

            //    if (thisReport.Feet[i] != "" && thisReport.Inches[i] != "" & thisReport.InchesPart[i] != "" && thisReport.Temperature[i] != "" & thisReport.HazardConditions[i] != false && thisReport.EmergContainmentValve[i] != false && thisReport.WaterCheck[i] != false)
            //    {
            //    DataGridViewRow row = (DataGridViewRow)dgReview.Rows[0].Clone();

            //    row.Cells[0].Value = thisReport.Tanks[i];
            //    row.Cells[1].Value = thisReport.Products[i];
            //    row.Cells[2].Value = thisReport.Descriptions[i];
            //    row.Cells[3].Value = thisReport.Feet[i];
            //    row.Cells[4].Value = thisReport.Inches[i];
            //    row.Cells[5].Value = thisReport.InchesPart[i];
            //    row.Cells[6].Value = thisReport.Temperature[i];
            //    row.Cells[7].Value = thisReport.TankStatus[i];
            //    row.Cells[8].Value = thisReport.DateTimeDone[i];
            //    row.Cells[9].Value = thisReport.HazardConditions[i];
            //    row.Cells[10].Value = thisReport.WaterCheck[i];
            //    row.Cells[11].Value = thisReport.EmergContainmentValve[i];
            //    row.Cells[12].Value = thisReport.ActionRequired[i];
            //    dgReview.Rows.Add(row);
            //    }


            //}
            dgReview.ClearSelection();
            for (int i = 0; i < dgReview.Rows.Count-1; i ++)
            {
                DataGridViewRow row = (DataGridViewRow)dgReview.Rows[i];

                if ( (String) row.Cells[3].Value == null && (String)row.Cells[4].Value == null && (String)row.Cells[5].Value == null && (String)row.Cells[6].Value == null )
                {

                    Boolean thisHazardConditions=false;
                    Boolean thisWaterCheck = false;
                    Boolean thisEmergContainmentValve = false;

                    try
                    {
                        thisHazardConditions =Boolean.Parse( row.Cells[9].Value.ToString());
                    } catch (Exception Ex)
                    {
                        thisHazardConditions = false;
                    }
                    try
                    {
                        thisWaterCheck = Boolean.Parse(row.Cells[10].Value.ToString());
                    }
                    catch (Exception Ex)
                    {
                        thisWaterCheck = false;
                    }
                    try
                    {
                        thisEmergContainmentValve = Boolean.Parse(row.Cells[11].Value.ToString());
                    }
                    catch (Exception Ex)
                    {
                        thisEmergContainmentValve = false;
                    }

                    if (!thisHazardConditions && !thisWaterCheck && !thisEmergContainmentValve) {
                        dgReview.Rows.RemoveAt(i);
                      dgReview.ClearSelection();
                     }

               
                }
               

            }
        }

        private void btnSaveAndContinue_Click(object sender, EventArgs e)
        {
        
             GridViewExportUtil ge = new GridViewExportUtil();
            DateTime localDate = DateTime.Now;
            string userNameAndDate = Environment.UserName + localDate.ToString("MMddyyyyHHmmss");
            string userNameAndDateFixed = userNameAndDate.Replace("/", "");
            userNameAndDateFixed = userNameAndDateFixed.Replace(" ", "");
            userNameAndDateFixed = userNameAndDateFixed.Replace(":", "");
              
            ge.ToCSV(dgReview, userNameAndDateFixed);
            this.Close();

         
          
        }

        private void DeleteRow_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dgReview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmReviewAndSave_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }
    }
}
