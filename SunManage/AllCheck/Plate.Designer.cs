namespace SunManage.AllCheck
{
    partial class Plate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plate));
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxTest_Filter_Diameter = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.labelFalse = new System.Windows.Forms.Label();
            this.labelTrue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(363, 80);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 18);
            this.label8.TabIndex = 42;
            this.label8.Text = "mm";
            // 
            // textBoxTest_Filter_Diameter
            // 
            this.textBoxTest_Filter_Diameter.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxTest_Filter_Diameter.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTest_Filter_Diameter.Location = new System.Drawing.Point(118, 76);
            this.textBoxTest_Filter_Diameter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxTest_Filter_Diameter.Name = "textBoxTest_Filter_Diameter";
            this.textBoxTest_Filter_Diameter.Size = new System.Drawing.Size(236, 27);
            this.textBoxTest_Filter_Diameter.TabIndex = 41;
            this.textBoxTest_Filter_Diameter.Text = "10";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(31, 79);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(98, 18);
            this.label35.TabIndex = 40;
            this.label35.Text = "Diameter:";
            // 
            // labelFalse
            // 
            this.labelFalse.AutoSize = true;
            this.labelFalse.BackColor = System.Drawing.Color.Transparent;
            this.labelFalse.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelFalse.ForeColor = System.Drawing.Color.White;
            this.labelFalse.Location = new System.Drawing.Point(355, 161);
            this.labelFalse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFalse.Name = "labelFalse";
            this.labelFalse.Size = new System.Drawing.Size(62, 18);
            this.labelFalse.TabIndex = 44;
            this.labelFalse.Text = "Cancel";
            this.labelFalse.Click += new System.EventHandler(this.labelFalse_Click);
            // 
            // labelTrue
            // 
            this.labelTrue.AutoSize = true;
            this.labelTrue.BackColor = System.Drawing.Color.Transparent;
            this.labelTrue.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTrue.ForeColor = System.Drawing.Color.White;
            this.labelTrue.Location = new System.Drawing.Point(229, 161);
            this.labelTrue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTrue.Name = "labelTrue";
            this.labelTrue.Size = new System.Drawing.Size(71, 18);
            this.labelTrue.TabIndex = 43;
            this.labelTrue.Text = "Confirm";
            this.labelTrue.Click += new System.EventHandler(this.labelTrue_Click);
            // 
            // Plate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SunManage.Properties.Resources.Test_Config;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(457, 270);
            this.Controls.Add(this.labelFalse);
            this.Controls.Add(this.labelTrue);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxTest_Filter_Diameter);
            this.Controls.Add(this.label35);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Plate";
            this.Text = "Plate";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Plate_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Plate_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Plate_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxTest_Filter_Diameter;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label labelFalse;
        private System.Windows.Forms.Label labelTrue;
    }
}