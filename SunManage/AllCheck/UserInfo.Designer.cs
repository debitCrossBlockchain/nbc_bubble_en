namespace SunManage.AllCheck
{
    partial class UserInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfo));
            this.tBUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewUserInfo = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonSearchALLHis = new System.Windows.Forms.Button();
            this.btHLevel = new System.Windows.Forms.Button();
            this.buttonHistoricalDelete = new System.Windows.Forms.Button();
            this.buttonHistoricalAdd = new System.Windows.Forms.Button();
            this.buttonHistoricalEdit = new System.Windows.Forms.Button();
            this.dataGridViewHistorical = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserInfo)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorical)).BeginInit();
            this.SuspendLayout();
            // 
            // tBUserName
            // 
            this.tBUserName.HideSelection = false;
            this.tBUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tBUserName.Location = new System.Drawing.Point(125, 10);
            this.tBUserName.Margin = new System.Windows.Forms.Padding(4);
            this.tBUserName.Name = "tBUserName";
            this.tBUserName.Size = new System.Drawing.Size(257, 25);
            this.tBUserName.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(41, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 22);
            this.label2.TabIndex = 8;
            this.label2.Tag = "";
            this.label2.Text = "User:";
            // 
            // tBPwd
            // 
            this.tBPwd.HideSelection = false;
            this.tBPwd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tBPwd.Location = new System.Drawing.Point(125, 62);
            this.tBPwd.Margin = new System.Windows.Forms.Padding(4);
            this.tBPwd.Name = "tBPwd";
            this.tBPwd.PasswordChar = '*';
            this.tBPwd.Size = new System.Drawing.Size(257, 25);
            this.tBPwd.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(56, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 22);
            this.label1.TabIndex = 6;
            this.label1.Tag = "";
            this.label1.Text = "Pwd:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(44, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 22);
            this.label3.TabIndex = 10;
            this.label3.Tag = "";
            this.label3.Text = "Level:";
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboBoxLevel.Location = new System.Drawing.Point(125, 112);
            this.comboBoxLevel.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(69, 23);
            this.comboBoxLevel.TabIndex = 71;
            this.comboBoxLevel.Text = "1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 196);
            this.panel1.TabIndex = 72;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewUserInfo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(397, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(438, 196);
            this.panel3.TabIndex = 74;
            // 
            // dataGridViewUserInfo
            // 
            this.dataGridViewUserInfo.AllowUserToOrderColumns = true;
            this.dataGridViewUserInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUserInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewUserInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUserInfo.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewUserInfo.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewUserInfo.Name = "dataGridViewUserInfo";
            this.dataGridViewUserInfo.RowTemplate.Height = 23;
            this.dataGridViewUserInfo.Size = new System.Drawing.Size(438, 196);
            this.dataGridViewUserInfo.TabIndex = 4;
            this.dataGridViewUserInfo.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUserInfo_CellContentDoubleClick);
            this.dataGridViewUserInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUserInfo_CellDoubleClick);
            this.dataGridViewUserInfo.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewUserInfo_RowPostPaint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBoxLevel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tBPwd);
            this.panel2.Controls.Add(this.tBUserName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 196);
            this.panel2.TabIndex = 73;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonSearchALLHis);
            this.panel4.Controls.Add(this.btHLevel);
            this.panel4.Controls.Add(this.buttonHistoricalDelete);
            this.panel4.Controls.Add(this.buttonHistoricalAdd);
            this.panel4.Controls.Add(this.buttonHistoricalEdit);
            this.panel4.Controls.Add(this.dataGridViewHistorical);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 196);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(835, 56);
            this.panel4.TabIndex = 73;
            // 
            // buttonSearchALLHis
            // 
            this.buttonSearchALLHis.Location = new System.Drawing.Point(193, 15);
            this.buttonSearchALLHis.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSearchALLHis.Name = "buttonSearchALLHis";
            this.buttonSearchALLHis.Size = new System.Drawing.Size(103, 28);
            this.buttonSearchALLHis.TabIndex = 14;
            this.buttonSearchALLHis.Text = "Refresh";
            this.buttonSearchALLHis.UseVisualStyleBackColor = true;
            this.buttonSearchALLHis.Click += new System.EventHandler(this.buttonSearchALLHis_Click);
            // 
            // btHLevel
            // 
            this.btHLevel.Location = new System.Drawing.Point(13, 17);
            this.btHLevel.Margin = new System.Windows.Forms.Padding(4);
            this.btHLevel.Name = "btHLevel";
            this.btHLevel.Size = new System.Drawing.Size(159, 26);
            this.btHLevel.TabIndex = 13;
            this.btHLevel.Text = "Query by level";
            this.btHLevel.UseVisualStyleBackColor = true;
            this.btHLevel.Click += new System.EventHandler(this.btHLevel_Click);
            // 
            // buttonHistoricalDelete
            // 
            this.buttonHistoricalDelete.Location = new System.Drawing.Point(565, 15);
            this.buttonHistoricalDelete.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHistoricalDelete.Name = "buttonHistoricalDelete";
            this.buttonHistoricalDelete.Size = new System.Drawing.Size(103, 28);
            this.buttonHistoricalDelete.TabIndex = 11;
            this.buttonHistoricalDelete.Text = "Delete";
            this.buttonHistoricalDelete.UseVisualStyleBackColor = true;
            this.buttonHistoricalDelete.Click += new System.EventHandler(this.buttonHistoricalDelete_Click);
            // 
            // buttonHistoricalAdd
            // 
            this.buttonHistoricalAdd.Location = new System.Drawing.Point(441, 15);
            this.buttonHistoricalAdd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHistoricalAdd.Name = "buttonHistoricalAdd";
            this.buttonHistoricalAdd.Size = new System.Drawing.Size(103, 28);
            this.buttonHistoricalAdd.TabIndex = 9;
            this.buttonHistoricalAdd.Text = "Add";
            this.buttonHistoricalAdd.UseVisualStyleBackColor = true;
            this.buttonHistoricalAdd.Click += new System.EventHandler(this.buttonHistoricalAdd_Click);
            // 
            // buttonHistoricalEdit
            // 
            this.buttonHistoricalEdit.Location = new System.Drawing.Point(317, 15);
            this.buttonHistoricalEdit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHistoricalEdit.Name = "buttonHistoricalEdit";
            this.buttonHistoricalEdit.Size = new System.Drawing.Size(103, 28);
            this.buttonHistoricalEdit.TabIndex = 10;
            this.buttonHistoricalEdit.Text = "Edit";
            this.buttonHistoricalEdit.UseVisualStyleBackColor = true;
            this.buttonHistoricalEdit.Click += new System.EventHandler(this.buttonHistoricalEdit_Click);
            // 
            // dataGridViewHistorical
            // 
            this.dataGridViewHistorical.AllowUserToOrderColumns = true;
            this.dataGridViewHistorical.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHistorical.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewHistorical.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewHistorical.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistorical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewHistorical.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewHistorical.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewHistorical.Name = "dataGridViewHistorical";
            this.dataGridViewHistorical.RowTemplate.Height = 23;
            this.dataGridViewHistorical.Size = new System.Drawing.Size(835, 56);
            this.dataGridViewHistorical.TabIndex = 8;
            // 
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 252);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "UserInfo";
            this.Text = "User Management";
            this.Load += new System.EventHandler(this.UserInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserInfo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorical)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tBUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonHistoricalDelete;
        private System.Windows.Forms.Button buttonHistoricalAdd;
        private System.Windows.Forms.Button buttonHistoricalEdit;
        private System.Windows.Forms.DataGridView dataGridViewHistorical;
        private System.Windows.Forms.Button btHLevel;
        private System.Windows.Forms.DataGridView dataGridViewUserInfo;
        private System.Windows.Forms.Button buttonSearchALLHis;
    }
}