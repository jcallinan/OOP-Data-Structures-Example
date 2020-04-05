using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace TabletTankGauging
{
    class GridViewExportUtil
    {
        public void SqlDataReaderToCSV(SqlDataReader sdr, string userNameAndDate)
        {

            // Don't save if no data is returned
            if (!sdr.HasRows)
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            // Column headers
            string columnsHeader = "";
            for (int i = 0; i < sdr.FieldCount; i++)
            {
                columnsHeader += sdr[i] + "\t";
            }
            sb.Append(columnsHeader + Environment.NewLine);
            // Go through each cell in the datagridview
            while (sdr.HasRows)
            {

                for (int c = 0; c < sdr.FieldCount; c++)
                {
                    // Append the cells data followed by a comma to delimit.

                    sb.Append("\"" + sdr[c] + "\"" + "\t");
                }
                // Add a new line in the text file.
                sb.Append(Environment.NewLine);

            }
            // Load up the save file dialog with the default option as saving as a .csv file.

            string userNameAndDateFixed = userNameAndDate.Replace("/", "");
            userNameAndDateFixed = userNameAndDateFixed.Replace(" ", "");
            userNameAndDateFixed = userNameAndDateFixed.Replace(":", "");
            string fileName = "";
            if (!Directory.Exists("C:\\Tablet_Tank_Gauging\\"))
            {
                Directory.CreateDirectory("C:\\Tablet_Tank_Gauging\\");
                Directory.CreateDirectory("C:\\Tablet_Tank_Gauging\\");
            }
            fileName = "C:\\Tablet_Tank_Gauging\\" + userNameAndDateFixed + ".tdt";

            // If they've selected a save location...
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false))
            {
                // Write the stringbuilder text to the the file.
                sw.WriteLine(sb.ToString());
            }

            // Confirm to the user it has been completed.

        }
        public void ToCSV(DataGridView dgv, string userNameAndDate)
        {

            // Don't save if no data is returned
            if (dgv.Rows.Count == 0)
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            // Column headers
            string columnsHeader = "";
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                columnsHeader += dgv.Columns[i].Name + "\t";
            }
            sb.Append(columnsHeader + Environment.NewLine);
            // Go through each cell in the datagridview
            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                // Make sure it's not an empty row.
                if (!dgvRow.IsNewRow)
                {
                    string feet = "";
                    try {
                        feet = dgvRow.Cells[3].Value.ToString();
                    } catch (Exception ex) {
                        feet = "";   
                    }

                    if (feet.Length > 0)
                    {
                       for (int c = 0; c < dgvRow.Cells.Count; c++)
                    {
                        // Append the cells data followed by a comma to delimit.

                        sb.Append(dgvRow.Cells[c].Value  + "\t");
                    }
                    // Add a new line in the text file.
                    sb.Append(Environment.NewLine);
                    }
                    
                }
            }
            // Load up the save file dialog with the default option as saving as a .csv file.

            string userNameAndDateFixed = userNameAndDate.Replace("/", "");
            userNameAndDateFixed = userNameAndDateFixed.Replace(" ", "");
            userNameAndDateFixed = userNameAndDateFixed.Replace(":", "");
            string fileName = "";
            if (!Directory.Exists("C:\\Tablet_Tank_Gauging\\"))
            {
                Directory.CreateDirectory("C:\\Tablet_Tank_Gauging\\");
                Directory.CreateDirectory("C:\\Tablet_Tank_Gauging\\");
            }
            fileName = "C:\\Tablet_Tank_Gauging\\" + userNameAndDateFixed + ".tdt";

            // If they've selected a save location...
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false))
            {
                // Write the stringbuilder text to the the file.
                sw.WriteLine(sb.ToString());
            }

            // Confirm to the user it has been completed.

        }
        public void ToCSV(DataTable dtDataTable, string strFilePath, bool AutoSave)
        {
            string userNameAndDateFixed = strFilePath.Replace("/", "");
            userNameAndDateFixed = userNameAndDateFixed.Replace(" ", "");
            userNameAndDateFixed = userNameAndDateFixed.Replace(":", "");
            string fileName = "";
            if (!Directory.Exists("C:\\Tablet_Tank_Gauging\\"))
            {

                Directory.CreateDirectory("C:\\Tablet_Tank_Gauging\\");
            }
           
            fileName = "C:\\Tablet_Tank_Gauging\\"  + userNameAndDateFixed + ".tdt";
            if (AutoSave)
            {
                fileName = "C:\\Tablet_Tank_Gauging\\" + userNameAndDateFixed + "-" + Util.currentDepartment.Replace("/","") + ".tdt-autosave";
                var files = Directory.EnumerateFiles("C:\\Tablet_Tank_Gauging\\",  "*.tdt-autosave");
                //remove all autosave files for this checklist
                foreach (var file in files)
                {
                    File.Delete(file);
                }

            }

            StreamWriter sw = new StreamWriter(fileName, false);
            //headers  
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write("\t");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        //  if (value.Contains(','))
                        //    {
                        value = "\"" + value + "\"" + "\t";
                        sw.Write(value);
                        //  }
                        //  else
                        //  {
                        //  sw.Write(dr[i].ToString());
                        //   }
                    } else
                    {
                        string value = "";
                        value = "\"" + value + "\"" + "\t";
                        sw.Write(value);
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write("\t");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
    }

}
 
