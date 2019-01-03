using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADOX;
using System.Data.OleDb;


namespace SunManage.communication
{
    public partial class CommunicationConnect : Form
    {
        private OleDbConnection mConnectionDeviceConcatenateParameter;
        string sAccessConnectionDeviceConcatenateParameter = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\DeviceConcatenate.mdb";
        public CommunicationConnect()
        {
            InitializeComponent();
           
        }
        
        /// <summary>
        /// 判断数据库历史数据是否为空
        /// </summary>
        public bool GetTables(OleDbConnection conn)
        {
            int result = 0;
            DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                                                             new object[] { null, null, null, "TABLE" });
            if (schemaTable != null)
            {

                for (Int32 row = 0; row < schemaTable.Rows.Count; row++)
                {
                    string col_name = schemaTable.Rows[row]["TABLE_NAME"].ToString();
                    if (col_name == this.DeviceName.Text)
                    {
                        result++;
                    }
                }
            }
            if (result == 0)
                return false;
            return true;
        }

        /// <summary>
        /// 判断数据库系统参数数据是否为空
        /// </summary>
        public bool GetTablesSP(OleDbConnection conn)
        {

            int result = 0;
            DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                                                             new object[] { null, null, null, "TABLE" });


            if (schemaTable != null)
            {

                for (Int32 row = 0; row < schemaTable.Rows.Count; row++)
                {
                    string col_name = schemaTable.Rows[row]["TABLE_NAME"].ToString();
                    if (col_name == this.DeviceName.Text)
                    {
                        result++;
                    }
                }
            }
            if (result == 0)
                return false;
            return true;
        }
        

        private string DeviceNameId;

        public string DeviceNameId1
        {
            get { return DeviceNameId; }
            set { DeviceNameId = value; }
        }
        
        private void ConfirmTheConnected_Click(object sender, EventArgs e)
        {
            
            DeviceNameId = this.DeviceName.Text;
            if (!(string.IsNullOrEmpty(this.textBoxDeviceAddress.Text)) && !(string.IsNullOrEmpty(this.DeviceName.Text)))
            {
                string mDeviceName=this.DeviceName.Text.ToString();
                string mDeviceAddress=this.textBoxDeviceAddress.Text.ToString();
                //string mQuery = "insert into {0} ([Test_Num]= '" + mTest_Num + "',[HA_STime]='" + DTime + "' ,[Test_Psernum]='" + Psernum + "',[Htest_type]='" + Htest_type + "',[Test_Result]='" + HtestResult + "',[Test_filt]='" + Test_filt + "',[Test_LIQU]='" + Test_LIQU + "',[Test_Meme_Aper]='" + Test_Meme_Aper + "',[Test_Filter_type]='" + Test_Filter_type + "',[Test_Filter_number]='" + Test_Filter_numer + "',[Test_Filter_Config]='" + Test_Filter_Config + "',[Test_startp]='" + Test_startp + "',[Test_Up_Volm]='" + Test_Up_Volm + "',[Test_Filter_Area]='" + Test_Filter_Area + "' ,[Test_LIQUConsistence]='" + Test_LIQUConsistence + "',[Test_setBp]='" + Test_setBp + "',[Test_Dif_max]='" + Test_Dif_max + "',[Htest_Value]='" + Htest_TestValue + "',[Htest_DifValue]='" + Htest_DifValue + "',[Htest_DiffePress]='" + Htest_DiffePress + "')" ;
                string mQuery = String.Format("insert into DeviceConcatenate ([DeviceName],[DeviceAddress],[mStatFlagBP],[mStatFlagMP],[mStatFlagRR],[mStatFlagDF],[mStatFlagWI],[mStatFlagSP]) values ('{0}','{1}','1','1','1','1','1','1')", mDeviceName, mDeviceAddress);
                // mQuery = string.Format(mQuery, mTreeView);
                mConnectionDeviceConcatenateParameter = new OleDbConnection(sAccessConnectionDeviceConcatenateParameter);

                OleDbCommand da = new OleDbCommand(mQuery, mConnectionDeviceConcatenateParameter);

                //

                try
                {
                    mConnectionDeviceConcatenateParameter.Open();
                    da.ExecuteNonQuery();

                   // MessageBox.Show("Add Success！", "Tips");

                    //this.Close();

                }

                catch (Exception ex)
                {

                    MessageBox.Show("Exception:" + ex.ToString(), "Tips");

                }

                finally
                {

                    mConnectionDeviceConcatenateParameter.Close();

                }
                /// <summary>
                /// 轮询查询
                /// </summary>
                OleDbConnection mConnectionDeviceConcatenateParameterMDB;
                string sAccessConnectionDeviceConcatenateParameterMDB = @"Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\DeviceConcatenate.mdb";
                string MQuery = "Select DeviceAddress From DeviceConcatenate";
                mConnectionDeviceConcatenateParameterMDB = new OleDbConnection(sAccessConnectionDeviceConcatenateParameterMDB);

                Main.mPollingInquiry.Clear();

                try
                {

                    mConnectionDeviceConcatenateParameterMDB.Open();
                    OleDbCommand cmd = new OleDbCommand(MQuery, mConnectionDeviceConcatenateParameterMDB);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Main.mPollingInquiry.Add(reader[0]);
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
            this.Close();
        }

        private void CCancer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
