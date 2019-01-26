namespace SunManage
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.CreateDevice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStartBuubblePointCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.ManualBubbleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BasicBubbleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StrengthenTheBubbleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolFlowCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.RateOfRiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DiffusionFlowCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WaterImmersionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolHistoricalRecords = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSystemParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mStatusStrip = new System.Windows.Forms.StatusStrip();
            this.MainToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerMainStatus = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxExport = new System.Windows.Forms.PictureBox();
            this.pictureBoxHelp = new System.Windows.Forms.PictureBox();
            this.pictureBoxImport = new System.Windows.Forms.PictureBox();
            this.pictureBoxCommunication = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStripSystem = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDelet = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCommunication = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSystemset = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemImport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRest = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.RssTreeView = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MyPanel = new System.Windows.Forms.Panel();
            this.mSkinEngine = new Sunisoft.IrisSkin.SkinEngine();
            this.timerPollingInquiry = new System.Windows.Forms.Timer(this.components);
            this.CreateDevice.SuspendLayout();
            this.CreateEdit.SuspendLayout();
            this.mStatusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCommunication)).BeginInit();
            this.panel3.SuspendLayout();
            this.menuStripSystem.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "auto.bmp");
            this.imageList.Images.SetKeyName(1, "BACKUP.BMP");
            this.imageList.Images.SetKeyName(2, "BFLY1.BMP");
            this.imageList.Images.SetKeyName(3, "bt.bmp");
            this.imageList.Images.SetKeyName(4, "Bubbles.bmp");
            this.imageList.Images.SetKeyName(5, "INSTALL.BMP");
            this.imageList.Images.SetKeyName(6, "JMMES.BMP");
            this.imageList.Images.SetKeyName(7, "SBubblepoint.BMP");
            this.imageList.Images.SetKeyName(8, "SETUP.BMP");
            this.imageList.Images.SetKeyName(9, "WRENCH.BMP");
            this.imageList.Images.SetKeyName(10, "Delete.png");
            this.imageList.Images.SetKeyName(11, "Edit.png");
            this.imageList.Images.SetKeyName(12, "NewBuild.png");
            // 
            // CreateDevice
            // 
            this.CreateDevice.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CreateDevice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.CreateDevice.Name = "contextMenuStrip1";
            this.CreateDevice.Size = new System.Drawing.Size(99, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem1.Text = "New";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.CreateMouseLeft);
            // 
            // CreateEdit
            // 
            this.CreateEdit.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CreateEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem4,
            this.ToolStartBuubblePointCheck,
            this.toolFlowCheck,
            this.toolHistoricalRecords,
            this.toolSystemParameter,
            this.toolUserInfo});
            this.CreateEdit.Name = "CreateEdit";
            this.CreateEdit.Size = new System.Drawing.Size(170, 158);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem2.Text = "New";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.AddNode);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem4.Text = "Delete";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.MouseDownDelete);
            // 
            // ToolStartBuubblePointCheck
            // 
            this.ToolStartBuubblePointCheck.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManualBubbleToolStripMenuItem,
            this.BasicBubbleToolStripMenuItem,
            this.StrengthenTheBubbleToolStripMenuItem});
            this.ToolStartBuubblePointCheck.Name = "ToolStartBuubblePointCheck";
            this.ToolStartBuubblePointCheck.Size = new System.Drawing.Size(169, 22);
            this.ToolStartBuubblePointCheck.Text = "Test.BP";
            // 
            // ManualBubbleToolStripMenuItem
            // 
            this.ManualBubbleToolStripMenuItem.Name = "ManualBubbleToolStripMenuItem";
            this.ManualBubbleToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.ManualBubbleToolStripMenuItem.Text = "Manual Bubble Point";
            this.ManualBubbleToolStripMenuItem.Click += new System.EventHandler(this.ManualBubbleToolStripMenuItem_Click);
            // 
            // BasicBubbleToolStripMenuItem
            // 
            this.BasicBubbleToolStripMenuItem.Name = "BasicBubbleToolStripMenuItem";
            this.BasicBubbleToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.BasicBubbleToolStripMenuItem.Text = "Basic Bubble Point";
            this.BasicBubbleToolStripMenuItem.Click += new System.EventHandler(this.BasicBubbleToolStripMenuItem_Click);
            // 
            // StrengthenTheBubbleToolStripMenuItem
            // 
            this.StrengthenTheBubbleToolStripMenuItem.Name = "StrengthenTheBubbleToolStripMenuItem";
            this.StrengthenTheBubbleToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.StrengthenTheBubbleToolStripMenuItem.Text = "Extensive Bubble Point";
            this.StrengthenTheBubbleToolStripMenuItem.Click += new System.EventHandler(this.StrengthenTheBubbleToolStripMenuItem_Click);
            // 
            // toolFlowCheck
            // 
            this.toolFlowCheck.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RateOfRiseToolStripMenuItem,
            this.DiffusionFlowCheckToolStripMenuItem,
            this.WaterImmersionTestToolStripMenuItem});
            this.toolFlowCheck.Name = "toolFlowCheck";
            this.toolFlowCheck.Size = new System.Drawing.Size(169, 22);
            this.toolFlowCheck.Text = "Test.DF";
            // 
            // RateOfRiseToolStripMenuItem
            // 
            this.RateOfRiseToolStripMenuItem.Name = "RateOfRiseToolStripMenuItem";
            this.RateOfRiseToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.RateOfRiseToolStripMenuItem.Text = "Pressure Holding";
            this.RateOfRiseToolStripMenuItem.Click += new System.EventHandler(this.RateOfRiseToolStripMenuItem_Click);
            // 
            // DiffusionFlowCheckToolStripMenuItem
            // 
            this.DiffusionFlowCheckToolStripMenuItem.Name = "DiffusionFlowCheckToolStripMenuItem";
            this.DiffusionFlowCheckToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.DiffusionFlowCheckToolStripMenuItem.Text = "Diffusion Flow";
            this.DiffusionFlowCheckToolStripMenuItem.Click += new System.EventHandler(this.DiffusionFlowCheckToolStripMenuItem_Click);
            // 
            // WaterImmersionTestToolStripMenuItem
            // 
            this.WaterImmersionTestToolStripMenuItem.Name = "WaterImmersionTestToolStripMenuItem";
            this.WaterImmersionTestToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.WaterImmersionTestToolStripMenuItem.Text = "Water Immersion ";
            this.WaterImmersionTestToolStripMenuItem.Click += new System.EventHandler(this.WaterImmersionTestToolStripMenuItem_Click);
            // 
            // toolHistoricalRecords
            // 
            this.toolHistoricalRecords.Name = "toolHistoricalRecords";
            this.toolHistoricalRecords.Size = new System.Drawing.Size(169, 22);
            this.toolHistoricalRecords.Text = "Historical Records";
            this.toolHistoricalRecords.Click += new System.EventHandler(this.toolHistoricalRecords_Click);
            // 
            // toolSystemParameter
            // 
            this.toolSystemParameter.Name = "toolSystemParameter";
            this.toolSystemParameter.Size = new System.Drawing.Size(169, 22);
            this.toolSystemParameter.Text = "System Parameter";
            this.toolSystemParameter.Click += new System.EventHandler(this.toolSystemParameter_Click);
            // 
            // toolUserInfo
            // 
            this.toolUserInfo.Name = "toolUserInfo";
            this.toolUserInfo.Size = new System.Drawing.Size(169, 22);
            this.toolUserInfo.Text = "User Info";
            this.toolUserInfo.Click += new System.EventHandler(this.toolUserInfo_Click);
            // 
            // mStatusStrip
            // 
            this.mStatusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainToolStripStatusLabel,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.mStatusStrip.Location = new System.Drawing.Point(0, 538);
            this.mStatusStrip.Name = "mStatusStrip";
            this.mStatusStrip.Size = new System.Drawing.Size(990, 22);
            this.mStatusStrip.TabIndex = 7;
            // 
            // MainToolStripStatusLabel
            // 
            this.MainToolStripStatusLabel.Name = "MainToolStripStatusLabel";
            this.MainToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // timerMainStatus
            // 
            this.timerMainStatus.Tick += new System.EventHandler(this.timerMainStatus_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBoxExport);
            this.panel1.Controls.Add(this.pictureBoxHelp);
            this.panel1.Controls.Add(this.pictureBoxImport);
            this.panel1.Controls.Add(this.pictureBoxCommunication);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 53);
            this.panel1.TabIndex = 5;
            // 
            // pictureBoxExport
            // 
            this.pictureBoxExport.Image = global::SunManage.Properties.Resources.AlienAqua_USB___Export;
            this.pictureBoxExport.Location = new System.Drawing.Point(123, 5);
            this.pictureBoxExport.Name = "pictureBoxExport";
            this.pictureBoxExport.Size = new System.Drawing.Size(52, 41);
            this.pictureBoxExport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxExport.TabIndex = 4;
            this.pictureBoxExport.TabStop = false;
            this.pictureBoxExport.Click += new System.EventHandler(this.pictureBoxExport_Click);
            this.pictureBoxExport.MouseEnter += new System.EventHandler(this.pictureBoxExport_MouseEnter);
            // 
            // pictureBoxHelp
            // 
            this.pictureBoxHelp.Image = global::SunManage.Properties.Resources.AlienAqua_Help;
            this.pictureBoxHelp.Location = new System.Drawing.Point(63, 5);
            this.pictureBoxHelp.Name = "pictureBoxHelp";
            this.pictureBoxHelp.Size = new System.Drawing.Size(52, 41);
            this.pictureBoxHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxHelp.TabIndex = 3;
            this.pictureBoxHelp.TabStop = false;
            this.pictureBoxHelp.Click += new System.EventHandler(this.pictureBoxHelp_Click);
            this.pictureBoxHelp.MouseEnter += new System.EventHandler(this.pictureBoxHelp_MouseEnter);
            // 
            // pictureBoxImport
            // 
            this.pictureBoxImport.Image = global::SunManage.Properties.Resources.AlienAqua_USB;
            this.pictureBoxImport.Location = new System.Drawing.Point(183, 5);
            this.pictureBoxImport.Name = "pictureBoxImport";
            this.pictureBoxImport.Size = new System.Drawing.Size(52, 41);
            this.pictureBoxImport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImport.TabIndex = 2;
            this.pictureBoxImport.TabStop = false;
            this.pictureBoxImport.Click += new System.EventHandler(this.pictureBoxImport_Click);
            this.pictureBoxImport.MouseEnter += new System.EventHandler(this.pictureBoxImport_MouseEnter);
            // 
            // pictureBoxCommunication
            // 
            this.pictureBoxCommunication.Image = global::SunManage.Properties.Resources.AlienAqua_network;
            this.pictureBoxCommunication.Location = new System.Drawing.Point(3, 5);
            this.pictureBoxCommunication.Name = "pictureBoxCommunication";
            this.pictureBoxCommunication.Size = new System.Drawing.Size(52, 41);
            this.pictureBoxCommunication.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCommunication.TabIndex = 1;
            this.pictureBoxCommunication.TabStop = false;
            this.pictureBoxCommunication.Click += new System.EventHandler(this.pictureBoxCommunication_Click);
            this.pictureBoxCommunication.MouseEnter += new System.EventHandler(this.pictureBoxCommunication_MouseEnter);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.menuStripSystem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(990, 27);
            this.panel3.TabIndex = 5;
            // 
            // menuStripSystem
            // 
            this.menuStripSystem.BackColor = System.Drawing.Color.SkyBlue;
            this.menuStripSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStripSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStripSystem.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripSystem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.setToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStripSystem.Location = new System.Drawing.Point(0, 0);
            this.menuStripSystem.Name = "menuStripSystem";
            this.menuStripSystem.Size = new System.Drawing.Size(986, 23);
            this.menuStripSystem.TabIndex = 6;
            this.menuStripSystem.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNew,
            this.ToolStripMenuItemDelet,
            this.ToolStripMenuItemQuit});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(39, 19);
            this.文件ToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItemNew
            // 
            this.toolStripMenuItemNew.Name = "toolStripMenuItemNew";
            this.toolStripMenuItemNew.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItemNew.Text = "New";
            this.toolStripMenuItemNew.Click += new System.EventHandler(this.toolStripMenuItemNew_Click);
            // 
            // ToolStripMenuItemDelet
            // 
            this.ToolStripMenuItemDelet.Name = "ToolStripMenuItemDelet";
            this.ToolStripMenuItemDelet.Size = new System.Drawing.Size(110, 22);
            this.ToolStripMenuItemDelet.Text = "Delete";
            this.ToolStripMenuItemDelet.Click += new System.EventHandler(this.ToolStripMenuItemDelet_Click);
            // 
            // ToolStripMenuItemQuit
            // 
            this.ToolStripMenuItemQuit.Name = "ToolStripMenuItemQuit";
            this.ToolStripMenuItemQuit.Size = new System.Drawing.Size(110, 22);
            this.ToolStripMenuItemQuit.Text = "Exit";
            this.ToolStripMenuItemQuit.Click += new System.EventHandler(this.ToolStripMenuItemQuit_Click);
            // 
            // setToolStripMenuItem
            // 
            this.setToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemCommunication,
            this.ToolStripMenuItemSystemset,
            this.ToolStripMenuItemExport,
            this.ToolStripMenuItemImport,
            this.toolStripMenuUserInfo,
            this.toolStripMenuItemRest});
            this.setToolStripMenuItem.Name = "setToolStripMenuItem";
            this.setToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.setToolStripMenuItem.Text = "Set";
            // 
            // ToolStripMenuItemCommunication
            // 
            this.ToolStripMenuItemCommunication.Name = "ToolStripMenuItemCommunication";
            this.ToolStripMenuItemCommunication.Size = new System.Drawing.Size(172, 22);
            this.ToolStripMenuItemCommunication.Text = "Communication";
            this.ToolStripMenuItemCommunication.Click += new System.EventHandler(this.ToolStripMenuItemCommunication_Click);
            // 
            // ToolStripMenuItemSystemset
            // 
            this.ToolStripMenuItemSystemset.Name = "ToolStripMenuItemSystemset";
            this.ToolStripMenuItemSystemset.Size = new System.Drawing.Size(172, 22);
            this.ToolStripMenuItemSystemset.Text = "SystemParameter";
            this.ToolStripMenuItemSystemset.Click += new System.EventHandler(this.ToolStripMenuItemSystemset_Click);
            // 
            // ToolStripMenuItemExport
            // 
            this.ToolStripMenuItemExport.Name = "ToolStripMenuItemExport";
            this.ToolStripMenuItemExport.Size = new System.Drawing.Size(172, 22);
            this.ToolStripMenuItemExport.Text = "Export";
            this.ToolStripMenuItemExport.Click += new System.EventHandler(this.ToolStripMenuItemExport_Click);
            // 
            // ToolStripMenuItemImport
            // 
            this.ToolStripMenuItemImport.Name = "ToolStripMenuItemImport";
            this.ToolStripMenuItemImport.Size = new System.Drawing.Size(172, 22);
            this.ToolStripMenuItemImport.Text = "Import";
            this.ToolStripMenuItemImport.Click += new System.EventHandler(this.ToolStripMenuItemImport_Click);
            // 
            // toolStripMenuUserInfo
            // 
            this.toolStripMenuUserInfo.Name = "toolStripMenuUserInfo";
            this.toolStripMenuUserInfo.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuUserInfo.Text = "UserInfo";
            this.toolStripMenuUserInfo.Click += new System.EventHandler(this.toolStripMenuUserInfo_Click);
            // 
            // toolStripMenuItemRest
            // 
            this.toolStripMenuItemRest.Name = "toolStripMenuItemRest";
            this.toolStripMenuItemRest.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItemRest.Text = "Reset";
            this.toolStripMenuItemRest.Click += new System.EventHandler(this.toolStripMenuItemRest_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAbout});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(45, 19);
            this.帮助ToolStripMenuItem.Text = "Help";
            // 
            // ToolStripMenuItemAbout
            // 
            this.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
            this.ToolStripMenuItemAbout.Size = new System.Drawing.Size(105, 22);
            this.ToolStripMenuItemAbout.Text = "About";
            this.ToolStripMenuItemAbout.Click += new System.EventHandler(this.ToolStripMenuItemAbout_Click);
            // 
            // RssTreeView
            // 
            this.RssTreeView.BackColor = System.Drawing.SystemColors.Window;
            this.RssTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.RssTreeView.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RssTreeView.ForeColor = System.Drawing.SystemColors.MenuText;
            this.RssTreeView.HideSelection = false;
            this.RssTreeView.HotTracking = true;
            this.RssTreeView.ImageIndex = 5;
            this.RssTreeView.ImageList = this.imageList;
            this.RssTreeView.ImeMode = System.Windows.Forms.ImeMode.On;
            this.RssTreeView.LineColor = System.Drawing.Color.Red;
            this.RssTreeView.Location = new System.Drawing.Point(0, 0);
            this.RssTreeView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.RssTreeView.MaximumSize = new System.Drawing.Size(135, 469);
            this.RssTreeView.MinimumSize = new System.Drawing.Size(135, 469);
            this.RssTreeView.Name = "RssTreeView";
            this.RssTreeView.SelectedImageIndex = 2;
            this.RssTreeView.Size = new System.Drawing.Size(135, 469);
            this.RssTreeView.TabIndex = 26;
            this.RssTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RssTreeView_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.MyPanel);
            this.panel2.Controls.Add(this.RssTreeView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(990, 458);
            this.panel2.TabIndex = 28;
            // 
            // MyPanel
            // 
            this.MyPanel.BackColor = System.Drawing.Color.White;
            this.MyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyPanel.Location = new System.Drawing.Point(135, 0);
            this.MyPanel.Name = "MyPanel";
            this.MyPanel.Size = new System.Drawing.Size(855, 458);
            this.MyPanel.TabIndex = 27;
            // 
            // mSkinEngine
            // 
            this.mSkinEngine.@__DrawButtonFocusRectangle = true;
            this.mSkinEngine.Active = false;
            this.mSkinEngine.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.mSkinEngine.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.mSkinEngine.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.mSkinEngine.SerialNumber = "";
            this.mSkinEngine.SkinDialogs = false;
            this.mSkinEngine.SkinFile = null;
            this.mSkinEngine.SkinScrollBar = false;
            // 
            // timerPollingInquiry
            // 
            this.timerPollingInquiry.Enabled = true;
            this.timerPollingInquiry.Interval = 3000;
            this.timerPollingInquiry.Tick += new System.EventHandler(this.timerPollingInquiry_Tick);
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(990, 560);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.mStatusStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximumSize = new System.Drawing.Size(996, 589);
            this.MinimumSize = new System.Drawing.Size(996, 589);
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Integrity Tester System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.CreateDevice.ResumeLayout(false);
            this.CreateEdit.ResumeLayout(false);
            this.mStatusStrip.ResumeLayout(false);
            this.mStatusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCommunication)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStripSystem.ResumeLayout(false);
            this.menuStripSystem.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip CreateDevice;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip CreateEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem ToolStartBuubblePointCheck;
        private System.Windows.Forms.ToolStripMenuItem toolFlowCheck;
        private System.Windows.Forms.ToolStripMenuItem toolHistoricalRecords;
        private System.Windows.Forms.ToolStripMenuItem toolSystemParameter;
        private System.Windows.Forms.ToolStripMenuItem toolUserInfo;
        private System.Windows.Forms.StatusStrip mStatusStrip;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem ManualBubbleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BasicBubbleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StrengthenTheBubbleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RateOfRiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DiffusionFlowCheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WaterImmersionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel MainToolStripStatusLabel;
        private System.Windows.Forms.Timer timerMainStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxHelp;
        private System.Windows.Forms.PictureBox pictureBoxImport;
        private System.Windows.Forms.PictureBox pictureBoxCommunication;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip menuStripSystem;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.TreeView RssTreeView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel MyPanel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNew;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelet;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemQuit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCommunication;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSystemset;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExport;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemImport;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAbout;
        private System.Windows.Forms.PictureBox pictureBoxExport;
        private System.Windows.Forms.Timer timerPollingInquiry;
        public Sunisoft.IrisSkin.SkinEngine mSkinEngine;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuUserInfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRest;
    }
}

