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

namespace SunManage
{
    public partial class Main : Form
    {
        public static Main ms_objMain;
        public const int system_level = 1;
        public const int hight_level = 2;
        public const int middle_level = 3;
        public const int primary_level = 4;
        /// <summary>
        /// 动态数组用于存放轮询访问
        /// 的设备地址
        /// </summary>

      public  static ArrayList mPollingInquiry = new ArrayList();
        /// <summary>
        /// 数据节点和链接Type
        /// </summary>
        public static string MTreeName = "Can not be empty";
        private OleDbConnection mConnection;
        private OleDbConnection mConnectionSystemParameter;
        private OleDbConnection mConnectionDeviceConcatenateParameter;
        string sAccessConnectionDeviceConcatenateParameter = @"Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\DeviceConcatenate.mdb";
        
         
        #region 判断数据是否为空
        /// <summary>
        /// 判断数据库历史数据是否为空
        /// </summary>
        public bool GetTables(OleDbConnection conn,string TableName)
        {

            int result = 0;
            DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                                                             new object[] { null, null, null, "TABLE" });
            try
            {
                if (schemaTable != null)
                {

                    for (Int32 row = 0; row < schemaTable.Rows.Count; row++)
                    {
                        string col_name = schemaTable.Rows[row]["TABLE_NAME"].ToString();
                        if (col_name == TableName)
                        {
                            result++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
            if (result == 0)
                return false;
            return true;
        }
        #endregion
        /// <summary>
        /// 打开xml文件
        /// </summary>
        //public static bool mFlagLog = true;
        OpXMLFile opxml = new OpXMLFile();
        string OpmlFile = @"..\..\XmlIni\TreeView.opml";
     
        public Main()
        {
            try
            {
                InitializeComponent();

                this.mSkinEngine.SkinFile = "..\\..\\skin\\MP10\\MP10.ssk";

                CommPort com = CommPort.Instance;
                com.StatusChanged += OnStatusChanged;

                //USB.pid = 0;
                //USB.vid = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
            
        }
       

       
        #region 判断数据库系统表是否为空
        /// <summary>
        /// 判断数据库系统表是否为空
        /// </summary>
        public bool mGetTables(OleDbConnection conn)
        {

            int result = 0;
            DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                                                             new object[] { null, null, null, "TABLE" });
            try
            {

                if (schemaTable != null)
                {

                    for (Int32 row = 0; row < schemaTable.Rows.Count; row++)
                    {
                        string col_name = schemaTable.Rows[row]["TABLE_NAME"].ToString();
                        if (col_name == this.RssTreeView.SelectedNode.Text)
                        {
                            result++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
            if (result == 0)
                return false;
            return true;
        }
        #endregion
        #region 动态生成Tree树目录
        // 动态生成Tree树目录(Load列表)
        public void LoadRssTreeList(string url)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(url);

                XmlNode body = doc.SelectSingleNode("//body");

                XmlNodeList FeedList = body.ChildNodes;//得到body的所有子元素

                foreach (XmlNode feed in FeedList)//分别对子元素依次循环操作
                {
                    TreeNode tree = new TreeNode();  // 创建一个树型节点对象

                    AddRssFeedSonListTree(feed, tree);//判断当前节点有子节点吗

                    tree.Text = feed.Attributes["title"].Value.ToString();// set树型节点的名称

                    RssTreeView.Nodes.Add(tree);//把当前创建的这个树型节点加到TreeView控件中
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }

        }
       #endregion
        #region 递归完成对当前节点的遍历功能
        // 递归完成对当前节点的遍历功能
        public void AddRssFeedSonListTree(XmlNode node, TreeNode PreTN)
        {
            try
            {

                if (node.HasChildNodes)//Testing当前节点有没有子元素
                {
                    for (int i = 0; i < node.ChildNodes.Count; i++)//循环所有子元素
                    {
                        TreeNode tn = new TreeNode();
                        tn.Text = node.ChildNodes[i].Attributes["title"].Value.ToString();
                        PreTN.Nodes.Add(tn);

                        AddRssFeedSonListTree(node.ChildNodes[i], tn);//递归开始
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }

    #endregion
        #region  选中的操作
        // 选中的操作

        private void OprationSelectRss(string oprationmode, string title, string url)
        {
            try
            {
                // 获得当前所被选中的节点的完整路径
                string old = RssTreeView.SelectedNode.FullPath.ToString();
                //MessageBox.Show(old);
                string xpathstr = old.Replace("\\", "/");
                //MessageBox.Show(xpathstr);
                string[] SARRAY = System.Text.RegularExpressions.Regex.Split(xpathstr, "/");
                //foreach (string s in SARRAY)
                //{
                //    MessageBox.Show(s);
                //}
                opxml.OprationOpmlFile(OpmlFile, SARRAY, oprationmode, title, url);
                //{
                //    MessageBox.Show("操作成功");
                //}
                //else { MessageBox.Show("操作失败"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        #endregion

        #region set控件随窗体一起变化
        ///// <summary>
        /////set控件随窗体一起变化
        ///// </summary>
        //private float X, Y;
        ////获得控件的长度、宽度、位置、字体大小的数据
        //private void setTag(Control cons)//Control类，定义控件的基类
        //{
        //    foreach (Control con in cons.Controls)
        //    {
        //        con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;//获取或set包含有关控件的数据的对象
        //        if (con.Controls.Count > 0)
        //            setTag(con);//递归算法
        //    }
        //}
        //private void setControls(float newx, float newy, Control cons)//实现控件以及字体的缩放
        //{
        //    foreach (Control con in cons.Controls)
        //    {
        //        string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
        //        float a = Convert.ToSingle(mytag[0]) * newx;
        //        con.Width = (int)a;
        //        a = Convert.ToSingle(mytag[1]) * newy;
        //        con.Height = (int)(a);
        //        a = Convert.ToSingle(mytag[2]) * newx;
        //        con.Left = (int)(a);
        //        a = Convert.ToSingle(mytag[3]) * newy;
        //        con.Top = (int)(a);
        //        Single currentSize = Convert.ToSingle(mytag[4]) * newy;
        //        con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
        //        if (con.Controls.Count > 0)
        //        {
        //            setControls(newx, newy, con);//递归
        //        }
        //    }
        //}
        //private void Form1_Resize(object sender, EventArgs e)
        //{
        //    float newx = (this.Width) / X;//当前宽度与变化前宽度之比
        //    float newy = this.Height / Y;//当前高度与变化前宽度之比
        //    setControls(newx, newy, this);
        //    //this.Text = this.Width.ToString() + " " + this.Height.ToString();  //窗体标题显示长度和宽度
        //}
        #endregion

        #region Load主窗体
        private void Main_Load(object sender, EventArgs e)
        {
            
            
            //this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            //this.Width = 889;
            //this.Height = 512;
            //this.Resize += new EventHandler(Form1_Resize);//执行Form1_Resize方法
            //X = this.Width;
            //Y = this.Height;
            //setTag(this);

            /// <summary>
            ///Load数据节点
            /// </summary>
            try
            {
                ms_objMain = this;
                switch (Login.m_nLevel)
                {
                    case Main.system_level:
                    case Main.hight_level:
                    case Main.middle_level:
                        {
                            break;
                        }
                    default:
                        {
                            ToolStripMenuItemExport.Visible = false;
                            ToolStripMenuItemImport.Visible = false;
                            pictureBoxImport.Visible = false;
                            pictureBoxExport.Visible = false;
                            break;
                        }
                }

                switch (Login.m_nLevel)
                {
                    case Main.system_level:
                    case Main.hight_level:
                        {
                            break;
                        }
                    default:
                        {
                            ToolStripMenuItemSystemset.Visible = false;
                            toolSystemParameter.Visible = false;
                            break;
                        }
                }
                RssTreeView.Nodes.Clear();
                LoadRssTreeList(OpmlFile);
                /// <summary>
                ///创建数据库
                /// </summary

                if (Directory.Exists("..\\..\\DataBase") == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory("..\\..\\DataBase");
                }
                string TestHistoryDataMDB = "..\\..\\DataBase\\TestHistoryData.mdb";
                string SystemParameterMDB = "..\\..\\DataBase\\SystemParameter.mdb";
                string DeviceConcatenateParameterMDB = "..\\..\\DataBase\\DeviceConcatenateParameter.mdb";
                string DeviceConcatenateMDB = "..\\..\\DataBase\\DeviceConcatenate.mdb";
                string StartTestMDB = "..\\..\\DataBase\\StartTest.mdb";
                if (!File.Exists(TestHistoryDataMDB)) //判断是否存在数据库，不存在，则创建
                {
                    ADOX.Catalog catalog = new Catalog();
                    catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\DataBase\\TestHistoryData.mdb;Jet OLEDB:Engine Type=5");

                }
                if (!File.Exists(SystemParameterMDB)) //判断是否存在数据库，不存在，则创建
                {
                    ADOX.Catalog catalog = new Catalog();
                    catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\DataBase\\SystemParameter.mdb;Jet OLEDB:Engine Type=5");

                }
                if (!File.Exists(DeviceConcatenateParameterMDB)) //判断是否存在数据库，不存在，则创建
                {
                    ADOX.Catalog catalog = new Catalog();
                    catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\DataBase\\DeviceConcatenateParameter.mdb;Jet OLEDB:Engine Type=5");

                }
                if (!File.Exists(DeviceConcatenateMDB)) //判断是否存在数据库，不存在，则创建
                {
                    ADOX.Catalog catalog = new Catalog();
                    catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\DataBase\\DeviceConcatenate.mdb;Jet OLEDB:Engine Type=5");

                }

                if (!File.Exists(StartTestMDB)) //判断是否存在数据库，不存在，则创建
                {
                    ADOX.Catalog catalog = new Catalog();
                    catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\DataBase\\StartTest.mdb;Jet OLEDB:Engine Type=5");

                }
                ADOX.Catalog mCatalog = new Catalog();
                ADODB.Connection cn = new ADODB.Connection();


                string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\DeviceConcatenate.mdb";
                mConnection = new OleDbConnection(sAccessConnection);

                mConnection.Open();
                cn.Open(sAccessConnection, null, null, -1);
                mCatalog.ActiveConnection = cn;

                bool flag = GetTables(mConnection, "DeviceConcatenate");
                if (!flag)//判断表名是否存在
                {

                    ADOX.Table table = new ADOX.Table();

                    table.Name = "DeviceConcatenate";

                    ADOX.Column column = new ADOX.Column();
                    column.ParentCatalog = mCatalog;
                    column.Name = "DeviceName";
                    column.Type = DataTypeEnum.adVarWChar;
                    column.DefinedSize = 16;
                    column.Properties["AutoIncrement"].Value = false;
                    column.Properties["Jet OLEDB:Allow Zero Length"].Value = true;
                    table.Columns.Append(column, DataTypeEnum.adVarWChar, 16);
                    table.Keys.Append("FirstTablePrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);
                    table.Columns.Append("DeviceAddress", DataTypeEnum.adInteger,10);
                    table.Columns["DeviceAddress"].Attributes = ColumnAttributesEnum.adColNullable;
                    table.Columns.Append("mStatFlagBP", DataTypeEnum.adInteger, 10); 
                    table.Columns["mStatFlagBP"].Attributes = ColumnAttributesEnum.adColNullable;
                 
                    table.Columns.Append("mStatFlagMP", DataTypeEnum.adInteger, 10);
                    table.Columns["mStatFlagMP"].Attributes = ColumnAttributesEnum.adColNullable;
                   
                    table.Columns.Append("mStatFlagRR", DataTypeEnum.adInteger, 10);
                    table.Columns["mStatFlagRR"].Attributes = ColumnAttributesEnum.adColNullable;
                   
                    table.Columns.Append("mStatFlagDF", DataTypeEnum.adInteger, 10);
                    table.Columns["mStatFlagDF"].Attributes = ColumnAttributesEnum.adColNullable;
                   
                    table.Columns.Append("mStatFlagWI", DataTypeEnum.adInteger, 10);
                    table.Columns["mStatFlagWI"].Attributes = ColumnAttributesEnum.adColNullable;
                   
                    table.Columns.Append("mStatFlagSP", DataTypeEnum.adInteger, 10);
                    table.Columns["mStatFlagSP"].Attributes = ColumnAttributesEnum.adColNullable;
                   
                   
       


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

                
            /// <summary>
            ///显示Time
            /// </summary
                this.MainToolStripStatusLabel.Text = String.Format("System Current Time:{0} Choosed Instrument:{1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), MTreeName) + USB.mUSBState;

            this.timerMainStatus.Interval = 1000;
            this.timerMainStatus.Start();

                OleDbConnection mConnectionDeviceConcatenateMDB;
                string sAccessConnectionDeviceConcatenateMDB = @"Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\DeviceConcatenate.mdb";
                string mQuery = "Select DeviceAddress From DeviceConcatenate";
                mConnectionDeviceConcatenateMDB = new OleDbConnection(sAccessConnectionDeviceConcatenateMDB);


                try
                {

                    mConnectionDeviceConcatenateMDB.Open();
                    OleDbCommand cmd = new OleDbCommand(mQuery, mConnectionDeviceConcatenateMDB);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        mPollingInquiry.Add(reader[0]);
                    }
                    reader.Close();
                }

                catch (Exception ex)
                {

                    MessageBox.Show("Exception:" + ex.ToString(), "Tips");

                }

                finally
                {


                    mConnectionDeviceConcatenateMDB.Close();

                }
                timerPollingInquiry.Start();
                timerPollingInquiry.Interval = 60000;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }

        }
        #endregion
        #region RssTreeView_MouseDown
        private void RssTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)//判断你点的是不是右键
                {
                    Point ClickPoint = new Point(e.X, e.Y);
                    TreeNode CurrentNode = RssTreeView.GetNodeAt(ClickPoint);
                    if (CurrentNode != null)//判断你点的是不是一个节点
                    {
                        string str = "NodeList";
                        if (CurrentNode.Text == str)
                        {
                            CurrentNode.ContextMenuStrip = CreateDevice;

                        }
                        else
                        {
                            CurrentNode.ContextMenuStrip = CreateEdit;
                        }

                        //switch (CurrentNode.Text)//根据不同节点显示不同的右键菜单，当然你可以让它显示一样的菜单
                        //{
                        //    case "NodeList":
                        //        CurrentNode.ContextMenuStrip = CreateDevice;
                        //        break;

                        //}
                        RssTreeView.SelectedNode = CurrentNode;//选中这个节点
                        MTreeName = RssTreeView.SelectedNode.Text;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }

        }
        #endregion
        #region 建数据库
        private void CreatDB(CommunicationConnect CCN)
        {
            try
            {
                ADOX.Catalog catalog = new Catalog();
                ADODB.Connection cn = new ADODB.Connection();


                string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\TestHistoryData.mdb";
                mConnection = new OleDbConnection(sAccessConnection);

                mConnection.Open();
                cn.Open(sAccessConnection, null, null, -1);
                catalog.ActiveConnection = cn;
                if (!string.IsNullOrEmpty(CCN.DeviceNameId1))
                {
                    bool flag = CCN.GetTables(mConnection);
                    if (!flag)//判断表名是否存在
                    {

                        ADOX.Table table = new ADOX.Table();

                        table.Name = CCN.DeviceNameId1;

                        ADOX.Column column = new ADOX.Column();
                        column.ParentCatalog = catalog;
                        column.Name = "TestHisData";
                        column.Type = DataTypeEnum.adWChar;
                        column.DefinedSize = 50;
                        column.Properties["AutoIncrement"].Value = false;
                        column.Properties["Jet OLEDB:Allow Zero Length"].Value = true;


                        table.Columns.Append(column, DataTypeEnum.adWChar, 50);
                        table.Keys.Append("FirstTablePrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);
                        //（2） Test_type          -------    测试模态 (M/B/A/P/D/H)    -- 1;
                        table.Columns.Append("Htest_type", DataTypeEnum.adWChar, 100);//（1） Test_type          -------    测试模态 (M/B/A/P/D/H)    -- 1;
                        table.Columns["Htest_type"].Attributes = ColumnAttributesEnum.adColNullable;//（1） Test_type          -------    测试模态 (M/B/A/P/D/H)    -- 1;

                        //（3） Test_Psernum[16]   -------   生产批号       -- 16     ;
                        table.Columns.Append("Test_Psernum", DataTypeEnum.adWChar, 100);
                        table.Columns["Test_Psernum"].Attributes = ColumnAttributesEnum.adColNullable;

                        //（4）HA_STime[5]           -------  日期/时间       -- 5    ;
                        table.Columns.Append("HA_STime", DataTypeEnum.adWChar, 100);
                        table.Columns["HA_STime"].Attributes = ColumnAttributesEnum.adColNullable;

                        //（5） Test_Name[16]   -------   测试名称       -- 16     ;
                        table.Columns.Append("Test_Name", DataTypeEnum.adWChar, 100);
                        table.Columns["Test_Name"].Attributes = ColumnAttributesEnum.adColNullable;

                        //（6） Test_Fsernum [16]   -------  滤芯序号       -- 16     ;
                        table.Columns.Append("Test_Fsernum", DataTypeEnum.adWChar, 100);
                        table.Columns["Test_Fsernum"].Attributes = ColumnAttributesEnum.adColNullable;

                        //（7） Test_filt[16]        -------  滤材种类       -- 16     ;
                        table.Columns.Append("Test_filt", DataTypeEnum.adWChar, 100);
                        table.Columns["Test_filt"].Attributes = ColumnAttributesEnum.adColNullable;

                        //（8）Test_LIQU[15]       -------  测试液体       -- 15    ;
                        table.Columns.Append("Test_LIQU", DataTypeEnum.adWChar, 100);
                        table.Columns["Test_LIQU"].Attributes = ColumnAttributesEnum.adColNullable;

                        //（9）Test_Filt_Hight -------  滤芯高度    -- 2    ;
                        table.Columns.Append("Test_Filt_Hight", DataTypeEnum.adWChar, 100);
                        table.Columns["Test_Filt_Hight"].Attributes = ColumnAttributesEnum.adColNullable;

                        //（10）Test_Filt_Num -------  滤芯数量    -- 2    ;
                        table.Columns.Append("Test_Filt_Num", DataTypeEnum.adWChar, 100);
                        table.Columns["Test_Filt_Num"].Attributes = ColumnAttributesEnum.adColNullable;


                        //（11）Test_Result -------  测试结果    -- 2    ;
                        table.Columns.Append("Test_Result", DataTypeEnum.adWChar, 100);
                        table.Columns["Test_Result"].Attributes = ColumnAttributesEnum.adColNullable;

                        //（12）Test_startp   -------  起测压力（ 滤芯的扩散流检测时的压力 ） -- 2 ;
                        table.Columns.Append("Test_startp", DataTypeEnum.adWChar, 100);
                        table.Columns["Test_startp"].Attributes = ColumnAttributesEnum.adColNullable;


                        //（13）Test_SetBp   -------   最小泡点     -- 2 ;
                        table.Columns.Append("Test_SetBp", DataTypeEnum.adWChar, 100);
                        table.Columns["Test_SetBp"].Attributes = ColumnAttributesEnum.adColNullable;

                        //（14）Test_Up_Volm  ------- 滤芯的上游体积  -- 4 ;
                        table.Columns.Append("Test_Up_Volm", DataTypeEnum.adWChar, 100);
                        table.Columns["Test_Up_Volm"].Attributes = ColumnAttributesEnum.adColNullable;


                        //（15）Test_Dif_max   -------   最大扩散流   -- 2  ；
                        table.Columns.Append("Test_Dif_max", DataTypeEnum.adWChar, 100);
                        table.Columns["Test_Dif_max"].Attributes = ColumnAttributesEnum.adColNullable;

                        //（16）Htest_DifValue    -------   测试值1 （扩散流量）-- 2  ；
                        table.Columns.Append("Htest_DifValue", DataTypeEnum.adWChar, 100);
                        table.Columns["Htest_DifValue"].Attributes = ColumnAttributesEnum.adColNullable;

                        //（17）Htest_TestValue    -------   测试值2 （泡点值）-- 2  ；
                        table.Columns.Append("Htest_Value", DataTypeEnum.adWChar, 100);
                        table.Columns["Htest_Value"].Attributes = ColumnAttributesEnum.adColNullable;

                        //（18）Test_Filter_Area   -------  过滤面积           -- 4    ;
                        table.Columns.Append("Test_Filter_Area", DataTypeEnum.adWChar, 100);
                        table.Columns["Test_Filter_Area"].Attributes = ColumnAttributesEnum.adColNullable;


                        //（19）Test_Meme_Aper  -------  过滤材料的孔径（精度）      -- 2  ;
                        table.Columns.Append("Test_Meme_Aper", DataTypeEnum.adWChar, 100);
                        table.Columns["Test_Meme_Aper"].Attributes = ColumnAttributesEnum.adColNullable;


                        //（20）Test_Filter_type ------- 测量用过滤器的种类(筒式/平板/囊式/其它) -- 1 ;
                        table.Columns.Append("Test_Filter_type", DataTypeEnum.adWChar, 100);
                        table.Columns["Test_Filter_type"].Attributes = ColumnAttributesEnum.adColNullable;


                        //（21）Htest_DiffePress ------ 测试的压力衰减值 ；（自检测试，压力衰减）-- 2；
                        table.Columns.Append("Htest_DiffePress", DataTypeEnum.adWChar, 100);
                        table.Columns["Htest_DiffePress"].Attributes = ColumnAttributesEnum.adColNullable;

                        //（22）Test_CDifValue  ------- 用于计算的最大扩散流  -- 2;
                        table.Columns.Append("Test_CDifValue", DataTypeEnum.adWChar, 100);
                        table.Columns["Test_CDifValue"].Attributes = ColumnAttributesEnum.adColNullable;

                        //（23）Htest_testimes  -------   曲线的采样次数  -- 1 ;固定为61次
                        table.Columns.Append("Test_testimes", DataTypeEnum.adWChar, 100);
                        table.Columns["Test_testimes"].Attributes = ColumnAttributesEnum.adColNullable;

                        //（24）Test_Sampling_Frequency  ------- 曲线的采样点的频率  -- 2 ;
                        table.Columns.Append("Test_Sampling_Frequency", DataTypeEnum.adWChar, 100);
                        table.Columns["Test_Sampling_Frequency"].Attributes = ColumnAttributesEnum.adColNullable;


                        //（25）Htest_DifStart ------ 曲线的采样数组中扩散流的起始位置-- 2；
                        table.Columns.Append("Htest_DifStart", DataTypeEnum.adWChar, 100);
                        table.Columns["Htest_DifStart"].Attributes = ColumnAttributesEnum.adColNullable;


                        //（26）Htest_Name    -------   测试人员名   -- 16 ；
                        table.Columns.Append("Htest_Name", DataTypeEnum.adWChar, 100);
                        table.Columns["Htest_Name"].Attributes = ColumnAttributesEnum.adColNullable;


                        //（25）Htest_Press_Line ------ 压力的曲线值-- 2；
                        table.Columns.Append("Htest_Press_Line", DataTypeEnum.adWChar, 250);
                        table.Columns["Htest_Press_Line"].Attributes = ColumnAttributesEnum.adColNullable;


                        //（26）Htest_Dif_Line    -------   扩散流的曲线值   -- 16 ；
                        table.Columns.Append("Htest_Dif_Line", DataTypeEnum.adWChar, 250);
                        table.Columns["Htest_Dif_Line"].Attributes = ColumnAttributesEnum.adColNullable;

                        //曲线的点
                        try
                        {
                            catalog.Tables.Append(table);
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        //此处一定要关闭连接，否则添加数据时候会出错

                        table = null;

                        catalog = null;

                        Application.DoEvents();
                    }
                }
                mConnection.Close();
                cn.Close();

                //新建设备参数数据库表


                ADOX.Catalog mCatalog = new Catalog();
                ADODB.Connection mCn = new ADODB.Connection();
                string sAccessConnectionSystemParameter = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\SystemParameter.mdb";
                mConnectionSystemParameter = new OleDbConnection(sAccessConnectionSystemParameter);
                mConnectionSystemParameter.Open();
                mCn.Open(sAccessConnectionSystemParameter, null, null, -1);
                mCatalog.ActiveConnection = mCn;
                if (!string.IsNullOrEmpty(CCN.DeviceNameId1))
                {
                    bool flag = CCN.GetTables(mConnectionSystemParameter);
                    if (!flag)//判断表名是否存在
                    {

                        ADOX.Table table = new ADOX.Table();

                        table.Name = CCN.DeviceNameId1;
                        ADOX.Column column = new ADOX.Column();
                        column.ParentCatalog = mCatalog;
                        column.Name = "SystemParameter";
                        column.Type = DataTypeEnum.adInteger;
                        column.DefinedSize = 9;
                        //column.Properties["AutoIncrement"].Value = true;
                        //column.Properties["Jet OLEDB:Allow Zero Length"].Value = true;
                        table.Columns.Append(column, DataTypeEnum.adInteger, 9);
                        //ADOX.Column column = new ADOX.Column();
                        table.Keys.Append("FirstTablePrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);
                        //                        //------------------------------------------------------------------------------------------------------------------
                        //struct filter_Difmax_Param               // ------ (12) 10“各种滤材的最大扩散流参数
                        //{
                        //  unsigned short     PES_Dif_max          ;        // 单芯10“PES滤芯的最大扩散流                                -- 2
                        //  unsigned short     PVDF_Dif_max         ;        // 单芯10“聚偏氟乙烯滤芯的最大扩散流                         -- 2
                        //  unsigned short     PTFE_Dif_max         ;        // 单芯10“聚四氟乙烯（空气过滤）滤芯的最大扩散流             -- 2
                        //  unsigned short     NYLON_Dif_max        ;        // 单芯10“尼龙滤芯的最大扩散流                               -- 2
                        //  unsigned short     OTHER_Dif_max        ;        // 单芯10“其它材质的滤芯的最大扩散流                         -- 2
                        //  unsigned short     PTFE_flow_max        ;        // 滤单芯10“聚四氟乙烯（空气过滤-水浸入法）滤芯的最大流量    -- 2          
                        // } ;

                        table.Columns.Append("PES_Dif_max", DataTypeEnum.adWChar, 10);
                        table.Columns["PES_Dif_max"].Attributes = ColumnAttributesEnum.adColNullable;
                        table.Columns.Append("PVDF_Dif_max", DataTypeEnum.adWChar, 10);
                        table.Columns["PVDF_Dif_max"].Attributes = ColumnAttributesEnum.adColNullable;
                        table.Columns.Append("PTFE_Dif_max", DataTypeEnum.adWChar, 10);
                        table.Columns["PTFE_Dif_max"].Attributes = ColumnAttributesEnum.adColNullable;
                        table.Columns.Append("NYLON_Dif_max", DataTypeEnum.adWChar, 10);
                        table.Columns["NYLON_Dif_max"].Attributes = ColumnAttributesEnum.adColNullable;
                        table.Columns.Append("OTHER_Dif_max", DataTypeEnum.adWChar, 10);
                        table.Columns["OTHER_Dif_max"].Attributes = ColumnAttributesEnum.adColNullable;
                        //table.Columns.Append("PTFE_flow_max", DataTypeEnum.adWChar, 10);
                        //table.Columns["PTFE_flow_max"].Attributes = ColumnAttributesEnum.adColNullable;
                        //                        struct Device_Param              // ------ （18）设备的基本参数
                        //{
                        //  unsigned int      Inter_Volm          ;      // -----系统的内部体积          -- 4
                        //  unsigned int      Exter_Volm          ;      // -----外部缓冲罐的体积        -- 4
                        //  unsigned short    SourceP             ;      // -----外部的气源压力          -- 2
                        //  unsigned short    AddP_extent         ;      // -----对滤芯的压力增幅        -- 2
                        //  unsigned char     Print_Setup         ;      // -----打印设置                -- 1
                        //  unsigned char     Over_ModeSetup      ;      // -----测试结束的方式（泡点合格后测试结束的方式）  手动/自动   -- 1
                        //  unsigned char     Language_Setup      ;      // -----语言设置                -- 1
                        //  unsigned char     Default_Load        ;      // -----缺省值得加载            -- 1
                        //  unsigned char     InitTestPara        ;      // -----初始化测试参数          -- 1
                        //  unsigned char     Test_rate           ;      // -----测试速度的级别          -- 1
                        // } ;
                        //table.Columns.Append("Inter_Volm", DataTypeEnum.adInteger, 10);
                        //table.Columns["Inter_Volm"].Attributes = ColumnAttributesEnum.adColNullable;
                        table.Columns.Append("Exter_Volm", DataTypeEnum.adWChar, 10);
                        table.Columns["Exter_Volm"].Attributes = ColumnAttributesEnum.adColNullable;
                        table.Columns.Append("SourceP", DataTypeEnum.adWChar, 10);
                        table.Columns["SourceP"].Attributes = ColumnAttributesEnum.adColNullable;
                        table.Columns.Append("AddP_extent", DataTypeEnum.adWChar, 5);
                        table.Columns["AddP_extent"].Attributes = ColumnAttributesEnum.adColNullable;
                        table.Columns.Append("Print_Setup", DataTypeEnum.adWChar, 2);
                        table.Columns["Print_Setup"].Attributes = ColumnAttributesEnum.adColNullable;
                        table.Columns.Append("Over_ModeSetup", DataTypeEnum.adWChar, 2);
                        table.Columns["Over_ModeSetup"].Attributes = ColumnAttributesEnum.adColNullable;
                        table.Columns.Append("Language_Setup", DataTypeEnum.adWChar, 2);
                        table.Columns["Language_Setup"].Attributes = ColumnAttributesEnum.adColNullable;
                        table.Columns.Append("Default_Load", DataTypeEnum.adWChar, 2);
                        table.Columns["Default_Load"].Attributes = ColumnAttributesEnum.adColNullable;
                        table.Columns.Append("InitTestPara", DataTypeEnum.adWChar, 2);
                        table.Columns["InitTestPara"].Attributes = ColumnAttributesEnum.adColNullable;
                        //table.Columns.Append("Test_rate", DataTypeEnum.adWChar, 2);
                        //table.Columns["Test_rate"].Attributes = ColumnAttributesEnum.adColNullable;


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
                }
                mConnectionSystemParameter.Close();
                mCn.Close();
            }
            catch (Exception ex)
            {
                //LogClass.WriteLogFile("Exception:" + ex.ToString());
            }

        }
        #endregion
        #region 增加新设备
        private void CreateMouseLeft(object sender, EventArgs e)
        {
            try
            {
                CommunicationConnect CCN = new CommunicationConnect();
                CCN.ShowDialog();
                string title = CCN.DeviceNameId1;
                if (!string.IsNullOrEmpty(title))
                {

                    TreeNode t = new TreeNode();
                    t.Text = title;
                    t.ImageKey = imageList.Images[2].ToString();
                    t.SelectedImageKey = imageList.Images[5].ToString();
                    OprationSelectRss("AddML", title, null);
                    RssTreeView.SelectedNode.Nodes.Add(t);
                    RssTreeView.SelectedNode = t;
                    RssTreeView.Refresh();
                    CreatDB(CCN);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        #endregion
        #region 删除节点
        private void MouseDownDelete(object sender, EventArgs e)
        {
            try
            {
            //CommunicationConnect CCN = new CommunicationConnect();
                DialogResult dr = MessageBox.Show("Do you want to delete the [" + RssTreeView.SelectedNode.Text + "] node from Confirm?", "Tips", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == dr)
            {
                ADOX.Catalog catalog = new Catalog();
                ADODB.Connection cn = new ADODB.Connection();

                string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\TestHistoryData.mdb";
                mConnection = new OleDbConnection(sAccessConnection);
                mConnection.Open();
                cn.Open(sAccessConnection, null, null, -1);
                catalog.ActiveConnection = cn;
                if (!string.IsNullOrEmpty(this.RssTreeView.SelectedNode.Text))
                {
                    bool flag = mGetTables(mConnection);
                    if (flag)//判断表名是否存在
                    {


                        catalog.Tables.Delete(RssTreeView.SelectedNode.Text);
                    }
                }
                //此处一定要关闭连接，否则添加数据时候会出错

                catalog = null;
                Application.DoEvents();
                cn.Close();
                /////删除系统参数表
                ADOX.Catalog mCatalog = new Catalog();
                ADODB.Connection mCn = new ADODB.Connection();

                string sAccessConnectionSystemParameter = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\SystemParameter.mdb";
                mConnectionSystemParameter = new OleDbConnection(sAccessConnectionSystemParameter);
                mConnectionSystemParameter.Open();
                mCn.Open(sAccessConnectionSystemParameter, null, null, -1);
                mCatalog.ActiveConnection = mCn;
                if (!string.IsNullOrEmpty(this.RssTreeView.SelectedNode.Text))
                {
                    bool flag = mGetTables(mConnectionSystemParameter);
                    if (flag)//判断表名是否存在
                    {


                        mCatalog.Tables.Delete(RssTreeView.SelectedNode.Text);
                    }
                }
                //此处一定要关闭连接，否则添加数据时候会出错

                mCatalog = null;
                Application.DoEvents();
                mCn.Close();
                ////////
                ///删除设备
                ///////
                string mDeviceName = RssTreeView.SelectedNode.Text.ToString();
                string mTablemDeviceConcatenateParameter = "DeviceConcatenate";
                string mQueryDeviceConcatenateParameter = "delete * From {0} where DeviceName='{1}'";
                mQueryDeviceConcatenateParameter = string.Format(mQueryDeviceConcatenateParameter, mTablemDeviceConcatenateParameter, mDeviceName);

                mConnectionDeviceConcatenateParameter = new OleDbConnection(sAccessConnectionDeviceConcatenateParameter);



                OleDbCommand daDeviceConcatenateParameter = new OleDbCommand(mQueryDeviceConcatenateParameter, mConnectionDeviceConcatenateParameter);

                try
                {
                    mConnectionDeviceConcatenateParameter.Open();
                    daDeviceConcatenateParameter.ExecuteNonQuery();



                }

                catch (Exception ex)
                {

                    MessageBox.Show("Exception:" + ex.ToString(), "Tips");

                }

                finally
                {

                    mConnectionDeviceConcatenateParameter.Close();

                }

                OprationSelectRss("Del", null, null);

                RssTreeView.Nodes.Remove(RssTreeView.SelectedNode);
                RssTreeView.Refresh();
          
                  
            }
            MTreeName = string.Format("{0}", this.RssTreeView.SelectedNode.Text);
            /// <summary>
            /// 重新轮询查询
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            OleDbConnection mConnectionDeviceConcatenateParameterMDB;
            string sAccessConnectionDeviceConcatenateParameterMDB = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\DeviceConcatenate.mdb";
            string MQuery = "Select DeviceAddress From DeviceConcatenate";
            mConnectionDeviceConcatenateParameterMDB = new OleDbConnection(sAccessConnectionDeviceConcatenateParameterMDB);

            mPollingInquiry.Clear();

            try
            {

                mConnectionDeviceConcatenateParameterMDB.Open();
                OleDbCommand cmd = new OleDbCommand(MQuery, mConnectionDeviceConcatenateParameterMDB);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mPollingInquiry.Add(reader[0]);
                }
                reader.Close();
            }

            catch (Exception ex)
            {

                MessageBox.Show("Exception:" + ex.ToString(), "Tips");

            }

            finally
            {


                mConnectionDeviceConcatenateParameterMDB.Close();

            }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        #endregion 
        #region 修改节点名称
        ///// <summary>
///// 重命名Device Name同时修改数据库的表名
///// </summary>
///// <param name="sender"></param>
///// <param name="e"></param>
//        private void EditRename(object sender, EventArgs e)
//        {

//            CommunicationConnect CCN = new CommunicationConnect();
//            CCN.ShowDialog();
//            //string title = CCN.DeviceNameId1;

//           if (!string.IsNullOrEmpty(CCN.DeviceNameId1))
//                {

//                //string TableName = RssTreeView.SelectedNode.Text;
//                ADOX.Catalog catalog = new Catalog();
//                ADODB.Connection cn = new ADODB.Connection();

//                string sAccessConnection = @"Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\TestHistoryData.mdb";
//                mConnection = new OleDbConnection(sAccessConnection);
//                mConnection.Open();
//                cn.Open(sAccessConnection, null, null, -1);
//                catalog.ActiveConnection = cn;
                

//                    bool flag = CCN.GetTables(mConnection);
//                    if (!flag)//判断表名是否存在
//                    {
//                        string title=CCN.DeviceNameId1;
//                        ADOX.Table table = new ADOX.Table();
//                        string TableName = RssTreeView.SelectedNode.Text;
//                        table = catalog.Tables[TableName]; //要重命名的表名:OldTable
//                        table.Name = title;//新表名
//                        table.DateModified();
//                    }
//                    //}
//                    catalog = null;
//                    Application.DoEvents();
//                    cn.Close();
//                    mConnection.Close();


//                    ADOX.Catalog mCatalog = new Catalog();
//                    ADODB.Connection mCn = new ADODB.Connection();
//                    string sAccessConnectionSystemParameter = @"Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\SystemParameter.mdb";
//                    mConnectionSystemParameter = new OleDbConnection(sAccessConnectionSystemParameter);
//                    mConnectionSystemParameter.Open();
//                    mCn.Open(sAccessConnectionSystemParameter, null, null, -1);
//                    mCatalog.ActiveConnection = mCn;
//                    //if (!string.IsNullOrEmpty(CCN.DeviceNameId1))
//                    //{
//                    bool mflag = CCN.GetTablesSP(mConnectionSystemParameter);
//                    if (!mflag)//判断表名是否存在
//                    {
//                        ADOX.Table table = new ADOX.Table();
//                        string title=CCN.DeviceNameId1;
//                        string TableName = RssTreeView.SelectedNode.Text;
//                        table = mCatalog.Tables[TableName]; //要重命名的表名:OldTable
//                        table.Name = title;//新表名
//                        table.DateModified();
//                    }
//                    //}
//                    mCatalog = null;
//                    Application.DoEvents();
//                    mCn.Close();

//                    mConnectionSystemParameter.Close();


//                    string mTitle = CCN.DeviceNameId1;
//                    OprationSelectRss("Rename", mTitle, null);
//                    RssTreeView.SelectedNode.Text = mTitle;
//                    RssTreeView.Refresh();

//                }



        //        }
        #endregion
        #region 增加同层节点
        private void AddNode(object sender, EventArgs e)
        {
            try
            {
            CommunicationConnect CCN = new CommunicationConnect();
            CCN.ShowDialog();
            string title = CCN.DeviceNameId1;
            if (!string.IsNullOrEmpty(title))
            {
                TreeNode r = new TreeNode();
                r.Text = title;


                r.ImageKey = imageList.Images[2].ToString();
                r.SelectedImageKey = imageList.Images[2].ToString();
                OprationSelectRss("AddM", title, null);

                RssTreeView.SelectedNode.Parent.Nodes.Add(r);
                RssTreeView.SelectedNode = r;
                RssTreeView.Refresh();

            }
            CreatDB(CCN);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
            
        }
        #endregion
        #region 所有的菜单相应事件
        /// <summary>
        /// 菜单的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


 

       

        private void toolHistoricalRecords_Click(object sender, EventArgs e)
        {
            try
            {
            BasicBubblePoint.BacicBubble = null;
            ManualBubblePoint.MManualBubblePoint = null;
            RateOfRise.MRateOfRise = null;
            WaterImmersionTest.MWaterImmersionTest = null;
            StrengthenTheBubble.MStrengthenTheBubble = null;
            HistoricalRecords mHR = new HistoricalRecords();
            mHR.FormBorderStyle = FormBorderStyle.None;
            mHR.TopLevel = false;
            mHR.Dock = DockStyle.Fill;
            this.MyPanel.Controls.Clear();
            this.MyPanel.Controls.Add(mHR);
            mHR.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }

       

        private void toolSystemParameter_Click(object sender, EventArgs e)
        {
            try
            {
                BasicBubblePoint.BacicBubble = null;
                
                ManualBubblePoint.MManualBubblePoint = null;
                RateOfRise.MRateOfRise = null;
                WaterImmersionTest.MWaterImmersionTest = null;
                StrengthenTheBubble.MStrengthenTheBubble = null;
                mSystemParameter mSP = new mSystemParameter();
                mSP.FormBorderStyle = FormBorderStyle.None;
                mSP.TopLevel = false;
                mSP.Dock = DockStyle.Fill;
                this.MyPanel.Controls.Clear();
                this.MyPanel.Controls.Add(mSP);
                mSP.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }

        private void toolLog_Click(object sender, EventArgs e)
        {
            try
            {

            BasicBubblePoint.BacicBubble = null;
          
            ManualBubblePoint.MManualBubblePoint = null;
            RateOfRise.MRateOfRise = null;
            WaterImmersionTest.MWaterImmersionTest = null;
            StrengthenTheBubble.MStrengthenTheBubble = null;
            Login mLogin = new Login();
            mLogin.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 基本泡点的菜单按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasicBubbleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

            BasicBubblePoint.BacicBubble = null;
           
            ManualBubblePoint.MManualBubblePoint = null;
            RateOfRise.MRateOfRise = null;
            WaterImmersionTest.MWaterImmersionTest = null;
            StrengthenTheBubble.MStrengthenTheBubble = null;
            BasicBubblePoint mBacicBubble = new BasicBubblePoint();
            mBacicBubble.TopLevel = false;
            mBacicBubble.FormBorderStyle = FormBorderStyle.None;
            mBacicBubble.Dock = DockStyle.Fill;
            this.MyPanel.Controls.Clear();
            this.MyPanel.Controls.Add(mBacicBubble);
           
            mBacicBubble.Show();

            BasicBubblePoint.BacicBubble = mBacicBubble;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
            
        }
        /// <summary>
        /// 手动泡点的菜单响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManualBubbleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

            BasicBubblePoint.BacicBubble = null;
          
            ManualBubblePoint.MManualBubblePoint = null;
            RateOfRise.MRateOfRise = null;
            WaterImmersionTest.MWaterImmersionTest = null;
            StrengthenTheBubble.MStrengthenTheBubble = null;
            ManualBubblePoint mManualBubblePoint = new ManualBubblePoint();
            mManualBubblePoint.TopLevel = false;
            mManualBubblePoint.FormBorderStyle = FormBorderStyle.None;
            mManualBubblePoint.Dock = DockStyle.Fill;
            this.MyPanel.Controls.Clear();
            this.MyPanel.Controls.Add(mManualBubblePoint);
            mManualBubblePoint.Show();
            ManualBubblePoint.MManualBubblePoint = mManualBubblePoint;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 增强泡点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StrengthenTheBubbleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BasicBubblePoint.BacicBubble = null;
             
                ManualBubblePoint.MManualBubblePoint = null;
                RateOfRise.MRateOfRise = null;
                WaterImmersionTest.MWaterImmersionTest = null;
                StrengthenTheBubble.MStrengthenTheBubble = null;
                StrengthenTheBubble mStrengthenTheBubble = new StrengthenTheBubble();
                mStrengthenTheBubble.TopLevel = false;
                mStrengthenTheBubble.FormBorderStyle = FormBorderStyle.None;
                mStrengthenTheBubble.Dock = DockStyle.Fill;
                this.MyPanel.Controls.Clear();
                this.MyPanel.Controls.Add(mStrengthenTheBubble);
                mStrengthenTheBubble.Show();
                StrengthenTheBubble.MStrengthenTheBubble = mStrengthenTheBubble;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// Pressure Holding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RateOfRiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
            BasicBubblePoint.BacicBubble = null;
           
            ManualBubblePoint.MManualBubblePoint = null;
            RateOfRise.MRateOfRise = null;
            WaterImmersionTest.MWaterImmersionTest = null;
            StrengthenTheBubble.MStrengthenTheBubble = null;
            RateOfRise mRateOfRise = new RateOfRise();
            mRateOfRise.TopLevel = false;
            mRateOfRise.FormBorderStyle = FormBorderStyle.None;
            mRateOfRise.Dock = DockStyle.Fill;
            this.MyPanel.Controls.Clear();
            this.MyPanel.Controls.Add(mRateOfRise);
            mRateOfRise.Show();
            RateOfRise.MRateOfRise = mRateOfRise;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// DF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiffusionFlowCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
            BasicBubblePoint.BacicBubble = null;
          
            ManualBubblePoint.MManualBubblePoint = null;
            RateOfRise.MRateOfRise = null;
            WaterImmersionTest.MWaterImmersionTest = null;
            StrengthenTheBubble.MStrengthenTheBubble = null;
            DfTestMode mDiffusionFlowCheck = new DfTestMode();
            mDiffusionFlowCheck.TopLevel = false;
            mDiffusionFlowCheck.FormBorderStyle = FormBorderStyle.None;
            mDiffusionFlowCheck.Dock = DockStyle.Fill;
            this.MyPanel.Controls.Clear();
            this.MyPanel.Controls.Add(mDiffusionFlowCheck);
            mDiffusionFlowCheck.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }

        public void DFlowTest()
        {
            try
            {
                BasicBubblePoint.BacicBubble = null;
                DiffusionFlowCheck.mDiffusionFlowCheck = null;
                ManualBubblePoint.MManualBubblePoint = null;
                RateOfRise.MRateOfRise = null;
                WaterImmersionTest.MWaterImmersionTest = null;
                StrengthenTheBubble.MStrengthenTheBubble = null;
                DiffusionFlowCheck mDiffusionFlowCheck = new DiffusionFlowCheck();
                mDiffusionFlowCheck.TopLevel = false;
                mDiffusionFlowCheck.FormBorderStyle = FormBorderStyle.None;
                mDiffusionFlowCheck.Dock = DockStyle.Fill;
                this.MyPanel.Controls.Clear();
                this.MyPanel.Controls.Add(mDiffusionFlowCheck);
                mDiffusionFlowCheck.Show();
                DiffusionFlowCheck.mDiffusionFlowCheck = mDiffusionFlowCheck;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }

        public void DFlowExTest()
        {
            try
            {
                BasicBubblePoint.BacicBubble = null;
                DiffusionFlowCheckEx.mDiffusionFlowCheck = null;
                ManualBubblePoint.MManualBubblePoint = null;
                RateOfRise.MRateOfRise = null;
                WaterImmersionTest.MWaterImmersionTest = null;
                StrengthenTheBubble.MStrengthenTheBubble = null;
                DiffusionFlowCheckEx mDiffusionFlowCheckEx = new DiffusionFlowCheckEx();
                mDiffusionFlowCheckEx.TopLevel = false;
                mDiffusionFlowCheckEx.FormBorderStyle = FormBorderStyle.None;
                mDiffusionFlowCheckEx.Dock = DockStyle.Fill;
                this.MyPanel.Controls.Clear();
                this.MyPanel.Controls.Add(mDiffusionFlowCheckEx);
                mDiffusionFlowCheckEx.Show();
                //DiffusionFlowCheckEx.mDiffusionFlowCheck = mDiffusionFlowCheckEx;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// Water侵入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaterImmersionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Main mMainF=new Main();
                BasicBubblePoint.BacicBubble = null;
             
                ManualBubblePoint.MManualBubblePoint = null;
                RateOfRise.MRateOfRise = null;
                WaterImmersionTest.MWaterImmersionTest = null;
                StrengthenTheBubble.MStrengthenTheBubble = null;
                WaterImmersionTest mWaterImmersionTest = new WaterImmersionTest();
                mWaterImmersionTest.TopLevel = false;
                mWaterImmersionTest.FormBorderStyle = FormBorderStyle.None;
                mWaterImmersionTest.Dock = DockStyle.Fill;
                this.MyPanel.Controls.Clear();
               

                this.MyPanel.Controls.Add(mWaterImmersionTest);
                mWaterImmersionTest.Show();
                WaterImmersionTest.MWaterImmersionTest = mWaterImmersionTest;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }

       
        /// <summary>
        /// 显示Time
         /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerMainStatus_Tick(object sender, EventArgs e)
        {
            try
            {
                this.MainToolStripStatusLabel.Text = "System Current Time:" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "   Choosed Instrument:" + MTreeName + USB.mUSBState;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        #endregion
        #region 串口操作
        /// <summary>
        /// 串口操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       

        // delegate used for Invoke
        internal delegate void StringDelegate(string data);
        /// <summary>
        /// Update the connection status
        /// </summary>

        public void OnStatusChanged(string status)
        {
            try
            {
           
            //Handle multi-threading
            if (InvokeRequired)
            {
                Invoke(new StringDelegate(OnStatusChanged), new object[] { status });
                return;
            }
            this.toolStripStatusLabel1.Text = String.Format("Serial port for State:{0}", status);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
            

        }

        #endregion
        #region 菜单操作
        /// <summary>
        /// 菜单操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        /// 新建操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemNew_Click(object sender, EventArgs e)
        {
            try
            {
            if (this.RssTreeView.SelectedNode.Text == "NodeList")
            {
                #region 增加新设备

                CommunicationConnect CCN = new CommunicationConnect();
                CCN.ShowDialog();
                string title = CCN.DeviceNameId1;
                if (!string.IsNullOrEmpty(title))
                {

                    TreeNode t = new TreeNode();
                    t.Text = title;
                    t.ImageKey = imageList.Images[2].ToString();
                    t.SelectedImageKey = imageList.Images[5].ToString();
                    OprationSelectRss("AddML", title, null);
                    RssTreeView.SelectedNode.Nodes.Add(t);
                    RssTreeView.SelectedNode = t;
                    RssTreeView.Refresh();
                    CreatDB(CCN);
                }

                #endregion
            }


            if (MTreeName != "Can not be empty" || this.RssTreeView.SelectedNode.Text == "NodeList")
            {

                #region 增加同层节点

                CommunicationConnect CCN = new CommunicationConnect();
                CCN.ShowDialog();
                string title = CCN.DeviceNameId1;
                if (!string.IsNullOrEmpty(title))
                {
                    TreeNode r = new TreeNode();
                    r.Text = title;


                    r.ImageKey = imageList.Images[2].ToString();
                    r.SelectedImageKey = imageList.Images[2].ToString();
                    OprationSelectRss("AddM", title, null);

                    RssTreeView.SelectedNode.Parent.Nodes.Add(r);
                    RssTreeView.SelectedNode = r;
                    RssTreeView.Refresh();

                }
                ADOX.Catalog catalog = new Catalog();
                ADODB.Connection cn = new ADODB.Connection();


                string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\TestHistoryData.mdb";
                mConnection = new OleDbConnection(sAccessConnection);
                mConnection.Open();
                cn.Open(sAccessConnection, null, null, -1);
                catalog.ActiveConnection = cn;
                if (!string.IsNullOrEmpty(CCN.DeviceNameId1))
                {
                    bool flag = CCN.GetTables(mConnection);
                    if (!flag)//判断表名是否存在
                    {

                        CreatDB(CCN);
                    }

                #endregion

                }

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
      

        private void ToolStripMenuItemDelet_Click(object sender, EventArgs e)
        {
            try
            {
            if (this.RssTreeView.SelectedNode.Text != "NodeList" || MTreeName == "Can not be empty")
            {
           
                //CommunicationConnect CCN = new CommunicationConnect();
                DialogResult dr = MessageBox.Show("Do you want to delete the [" + RssTreeView.SelectedNode.Text + "] node from Confirm?", "Tips", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == dr)
                {
                    ADOX.Catalog catalog = new Catalog();
                    ADODB.Connection cn = new ADODB.Connection();

                    string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\TestHistoryData.mdb";
                    mConnection = new OleDbConnection(sAccessConnection);
                    mConnection.Open();
                    cn.Open(sAccessConnection, null, null, -1);
                    catalog.ActiveConnection = cn;
                    if (!string.IsNullOrEmpty(this.RssTreeView.SelectedNode.Text))
                    {
                        bool flag = mGetTables(mConnection);
                        if (flag)//判断表名是否存在
                        {


                            catalog.Tables.Delete(RssTreeView.SelectedNode.Text);
                        }
                    }
                    //此处一定要关闭连接，否则添加数据时候会出错

                    catalog = null;
                    Application.DoEvents();
                    cn.Close();
                    /////删除系统参数表
                    ADOX.Catalog mCatalog = new Catalog();
                    ADODB.Connection mCn = new ADODB.Connection();

                    string sAccessConnectionSystemParameter = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\SystemParameter.mdb";
                    mConnectionSystemParameter = new OleDbConnection(sAccessConnectionSystemParameter);
                    mConnectionSystemParameter.Open();
                    mCn.Open(sAccessConnectionSystemParameter, null, null, -1);
                    mCatalog.ActiveConnection = mCn;
                    if (!string.IsNullOrEmpty(this.RssTreeView.SelectedNode.Text))
                    {
                        bool flag = mGetTables(mConnectionSystemParameter);
                        if (flag)//判断表名是否存在
                        {


                            mCatalog.Tables.Delete(RssTreeView.SelectedNode.Text);
                        }
                    }
                    //此处一定要关闭连接，否则添加数据时候会出错

                    mCatalog = null;
                    Application.DoEvents();
                    mCn.Close();
                    ////////
                    ///删除设备
                    ///////
                    string mDeviceName = RssTreeView.SelectedNode.Text.ToString();
                    string mTablemDeviceConcatenateParameter = "DeviceConcatenate";
                    string mQueryDeviceConcatenateParameter = "delete * From {0} where DeviceName='{1}'";
                    mQueryDeviceConcatenateParameter = string.Format(mQueryDeviceConcatenateParameter, mTablemDeviceConcatenateParameter, mDeviceName);

                    mConnectionDeviceConcatenateParameter = new OleDbConnection(sAccessConnectionDeviceConcatenateParameter);



                    OleDbCommand daDeviceConcatenateParameter = new OleDbCommand(mQueryDeviceConcatenateParameter, mConnectionDeviceConcatenateParameter);

                    try
                    {
                        mConnectionDeviceConcatenateParameter.Open();
                        daDeviceConcatenateParameter.ExecuteNonQuery();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception:" + ex.ToString(), "Tips");
                    }

                    finally
                    {
                        mConnectionDeviceConcatenateParameter.Close();
                    }

                    OprationSelectRss("Del", null, null);

                    RssTreeView.Nodes.Remove(RssTreeView.SelectedNode);
                    RssTreeView.Refresh();

                }
                MTreeName = string.Format("{0}", this.RssTreeView.SelectedNode.Text);

                /// <summary>
                /// 重新轮询查询
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                OleDbConnection mConnectionDeviceConcatenateParameterMDB;
                string sAccessConnectionDeviceConcatenateParameterMDB = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\DeviceConcatenate.mdb";
                string MQuery = "Select DeviceAddress From DeviceConcatenate";
                mConnectionDeviceConcatenateParameterMDB = new OleDbConnection(sAccessConnectionDeviceConcatenateParameterMDB);

                mPollingInquiry.Clear();

                try
                {

                    mConnectionDeviceConcatenateParameterMDB.Open();
                    OleDbCommand cmd = new OleDbCommand(MQuery, mConnectionDeviceConcatenateParameterMDB);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        mPollingInquiry.Add(reader[0]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception:" + ex.ToString(), "Tips");
                }
                finally
                {
                    mConnectionDeviceConcatenateParameterMDB.Close();
                }
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
            
        }
        /// <summary>
        /// 退出软件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ToolStripMenuItemQuit_Click(object sender, EventArgs e)
        {
            try
            {
                  DialogResult dr = MessageBox.Show("Do you want Confirm to quit the application！", "Tips", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                  if (DialogResult.Yes == dr)
                  {
                      this.Close();
                  }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 打开帮助文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemHelp_Click(object sender, EventArgs e)
        {
            try
            {
            Help.ShowHelp(new Control(), @"..\..\Help\Help.chm");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }

        private void ToolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            try
            {
            About mAbout = new About();
            mAbout.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 打印关联
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemPrint_Click(object sender, EventArgs e)
        {
            try
            {
            /// <summary>
            /// 基本泡点打印
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            
            
            if (BasicBubblePoint.BacicBubble != null)
            {
                if (BasicBubblePoint.BacicBubble.tabControlBasicBubblePoint.SelectedTab == BasicBubblePoint.BacicBubble.tabControlBasicBubblePointChart)
                {
                    if (BasicBubblePoint.BacicBubble.tabControlChart.SelectedTab == BasicBubblePoint.BacicBubble.tabPagePressureAndTime)
                    {
                        BasicBubblePoint.BacicBubble.BasicBubbleZedGraphControlPTime.DoPrint();
                    }
                    if (BasicBubblePoint.BacicBubble.tabControlChart.SelectedTab == BasicBubblePoint.BacicBubble.tabPageDifAndPressure)
                    {
                        BasicBubblePoint.BacicBubble.BasicBubbleZedGraphControlFP.DoPrint();
                    }
                }
            }
            /// <summary>
            /// DF打印
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            if (DiffusionFlowCheck.mDiffusionFlowCheck != null)
            {
                if (DiffusionFlowCheck.mDiffusionFlowCheck.tabControlDiffusionFlowCheck.SelectedTab == DiffusionFlowCheck.mDiffusionFlowCheck.tabPageDiffusionFlowCheckChart)
                {
                    if (DiffusionFlowCheck.mDiffusionFlowCheck.tabControlChart.SelectedTab == DiffusionFlowCheck.mDiffusionFlowCheck.tabPagePressureAndTime)
                    {
                        DiffusionFlowCheck.mDiffusionFlowCheck.DiffusionFlowCheckZedGraphControlPTime.DoPrint();
                    }
                    if (DiffusionFlowCheck.mDiffusionFlowCheck.tabControlChart.SelectedTab == DiffusionFlowCheck.mDiffusionFlowCheck.tabPageDifAndPressure)
                    {
                        DiffusionFlowCheck.mDiffusionFlowCheck.DiffusionFlowCheckZedGraphControlFP.DoPrint();
                    }
                }
            }
            /// <summary>
            /// 手动泡点打印
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            if (ManualBubblePoint.MManualBubblePoint != null)
            {
                if (ManualBubblePoint.MManualBubblePoint.tabControlManualBubblePoint.SelectedTab == ManualBubblePoint.MManualBubblePoint.tabPageManualBubblePointChart)
                {
                    if (ManualBubblePoint.MManualBubblePoint.tabControlChart.SelectedTab == ManualBubblePoint.MManualBubblePoint.tabPagePressureAndTime)
                    {
                        ManualBubblePoint.MManualBubblePoint.ManualBubblePointZedGraphControlPTime.DoPrint();
                    }
                    if (ManualBubblePoint.MManualBubblePoint.tabControlChart.SelectedTab == ManualBubblePoint.MManualBubblePoint.tabPageDifAndPressure)
                    {
                        ManualBubblePoint.MManualBubblePoint.ManualBubblePointZedGraphControlFP.DoPrint();
                    }
                }
            }
            /// <summary>
            /// Pressure Holding打印
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            if (RateOfRise.MRateOfRise != null)
            {
                if (RateOfRise.MRateOfRise.tabControlRateOfRise.SelectedTab == RateOfRise.MRateOfRise.tabPageRateOfRiseChart)
                {
                    if (RateOfRise.MRateOfRise.tabControlChart.SelectedTab == RateOfRise.MRateOfRise.tabPagePressureAndTime)
                    {
                        RateOfRise.MRateOfRise.RateOfRiseZedGraphControlPTime.DoPrint();
                    }
                    if (RateOfRise.MRateOfRise.tabControlChart.SelectedTab == RateOfRise.MRateOfRise.tabPageDifAndPressure)
                    {
                        RateOfRise.MRateOfRise.RateOfRiseZedGraphControlFP.DoPrint();
                    }
                }
            }
            /// <summary>
            /// Water Immersion 打印
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            if (WaterImmersionTest.MWaterImmersionTest != null)
            {
                if (WaterImmersionTest.MWaterImmersionTest.tabControlWaterImmersionTest.SelectedTab == WaterImmersionTest.MWaterImmersionTest.tabPageWaterImmersionTestChart)
                {
                    if (WaterImmersionTest.MWaterImmersionTest.tabControlChart.SelectedTab == WaterImmersionTest.MWaterImmersionTest.tabPagePressureAndTime)
                    {
                        WaterImmersionTest.MWaterImmersionTest.WaterImmersionTestZedGraphControlPTime.DoPrint();
                    }
                    if (WaterImmersionTest.MWaterImmersionTest.tabControlChart.SelectedTab == WaterImmersionTest.MWaterImmersionTest.tabPageDifAndPressure)
                    {
                        WaterImmersionTest.MWaterImmersionTest.WaterImmersionTestZedGraphControlFP.DoPrint();
                    }
                }
            }
            /// <summary>
            /// Extensive Bubble Point
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            if (StrengthenTheBubble.MStrengthenTheBubble != null)
            {
                if (StrengthenTheBubble.MStrengthenTheBubble.tabControlStrengthenTheBubble.SelectedTab == StrengthenTheBubble.MStrengthenTheBubble.tabPageStrengthenTheBubbleChart)
                {
                    if (StrengthenTheBubble.MStrengthenTheBubble.tabControlChart.SelectedTab == StrengthenTheBubble.MStrengthenTheBubble.tabPagePressureAndTime)
                    {
                        StrengthenTheBubble.MStrengthenTheBubble.StrengthenTheBubbleZedGraphControlPTime.DoPrint();
                        
                    }
                    if (StrengthenTheBubble.MStrengthenTheBubble.tabControlChart.SelectedTab == StrengthenTheBubble.MStrengthenTheBubble.tabPageDifAndPressure)
                    {
                        StrengthenTheBubble.MStrengthenTheBubble.StrengthenTheBubbleZedGraphControlFP.DoPrint();
                       
                    }
                }
            }
           
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }


       

        private void pictureBoxHelp_Click(object sender, EventArgs e)
        {
            try
            {
                About mAbout = new About();
                mAbout.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
        
            try
            {
                OleDbConnection mConnection;
                string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\DeviceConcatenate.mdb";
                foreach (int o in mPollingInquiry)
                {

                   
                    string mQuery = "update DeviceConcatenate set [mStatFlagBP]='" + (1).ToString() + "',[mStatFlagMP]='" + (1).ToString() + "',[mStatFlagRR]='" + (1).ToString() + "',[mStatFlagDF]='" + (1).ToString() + "',[mStatFlagWI]='" + (1).ToString() + "',[mStatFlagSP]='" + (1).ToString() + "' where CStr(DeviceAddress)='" + (o).ToString() + "'";
                  

                    mConnection = new OleDbConnection(sAccessConnection);

                    OleDbCommand da = new OleDbCommand(mQuery, mConnection);


                    mConnection.Open();
                    da.ExecuteNonQuery();

                    mConnection.Close();

                }
               
            CommPort com = CommPort.Instance;

            if (com.IsOpen == true)
            {
                com.Close();
            }
            System.Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
    

        }

        private void ToolStripMenuItemCommunication_Click(object sender, EventArgs e)
        {
            try
            {
            Communication mCommunication = new Communication();
            mCommunication.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        #endregion
        #region Import和Export
        /// <summary>
/// Import和Export
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void ToolStripMenuItemImport_Click(object sender, EventArgs e)
        {
            try
            {
            Import mImport = new Import();
            mImport.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }

        private void ToolStripMenuItemExport_Click(object sender, EventArgs e)
        {
            try
            {
            Export mExport = new Export();
            mExport.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }


        #endregion

        #region 工具栏
        /// <summary>
        /// 通信方式的选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxCommunication_Click(object sender, EventArgs e)
        {
            try
            {
            Communication mCommunication = new Communication();
            mCommunication.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxPrint_Click(object sender, EventArgs e)
        {
            try
            {
            /// <summary>
            /// 基本泡点打印
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            if (BasicBubblePoint.BacicBubble != null)
            {
                if (BasicBubblePoint.BacicBubble.tabControlBasicBubblePoint.SelectedTab == BasicBubblePoint.BacicBubble.tabControlBasicBubblePointChart)
                {
                    if (BasicBubblePoint.BacicBubble.tabControlChart.SelectedTab == BasicBubblePoint.BacicBubble.tabPagePressureAndTime)
                    {
                        BasicBubblePoint.BacicBubble.BasicBubbleZedGraphControlPTime.DoPrint();
                    }
                    if (BasicBubblePoint.BacicBubble.tabControlChart.SelectedTab == BasicBubblePoint.BacicBubble.tabPageDifAndPressure)
                    {
                        BasicBubblePoint.BacicBubble.BasicBubbleZedGraphControlFP.DoPrint();
                    }
                }
            }
            /// <summary>
            /// DF打印
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            if (DiffusionFlowCheck.mDiffusionFlowCheck != null)
            {
                if (DiffusionFlowCheck.mDiffusionFlowCheck.tabControlDiffusionFlowCheck.SelectedTab == DiffusionFlowCheck.mDiffusionFlowCheck.tabPageDiffusionFlowCheckChart)
                {
                    if (DiffusionFlowCheck.mDiffusionFlowCheck.tabControlChart.SelectedTab == DiffusionFlowCheck.mDiffusionFlowCheck.tabPagePressureAndTime)
                    {
                        DiffusionFlowCheck.mDiffusionFlowCheck.DiffusionFlowCheckZedGraphControlPTime.DoPrint();
                    }
                    if (DiffusionFlowCheck.mDiffusionFlowCheck.tabControlChart.SelectedTab == DiffusionFlowCheck.mDiffusionFlowCheck.tabPageDifAndPressure)
                    {
                        DiffusionFlowCheck.mDiffusionFlowCheck.DiffusionFlowCheckZedGraphControlFP.DoPrint();
                    }
                }
            }
            /// <summary>
            /// 手动泡点打印
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            if (ManualBubblePoint.MManualBubblePoint != null)
            {
                if (ManualBubblePoint.MManualBubblePoint.tabControlManualBubblePoint.SelectedTab == ManualBubblePoint.MManualBubblePoint.tabPageManualBubblePointChart)
                {
                    if (ManualBubblePoint.MManualBubblePoint.tabControlChart.SelectedTab == ManualBubblePoint.MManualBubblePoint.tabPagePressureAndTime)
                    {
                        ManualBubblePoint.MManualBubblePoint.ManualBubblePointZedGraphControlPTime.DoPrint();
                    }
                    if (ManualBubblePoint.MManualBubblePoint.tabControlChart.SelectedTab == ManualBubblePoint.MManualBubblePoint.tabPageDifAndPressure)
                    {
                        ManualBubblePoint.MManualBubblePoint.ManualBubblePointZedGraphControlFP.DoPrint();
                    }
                }
            }
            /// <summary>
            /// Pressure Holding打印
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            if (RateOfRise.MRateOfRise != null)
            {
                if (RateOfRise.MRateOfRise.tabControlRateOfRise.SelectedTab == RateOfRise.MRateOfRise.tabPageRateOfRiseChart)
                {
                    if (RateOfRise.MRateOfRise.tabControlChart.SelectedTab == RateOfRise.MRateOfRise.tabPagePressureAndTime)
                    {
                        RateOfRise.MRateOfRise.RateOfRiseZedGraphControlPTime.DoPrint();
                    }
                    if (RateOfRise.MRateOfRise.tabControlChart.SelectedTab == RateOfRise.MRateOfRise.tabPageDifAndPressure)
                    {
                        RateOfRise.MRateOfRise.RateOfRiseZedGraphControlFP.DoPrint();
                    }
                }
            }
            /// <summary>
            /// Water Immersion 打印
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            if (WaterImmersionTest.MWaterImmersionTest != null)
            {
                if (WaterImmersionTest.MWaterImmersionTest.tabControlWaterImmersionTest.SelectedTab == WaterImmersionTest.MWaterImmersionTest.tabPageWaterImmersionTestChart)
                {
                    if (WaterImmersionTest.MWaterImmersionTest.tabControlChart.SelectedTab == WaterImmersionTest.MWaterImmersionTest.tabPagePressureAndTime)
                    {
                        WaterImmersionTest.MWaterImmersionTest.WaterImmersionTestZedGraphControlPTime.DoPrint();
                    }
                    if (WaterImmersionTest.MWaterImmersionTest.tabControlChart.SelectedTab == WaterImmersionTest.MWaterImmersionTest.tabPageDifAndPressure)
                    {
                        WaterImmersionTest.MWaterImmersionTest.WaterImmersionTestZedGraphControlFP.DoPrint();
                    }
                }
            }
            /// <summary>
            /// Extensive Bubble Point
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            if (StrengthenTheBubble.MStrengthenTheBubble != null)
            {
                if (StrengthenTheBubble.MStrengthenTheBubble.tabControlStrengthenTheBubble.SelectedTab == StrengthenTheBubble.MStrengthenTheBubble.tabPageStrengthenTheBubbleChart)
                {
                    if (StrengthenTheBubble.MStrengthenTheBubble.tabControlChart.SelectedTab == StrengthenTheBubble.MStrengthenTheBubble.tabPagePressureAndTime)
                    {
                        StrengthenTheBubble.MStrengthenTheBubble.StrengthenTheBubbleZedGraphControlPTime.DoPrint();

                    }
                    if (StrengthenTheBubble.MStrengthenTheBubble.tabControlChart.SelectedTab == StrengthenTheBubble.MStrengthenTheBubble.tabPageDifAndPressure)
                    {
                        StrengthenTheBubble.MStrengthenTheBubble.StrengthenTheBubbleZedGraphControlFP.DoPrint();

                    }
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// Import
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxImport_Click(object sender, EventArgs e)
        {
            try
            {
                Import mImport = new Import();
                mImport.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// Export
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxExport_Click(object sender, EventArgs e)
        {
            try
            {
            Export mExport = new Export();
            mExport.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 打开帮助文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxOpenHelpDoc_Click(object sender, EventArgs e)
        {
            try
            {
            Help.ShowHelp(new Control(), @"..\..\Help\Help.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }

      

        /// <summary>
        /// 通信方式Tips信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxCommunication_MouseEnter(object sender, EventArgs e)
        {
            try
            {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.pictureBoxCommunication, "Communication Mode");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 打印Tips
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxPrint_MouseEnter(object sender, EventArgs e)
        {
            try
            {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            //p.SetToolTip(this.pictureBoxPrint, "Print");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// ImportTips
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxImport_MouseEnter(object sender, EventArgs e)
        {
            try
            {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.pictureBoxImport, "Import");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// ExportTips
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxExport_MouseEnter(object sender, EventArgs e)
        {
            try
            {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.pictureBoxExport, "Export");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 打开帮助文档的Tips
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxOpenHelpDoc_MouseEnter(object sender, EventArgs e)
        {
            try
            {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            //p.SetToolTip(this.pictureBoxOpenHelpDoc, "Open help documentation");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 关于Tips
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxHelp_MouseEnter(object sender, EventArgs e)
        {
            try
            {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.pictureBoxHelp, "About");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        #endregion

        private void timerPollingInquiry_Tick(object sender, EventArgs e)
        {
           
            CommPort mComPort = CommPort.Instance;
            usbReferenceDevice theReferenceUsbDevice = new usbReferenceDevice(USB.vid, USB.pid);
            foreach (int o in mPollingInquiry)
            {
                try
                {

                   string str = "FF" + "{0}" + "05" + "03" + "00";
                    
                    str = string.Format(str, o.ToString("X2"));
                    byte[] sendData = mComPort.convertstringtobyte(str);
                    int sum = 0;
                    foreach (int i in sendData)
                    {
                        sum += i;
                    }
                    sendData[sendData.Length - 1] = (byte)(sum % 256);
                    if (Communication.mConFlag == 2)
                    {
                        mComPort.Send(sendData);
                    }
                    if (Communication.mConFlag == 3)
                    {
                        theReferenceUsbDevice.Send(sendData);
                    }
                   
                }

                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                
            }
            
        }
        /// <summary>
        /// 系统set想要事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemSystemset_Click(object sender, EventArgs e)
        {
             try
                {
                    BasicBubblePoint.BacicBubble = null;
                  
                    ManualBubblePoint.MManualBubblePoint = null;
                    RateOfRise.MRateOfRise = null;
                    WaterImmersionTest.MWaterImmersionTest = null;
                    StrengthenTheBubble.MStrengthenTheBubble = null;
                    mSystemParameter mSP = new mSystemParameter();
                    mSP.FormBorderStyle = FormBorderStyle.None;
                    mSP.TopLevel = false;
                    mSP.Dock = DockStyle.Fill;
                    this.MyPanel.Controls.Clear();
                    this.MyPanel.Controls.Add(mSP);
                    mSP.Show();
                }

             catch (Exception er)
             {
                 MessageBox.Show(er.Message);
             }

        }
        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolUserInfo_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfo mUserInfo = new UserInfo();
                mUserInfo.ShowDialog();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }

        private void toolStripMenuUserInfo_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfo mUserInfo = new UserInfo();
                mUserInfo.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemRest_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("Did you reset Confirm? The reset must be in the case that all devices are not under TestingState! "," warning! ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                {
                    CommPort.MCurrent.Clear();
                    CommPort.MResult.Clear();
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }  
    }
}