using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
//引用创建Access数据库的库
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace SunManage.AllCheck
{
    public partial class RecordPrinter : Form
    {
        private OleDbConnection mConnection;
        string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\TestHistoryData.mdb";

        Main mTreeName = new Main();
        static DataTable DataTableGet;


        public RecordPrinter()
        {
            InitializeComponent();
            this.mSkinEngineRecordPrinter.SkinFile = "..\\..\\skin\\Vista1\\vista1_green.ssk";

        }

        private void RecordPrinter_Load(object sender, EventArgs e)
        {
            try
            {
                HistoricalRecords mHistoricalRecords = new HistoricalRecords();

                this.reportViewer.Reset();
                string mTreeView = Main.MTreeName.ToString();
                string mQuery = "Select [Htest_type] From {0} where TestHisData='" + HistoricalRecords.mPrintNo + "'";
                mQuery = string.Format(mQuery, mTreeView);
                mConnection = new OleDbConnection(sAccessConnection);

                if (HistoricalRecords.mPrintNo != null)
                {
                    mConnection.Open();
                    OleDbCommand cmd = new OleDbCommand(mQuery, mConnection);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        switch (reader[0].ToString())
                        {
                            case "Manual Bubble Point":
                                {
                                    this.reportViewer.LocalReport.ReportEmbeddedResource = "SunManage.AllCheck.ReportHMBPPT.rdlc";
                                }
                                break;
                            case "Basic Bubble Point":
                                {
                                    this.reportViewer.LocalReport.ReportEmbeddedResource = "SunManage.AllCheck.ReportHBBPPT.rdlc";
                                }
                                break;
                            case "Extensive Bubble Point":
                                {
                                    this.reportViewer.LocalReport.ReportEmbeddedResource = "SunManage.AllCheck.ReportHSBPPT.rdlc";
                                }
                                break;
                            case "Pressure Holding":
                                {
                                    this.reportViewer.LocalReport.ReportEmbeddedResource = "SunManage.AllCheck.ReportHRORPT.rdlc";
                                    break;
                                }
                            case "Diffusion Flow":
                                {
                                    this.reportViewer.LocalReport.ReportEmbeddedResource = "SunManage.AllCheck.ReportHDFCPT.rdlc";
                                }
                                break;
                            case "Water Immersion ":
                                {
                                    this.reportViewer.LocalReport.ReportEmbeddedResource = "SunManage.AllCheck.ReportHWITPT.rdlc";
                                }
                                break;
                            case "Ultrafiltration":
                                {
                                    this.reportViewer.LocalReport.ReportEmbeddedResource = "SunManage.AllCheck.ReportHDFCPTEx.rdlc";
                                }
                                break;
                            default: break;
                        }
                        reader.Close();
                        mConnection.Close();

                    }
                }




                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetRecordP", mHistoricalRecords.GetDataSet()));

                reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetCoords", dsPGet(HistoricalRecords.mPrintNo)));
                reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetCoordD", dsDGet(HistoricalRecords.mPrintNo)));


                this.reportViewer.RefreshReport();


                //// 将显示模式切换到打印布局模式
                this.reportViewer.SetDisplayMode(DisplayMode.PrintLayout);

                // 将缩放模式set为百分比
                this.reportViewer.ZoomMode = ZoomMode.Percent;

                // 设为 100% 
                this.reportViewer.ZoomPercent = 35;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Exception:" + ex.ToString(), "Tips");

            }
        }

        public static bool IsNumber(String strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            return !objNotNumberPattern.IsMatch(strNumber) &&
                   !objTwoDotPattern.IsMatch(strNumber) &&
                   !objTwoMinusPattern.IsMatch(strNumber) &&
                   objNumberPattern.IsMatch(strNumber);
        }

        public static List<string> GetData(string strData)
        {
            List<String> listInfo = new List<string>();
            string[] sArray = strData.Split(',');
            foreach (string strTemp in sArray)
            {
                // listInfo.Add(strTemp);
                if (IsNumber(strTemp))
                {
                    listInfo.Add(strTemp);
                }
                else if (strTemp == "")
                {
                    listInfo.Add("0");
                }

            }
            return listInfo;
        }

        /// <summary>
        /// 画曲线
        /// </summary>
        /// <returns></returns>
        public DataTable dsPGet(string mEditHistoricalIndex)
        {
            DataTable mDataTable = new DataTable("ds3");

            mDataTable.Columns.Add("Htest_Press_Line", typeof(Int32));
            mDataTable.Columns.Add("Test_startp", typeof(Int32));
            mDataTable.Columns.Add("DataTimeP", typeof(Int32));

            string mTreeView = Main.MTreeName.ToString();
            string mQuery = "Select [Htest_Press_Line],[Htest_Dif_Line],[Test_startp] From {0} where [TestHisData]='" + mEditHistoricalIndex + "'";
            mQuery = string.Format(mQuery, mTreeView);

            mConnection = new OleDbConnection(sAccessConnection);
            try
            {
                if (mEditHistoricalIndex != null)
                {
                    mConnection.Open();
                    OleDbCommand cmd = new OleDbCommand(mQuery, mConnection);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        int i = 0;
                        int j = 0;
                        string strDpress = reader[0].ToString();
                        string strStartup = reader[2].ToString();
                        List<string> temp = GetData(strDpress);
                        int k = 0;
                        int sum = 0;
                        foreach (string dp in temp)
                        {
                            if (k > (temp.Count / 2))
                            {
                                sum = sum + Convert.ToInt32(dp);
                            }
                            k++;
                        }

                        int length = 0;
                        if (sum == 0)
                        {
                            length = temp.Count / 5;
                        }
                        else
                        {
                            length = temp.Count / 2;
                        }
                        foreach (string dp in temp)
                        {
                            DataRow dr = mDataTable.NewRow();
                            if ((Convert.ToInt32(dp) == 0) && (j > length))
                            {
                            }
                            else
                            {
                                dr["Htest_Press_Line"] = Convert.ToInt32(dp);
                                dr["Test_startp"] = Convert.ToInt32(strStartup);
                                dr["DataTimeP"] = i++;
                                mDataTable.Rows.Add(dr);
                            }
                            j++;
                        }

                    }
                    reader.Close();
                    mConnection.Close();

                }
            }
            catch (Exception)
            {

            }
            return mDataTable;
        }

        public DataTable dsDGet(string mEditHistoricalIndex)
        {
            DataTable mDataTable = new DataTable("ds4");

            mDataTable.Columns.Add("Htest_Dif_Line", typeof(Int32));
            mDataTable.Columns.Add("DataTimeD", typeof(Int32));

            string mTreeView = Main.MTreeName.ToString();
            string mQuery = "Select [Htest_Press_Line],[Htest_Dif_Line],[Test_startp] From {0} where [TestHisData]='" + mEditHistoricalIndex + "'";
            mQuery = string.Format(mQuery, mTreeView);

            mConnection = new OleDbConnection(sAccessConnection);
            try
            {
                if (mEditHistoricalIndex != null)
                {
                    mConnection.Open();
                    OleDbCommand cmd = new OleDbCommand(mQuery, mConnection);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int j = 0;
                        List<string> strDif = GetData(reader[1].ToString());
                        if (strDif.Count == 0)
                        {
                            DataRow dk = mDataTable.NewRow();
                            dk["Htest_Dif_Line"] = 0;
                            dk["DataTimeD"] = 1;
                            mDataTable.Rows.Add(dk);
                        }
                        int k = 0;
                        int sum = 0;
                        foreach (string dp in strDif)
                        {
                            if (k > (strDif.Count / 2))
                            {
                                sum = sum + Convert.ToInt32(dp);
                            }
                            k++;
                        }

                        int m = 0;
                        int length = 0;
                        if (sum == 0)
                        {
                            length = strDif.Count / 5;
                        }
                        else
                        {
                            length = strDif.Count / 2;
                        }

                        foreach (string dp in strDif)
                        {
                            DataRow dk = mDataTable.NewRow();
                            if (string.IsNullOrWhiteSpace(dp) || string.IsNullOrEmpty(dp) || (dp == ""))
                            {
                                if (m <= length)
                                {
                                    dk["Htest_Dif_Line"] = 0;
                                    dk["DataTimeD"] = j++;
                                }
                            }
                            else
                            {
                                if ((m > length) && (Convert.ToInt32(dp) == 0))
                                {
                                }
                                else
                                {

                                    dk["Htest_Dif_Line"] = Convert.ToInt32(dp);
                                    dk["DataTimeD"] = j++;
                                }
                            }
                            m++;
                            mDataTable.Rows.Add(dk);
                        }

                    }
                    reader.Close();
                    mConnection.Close();

                }
            }
            catch (Exception)
            {
            }
            return mDataTable;
        }

        /// <summary>
        /// 关闭窗口时释放资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void RecordPrinter_FormClosed(object sender, FormClosedEventArgs e)
        {
            reportViewer.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
