using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//引用创建Access数据库的库
using System.Data.OleDb;
using SunManage.communication;
using ADOX;//引用创建Access数据库的库
using System.IO;
using System.Drawing.Printing;
using System.Security.Cryptography;
using SunManage;
namespace SunManage.AllCheck
{
    public partial class UserInfo : Form
    {
        private OleDbConnection mConnection;
        string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\DeviceConcatenateParameter.mdb";
        private DataSet ds = new DataSet();//数据库操作
        static string mLevel = "1";
        public UserInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInfo_Load(object sender, EventArgs e)
        {
            switch (Login.m_nLevel)
            {
                case Main.system_level:
                case Main.hight_level:
                case Main.middle_level:
                    break;
                default:
                    {
                        buttonHistoricalAdd.Visible = false;
                        buttonHistoricalDelete.Visible = false;
                        break;
                    }

            }

            string mTreeView = "UserInfo";
            string mQuery = "Select [UserNameInfo] as userName,[LevelInfo] as level From {0}";
            mQuery = string.Format(mQuery, mTreeView);
            mConnection = new OleDbConnection(sAccessConnection);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(mQuery, mConnection);
            try
            {
                mConnection.Open();
                dataAdapter.Fill(ds);
                dataGridViewUserInfo.DataSource = ds.Tables[0].DefaultView;
                dataGridViewUserInfo.AllowUserToAddRows = false;

            }
            catch (Exception ex)
            {
            }
            finally
            {

                mConnection.Close();

            }

        }

