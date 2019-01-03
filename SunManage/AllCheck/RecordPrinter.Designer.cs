namespace SunManage.AllCheck
{
    partial class RecordPrinter
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordPrinter));
            this.mSkinEngineRecordPrinter = new Sunisoft.IrisSkin.SkinEngine();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // mSkinEngineRecordPrinter
            // 
            this.mSkinEngineRecordPrinter.@__DrawButtonFocusRectangle = true;
            this.mSkinEngineRecordPrinter.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.mSkinEngineRecordPrinter.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.mSkinEngineRecordPrinter.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.mSkinEngineRecordPrinter.SerialNumber = "";
            this.mSkinEngineRecordPrinter.SkinDialogs = false;
            this.mSkinEngineRecordPrinter.SkinFile = null;
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet";
            reportDataSource1.Value = null;
            reportDataSource2.Name = "DataSetCoords";
            reportDataSource2.Value = null;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "SunManage.AllCheck.ReportReportViewer.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ShowZoomControl = false;
            this.reportViewer.Size = new System.Drawing.Size(1343, 759);
            this.reportViewer.TabIndex = 1;
            // 
            // RecordPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 759);
            this.Controls.Add(this.reportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RecordPrinter";
            this.Text = "Historical Records Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RecordPrinter_FormClosed);
            this.Load += new System.EventHandler(this.RecordPrinter_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine mSkinEngineRecordPrinter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
       
    }
}