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
            this.imageListInfo = new System.Windows.Forms.ImageList(this.components);
            this.timerInfo = new System.Windows.Forms.Timer(this.components);
            this.openFileDialogtxt = new System.Windows.Forms.OpenFileDialog();
            this.buttonLoadSQL = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            // timerInfo
            // 
        
            // 
            // openFileDialogtxt
            // 
            this.openFileDialogtxt.FileName = "openFileDialogtxt";
            this.openFileDialogtxt.Multiselect = true;
            // 
            // buttonLoadSQL
            // 
            this.buttonLoadSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadSQL.Location = new System.Drawing.Point(33, 10);
            this.buttonLoadSQL.Name = "buttonLoadSQL";
            this.buttonLoadSQL.Size = new System.Drawing.Size(213, 27);
            this.buttonLoadSQL.TabIndex = 2;
            this.buttonLoadSQL.Text = "Open and Import";
            this.buttonLoadSQL.UseVisualStyleBackColor = true;
            this.buttonLoadSQL.Click += new System.EventHandler(this.buttonLoadSQL_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonLoadSQL);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 42);
            this.panel2.TabIndex = 4;
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 44);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Import";
            this.Text = "Import";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerInfo;
        private System.Windows.Forms.ImageList imageListInfo;
        private System.Windows.Forms.OpenFileDialog openFileDialogtxt;
        private System.Windows.Forms.Button buttonLoadSQL;
        private System.Windows.Forms.Panel panel2;
    }
}