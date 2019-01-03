namespace SunManage.communication
{
    partial class CommunicationConnect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommunicationConnect));
            this.label1 = new System.Windows.Forms.Label();
            this.DeviceName = new System.Windows.Forms.TextBox();
            this.ConfirmTheConnected = new System.Windows.Forms.Button();
            this.CCancer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxDeviceAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(36, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Device Name:";
            // 
            // DeviceName
            // 
            this.DeviceName.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DeviceName.Location = new System.Drawing.Point(151, 15);
            this.DeviceName.Margin = new System.Windows.Forms.Padding(4);
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.Size = new System.Drawing.Size(285, 27);
            this.DeviceName.TabIndex = 1;
            // 
            // ConfirmTheConnected
            // 
            this.ConfirmTheConnected.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfirmTheConnected.Location = new System.Drawing.Point(29, 119);
            this.ConfirmTheConnected.Margin = new System.Windows.Forms.Padding(4);
            this.ConfirmTheConnected.Name = "ConfirmTheConnected";
            this.ConfirmTheConnected.Size = new System.Drawing.Size(107, 34);
            this.ConfirmTheConnected.TabIndex = 6;
            this.ConfirmTheConnected.Text = "Confirm";
            this.ConfirmTheConnected.UseVisualStyleBackColor = true;
            this.ConfirmTheConnected.Click += new System.EventHandler(this.ConfirmTheConnected_Click);
            // 
            // CCancer
            // 
            this.CCancer.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CCancer.Location = new System.Drawing.Point(301, 119);
            this.CCancer.Margin = new System.Windows.Forms.Padding(4);
            this.CCancer.Name = "CCancer";
            this.CCancer.Size = new System.Drawing.Size(107, 34);
            this.CCancer.TabIndex = 7;
            this.CCancer.Text = "Cancel";
            this.CCancer.UseVisualStyleBackColor = true;
            this.CCancer.Click += new System.EventHandler(this.CCancer_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ConfirmTheConnected);
            this.panel1.Controls.Add(this.textBoxDeviceAddress);
            this.panel1.Controls.Add(this.CCancer);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.DeviceName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 165);
            this.panel1.TabIndex = 9;
            // 
            // textBoxDeviceAddress
            // 
            this.textBoxDeviceAddress.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxDeviceAddress.Location = new System.Drawing.Point(151, 52);
            this.textBoxDeviceAddress.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDeviceAddress.Name = "textBoxDeviceAddress";
            this.textBoxDeviceAddress.Size = new System.Drawing.Size(285, 27);
            this.textBoxDeviceAddress.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(45, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Device NO.:";
            // 
            // CommunicationConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 168);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CommunicationConnect";
            this.Text = "New Device";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DeviceName;
        private System.Windows.Forms.Button ConfirmTheConnected;
        private System.Windows.Forms.Button CCancer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDeviceAddress;
    }
}