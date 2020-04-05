using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabletTankGauging
{
    public partial class PickUnit : Form
    {
        public PickUnit()
        {
            InitializeComponent();
            try
            {
                Util.UpdateTankInfoOnDisk();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Util.currentDepartment = cmdUnits.Text;
            
            Form1 f1 = new Form1(cmdUnits.Text, Util.currentTankIndex);
            f1.CurrentTankIndex = Util.currentTankIndex;
            f1.Show();
            // f1.Show();





        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PickUnit_Load(object sender, EventArgs e)
        {

        }
    }
}
