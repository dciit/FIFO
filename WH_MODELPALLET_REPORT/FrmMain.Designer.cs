﻿namespace WH_OBSOLETEREPORT
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgLoadData = new System.ComponentModel.BackgroundWorker();
            this.Header = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonHeaderGroup2 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.dgvDetailList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.groupSearch = new System.Windows.Forms.GroupBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ddlPalletType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ddlModel = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbNWC = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnClear = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pictureLoading = new System.Windows.Forms.PictureBox();
            this.btnSearch = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Header)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Header.Panel)).BeginInit();
            this.Header.Panel.SuspendLayout();
            this.Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).BeginInit();
            this.kryptonHeaderGroup2.Panel.SuspendLayout();
            this.kryptonHeaderGroup2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.groupSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPalletType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNWC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "CSV File|*.csv";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(987, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(140, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveToolStripMenuItem.Text = "&Export Excel";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(140, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(119, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // bgLoadData
            // 
            this.bgLoadData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoadData_DoWork);
            this.bgLoadData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoadData_RunWorkerCompleted);
            // 
            // Header
            // 
            this.Header.CollapseTarget = ComponentFactory.Krypton.Toolkit.HeaderGroupCollapsedTarget.CollapsedToPrimary;
            this.Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Header.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.Header.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ControlClient;
            this.Header.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Primary;
            this.Header.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this.Header.Location = new System.Drawing.Point(0, 24);
            this.Header.Name = "Header";
            this.Header.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            // 
            // Header.Panel
            // 
            this.Header.Panel.Controls.Add(this.kryptonHeaderGroup2);
            this.Header.Panel.Controls.Add(this.kryptonPanel1);
            this.Header.Size = new System.Drawing.Size(987, 559);
            this.Header.TabIndex = 3;
            this.Header.Text = "OBSOLETE REPORT COMPRESSOR";
            this.Header.ValuesPrimary.Description = "";
            this.Header.ValuesPrimary.Heading = "OBSOLETE REPORT COMPRESSOR";
            this.Header.ValuesPrimary.Image = ((System.Drawing.Image)(resources.GetObject("Header.ValuesPrimary.Image")));
            this.Header.ValuesSecondary.Description = "";
            this.Header.ValuesSecondary.Heading = "";
            this.Header.ValuesSecondary.Image = null;
            // 
            // kryptonHeaderGroup2
            // 
            this.kryptonHeaderGroup2.CollapseTarget = ComponentFactory.Krypton.Toolkit.HeaderGroupCollapsedTarget.CollapsedToPrimary;
            this.kryptonHeaderGroup2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup2.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.kryptonHeaderGroup2.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ControlClient;
            this.kryptonHeaderGroup2.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this.kryptonHeaderGroup2.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this.kryptonHeaderGroup2.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup2.Location = new System.Drawing.Point(0, 144);
            this.kryptonHeaderGroup2.Name = "kryptonHeaderGroup2";
            this.kryptonHeaderGroup2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            // 
            // kryptonHeaderGroup2.Panel
            // 
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.dgvDetailList);
            this.kryptonHeaderGroup2.Size = new System.Drawing.Size(985, 380);
            this.kryptonHeaderGroup2.TabIndex = 1;
            this.kryptonHeaderGroup2.Text = "Detail ";
            this.kryptonHeaderGroup2.ValuesPrimary.Description = "";
            this.kryptonHeaderGroup2.ValuesPrimary.Heading = "Detail ";
            this.kryptonHeaderGroup2.ValuesPrimary.Image = ((System.Drawing.Image)(resources.GetObject("kryptonHeaderGroup2.ValuesPrimary.Image")));
            this.kryptonHeaderGroup2.ValuesSecondary.Description = "";
            this.kryptonHeaderGroup2.ValuesSecondary.Heading = "";
            this.kryptonHeaderGroup2.ValuesSecondary.Image = null;
            // 
            // dgvDetailList
            // 
            this.dgvDetailList.AllowUserToAddRows = false;
            this.dgvDetailList.AllowUserToDeleteRows = false;
            this.dgvDetailList.AllowUserToResizeRows = false;
            this.dgvDetailList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetailList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column12,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column8});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetailList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetailList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetailList.Location = new System.Drawing.Point(0, 0);
            this.dgvDetailList.Name = "dgvDetailList";
            this.dgvDetailList.ReadOnly = true;
            this.dgvDetailList.Size = new System.Drawing.Size(983, 357);
            this.dgvDetailList.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 101.8274F;
            this.Column1.HeaderText = "MODEL";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 101.8274F;
            this.Column2.HeaderText = "SERIAL";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 101.8274F;
            this.Column3.HeaderText = "PALLET NO";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.FillWeight = 101.8274F;
            this.Column12.HeaderText = "PALLET TYPE";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 101.8274F;
            this.Column4.HeaderText = "FG DATE";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 101.8274F;
            this.Column5.HeaderText = "SLOW DATE";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 101.8274F;
            this.Column6.HeaderText = "OBSOLETE DATE";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column7.FillWeight = 59.89848F;
            this.Column7.HeaderText = "UNIT";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.FillWeight = 101.8274F;
            this.Column9.HeaderText = "AREA";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.FillWeight = 101.8274F;
            this.Column10.HeaderText = "CURRENT WC";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.FillWeight = 121.8274F;
            this.Column11.HeaderText = "WAREHOUSE CODE";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.FillWeight = 101.8274F;
            this.Column8.HeaderText = "STATUS";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.groupSearch);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            this.kryptonPanel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.TabLowProfile;
            this.kryptonPanel1.Size = new System.Drawing.Size(985, 144);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // groupSearch
            // 
            this.groupSearch.BackColor = System.Drawing.Color.Transparent;
            this.groupSearch.Controls.Add(this.kryptonLabel3);
            this.groupSearch.Controls.Add(this.ddlPalletType);
            this.groupSearch.Controls.Add(this.kryptonLabel1);
            this.groupSearch.Controls.Add(this.ddlModel);
            this.groupSearch.Controls.Add(this.kryptonLabel2);
            this.groupSearch.Controls.Add(this.cbNWC);
            this.groupSearch.Controls.Add(this.btnClear);
            this.groupSearch.Controls.Add(this.pictureLoading);
            this.groupSearch.Controls.Add(this.btnSearch);
            this.groupSearch.Location = new System.Drawing.Point(5, 4);
            this.groupSearch.Name = "groupSearch";
            this.groupSearch.Size = new System.Drawing.Size(574, 134);
            this.groupSearch.TabIndex = 101;
            this.groupSearch.TabStop = false;
            this.groupSearch.Text = "Search / ค้นหาข้อมูล";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(44, 94);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            this.kryptonLabel3.Size = new System.Drawing.Size(97, 22);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 114;
            this.kryptonLabel3.Text = "Pallet Type :";
            this.kryptonLabel3.Values.ExtraText = "";
            this.kryptonLabel3.Values.Image = null;
            this.kryptonLabel3.Values.Text = "Pallet Type :";
            // 
            // ddlPalletType
            // 
            this.ddlPalletType.DropBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.ddlPalletType.DropButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.InputControl;
            this.ddlPalletType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPalletType.DropDownWidth = 121;
            this.ddlPalletType.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Standalone;
            this.ddlPalletType.Items.AddRange(new object[] {
            "ALL",
            "DCI",
            "SKO",
            "PDT",
            "UNW",
            "RPK"});
            this.ddlPalletType.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ListItem;
            this.ddlPalletType.Location = new System.Drawing.Point(154, 93);
            this.ddlPalletType.Name = "ddlPalletType";
            this.ddlPalletType.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            this.ddlPalletType.Size = new System.Drawing.Size(150, 25);
            this.ddlPalletType.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlPalletType.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlPalletType.TabIndex = 113;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(79, 28);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            this.kryptonLabel1.Size = new System.Drawing.Size(62, 22);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 112;
            this.kryptonLabel1.Text = "Model :";
            this.kryptonLabel1.Values.ExtraText = "";
            this.kryptonLabel1.Values.Image = null;
            this.kryptonLabel1.Values.Text = "Model :";
            // 
            // ddlModel
            // 
            this.ddlModel.DropBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.ddlModel.DropButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.InputControl;
            this.ddlModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlModel.DropDownWidth = 121;
            this.ddlModel.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Standalone;
            this.ddlModel.Items.AddRange(new object[] {
            "ALL",
            "DCI",
            "SKO",
            "PDT",
            "UNW",
            "RPK"});
            this.ddlModel.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ListItem;
            this.ddlModel.Location = new System.Drawing.Point(154, 27);
            this.ddlModel.Name = "ddlModel";
            this.ddlModel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            this.ddlModel.Size = new System.Drawing.Size(150, 25);
            this.ddlModel.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlModel.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlModel.TabIndex = 111;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(40, 60);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            this.kryptonLabel2.Size = new System.Drawing.Size(101, 22);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 110;
            this.kryptonLabel2.Text = "Current WC :";
            this.kryptonLabel2.Values.ExtraText = "";
            this.kryptonLabel2.Values.Image = null;
            this.kryptonLabel2.Values.Text = "Current WC :";
            // 
            // cbNWC
            // 
            this.cbNWC.DropBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.cbNWC.DropButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.InputControl;
            this.cbNWC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNWC.DropDownWidth = 121;
            this.cbNWC.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Standalone;
            this.cbNWC.Items.AddRange(new object[] {
            "ALL",
            "DCI",
            "SKO",
            "PDT",
            "UNW",
            "RPK"});
            this.cbNWC.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ListItem;
            this.cbNWC.Location = new System.Drawing.Point(154, 60);
            this.cbNWC.Name = "cbNWC";
            this.cbNWC.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            this.cbNWC.Size = new System.Drawing.Size(150, 25);
            this.cbNWC.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNWC.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNWC.TabIndex = 108;
            // 
            // btnClear
            // 
            this.btnClear.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone;
            this.btnClear.Location = new System.Drawing.Point(350, 75);
            this.btnClear.Name = "btnClear";
            this.btnClear.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            this.btnClear.Size = new System.Drawing.Size(113, 44);
            this.btnClear.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.Values.ExtraText = "";
            this.btnClear.Values.Image = null;
            this.btnClear.Values.ImageStates.ImageCheckedNormal = null;
            this.btnClear.Values.ImageStates.ImageCheckedPressed = null;
            this.btnClear.Values.ImageStates.ImageCheckedTracking = null;
            this.btnClear.Values.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pictureLoading
            // 
            this.pictureLoading.Location = new System.Drawing.Point(483, 53);
            this.pictureLoading.Name = "pictureLoading";
            this.pictureLoading.Size = new System.Drawing.Size(47, 38);
            this.pictureLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLoading.TabIndex = 102;
            this.pictureLoading.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone;
            this.btnSearch.Location = new System.Drawing.Point(349, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            this.btnSearch.Size = new System.Drawing.Size(113, 44);
            this.btnSearch.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.Values.ExtraText = "";
            this.btnSearch.Values.Image = null;
            this.btnSearch.Values.ImageStates.ImageCheckedNormal = null;
            this.btnSearch.Values.ImageStates.ImageCheckedPressed = null;
            this.btnSearch.Values.ImageStates.ImageCheckedTracking = null;
            this.btnSearch.Values.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 583);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OBSOLETE REPORT COMPRESSOR V.3";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Header.Panel)).EndInit();
            this.Header.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Header)).EndInit();
            this.Header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).EndInit();
            this.kryptonHeaderGroup2.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).EndInit();
            this.kryptonHeaderGroup2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.groupSearch.ResumeLayout(false);
            this.groupSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPalletType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNWC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bgLoadData;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup Header;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup2;
        private System.Windows.Forms.DataGridView dgvDetailList;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.GroupBox groupSearch;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSearch;
        private System.Windows.Forms.PictureBox pictureLoading;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbNWC;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox ddlPalletType;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox ddlModel;
    }
}