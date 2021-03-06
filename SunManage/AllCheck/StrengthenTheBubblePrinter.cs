﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Xml;
//引用创建Access数据库的库
using System.Data.OleDb;

namespace SunManage.AllCheck
{
    public partial class StrengthenTheBubblePrinter : Form
    {
        private OleDbConnection mConnectionStartTest;
        string sAccessConnectionStartTest = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\StartTest.mdb";
        public StrengthenTheBubblePrinter()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取数据集方法
        /// </summary>
        public DataTable GetDataSet()
        {
            DataTable mDataTable = new DataTable("ds3");
          



                mDataTable.Columns.Add("Test_Psernum", typeof(string));
                mDataTable.Columns.Add("Test_Fsernum", typeof(string));
                mDataTable.Columns.Add("Test_startp", typeof(string));
                mDataTable.Columns.Add("Test_setBp", typeof(string));
                mDataTable.Columns.Add("Test_Up_Volm", typeof(string));
                mDataTable.Columns.Add("Test_Tsernum", typeof(string));
                mDataTable.Columns.Add("Test_Meme_Aper", typeof(string));
                mDataTable.Columns.Add("Test_Dif_max", typeof(string));
                mDataTable.Columns.Add("Test_filt", typeof(string));
                mDataTable.Columns.Add("Test_Filter_Config", typeof(string));
                mDataTable.Columns.Add("Test_Filter_Area", typeof(string));
                mDataTable.Columns.Add("Test_LIQU", typeof(string));
                mDataTable.Columns.Add("Test_Time", typeof(string));
                mDataTable.Columns.Add("Test_Value", typeof(string));
                mDataTable.Columns.Add("Test_Result", typeof(string));
                mDataTable.Columns.Add("Test_Name", typeof(string));
                mDataTable.Columns.Add("Test_DeviceName", typeof(string));
                mDataTable.Columns.Add("Test_DifValue", typeof(string));




                string mTreeName = Main.MTreeName.ToString();

                if (!string.IsNullOrEmpty(mTreeName))
                {



                    string mSelectQuery = "Select * FROM [SBStartTest] Where [DeviceName]= '" + mTreeName.ToString() + "'";



                    mConnectionStartTest = new OleDbConnection(sAccessConnectionStartTest);
                    try
                    {

                        if (mConnectionStartTest.State != ConnectionState.Open) { mConnectionStartTest.Open(); }

                        OleDbCommand cmd = new OleDbCommand(mSelectQuery, mConnectionStartTest);
                        cmd.CommandType = CommandType.Text;

                        OleDbDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {


                            DataRow dr = mDataTable.NewRow();

                            dr["Test_Psernum"] = reader[2].ToString();

                            dr["Test_Fsernum"] = reader[4].ToString();

                            dr["Test_startp"] = reader[17].ToString();

                            dr["Test_setBp"] = reader[18].ToString();

                            dr["Test_Up_Volm"] = reader[16].ToString();

                            dr["Test_Meme_Aper"] = reader[14].ToString();

                            dr["Test_Tsernum"] = reader[3].ToString();

                            dr["Test_filt"] = reader[5].ToString();

                            dr["Test_Filter_Config"] = reader[10].ToString();

                            dr["Test_LIQU"] = reader[8].ToString();
                           
                            dr["Test_Filter_Area"] = reader[13].ToString();
                            dr["Test_Dif_max"] = reader[19].ToString();
                            dr["Test_Time"] = reader[3].ToString();
                            dr["Test_Value"] = StrengthenTheBubble.Htest_TestValue.ToString();
                            dr["Test_Result"] = StrengthenTheBubble.Htest_ALL_Result;
                            dr["Test_Name"] = StrengthenTheBubble.Htest_Name;
                            dr["Test_DeviceName"] = Main.MTreeName.ToString();

                            mDataTable.Rows.Add(dr);

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
                
                return mDataTable;

            
        }
        /// <summary>
        /// 画Chart
        /// </summary>
        /// <returns></returns>
        private DataTable ds()
        {
            DataTable mDataTable = new DataTable("ds2");

            mDataTable.Columns.Add("DataPressure", typeof(Int32));
            mDataTable.Columns.Add("DataTime", typeof(Int32));


            for (int i = 0; i <= 49; i++)
            {

                if (BasicBubblePoint.mCurPT[i].ToString() == "\0" || BasicBubblePoint.mCurPT[i].ToString() == "")
                {
                    DataRow dr = mDataTable.NewRow();
                    dr["DataPressure"] = 0;
                    dr["DataTime"] = i;
                    mDataTable.Rows.Add(dr);
                }
                else
                {
                    DataRow dr = mDataTable.NewRow();
                    dr["DataPressure"] = BasicBubblePoint.mCurPT[i];
                    dr["DataTime"] = i;
                    mDataTable.Rows.Add(dr);
                }

            }
            return mDataTable;
        }

        private void StrengthenTheBubblePrinter_Load(object sender, EventArgs e)
        {
            //HistoricalRecords mHistoricalRecords = new HistoricalRecords();

            this.reportViewer.Reset();
            this.reportViewer.LocalReport.ReportEmbeddedResource = "SunManage.AllCheck.ReportSBPPT.rdlc";
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetSBPReport", GetDataSet()));

            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetSBPPTReport", ds()));


            this.reportViewer.RefreshReport();


            //// 将显示模式切换到打印布局模式
            this.reportViewer.SetDisplayMode(DisplayMode.PrintLayout);

            // 将缩放模式set为百分比
            this.reportViewer.ZoomMode = ZoomMode.Percent;

            // 设为 100% 
            this.reportViewer.ZoomPercent = 35;
        }
        /// <summary>
        /// 窗口关闭后的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StrengthenTheBubblePrinter_FormClosed(object sender, FormClosedEventArgs e)
        {
            reportViewer.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
