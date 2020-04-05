namespace ImportToiSeries
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.tankGaugingDataBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tankGaugingDataBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tankGaugingDataDataGridView = new System.Windows.Forms.DataGridView();
            this.InOutage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtErrorText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.recordDate = new System.Windows.Forms.MonthCalendar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCurTank = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.chkInspectionRec = new System.Windows.Forms.CheckBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tankGaugingDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tankGaugingData = new ImportToiSeries.TankGaugingData();
            this.tankGaugingDataTableAdapter = new ImportToiSeries.TankGaugingDataTableAdapters.TankGaugingDataTableAdapter();
            this.tableAdapterManager = new ImportToiSeries.TankGaugingDataTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.tankGaugingDataBindingNavigator)).BeginInit();
            this.tankGaugingDataBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tankGaugingDataDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankGaugingDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankGaugingData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-189, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // tankGaugingDataBindingNavigator
            // 
            this.tankGaugingDataBindingNavigator.AddNewItem = null;
            this.tankGaugingDataBindingNavigator.BindingSource = this.tankGaugingDataBindingSource;
            this.tankGaugingDataBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tankGaugingDataBindingNavigator.DeleteItem = null;
            this.tankGaugingDataBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.tankGaugingDataBindingNavigatorSaveItem,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolStripButton2});
            this.tankGaugingDataBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.tankGaugingDataBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tankGaugingDataBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tankGaugingDataBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tankGaugingDataBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tankGaugingDataBindingNavigator.Name = "tankGaugingDataBindingNavigator";
            this.tankGaugingDataBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tankGaugingDataBindingNavigator.Size = new System.Drawing.Size(1265, 25);
            this.tankGaugingDataBindingNavigator.TabIndex = 2;
            this.tankGaugingDataBindingNavigator.Text = "bindingNavigator1";
            this.tankGaugingDataBindingNavigator.RefreshItems += new System.EventHandler(this.tankGaugingDataBindingNavigator_RefreshItems);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tankGaugingDataBindingNavigatorSaveItem
            // 
            this.tankGaugingDataBindingNavigatorSaveItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.tankGaugingDataBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tankGaugingDataBindingNavigatorSaveItem.Image")));
            this.tankGaugingDataBindingNavigatorSaveItem.Name = "tankGaugingDataBindingNavigatorSaveItem";
            this.tankGaugingDataBindingNavigatorSaveItem.Size = new System.Drawing.Size(95, 22);
            this.tankGaugingDataBindingNavigatorSaveItem.Text = "Save Data";
            this.tankGaugingDataBindingNavigatorSaveItem.Click += new System.EventHandler(this.tankGaugingDataBindingNavigatorSaveItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton1.Text = "Send";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(46, 22);
            this.toolStripButton2.Text = "Close";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tankGaugingDataDataGridView
            // 
            this.tankGaugingDataDataGridView.AutoGenerateColumns = false;
            this.tankGaugingDataDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tankGaugingDataDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.InOutage});
            this.tankGaugingDataDataGridView.DataSource = this.tankGaugingDataBindingSource;
            this.tankGaugingDataDataGridView.Location = new System.Drawing.Point(208, 94);
            this.tankGaugingDataDataGridView.Name = "tankGaugingDataDataGridView";
            this.tankGaugingDataDataGridView.Size = new System.Drawing.Size(1046, 380);
            this.tankGaugingDataDataGridView.TabIndex = 3;
            this.tankGaugingDataDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tankGaugingDataDataGridView_CellClick);
            this.tankGaugingDataDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tankGaugingDataDataGridView_CellContentClick);
            // 
            // InOutage
            // 
            this.InOutage.DataPropertyName = "InOutage";
            this.InOutage.HeaderText = "InOutage";
            this.InOutage.Name = "InOutage";
            // 
            // txtErrorText
            // 
            this.txtErrorText.Location = new System.Drawing.Point(1342, 73);
            this.txtErrorText.Multiline = true;
            this.txtErrorText.Name = "txtErrorText";
            this.txtErrorText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErrorText.Size = new System.Drawing.Size(100, 20);
            this.txtErrorText.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(385, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Below are the current records in the holding area, ready to be sent to the iSerie" +
    "s.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(711, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Make any changes you would like to make, then save them using the \'Save\' button a" +
    "bove. Once you are ready, hit \'Send\' to send them to the iSeries.";
            // 
            // recordDate
            // 
            this.recordDate.Location = new System.Drawing.Point(0, 57);
            this.recordDate.MaxSelectionCount = 1;
            this.recordDate.Name = "recordDate";
            this.recordDate.TabIndex = 7;
            this.recordDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.recordDate_DateChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Date to show records for:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Current Tank:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Unit:";
            // 
            // lblCurTank
            // 
            this.lblCurTank.AutoSize = true;
            this.lblCurTank.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurTank.ForeColor = System.Drawing.Color.Green;
            this.lblCurTank.Location = new System.Drawing.Point(18, 279);
            this.lblCurTank.Name = "lblCurTank";
            this.lblCurTank.Size = new System.Drawing.Size(76, 18);
            this.lblCurTank.TabIndex = 11;
            this.lblCurTank.Text = "[               ]";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit.ForeColor = System.Drawing.Color.Green;
            this.lblUnit.Location = new System.Drawing.Point(18, 332);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(76, 18);
            this.lblUnit.TabIndex = 12;
            this.lblUnit.Text = "[               ]";
            // 
            // chkInspectionRec
            // 
            this.chkInspectionRec.AutoSize = true;
            this.chkInspectionRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInspectionRec.Location = new System.Drawing.Point(1093, 51);
            this.chkInspectionRec.Name = "chkInspectionRec";
            this.chkInspectionRec.Size = new System.Drawing.Size(153, 19);
            this.chkInspectionRec.TabIndex = 13;
            this.chkInspectionRec.Text = "Only inspection records";
            this.chkInspectionRec.UseVisualStyleBackColor = true;
            this.chkInspectionRec.CheckedChanged += new System.EventHandler(this.chkInspectionRec_CheckedChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TankNumber";
            this.dataGridViewTextBoxColumn1.HeaderText = "TankNumber";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DateTimeTaken";
            this.dataGridViewTextBoxColumn2.HeaderText = "DateTimeTaken";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Feet";
            this.dataGridViewTextBoxColumn3.HeaderText = "Feet";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Inches";
            this.dataGridViewTextBoxColumn4.HeaderText = "Inches";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "InchesPart";
            this.dataGridViewTextBoxColumn5.HeaderText = "InchesPart";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Temperature";
            this.dataGridViewTextBoxColumn6.HeaderText = "Temperature";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Inspection";
            this.dataGridViewTextBoxColumn7.HeaderText = "Inspection";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ProdCode";
            this.dataGridViewTextBoxColumn8.HeaderText = "ProdCode";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ProdDescription";
            this.dataGridViewTextBoxColumn9.HeaderText = "ProdDescription";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // tankGaugingDataBindingSource
            // 
            this.tankGaugingDataBindingSource.DataMember = "TankGaugingData";
            this.tankGaugingDataBindingSource.DataSource = this.tankGaugingData;
            // 
            // tankGaugingData
            // 
            this.tankGaugingData.DataSetName = "TankGaugingData";
            this.tankGaugingData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tankGaugingDataTableAdapter
            // 
            this.tankGaugingDataTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.TankGaugingDataTableAdapter = this.tankGaugingDataTableAdapter;
            this.tableAdapterManager.UpdateOrder = ImportToiSeries.TankGaugingDataTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 488);
            this.Controls.Add(this.chkInspectionRec);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.lblCurTank);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.recordDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtErrorText);
            this.Controls.Add(this.tankGaugingDataDataGridView);
            this.Controls.Add(this.tankGaugingDataBindingNavigator);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Tank Gauging Import to iSeries";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tankGaugingDataBindingNavigator)).EndInit();
            this.tankGaugingDataBindingNavigator.ResumeLayout(false);
            this.tankGaugingDataBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tankGaugingDataDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankGaugingDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankGaugingData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private TankGaugingData tankGaugingData;
        private System.Windows.Forms.BindingSource tankGaugingDataBindingSource;
        private TankGaugingDataTableAdapters.TankGaugingDataTableAdapter tankGaugingDataTableAdapter;
        private TankGaugingDataTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tankGaugingDataBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton tankGaugingDataBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView tankGaugingDataDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TextBox txtErrorText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn InOutage;
        private System.Windows.Forms.MonthCalendar recordDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCurTank;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.CheckBox chkInspectionRec;
    }
}

