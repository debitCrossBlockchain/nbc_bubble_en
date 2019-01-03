namespace SunManage.AllCheck
{
    partial class HistoricalRecords
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePickerDTime = new System.Windows.Forms.DateTimePicker();
            this.btHTime = new System.Windows.Forms.Button();
            this.buttonHistoricalPrint = new System.Windows.Forms.Button();
            this.buttonSearchALLHis = new System.Windows.Forms.Button();
            this.dataGridViewHistorical = new System.Windows.Forms.DataGridView();
            this.buttonHistoricalClear = new System.Windows.Forms.Button();
            this.buttonHistoricalAdd = new System.Windows.Forms.Button();
            this.buttonHistoricalEdit = new System.Windows.Forms.Button();
            this.buttonHistoricalDelete = new System.Windows.Forms.Button();
            this.buttonWrite = new System.Windows.Forms.Button();
            this.buttonRead = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorical)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1405, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data List";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonWrite);
            this.panel1.Controls.Add(this.buttonRead);
            this.panel1.Controls.Add(this.dateTimePickerDTime);
            this.panel1.Controls.Add(this.buttonHistoricalClear);
            this.panel1.Controls.Add(this.buttonHistoricalDelete);
            this.panel1.Controls.Add(this.buttonHistoricalEdit);
            this.panel1.Controls.Add(this.buttonHistoricalAdd);
            this.panel1.Controls.Add(this.btHTime);
            this.panel1.Controls.Add(this.buttonHistoricalPrint);
            this.panel1.Controls.Add(this.buttonSearchALLHis);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 430);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1405, 50);
            this.panel1.TabIndex = 2;
            // 
            // dateTimePickerDTime
            // 
            this.dateTimePickerDTime.CustomFormat = " yyyy-mm-dd hh:mm";
            this.dateTimePickerDTime.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePickerDTime.Location = new System.Drawing.Point(164, 6);
            this.dateTimePickerDTime.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerDTime.Name = "dateTimePickerDTime";
            this.dateTimePickerDTime.Size = new System.Drawing.Size(153, 27);
            this.dateTimePickerDTime.TabIndex = 9;
            this.dateTimePickerDTime.Value = new System.DateTime(2014, 1, 8, 15, 45, 0, 0);
            // 
            // btHTime
            // 
            this.btHTime.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btHTime.Location = new System.Drawing.Point(4, 7);
            this.btHTime.Margin = new System.Windows.Forms.Padding(4);
            this.btHTime.Name = "btHTime";
            this.btHTime.Size = new System.Drawing.Size(141, 29);
            this.btHTime.TabIndex = 2;
            this.btHTime.Text = "Query by time";
            this.btHTime.UseVisualStyleBackColor = true;
            this.btHTime.Click += new System.EventHandler(this.btHTime_Click);
            // 
            // buttonHistoricalPrint
            // 
            this.buttonHistoricalPrint.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonHistoricalPrint.Location = new System.Drawing.Point(434, 6);
            this.buttonHistoricalPrint.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHistoricalPrint.Name = "buttonHistoricalPrint";
            this.buttonHistoricalPrint.Size = new System.Drawing.Size(75, 27);
            this.buttonHistoricalPrint.TabIndex = 1;
            this.buttonHistoricalPrint.Text = "Print";
            this.buttonHistoricalPrint.UseVisualStyleBackColor = true;
            this.buttonHistoricalPrint.Click += new System.EventHandler(this.buttonHistoricalPrint_Click);
            // 
            // buttonSearchALLHis
            // 
            this.buttonSearchALLHis.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSearchALLHis.Location = new System.Drawing.Point(340, 6);
            this.buttonSearchALLHis.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSearchALLHis.Name = "buttonSearchALLHis";
            this.buttonSearchALLHis.Size = new System.Drawing.Size(75, 27);
            this.buttonSearchALLHis.TabIndex = 0;
            this.buttonSearchALLHis.Text = "Refresh";
            this.buttonSearchALLHis.UseVisualStyleBackColor = true;
            this.buttonSearchALLHis.Click += new System.EventHandler(this.buttonSearchALLHis_Click);
            // 
            // dataGridViewHistorical
            // 
            this.dataGridViewHistorical.AllowUserToOrderColumns = true;
            this.dataGridViewHistorical.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHistorical.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewHistorical.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewHistorical.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistorical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewHistorical.Location = new System.Drawing.Point(0, 41);
            this.dataGridViewHistorical.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewHistorical.Name = "dataGridViewHistorical";
            this.dataGridViewHistorical.RowTemplate.Height = 23;
            this.dataGridViewHistorical.Size = new System.Drawing.Size(1405, 389);
            this.dataGridViewHistorical.TabIndex = 3;
            this.dataGridViewHistorical.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHistorical_CellDoubleClick);
            // 
            // buttonHistoricalClear
            // 
            this.buttonHistoricalClear.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonHistoricalClear.Location = new System.Drawing.Point(528, 6);
            this.buttonHistoricalClear.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHistoricalClear.Name = "buttonHistoricalClear";
            this.buttonHistoricalClear.Size = new System.Drawing.Size(75, 27);
            this.buttonHistoricalClear.TabIndex = 7;
            this.buttonHistoricalClear.Text = "Clear";
            this.buttonHistoricalClear.UseVisualStyleBackColor = true;
            this.buttonHistoricalClear.Click += new System.EventHandler(this.buttonHistoricalClear_Click);
            // 
            // buttonHistoricalAdd
            // 
            this.buttonHistoricalAdd.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonHistoricalAdd.Location = new System.Drawing.Point(904, 6);
            this.buttonHistoricalAdd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHistoricalAdd.Name = "buttonHistoricalAdd";
            this.buttonHistoricalAdd.Size = new System.Drawing.Size(75, 27);
            this.buttonHistoricalAdd.TabIndex = 4;
            this.buttonHistoricalAdd.Text = "Add";
            this.buttonHistoricalAdd.UseVisualStyleBackColor = true;
            this.buttonHistoricalAdd.Visible = false;
            this.buttonHistoricalAdd.Click += new System.EventHandler(this.buttonHistoricalAdd_Click);
            // 
            // buttonHistoricalEdit
            // 
            this.buttonHistoricalEdit.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonHistoricalEdit.Location = new System.Drawing.Point(998, 6);
            this.buttonHistoricalEdit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHistoricalEdit.Name = "buttonHistoricalEdit";
            this.buttonHistoricalEdit.Size = new System.Drawing.Size(75, 27);
            this.buttonHistoricalEdit.TabIndex = 5;
            this.buttonHistoricalEdit.Text = "Edit";
            this.buttonHistoricalEdit.UseVisualStyleBackColor = true;
            this.buttonHistoricalEdit.Visible = false;
            this.buttonHistoricalEdit.Click += new System.EventHandler(this.buttonHistoricalEdit_Click);
            // 
            // buttonHistoricalDelete
            // 
            this.buttonHistoricalDelete.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonHistoricalDelete.Location = new System.Drawing.Point(810, 6);
            this.buttonHistoricalDelete.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHistoricalDelete.Name = "buttonHistoricalDelete";
            this.buttonHistoricalDelete.Size = new System.Drawing.Size(75, 27);
            this.buttonHistoricalDelete.TabIndex = 6;
            this.buttonHistoricalDelete.Text = "Delete";
            this.buttonHistoricalDelete.UseVisualStyleBackColor = true;
            this.buttonHistoricalDelete.Click += new System.EventHandler(this.buttonHistoricalDelete_Click);
            // 
            // buttonWrite
            // 
            this.buttonWrite.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonWrite.Location = new System.Drawing.Point(716, 6);
            this.buttonWrite.Margin = new System.Windows.Forms.Padding(4);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(75, 27);
            this.buttonWrite.TabIndex = 11;
            this.buttonWrite.Text = "Write";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRead.Location = new System.Drawing.Point(622, 6);
            this.buttonRead.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(75, 27);
            this.buttonRead.TabIndex = 10;
            this.buttonRead.Text = "Read";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // HistoricalRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1405, 480);
            this.Controls.Add(this.dataGridViewHistorical);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HistoricalRecords";
            this.Text = "HistoricalRecords";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HistoricalRecords_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorical)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonHistoricalPrint;
        private System.Windows.Forms.Button buttonSearchALLHis;
        private System.Windows.Forms.Button btHTime;
        public System.Windows.Forms.DataGridView dataGridViewHistorical;
        private System.Windows.Forms.DateTimePicker dateTimePickerDTime;
        private System.Windows.Forms.Button buttonHistoricalClear;
        private System.Windows.Forms.Button buttonWrite;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.Button buttonHistoricalDelete;
        private System.Windows.Forms.Button buttonHistoricalEdit;
        private System.Windows.Forms.Button buttonHistoricalAdd;

    }
}