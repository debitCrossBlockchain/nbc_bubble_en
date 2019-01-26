using System;
using System.Data;
using System.Windows.Forms;
//引用创建Access数据库的库
using System.Data.OleDb;
using SunManage.communication;
using System.Text;
namespace SunManage.AllCheck
{
    public partial class HistoricalRecords : Form
    {
        //private static int mflag = 0;//增加记录的标志位查看数据库是否存在这条记录
        public static string mEditHistoricalIndex;
        private OleDbConnection mConnection;
        string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\TestHistoryData.mdb";
        private DataSet ds = new DataSet();//数据库操作
        Main mTreeName = new Main();
        /// <summary>
        /// 创建数据集
        /// </summary>
        public static string mPrintNo = "";
        public static HistoricalRecords mHistoricalRecords = null;


        public HistoricalRecords()
        {
            InitializeComponent();
        }

        private void buttonSearchALLHis_Click(object sender, EventArgs e)
        {
            //string mTreeView = "表1";
            string mTreeView = Main.MTreeName.ToString();
            string mQuery = "Select TestHisData as num,Test_Psernum as Product_batch,Test_Fsernum as product_name,HA_STime as test_time,Htest_type as test_type From {0}";
            mQuery = string.Format(mQuery, mTreeView);
            mConnection = new OleDbConnection(sAccessConnection);

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(mQuery, mConnection);
            DataGridView dz = new DataGridView();
            dz.DataSource = ds.Tables[0].DefaultView;
            //如果需要再次查询，需清空dataset里面的数据  
            try
            {
                if (mConnection.State != ConnectionState.Open) { mConnection.Open(); }
                ds.Tables[0].Clear();
                dataAdapter.Fill(ds);
                dataGridViewHistorical.DataSource = ds.Tables[0].DefaultView;
                dataGridViewHistorical.AllowUserToAddRows = false;

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
        /// <summary>
        /// 增加记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHistoricalAdd_Click(object sender, EventArgs e)
        {
            try
            {
                HistoricalData mHistoricalData = new HistoricalData();
                mHistoricalData.ShowDialog();
                mHistoricalData.Insert();
            }

            catch (Exception ex)
            {

                MessageBox.Show("Exception:" + ex.ToString(), "Tips");

            }
        }
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHistoricalEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewHistorical.SelectedRows.Count > 0)
                {
                    mEditHistoricalIndex = dataGridViewHistorical.Rows[dataGridViewHistorical.CurrentRow.Index].Cells[0].Value.ToString();
                    HistoricalData mHistoricalData = new HistoricalData();
                    mHistoricalData.ShowDialog();
                    mHistoricalData.Edit(mEditHistoricalIndex);
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show("Exception:" + ex.ToString(), "Tips");

            }
        }

