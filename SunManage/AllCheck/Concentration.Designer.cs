namespace SunManage.AllCheck
{
    partial class Concentration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Concentration));
            this.labelFalse = new System.Windows.Forms.Label();
            this.labelTrue = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxTest_Filter_Concentration = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelFalse
            // 
            this.labelFalse.AutoSize = true;
            this.labelFalse.BackColor = System.Drawing.Color.Transparent;
            this.labelFalse.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelFalse.ForeColor = System.Drawing.Color.Transparent;
            this.labelFalse.Location = new System.Drawing.Point(364, 212);
            this.labelFalse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFalse.Name = "labelFalse";
            this.labelFalse.Size = new System.Drawing.Size(62, 18);
            this.labelFalse.TabIndex = 49;
            this.labelFalse.Text = "Cancel";
            this.labelFalse.Click += new System.EventHandler(this.labelFalse_Click);
            // 
            // labelTrue
            // 
            this.labelTrue.AutoSize = true;
            this.labelTrue.BackColor = System.Drawing.Color.Transparent;
            this.labelTrue.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTrue.ForeColor = System.Drawing.Color.Transparent;
            this.labelTrue.Location = new System.Drawing.Point(239, 212);
            this.labelTrue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTrue.Name = "labelTrue";
            this.labelTrue.Size = new System.Drawing.Size(71, 18);
            this.labelTrue.TabIndex = 48;
            this.labelTrue.Text = "Confirm";
            this.labelTrue.Click += new System.EventHandler(this.labelTrue_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(369, 130);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 18);
            this.label8.TabIndex = 47;
            this.label8.Text = "%";
            // 
            // textBoxTest_Filter_Concentration
            // 
            this.textBoxTest_Filter_Concentration.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTest_Filter_Concentration.Location = new System.Drawing.Point(154, 126);
            this.textBoxTest_Filter_Concentration.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTest_Filter_Concentration.Name = "textBoxTest_Filter_Concentration";
            this.textBoxTest_Filter_Concentration.Size = new System.Drawing.Size(195, 27);
            this.textBoxTest_Filter_Concentration.TabIndex = 46;
            this.textBoxTest_Filter_Concentration.Text = "10";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(20, 129);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(143, 18);
            this.label35.TabIndex = 45;
            this.label35.Text = "Concentration:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(20, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 18);
            this.label1.TabIndex = 50;
            this.label1.Text = "Please enter the Testing Liquid concentration:";
            // 
            // Concentration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SunManage.Properties.Resources.Test_Config;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(464, 311);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelFalse);
            this.Controls.Add(this.labelTrue);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxTest_Filter_Concentration);
            this.Controls.Add(this.label35);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Concentration";
            this.Text = "Concentration";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Concentration_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Concentration_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Concentration_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFalse;
        private System.Windows.Forms.Label labelTrue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxTest_Filter_Concentration;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label1;
    }
}