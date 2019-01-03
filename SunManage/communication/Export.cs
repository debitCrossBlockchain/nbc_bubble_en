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
            string mQuery = "Select TestHisData as num, Htest_type as Testing_mode,Test_Psernum as Product_batch ,HA_STime as test_time,Test_Tsernum as Tsernum,Test_Fsernum as Fsernum,Test_filt as Filter_Material_Type,Test_LIQUType as Testing_Liquid,Test_Filter_Config as Filter_Config,Test_Filter_number as Filter_Amount,Test_Result as Result,Test_startp as Start_Pressure,Test_setBp as Min_BP,Test_Up_Volm as Upstream_Volume,Test_Dif_max as Max_DF,Htest_DifValue as Real_DF,Htest_Value as Testing_BP,Test_Filter_Area as Filter_Area,Test_Meme_Aper as Aperture,Test_Filter_type as Test_Filter_type,Htest_DiffePress as Pressure_Damping,Test_testimes as Times,Htest_Name as Tester,p0 as 0,p1 as 1,p2 as 2,p3 as 3,p4 as 4,p5 as 5,p6 as 6,p7 as 7,p8 as 8,p9 as 9,p10 as 10,p11 as 11,p12 as 12,p13 as 13,p14 as 14,p15 as 15,p16 as 16,p17 as 17,p18 as 18,p19 as 19,p20 as 20,p21 as 21,p22 as 22,p23 as 23,p24 as 24,p25 as 25,p26 as 26,p27 as 27,p28 as 28,p29 as 29,p30 as 30,p31 as 31,p32 as 32,p33 as 33,p34 as 34,p35 as 35,p36 as 36,p37 as 37,p38 as 38,p39 as 39,p40 as 40,p41 as 41,p42 as 42,p43 as 43,p44 as 44,p45 as 45,p46 as 46,p47 as 47,p48 as 48,p49 as 49  From {0}";
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
            string mQuery = "Select TestHisData as num, Htest_type as Testing_mode,Test_Psernum as Product_batch ,HA_STime as test_time,Test_Tsernum as Tsernum,Test_Fsernum as Fsernum,Test_filt as Filter_Material_Type,Test_LIQUType as Testing_Liquid,Test_Filter_Config as Filter_Config,Test_Filter_number as Filter_Amount,Test_Result as Result,Test_startp as Start_Pressure,Test_setBp as Min_BP,Test_Up_Volm as Upstream_Volume,Test_Dif_max as Max_DF,Htest_DifValue as Real_DF,Htest_Value as Testing_BP,Test_Filter_Area as Filter_Area,Test_Meme_Aper as Aperture,Test_Filter_type as Test_Filter_type,Htest_DiffePress as Pressure_Damping,Test_testimes as Times,Htest_Name as Tester,p0 as 0,p1 as 1,p2 as 2,p3 as 3,p4 as 4,p5 as 5,p6 as 6,p7 as 7,p8 as 8,p9 as 9,p10 as 10,p11 as 11,p12 as 12,p13 as 13,p14 as 14,p15 as 15,p16 as 16,p17 as 17,p18 as 18,p19 as 19,p20 as 20,p21 as 21,p22 as 22,p23 as 23,p24 as 24,p25 as 25,p26 as 26,p27 as 27,p28 as 28,p29 as 29,p30 as 30,p31 as 31,p32 as 32,p33 as 33,p34 as 34,p35 as 35,p36 as 36,p37 as 37,p38 as 38,p39 as 39,p40 as 40,p41 as 41,p42 as 42,p43 as 43,p44 as 44,p45 as 45,p46 as 46,p47 as 47,p48 as 48,p49 as 49  From {0}";
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
                                case "Water Immersion ":
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

                            string m14 = "";
                            if (!string.IsNullOrWhiteSpace(dataGridViewExportInfo.Rows[i].Cells[14].Value.ToString()))
                                m14 = Convert.ToInt64((dataGridViewExportInfo.Rows[i].Cells[14].Value.ToString().Replace(".", ""))).ToString();
                            string m15 = "";
                            if (!string.IsNullOrWhiteSpace(dataGridViewExportInfo.Rows[i].Cells[15].Value.ToString()))
                                m15 = (Convert.ToInt64(((dataGridViewExportInfo.Rows[i].Cells[15].Value).ToString().Replace(".", "")))).ToString();

                            string m8 = "";
                            if (!string.IsNullOrWhiteSpace(dataGridViewExportInfo.Rows[i].Cells[8].Value.ToString()))
                                m8 = dataGridViewExportInfo.Rows[i].Cells[8].Value.ToString().Replace('"'.ToString(), "");

                            string m17 = "";
                            if (!string.IsNullOrWhiteSpace(dataGridViewExportInfo.Rows[i].Cells[17].Value.ToString()))
                                m17 = Convert.ToInt64((dataGridViewExportInfo.Rows[i].Cells[17].Value.ToString().Replace(".", ""))).ToString();

                            string m18 = "";
                            if (!string.IsNullOrWhiteSpace(dataGridViewExportInfo.Rows[i].Cells[18].Value.ToString()))
                                m18 = Convert.ToInt64((dataGridViewExportInfo.Rows[i].Cells[18].Value.ToString().Replace(".", ""))).ToString();
                            str += (i + 1).ToString() + "," + Htest_type + "," + dataGridViewExportInfo.Rows[i].Cells[2].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[3].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[5].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[4].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[6].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[7].Value.ToString() + "," + m8 + "," + dataGridViewExportInfo.Rows[i].Cells[9].Value.ToString().Replace("%", "") + "," + dataGridViewExportInfo.Rows[i].Cells[10].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[11].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[12].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[13].Value.ToString() + "," + m14.ToString() + "," + m15.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[16].Value.ToString() + "," + m17.ToString() + "," + m18.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[19].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[20].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[21].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[22].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[23].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[24].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[25].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[26].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[27].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[28].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[29].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[30].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[31].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[32].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[33].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[34].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[35].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[36].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[37].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[38].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[39].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[40].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[41].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[42].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[43].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[44].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[45].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[46].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[47].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[48].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[49].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[50].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[51].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[52].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[53].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[54].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[55].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[56].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[57].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[58].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[59].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[60].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[61].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[62].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[63].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[64].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[65].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[66].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[67].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[68].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[69].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[70].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[71].Value.ToString() + "," + dataGridViewExportInfo.Rows[i].Cells[72].Value.ToString() + "," + "\r\n";

                        }

                        File.WriteAllText(saveName, str, System.Text.Encoding.GetEncoding("GB2312"));
                  
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
