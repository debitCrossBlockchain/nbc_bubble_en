using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
//引用创建Access数据库的库
using System.Data.OleDb;
using SunManage.communication;
using System.Xml;
namespace SunManage.AllCheck
{
    public partial class ManualBubblePoint : Form
    {
        int mStatFlagMP;
        static bool mStartTest = false;//为假修改，为真
        public static int[] mCurPT = new int[50];
        public static string Test_AreaMP = (0).ToString("X8");
        public static string Test_Filter_ConfigMP = (0).ToString("X4");
        public static string Test_Filter_numerMP = (0).ToString("X2");
        public static string Test_LIQUConsistenceMP = (0).ToString("X4");

        public static string HTest_Filter_ConfigMP = (0).ToString("X4");
        public static string HTest_Filter_numerMP = (0).ToString("X2");
        public static string HTest_LIQUConsistenceMP = (0).ToString("X4");
        public static string Test_LIQUMP = "";
        static int x = 0;
        /// <summary>
        /// Result
        /// </summary>
        static string Test_type="";
        public static string Htest_Name="";
        static Int32 Htest_DifValue=0;
        public static Int32 Htest_TestValue=0;
        static Int32 Htest_DiffePress=0;
        static string Htest_BP_Result="";
        static string Htest_DIF_Result="";
        public static string Htest_ALL_Result="";
        static Int32 Htest_testimes=0;

        private OleDbConnection mConnection;
        string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\TestHistoryData.mdb";
        private OleDbConnection mConnectionStartTest;
        string sAccessConnectionStartTest = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\StartTest.mdb";
        //private OleDbConnection mConnectionParameter;
        //string sAccessConnectionParameter = @"Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\SystemParameter.mdb";
        private DataSet ds = new DataSet();//数据库操作
        public static ManualBubblePoint MManualBubblePoint = null;
        public static bool MMB = false;

