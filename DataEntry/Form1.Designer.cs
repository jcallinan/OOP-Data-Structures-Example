namespace DataEntry
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tankGaugingDataDataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.miBrlHse = new System.Windows.Forms.ToolStripMenuItem();
            this.miFBBlend = new System.Windows.Forms.ToolStripMenuItem();
            this.miCrudeFarm = new System.Windows.Forms.ToolStripMenuItem();
            this.miExtract = new System.Windows.Forms.ToolStripMenuItem();
            this.miBoilerHouse = new System.Windows.Forms.ToolStripMenuItem();
            this.miFosterBrookBulk = new System.Windows.Forms.ToolStripMenuItem();
            this.miCrudeUnit = new System.Windows.Forms.ToolStripMenuItem();
            this.mi4Bay = new System.Windows.Forms.ToolStripMenuItem();
            this.miPlatformer = new System.Windows.Forms.ToolStripMenuItem();
            this.miMEK = new System.Windows.Forms.ToolStripMenuItem();
            this.miPackagingPlant = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.lblNumTanksLoaded = new System.Windows.Forms.ToolStripLabel();
            this.lblTankSaved = new System.Windows.Forms.ToolStripLabel();
            this.lblUnit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tankGaugingDataDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tankGaugingDataDataGridView
            // 
            this.tankGaugingDataDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tankGaugingDataDataGridView.Location = new System.Drawing.Point(5, 29);
            this.tankGaugingDataDataGridView.Name = "tankGaugingDataDataGridView";
            this.tankGaugingDataDataGridView.Size = new System.Drawing.Size(1094, 380);
            this.tankGaugingDataDataGridView.TabIndex = 4;
            this.tankGaugingDataDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tankGaugingDataDataGridView_CellContentClick);
            this.tankGaugingDataDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tankGaugingDataDataGridView_CellEndEdit);
            this.tankGaugingDataDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tankGaugingDataDataGridView_CellValueChanged);
            this.tankGaugingDataDataGridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tankGaugingDataDataGridView_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripDropDownButton1,
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.lblNumTanksLoaded,
            this.lblTankSaved});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1101, 26);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(68, 23);
            this.toolStripButton1.Text = "Save";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miBrlHse,
            this.miFBBlend,
            this.miCrudeFarm,
            this.miExtract,
            this.miBoilerHouse,
            this.miFosterBrookBulk,
            this.miCrudeUnit,
            this.mi4Bay,
            this.miPlatformer,
            this.miMEK,
            this.miPackagingPlant});
            this.toolStripDropDownButton1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(127, 23);
            this.toolStripDropDownButton1.Text = "Select Unit";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // miBrlHse
            // 
            this.miBrlHse.Name = "miBrlHse";
            this.miBrlHse.Size = new System.Drawing.Size(233, 24);
            this.miBrlHse.Text = "Barrel House";
            this.miBrlHse.Click += new System.EventHandler(this.miBrlHse_Click);
            // 
            // miFBBlend
            // 
            this.miFBBlend.Name = "miFBBlend";
            this.miFBBlend.Size = new System.Drawing.Size(233, 24);
            this.miFBBlend.Text = "Foster Brook Blend";
            this.miFBBlend.Click += new System.EventHandler(this.miFBBlend_Click);
            // 
            // miCrudeFarm
            // 
            this.miCrudeFarm.Name = "miCrudeFarm";
            this.miCrudeFarm.Size = new System.Drawing.Size(233, 24);
            this.miCrudeFarm.Text = "Crude Farm";
            this.miCrudeFarm.Click += new System.EventHandler(this.miCrudeFarm_Click);
            // 
            // miExtract
            // 
            this.miExtract.Name = "miExtract";
            this.miExtract.Size = new System.Drawing.Size(233, 24);
            this.miExtract.Text = "Rose/Extract";
            this.miExtract.Click += new System.EventHandler(this.miExtract_Click);
            // 
            // miBoilerHouse
            // 
            this.miBoilerHouse.Name = "miBoilerHouse";
            this.miBoilerHouse.Size = new System.Drawing.Size(233, 24);
            this.miBoilerHouse.Text = "Boiler House";
            this.miBoilerHouse.Click += new System.EventHandler(this.miBoilerHouse_Click);
            // 
            // miFosterBrookBulk
            // 
            this.miFosterBrookBulk.Name = "miFosterBrookBulk";
            this.miFosterBrookBulk.Size = new System.Drawing.Size(233, 24);
            this.miFosterBrookBulk.Text = "Foster Brook Bulk";
            this.miFosterBrookBulk.Click += new System.EventHandler(this.miFosterBrookBulk_Click);
            // 
            // miCrudeUnit
            // 
            this.miCrudeUnit.Name = "miCrudeUnit";
            this.miCrudeUnit.Size = new System.Drawing.Size(233, 24);
            this.miCrudeUnit.Text = "Crude Unit";
            this.miCrudeUnit.Click += new System.EventHandler(this.miCrudeUnit_Click);
            // 
            // mi4Bay
            // 
            this.mi4Bay.Name = "mi4Bay";
            this.mi4Bay.Size = new System.Drawing.Size(233, 24);
            this.mi4Bay.Text = "4 Bay";
            this.mi4Bay.Click += new System.EventHandler(this.mi4Bay_Click);
            // 
            // miPlatformer
            // 
            this.miPlatformer.Name = "miPlatformer";
            this.miPlatformer.Size = new System.Drawing.Size(233, 24);
            this.miPlatformer.Text = "Platformer";
            this.miPlatformer.Click += new System.EventHandler(this.miPlatformer_Click);
            // 
            // miMEK
            // 
            this.miMEK.Name = "miMEK";
            this.miMEK.Size = new System.Drawing.Size(233, 24);
            this.miMEK.Text = "MEK";
            this.miMEK.Click += new System.EventHandler(this.miMEK_Click);
            // 
            // miPackagingPlant
            // 
            this.miPackagingPlant.Name = "miPackagingPlant";
            this.miPackagingPlant.Size = new System.Drawing.Size(233, 24);
            this.miPackagingPlant.Text = "Packaging Plant";
            this.miPackagingPlant.Click += new System.EventHandler(this.miPackagingPlant_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Blue;
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(204, 23);
            this.toolStripLabel1.Text = "View Tank Gauge Reports";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(212, 23);
            this.toolStripLabel2.Text = "View Help Documentation";
            this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // lblNumTanksLoaded
            // 
            this.lblNumTanksLoaded.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNumTanksLoaded.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.lblNumTanksLoaded.Name = "lblNumTanksLoaded";
            this.lblNumTanksLoaded.Size = new System.Drawing.Size(218, 23);
            this.lblNumTanksLoaded.Text = "Number of Tanks Loaded: 0";
            // 
            // lblTankSaved
            // 
            this.lblTankSaved.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTankSaved.ForeColor = System.Drawing.Color.Gray;
            this.lblTankSaved.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.lblTankSaved.Name = "lblTankSaved";
            this.lblTankSaved.Size = new System.Drawing.Size(154, 23);
            this.lblTankSaved.Text = "No tanks saved yet";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(101, 448);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(0, 13);
            this.lblUnit.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 411);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tankGaugingDataDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "American Refining Group - Tank Gauging";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tankGaugingDataDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tankGaugingDataDataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem miBrlHse;
        private System.Windows.Forms.ToolStripMenuItem miFBBlend;
        private System.Windows.Forms.ToolStripMenuItem miCrudeFarm;
        private System.Windows.Forms.ToolStripMenuItem miExtract;
        private System.Windows.Forms.ToolStripMenuItem miBoilerHouse;
        private System.Windows.Forms.ToolStripMenuItem miFosterBrookBulk;
        private System.Windows.Forms.ToolStripMenuItem miCrudeUnit;
        private System.Windows.Forms.ToolStripMenuItem mi4Bay;
        private System.Windows.Forms.ToolStripMenuItem miPlatformer;
        private System.Windows.Forms.ToolStripMenuItem miMEK;
        private System.Windows.Forms.ToolStripMenuItem miPackagingPlant;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel lblNumTanksLoaded;
        private System.Windows.Forms.ToolStripLabel lblTankSaved;

    }
}

