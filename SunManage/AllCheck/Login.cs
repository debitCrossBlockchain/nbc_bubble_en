using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using SunManage.xml;
using SunManage.communication;
using SunManage.AllCheck;
using ADOX;//引用创建Access数据库的库
using System.IO;
using System.Data.OleDb;
using System.Drawing.Printing;
using System.Collections;
using System.Security.Cryptography;
using System.Windows;



namespace SunManage.AllCheck
{
    public partial class Login : Form
    {
        public static string mUserLog = "";
        public static int m_nLevel = 100;
        bool formMove = false;//窗体是否移动
        Point formPoint;//记录窗体的位置
        private static int mflag = 0;//增加超级用户的标志位查看数据库是否存在这条记录
        private OleDbConnection mConnection;
        public static string ms_strName = "";

        private OleDbConnection mConnectionDeviceConcatenateParameterS;
     
        private OleDbConnection mConnectionDeviceConcatenateParameter;
        string sAccessConnectionDeviceConcatenateParameter = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\DeviceConcatenateParameter.mdb";
        string sAccessConnectionDeviceConcatenateParameterS = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\DeviceConcatenateParameter.mdb";
        public Login()
        {
            InitializeComponent();
        }


        void GetLevel(String UserName)
        {
            string TableName = "UserInfo";
            string mSelectQuery = "Select * From {0} where [UserNameInfo]='" + UserName + "'";
            mSelectQuery = string.Format(mSelectQuery, TableName);

            mConnectionDeviceConcatenateParameterS = new OleDbConnection(sAccessConnectionDeviceConcatenateParameterS);
            mConnectionDeviceConcatenateParameterS.Open();
            OleDbCommand mCmd = new OleDbCommand(mSelectQuery, mConnectionDeviceConcatenateParameterS);
            OleDbDataReader reader = mCmd.ExecuteReader();


            if (reader.Read())
            {
                m_nLevel = Convert.ToInt32(reader[2].ToString());
            }
            reader.Close();
            mConnectionDeviceConcatenateParameterS.Close();
        }


        private void mBCancer_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                System.Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }

