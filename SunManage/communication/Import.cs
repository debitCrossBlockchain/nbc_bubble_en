using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
//引用创建Access数据库的库
using System.Data.OleDb;
using System.Collections;

namespace SunManage.communication
{
    public partial class Import : Form
    {
       
        private static int mflag = 0;//标志位查看数据库是否存在这条记录
        private static int flag = 0;
        string firstLine = "";//文本文件的第一行
        private OleDbConnection mConnection;
        string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\TestHistoryData.mdb";
        public Import()
        {
            InitializeComponent();
        }

        private void buttonLoadSQL_Click(object sender, EventArgs e)
        {
            //string InitialDireectory = string.Format(@"{0}\..\..\", AppDomain.CurrentDomain.setupInformation.ApplicationBase);Application.StartupPath +
            openFileDialogtxt.InitialDirectory = @"../../USB";
            openFileDialogtxt.Filter = "File|*.*";
            openFileDialogtxt.FilterIndex = 2;
            openFileDialogtxt.RestoreDirectory = false;
            //openFileDialog1.ShowHelp = true;// 对话框 发生变化
            openFileDialogtxt.Title = "Open";
            openFileDialogtxt.FileName = "";
            openFileDialogtxt.Multiselect = true;
  
              if (openFileDialogtxt.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialogtxt.FileName.ToString();

                StreamReader objReader = new StreamReader(filePath,System.Text.Encoding.GetEncoding("GB2312"));

                char[] parsChar = { ',' };

                string sLine = "";
                firstLine = objReader.ReadLine();
                //MessageBox.Show(firstLine);
                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null && !sLine.Equals(""))
                    {
                       
                        string mTreeView = Main.MTreeName.ToString();
                        string HTestHisData = sLine.Split(parsChar)[0].ToString();
                            string Htest_type = "";
                            switch (sLine.Split(parsChar)[1].ToString())
                            {
                                case "M":
                                    {
                                        Htest_type = "Manual Bubble Point";
                                    }
                                    break;
                                case "B":
                                    {
                                        Htest_type = "Basic Bubble Point";
                                    }
                                    break;
                                case "A":
                                    {
                                        Htest_type = "Extensive Bubble Point";
                                    }
                                    break;
                                case "P":
                                    {
                                        Htest_type = "Pressure Holding";
                                    }
                                    break;
                                case "D":
                                    {
                                        Htest_type = "Diffusion Flow";
                                    }
                                    break;
                                case "H":
                                    {
                                        Htest_type = "Water Immersion";
                                    }
                                    break;
                                case "d":
                                    {
                                        Htest_type = "Ultrafiltration";
                                    }
                                    break;
                                default: break;


                            }
                            string HTest_Psernum = sLine.Split(parsChar)[2].ToString();
                            if (HTest_Psernum == null)
                            {
                                HTest_Psernum = "";
                            }
                            string THA_STime = sLine.Split(parsChar)[3].ToString();
                            if (THA_STime == null)
                            {
                                THA_STime = "";
                            }
                            string HTest_Name = sLine.Split(parsChar)[4].ToString();
                            if (HTest_Name == null)
                            {
                                HTest_Name = "";
                            }
                            string HTest_Fsernum = sLine.Split(parsChar)[5].ToString();
                            if (HTest_Fsernum == null)
                            {
                                HTest_Fsernum = "";
                            }
                            string HTest_filt = sLine.Split(parsChar)[6].ToString();
                            if (HTest_filt == null)
                            {
                                HTest_filt = "";
                            }
                            string HTest_LIQU = sLine.Split(parsChar)[7].ToString();
                            if (HTest_LIQU == null)
                            {
                                HTest_LIQU = "";
                            }
                            string HTest_Filt_Hight = sLine.Split(parsChar)[8].ToString();
                            if (HTest_Filt_Hight == null)
                            {
                                HTest_Filt_Hight = "";
                            }
                            string HTest_Filt_Num = sLine.Split(parsChar)[9].ToString();
                            if (HTest_Filt_Num == null)
                            {
                                HTest_Filt_Num = "";
                            }
                            string HTest_Result = sLine.Split(parsChar)[10].ToString();
                            if (HTest_Result == null)
                            {
                                HTest_Result = "";
                            }
                            string HTest_startp = sLine.Split(parsChar)[11].ToString();
                            if (HTest_startp == null)
                            {
                                HTest_startp = "";
                            }
                            string HTest_SetBp = sLine.Split(parsChar)[12].ToString();
                            if (HTest_SetBp == null)
                            {
                                HTest_SetBp = "";
                            }
                            string HTest_Up_Volm = sLine.Split(parsChar)[13].ToString();
                            if (HTest_Up_Volm == null)
                            {
                                HTest_Up_Volm = "";
                            }
                            string THest_Dif_max = sLine.Split(parsChar)[14].ToString();
                            if (THest_Dif_max == null)
                            {
                                THest_Dif_max = "";
                            }
                            string Htest_DifValue = sLine.Split(parsChar)[15].ToString();
                            if (Htest_DifValue == null)
                            {
                                Htest_DifValue = "";
                            }
                            string Htest_Value = sLine.Split(parsChar)[16].ToString();
                            if (Htest_Value == null)
                            {
                                Htest_Value = "";
                            }
                            string HTest_Filter_Area = sLine.Split(parsChar)[17].ToString();
                            if (HTest_Filter_Area == null)
                            {
                                HTest_Filter_Area = "";
                            }
                            string HTest_Meme_Aper = sLine.Split(parsChar)[18].ToString();
                            if (HTest_Meme_Aper == null)
                            {
                                HTest_Meme_Aper = "";
                            }
                            string HTest_Filter_type = sLine.Split(parsChar)[19].ToString();
                            if (HTest_Filter_type == null)
                            {
                                HTest_Filter_type = "";
                            }
                            string Htest_DiffePress = sLine.Split(parsChar)[20].ToString();
                            if (Htest_DiffePress == null)
                            {
                                Htest_DiffePress = "";
                            }
                            string HTest_CDifValue = sLine.Split(parsChar)[21].ToString();
                            if (HTest_CDifValue == null)
                            {
                                HTest_CDifValue = "";
                            }
                            string Htest_testimes = sLine.Split(parsChar)[22].ToString();
                            if (Htest_testimes == null)
                            {
                                Htest_testimes = "";
                            }
                            string HTest_Sampling_Frequency = sLine.Split(parsChar)[23].ToString();
                            if (HTest_Sampling_Frequency == null)
                            {
                                HTest_Sampling_Frequency = "";
                            }
                            string HTest_DifStart = sLine.Split(parsChar)[24].ToString();
                            if (HTest_DifStart == null)
                            {
                                HTest_DifStart = "";
                            }
                            string HtestName = sLine.Split(parsChar)[25].ToString();
                            if (HtestName == null)
                            {
                                HtestName = "";
                            }
                            string Htest_Press_Line = "";
                            for (int i = 26; i < 90; i++)
                            {
                                Htest_Press_Line = Htest_Press_Line + sLine.Split(parsChar)[i].ToString() + ',';
                            }
                            Htest_Press_Line = Htest_Press_Line.Substring(0, Htest_Press_Line.Length - 2);

                            string Htest_Dif_Line = "";
                            for (int i = 91; i < 155; i++)
                            {
                                Htest_Dif_Line = Htest_Dif_Line + sLine.Split(parsChar)[i].ToString() + ',';
                            }
                            Htest_Dif_Line = Htest_Dif_Line.Substring(0, Htest_Dif_Line.Length - 2);


                            string mQuery = String.Format("INSERT INTO {0}([TestHisData],[Htest_type],[Test_Psernum],[HA_STime],[Test_Name],[Test_Fsernum],[Test_filt],[Test_LIQU],[Test_Filt_Hight],[Test_Filt_Num],[Test_Result],[Test_startp],[Test_SetBp],[Test_Up_Volm],[Test_Dif_max],[Htest_DifValue],[Htest_Value],[Test_Filter_Area],[Test_Meme_Aper],[Test_Filter_type],[Htest_DiffePress],[Test_CDifValue],[Test_testimes],[Test_Sampling_Frequency],[Htest_DifStart],[Htest_Name],[Htest_Press_Line],[Htest_Dif_Line]) VALUES ('" + HTestHisData.ToString() + "','" + Htest_type.ToString() + "','" + HTest_Psernum.ToString() + "','" + THA_STime.ToString() + "','" + HTest_Name.ToString() + "','" + HTest_Fsernum.ToString() + "','" + HTest_filt.ToString() + "','" + HTest_LIQU.ToString() + "','" + HTest_Filt_Hight.ToString() + "','" + HTest_Filt_Num.ToString() + "','" + HTest_Result.ToString() + "','" + HTest_startp.ToString() + "','" + HTest_SetBp.ToString() + "', '" + HTest_Up_Volm.ToString() + "','" + THest_Dif_max.ToString() + "','" + Htest_DifValue.ToString() + "','" + Htest_Value.ToString() + "','" + HTest_Filter_Area.ToString() + "','" + HTest_Meme_Aper.ToString() + "','" + HTest_Filter_type.ToString() + "','" + Htest_DiffePress.ToString() + "','" + HTest_CDifValue.ToString() + "','" + Htest_testimes.ToString() + "','" + HTest_Sampling_Frequency.ToString() + "','" + HTest_DifStart.ToString() + "','" + HtestName.ToString() + "','" + Htest_Press_Line.ToString() + "','" + Htest_Dif_Line.ToString() + "')", mTreeView);
                            mConnection = new OleDbConnection(sAccessConnection);
                            mConnection.Open();
                            OleDbCommand da = new OleDbCommand(mQuery, mConnection);

                            try
                            {
                                da.CommandType = CommandType.Text;
                                if (mConnection.State != ConnectionState.Open) { mConnection.Open(); }
                                da.ExecuteNonQuery();
                                this.Close();

                            }

                            catch (Exception ex)
                            {
                                //LogClass.WriteLogFile("Exception:" + ex.ToString());
                            }
                            finally
                            {
                                mflag = 0;
                                mConnection.Close();

                            }
                    }
                }

                MessageBox.Show("completed！", "prompt");
                objReader.Close();
               
                this.Close();
            } 
            }
        }


    }


