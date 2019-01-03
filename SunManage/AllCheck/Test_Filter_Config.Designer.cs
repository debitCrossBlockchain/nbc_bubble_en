namespace SunManage.AllCheck
{
    partial class Test_Filter_Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Test_Filter_Config));
            this.label1 = new System.Windows.Forms.Label();
            this.labelCartridge = new System.Windows.Forms.Label();
            this.labelFlat = new System.Windows.Forms.Label();
            this.labelPurse = new System.Windows.Forms.Label();
            this.labelOther = new System.Windows.Forms.Label();
            this.labelCancel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(108, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please select filter type:";
            // 
            // labelCartridge
            // 
            this.labelCartridge.AutoSize = true;
            this.labelCartridge.BackColor = System.Drawing.Color.Transparent;
            this.labelCartridge.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCartridge.ForeColor = System.Drawing.Color.Transparent;
            this.labelCartridge.Location = new System.Drawing.Point(76, 99);
            this.labelCartridge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCartridge.Name = "labelCartridge";
            this.labelCartridge.Size = new System.Drawing.Size(163, 30);
            this.labelCartridge.TabIndex = 1;
            this.labelCartridge.Text = "Cartridge ";
            this.labelCartridge.Click += new System.EventHandler(this.labelCartridge_Click);
            // 
            // labelFlat
            // 
            this.labelFlat.AutoSize = true;
            this.labelFlat.BackColor = System.Drawing.Color.Transparent;
            this.labelFlat.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelFlat.ForeColor = System.Drawing.Color.Transparent;
            this.labelFlat.Location = new System.Drawing.Point(233, 99);
            this.labelFlat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFlat.Name = "labelFlat";
            this.labelFlat.Size = new System.Drawing.Size(103, 30);
            this.labelFlat.TabIndex = 2;
            this.labelFlat.Text = "Pannel";
            this.labelFlat.Click += new System.EventHandler(this.labelFlat_Click);
            // 
            // labelPurse
            // 
            this.labelPurse.AutoSize = true;
            this.labelPurse.BackColor = System.Drawing.Color.Transparent;
            this.labelPurse.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPurse.ForeColor = System.Drawing.Color.Transparent;
            this.labelPurse.Location = new System.Drawing.Point(107, 160);
            this.labelPurse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPurse.Name = "labelPurse";
            this.labelPurse.Size = new System.Drawing.Size(58, 30);
            this.labelPurse.TabIndex = 3;
            this.labelPurse.Text = "Bag";
            this.labelPurse.Click += new System.EventHandler(this.labelPurse_Click);
            // 
            // labelOther
            // 
            this.labelOther.AutoSize = true;
            this.labelOther.BackColor = System.Drawing.Color.Transparent;
            this.labelOther.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelOther.ForeColor = System.Drawing.Color.Transparent;
            this.labelOther.Location = new System.Drawing.Point(233, 160);
            this.labelOther.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOther.Name = "labelOther";
            this.labelOther.Size = new System.Drawing.Size(88, 30);
            this.labelOther.TabIndex = 4;
            this.labelOther.Text = "Other";
            this.labelOther.Click += new System.EventHandler(this.labelOther_Click);
            // 
            // labelCancel
            // 
            this.labelCancel.AutoSize = true;
            this.labelCancel.BackColor = System.Drawing.Color.Transparent;
            this.labelCancel.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCancel.ForeColor = System.Drawing.Color.Transparent;
            this.labelCancel.Location = new System.Drawing.Point(341, 218);
            this.labelCancel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCancel.Name = "labelCancel";
            this.labelCancel.Size = new System.Drawing.Size(82, 24);
            this.labelCancel.TabIndex = 5;
            this.labelCancel.Text = "Cancel";
            this.labelCancel.Click += new System.EventHandler(this.labelCancel_Click);
            // 
            // Test_Filter_Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SunManage.Properties.Resources.Test_Config;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(455, 276);
            this.Controls.Add(this.labelCancel);
            this.Controls.Add(this.labelOther);
            this.Controls.Add(this.labelPurse);
            this.Controls.Add(this.labelFlat);
            this.Controls.Add(this.labelCartridge);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Test_Filter_Config";
            this.ShowIcon = false;
            this.Text = "Test_Filter_Config";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Test_Filter_Config_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Test_Filter_Config_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Test_Filter_Config_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCartridge;
        private System.Windows.Forms.Label labelFlat;
        private System.Windows.Forms.Label labelPurse;
        private System.Windows.Forms.Label labelOther;
        private System.Windows.Forms.Label labelCancel;
    }
}