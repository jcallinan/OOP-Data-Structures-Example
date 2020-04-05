namespace TabletTankGauging
{
    partial class frmReviewAndSave
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReviewAndSave));
            this.btnSaveAndContinue = new System.Windows.Forms.Button();
            this.dgReview = new System.Windows.Forms.DataGridView();
            this.Tank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Feet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InchesPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTimeDone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HazardConditions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaterCheck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmergContainmentValve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.InspectionRecord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgReview)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveAndContinue
            // 
            this.btnSaveAndContinue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSaveAndContinue.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnSaveAndContinue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.GreenYellow;
            this.btnSaveAndContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GreenYellow;
            this.btnSaveAndContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAndContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndContinue.ForeColor = System.Drawing.Color.Green;
            this.btnSaveAndContinue.Location = new System.Drawing.Point(859, 581);
            this.btnSaveAndContinue.Name = "btnSaveAndContinue";
            this.btnSaveAndContinue.Size = new System.Drawing.Size(406, 65);
            this.btnSaveAndContinue.TabIndex = 27;
            this.btnSaveAndContinue.Text = "Save gauges";
            this.btnSaveAndContinue.UseVisualStyleBackColor = false;
            this.btnSaveAndContinue.Click += new System.EventHandler(this.btnSaveAndContinue_Click);
            // 
            // dgReview
            // 
            this.dgReview.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgReview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgReview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tank,
            this.Product,
            this.Description,
            this.Feet,
            this.Inches,
            this.InchesPart,
            this.Temperature,
            this.Status,
            this.DateTimeDone,
            this.HazardConditions,
            this.WaterCheck,
            this.EmergContainmentValve,
            this.AR,
            this.InspectionRecord});
            this.dgReview.ContextMenuStrip = this.DeleteRow;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgReview.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgReview.GridColor = System.Drawing.Color.MediumSeaGreen;
            this.dgReview.Location = new System.Drawing.Point(15, 19);
            this.dgReview.Name = "dgReview";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgReview.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgReview.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgReview.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgReview.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgReview.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgReview.RowTemplate.Height = 30;
            this.dgReview.Size = new System.Drawing.Size(1253, 435);
            this.dgReview.TabIndex = 26;
            this.dgReview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgReview_CellContentClick);
            // 
            // Tank
            // 
            this.Tank.HeaderText = "Tank";
            this.Tank.Name = "Tank";
            this.Tank.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Tank.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Product
            // 
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 150;
            // 
            // Feet
            // 
            this.Feet.HeaderText = "Feet";
            this.Feet.Name = "Feet";
            this.Feet.Width = 90;
            // 
            // Inches
            // 
            this.Inches.HeaderText = "Inches";
            this.Inches.Name = "Inches";
            this.Inches.Width = 90;
            // 
            // InchesPart
            // 
            this.InchesPart.HeaderText = "1/4";
            this.InchesPart.Name = "InchesPart";
            // 
            // Temperature
            // 
            this.Temperature.HeaderText = "Temperature";
            this.Temperature.Name = "Temperature";
            this.Temperature.Width = 150;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // DateTimeDone
            // 
            this.DateTimeDone.HeaderText = "Date/Time";
            this.DateTimeDone.Name = "DateTimeDone";
            this.DateTimeDone.Width = 125;
            // 
            // HazardConditions
            // 
            this.HazardConditions.HeaderText = "HC";
            this.HazardConditions.Name = "HazardConditions";
            this.HazardConditions.Width = 70;
            // 
            // WaterCheck
            // 
            this.WaterCheck.HeaderText = "WC";
            this.WaterCheck.Name = "WaterCheck";
            this.WaterCheck.Width = 70;
            // 
            // EmergContainmentValve
            // 
            this.EmergContainmentValve.HeaderText = "ECV";
            this.EmergContainmentValve.Name = "EmergContainmentValve";
            this.EmergContainmentValve.Width = 70;
            // 
            // AR
            // 
            this.AR.HeaderText = "AR";
            this.AR.Name = "AR";
            // 
            // DeleteRow
            // 
            this.DeleteRow.Name = "DeleteRow";
            this.DeleteRow.Size = new System.Drawing.Size(61, 4);
            this.DeleteRow.Text = "Remove Tank";
            this.DeleteRow.Opening += new System.ComponentModel.CancelEventHandler(this.DeleteRow_Opening);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(538, 73);
            this.label1.TabIndex = 28;
            this.label1.Text = "Review and save:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.dgReview);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-3, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1335, 475);
            this.panel1.TabIndex = 29;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1094, 340);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(254, 132);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // InspectionRecord
            // 
            this.InspectionRecord.HeaderText = "IR";
            this.InspectionRecord.Name = "InspectionRecord";
            // 
            // frmReviewAndSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 662);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveAndContinue);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReviewAndSave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "American Refining Group - Tank Gauging";
            this.Load += new System.EventHandler(this.frmReviewAndSave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgReview)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveAndContinue;
        private System.Windows.Forms.DataGridView dgReview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip DeleteRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Feet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inches;
        private System.Windows.Forms.DataGridViewTextBoxColumn InchesPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTimeDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn HazardConditions;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaterCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmergContainmentValve;
        private System.Windows.Forms.DataGridViewTextBoxColumn AR;
        private System.Windows.Forms.DataGridViewTextBoxColumn InspectionRecord;
    }
}