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
using System.Collections;

namespace SunManage.AllCheck
{
    public partial class HistoricalData : Form
    {
        private static int mflag = 0;//增加记录的标志位查看数据库是否存在这条记录
      
        private string mTest_Num;


        public string MTest_Num
        {
            get { return mTest_Num; }
            set { mTest_Num = value; }
        }
        private OleDbConnection mConnection;
        string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\TestHistoryData.mdb";
        private DataSet ds = new DataSet();//数据库操作

        Main mTreeName = new Main();
        public HistoricalData()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 增加记录
        /// </summary>
        public void Insert()
        {
            string mTreeView = Main.MTreeName.ToString();
            if (string.IsNullOrEmpty(textBoxRecordTheSerialNumber.Text.ToString()))
            {
                MessageBox.Show("NO. cannot be empty. There must be numbers！");
            }

            //string mTreeView = Main.MTreeName.ToString();

            if (!string.IsNullOrEmpty(textBoxRecordTheSerialNumber.Text.ToString()))
            {
                try
                {




                    string mSelectQuery = "Select * From {0} where [TestHisData]='" + textBoxRecordTheSerialNumber.Text.ToString() + "'";

                    mSelectQuery = string.Format(mSelectQuery, mTreeView);
                    mConnection = new OleDbConnection(sAccessConnection);
                    mConnection.Open();
                    OleDbCommand cmd = new OleDbCommand(mSelectQuery, mConnection);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("This record exists. Please re-enter the different NO.！");
                    }
                    else
                    {

                        mflag = 1;


                    }
                    reader.Close();
                    mConnection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception:" + ex.ToString(), "Tips");
                }
            }
            if (mflag == 1)
            {


                string DTime = " " + Convert.ToInt32(comboBoxTest_DtYear.Text).ToString("D4") + "-" + Convert.ToInt32(comboBoxTest_DtMonth.Text).ToString("D2") + "-" + Convert.ToInt32(comboBoxTest_DtDay.Text).ToString("D2") + " " + Convert.ToInt32(comboBoxTest_DtHour.Text).ToString("D2") + ":" + Convert.ToInt32(comboBoxTest_DtMinute.Text).ToString("D2") + "";

                //string mQuery = "insert into {0} ([Test_Num]= '" + mTest_Num + "',[HA_STime]='" + DTime + "' ,[Test_Psernum]='" + Psernum + "',[Htest_type]='" + Htest_type + "',[Test_Result]='" + HtestResult + "',[Test_filt]='" + Test_filt + "',[Test_LIQU]='" + Test_LIQU + "',[Test_Meme_Aper]='" + Test_Meme_Aper + "',[Test_Filter_type]='" + Test_Filter_type + "',[Test_Filter_number]='" + Test_Filter_numer + "',[Test_Filter_Config]='" + Test_Filter_Config + "',[Test_startp]='" + Test_startp + "',[Test_Up_Volm]='" + Test_Up_Volm + "',[Test_Filter_Area]='" + Test_Filter_Area + "' ,[Test_LIQUConsistence]='" + Test_LIQUConsistence + "',[Test_setBp]='" + Test_setBp + "',[Test_Dif_max]='" + Test_Dif_max + "',[Htest_Value]='" + Htest_TestValue + "',[Htest_DifValue]='" + Htest_DifValue + "',[Htest_DiffePress]='" + Htest_DiffePress + "')" ;
                string mQuery = String.Format("insert into {0}([TestHisData],[Htest_type],[Test_Psernum],[Test_Tsernum],[Test_Fsernum],[Test_filt],[Test_LIQU],[HA_STime],[Test_LIQUType],[Test_LIQUConsistence],[Test_Filter_type],[Test_Filter_Config],[Test_Filter_number],[Test_Filter_Area],[Test_Meme_Aper],[Test_Velocity],[Test_Up_Volm],[Test_startp],[Test_setBp],[Test_Dif_max],[Htest_Name],[Htest_DifValue],[Htest_Value],[Htest_BP_Result],[Htest_DIF_Result],[Test_Result],[Htest_DiffePress],[Test_testimes],[p0],[p1],[p2],[p3],[p4],[p5],[p6],[p7],[p8],[p9],[p10],[p11],[p12],[p13],[p14],[p15],[p16],[p17],[p18],[p19],[p20],[p21],[p22],[p23],[p24],[p25],[p26],[p27],[p28],[p29],[p30],[p31],[p32],[p33],[p34],[p35],[p36],[p37],[p38],[p39],[p40],[p41],[p42],[p43],[p44],[p45],[p46],[p47],[p48],[p49]) values ('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}','{52}','{53}','{54}','{55}','{56}','{57}','{58}','{59}','{60}','{61}','{62}','{63}','{64}','{65}','{66}','{67}','{68}','{69}','{70}','{71}','{72}','{73}','{74}','{75}','{76}','{77}','{78}')", mTreeView, textBoxRecordTheSerialNumber.Text.ToString(), textBoxHtest_type.Text.ToString(), textBoxTest_Psernum.Text.ToString(), textBoxTest_Tsernum.Text.ToString(), textBoxTest_Fsernum.Text.ToString(), textBoxTest_filt.Text.ToString(), "液体", DTime, textBoxTest_LIQUType.Text.ToString(), "浓度", textBoxTest_Filter_type.Text.ToString(), textBoxTest_Filter_Config.Text.ToString(), textBoxTest_Filter_numer.Text.ToString(), textBoxTest_Filter_Area.Text.ToString(), textBoxTest_Meme_Aper.Text.ToString(),"66", textBoxTest_Up_Volm.Text.ToString(), textBoxTest_startp.Text.ToString(), textBoxTest_setBp.Text.ToString(), textBoxTest_Dif_max.Text.ToString(), textBoxHtest_Name.Text.ToString(), textBoxHtest_DifValue.Text.ToString(), textBoxHtest_TestValue.Text.ToString(), textBoxHtest_BP_Result.Text.ToString(), textBoxHtest_DIF_Result.Text.ToString(), textBoxHtest_ALL_Result.Text.ToString(), textBoxHtest_DiffePress.Text.ToString(), textBoxTest_testimes.Text.ToString(), textBox0.Text.ToString(), textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString(), textBox4.Text.ToString(), textBox5.Text.ToString(), textBox6.Text.ToString(), textBox7.Text.ToString(), textBox8.Text.ToString(), textBox9.Text.ToString(), textBox10.Text.ToString(), textBox11.Text.ToString(), textBox12.Text.ToString(), textBox13.Text.ToString(), textBox14.Text.ToString(), textBox15.Text.ToString(), textBox16.Text.ToString(), textBox17.Text.ToString(), textBox18.Text.ToString(), textBox19.Text.ToString(), textBox20.Text.ToString(), textBox21.Text.ToString(), textBox22.Text.ToString(), textBox23.Text.ToString(), textBox24.Text.ToString(), textBox25.Text.ToString(), textBox26.Text.ToString(), textBox27.Text.ToString(), textBox28.Text.ToString(), textBox29.Text.ToString(), textBox30.Text.ToString(), textBox31.Text.ToString(), textBox32.Text.ToString(), textBox33.Text.ToString(), textBox34.Text.ToString(), textBox35.Text.ToString(), textBox36.Text.ToString(), textBox37.Text.ToString(), textBox38.Text.ToString(), textBox39.Text.ToString(), textBox40.Text.ToString(), textBox41.Text.ToString(), textBox42.Text.ToString(), textBox43.Text.ToString(), textBox44.Text.ToString(), textBox45.Text.ToString(), textBox46.Text.ToString(), textBox47.Text.ToString(), textBox48.Text.ToString(), textBox49.Text.ToString());

                //mQuery = string.Format(mQuery, mTreeView);
                mConnection = new OleDbConnection(sAccessConnection);

                OleDbCommand da = new OleDbCommand(mQuery, mConnection);

                //

                try
                {
                    mConnection.Open();
                    da.ExecuteNonQuery();

                    MessageBox.Show("Add Success！", "Tips");

                    //this.Close();

                }

                catch (Exception ex)
                {

                    MessageBox.Show("Exception:" + ex.ToString(), "Tips");

                }

                finally
                {
                    mflag = 0;
                    mConnection.Close();

                }



            }
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="mHistorical"></param>
        public void Edit(string mHistorical)
        {



            string mTreeView = Main.MTreeName.ToString();

            if (string.IsNullOrEmpty(textBoxRecordTheSerialNumber.Text.ToString()))
            {
                MessageBox.Show("The modified NO. cannot be empty and must be numeric！");
            }

            //string mTreeView = Main.MTreeName.ToString();




            string DTime = " " + Convert.ToInt32(comboBoxTest_DtYear.Text).ToString("D4") + "-" + Convert.ToInt32(comboBoxTest_DtMonth.Text).ToString("D2") + "-" + Convert.ToInt32(comboBoxTest_DtDay.Text).ToString("D2") + " " + Convert.ToInt32(comboBoxTest_DtHour.Text).ToString("D2") + ":" + Convert.ToInt32(comboBoxTest_DtMinute.Text).ToString("D2") + "";

            string mQuery = "update {0} set [p49]='" + "{1}" + "',[p48]='" + "{2}" + "',[p47]='" + "{3}" + "',[p46]='" + "{4}" + "',[p45]='" + "{5}" + "',[p44]='" + "{6}" + "',[p43]='" + "{7}" + "',[p42]='" + "{8}" + "',[p41]='" + "{9}" + "',[p40]='" + "{10}" + "',[p39]='" + "{11}" + "',[p38]='" + "{12}" + "',[p37]='" + "{13}" + "',[p36]='" + "{14}" + "',[p35]='" + "{15}" + "',[p34]='" + "{16}" + "',[p33]='" + "{17}" + "',[p32]='" + "{18}" + "',[p31]='" + "{19}" + "',[p30]='" + "{20}" + "',[p29]='" + "{21}" + "',[p28]='" + "{22}" + "',[p27]='" + "{23}" + "',[p26]='" + "{24}" + "',[p25]='" + "{25}" + "',[p24]='" + "{26}" + "',[p23]='" + "{27}" + "',[p22]='" + "{28}" + "',[p21]='" + "{29}" + "',[p20]='" + "{30}" + "',[p19]='" + "{31}" + "',[p18]='" + "{32}" + "',[p17]='" + "{33}" + "',[p16]='" + "{34}" + "',[p15]='" + "{35}" + "',[p14]='" + "{36}" + "',[p13]='" + "{37}" + "',[p12]='" + "{38}" + "',[p11]='" + "{39}" + "',[p10]='" + "{40}" + "',[p9]='" + "{41}" + "',[p8]='" + "{42}" + "',[p7]='" + "{43}" + "',[p6]='" + "{44}" + "',[p5]='" + "{45}" + "',[p4]='" + "{46}" + "',[p3]='" + "{47}" + "',[p2]='" + "{48}" + "',[p1]='" + "{49}" + "',[p0]='" + "{50}" + "',[TestHisData]='" + textBoxRecordTheSerialNumber.Text.ToString() + "',[Htest_type]='" + textBoxHtest_type.Text.ToString() + "',[Test_Psernum]='" + textBoxTest_Psernum.Text.ToString() + "',[Test_Tsernum]='" + textBoxTest_Tsernum.Text.ToString() + "',[Test_Fsernum]='" + textBoxTest_Fsernum.Text.ToString() + "',[Test_filt]='" + textBoxTest_filt.Text.ToString() + "',[Test_LIQU]='" + "液体" + "' ,[HA_STime]='" + DTime + "',[Test_LIQUType]='" + textBoxTest_LIQUType.Text.ToString() + "',[Test_LIQUConsistence]='" + "56" + "',[Test_Filter_type]='" + textBoxTest_Filter_type.Text.ToString() + "',[Test_Filter_Config]='" + textBoxTest_Filter_Config.Text.ToString() + "',[Test_Filter_number]='" + textBoxTest_Filter_numer.Text.ToString() + "',[Test_Filter_Area]='" + textBoxTest_Filter_Area.Text.ToString() + "',[Test_Meme_Aper]='" + textBoxTest_Meme_Aper.Text.ToString() + "',[Test_Velocity]='" + "55" + "',[Test_Up_Volm]='" + textBoxTest_Up_Volm.Text.ToString() + "',[Test_startp]='" + textBoxTest_startp.Text.ToString() + "',[Test_setBp]='" + textBoxTest_setBp.Text.ToString() + "' ,[Test_Dif_max]='" + textBoxTest_Dif_max.Text.ToString() + "',[Htest_Name]='" + textBoxHtest_Name.Text.ToString() + "',[Htest_DifValue]='" + textBoxHtest_DifValue.Text.ToString() + "',[Htest_Value]='" + textBoxHtest_TestValue.Text.ToString() + "',[Htest_BP_Result]='" + textBoxHtest_BP_Result.Text.ToString() + "',[Htest_DIF_Result]='" + textBoxHtest_DIF_Result.Text.ToString() + "',[Test_Result]='" + textBoxHtest_ALL_Result.Text.ToString() + "',[Htest_DiffePress]='" + textBoxHtest_DiffePress.Text.ToString() + "',[Test_testimes]='" + textBoxTest_testimes.Text.ToString() + "' where [TestHisData]='" + mHistorical + "'";

            mQuery = string.Format(mQuery, mTreeView, textBox49.Text.ToString(), textBox48.Text.ToString(), textBox47.Text.ToString(), textBox46.Text.ToString(), textBox45.Text.ToString(), textBox44.Text.ToString(), textBox43.Text.ToString(), textBox42.Text.ToString(), textBox41.Text.ToString(), textBox40.Text.ToString(), textBox39.Text.ToString(), textBox38.Text.ToString(), textBox37.Text.ToString(), textBox36.Text.ToString(), textBox35.Text.ToString(), textBox34.Text.ToString(), textBox33.Text.ToString(), textBox32.Text.ToString(), textBox31.Text.ToString(), textBox30.Text.ToString(), textBox29.Text.ToString(), textBox28.Text.ToString(), textBox27.Text.ToString(), textBox26.Text.ToString(), textBox25.Text.ToString(), textBox24.Text.ToString(), textBox23.Text.ToString(), textBox22.Text.ToString(), textBox21.Text.ToString(), textBox20.Text.ToString(), textBox19.Text.ToString(), textBox18.Text.ToString(), textBox17.Text.ToString(), textBox16.Text.ToString(), textBox15.Text.ToString(), textBox14.Text.ToString(), textBox13.Text.ToString(), textBox12.Text.ToString(), textBox11.Text.ToString(), textBox10.Text.ToString(), textBox9.Text.ToString(), textBox8.Text.ToString(), textBox7.Text.ToString(), textBox6.Text.ToString(), textBox5.Text.ToString(), textBox4.Text.ToString(), textBox3.Text.ToString(), textBox2.Text.ToString(), textBox1.Text.ToString(), textBox0.Text.ToString());

            mConnection = new OleDbConnection(sAccessConnection);

            OleDbCommand da = new OleDbCommand(mQuery, mConnection);

            //

            try
            {
                mConnection.Open();
                da.ExecuteNonQuery();

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

     public  void buttonConfirm_Click(object sender, EventArgs e)
     {

         mTest_Num = this.textBoxHtest_type.Text.ToString();
         this.Close();
     }

     private void HistoricalData_Load(object sender, EventArgs e)
     {

         try
         {
             comboBoxTest_DtYear.Text = DateTime.Now.Year.ToString();
             comboBoxTest_DtMonth.Text = DateTime.Now.Month.ToString();
             comboBoxTest_DtDay.Text = DateTime.Now.Day.ToString();
             comboBoxTest_DtHour.Text = DateTime.Now.Hour.ToString();
             comboBoxTest_DtMinute.Text = DateTime.Now.Minute.ToString();
             string mTreeView = Main.MTreeName.ToString();
             string mHistorical = HistoricalRecords.mEditHistoricalIndex;
             if (!string.IsNullOrEmpty(mHistorical))
             {
                 string mSelectQuery = "Select * From {0} where [TestHisData]='" + mHistorical + "'";

                 mSelectQuery = string.Format(mSelectQuery, mTreeView);
                 mConnection = new OleDbConnection(sAccessConnection);
                 mConnection.Open();
                 OleDbCommand cmd = new OleDbCommand(mSelectQuery, mConnection);
                 OleDbDataReader reader = cmd.ExecuteReader();
                 if (reader.Read())
                 {
                     textBoxRecordTheSerialNumber.Text = reader[0].ToString();
                     textBoxHtest_type.Text = reader[1].ToString();
                     textBoxTest_Psernum.Text = reader[2].ToString();
                     textBoxTest_Tsernum.Text = reader[3].ToString();
                     textBoxTest_Fsernum.Text = reader[4].ToString();
                     textBoxTest_filt.Text = reader[5].ToString();

                     textBoxTest_LIQUType.Text = reader[8].ToString();

                     textBoxTest_Filter_type.Text = reader[10].ToString();
                     textBoxTest_Filter_Config.Text = reader[11].ToString();
                     textBoxTest_Filter_numer.Text = reader[12].ToString();
                     textBoxTest_Filter_Area.Text = reader[13].ToString();

                     textBoxTest_Meme_Aper.Text = reader[14].ToString();
                     textBoxTest_Up_Volm.Text = reader[16].ToString();
                   
                     textBoxTest_startp.Text = reader[17].ToString();
                     textBoxTest_setBp.Text = reader[18].ToString();

                     textBoxTest_Dif_max.Text = reader[19].ToString();
                     textBoxHtest_Name.Text = reader[20].ToString();
                    
                     textBoxHtest_BP_Result.Text = reader[23].ToString();
                     textBoxHtest_DIF_Result.Text = reader[24].ToString();
                     textBoxHtest_ALL_Result.Text = reader[25].ToString();

                     if (!string.IsNullOrWhiteSpace(reader[21].ToString()))
                     {
                         textBoxHtest_DifValue.Text = reader[21].ToString();
                     }

                     if (!string.IsNullOrWhiteSpace(reader[22].ToString()))
                     {
                         textBoxHtest_TestValue.Text = reader[22].ToString();
                     }

                     if (!string.IsNullOrWhiteSpace(reader[26].ToString()))
                     {
                         textBoxHtest_DiffePress.Text = reader[26].ToString();
                     }


                     if (reader[1].ToString() == "Pressure Holding")
                     {
                         textBoxTest_startp.Text = reader[18].ToString();
                         textBoxTest_setBp.Text = "";
                         textBoxHtest_DiffePress.Text = reader[26].ToString();
                         textBoxHtest_DifValue.Text = "";
                     }

                     if (reader[1].ToString() == "Diffusion Flow")
                     {
                         textBoxHtest_DiffePress.Text ="";
                         textBoxHtest_DifValue.Text = reader[21].ToString();
                     }


                     textBoxTest_testimes.Text = reader[27].ToString();
                     textBox0.Text = reader[28].ToString();
                     textBox1.Text = reader[29].ToString();
                     textBox2.Text = reader[30].ToString();
                     textBox3.Text = reader[31].ToString();
                     textBox4.Text = reader[32].ToString();
                     textBox5.Text = reader[33].ToString();
                     textBox6.Text = reader[34].ToString();
                     textBox7.Text = reader[35].ToString();
                     textBox8.Text = reader[36].ToString();
                     textBox9.Text = reader[37].ToString();
                     textBox10.Text = reader[38].ToString();
                     textBox11.Text = reader[39].ToString();
                     textBox12.Text = reader[40].ToString();
                     textBox13.Text = reader[41].ToString();
                     textBox14.Text = reader[42].ToString();
                     textBox15.Text = reader[43].ToString();
                     textBox16.Text = reader[44].ToString();
                     textBox17.Text = reader[45].ToString();
                     textBox18.Text = reader[46].ToString();
                     textBox19.Text = reader[47].ToString();
                     textBox20.Text = reader[48].ToString();
                     textBox21.Text = reader[49].ToString();
                     textBox22.Text = reader[50].ToString();
                     textBox23.Text = reader[51].ToString();
                     textBox24.Text = reader[52].ToString();
                     textBox25.Text = reader[53].ToString();
                     textBox26.Text = reader[54].ToString();
                     textBox27.Text = reader[55].ToString();
                     textBox28.Text = reader[56].ToString();
                     textBox29.Text = reader[57].ToString();
                     textBox30.Text = reader[58].ToString();
                     textBox31.Text = reader[59].ToString();
                     textBox32.Text = reader[60].ToString();
                     textBox33.Text = reader[61].ToString();
                     textBox34.Text = reader[62].ToString();
                     textBox35.Text = reader[63].ToString();
                     textBox36.Text = reader[64].ToString();
                     textBox37.Text = reader[65].ToString();
                     textBox38.Text = reader[66].ToString();
                     textBox39.Text = reader[67].ToString();
                     textBox40.Text = reader[68].ToString();
                     textBox41.Text = reader[69].ToString();
                     textBox42.Text = reader[70].ToString();
                     textBox43.Text = reader[71].ToString();
                     textBox44.Text = reader[72].ToString();
                     textBox45.Text = reader[73].ToString();
                     textBox46.Text = reader[74].ToString();
                     textBox47.Text = reader[75].ToString();
                     textBox48.Text = reader[76].ToString();
                     textBox49.Text = reader[77].ToString();
                    

                 }
                 reader.Close();
                 mConnection.Close();

             }
         }
         catch(Exception ex)
         {
             MessageBox.Show("Exception:" + ex.ToString(), "Tips");
         }
     }

    
    }
}
