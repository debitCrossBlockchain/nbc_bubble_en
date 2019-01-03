namespace SunManage.communication
{
    partial class Export
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Export));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewExportInfo = new System.Windows.Forms.DataGridView();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonExportRefresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveFileDialogExport = new System.Windows.Forms.SaveFileDialog();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExportInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewExportInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1424, 491);
            this.panel2.TabIndex = 3;
            // 
            // dataGridViewExportInfo
            // 
            this.dataGridViewExportInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewExportInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExportInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewExportInfo.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewExportInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewExportInfo.Name = "dataGridViewExportInfo";
            this.dataGridViewExportInfo.RowTemplate.Height = 23;
            this.dataGridViewExportInfo.Size = new System.Drawing.Size(1424, 491);
            this.dataGridViewExportInfo.TabIndex = 0;
            // 
            // buttonExport
            // 
            this.buttonExport.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExport.Location = new System.Drawing.Point(191, 9);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(124, 30);
            this.buttonExport.TabIndex = 1;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonExportRefresh
            // 
            this.buttonExportRefresh.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExportRefresh.Location = new System.Drawing.Point(4, 9);
            this.buttonExportRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExportRefresh.Name = "buttonExportRefresh";
            this.buttonExportRefresh.Size = new System.Drawing.Size(124, 30);
            this.buttonExportRefresh.TabIndex = 0;
            this.buttonExportRefresh.Text = "Refresh";
            this.buttonExportRefresh.UseVisualStyleBackColor = true;
            this.buttonExportRefresh.Click += new System.EventHandler(this.buttonExportRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonExport);
            this.panel1.Controls.Add(this.buttonExportRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 491);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1424, 48);
            this.panel1.TabIndex = 2;
            // 
            // Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 539);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Export";
            this.Text = "Export";
            this.Load += new System.EventHandler(this.Export_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExportInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewExportInfo;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonExportRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExport;
    }
}