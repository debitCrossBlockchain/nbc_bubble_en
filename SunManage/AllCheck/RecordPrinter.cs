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
            string mQuery = "Select [Htest_type] From {0} where TestHisData='" + HistoricalRecords.mPrintNo+"'";
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

            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetCoords", DataTableGet));
          

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

        /// <summary>
        /// 画Chart
        /// </summary>
        /// <returns></returns>
        public DataTable dsGet(string mEditHistoricalIndex)
        {
           
           
            DataTable mDataTable = new DataTable("ds2");

            mDataTable.Columns.Add("DataPressure", typeof(Int32));
            mDataTable.Columns.Add("DataTime", typeof(Int32));
            mDataTable.Columns.Add("Test_setBp", typeof(Int32));
            
            string mTreeView = Main.MTreeName.ToString();
            string mQuery = "Select [p0],[p1],[p2],[p3],[p4],[p5],[p6],[p7],[p8],[p9],[p10],[p11],[p12],[p13],[p14],[p15],[p16],[p17],[p18],[p19],[p20],[p21],[p22],[p23],[p24],[p25],[p26],[p27],[p28],[p29],[p30],[p31],[p32],[p33],[p34],[p35],[p36],[p37],[p38],[p39],[p40],[p41],[p42],[p43],[p44],[p45],[p46],[p47],[p48],[p49],[Test_testimes],[Test_setBp],[Htest_type] From {0} where [TestHisData]='" + mEditHistoricalIndex+"'";
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
                   
                       
                    
                    for (int i = 0; i <Convert.ToInt64(reader[50]); i++)
                    {
                        if ((reader[52].ToString() == "Diffusion Flow" )|| (reader[52].ToString() == "Pressure Holding"))
                        {
                            if (reader[i].ToString() == "\0" || reader[i].ToString() == "")
                            {
                                DataRow dr = mDataTable.NewRow();
                                dr["DataPressure"] = 0;
                                dr["DataTime"] = i;
                                dr["Test_setBp"] = 0;


                                mDataTable.Rows.Add(dr);
                            }
                            else
                            {
                                DataRow dr = mDataTable.NewRow();
                                dr["DataPressure"] = Convert.ToInt32(reader[i].ToString());
                                dr["DataTime"] = i;
                                dr["Test_setBp"] = 0;
                                mDataTable.Rows.Add(dr);
                            }
                           
                        }
                        else
                        {
                           
                            if (reader[i].ToString() == "\0" || reader[i].ToString() == "")
                            {

                                DataRow dr = mDataTable.NewRow();
                                dr["DataPressure"] = 0;
                                dr["DataTime"] = i;
                                if (reader[51].ToString() == "\0" || reader[51].ToString() == "")
                                {
                                    dr["Test_setBp"] = 0;
                                }
                                else
                                {
                                    dr["Test_setBp"] = Convert.ToInt64(reader[51]);
                                }
                                mDataTable.Rows.Add(dr);
                            }
                            else
                            {
                                DataRow dr = mDataTable.NewRow();
                                dr["DataPressure"] = Convert.ToInt32(reader[i].ToString().Trim());
                                dr["DataTime"] = i;
                                if (reader[51].ToString() == "\0" || reader[51].ToString() == "")
                                {
                                    dr["Test_setBp"] = 0;
                                }
                                else
                                {
                                    dr["Test_setBp"] = Convert.ToInt64(reader[51]);
                                }
                                mDataTable.Rows.Add(dr);
                            }
                        }


                    }

                    reader.Close();



                    mConnection.Close();
           
                }
            }
            else
            {
                for (int i = 0; i <= 60; i++)
                {

                    DataRow dr = mDataTable.NewRow();
                    dr["DataPressure"] = 0;
                    dr["DataTime"] = i;
                    mDataTable.Rows.Add(dr);
                }
            }
            }
            catch(Exception)
            {
               
            }

            DataTableGet = mDataTable;

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
