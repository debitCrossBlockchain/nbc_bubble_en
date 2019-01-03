using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADOX;//引用创建Access数据库的库
using System.IO;
using System.Data.OleDb;
using SunManage;
using System.Data;
using System.Windows.Forms;
namespace SunManage.DataBase
{
    public partial class DataBase
    {
        #region 判断数据是否为空
        /// <summary>
        /// 判断数据库历史数据是否为空
        /// </summary>
        public bool GetTables(OleDbConnection conn, string TableName)
        {

            int result = 0;
            DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                                                             new object[] { null, null, null, "TABLE" });
            try
            {
                if (schemaTable != null)
                {

                    for (Int32 row = 0; row < schemaTable.Rows.Count; row++)
                    {
                        string col_name = schemaTable.Rows[row]["TABLE_NAME"].ToString();
                        if (col_name == TableName)
                        {
                            result++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
            if (result == 0)
                return false;
            return true;
        }
        #endregion

        #region 建Basic Bubble Point启动Testing数据表
        /// <summary>
        /// 建Basic Bubble Point启动Testing数据表
        /// </summary>

        public void CreatDB(string TableName)
        {
            try
            {
                DataBase mDataBase = new DataBase();
                ADOX.Catalog catalog = new Catalog();
                ADODB.Connection cn = new ADODB.Connection();


                string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\StartTest.mdb";
                OleDbConnection mConnection;
                mConnection = new OleDbConnection(sAccessConnection);

                mConnection.Open();
                cn.Open(sAccessConnection, null, null, -1);
                catalog.ActiveConnection = cn;

                bool flag = mDataBase.GetTables(mConnection, TableName);
                if (!flag)//判断表名是否存在
                {

                    ADOX.Table table = new ADOX.Table();

                    table.Name = TableName;

                    ADOX.Column column = new ADOX.Column();
                    column.ParentCatalog = catalog;
                    column.Name = "DeviceName";
                    column.Type = DataTypeEnum.adWChar;
                    column.DefinedSize = 50;
                    column.Properties["AutoIncrement"].Value = false;
                    column.Properties["Jet OLEDB:Allow Zero Length"].Value = true;
                    //                        //column.Properties["Jet OLEDB:Allow Zero Length"].Value = true;
                    //                        struct TTest_Param               // ------ 107
                    //{
                    //  unsigned char      Test_type;               // Testing mode      -- 1                    
                    //  unsigned char      Test_Psernum[16];        // product_batch_NO      -- 16 
                    //  unsigned char      Test_Tsernum[16];        // 产品编号      -- 16                         
                    //  unsigned char      Test_Fsernum[16];        // Filter Serial Number     --  16
                    //  unsigned char      Test_filt[16];           // Filter Material Type     --  16
                    //  unsigned char      Test_LIQU[15];           // Testing Liquid      -- 15
                    //  unsigned char      Test_Dt[5];              // Date/Time     -- 5
                    //  unsigned char      Test_LIQUType;           // Testing Liquid种类  -- 1
                    //  unsigned int       Test_LIQUConsistence;    // Testing Liquid浓度  -- 2
                    //  unsigned char      Test_Filter_type;        // 测量用过滤器的种类  筒式/平板/囊式/Other  -- 1  
                    //  unsigned short     Test_Filter_Config;      // 过滤材料的规格（或平板滤器的直径） （2.5",5“，10”，20“，30”, 40"） -- 4
                    //  unsigned char      Test_Filter_numer;       // Testing过滤器滤芯的数量           -- 1 
                    //  unsigned int       Test_Filter_Area  ;      // Filter Area
                    //  unsigned short     Test_Meme_Aper;          // 过滤材料的Aperture（精度） 如:0。22um       -- 2
                    //  unsigned short     Test_Velocity ;          // 基本泡点Test Mode / Water Immersion 的test_time  -- 2
                    //  unsigned int       Test_Up_Volm;            // 滤芯的Upstream Volume                           -- 4 
                    //  unsigned short     Test_startp ;            // Start Pressure（ 滤芯的DF检测时的Pressure ）   -- 2
                    //  unsigned short     Test_setBp  ;            // Min. BP                                 -- 2 
                    //  unsigned short     Test_Dif_max  ;          // Max. DF                               -- 2

                    // };




                    table.Columns.Append(column, DataTypeEnum.adWChar, 50);
                    table.Keys.Append("FirstTablePrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);
                    //（1） Test_type          -------    Testing mode (M/B/A/P/D/H)    -- 1;
                    table.Columns.Append("Htest_type", DataTypeEnum.adVarWChar, 50);//（1） Test_type          -------    Testing mode (M/B/A/P/D/H)    -- 1;
                    table.Columns["Htest_type"].Attributes = ColumnAttributesEnum.adColNullable;//（1） Test_type          -------    Testing mode (M/B/A/P/D/H)    -- 1;

                    //（2） Test_Psernum[16]   -------   product_batch_NO       -- 16     ;
                    table.Columns.Append("Test_Psernum", DataTypeEnum.adVarWChar, 50);
                    table.Columns["Test_Psernum"].Attributes = ColumnAttributesEnum.adColNullable;

                    //（3） Test_Tsernum[16]   -------   产品编号       -- 16     ;
                    table.Columns.Append("Test_Tsernum", DataTypeEnum.adVarWChar, 50);
                    table.Columns["Test_Tsernum"].Attributes = ColumnAttributesEnum.adColNullable;

                    //（4） Test_Fsernum [16]   -------  Filter Serial Number       -- 16     ;
                    table.Columns.Append("Test_Fsernum", DataTypeEnum.adVarWChar, 50);
                    table.Columns["Test_Fsernum"].Attributes = ColumnAttributesEnum.adColNullable;

                    //（5） Test_filt[16]        -------  Filter Material Type       -- 16     ;
                    table.Columns.Append("Test_filt", DataTypeEnum.adVarWChar, 50);
                    table.Columns["Test_filt"].Attributes = ColumnAttributesEnum.adColNullable;

                    //（6）Test_LIQU[15]       -------  Testing Liquid       -- 15    ;
                    table.Columns.Append("Test_LIQU", DataTypeEnum.adVarWChar, 50);
                    table.Columns["Test_LIQU"].Attributes = ColumnAttributesEnum.adColNullable;

                    //（7）Test_Dt[5]           -------  Date/Time       -- 5    ;
                    table.Columns.Append("HA_STime", DataTypeEnum.adVarWChar, 50);
                    table.Columns["HA_STime"].Attributes = ColumnAttributesEnum.adColNullable;

                    //（8）Test_LIQUType      -------  Testing Liquid种类    -- 1    ;
                    table.Columns.Append("Test_LIQUType", DataTypeEnum.adVarWChar, 50);
                    table.Columns["Test_LIQUType"].Attributes = ColumnAttributesEnum.adColNullable;

                    //（9）Test_LIQUConsistence -------  Testing Liquid浓度    -- 2    ;
                    table.Columns.Append("Test_LIQUConsistence", DataTypeEnum.adWChar, 50);
                    table.Columns["Test_LIQUConsistence"].Attributes = ColumnAttributesEnum.adColNullable;

                    //（10）Test_Filter_type ------- 测量用过滤器的种类(筒式/平板/囊式/Other) -- 1 ;
                    table.Columns.Append("Test_Filter_type", DataTypeEnum.adVarWChar, 50);
                    table.Columns["Test_Filter_type"].Attributes = ColumnAttributesEnum.adColNullable;

                    //（11）Test_Filter_Config  ------- 过滤材料的规格（或平板滤器的直径）  -- 2;
                    table.Columns.Append("Test_Filter_Config", DataTypeEnum.adWChar, 50);
                    table.Columns["Test_Filter_Config"].Attributes = ColumnAttributesEnum.adColNullable;

                    //（12）Test_Filter_numer  -------  Testing过滤器滤芯的数量        -- 1 ;
                    table.Columns.Append("Test_Filter_number", DataTypeEnum.adVarWChar, 50);
                    table.Columns["Test_Filter_number"].Attributes = ColumnAttributesEnum.adColNullable;

                    //（13）Test_Filter_Area   -------  Filter Area           -- 4    ;
                    table.Columns.Append("Test_Filter_Area", DataTypeEnum.adWChar, 50);
                    table.Columns["Test_Filter_Area"].Attributes = ColumnAttributesEnum.adColNullable;

                    //（14）Test_Meme_Aper  -------  过滤材料的Aperture（精度）      -- 2  ;
                    table.Columns.Append("Test_Meme_Aper", DataTypeEnum.adWChar, 50);
                    table.Columns["Test_Meme_Aper"].Attributes = ColumnAttributesEnum.adColNullable;

                    //（15）Test_Velocity  ------- 基本泡点Test Mode / Water浸入的test_time  -- 2 ;
                    table.Columns.Append("Test_Velocity", DataTypeEnum.adWChar, 50);
                    table.Columns["Test_Velocity"].Attributes = ColumnAttributesEnum.adColNullable;

                    //（16）Test_Up_Volm  ------- 滤芯的Upstream Volume  -- 4 ;
                    table.Columns.Append("Test_Up_Volm", DataTypeEnum.adWChar, 50);
                    table.Columns["Test_Up_Volm"].Attributes = ColumnAttributesEnum.adColNullable;

                    //（17）Test_startp   -------  Start Pressure（ 滤芯的DF检测时的Pressure ） -- 2 ;
                    table.Columns.Append("Test_startp", DataTypeEnum.adWChar, 50);
                    table.Columns["Test_startp"].Attributes = ColumnAttributesEnum.adColNullable;

                    //（18）Test_setBp   -------   Min. BP     -- 2 ;
                    table.Columns.Append("Test_setBp", DataTypeEnum.adWChar, 50);
                    table.Columns["Test_setBp"].Attributes = ColumnAttributesEnum.adColNullable;

                    //（19）Test_Dif_max   -------   Max. DF   -- 2  ；
                    table.Columns.Append("Test_Dif_max", DataTypeEnum.adWChar, 50);
                    table.Columns["Test_Dif_max"].Attributes = ColumnAttributesEnum.adColNullable;





                    try
                    {

                        catalog.Tables.Append(table);

                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);

                    }

                    //此处一定要关闭连接，否则添加数据时候会出错

                    table = null;

                    catalog = null;

                    Application.DoEvents();
                }

                mConnection.Close();
                cn.Close();

                //New Device参数数据库表


            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }

        }
    }
        #endregion

}