        private bool checkLevel(int operate_level)
        {
            bool flag = true;

            switch (Login.m_nLevel)
            {
                case Main.system_level:
                    {
                        switch (operate_level)
                        {
                            case Main.system_level:
                            case Main.hight_level:
                            case Main.middle_level:
                            case Main.primary_level:
                                {
                                    flag = true;
                                    break;
                                }
                            default:
                                {
                                    flag = false;
                                    break;
                                }
                        }
                        break;
                    }

                case Main.hight_level:
                    {
                        switch (operate_level)
                        {
                            case Main.hight_level:
                            case Main.middle_level:
                            case Main.primary_level:
                                {
                                    flag = true;
                                    break;
                                }
                            default:
                                {
                                    flag = false;
                                    break;
                                }
                        }
                        break;
                    }
                case Main.middle_level:
                    {
                        switch (operate_level)
                        {
                            case Main.middle_level:
                            case Main.primary_level:
                                {
                                    flag = true;
                                    break;
                                }
                            default:
                                {
                                    flag = false;
                                    break;
                                }
                        }
                        break;
                    }
                case Main.primary_level:
                    {
                        if (operate_level == Main.primary_level)
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                        break;
                    }
                default:
                    {
                        flag = false;
                        break;
                    }

            }
            return flag;
        }
        /// <summary>
        /// 按级别查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btHLevel_Click(object sender, EventArgs e)
        {
            try
            {

                string mTreeView = "UserInfo";
                switch (comboBoxLevel.SelectedIndex)
                {
                    case 0:
                        mLevel = "1";
                        break;
                    case 1:
                        mLevel = "2";
                        break;
                    case 2:
                        mLevel = "3";
                        break;
                    case 3:
                        mLevel = "4";
                        break;
                    case 4:
                        mLevel = "5";
                        break;
                    case 5:
                        mLevel = "6";
                        break;


                    default: break;
                }

                string mQuery = "Select [UserNameInfo] as userName,[LevelInfo] as level From {0} where [LevelInfo]='" + mLevel + "'";



                mQuery = string.Format(mQuery, mTreeView);
                mConnection = new OleDbConnection(sAccessConnection);

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(mQuery, mConnection);


                mConnection.Open();
                //如果需要再次查询，需清空dataset里面的数据  
                ds.Tables[0].Clear();


                dataAdapter.Fill(ds);
                dataGridViewUserInfo.DataSource = ds.Tables[0].DefaultView;
                dataGridViewUserInfo.AllowUserToAddRows = false;

            }

            catch (Exception ex)
            {
                //LogClass.WriteLogFile("Exception:" + ex.ToString());
            }

            finally
            {
                mConnection.Close();
            }

        }
        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHistoricalAdd_Click(object sender, EventArgs e)
        {
            string mTreeView = "UserInfo";
            switch (comboBoxLevel.SelectedIndex)
            {
                case 0:
                    mLevel = "1";
                    break;
                case 1:
                    mLevel = "2";
                    break;
                case 2:
                    mLevel = "3";
                    break;
                case 3:
                    mLevel = "4";
                    break;
                case 4:
                    mLevel = "5";
                    break;
                case 5:
                    mLevel = "6";
                    break;
                default: break;
            }

            if (!checkLevel(comboBoxLevel.SelectedIndex + 1))
            {
                MessageBox.Show("This permission cannot be operated！");
                return;
            }

            if (string.IsNullOrEmpty(tBUserName.Text.ToString()))
            {
                MessageBox.Show("The user name cannot be empty！");
                return;
            }

            if (!string.IsNullOrEmpty(tBUserName.Text.ToString()))
            {
                try
                {
                    string mSelectQuery = "Select * From {0} where [UserNameInfo]='" + tBUserName.Text.ToString() + "'";

                    mSelectQuery = string.Format(mSelectQuery, mTreeView);
                    mConnection = new OleDbConnection(sAccessConnection);
                    mConnection.Open();
                    OleDbCommand cmd = new OleDbCommand(mSelectQuery, mConnection);
                    OleDbDataReader mReader = cmd.ExecuteReader();
                    if (mReader.Read())
                    {
                        MessageBox.Show("This user name exists. Please reenter a different user name！");
                        return;
                    }
                    mReader.Close();
                    mConnection.Close();

                }
                catch (Exception ex)
                {
                    //LogClass.WriteLogFile("Exception:" + ex.ToString());
                }
            }

            byte[] mResult = Encoding.Default.GetBytes(tBPwd.Text.ToString().Trim());    //mPwd为输入密码
            MD5 Md5 = new MD5CryptoServiceProvider();
            byte[] mOutput = Md5.ComputeHash(mResult);
            string mPwd = BitConverter.ToString(mOutput).Replace("-", "");  //Pwd为输出加密文本
            string mQuery = String.Format("insert into {0}([UserNameInfo],[PwdInfo],[LevelInfo]) values ('{1}','{2}','{3}')", mTreeView, tBUserName.Text.ToString(), mPwd, mLevel);


            mConnection = new OleDbConnection(sAccessConnection);
            OleDbCommand da = new OleDbCommand(mQuery, mConnection);

            try
            {
                mConnection.Open();
                da.ExecuteNonQuery();
                MessageBox.Show("User increase success!", "tips");
            }
            catch (Exception ex)
            {
                //LogClass.WriteLogFile("Exception:" + ex.ToString());

            }
            finally
            {
                mConnection.Close();

            }

        }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHistoricalEdit_Click(object sender, EventArgs e)
        {
            string mUserInfoIndex = "";
            switch (comboBoxLevel.SelectedIndex)
            {
                case 0:
                    mLevel = "1";
                    break;
                case 1:
                    mLevel = "2";
                    break;
                case 2:
                    mLevel = "3";
                    break;
                case 3:
                    mLevel = "4";
                    break;
                case 4:
                    mLevel = "5";
                    break;
                case 5:
                    mLevel = "6";
                    break;
                default: break;
            }

            if (dataGridViewUserInfo.SelectedRows.Count <= 0)
            {
                return;
            }
            if (!checkLevel(comboBoxLevel.SelectedIndex + 1))
            {
                MessageBox.Show("This permission cannot be operated！");
                return;
            }
            if (string.IsNullOrEmpty(tBUserName.Text.ToString()))
            {
                MessageBox.Show("The user name cannot be empty！");
                return;
            }
            mUserInfoIndex = dataGridViewUserInfo.Rows[dataGridViewUserInfo.CurrentRow.Index].Cells[1].Value.ToString();
            string TableName = "UserInfo";
            string mQuery = "";
            byte[] mResult = Encoding.Default.GetBytes(tBPwd.Text.ToString().Trim());    //mPwd为输入密码
            MD5 Md5 = new MD5CryptoServiceProvider();
            byte[] mOutput = Md5.ComputeHash(mResult);
            string mPwd = BitConverter.ToString(mOutput).Replace("-", "");  //Pwd为输出加密文本
            mQuery = "update {0} set [UserNameInfo]='" + "{1}" + "',[PwdInfo]='" + "{2}" + "',[LevelInfo]='" + "{3}" + "'where [UserNameInfo]='" + tBUserName.Text.Trim() + "'";
            mQuery = string.Format(mQuery, TableName, tBUserName.Text.ToString(), mPwd, mLevel);
            mConnection = new OleDbConnection(sAccessConnection);
            OleDbCommand da = new OleDbCommand(mQuery, mConnection);
            try
            {
                mConnection.Open();
                da.ExecuteNonQuery();
                MessageBox.Show("User changed successfully!", "tips");
            }
            catch (Exception ex)
            {
                //LogClass.WriteLogFile("Exception:" + ex.ToString());
            }
            finally
            {
                mConnection.Close();
            }
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHistoricalDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewUserInfo.SelectedRows.Count <= 0)
            {
                return;
            }

