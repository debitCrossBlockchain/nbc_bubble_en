namespace SunManage.communication
{
    partial class Communication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Communication));
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonUSB = new System.Windows.Forms.RadioButton();
            this.radioButtonRS232 = new System.Windows.Forms.RadioButton();
            this.radioButtonIPV4 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MyPanel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonUSB);
            this.panel1.Controls.Add(this.radioButtonRS232);
            this.panel1.Controls.Add(this.radioButtonIPV4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 38);
            this.panel1.TabIndex = 15;
            // 
            // radioButtonUSB
            // 
            this.radioButtonUSB.AutoSize = true;
            this.radioButtonUSB.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonUSB.Location = new System.Drawing.Point(367, 8);
            this.radioButtonUSB.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonUSB.Name = "radioButtonUSB";
            this.radioButtonUSB.Size = new System.Drawing.Size(56, 22);
            this.radioButtonUSB.TabIndex = 3;
            this.radioButtonUSB.TabStop = true;
            this.radioButtonUSB.Text = "USB";
            this.radioButtonUSB.UseVisualStyleBackColor = true;
            this.radioButtonUSB.Click += new System.EventHandler(this.radioButtonUSB_Click);
            // 
            // radioButtonRS232
            // 
            this.radioButtonRS232.AutoSize = true;
            this.radioButtonRS232.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonRS232.Location = new System.Drawing.Point(248, 8);
            this.radioButtonRS232.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonRS232.Name = "radioButtonRS232";
            this.radioButtonRS232.Size = new System.Drawing.Size(74, 22);
            this.radioButtonRS232.TabIndex = 2;
            this.radioButtonRS232.TabStop = true;
            this.radioButtonRS232.Text = "RS232";
            this.radioButtonRS232.UseVisualStyleBackColor = true;
            this.radioButtonRS232.Click += new System.EventHandler(this.radioButtonRS232_Click);
            // 
            // radioButtonIPV4
            // 
            this.radioButtonIPV4.AutoSize = true;
            this.radioButtonIPV4.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonIPV4.Location = new System.Drawing.Point(124, 8);
            this.radioButtonIPV4.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonIPV4.Name = "radioButtonIPV4";
            this.radioButtonIPV4.Size = new System.Drawing.Size(101, 22);
            this.radioButtonIPV4.TabIndex = 1;
            this.radioButtonIPV4.TabStop = true;
            this.radioButtonIPV4.Text = "Ethernet";
            this.radioButtonIPV4.UseVisualStyleBackColor = true;
            this.radioButtonIPV4.Click += new System.EventHandler(this.radioButtonIPV4_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.MyPanel2);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(507, 390);
            this.panel2.TabIndex = 16;
            // 
            // MyPanel2
            // 
            this.MyPanel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.MyPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyPanel2.Location = new System.Drawing.Point(0, 38);
            this.MyPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.MyPanel2.Name = "MyPanel2";
            this.MyPanel2.Size = new System.Drawing.Size(507, 352);
            this.MyPanel2.TabIndex = 16;
            // 
            // Communication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 390);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Communication";
            this.Text = "Communication Set";
            this.Load += new System.EventHandler(this.Communication_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonUSB;
        private System.Windows.Forms.RadioButton radioButtonRS232;
        private System.Windows.Forms.RadioButton radioButtonIPV4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel MyPanel2;
    }
}