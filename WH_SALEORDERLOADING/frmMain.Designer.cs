namespace WH_SALEORDERLOADING
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
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
            this.pnDateDetail = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonHeaderGroup2 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.dgvDetailList = new System.Windows.Forms.DataGridView();
            this.DOCNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODEL_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRUCK_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PALLET_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PALLET_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WAREHOUSE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ETD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDTYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOADDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DELBIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.groupSearch = new System.Windows.Forms.GroupBox();
            this.txtModel = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cbCustomer = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClear = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSearch = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureLoading = new System.Windows.Forms.PictureBox();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnDateDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnDateDetail.Panel)).BeginInit();
            this.pnDateDetail.Panel.SuspendLayout();
            this.pnDateDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).BeginInit();
            this.kryptonHeaderGroup2.Panel.SuspendLayout();
            this.kryptonHeaderGroup2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.groupSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "CSVFile|*.csv";
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
            // pnDateDetail
            // 
            this.pnDateDetail.CollapseTarget = ComponentFactory.Krypton.Toolkit.HeaderGroupCollapsedTarget.CollapsedToPrimary;
            this.pnDateDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDateDetail.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.pnDateDetail.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ControlClient;
            this.pnDateDetail.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Primary;
            this.pnDateDetail.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this.pnDateDetail.Location = new System.Drawing.Point(0, 24);
            this.pnDateDetail.Name = "pnDateDetail";
            this.pnDateDetail.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            // 
            // pnDateDetail.Panel
            // 
            this.pnDateDetail.Panel.Controls.Add(this.kryptonHeaderGroup2);
            this.pnDateDetail.Panel.Controls.Add(this.kryptonPanel1);
            this.pnDateDetail.Size = new System.Drawing.Size(987, 559);
            this.pnDateDetail.TabIndex = 3;
            this.pnDateDetail.Text = "Sale And Loading";
            this.pnDateDetail.ValuesPrimary.Description = "";
            this.pnDateDetail.ValuesPrimary.Heading = "Sale And Loading";
            this.pnDateDetail.ValuesPrimary.Image = ((System.Drawing.Image)(resources.GetObject("pnDateDetail.ValuesPrimary.Image")));
            this.pnDateDetail.ValuesSecondary.Description = "";
            this.pnDateDetail.ValuesSecondary.Heading = "";
            this.pnDateDetail.ValuesSecondary.Image = null;
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
            this.kryptonHeaderGroup2.ValuesSecondary.Heading = "Description";
            this.kryptonHeaderGroup2.ValuesSecondary.Image = null;
            // 
            // dgvDetailList
            // 
            this.dgvDetailList.AllowUserToAddRows = false;
            this.dgvDetailList.AllowUserToDeleteRows = false;
            this.dgvDetailList.AllowUserToResizeRows = false;
            this.dgvDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DOCNO,
            this.INVOICE_NO,
            this.MODEL_,
            this.CUSTOMER_NAME,
            this.TRUCK_NO,
            this.PALLET_NO,
            this.PALLET_TYPE,
            this.WAREHOUSE,
            this.CTNO,
            this.ETD,
            this.ORDTYPE,
            this.LOADDATE,
            this.DELBIT});
            this.dgvDetailList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetailList.Location = new System.Drawing.Point(0, 0);
            this.dgvDetailList.Name = "dgvDetailList";
            this.dgvDetailList.ReadOnly = true;
            this.dgvDetailList.Size = new System.Drawing.Size(983, 357);
            this.dgvDetailList.TabIndex = 0;
            // 
            // DOCNO
            // 
            this.DOCNO.HeaderText = "DOC_NO      ";
            this.DOCNO.Name = "DOCNO";
            this.DOCNO.ReadOnly = true;
            // 
            // INVOICE_NO
            // 
            this.INVOICE_NO.HeaderText = "INVOICE_NO";
            this.INVOICE_NO.Name = "INVOICE_NO";
            this.INVOICE_NO.ReadOnly = true;
            // 
            // MODEL_
            // 
            this.MODEL_.HeaderText = "MODEL";
            this.MODEL_.Name = "MODEL_";
            this.MODEL_.ReadOnly = true;
            // 
            // CUSTOMER_NAME
            // 
            this.CUSTOMER_NAME.HeaderText = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.Name = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.ReadOnly = true;
            this.CUSTOMER_NAME.Width = 300;
            // 
            // TRUCK_NO
            // 
            this.TRUCK_NO.HeaderText = "TRUCK_NO";
            this.TRUCK_NO.Name = "TRUCK_NO";
            this.TRUCK_NO.ReadOnly = true;
            // 
            // PALLET_NO
            // 
            this.PALLET_NO.HeaderText = "PALLET_NO";
            this.PALLET_NO.Name = "PALLET_NO";
            this.PALLET_NO.ReadOnly = true;
            // 
            // PALLET_TYPE
            // 
            this.PALLET_TYPE.HeaderText = "PALLET_TYPE";
            this.PALLET_TYPE.Name = "PALLET_TYPE";
            this.PALLET_TYPE.ReadOnly = true;
            // 
            // WAREHOUSE
            // 
            this.WAREHOUSE.HeaderText = "WAREHOUSE";
            this.WAREHOUSE.Name = "WAREHOUSE";
            this.WAREHOUSE.ReadOnly = true;
            // 
            // CTNO
            // 
            this.CTNO.HeaderText = "CTNO";
            this.CTNO.Name = "CTNO";
            this.CTNO.ReadOnly = true;
            // 
            // ETD
            // 
            this.ETD.HeaderText = "ETD";
            this.ETD.Name = "ETD";
            this.ETD.ReadOnly = true;
            // 
            // ORDTYPE
            // 
            this.ORDTYPE.HeaderText = "ORDTYPE";
            this.ORDTYPE.Name = "ORDTYPE";
            this.ORDTYPE.ReadOnly = true;
            // 
            // LOADDATE
            // 
            this.LOADDATE.HeaderText = "LOADDATE";
            this.LOADDATE.Name = "LOADDATE";
            this.LOADDATE.ReadOnly = true;
            // 
            // DELBIT
            // 
            this.DELBIT.HeaderText = "DELBIT";
            this.DELBIT.Name = "DELBIT";
            this.DELBIT.ReadOnly = true;
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
            this.groupSearch.Controls.Add(this.txtModel);
            this.groupSearch.Controls.Add(this.cbCustomer);
            this.groupSearch.Controls.Add(this.label6);
            this.groupSearch.Controls.Add(this.label5);
            this.groupSearch.Controls.Add(this.btnClear);
            this.groupSearch.Controls.Add(this.pictureLoading);
            this.groupSearch.Controls.Add(this.btnSearch);
            this.groupSearch.Controls.Add(this.txtEndDate);
            this.groupSearch.Controls.Add(this.label2);
            this.groupSearch.Controls.Add(this.txtStartDate);
            this.groupSearch.Controls.Add(this.label1);
            this.groupSearch.Location = new System.Drawing.Point(5, 4);
            this.groupSearch.Name = "groupSearch";
            this.groupSearch.Size = new System.Drawing.Size(591, 134);
            this.groupSearch.TabIndex = 101;
            this.groupSearch.TabStop = false;
            this.groupSearch.Text = "Search / ค้นหาข้อมูล";
            // 
            // txtModel
            // 
            this.txtModel.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Standalone;
            this.txtModel.Location = new System.Drawing.Point(278, 23);
            this.txtModel.MaxLength = 15;
            this.txtModel.Name = "txtModel";
            this.txtModel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            this.txtModel.Size = new System.Drawing.Size(207, 26);
            this.txtModel.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModel.TabIndex = 3;
            this.txtModel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtModel_KeyDown);
            // 
            // cbCustomer
            // 
            this.cbCustomer.DropBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.cbCustomer.DropButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.InputControl;
            this.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomer.DropDownWidth = 298;
            this.cbCustomer.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Standalone;
            this.cbCustomer.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ListItem;
            this.cbCustomer.Location = new System.Drawing.Point(278, 56);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            this.cbCustomer.Size = new System.Drawing.Size(298, 24);
            this.cbCustomer.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomer.TabIndex = 4;
            this.cbCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCustomer_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(205, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 114;
            this.label6.Text = "Customer :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(223, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 113;
            this.label5.Text = "Model :";
            // 
            // btnClear
            // 
            this.btnClear.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone;
            this.btnClear.Location = new System.Drawing.Point(293, 88);
            this.btnClear.Name = "btnClear";
            this.btnClear.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            this.btnClear.Size = new System.Drawing.Size(96, 40);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.Values.ExtraText = "";
            this.btnClear.Values.Image = global::WH_SALEORDERLOADING.Properties.Resources.Clear;
            this.btnClear.Values.ImageStates.ImageCheckedNormal = null;
            this.btnClear.Values.ImageStates.ImageCheckedPressed = null;
            this.btnClear.Values.ImageStates.ImageCheckedTracking = null;
            this.btnClear.Values.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone;
            this.btnSearch.Location = new System.Drawing.Point(129, 88);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            this.btnSearch.Size = new System.Drawing.Size(104, 41);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.Values.ExtraText = "";
            this.btnSearch.Values.Image = global::WH_SALEORDERLOADING.Properties.Resources.search7;
            this.btnSearch.Values.ImageStates.ImageCheckedNormal = null;
            this.btnSearch.Values.ImageStates.ImageCheckedPressed = null;
            this.btnSearch.Values.ImageStates.ImageCheckedTracking = null;
            this.btnSearch.Values.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtEndDate
            // 
            this.txtEndDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtEndDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEndDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.Location = new System.Drawing.Point(99, 56);
            this.txtEndDate.MaxLength = 8;
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(100, 26);
            this.txtEndDate.TabIndex = 2;
            this.txtEndDate.Tag = "2";
            this.txtEndDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEndDate_KeyDown);
            this.txtEndDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEndDate_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "End Date : ";
            // 
            // txtStartDate
            // 
            this.txtStartDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtStartDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartDate.Location = new System.Drawing.Point(99, 23);
            this.txtStartDate.MaxLength = 8;
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(100, 26);
            this.txtStartDate.TabIndex = 1;
            this.txtStartDate.Tag = "1";
            this.txtStartDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStartDate_KeyDown);
            this.txtStartDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartDate_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Date : ";
            // 
            // pictureLoading
            // 
            this.pictureLoading.Image = global::WH_SALEORDERLOADING.Properties.Resources.loading;
            this.pictureLoading.Location = new System.Drawing.Point(247, 92);
            this.pictureLoading.Name = "pictureLoading";
            this.pictureLoading.Size = new System.Drawing.Size(29, 34);
            this.pictureLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLoading.TabIndex = 102;
            this.pictureLoading.TabStop = false;
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 583);
            this.Controls.Add(this.pnDateDetail);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sale And Loading  V.2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnDateDetail.Panel)).EndInit();
            this.pnDateDetail.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnDateDetail)).EndInit();
            this.pnDateDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).EndInit();
            this.kryptonHeaderGroup2.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).EndInit();
            this.kryptonHeaderGroup2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.groupSearch.ResumeLayout(false);
            this.groupSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCustomer)).EndInit();
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
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup pnDateDetail;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup2;
        private System.Windows.Forms.DataGridView dgvDetailList;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.GroupBox groupSearch;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSearch;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureLoading;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbCustomer;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOCNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRUCK_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PALLET_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PALLET_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WAREHOUSE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ETD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDTYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOADDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DELBIT;
    }
}