            if (!checkLevel(comboBoxLevel.SelectedIndex + 1))
            {
                MessageBox.Show("This permission cannot be operated！");
                return;
            }
            if (string.IsNullOrEmpty(tBUserName.Text.ToString()))
            {
                MessageBox.Show("The user name cannot be empty！");
                return;
            }
            string mTreeView = "UserInfo";

            string mDeleteUserInfoIndex = dataGridViewUserInfo.Rows[dataGridViewUserInfo.CurrentRow.Index].Cells[1].Value.ToString();
            if (!checkLevel(int.Parse(mDeleteUserInfoIndex)))
            {
                MessageBox.Show("This permission cannot be operated！");
                return;
            }
            if (mDeleteUserInfoIndex != "Admin")
            {
                string mQuery = "delete * From {0} where [UserNameInfo]='" + mDeleteUserInfoIndex + "'";
                mQuery = string.Format(mQuery, mTreeView);
                mConnection = new OleDbConnection(sAccessConnection);
                OleDbCommand da = new OleDbCommand(mQuery, mConnection);
                try
                {
                    mConnection.Open();
                    if ((MessageBox.Show("Are you sure you want to delete the current user?", "warned！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                    {
                        //删除数据
                        //首先删除数据集 中的该条记录
                        int i = dataGridViewUserInfo.CurrentCell.RowIndex;//得到当前记录号
                        if (i >= 0)
                        {
                            ds.Tables[0].Rows[i].Delete();
                        }
                    }
                    da.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    //LogClass.WriteLogFile("Exception:" + ex.ToString());
                }
                finally
                {
                    mConnection.Close();
                }
            }
        }

        /// <summary>
        /// 清空用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHistoricalClear_Click(object sender, EventArgs e)
        {
            if (dataGridViewUserInfo.SelectedRows.Count > 0)
            {
                string mTreeView = "UserInfo";
                string mQuery = "delete * From {0} where  Not[UserNameInfo]='" + "Admin" + "'";
                mQuery = string.Format(mQuery, mTreeView);
                mConnection = new OleDbConnection(sAccessConnection);
                OleDbCommand da = new OleDbCommand(mQuery, mConnection);

                try
                {
                    mConnection.Open();
                    if ((MessageBox.Show("Are you sure you want to clear the current user?", "warned！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                    {
                        int m = dataGridViewUserInfo.Rows.Count;

                        while (dataGridViewUserInfo.Rows[--m].Cells[0].Value.ToString() != "Admin")
                        {
                            if (m >= 0)
                                ds.Tables[0].Rows[m].Delete();
                        }
                        da.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                   // LogClass.WriteLogFile("Exception:" + ex.ToString());
                }
                finally
                {
                    mConnection.Close();
                }
            }

        }
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearchALLHis_Click(object sender, EventArgs e)
        {
            string mTreeView = "UserInfo";
            string mQuery = "Select [UserNameInfo] as userName,[LevelInfo] as level From {0}";
            mQuery = string.Format(mQuery, mTreeView);
            mConnection = new OleDbConnection(sAccessConnection);

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(mQuery, mConnection);
            //DataGridView dz = new DataGridView();
            //dz.DataSource = ds.Tables[0].DefaultView;
            //如果需要再次查询，需清空dataset里面的数据  
            try
            {
                mConnection.Open();
                ds.Tables[0].Clear();
                dataAdapter.Fill(ds);
                dataGridViewUserInfo.DataSource = ds.Tables[0].DefaultView;
                dataGridViewUserInfo.AllowUserToAddRows = false;

            }
            catch (Exception ex)
            {

               // LogClass.WriteLogFile("Exception:" + ex.ToString());

            }
            finally
            {
                mConnection.Close();

            }
        }
        /// <summary>
        /// 加行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewUserInfo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               dataGridViewUserInfo.RowHeadersWidth - 4,
               e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dataGridViewUserInfo.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dataGridViewUserInfo.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        /// <summary>
        /// 赋值给文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewUserInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tBUserName.Text = dataGridViewUserInfo.Rows[dataGridViewUserInfo.CurrentRow.Index].Cells[0].Value.ToString();
            comboBoxLevel.SelectedIndex = int.Parse(dataGridViewUserInfo.Rows[dataGridViewUserInfo.CurrentRow.Index].Cells[1].Value.ToString())-1;
        }

        private void dataGridViewUserInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tBUserName.Text = dataGridViewUserInfo.Rows[dataGridViewUserInfo.CurrentRow.Index].Cells[0].Value.ToString();
            comboBoxLevel.SelectedIndex = int.Parse(dataGridViewUserInfo.Rows[dataGridViewUserInfo.CurrentRow.Index].Cells[1].Value.ToString()) - 1;
        }

    }
}
