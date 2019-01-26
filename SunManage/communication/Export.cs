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
using System.IO;
using System.Collections;
namespace SunManage.communication
{
    public partial class Export : Form
    {

        private OleDbConnection mConnection;
        string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\TestHistoryData.mdb";
        private DataSet ds = new DataSet();//数据库操作
        //private DataSet ds1 = new DataSet();//数据库操作
        Main mTreeName = new Main();
        public Export()
        {
            InitializeComponent();
        }

        private void Export_Load(object sender, EventArgs e)
        {

            string mTreeView = Main.MTreeName.ToString();
            //string mQuery = "Select TestHisData as num,Test_Psernum as Product_batch,Test_Fsernum as product_name,HA_STime as test_time,Htest_type as test_type From {0}";
            string mQuery = "Select TestHisData as num, Htest_type as Testing_mode,Test_Psernum as Product_batch ,HA_STime as test_time,Test_Name as Test_Name,Test_Fsernum as Test_Fsernum,Test_filt as Test_filt,Test_LIQU as Test_LIQU,Test_Filt_Hight as Test_Filt_Hight,Test_Filt_Num as Test_Filt_Num,Test_Result as Test_Result,Test_startp as Test_startp,Test_SetBp as Test_SetBp,Test_Up_Volm as Test_Up_Volm,Test_Dif_max as Test_Dif_max,Htest_DifValue as Htest_DifValue,Htest_Value as Htest_Value,Test_Filter_Area as Test_Filter_Area,Test_Meme_Aper as Test_Meme_Aper,Test_Filter_type as Test_Filter_type,Htest_DiffePress as Htest_DiffePress,Test_CDifValue as Test_CDifValue,Test_testimes as Test_testimes,Test_Sampling_Frequency as Test_Sampling_Frequency,Htest_DifStart as Htest_DifStart,Htest_Name as Htest_Name,Htest_Press_Line as Htest_Press_Line,Htest_Dif_Line as Htest_Dif_Line  From {0}";
            mQuery = string.Format(mQuery, mTreeView);
            mConnection = new OleDbConnection(sAccessConnection);

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(mQuery, mConnection);
            //DataGridView dz = new DataGridView();
            //dz.DataSource = ds.Tables[0].DefaultView;
            //如果需要再次查询，需清空dataset里面的数据  
            try
            {
                mConnection.Open();


                dataAdapter.Fill(ds);
                dataGridViewExportInfo.DataSource = ds.Tables[0].DefaultView;
                dataGridViewExportInfo.AllowUserToAddRows = false;

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

        private void buttonExportRefresh_Click(object sender, EventArgs e)
        {

            string mTreeView = Main.MTreeName.ToString();
            string mQuery = "Select TestHisData as num, Htest_type as Testing_mode,Test_Psernum as Product_batch ,HA_STime as test_time,Test_Name as Test_Name,Test_Fsernum as Test_Fsernum,Test_filt as Test_filt,Test_LIQU as Test_LIQU,Test_Filt_Hight as Test_Filt_Hight,Test_Filt_Num as Test_Filt_Num,Test_Result as Test_Result,Test_startp as Test_startp,Test_SetBp as Test_SetBp,Test_Up_Volm as Test_Up_Volm,Test_Dif_max as Test_Dif_max,Htest_DifValue as Htest_DifValue,Htest_Value as Htest_Value,Test_Filter_Area as Test_Filter_Area,Test_Meme_Aper as Test_Meme_Aper,Test_Filter_type as Test_Filter_type,Htest_DiffePress as Htest_DiffePress,Test_CDifValue as Test_CDifValue,Test_testimes as Test_testimes,Test_Sampling_Frequency as Test_Sampling_Frequency,Htest_DifStart as Htest_DifStart,Htest_Name as Htest_Name,Htest_Press_Line as Htest_Press_Line,Htest_Dif_Line as Htest_Dif_Line  From {0}";
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
                //string mQuery = String.Format("insert into {0}([Test_Num],[HA_STime],[Test_Psernum],[Htest_type],[Test_Result],[Test_filt],[Test_LIQU],[Test_Meme_Aper],[Test_Filter_type],[Test_Filter_number],[Test_Filter_Config],[Test_startp],[Test_Up_Volm],[Test_Filter_Area],[Test_LIQUConsistence],[Test_setBp],[Test_Dif_max],[Htest_Value],[Htest_DifValue],[Htest_DiffePress]) values ('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}')", mTreeView, mTest_Num, DTime, Psernum, Htest_type, HtestResult, Test_filt, Test_LIQU, Test_Meme_Aper, Test_Filter_type, Test_Filter_numer, Test_Filter_Config, Test_startp, Test_Up_Volm, Test_Filter_Area, Test_LIQUConsistence, Test_setBp, Test_Dif_max, Htest_TestValue, Htest_DifValue, Htest_DiffePress);
                //// mQuery = string.Format(mQuery, mTreeView);

                dataAdapter.Fill(ds);
                dataGridViewExportInfo.DataSource = ds.Tables[0].DefaultView;
                dataGridViewExportInfo.AllowUserToAddRows = false;

            }

            catch (Exception ex)
            {

                File.WriteAllText(DateTime.Now.ToShortDateString(), "Exception:" + ex.ToString());
                MessageBox.Show("The program is out of order. Check the log");

            }
            finally
            {

                mConnection.Close();

            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridViewExportInfo.Rows.Count > 0)
                {

                    saveFileDialogExport.InitialDirectory = @"..\..\Export";
                    saveFileDialogExport.Filter = "File|*.*";
                    saveFileDialogExport.FilterIndex = 2;
                    //saveFileDialog1.RestoreDirectory =false ;
                    saveFileDialogExport.ShowHelp = true;
                    saveFileDialogExport.Title = "Savet";
                    saveFileDialogExport.FileName = DateTime.Now.ToString("yyyy-MM-dd ");
                    saveFileDialogExport.RestoreDirectory = true;
                    if (saveFileDialogExport.ShowDialog() == DialogResult.OK)
                    {
                        string saveName = saveFileDialogExport.FileName.ToString();


                        string str = dataGridViewExportInfo.Rows.Count.ToString() + "\r\n";
                        for (int i = 0; i < dataGridViewExportInfo.Rows.Count; i++)
                        {
                            string Htest_type = "";
                            switch (dataGridViewExportInfo.Rows[i].Cells[1].Value.ToString())
                            {
                                case "Manual Bubble Point":
                                    {
                                        Htest_type = "M";
                                    }
                                    break;
                                case "Basic Bubble Point":
                                    {
                                        Htest_type = "B";
                                    }
                                    break;
                                case "Extensive Bubble Point":
                                    {
                                        Htest_type = "A";
                                    }
                                    break;
                                case "Pressure Holding":
                                    {
                                        Htest_type = "P";
                                    }
                                    break;
                                case "Diffusion Flow":
                                    {
                                        Htest_type = "D";
                                    }
                                    break;
                                case "Water Immersion":
                                    {
                                        Htest_type = "H";
                                    }
                                    break;
                                case "Ultrafiltration":
                                    {
                                        Htest_type = "d";
                                    }
                                    break;
                                default: break;


                            }

                            str = str + (i + 1).ToString() + "," + Htest_type;
                            for (int j = 2; j < 26; j++)
                            {
                                str = str + "," + dataGridViewExportInfo.Rows[i].Cells[j].Value.ToString();

                            }
                            string strPrcess = dataGridViewExportInfo.Rows[i].Cells[26].Value.ToString();
                            string strDif = dataGridViewExportInfo.Rows[i].Cells[27].Value.ToString();
                            str = str + "," + strPrcess + "," + "," + "," + strDif + "," + "\r\n";
                        }

                        File.WriteAllText(saveName, str, System.Text.Encoding.GetEncoding("GB2312"));
                        MessageBox.Show("exported file!");
                    }

                }
            }

            catch (Exception ex)
            {

                File.WriteAllText(DateTime.Now.ToShortDateString(), "Exception:" + ex.ToString());
                MessageBox.Show("The program is out of order. Check the log");

            }
        }
    }
}
