namespace SunManage.AllCheck
{
    partial class DfTestMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DfTestMode));
            this.m_lable_cancle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnMicrofil = new System.Windows.Forms.Button();
            this.m_btnUltrafil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_lable_cancle
            // 
            this.m_lable_cancle.BackColor = System.Drawing.Color.Transparent;
            this.m_lable_cancle.Image = ((System.Drawing.Image)(resources.GetObject("m_lable_cancle.Image")));
            this.m_lable_cancle.Location = new System.Drawing.Point(898, 427);
            this.m_lable_cancle.Name = "m_lable_cancle";
            this.m_lable_cancle.Size = new System.Drawing.Size(196, 97);
            this.m_lable_cancle.TabIndex = 0;
            this.m_lable_cancle.Click += new System.EventHandler(this.m_lable_cancle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(407, 193);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 24);
            this.label1.TabIndex = 51;
            this.label1.Text = "Please select test mode:";
            // 
            // m_btnMicrofil
            // 
            this.m_btnMicrofil.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_btnMicrofil.Location = new System.Drawing.Point(381, 248);
            this.m_btnMicrofil.Name = "m_btnMicrofil";
            this.m_btnMicrofil.Size = new System.Drawing.Size(147, 116);
            this.m_btnMicrofil.TabIndex = 52;
            this.m_btnMicrofil.Text = "Microfil";
            this.m_btnMicrofil.UseVisualStyleBackColor = false;
            this.m_btnMicrofil.Click += new System.EventHandler(this.m_btnMicrofil_Click);
            // 
            // m_btnUltrafil
            // 
            this.m_btnUltrafil.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_btnUltrafil.Location = new System.Drawing.Point(583, 248);
            this.m_btnUltrafil.Name = "m_btnUltrafil";
            this.m_btnUltrafil.Size = new System.Drawing.Size(147, 116);
            this.m_btnUltrafil.TabIndex = 53;
            this.m_btnUltrafil.Text = "Ultrafil";
            this.m_btnUltrafil.UseVisualStyleBackColor = false;
            this.m_btnUltrafil.Click += new System.EventHandler(this.m_btnUltrafil_Click);
            // 
            // DfTestMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1405, 580);
            this.Controls.Add(this.m_btnUltrafil);
            this.Controls.Add(this.m_btnMicrofil);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_lable_cancle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DfTestMode";
            this.Text = "DfTestMode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_lable_cancle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button m_btnMicrofil;
        private System.Windows.Forms.Button m_btnUltrafil;
    }
}