        Main mTreeName = new Main();
        public ManualBubblePoint()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Pressure And Test  Chart图
        /// </summary>
        private void BasicBubblePointPTime(ZedGraphControl zgc)
        {

            GraphPane myPane = zgc.GraphPane;


            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            // set the titles and axis labels
            myPane.Title.Text = "Manual Bubble Point Chart";
            myPane.XAxis.Title.Text = "Time(min)";
            myPane.YAxis.Title.Text = "Pressure(mbar)";
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 60;
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 10000;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 10;
            myPane.YAxis.Scale.MinorStep = 100;
            myPane.YAxis.Scale.MajorStep = 1000;

            try
            {
                CommPort mComPort = CommPort.Instance;
                usbReferenceDevice theReferenceUsbDevice = new usbReferenceDevice(USB.vid, USB.pid);
                x = 0;
                foreach (CommPort o in CommPort.MCurrent)
                {


                    if (o.DeviceID == CommPort.mDeviceAddress)
                    {
                        if ((o.CurrentState == 0x52) && (o.CurrentType == "Manual Bubble Point"))
                        {
                            labelManualBubblePointPress.Text = o.CurrentPress.ToString();

                            list1.Add(x, o.CurrentPress);
                            if (x < 50)
                            {
                                mCurPT[x] = o.CurrentPress;
                            }
                            if (textBoxTest_startp.Text.ToString() == "\0" || textBoxTest_startp.Text.ToString() == "")
                            {
                                //实例化xml
                                XmlDocument xml = new XmlDocument();
                                //读取xml文件
                                xml.Load(@"..\..\XmlIni\StartTheTestData.XML");  //xml地址

                                //////////*******下面开始循环读取xml文件信息********/
                                ///////////////
                                foreach (XmlNode node in xml.ChildNodes)
                                {
                                    if (node.Name == "Config")
                                    {
                                        foreach (XmlNode node1 in node.ChildNodes)
                                        {
                                            if (node1.Name == "ManualBubblePoint")
                                            {
                                                foreach (XmlNode node2 in node1.ChildNodes)
                                                {
                                                    switch (node2.Name)
                                                    {

                                                        case "Test_startp":
                                                            textBoxTest_startp.Text = node2.InnerText;
                                                            break;
                                                        case "Test_setBp":
                                                            textBoxTest_setBp.Text = node2.InnerText;
                                                            break;

                                                        default:

                                                            break;
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                list2.Add(x, Convert.ToInt32(textBoxTest_startp.Text.ToString()));
                                list3.Add(x, Convert.ToInt32(textBoxTest_setBp.Text.ToString()));

                            }
                            else
                            {
                                list2.Add(x, Convert.ToInt32(textBoxTest_startp.Text.ToString()));
                                list3.Add(x, Convert.ToInt32(textBoxTest_setBp.Text.ToString()));
                            }
                            x++;
                        }
                        else if (o.CurrentState == 0x53)
                        {
                            mComPort.SearchDeviceAddress();

                            try
                            {

                                string str = "ff" + "{0}" + "05" + "04" + "00";
                                str = string.Format(str, CommPort.mDeviceAddress.ToString("X2"));
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

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Exception:" + ex.ToString(), "Tips");

            }


            LineItem curve = myPane.AddCurve("Pressure And Test  ", list1, Color.Red, SymbolType.None);
            LineItem mcurve = myPane.AddCurve("Start Pressure", list2, Color.Blue, SymbolType.None);
            LineItem mgcurve = myPane.AddCurve("Min. BP", list3, Color.Green, SymbolType.None);
            //BasicBubbleZedGraphControlPTime.AxisChange();
            //reader.Close();
            //mConnection.Close();

            foreach (CommPort oR in CommPort.MResult)
            {

                if (oR.DeviceID == CommPort.mDeviceAddress)
                {
                    if (oR.CurrentType == "Manual Bubble Point")
                    {
                        labelValue.Text = oR.Htest_TestValue.ToString();
                        labelResult.Text = oR.Htest_ALL_Result.ToString();
                        Test_type = oR.Test_type;
                        Htest_Name = oR.Htest_Name;
                        Htest_DifValue = oR.Htest_DifValue;
                        Htest_TestValue = oR.Htest_TestValue;
                        Htest_DiffePress = oR.Htest_DiffePress;
                        Htest_BP_Result = oR.Htest_BP_Result;
                        Htest_DIF_Result = oR.Htest_DIF_Result;
                        Htest_ALL_Result = oR.Htest_ALL_Result;
                        Htest_testimes = oR.Htest_testimes;
                    }
                }
            }

            
        }
        /// <summary>
        /// Flow And Pressure图形
        /// </summary>
        /// <param name="zgc"></param>
        private void BasicBubblePointFP(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            RollingPointPairList list = new RollingPointPairList(1200);
            // set the titles and axis labels
            myPane.Title.Text = "Manual Bubble PointChart";
            myPane.XAxis.Title.Text = "Pressure(mbar)";
            myPane.YAxis.Title.Text = "DF(ml/min)";
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 5000;
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 800;
            myPane.XAxis.Scale.MinorStep = 50;
            myPane.XAxis.Scale.MajorStep = 500;
            myPane.YAxis.Scale.MinorStep = 10;
            myPane.YAxis.Scale.MajorStep = 100;
            LineItem curve = myPane.AddCurve("Start Pressure", list, Color.Red, SymbolType.None);
            LineItem mcurve = myPane.AddCurve("Max. DF", list, Color.Blue, SymbolType.None);
            LineItem mgcurve = myPane.AddCurve("DF And Pressure", list, Color.Green, SymbolType.None);
            LineItem mycurve = myPane.AddCurve("Min. BP", list, Color.Yellow, SymbolType.None); 
        }
        
        private void ManualBubblePoint_Load(object sender, EventArgs e)
        {

            try
            {
                SunManage.DataBase.DataBase mDataBase = new DataBase.DataBase();
                mDataBase.CreatDB("MBStartTest");
            OleDbConnection mConnection;
            string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\DeviceConcatenate.mdb";


            string mQuery = "Select [mStatFlagMP] From DeviceConcatenate where [DeviceName]='" + Main.MTreeName + "'";

            mConnection = new OleDbConnection(sAccessConnection);



            mConnection.Open();
            OleDbCommand cmd = new OleDbCommand(mQuery, mConnection);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                mStatFlagMP = Convert.ToInt32(reader[0].ToString());
            }

            reader.Close();


            mConnection.Close();
            BasicBubblePointPTime(ManualBubblePointZedGraphControlPTime);
            BasicBubblePointFP(ManualBubblePointZedGraphControlFP);
            if (mStatFlagMP == 1)
            {
                //启动

                pictureBoxstart.Image = SunManage.Properties.Resources.Start;
            }
            else
            {
                //停止
                pictureBoxstart.Image = SunManage.Properties.Resources.Analysis;


            }
           
            this.tabControlManualBubblePoint.SelectTab(tabPageManualBubblePointset);//set为当前的选项卡
           


           
            //实例化xml
            XmlDocument xml = new XmlDocument();
            //读取xml文件
            xml.Load(@"..\..\XmlIni\StartTheTestData.XML");  //xml地址

            //////////*******下面开始循环读取xml文件信息********/
            ///////////////
            foreach (XmlNode node in xml.ChildNodes)
            {
                if (node.Name == "Config")
                {
                    foreach (XmlNode node1 in node.ChildNodes)
                    {
                        if (node1.Name == "ManualBubblePoint")
                        {
                            foreach (XmlNode node2 in node1.ChildNodes)
                            {
                                switch (node2.Name)
                                {
                                    case "Test_Psernum":
                                        textBoxTest_Psernum.Text = node2.InnerText;
                                        break;
                                    case "Test_Tsernum":
                                        textBoxTest_Tsernum.Text = node2.InnerText;
                                        break;
                                        
                                    case "Test_setBp":
                                        textBoxTest_setBp.Text = node2.InnerText;
                                        break;
                                   
                                    case "Test_Velocity":
                                        textBoxTest_Velocity.Text = node2.InnerText;
                                        break;
                                    case "Test_Meme_Aper":
                                        textBoxTest_Meme_Aper.Text = node2.InnerText;
                                        break;
                                    case "Test_startp":
                                        textBoxTest_startp.Text = node2.InnerText;
                                        break;
                                    case "Test_filt":
                                        textBoxTest_filt.Text = node2.InnerText;
                                        break;
                                    case "Test_Filter_Type":
                                        textBoxTest_Filter_Config.Text = node2.InnerText;
                                        break;
                                    case "Test_Filter_Area":
                                        textBoxTest_Filter_Area.Text = node2.InnerText;
                                        break;
                                    case "Test_Fsernum":
                                        textBoxTest_Fsernum.Text = node2.InnerText;
                                        break;                                 
                                    case "Test_Num":
                                        textBoxTest_Tsernum.Text = node2.InnerText;
                                        break;
                                    case "Test_LIQU":
                                       // textBoxTest_LIQU.Text = node2.InnerText;
                                        break;
                                    case "Test_LIQUConsistence":
                                        HTest_LIQUConsistenceMP = node2.InnerText;
                                        break;
                                    case "Test_Filter_Config":
                                        HTest_Filter_ConfigMP = node2.InnerText;
                                        break;
                                    case "Test_Filter_number":
                                        HTest_Filter_numerMP = node2.InnerText;
                                        break;
                                    case "Test_LIQUName":
                                        Test_LIQUMP = node2.InnerText;
                                        break;
                                    default:
                                        break;
                                }
                            }

                        }
                    }
                }
            }
            this.timerManualBubblePoint.Interval = 1000;
            this.timerManualBubblePoint.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Exception:" + ex.ToString(), "Tips");

            }
        }
        /// <summary>
        /// Manual Bubble Point参数set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttontabPageManualBubblePointsetTest_Click(object sender, EventArgs e)
        {
            //labelCurrentRun.Text = "运行中";
            CommPort mComPort = CommPort.Instance;
           
            string Test_type = (77).ToString("X2");


            /// <summary>
            /// product_batch_NO
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>

            string Test_Psernum = "";
            string Test_Ps = "";
            if (!string.IsNullOrEmpty(textBoxTest_Psernum.Text))
            {

                for (int m = 0; m < 16 - (textBoxTest_Psernum.Text).Length; m++)
                {
                    Test_Psernum = Test_Psernum + "\0";
                }
                Test_Psernum = textBoxTest_Psernum.Text + Test_Psernum;




                for (int m = 0; m < 16; m++)
                {

                    if (m < Test_Psernum.Length)
                    {
                        Test_Ps = Test_Ps + (Encoding.ASCII.GetBytes(Test_Psernum)[m]).ToString("X2");
                    }
                    else
                    {
                        Test_Ps = Test_Ps + "00";
                    }
                }
            }
            else
            {
                Test_Ps = (0).ToString("X32");
            }
            /// <summary>
            /// 产品编号
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            string Test_Ts = "";
            if (!string.IsNullOrEmpty(textBoxTest_Tsernum.Text))
            {

                string Test_Tsernum = textBoxTest_Tsernum.Text;
                string Test_T = "";

                for (int m = 0; m < 16 - Test_Tsernum.Length; m++)
                {
                    Test_T = Test_T + "\0";
                }
                Test_Tsernum = Test_Tsernum + Test_T;




                for (int m = 0; m < 16; m++)
                {
                    if (m < Test_Tsernum.Length)
                    {

                        Test_Ts = Test_Ts + (Encoding.ASCII.GetBytes(Test_Tsernum)[m]).ToString("X2");
                    }
                    else
                    {
                        Test_Ts = Test_Ts + "00";
                    }

                }
            }
            else
            {
                Test_Ts = (0).ToString("X32");
            }
            /// <summary>
            /// Filter Serial Number
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            string Test_Fsernum = textBoxTest_Fsernum.Text;
            string Test_F = "";
            string Test_Fs = "";
            if (!string.IsNullOrEmpty(textBoxTest_Fsernum.Text))
            {
                for (int i = 0; i < 16 - Test_Fsernum.Length; i++)
                {
                    Test_F = Test_F + "\0";
                }
                Test_Fsernum = Test_Fsernum + Test_F;


                for (int i = 0; i < 16; i++)
                {
                    if (i < Test_Fsernum.Length)
                    {
                        Test_Fs = Test_Fs + (Encoding.ASCII.GetBytes(Test_Fsernum)[i]).ToString("X2");
                    }
                    else
                    {
                        Test_Fs = Test_Fs + "00";
                    }

                }
            }
            else
            {
                Test_Fs = (0).ToString("X32");
            }

            /// <summary>
            /// Filter Material Type
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            string Test_filt = textBoxTest_filt.Text;
            string Test_f = "";
            string Test_fi = "";
            if (!string.IsNullOrEmpty(textBoxTest_filt.Text))
            {
                for (int i = 0; i < 16 - Test_filt.Length; i++)
                {
                    Test_f = Test_f + "\0";
                }
                Test_filt = Test_filt + Test_f;




                for (int i = 0; i < 16; i++)
                {
                    if (i < Test_filt.Length)
                    {
                        Test_fi = Test_fi + ((Encoding.ASCII.GetBytes(Test_filt))[i]).ToString("X2");
                    }
                    else
                    {
                        Test_fi = Test_fi + "00";
                    }
                }
            }
            else
            {
                Test_fi = (0).ToString("X32");
            }
            /// <summary>
            /// Testing Liquid
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>

            string Test_LIQU = "";
            string Test_LI = "";

            string mLiqu = (Test_LIQUMP).Trim();
            if (!string.IsNullOrEmpty(mLiqu))
            {
                for (int i = 0; i < 15 - (System.Text.Encoding.GetEncoding("GB2312").GetBytes(mLiqu)).Length; i++)
                {
                    Test_LIQU = Test_LIQU + "00";
                }
                //Test_LIQU = mLiqu + Test_LIQU;
                byte[] StryTest_LIQU = System.Text.Encoding.GetEncoding("GB2312").GetBytes(mLiqu);
                for (int i = 0; i < StryTest_LIQU.Length; i++)
                {
                    Test_LI = Test_LI + StryTest_LIQU[i].ToString("X2");
                }
                Test_LI = Test_LI + Test_LIQU;

            }
            else
            {
                Test_LI = (0).ToString("X30");
            }
            /// <summary>
            /// Date/Time
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            string DTime = " " + DateTime.Now.Year.ToString("D4") + "-" + DateTime.Now.Month.ToString("D2") + "-" + DateTime.Now.Day.ToString("D2") + " " + DateTime.Now.Hour.ToString("D2") + ":" + DateTime.Now.Minute.ToString("D2") + "";
            string MDataTime = "";
            string DT = DTime.Replace(" ", "");
            DT = DT.Trim();
            DT = DT.Replace("-", "");
            DT = DT.Replace(":", "");
            DT = DT.Replace("", "");
            string mDataTime = DT;
           
            for (int i = 0; i < mDataTime.Length; )
            {
                MDataTime = MDataTime + (Convert.ToInt32(((mDataTime[i].ToString()) + (mDataTime[i + 1].ToString())))).ToString("X2");
                i = i + 2;
            }
            /// <summary>
            /// Testing Liquid种类
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            string mTest_LIQUType = "";
            string mTest_LQT = "";
            switch (mTest_LQT)
            {
                case "Water":
                    {
                        mTest_LIQUType = (1).ToString("X2");
                    }
                    break;
                case "Enthanol":
                    {
                        mTest_LIQUType = (2).ToString("X2");
                    }
                    break;
                case "l_Alcohol":
                    {
                        mTest_LIQUType = (3).ToString("X2");
                    }
                    break;
                case "Other":
                    {
                        mTest_LIQUType = (4).ToString("X2");
                    }
                    break;
                default:
                    mTest_LIQUType = (69).ToString("X2");
                    break;
            }

            /// <summary>
            /// Testing Liquid浓度
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>


            /// <summary>
            /// 测量用过滤器的种类
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            string Test_Filter_type = "";
            string mTest_Fil_T = (textBoxTest_Filter_Config.Text).Trim();
            switch (mTest_Fil_T)
            {
                case "Cartridge":
                    {
                        Test_Filter_type = (1).ToString("X2");
                    }
                    break;
                case "Pannel":
                    {
                        Test_Filter_type = (2).ToString("X2");
                    }
                    break;
                case "Bag":
                    {
                        Test_Filter_type = (3).ToString("X2");
                    }
                    break;
                case "Other":
                    {
                        Test_Filter_type = (4).ToString("X2");
                    }
                    break;
                default:
                    Test_Filter_type = (69).ToString("X2");
                    break;
            }


            /// <summary>
            /// Filter Specification
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>

            /// <summary>
            /// 过滤器Filter Amount
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>


            /// <summary>
            /// 过滤器面积
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>


            /// <summary>
            ///过滤材料Aperture
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            string Test_Meme_Aper = (0).ToString("X4");
            if (!string.IsNullOrEmpty(textBoxTest_Meme_Aper.Text))
            {
                Test_Meme_Aper = (Convert.ToInt64((textBoxTest_Meme_Aper.Text.Replace(".", "")))).ToString("X4");
            }


            /// <summary>
            ///Test Mode
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>

            string Test_Velocity = (0).ToString("X4");
            if (!string.IsNullOrEmpty(textBoxTest_Velocity.Text))
           {
                Test_Velocity=(Convert.ToInt64(textBoxTest_Velocity.Text.Replace(".",""))).ToString("X4");
           }

            /// <summary>
            ///滤芯的Upstream Volume
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            string Test_Up_Volm = (0).ToString("X8");

            /// <summary>
            ///Start Pressure（ 滤芯的DF检测时的Pressure ） -- 2 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            string Test_start = (0).ToString("X4");//Start Pressure
            if (!string.IsNullOrEmpty(textBoxTest_startp.Text))
            {
                Test_start = (Convert.ToInt64(textBoxTest_startp.Text)).ToString("X4");
            }


            /// <summary>
            /// Min. BP     -- 2 ;
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>


            string Test_setBp = (0).ToString("X4");
            if (!string.IsNullOrEmpty(textBoxTest_setBp.Text))
            {
                Test_setBp = (Convert.ToInt64(textBoxTest_setBp.Text)).ToString("X4");
            }

            /// <summary>
            /// Max. DF    -- 2 ;
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            string Test_Dif_max = (0).ToString("X4");


            try
            {
                try
                {
                    string mTreeName = Main.MTreeName.ToString();

                    if (!string.IsNullOrEmpty(mTreeName))
                    {



                        string mSelectQuery = "Select * FROM [MBStartTest] Where [DeviceName]= '" + mTreeName.ToString() + "'";



                        mConnectionStartTest = new OleDbConnection(sAccessConnectionStartTest);

                        if (mConnectionStartTest.State != ConnectionState.Open) { mConnectionStartTest.Open(); }

                        OleDbCommand cmd = new OleDbCommand(mSelectQuery, mConnectionStartTest);
                        cmd.CommandType = CommandType.Text;


                        if (cmd.ExecuteScalar() != null)
                        {
                            mStartTest = false;//表示存在
                        }
                        else
                        {

                            mStartTest = true;


                        }

                        mConnectionStartTest.Close();
                    }
                    //增加
                    if (mStartTest == true)
                    {
                        string mQuery = String.Format("INSERT INTO {0}([DeviceName],[Htest_type],[Test_Psernum],[Test_Tsernum],[Test_Fsernum],[Test_filt],[Test_LIQU],[HA_STime],[Test_LIQUType],[Test_LIQUConsistence],[Test_Filter_type],[Test_Filter_Config],[Test_Filter_number],[Test_Filter_Area],[Test_Meme_Aper],[Test_Velocity],[Test_Up_Volm],[Test_startp],[Test_setBp],[Test_Dif_max]) VALUES ('" + mTreeName + "','" + "Manual Bubble Point".ToString() + "','" + textBoxTest_Psernum.Text.ToString() + "','" + textBoxTest_Tsernum.Text.ToString() + "','" + textBoxTest_Fsernum.Text.ToString() + "','" + textBoxTest_filt.Text.ToString() + "','" + mLiqu.ToString() + "','" + DTime + "','" + "" + "','" + HTest_LIQUConsistenceMP.ToString() + "','" + textBoxTest_Filter_Config.Text.ToString() + "','" + HTest_Filter_ConfigMP.ToString() + "','" + HTest_Filter_numerMP.ToString() + "','" + textBoxTest_Filter_Area.Text.ToString() + "','" + textBoxTest_Meme_Aper.Text.ToString() + "','" + textBoxTest_Velocity.Text.ToString() + "','" + ("").ToString() + "','" + textBoxTest_startp.Text.ToString() + "','" + textBoxTest_setBp.Text.ToString() + "','" + ("").ToString() + "')", ("MBStartTest").ToString());

                        OleDbCommand da = new OleDbCommand(mQuery, mConnectionStartTest);

                        try
                        {

                            da.CommandType = CommandType.Text;
                            if (mConnectionStartTest.State != ConnectionState.Open) { mConnectionStartTest.Open(); }
                            da.ExecuteNonQuery();




                        }

                        catch (Exception ex)
                        {

                            MessageBox.Show("Exception:" + ex.ToString(), "Tips");

                        }

                        finally
                        {

                            mConnectionStartTest.Close();

                        }
                    }
                    //编辑
                    if (mStartTest == false)
                    {

                        // string mQuery = String.Format("INSERT INTO {0}([DeviceName],[Htest_type],[Test_Psernum],[Test_Tsernum],[Test_Fsernum],[Test_filt],[Test_LIQU],[HA_STime],[Test_LIQUType],[Test_LIQUConsistence],[Test_Filter_type],[Test_Filter_Config],[Test_Filter_number],[Test_Filter_Area],[Test_Meme_Aper],[Test_Velocity],[Test_Up_Volm],[Test_startp],[Test_setBp],[Test_Dif_max]) VALUES ('" + mTreeName + "','" + "Basic Bubble Point".ToString() + "','" + textBoxTest_Psernum.Text.ToString() + "','" + textBoxTest_Tsernum.Text.ToString() + "','" + textBoxTest_Fsernum.Text.ToString() + "','" + textBoxTest_filt.Text.ToString() + "','" + mLiqu.ToString() + "','" + DTime + "','" + textBoxTest_LIQU.Text.ToString() + "','" + HTest_LIQUConsistenceBP.ToString() + "','" + textBoxTest_Filter_Config.Text.ToString() + "','" + HTest_Filter_ConfigBP.ToString() + "','" + HTest_Filter_numerBP.ToString() + "','" + textBoxTest_Filter_Area.Text.ToString() + "','" + textBoxTest_Meme_Aper.Text.ToString() + "','" + mTVelocity.ToString() + "','" + ("").ToString() + "','" + textBoxTest_startp.Text.ToString() + "','" + textBoxTest_setBp.Text.ToString() + "','" + ("").ToString() + "')", ("BBStartTest").ToString());

                        string mQuery = "update [MBStartTest] set [DeviceName]='" + mTreeName.ToString() + "',[Htest_type]='" + "Manual Bubble Point".ToString() + "',[Test_Psernum]='" + textBoxTest_Psernum.Text.ToString() + "',[Test_Tsernum]='" + textBoxTest_Tsernum.Text.ToString() + "',[Test_Fsernum]='" + textBoxTest_Fsernum.Text.ToString() + "',[Test_filt]='" + textBoxTest_filt.Text.ToString() + "',[Test_LIQU]='" + mLiqu.ToString() + "',[HA_STime]='" + DTime + "',[Test_LIQUType]='" + "" + "',[Test_LIQUConsistence]='" + HTest_LIQUConsistenceMP.ToString() + "',[Test_Filter_type]='" + textBoxTest_Filter_Config.Text.ToString() + "',[Test_Filter_Config]='" + HTest_Filter_ConfigMP.ToString() + "',[Test_Filter_Area]='" + textBoxTest_Filter_Area.Text.ToString() + "',[Test_Meme_Aper]='" + textBoxTest_Meme_Aper.Text.ToString() + "',[Test_Velocity]='" + textBoxTest_Velocity.Text.ToString() + "',[Test_Up_Volm]='" + ("").ToString() + "',[Test_startp]='" + textBoxTest_startp.Text.ToString() + "',[Test_setBp]='" + textBoxTest_setBp.Text.ToString() + "',[Test_Dif_max]='" + ("").ToString() + "' where [DeviceName]='" + mTreeName.ToString() + "'";


                        mConnectionStartTest = new OleDbConnection(sAccessConnectionStartTest);

                        OleDbCommand da = new OleDbCommand(mQuery, mConnectionStartTest);

                        //

                        try
                        {
                            da.CommandType = CommandType.Text;
                            if (mConnectionStartTest.State != ConnectionState.Open) { mConnectionStartTest.Open(); }

                            da.ExecuteNonQuery();
                        }

                        catch (Exception ex)
                        {

                            MessageBox.Show("Exception:" + ex.ToString(), "Tips");

                        }

                        finally
                        {

                            mConnectionStartTest.Close();

                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception:" + ex.ToString(), "Tips");
                }
                usbReferenceDevice theReferenceUsbDevice = new usbReferenceDevice(USB.vid, USB.pid);
                mComPort.SearchDeviceAddress();
                string str = "FF" + "{0}" + "73" + "01" + Test_type + Test_Ps + Test_Ts + Test_Fs + Test_fi + Test_LI + MDataTime + mTest_LIQUType + Test_LIQUConsistenceMP + Test_Filter_ConfigMP + Test_Filter_numerMP + Test_AreaMP + Test_Meme_Aper + Test_Velocity + Test_Up_Volm + Test_start + Test_setBp + Test_Dif_max + "00";
                str = string.Format(str, CommPort.mDeviceAddress.ToString("X2"));
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
            this.tabControlManualBubblePoint.SelectTab(tabPageManualBubblePointState);//setState选项为当前的选项卡
        }

        private void buttonManualBubblePointLoad_Click(object sender, EventArgs e)
        {
            string mTreeName = Main.MTreeName.ToString();

            if (!string.IsNullOrEmpty(mTreeName))
            {



                string mSelectQuery = "Select * FROM [MBStartTest] Where [DeviceName]= '" + mTreeName.ToString() + "'";



                mConnectionStartTest = new OleDbConnection(sAccessConnectionStartTest);
                try
                {

                    if (mConnectionStartTest.State != ConnectionState.Open) { mConnectionStartTest.Open(); }

                    OleDbCommand cmd = new OleDbCommand(mSelectQuery, mConnectionStartTest);
                    cmd.CommandType = CommandType.Text;

                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        textBoxTest_Psernum.Text = reader[2].ToString();
                        textBoxTest_Tsernum.Text = reader[3].ToString();
                        textBoxTest_Fsernum.Text = reader[4].ToString();
                        textBoxTest_startp.Text = reader[17].ToString();
                        textBoxTest_setBp.Text = reader[18].ToString();
                        textBoxTest_Meme_Aper.Text = reader[14].ToString();
                       
                        textBoxTest_Velocity.Text = reader[15].ToString();

                        textBoxTest_filt.Text = reader[5].ToString();





                        textBoxTest_Filter_Config.Text = reader[10].ToString();
                        textBoxTest_Filter_Area.Text = reader[13].ToString();

                        //textBoxTest_LIQU.Text = reader[6].ToString();

                        HTest_Filter_ConfigMP = reader[11].ToString();
                        HTest_Filter_numerMP = reader[12].ToString();
                        HTest_LIQUConsistenceMP = reader[9].ToString();

                        if (string.IsNullOrEmpty(reader[11].ToString()))
                        {
                            Test_Filter_ConfigMP = (0).ToString("X4");
                        }
                        else
                        {
                            Test_Filter_ConfigMP = (Convert.ToInt64(reader[11].ToString())).ToString("X4");
                        }
                        if (string.IsNullOrEmpty(reader[12].ToString()))
                        {
                            Test_Filter_numerMP = (0).ToString("X2");
                        }
                        else
                        {
                            Test_Filter_numerMP = (Convert.ToInt64(reader[12].ToString())).ToString("X4");
                        }
                        if (string.IsNullOrEmpty(reader[9].ToString()))
                        {
                            Test_LIQUConsistenceMP = (0).ToString("X4");
                        }
                        else
                        {
                            Test_LIQUConsistenceMP = (Convert.ToInt64(reader[9].ToString())).ToString("X4");
                        }


                    }

                }

                catch (Exception ex)
                {

                    MessageBox.Show("Exception:" + ex.ToString(), "Tips");

                }
                finally
                {
                    mConnectionStartTest.Close();
                }




            }
        }

        private void ManualBubblePoint_FormClosed(object sender, FormClosedEventArgs e)
        {
            MManualBubblePoint = null;
        }
        /// <summary>
        /// 定时器Manual Bubble Point
        /// 显示当前参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerManualBubblePoint_Tick(object sender, EventArgs e)
        {
            this.ManualBubblePointZedGraphControlPTime.GraphPane.CurveList.Clear();
            this.ManualBubblePointZedGraphControlPTime.GraphPane.GraphObjList.Clear();

            BasicBubblePointPTime(ManualBubblePointZedGraphControlPTime);
          


            this.ManualBubblePointZedGraphControlPTime.Refresh();
        }

        /// <summary>
        /// 保存手动Result到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxSave_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to save the Confirm manual Result Test bubble?", "Tips", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string m1 = "";
            string m2 = "";
            string m3 = "";
            string m4 = "";
            string m5 = "";
            string m6 = "";
            string m7 = "";
            string m8 = "";
            string m9 = "";
            string m10 = "";
            string m11 = "";
            string m12 = "";
            string m13 = "";
            string m14 = "";
            string m15 = "";
            string m16 = "";
            string m17 = "";
            string m18 = "";
            string m19 = "";
            if (DialogResult.Yes == dr)
            {

                string mTreeName = Main.MTreeName.ToString();

                if (!string.IsNullOrEmpty(mTreeName))
                {

                    string mSelectQuery = "Select * FROM [MBStartTest] Where [DeviceName]= '" + mTreeName.ToString() + "'";

                    mConnectionStartTest = new OleDbConnection(sAccessConnectionStartTest);
                    try
                    {

                        if (mConnectionStartTest.State != ConnectionState.Open) { mConnectionStartTest.Open(); }

                        OleDbCommand cmd = new OleDbCommand(mSelectQuery, mConnectionStartTest);
                        cmd.CommandType = CommandType.Text;

                        OleDbDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            m1 = reader[1].ToString();
                            m2 = reader[2].ToString();
                            m3 = reader[3].ToString();
                            m4 = reader[4].ToString();
                            m5 = reader[5].ToString();
                            m6 = reader[6].ToString();
                            m7 = reader[7].ToString();
                            m8 = reader[8].ToString();
                            m9 = reader[9].ToString();
                            m10 = reader[10].ToString();
                            m11 = reader[11].ToString();
                            m12 = reader[12].ToString();
                            m13 = reader[13].ToString();
                            m14 = reader[14].ToString();
                            m15 = reader[15].ToString();
                            m16 = reader[16].ToString();
                            m17 = reader[17].ToString();
                            m18 = reader[18].ToString();
                            m19 = reader[19].ToString();


                        }

                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show("Exception:" + ex.ToString(), "Tips");

                    }
                    finally
                    {
                        mConnectionStartTest.Close();
                    }


                    string mTreeView = Main.MTreeName.ToString();
                    //string mTreeView = "表1";

                    string mQuery = "Select TestHisData as num,Test_Psernum as product_batch_NO,HA_STime as test_time,Htest_type as test_type From {0}";
                    mQuery = string.Format(mQuery, mTreeView);
                    mConnection = new OleDbConnection(sAccessConnection);

                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(mQuery, mConnection);
                    //DataGridView dz = new DataGridView();
                    //dz.DataSource = ds.Tables[0].DefaultView;
                    //如果需要再次查询，需清空dataset里面的数据  
                    int MTestData = 0;
                    try
                    {
                        if (mConnection.State != ConnectionState.Open) { mConnection.Open(); }




                        dataAdapter.Fill(ds);
                        MTestData = ds.Tables[0].Rows.Count + 1;
                        if ((ds.Tables[0].Rows.Count) != 0)
                        {
                            ds.Tables[0].Clear();
                        }


                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show("Exception:" + ex.ToString(), "Tips");

                    }

                    finally
                    {

                        mConnection.Close();

                    }
                    bool mflag = true;
                    string mSelectQueryH = "Select * From {0} where [TestHisData]= '" + MTestData.ToString() + "'";

                    mSelectQueryH = string.Format(mSelectQueryH, mTreeView);
                    mConnection = new OleDbConnection(sAccessConnection);
                    try
                    {
                        if (mConnection.State != ConnectionState.Open) { mConnection.Open(); }
                        OleDbCommand cmdH = new OleDbCommand(mSelectQueryH, mConnection);

                        object result = cmdH.ExecuteScalar();
                        if (result == null || result is DBNull)
                        {
                            mflag = true;


                        }
                        else
                        {
                            mflag = false;

                        }
                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show("Exception:" + ex.ToString(), "Tips");

                    }

                    finally
                    {

                        mConnection.Close();

                    }
                    while (mflag != true)
                    {
                        ++MTestData;
                        string mSelectQueryHN = "Select * From {0} where [TestHisData]= '" + MTestData.ToString() + "'";
                        mSelectQueryHN = string.Format(mSelectQueryHN, mTreeView);
                        try
                        {
                            if (mConnection.State != ConnectionState.Open) { mConnection.Open(); }
                            OleDbCommand cmdHN = new OleDbCommand(mSelectQueryHN, mConnection);
                            object result = cmdHN.ExecuteScalar();
                            if (result == null || result is DBNull)
                            {
                                mflag = true;


                            }
                            else
                            {
                                mflag = false;

                            }

                        }

                        catch (Exception ex)
                        {

                            MessageBox.Show("Exception:" + ex.ToString(), "Tips");

                        }

                        finally
                        {

                            mConnection.Close();

                        }

                    }


                    string mQueryInsert = String.Format("INSERT INTO {0}([TestHisData],[Htest_type],[Test_Psernum],[Test_Tsernum],[Test_Fsernum],[Test_filt],[Test_LIQU],[HA_STime],[Test_LIQUType],[Test_LIQUConsistence],[Test_Filter_type],[Test_Filter_Config],[Test_Filter_number],[Test_Filter_Area],[Test_Meme_Aper],[Test_Velocity],[Test_Up_Volm],[Test_startp],[Test_setBp],[Test_Dif_max],[Htest_Name],[Htest_DifValue],[Htest_Value],[Test_Result],[Htest_DiffePress],[Test_testimes],[p0],[p1],[p2],[p3],[p4],[p5],[p6],[p7],[p8],[p9],[p10],[p11],[p12],[p13],[p14],[p15],[p16],[p17],[p18],[p19],[p20],[p21],[p22],[p23],[p24],[p25],[p26],[p27],[p28],[p29],[p30],[p31],[p32],[p33],[p34],[p35],[p36],[p37],[p38],[p39],[p40],[p41],[p42],[p43],[p44],[p45],[p46],[p47],[p48],[p49]) VALUES ('" + MTestData.ToString() + "','" + m1.ToString() + "','" + m2.ToString() + "','" + m3.ToString() + "','" + m4.ToString() + "','" + m5.ToString() + "','" + m6.ToString() + "','" + m7.ToString() + "','" + m8.ToString() + "','" + m9.ToString() + "','" + m10.ToString() + "','" + m11.ToString() + "','" + m12.ToString() + "','" + m13.ToString() + "','" + m14.ToString() + "','" + m15.ToString() + "','" + m16.ToString() + "','" + m17.ToString() + "','" + m18.ToString() + "','" + m19.ToString() + "','" + Htest_Name.ToString() + "','" + Htest_DifValue.ToString() + "','" + Htest_TestValue.ToString() + "','" + Htest_ALL_Result.ToString() + "','" + Htest_DiffePress.ToString() + "','" + Htest_testimes.ToString() + "','" + mCurPT[0].ToString() + "', '" + mCurPT[1].ToString() + "','" + mCurPT[2].ToString() + "','" + mCurPT[3].ToString() + "','" + mCurPT[4].ToString() + "','" + mCurPT[5].ToString() + "','" + mCurPT[6].ToString() + "', '" + mCurPT[7].ToString() + "','" + mCurPT[8].ToString() + "','" + mCurPT[9].ToString() + "', '" + mCurPT[10].ToString() + "','" + mCurPT[11].ToString() + "', '" + mCurPT[12].ToString() + "','" + mCurPT[13].ToString() + "','" + mCurPT[14].ToString() + "','" + mCurPT[15].ToString() + "','" + mCurPT[16].ToString() + "', '" + mCurPT[17].ToString() + "','" + mCurPT[18].ToString() + "', '" + mCurPT[19].ToString() + "','" + mCurPT[20].ToString() + "','" + mCurPT[21].ToString() + "','" + mCurPT[22].ToString() + "','" + mCurPT[23].ToString() + "','" + mCurPT[24].ToString() + "', '" + mCurPT[25].ToString() + "','" + mCurPT[26].ToString() + "', '" + mCurPT[27].ToString() + "','" + mCurPT[28].ToString() + "','" + mCurPT[29].ToString() + "','" + mCurPT[30].ToString() + "','" + mCurPT[31].ToString() + "','" + mCurPT[32].ToString() + "','" + mCurPT[33].ToString() + "', '" + mCurPT[34].ToString() + "', '" + mCurPT[35].ToString() + "','" + mCurPT[36].ToString() + "', '" + mCurPT[37].ToString() + "', '" + mCurPT[38].ToString() + "','" + mCurPT[39].ToString() + "','" + mCurPT[40].ToString() + "','" + mCurPT[41].ToString() + "','" + mCurPT[42].ToString() + "', '" + mCurPT[43].ToString() + "', '" + mCurPT[44].ToString() + "','" + mCurPT[45].ToString() + "','" + mCurPT[46].ToString() + "','" + mCurPT[47].ToString() + "','" + mCurPT[48].ToString() + "','" + mCurPT[49].ToString() + "')", mTreeView.ToString());

                    mConnection = new OleDbConnection(sAccessConnection);
                    OleDbCommand da = new OleDbCommand(mQueryInsert, mConnection);

                    //

                    try
                    {
                        if (mConnection.State != ConnectionState.Open) { mConnection.Open(); }
                        da.ExecuteNonQuery();

                        MessageBox.Show("Save Success！", "Tips");



                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show("Exception:" + ex.ToString(), "Tips");

                    }

                    finally
                    {

                        mConnection.Close();

                    }
                }
            }
        }
        /// <summary>
        /// 打印手动泡点Result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ManualBubblePointPrinter mManualBubblePointPrinter = new ManualBubblePointPrinter();
                mManualBubblePointPrinter.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 查看Manual Bubble PointChart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxChart_Click(object sender, EventArgs e)
        {
            try
            {

                this.tabControlManualBubblePoint.SelectTab(tabPageManualBubblePointChart);//set为当前的选项卡
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 手动泡点存储Tips
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxSave_MouseEnter(object sender, EventArgs e)
        {
            try
            {

                ToolTip p = new ToolTip();
                p.ShowAlways = true;
                p.SetToolTip(this.pictureBoxSave, "Save Mannul.BP Result");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 打印手动泡点ResultTips
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxPrint_MouseEnter(object sender, EventArgs e)
        {
            try
            {

                ToolTip p = new ToolTip();
                p.ShowAlways = true;
                p.SetToolTip(this.pictureBoxPrint, "Print Mannul.BP Result");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 查看Manual Bubble PointChartTips
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxChart_MouseEnter(object sender, EventArgs e)
        {
            try
            {

                ToolTip p = new ToolTip();
                p.ShowAlways = true;
                p.SetToolTip(this.pictureBoxChart, "See Manual Bubble Point Chart");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// Filter Specification的选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxTest_Filter_Config_Click(object sender, EventArgs e)
        {
            try
            {
                Test_Filter_Config mTest_Filter_ConfigW = new Test_Filter_Config();
                mTest_Filter_ConfigW.ShowDialog();
                textBoxTest_Filter_Config.Text = Test_Filter_Config.mTest_Filter_Config;
                textBoxTest_Filter_Area.Text = Cartridge.Test_filter_Area;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// Testing Liquid选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxTest_LIQU_Click(object sender, EventArgs e)
        {
            try
            {

                Test_Liquid mTest_LiquidW = new Test_Liquid();
                mTest_LiquidW.ShowDialog();
               // textBoxTest_LIQU.Text = Test_Liquid.mTest_Liquid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 过滤发生改变时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxTest_Filter_Config_TextChanged(object sender, EventArgs e)
        {
            try
            {
                switch (textBoxTest_Filter_Config.Text)
                {
                    case "Cartridge":
                        Test_Filter_ConfigMP = Cartridge.Test_filter_Hight;
                        Test_Filter_numerMP = Cartridge.Test_filter_Num;
                        break;
                    case "Pannel":
                        Test_Filter_ConfigMP = Plate.Test_Filter_Diameter;

                        break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// Testing Liquid值改变的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxTest_LIQU_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Test_LIQUConsistenceMP = Concentration.mTest_LIQUConsistence;
                //if (textBoxTest_LIQU.Text == "Other")
                //{
                //    Test_LIQUMP = Fluid.Test_Filter_LiquidName;
                //}
                //else
                //{
                //    Test_LIQUMP = textBoxTest_LIQU.Text;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// Filter Area值改变的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxTest_Filter_Area_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxTest_Filter_Area.Text))
                {
                    Test_AreaMP = (Convert.ToInt64(((textBoxTest_Filter_Area.Text).Replace(".", "")))).ToString("X8");
                }
                else
                {
                    Test_AreaMP = (0).ToString("X8");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 启动按钮set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxstart_Click(object sender, EventArgs e)
        {
            try
            {
                usbReferenceDevice theReferenceUsbDevice = new usbReferenceDevice(USB.vid, USB.pid);
                CommPort mComPort = CommPort.Instance;
                mComPort.SearchDeviceAddress();
                if (mStatFlagMP == 1)
                {
                    //启动
                    pictureBoxstart.Image = SunManage.Properties.Resources.Analysis;


                    string str = "FF" + "{0}" + "06" + "01" + "52" + "00";
                    str = string.Format(str, CommPort.mDeviceAddress.ToString("X2"));
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


                    OleDbConnection mConnection;
                    string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\DeviceConcatenate.mdb";


                    string mQuery = "update DeviceConcatenate set [mStatFlagMP]='" + (0).ToString() + "' where [DeviceName]='" + (Main.MTreeName).ToString() + "'";


                    mConnection = new OleDbConnection(sAccessConnection);

                    OleDbCommand da = new OleDbCommand(mQuery, mConnection);


                    mConnection.Open();
                    da.ExecuteNonQuery();

                    mConnection.Close();
                    mStatFlagMP = 0;

                }
                else
                {
                    //停止
                    string str = "FF" + "{0}" + "06" + "01" + "53" + "00";
                    str = string.Format(str, CommPort.mDeviceAddress.ToString("X2"));
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
                    pictureBoxstart.Image = SunManage.Properties.Resources.Start;

                    OleDbConnection mConnection;
                    string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\DeviceConcatenate.mdb";


                    string mQuery = "update DeviceConcatenate set [mStatFlagMP]='" + (1).ToString() + "' where [DeviceName]='" + (Main.MTreeName).ToString() + "'"; ;


                    mConnection = new OleDbConnection(sAccessConnection);

                    OleDbCommand da = new OleDbCommand(mQuery, mConnection);


                    mConnection.Open();
                    da.ExecuteNonQuery();

                    mConnection.Close();
                    mStatFlagMP = 1;
                }
            }

            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        
        
    }
}
