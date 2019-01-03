namespace SunManage.communication
{
    partial class USB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USB));
            this.label1 = new System.Windows.Forms.Label();
            this.VIDTb = new System.Windows.Forms.TextBox();
            this.PIDTb = new System.Windows.Forms.TextBox();
            this.Lab = new System.Windows.Forms.Label();
            this.CloseB = new System.Windows.Forms.Button();
            this.open = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(163, 115);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 30);
            this.label1.TabIndex = 20;
            this.label1.Text = "VID:";
            // 
            // VIDTb
            // 
            this.VIDTb.Location = new System.Drawing.Point(243, 115);
            this.VIDTb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VIDTb.Name = "VIDTb";
            this.VIDTb.Size = new System.Drawing.Size(111, 25);
            this.VIDTb.TabIndex = 19;
            this.VIDTb.Text = "04D8";
            // 
            // PIDTb
            // 
            this.PIDTb.Location = new System.Drawing.Point(243, 40);
            this.PIDTb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PIDTb.Name = "PIDTb";
            this.PIDTb.Size = new System.Drawing.Size(111, 25);
            this.PIDTb.TabIndex = 18;
            this.PIDTb.Text = "0078";
            // 
            // Lab
            // 
            this.Lab.Location = new System.Drawing.Point(165, 44);
            this.Lab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lab.Name = "Lab";
            this.Lab.Size = new System.Drawing.Size(57, 30);
            this.Lab.TabIndex = 17;
            this.Lab.Text = "PID:";
            // 
            // CloseB
            // 
            this.CloseB.Location = new System.Drawing.Point(360, 251);
            this.CloseB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CloseB.Name = "CloseB";
            this.CloseB.Size = new System.Drawing.Size(104, 39);
            this.CloseB.TabIndex = 16;
            this.CloseB.Text = "Close";
            this.CloseB.UseVisualStyleBackColor = true;
            this.CloseB.Click += new System.EventHandler(this.CloseB_Click);
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(91, 251);
            this.open.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(104, 39);
            this.open.TabIndex = 15;
            this.open.Text = "Open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // USB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(556, 331);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VIDTb);
            this.Controls.Add(this.PIDTb);
            this.Controls.Add(this.Lab);
            this.Controls.Add(this.CloseB);
            this.Controls.Add(this.open);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "USB";
            this.Text = "USB";
            this.Load += new System.EventHandler(this.USB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox VIDTb;
        private System.Windows.Forms.TextBox PIDTb;
        private System.Windows.Forms.Label Lab;
        private System.Windows.Forms.Button CloseB;
        private System.Windows.Forms.Button open;

    }
}