        private void mBLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tBUserName.Text) || string.IsNullOrEmpty(tBPwd.Text))
            {
                MessageBox.Show("User or By Detectingword cannot be null！");
            }
            if (!string.IsNullOrEmpty(tBUserName.Text) && !string.IsNullOrEmpty(tBPwd.Text))
            {
                string UserName = tBUserName.Text.ToString();
                byte[] result = Encoding.Default.GetBytes(tBPwd.Text.Trim());    //mPwd为输入By Detectingword
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] output = md5.ComputeHash(result);
                string Pwd = BitConverter.ToString(output).Replace("-", "");  //Pwd为输出加密文本
                if (!string.IsNullOrEmpty(UserName))
                {
                    try
                    {
                        GetLevel(UserName);
                        string TableName = "UserInfo";


                        string mSelectQuery = "Select * From {0} where [UserNameInfo]='" + UserName + "'";
                        mSelectQuery = string.Format(mSelectQuery, TableName);

                        mConnectionDeviceConcatenateParameterS = new OleDbConnection(sAccessConnectionDeviceConcatenateParameterS);
                        mConnectionDeviceConcatenateParameterS.Open();
                        OleDbCommand mCmd = new OleDbCommand(mSelectQuery, mConnectionDeviceConcatenateParameterS);
                        OleDbDataReader reader = mCmd.ExecuteReader();
                       
                      
                        if (reader.Read())
                        {

                            if (Pwd == reader[1].ToString())
                            {
                                this.Close();
                                ms_strName = UserName;

                                Main mMain = new Main();
                                mMain.ShowDialog();
                                
                            }


                        }
                       
                        reader.Close();
                        mConnectionDeviceConcatenateParameterS.Close();
                       

                    }
                    catch (Exception ex)
                    {
                       
                    }

                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists("..\\..\\DataBase") == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory("..\\..\\DataBase");
                }

                string DeviceConcatenateParameterMDB = "..\\..\\DataBase\\DeviceConcatenateParameter.mdb";
                if (!File.Exists(DeviceConcatenateParameterMDB)) //判断是否存在数据库，不存在，则创建
                {
                    ADOX.Catalog catalog = new Catalog();
                    catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\DataBase\\DeviceConcatenateParameter.mdb;Jet OLEDB:Engine Type=5");

                }
                ADOX.Catalog mCatalog = new Catalog();
                ADODB.Connection cn = new ADODB.Connection();


                string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\DeviceConcatenateParameter.mdb";
                mConnection = new OleDbConnection(sAccessConnection);

                mConnection.Open();
                cn.Open(sAccessConnection, null, null, -1);
                mCatalog.ActiveConnection = cn;
                Main mMain = new Main();
                bool flag = mMain.GetTables(mConnection, "UserInfo");
                if (!flag)//判断表名是否存在
                {

                    ADOX.Table table = new ADOX.Table();

                    table.Name = "UserInfo";

                    ADOX.Column column = new ADOX.Column();
                    column.ParentCatalog = mCatalog;
                    column.Name = "UserNameInfo";
                    column.Type = DataTypeEnum.adVarWChar;
                    column.DefinedSize = 35;
                    column.Properties["AutoIncrement"].Value = false;
                    column.Properties["Jet OLEDB:Allow Zero Length"].Value = true;
                    table.Columns.Append(column, DataTypeEnum.adVarWChar, 35);
                    table.Keys.Append("FirstTablePrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);

                    table.Columns.Append("PwdInfo", DataTypeEnum.adVarWChar, 35);
                    table.Columns["PwdInfo"].Attributes = ColumnAttributesEnum.adColNullable;
                    table.Columns.Append("LevelInfo", DataTypeEnum.adVarWChar, 15);
                    table.Columns["LevelInfo"].Attributes = ColumnAttributesEnum.adColNullable;


                    try
                    {

                        mCatalog.Tables.Append(table);

                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);

                    }

                    //此处一定要关闭连接，否则添加数据时候会出错

                    table = null;

                    mCatalog = null;

                    Application.DoEvents();

                }
                mConnection.Close();
                cn.Close();

                string mUserName = "Admin";
                string mPwd = "Admin";
                string Level = "1";

                byte[] result = Encoding.Default.GetBytes(mPwd.Trim());    //mPwd为输入By Detectingword
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] output = md5.ComputeHash(result);
                string Pwd = BitConverter.ToString(output).Replace("-", "");  //Pwd为输出加密文本

                if (!string.IsNullOrEmpty(mUserName))
                {
                    try
                    {

                        string TableName = "UserInfo";


                        string mSelectQuery = "Select * From {0} where [UserNameInfo]='" + mUserName + "'";
                        mSelectQuery = string.Format(mSelectQuery, TableName);

                        mConnectionDeviceConcatenateParameterS = new OleDbConnection(sAccessConnectionDeviceConcatenateParameterS);
                        mConnectionDeviceConcatenateParameterS.Open();
                        OleDbCommand mCmd = new OleDbCommand(mSelectQuery, mConnectionDeviceConcatenateParameterS);
                        OleDbDataReader reader = mCmd.ExecuteReader();

                        if (!reader.Read())
                        {

                            mflag = 1;


                        }
                        reader.Close();
                        mConnectionDeviceConcatenateParameterS.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception:" + ex.ToString(), "Tips");
                    }
                }
                if (mflag == 1)
                {




                    string mQuery = String.Format("insert into UserInfo ([UserNameInfo],[PwdInfo],[LevelInfo]) values ('{0}','{1}','{2}')", mUserName, Pwd, Level);

                    mConnectionDeviceConcatenateParameter = new OleDbConnection(sAccessConnectionDeviceConcatenateParameter);

                  OleDbCommand da = new OleDbCommand(mQuery, mConnectionDeviceConcatenateParameter);

                    //

                    try
                    {
                        mConnectionDeviceConcatenateParameter.Open();
                        da.ExecuteNonQuery();

                       

                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show("Exception:" + ex.ToString(), "Tips");

                    }

                    finally
                    {
                        mflag = 0;
                        mConnectionDeviceConcatenateParameter.Close();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
            CreateNuronbc("Neuronbc");
         
        }

        void CreateNuronbc(string UserName)
        {
            try
            {
                if (Directory.Exists("..\\..\\DataBase") == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory("..\\..\\DataBase");
                }

                string DeviceConcatenateParameterMDB = "..\\..\\DataBase\\DeviceConcatenateParameter.mdb";
                if (!File.Exists(DeviceConcatenateParameterMDB)) //判断是否存在数据库，不存在，则创建
                {
                    ADOX.Catalog catalog = new Catalog();
                    catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\DataBase\\DeviceConcatenateParameter.mdb;Jet OLEDB:Engine Type=5");

                }
                ADOX.Catalog mCatalog = new Catalog();
                ADODB.Connection cn = new ADODB.Connection();


                string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\DeviceConcatenateParameter.mdb";
                mConnection = new OleDbConnection(sAccessConnection);

                mConnection.Open();
                cn.Open(sAccessConnection, null, null, -1);
                mCatalog.ActiveConnection = cn;
                Main mMain = new Main();
                bool flag = mMain.GetTables(mConnection, "UserInfo");
                if (!flag)//判断表名是否存在
                {

                    ADOX.Table table = new ADOX.Table();

                    table.Name = "UserInfo";

                    ADOX.Column column = new ADOX.Column();
                    column.ParentCatalog = mCatalog;
                    column.Name = "UserNameInfo";
                    column.Type = DataTypeEnum.adVarWChar;
                    column.DefinedSize = 35;
                    column.Properties["AutoIncrement"].Value = false;
                    column.Properties["Jet OLEDB:Allow Zero Length"].Value = true;
                    table.Columns.Append(column, DataTypeEnum.adVarWChar, 35);
                    table.Keys.Append("FirstTablePrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);

                    table.Columns.Append("PwdInfo", DataTypeEnum.adVarWChar, 35);
                    table.Columns["PwdInfo"].Attributes = ColumnAttributesEnum.adColNullable;
                    table.Columns.Append("LevelInfo", DataTypeEnum.adVarWChar, 15);
                    table.Columns["LevelInfo"].Attributes = ColumnAttributesEnum.adColNullable;


                    try
                    {

                        mCatalog.Tables.Append(table);

                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);

                    }

                    //此处一定要关闭连接，否则添加数据时候会出错

                    table = null;

                    mCatalog = null;

                    Application.DoEvents();

                }
                mConnection.Close();
                cn.Close();

                string mUserName = UserName;
                string mPwd = UserName;
                string Level = "2";

                byte[] result = Encoding.Default.GetBytes(mPwd.Trim());    //mPwd为输入By Detectingword
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] output = md5.ComputeHash(result);
                string Pwd = BitConverter.ToString(output).Replace("-", "");  //Pwd为输出加密文本

                if (!string.IsNullOrEmpty(mUserName))
                {
                    try
                    {

                        string TableName = "UserInfo";


                        string mSelectQuery = "Select * From {0} where [UserNameInfo]='" + mUserName + "'";
                        mSelectQuery = string.Format(mSelectQuery, TableName);

                        mConnectionDeviceConcatenateParameterS = new OleDbConnection(sAccessConnectionDeviceConcatenateParameterS);
                        mConnectionDeviceConcatenateParameterS.Open();
                        OleDbCommand mCmd = new OleDbCommand(mSelectQuery, mConnectionDeviceConcatenateParameterS);
                        OleDbDataReader reader = mCmd.ExecuteReader();

                        if (!reader.Read())
                        {

                            mflag = 1;


                        }
                        reader.Close();
                        mConnectionDeviceConcatenateParameterS.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception:" + ex.ToString(), "Tips");
                    }
                }
                if (mflag == 1)
                {




                    string mQuery = String.Format("insert into UserInfo ([UserNameInfo],[PwdInfo],[LevelInfo]) values ('{0}','{1}','{2}')", mUserName, Pwd, Level);

                    mConnectionDeviceConcatenateParameter = new OleDbConnection(sAccessConnectionDeviceConcatenateParameter);

                    OleDbCommand da = new OleDbCommand(mQuery, mConnectionDeviceConcatenateParameter);

                    //

                    try
                    {
                        mConnectionDeviceConcatenateParameter.Open();
                        da.ExecuteNonQuery();



                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show("Exception:" + ex.ToString(), "Tips");

                    }

                    finally
                    {
                        mflag = 0;
                        mConnectionDeviceConcatenateParameter.Close();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 鼠标按下的处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                formPoint = new Point();
                int xOffset;
                int yOffset;
                if (e.Button == MouseButtons.Left)
                {
                    xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                    yOffset = -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height;
                    formPoint = new Point(xOffset, yOffset);
                    formMove = true;//开始移动
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Exception:" + ex.ToString(), "Tips");

            }
        }
        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (formMove == true)
                {
                    Point mousePos = Control.MousePosition;
                    mousePos.Offset(formPoint.X, formPoint.Y);
                    Location = mousePos;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Exception:" + ex.ToString(), "Tips");

            }
        }
        /// <summary>
        /// 鼠标左键放下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)//按下的是鼠标左键
                {
                    formMove = false;//停止移动
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Exception:" + ex.ToString(), "Tips");

            }
        }
        
            
    }
}