        private void buttonHistoricalDelete_Click(object sender, EventArgs e)
        {

            if (dataGridViewHistorical.SelectedRows.Count > 0)
            {
                string mTreeView = Main.MTreeName.ToString();

                string mDeleteHistoricalIndex = dataGridViewHistorical.Rows[dataGridViewHistorical.CurrentRow.Index].Cells[0].Value.ToString();

                string mQuery = "delete * From {0} where TestHisData='" + mDeleteHistoricalIndex + "'";
                mQuery = string.Format(mQuery, mTreeView);
                mConnection = new OleDbConnection(sAccessConnection);
                OleDbCommand da = new OleDbCommand(mQuery, mConnection);

                try
                {
                    if (mConnection.State != ConnectionState.Open) { mConnection.Open(); }
                    if ((MessageBox.Show("Do you Confirm delete the current record? ", " warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                    {
                        //删除数据
                        //首先删除数据集 中的该条记录
                        int i = dataGridViewHistorical.CurrentCell.RowIndex;//得到当前记录号
                        if (i >= 0)
                        {
                            ds.Tables[0].Rows[i].Delete();

                        }
                    }
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
        }

        private void buttonHistoricalClear_Click(object sender, EventArgs e)
        {
            if (dataGridViewHistorical.SelectedRows.Count > 0)
            {
                string mTreeView = Main.MTreeName.ToString();

                string mQuery = "delete * From {0}";
                mQuery = string.Format(mQuery, mTreeView);
                mConnection = new OleDbConnection(sAccessConnection);

                OleDbCommand da = new OleDbCommand(mQuery, mConnection);

                try
                {
                    if (mConnection.State != ConnectionState.Open) { mConnection.Open(); }
                    if ((MessageBox.Show("Do you Confirm empty all records? ", " warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                    {
                        ds.Tables[0].Clear();
                        da.ExecuteNonQuery();
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
        }

        /// <summary>
        /// 按Time查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btHTime_Click(object sender, EventArgs e)
        {

            string mTreeView = Main.MTreeName.ToString();
            string DTime = DateTime.Parse(dateTimePickerDTime.Text).Year.ToString("D4") + "-" + DateTime.Parse(dateTimePickerDTime.Text).Month.ToString("D2") + "-" + DateTime.Parse(dateTimePickerDTime.Text).Day.ToString("D2");
            string mQuery = "Select TestHisData as num,Test_Psernum as Product_batch,Test_Fsernum as product_name,HA_STime as test_time,Htest_type as test_type From {0}" +"  where [HA_STime] like'" + " " + DTime + " %%:%%" + "'";
            //+DTime+" "+"%%:%%"+ 


            mQuery = string.Format(mQuery, mTreeView);
            mConnection = new OleDbConnection(sAccessConnection);

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(mQuery, mConnection);

            try
            {
                if (mConnection.State != ConnectionState.Open) { mConnection.Open(); }
                //如果需要再次查询，需清空dataset里面的数据  
                ds.Tables[0].Clear();


                dataAdapter.Fill(ds);
                dataGridViewHistorical.DataSource = ds.Tables[0].DefaultView;
                dataGridViewHistorical.AllowUserToAddRows = false;

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

        /// <summary>
        /// Load窗体时候发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistoricalRecords_Load(object sender, EventArgs e)
        {
            if (Login.ms_strName != "Admin")
            {
                buttonRead.Enabled = false;
                buttonRead.Visible = false;
                buttonWrite.Enabled = false;
                buttonWrite.Visible = false;
                buttonHistoricalDelete.Enabled = false;
                buttonHistoricalDelete.Visible = false;
                buttonHistoricalAdd.Enabled = false;
                buttonHistoricalAdd.Visible = false;
                buttonHistoricalEdit.Enabled = false;
                buttonHistoricalEdit.Visible = false;
            }
            dateTimePickerDTime.Format = DateTimePickerFormat.Long;
            dateTimePickerDTime.CustomFormat = "yyyy-mm-dd hh:mm";

            string mTreeView = Main.MTreeName.ToString();
            string mQuery = "Select TestHisData as num,Test_Psernum as Product_batch,Test_Fsernum as product_name,HA_STime as test_time,Htest_type as test_type From {0}";
            mQuery = string.Format(mQuery, mTreeView);
            mConnection = new OleDbConnection(sAccessConnection);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(mQuery, mConnection);
            try
            {
                if (mConnection.State != ConnectionState.Open) { mConnection.Open(); }
                dataAdapter.Fill(ds);
                dataGridViewHistorical.DataSource = ds.Tables[0].DefaultView;
                dataGridViewHistorical.AllowUserToAddRows = false;

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
        /// <summary>
        /// 给dataGridView加行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewHistorical_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dataGridViewHistorical.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dataGridViewHistorical.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dataGridViewHistorical.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

        }

        /// <summary>
        /// 获取数据集方法
        /// Load基本set参数
        /// </summary>
        public DataTable GetDataSet()
        {
            DataTable mDataTable = new DataTable("ds3");
            mDataTable.Columns.Add("Htest_type", typeof(string));
            mDataTable.Columns.Add("Test_Psernum", typeof(string));
            mDataTable.Columns.Add("HA_STime", typeof(string));
            mDataTable.Columns.Add("Test_Name", typeof(string));
            mDataTable.Columns.Add("Test_Fsernum", typeof(string));
            mDataTable.Columns.Add("Test_filt", typeof(string));
            mDataTable.Columns.Add("Test_LIQU", typeof(string));
            mDataTable.Columns.Add("Test_Filt_Hight", typeof(string));
            mDataTable.Columns.Add("Test_Filt_Num", typeof(string));
            mDataTable.Columns.Add("Test_Result", typeof(string));
            mDataTable.Columns.Add("Test_startp", typeof(string));
            mDataTable.Columns.Add("Test_SetBp", typeof(string));
            mDataTable.Columns.Add("Test_Up_Volm", typeof(string));
            mDataTable.Columns.Add("Test_Dif_max", typeof(string));
            mDataTable.Columns.Add("Htest_DifValue", typeof(string));
            mDataTable.Columns.Add("Htest_Value", typeof(string));
            mDataTable.Columns.Add("Test_Filter_Area", typeof(string));
            mDataTable.Columns.Add("Test_Meme_Aper", typeof(string));
            mDataTable.Columns.Add("Test_Filter_type", typeof(string));
            mDataTable.Columns.Add("Htest_DiffePress", typeof(string));
            mDataTable.Columns.Add("Test_CDifValue", typeof(string));
            mDataTable.Columns.Add("Test_testimes", typeof(string));
            mDataTable.Columns.Add("Test_Sampling_Frequency", typeof(string));
            mDataTable.Columns.Add("Htest_DifStart", typeof(string));
            mDataTable.Columns.Add("Htest_Name", typeof(string));
            mDataTable.Columns.Add("DeviceName", typeof(string));


            string mTreeView = Main.MTreeName.ToString();

            string mQuery = "Select * From {0} where TestHisData='" + mEditHistoricalIndex + "'";
            mQuery = string.Format(mQuery, mTreeView);
            mConnection = new OleDbConnection(sAccessConnection);

            try
            {
                if (mConnection.State != ConnectionState.Open) { mConnection.Open(); }
                OleDbCommand cmd = new OleDbCommand(mQuery, mConnection);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    DataRow dr = mDataTable.NewRow();
                    dr["Htest_type"] = reader[1].ToString();
                    dr["Test_Psernum"] = reader[2].ToString();
                    dr["HA_STime"] = reader[3].ToString();
                    dr["Test_Name"] = reader[4].ToString();
                    dr["Test_Fsernum"] = reader[5].ToString();
                    dr["Test_filt"] = reader[6].ToString();
                    dr["Test_LIQU"] = reader[7].ToString();
                    dr["Test_Filt_Hight"] = reader[8].ToString();
                    dr["Test_Filt_Num"] = reader[9].ToString();
                    dr["Test_Result"] = reader[10].ToString();
                    dr["Test_startp"] = reader[11].ToString();
                    dr["Test_SetBp"] = reader[12].ToString();
                    dr["Test_Up_Volm"] = reader[13].ToString();
                    string dif_max = reader[14].ToString();
                    if (dif_max == "")
                    {
                        dif_max = "0";
                    }
                    string h_dif_max = reader[15].ToString();
                    if (h_dif_max == "")
                    {
                        h_dif_max = "0";
                    }
                    if (reader[1].ToString() == "Water Immersion")
                    {
                        dr["Test_Dif_max"] = (float.Parse(dif_max) / 100).ToString();
                        dr["Htest_DifValue"] = (float.Parse(h_dif_max) / 100).ToString();
                        //dr["Test_CDifValue"] = (float.Parse(reader[21].ToString()) / 100).ToString();
                    }
                    else
                    {
                        dr["Test_Dif_max"] = (float.Parse(dif_max) / 10).ToString();
                        dr["Htest_DifValue"] = (float.Parse(h_dif_max) / 10).ToString();

                    }

                    dr["Test_CDifValue"] = reader[21].ToString();
                    dr["Htest_Value"] = reader[16].ToString();
                    dr["Test_Filter_Area"] = "0." + reader[17].ToString();
                    dr["Test_Meme_Aper"] = "0." + reader[18].ToString();
                    dr["Test_Filter_type"] = reader[19].ToString();
                    dr["Htest_DiffePress"] = reader[20].ToString();
                    dr["Test_testimes"] = reader[22].ToString();
                    dr["Test_Sampling_Frequency"] = reader[23].ToString();
                    dr["Htest_DifStart"] = reader[24].ToString();
                    dr["Htest_Name"] = reader[25].ToString();
                    dr["DeviceName"] = mTreeView;
                    mDataTable.Rows.Add(dr);

                }
                reader.Close();
            }
            catch (Exception ex)
            {

                //LogClass.WriteLogFile("Exception:" + ex.ToString());

            }
            finally
            {

                mConnection.Close();

            }
            return mDataTable;
        }
        /// <summary>
        /// 画Chart
        /// </summary>
        /// <returns></returns>
        public DataTable dsGet()
        {
            int i = 0;
            mEditHistoricalIndex = dataGridViewHistorical.Rows[dataGridViewHistorical.CurrentRow.Index].Cells[0].Value.ToString();
            DataTable mDataTable = new DataTable("ds2");

            mDataTable.Columns.Add("DataPressure", typeof(Int32));
            mDataTable.Columns.Add("DataTime", typeof(Int32));
            string mTreeView = Main.MTreeName.ToString();
            string mQuery = "Select Test_SetBp,Htest_Press_Line,Htest_Dif_Line  From {0} where TestHisData=" + mEditHistoricalIndex;
            mQuery = string.Format(mQuery, mTreeView);
            mConnection = new OleDbConnection(sAccessConnection);

            if (mEditHistoricalIndex != null)
            {
                if (mConnection.State != ConnectionState.Open) { mConnection.Open(); }
                OleDbCommand cmd = new OleDbCommand(mQuery, mConnection);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    for (; i <= 60; i++)
                    {

                        if (reader[i].ToString() == "\0" || reader[i].ToString() == "")
                        {
                        
                        }
                        else
                        {
                            DataRow dr = mDataTable.NewRow();
                            dr["DataPressure"] = Convert.ToInt32(reader[i].ToString());
                            dr["DataTime"] = i;
                            mDataTable.Rows.Add(dr);
                        }
                    }
                    reader.Close();
                    mConnection.Close();
                }
            }
            else
            {
                for (; i <= 60; i++)
                {
                    DataRow dr = mDataTable.NewRow();
                    dr["DataPressure"] = 0;
                    dr["DataTime"] = i;
                    mDataTable.Rows.Add(dr);
                }
            }



            return mDataTable;
        }
        /// <summary>
        /// 修改历史数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewHistorical_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Login.ms_strName != "Admin")
                {
                    return;
                }
                if (dataGridViewHistorical.SelectedRows.Count > 0)
                {
                    mEditHistoricalIndex = dataGridViewHistorical.Rows[dataGridViewHistorical.CurrentRow.Index].Cells[0].Value.ToString();

                    HistoricalData mHistoricalData = new HistoricalData();
                    mHistoricalData.ShowDialog();

                    //if (mHistoricalData.MTest_Num!=null)
                    mHistoricalData.Edit(mEditHistoricalIndex);

                }

            }

            catch (Exception ex)
            {

                MessageBox.Show("Exception:" + ex.ToString(), "Tips");

            }

        }
        /// <summary>
        /// 打印Historical Records
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHistoricalPrint_Click(object sender, EventArgs e)
        {
            if (dataGridViewHistorical.SelectedRows.Count > 0)
            {
                mEditHistoricalIndex = dataGridViewHistorical.Rows[dataGridViewHistorical.CurrentRow.Index].Cells[0].Value.ToString();
                mPrintNo = dataGridViewHistorical.Rows[dataGridViewHistorical.CurrentRow.Index].Cells[0].Value.ToString();
                try
                {


                    RecordPrinter mRecordPrinter = new RecordPrinter();
                    //mRecordPrinter.dsGet(mEditHistoricalIndex);
                    mRecordPrinter.ShowDialog();

                }
                catch (Exception)
                {
                    MessageBox.Show("You haven't got the data yet!");
                }

            }

        }
        /// <summary>
        /// 读取设备的Historical Records并保存到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRead_Click(object sender, EventArgs e)
        {
            CommPort mComPort = CommPort.Instance;
            mComPort.SearchDeviceAddress();
            usbReferenceDevice theReferenceUsbDevice = new usbReferenceDevice(USB.vid, USB.pid);
            try
            {
                //CommPort.mHistoryRecord.Clear();

                string str = "FF" + "{0}" + "05" + "07" + "00";
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
            //foreach (CommPort oR in CommPort.MHistoryRecord)
            //{

            //    //if (oR.DeviceID == CommPort.mDeviceAddress)
            //    //{
            //        string mTreeView = Main.MTreeName.ToString();
            //        if (!string.IsNullOrEmpty(mTreeView))
            //        {

            //            //string mQuery = "insert into {0} ([Test_Num]= '" + mTest_Num + "',[HA_STime]='" + DTime + "' ,[Test_Psernum]='" + Psernum + "',[Htest_type]='" + Htest_type + "',[Test_Result]='" + HtestResult + "',[Test_filt]='" + Test_filt + "',[Test_LIQU]='" + Test_LIQU + "',[Test_Meme_Aper]='" + Test_Meme_Aper + "',[Test_Filter_type]='" + Test_Filter_type + "',[Test_Filter_number]='" + Test_Filter_numer + "',[Test_Filter_Config]='" + Test_Filter_Config + "',[Test_startp]='" + Test_startp + "',[Test_Up_Volm]='" + Test_Up_Volm + "',[Test_Filter_Area]='" + Test_Filter_Area + "' ,[Test_LIQUConsistence]='" + Test_LIQUConsistence + "',[Test_setBp]='" + Test_setBp + "',[Test_Dif_max]='" + Test_Dif_max + "',[Htest_Value]='" + Htest_TestValue + "',[Htest_DifValue]='" + Htest_DifValue + "',[Htest_DiffePress]='" + Htest_DiffePress + "')" ;
            //            string mQuery = String.Format("insert into {0}([Htest_type],[Test_Psernum],[Test_Tsernum],[Test_Fsernum],[Test_filt],[Test_LIQU],[HA_STime],[Test_LIQUType],[Test_LIQUConsistence],[Test_Filter_type],[Test_Filter_Config],[Test_Filter_number],[Test_Filter_Area],[Test_Meme_Aper],[Test_Velocity],[Test_Up_Volm],[Test_startp],[Test_setBp],[Test_Dif_max],[Htest_Name],[Htest_DifValue],[Htest_Value],[Htest_BP_Result],[Htest_DIF_Result],[Test_Result],[Htest_DiffePress],[Test_testimes],[p0],[p1],[p2],[p3],[p4],[p5],[p6],[p7],[p8],[p9],[p10],[p11],[p12],[p13],[p14],[p15],[p16],[p17],[p18],[p19],[p20],[p21],[p22],[p23],[p24],[p25],[p26],[p27],[p28],[p29],[p30],[p31],[p32],[p33],[p34],[p35],[p36],[p37],[p38],[p39],[p40],[p41],[p42],[p43],[p44],[p45],[p46],[p47],[p48],[p49],[p50],[p51],[p52],[p53],[p54],[p55],[p56],[p57],[p58],[p59],[p60]) values ('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}','{52}','{53}','{54}','{55}','{56}','{57}','{58}','{59}','{60}','{61}','{62}','{63}','{64}','{65}','{66}','{67}','{68}','{69}','{70}','{71}','{72}','{73}','{74}','{75}','{76}','{77}','{78}','{79}','{80}','{81}','{82}','{83}','{84}','{85}','{86}','{87}','{88}')", mTreeView, oR.HTest_type1, oR.Test_Psernum1, oR.HTest_Tsernum1, oR.Test_Fsernum1, oR.Test_filt1, oR.Test_LIQU1, oR.Test_Dt1, oR.Test_LIQUType1, oR.Test_LIQUConsistence1, oR.Test_Filter_type1, oR.Test_Filter_Config1, oR.Test_Filter_numer1, oR.Test_Filter_Area1, oR.Test_Meme_Aper1, oR.Test_Velocity1, oR.Test_Up_Volm1, oR.Test_startp1, oR.Test_setBp1, oR.Test_Dif_max1, oR.HHtest_Name1, oR.HHtest_DifValue1, oR.HHtest_TestValue1, oR.HHtest_BP_Result1, oR.HHtest_DIF_Result1, oR.HHtest_ALL_Result1,oR.HHtest_DiffePress1,oR.HHtest_testimes1,oR.P0,oR.P1,oR.P2,oR.P3,oR.P4,oR.P5,oR.P6,oR.P7,oR.P8,oR.P9, oR.P10,oR.P11,oR.P12,oR.P13,oR.P14,oR.P15,oR.P16,oR.P17,oR.P18,oR.P19,oR.P20,oR.P21,oR.P22,oR.P23,oR.P24,oR.P25,oR.P26,oR.P27,oR.P28,oR.P29,oR.P30,oR.P31,oR.P32,oR.P33,oR.P34,oR.P35,oR.P36,oR.P37,oR.P38,oR.P39,oR.P40,oR.P41,oR.P42,oR.P43,oR.P44,oR.P45,oR.P46,oR.P47,oR.P48,oR.P49,oR.P50,oR.P51,oR.P52,oR.P53,oR.P54,oR.P55,oR.P56,oR.P57,oR.P58,oR.P59,oR.P60);

            //            mQuery = string.Format(mQuery, mTreeView);
            //            mConnection = new OleDbConnection(sAccessConnection);

            //            OleDbCommand da = new OleDbCommand(mQuery, mConnection);

            //            //

            //            try
            //            {
            //                mConnection.Open();
            //                da.ExecuteNonQuery();

            //                MessageBox.Show("Add Success！", "Tips");

            //                this.Close();

            //            }

            //            catch (Exception ex)
            //            {

            //                MessageBox.Show("Exception:" + ex.ToString(), "Tips");

            //            }

            //            finally
            //            {

            //                mConnection.Close();

            //            }
            //        //}

            //    }
            //}

        }
        /// <summary>
        /// 写入Historical Records到设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonWrite_Click(object sender, EventArgs e)
        {
            if (dataGridViewHistorical.Rows.Count > 0)
            {
                string Hisdatasum = dataGridViewHistorical.Rows.Count.ToString("X4");
                //for (int n = 1; n <= dataGridViewHistorical.Rows.Count; n++)
                //{
                string Hisdatacurnum = (1).ToString("X4");
                string mTreeView = Main.MTreeName.ToString();

                string mQuery = "Select * From {0} where TestHisData='" + dataGridViewHistorical.Rows[0].Cells[0].Value.ToString() + "'";
                mQuery = string.Format(mQuery, mTreeView);
                mConnection = new OleDbConnection(sAccessConnection);

                try
                {
                    mConnection.Open();
                    OleDbCommand cmd = new OleDbCommand(mQuery, mConnection);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        /// <summary>
                        /// NO.
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>
                        string TestHisData = "";
                        if (!string.IsNullOrEmpty(reader[0].ToString()))
                        {
                            TestHisData = Convert.ToInt64(reader[0].ToString()).ToString("X4");
                        }
                        else
                        {
                            TestHisData = (1).ToString("X4");
                        }

                        string Test_type = "\0";
                        switch (reader[1].ToString())
                        {
                            case "Manual Bubble Point":
                                {
                                    Test_type = (77).ToString("X2");
                                }
                                break;
                            case "Basic Bubble Point":
                                {
                                    Test_type = (66).ToString("X2");
                                }
                                break;
                            case "Extensive Bubble Point":
                                {
                                    Test_type = (65).ToString("X2");
                                }
                                break;
                            case "Pressure Holding":
                                {
                                    Test_type = (80).ToString("X2");
                                }
                                break;
                            case "Diffusion Flow":
                                {
                                    Test_type = (68).ToString("X2");
                                }
                                break;
                            case "Water Immersion ":
                                {
                                    Test_type = (72).ToString("X2");
                                }
                                break;
                            case "Ultrafiltration":
                                {
                                    Test_type = (100).ToString("X2");
                                }
                                break;
                      default:

                                Test_type = (0).ToString("X2");

                                break;


                        }


                        /// <summary>
                        /// product_batch_NO
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>

                        string Test_Psernum = "";
                        string Test_Ps = "";
                        if (!string.IsNullOrEmpty(reader[2].ToString()))
                        {

                            for (int m = 0; m < 16 - (reader[2].ToString()).Length; m++)
                            {
                                Test_Psernum = Test_Psernum + "\0";
                            }
                            Test_Psernum = reader[2].ToString() + Test_Psernum;




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
                        if (!string.IsNullOrEmpty(reader[3].ToString()))
                        {

                            string Test_Tsernum = reader[3].ToString();
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
                        string Test_Fsernum = reader[4].ToString();
                        string Test_F = "";
                        string Test_Fs = "";
                        if (!string.IsNullOrEmpty(reader[4].ToString()))
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
                        string Test_filt = reader[5].ToString();
                        string Test_f = "";
                        string Test_fi = "";
                        if (!string.IsNullOrEmpty(reader[5].ToString()))
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
                        //string Test_LIQU = "";
                        //string Test_LI = "";
                        //string mLiqu = (reader[6].ToString()).Trim();
                        //if (!string.IsNullOrEmpty(mLiqu))
                        //{
                        //    for (int i = 0; i < 15 - (System.Text.Encoding.GetEncoding("GB2312").GetBytes(mLiqu)).Length; i++)
                        //    {
                        //        Test_LIQU = Test_LIQU + "\0";
                        //    }
                        //    Test_LIQU = reader[4].ToString() + Test_LIQU;
                        //    byte[] StryTest_LIQU = System.Text.Encoding.GetEncoding("GB2312").GetBytes(Test_LIQU);

                        //    for (int i = 0; i < 15; i++)
                        //    {
                        //        if (i < Test_LIQU.Length)
                        //        {
                        //            Test_LI = Test_LI + StryTest_LIQU[i].ToString("X2");
                        //        }
                        //        else
                        //        {
                        //            Test_LI = Test_LI + "00";
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    Test_LI = (0).ToString("X30");
                        //}
                        string Test_LIQU = "";
                        string Test_LI = "";

                        string mLiqu = (reader[6].ToString()).Trim();
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
                        /// test_time
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>
                        string DT = reader[7].ToString().Replace(" ", "");

                        DT = DT.Replace("-", "");
                        DT = DT.Replace(":", "");
                        DT = DT.Replace("", "");
                        string mDT = "";
                        if (DT.Length >= 10)
                        {
                            for (int i = 2; i < DT.Length - 1; )
                            {

                                mDT = mDT + (Convert.ToInt32(((DT[i].ToString()) + (DT[i + 1].ToString())))).ToString("X2");
                                i = i + 2;

                            }
                        }
                        else
                        {
                            mDT = (0).ToString("X10");
                        }
                        /// <summary>
                        /// Testing Liquid种类
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>
                        string mTest_LIQUType = "";
                        string mTest_LQT = (reader[8].ToString()).Trim();
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
                        /// 
                        string Test_LIQUConsistence = (0).ToString("X4");
                        if (!string.IsNullOrEmpty(reader[9].ToString().Replace("%", "")))
                        {
                            Test_LIQUConsistence = (Convert.ToInt64(reader[9].ToString().Replace("%", ""))).ToString("X4");
                        }


                        /// <summary>
                        /// 测量用过滤器的种类
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>
                        string Test_Filter_type = "";
                        string mTest_Fil_T = (reader[10].ToString()).Trim();
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
                        /// 过滤材料的规格（或平板滤器的直径）  -- 2;
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>


                        string Test_Filter_Config = reader[11].ToString().Replace('"'.ToString(), "");
                        Test_Filter_Config = Test_Filter_Config.Replace("mm", "");

                        if (!string.IsNullOrEmpty(Test_Filter_Config))
                        {
                            Test_Filter_Config = (Convert.ToInt64(Test_Filter_Config)).ToString("X4");
                        }
                        else
                        {
                            Test_Filter_Config = (0).ToString("X4");
                        }
                        /// <summary>
                        ///Testing过滤器滤芯的数量        -- 1 ;
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>
                        string Test_Filter_numer = (0).ToString("X2");
                        if (!string.IsNullOrEmpty(reader[12].ToString()))
                        {
                            Test_Filter_numer = Convert.ToInt32(reader[12].ToString().Replace("芯", "")).ToString("X2");
                        }
                        /// <summary>
                        ///Test_Filter_Area   -------  Filter Area           -- 4    ;
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>

                        string Test_Filter_Area = (0).ToString("X8");
                        if (!string.IsNullOrEmpty(reader[13].ToString()))
                        {
                            Test_Filter_Area = (Convert.ToInt64(reader[13].ToString().Replace(".", ""))).ToString("X8");
                        }
                        /// <summary>
                        ///Test_Meme_Aper  -------  过滤材料的Aperture（精度）      -- 2  ;
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>
                        string Test_Meme_Aper = (0).ToString("X4");
                        if (!string.IsNullOrEmpty(reader[14].ToString()))
                        {
                            Test_Meme_Aper = (Convert.ToInt64(reader[14].ToString().Replace(".", ""))).ToString("X4");
                        }

                        /// <summary>
                        /// /// <summary>
                        ///Test_Velocity  ------- 基本泡点Test Mode / Water浸入的test_time  -- 2 ;基本泡点分为:0或1  0是Normal 1Fast
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>

                        string Test_Velocity = "\0\0";
                        switch (reader[15].ToString())
                        {
                            case "Normal":
                                {
                                    Test_Velocity = (0).ToString("X4");
                                }
                                break;
                            case "Fast":
                                {
                                    Test_Velocity = (1).ToString("X4");
                                }
                                break;
                            default:

                                Test_Velocity = (69).ToString("X4");

                                break;
                        }

                        /// <summary>
                        ///Test_Up_Volm  ------- 滤芯的Upstream Volume  -- 4 ;
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>
                        string Test_Up_Volm = (0).ToString("X8");
                        if (!string.IsNullOrEmpty(reader[16].ToString()))
                        {
                            Test_Up_Volm = (Convert.ToInt64(reader[16].ToString())).ToString("X8");
                        }
                        /// <summary>
                        ///Test_startp   -------  Start Pressure（ 滤芯的DF检测时的Pressure ） -- 2 ;
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>
                        string Test_startp = (0).ToString("X4");
                        if (!string.IsNullOrEmpty(reader[17].ToString()))
                        {
                            Test_startp = (Convert.ToInt64(reader[17].ToString())).ToString("X4");
                        }
                        /// <summary>
                        ///Test_setBp   -------   Min. BP     -- 2 ;
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>
                        string Test_setBp = (0).ToString("X4");
                        if (!string.IsNullOrEmpty(reader[18].ToString()))
                        {
                            Test_setBp = (Convert.ToInt64(reader[18].ToString())).ToString("X4");
                        }
                        /// <summary>
                        ///Test_Dif_max   -------   Max. DF   -- 2  ；
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>
                        string Test_Dif_max = (0).ToString("X4");
                        if (!string.IsNullOrEmpty(reader[19].ToString()))
                        {
                            Test_Dif_max = Convert.ToInt64(reader[19].ToString().Replace(".", "")).ToString("X4");
                        }
                        /// <summary>
                        ///Htest_Name    -------   Tester名   -- 16 ；
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>

                        string Htest_Name = "";
                        string Test_Htest_Name = "";

                        if (!string.IsNullOrEmpty(reader[20].ToString()))
                        {
                            for (int i = 0; i < 16 - System.Text.Encoding.GetEncoding("GB2312").GetBytes(reader[20].ToString()).Length; i++)
                            {
                                Htest_Name = Htest_Name + "00";
                            }
                            //Htest_Name = reader[20].ToString() + Htest_Name;
                            byte[] StryHtest_Name = System.Text.Encoding.GetEncoding("GB2312").GetBytes(reader[20].ToString());

                            for (int i = 0; i < StryHtest_Name.Length; i++)
                            {

                                Test_Htest_Name = Test_Htest_Name + StryHtest_Name[i].ToString("X2");
                            }

                            Test_Htest_Name = Test_Htest_Name + Htest_Name;
                        }
                        else
                        {
                            Test_Htest_Name = (0).ToString("X32");
                        }
                        /// <summary>
                        ///Htest_DifValue    -------   Testing值1 （DF量）-- 2  ；
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>
                        string Htest_DifValue = (0).ToString("X4");
                        if (!string.IsNullOrEmpty(reader[21].ToString()))
                        {
                            Htest_DifValue = reader[21].ToString().Replace("0.","");
                            Htest_DifValue = Htest_DifValue.Replace(".", "");
                            Htest_DifValue = Convert.ToInt32(Htest_DifValue).ToString("X4");
                        }



                        /// <summary>
                        ///Htest_TestValue    -------   Testing值2 （泡点值）-- 2  ；
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>
                        string Htest_TestValue = (0).ToString("X4");
                        if (!string.IsNullOrEmpty(reader[22].ToString()))
                        {
                            Htest_TestValue = Convert.ToInt64(reader[22].ToString()).ToString("X4");
                        }
                        /// <summary>
                        ///Htest_BP_Result    -------   Result  -- 1 ;
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>
                        string Htest_BP_Result = "00";
                        switch (reader[23].ToString())
                        {
                            case "By Detecting":
                                {
                                    Htest_BP_Result = "47";
                                }
                                break;
                            case "Did Not By Detecting":
                                {
                                    Htest_BP_Result = "55";
                                }
                                break;

                            default:
                                Htest_BP_Result = "45";
                                break;
                        }



                        /// <summary>
                        ///Htest_DIF_Result   -------   Result  -- 1 ;
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>
                        string Htest_DIF_Result = "\0";
                        switch (reader[24].ToString())
                        {
                            case "By Detecting":
                                {
                                    Htest_DIF_Result = "47";
                                }
                                break;
                            case "Did Not By Detecting":
                                {
                                    Htest_DIF_Result = "55";
                                }
                                break;

                            default:
                                Htest_DIF_Result = "45";
                                break;
                        }
                        /// <summary>
                        ///Htest_ALL_Result  -------   Result  -- 1 ;
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>
                        string Htest_ALL_Result = "\0";
                        switch (reader[25].ToString())
                        {
                            case "By Detecting":
                                {
                                    Htest_ALL_Result = "47";
                                }
                                break;
                            case "Did Not By Detecting":
                                {
                                    Htest_ALL_Result = "55";
                                }
                                break;

                            default:
                                Htest_ALL_Result = "45";
                                break;
                        }

                        /// <summary>
                        ///Htest_DiffePress ------ Testing的Pressure Scale Fall ；（自检Testing，Pressure衰减）-- 2；
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>
                        string Htest_DiffePress = (0).ToString("X4");
                        if (!string.IsNullOrEmpty(reader[26].ToString()))
                        {
                            Htest_DiffePress = (Convert.ToInt64(reader[26].ToString())).ToString("X4");
                        }
                        /// <summary>
                        ///Htest_testimes  -------   Chart的采样次数  -- 1 ;
                        /// </summary>
                        /// <param name="sender"></param>
                        /// <param name="e"></param>
                        string Htest_testimes = (0).ToString("X2");
                        if (!string.IsNullOrEmpty(reader[27].ToString()))
                        {
                            Htest_testimes = Convert.ToInt64(reader[27].ToString()).ToString("X2");
                        }
                        string Hisdata = "";

                        if (!string.IsNullOrEmpty(reader[27].ToString()))
                        {
                            if (Convert.ToInt64(reader[27].ToString()) <= 50)
                            {
                                for (int i = 28; i < 28 + Convert.ToInt64(reader[27].ToString()); i++)
                                {

                                    if (!string.IsNullOrEmpty(reader[i].ToString()))
                                    {
                                        Hisdata = Hisdata + Convert.ToInt64(reader[i].ToString()).ToString("X2");
                                    }
                                    else
                                    {
                                        Hisdata = Hisdata + "00";
                                    }
                                }
                            }
                            else
                            {
                                Htest_testimes = (50).ToString("X2");
                                for (int i = 28; i < 77; i++)
                                {
                                    if (!string.IsNullOrEmpty(reader[i].ToString()))
                                    {
                                        Hisdata = Hisdata + Convert.ToInt64(reader[i].ToString()).ToString("X2");
                                    }
                                    else
                                    {
                                        Hisdata = Hisdata + "00";
                                    }
                                }

                            }
                        }


                        CommPort mComPort = CommPort.Instance;

                        mComPort.SearchDeviceAddress();

                        try
                        {
                            //+ Hisdatasum + n.ToString("X4") + TestHisData
                            string mStrlenth = "FF" + "00" + "00" + "09" + Hisdatasum + (1).ToString("X2") + Test_type + Test_Ps + Test_Ts + Test_Fs + Test_fi + Test_LI + mDT + mTest_LIQUType + Test_LIQUConsistence + Test_Filter_type + Test_Filter_Config + Test_Filter_numer + Test_Filter_Area + Test_Meme_Aper + Test_Velocity + Test_Up_Volm + Test_startp + Test_setBp + Test_Dif_max + Test_Htest_Name + Htest_DifValue + Htest_TestValue + Htest_BP_Result + Htest_DIF_Result + Htest_ALL_Result + Htest_DiffePress + Htest_testimes + Hisdata + "00";

                            string str = "FF" + "{0}" + "{1}" + "09" + Hisdatasum + (1).ToString("X2") + Test_type + Test_Ps + Test_Ts + Test_Fs + Test_fi + Test_LI + mDT + mTest_LIQUType + Test_LIQUConsistence + Test_Filter_type + Test_Filter_Config + Test_Filter_numer + Test_Filter_Area + Test_Meme_Aper + Test_Velocity + Test_Up_Volm + Test_startp + Test_setBp + Test_Dif_max + Test_Htest_Name + Htest_DifValue + Htest_TestValue + Htest_BP_Result + Htest_DIF_Result + Htest_ALL_Result + Htest_DiffePress + Htest_testimes + Hisdata + "00";

                            str = string.Format(str, CommPort.mDeviceAddress.ToString("X2"), ((mStrlenth.Length) / 2).ToString("X2"));
                            byte[] sendData = mComPort.convertstringtobyte(str);
                            int sum = 0;
                            foreach (int i in sendData)
                            {
                                sum += i;
                            }
                            sendData[sendData.Length - 1] = (byte)(sum % 256);
                            mComPort.Send(sendData);
                        }

                        catch (Exception)
                        {
                            //MessageBox.Show(er.Message);
                        }






                    }

                    reader.Close();


                }

                catch (Exception)
                {

                    //MessageBox.Show("Exception:" + ex.ToString(), "Tips");

                }
                finally
                {

                    mConnection.Close();

                }


            }
        }
    }

}

