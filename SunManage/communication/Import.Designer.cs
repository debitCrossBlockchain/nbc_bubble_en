namespace SunManage.communication
{
    partial class Import
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Import));
            this.listBoxInfo = new System.Windows.Forms.ListBox();
            this.treeViewInfo = new System.Windows.Forms.TreeView();
            this.imageListInfo = new System.Windows.Forms.ImageList(this.components);
            this.listViewInfo = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonLoadSQL = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.timerInfo = new System.Windows.Forms.Timer(this.components);
            this.openFileDialogtxt = new System.Windows.Forms.OpenFileDialog();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxInfo
            // 
            this.listBoxInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxInfo.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxInfo.FormattingEnabled = true;
            this.listBoxInfo.ItemHeight = 17;
            this.listBoxInfo.Location = new System.Drawing.Point(0, 0);
            this.listBoxInfo.Name = "listBoxInfo";
            this.listBoxInfo.Size = new System.Drawing.Size(836, 123);
            this.listBoxInfo.TabIndex = 0;
            // 
            // treeViewInfo
            // 
            this.treeViewInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewInfo.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeViewInfo.ImageIndex = 0;
            this.treeViewInfo.ImageList = this.imageListInfo;
            this.treeViewInfo.Location = new System.Drawing.Point(0, 0);
            this.treeViewInfo.Name = "treeViewInfo";
            this.treeViewInfo.SelectedImageIndex = 0;
            this.treeViewInfo.Size = new System.Drawing.Size(247, 394);
            this.treeViewInfo.TabIndex = 1;
            this.treeViewInfo.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewInfo_AfterSelect);
            // 
            // imageListInfo
            // 
            this.imageListInfo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListInfo.ImageStream")));
            this.imageListInfo.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListInfo.Images.SetKeyName(0, "word.png");
            this.imageListInfo.Images.SetKeyName(1, "usb.png");
            this.imageListInfo.Images.SetKeyName(2, "container.png");
            this.imageListInfo.Images.SetKeyName(3, "pic.png");
            this.imageListInfo.Images.SetKeyName(4, "pdf.png");
            this.imageListInfo.Images.SetKeyName(5, "so.jpg");
            // 
            // listViewInfo
            // 
            this.listViewInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewInfo.LargeImageList = this.imageListInfo;
            this.listViewInfo.Location = new System.Drawing.Point(0, 0);
            this.listViewInfo.Name = "listViewInfo";
            this.listViewInfo.Size = new System.Drawing.Size(585, 394);
            this.listViewInfo.TabIndex = 2;
            this.listViewInfo.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(836, 14);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonLoadSQL);
            this.panel2.Controls.Add(this.buttonImport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 535);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(836, 42);
            this.panel2.TabIndex = 4;
            // 
            // buttonLoadSQL
            // 
            this.buttonLoadSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadSQL.Location = new System.Drawing.Point(141, 7);
            this.buttonLoadSQL.Name = "buttonLoadSQL";
            this.buttonLoadSQL.Size = new System.Drawing.Size(213, 27);
            this.buttonLoadSQL.TabIndex = 2;
            this.buttonLoadSQL.Text = "Open and Import";
            this.buttonLoadSQL.UseVisualStyleBackColor = true;
            this.buttonLoadSQL.Click += new System.EventHandler(this.buttonLoadSQL_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImport.Location = new System.Drawing.Point(14, 7);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(84, 27);
            this.buttonImport.TabIndex = 1;
            this.buttonImport.Text = "Start Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.treeViewInfo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel3.Location = new System.Drawing.Point(0, 137);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(836, 398);
            this.panel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.listViewInfo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(247, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(585, 394);
            this.panel4.TabIndex = 2;
            // 
            // timerInfo
            // 
            this.timerInfo.Interval = 3000;
            this.timerInfo.Tick += new System.EventHandler(this.timerInfo_Tick);
            // 
            // openFileDialogtxt
            // 
            this.openFileDialogtxt.FileName = "openFileDialogtxt";
            this.openFileDialogtxt.Multiselect = true;
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 577);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBoxInfo);
            this.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Import";
            this.Text = "Import";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxInfo;
        private System.Windows.Forms.TreeView treeViewInfo;
        private System.Windows.Forms.ListView listViewInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Timer timerInfo;
        private System.Windows.Forms.ImageList imageListInfo;
        private System.Windows.Forms.Button buttonLoadSQL;
        private System.Windows.Forms.OpenFileDialog openFileDialogtxt;
    }
}