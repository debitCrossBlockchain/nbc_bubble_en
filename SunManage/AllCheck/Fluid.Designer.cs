namespace SunManage.AllCheck
{
    partial class Fluid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fluid));
            this.label1 = new System.Windows.Forms.Label();
            this.labelFalse = new System.Windows.Forms.Label();
            this.labelTrue = new System.Windows.Forms.Label();
            this.textBoxTest_Filter_LiquidName = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(106, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 18);
            this.label1.TabIndex = 56;
            this.label1.Text = "Please enter the Testing Liquid name:";
            // 
            // labelFalse
            // 
            this.labelFalse.AutoSize = true;
            this.labelFalse.BackColor = System.Drawing.Color.Transparent;
            this.labelFalse.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelFalse.ForeColor = System.Drawing.Color.White;
            this.labelFalse.Location = new System.Drawing.Point(385, 186);
            this.labelFalse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFalse.Name = "labelFalse";
            this.labelFalse.Size = new System.Drawing.Size(62, 18);
            this.labelFalse.TabIndex = 55;
            this.labelFalse.Text = "Cancel";
            this.labelFalse.Click += new System.EventHandler(this.labelFalse_Click);
            // 
            // labelTrue
            // 
            this.labelTrue.AutoSize = true;
            this.labelTrue.BackColor = System.Drawing.Color.Transparent;
            this.labelTrue.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTrue.ForeColor = System.Drawing.Color.White;
            this.labelTrue.Location = new System.Drawing.Point(260, 186);
            this.labelTrue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTrue.Name = "labelTrue";
            this.labelTrue.Size = new System.Drawing.Size(71, 18);
            this.labelTrue.TabIndex = 54;
            this.labelTrue.Text = "Confirm";
            this.labelTrue.Click += new System.EventHandler(this.labelTrue_Click);
            // 
            // textBoxTest_Filter_LiquidName
            // 
            this.textBoxTest_Filter_LiquidName.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTest_Filter_LiquidName.Location = new System.Drawing.Point(135, 100);
            this.textBoxTest_Filter_LiquidName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxTest_Filter_LiquidName.Name = "textBoxTest_Filter_LiquidName";
            this.textBoxTest_Filter_LiquidName.Size = new System.Drawing.Size(260, 27);
            this.textBoxTest_Filter_LiquidName.TabIndex = 52;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(52, 104);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(62, 18);
            this.label35.TabIndex = 51;
            this.label35.Text = "Name:";
            // 
            // Fluid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SunManage.Properties.Resources.Test_Config;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(513, 274);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelFalse);
            this.Controls.Add(this.labelTrue);
            this.Controls.Add(this.textBoxTest_Filter_LiquidName);
            this.Controls.Add(this.label35);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Fluid";
            this.Text = "Fluid";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Fluid_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Fluid_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Fluid_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelFalse;
        private System.Windows.Forms.Label labelTrue;
        private System.Windows.Forms.TextBox textBoxTest_Filter_LiquidName;
        private System.Windows.Forms.Label label35;
    }
}