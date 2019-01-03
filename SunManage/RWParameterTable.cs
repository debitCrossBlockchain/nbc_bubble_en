using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SunManage
{
    /// <summary>
    /// 
    /// </summary>
    class RWParameterTable
    {
        #region 系统参数表
        //系统参数表
      //  //------------------------------------------------------------------------------------------------------------------
      // struct filter_Difmax_Param               // ------ (12) 10“各种滤材的Max. DF参数
      //{
      //unsigned short     PES_Dif_max          ;        // 单芯10“PES滤芯的Max. DF                                -- 2
      //unsigned short     PVDF_Dif_max         ;        // 单芯10“聚偏氟乙烯滤芯的Max. DF                         -- 2
      //unsigned short     PTFE_Dif_max         ;        // 单芯10“聚四氟乙烯（空气过滤）滤芯的Max. DF             -- 2
      //unsigned short     NYLON_Dif_max        ;        // 单芯10“尼龙滤芯的Max. DF                               -- 2
      //unsigned short     OTHER_Dif_max        ;        // 单芯10“Other材质的滤芯的Max. DF                         -- 2
      // unsigned short    PTFE_flow_max        ;        // 滤单芯10“聚四氟乙烯（空气过滤-Water浸入法）滤芯的最大流量    -- 2          
      // };
        /// <summary>
        /// 单芯10“PES滤芯的Max. DF 
        /// </summary>
        private int ReadPES_Dif_max; //单芯10“PES滤芯的Max. DF 

        public int ReadPES_Dif_max1
        {
            get { return ReadPES_Dif_max; }
            set { ReadPES_Dif_max = value; }
        }
        private int WritePES_Dif_max; //单芯10“PES滤芯的Max. DF 

        public int WritePES_Dif_max1
        {
            get { return WritePES_Dif_max; }
            set { WritePES_Dif_max = value; }
        }

        /// <summary>
        ///单芯10“聚偏氟乙烯滤芯的Max. DF 
        /// </summary>
        private int ReadPVDF_Dif_max;        // 单芯10“聚偏氟乙烯滤芯的Max. DF   

        public int ReadPVDF_Dif_max1
        {
            get { return ReadPVDF_Dif_max; }
            set { ReadPVDF_Dif_max = value; }
        }

        private int WritePVDF_Dif_max;        // 单芯10“聚偏氟乙烯滤芯的Max. DF   

        public int WritePVDF_Dif_max1
        {
            get { return WritePVDF_Dif_max; }
            set { WritePVDF_Dif_max = value; }
        }
        /// <summary>
        ///单芯10“聚四氟乙烯（空气过滤）滤芯的Max. DF 
        /// </summary>

        private int ReadPTFE_Dif_max;        // 单芯10“聚四氟乙烯（空气过滤）滤芯的Max. DF

        public int ReadPTFE_Dif_max1
        {
            get { return ReadPTFE_Dif_max; }
            set { ReadPTFE_Dif_max = value; }
        }

        private int WritePTFE_Dif_max;        // 单芯10“聚四氟乙烯（空气过滤）滤芯的Max. DF

        public int WritePTFE_Dif_max1
        {
            get { return WritePTFE_Dif_max; }
            set { WritePTFE_Dif_max = value; }
        }

        /// <summary>
        /// 单芯10“尼龙滤芯的Max. DF
        /// </summary>
        private int ReadNYLON_Dif_max;        // 单芯10“尼龙滤芯的Max. DF 

        public int ReadNYLON_Dif_max1
        {
            get { return ReadNYLON_Dif_max; }
            set { ReadNYLON_Dif_max = value; }
        }
        private int WriteNYLON_Dif_max;        // 单芯10“尼龙滤芯的Max. DF 

        public int WriteNYLON_Dif_max1
        {
            get { return WriteNYLON_Dif_max; }
            set { WriteNYLON_Dif_max = value; }
        }

        /// <summary>
        ///单芯10“Other材质的滤芯的Max. DF
        /// </summary>
        private int ReadOTHER_Dif_max;        // 单芯10“Other材质的滤芯的Max. DF

        public int ReadOTHER_Dif_max1
        {
            get { return ReadOTHER_Dif_max; }
            set { ReadOTHER_Dif_max = value; }
        }
        private int WriteOTHER_Dif_max;        // 单芯10“Other材质的滤芯的Max. DF

        public int WriteOTHER_Dif_max1
        {
            get { return WriteOTHER_Dif_max; }
            set { WriteOTHER_Dif_max = value; }
        }
        /// <summary>
        /// 滤单芯10“聚四氟乙烯（空气过滤-Water浸入法）滤芯的最大流量
        /// </summary>

        private int ReadPTFE_flow_max;        // 滤单芯10“聚四氟乙烯（空气过滤-Water浸入法）滤芯的最大流量

        public int ReadPTFE_flow_max1
        {
            get { return ReadPTFE_flow_max; }
            set { ReadPTFE_flow_max = value; }
        }
        private int WritePTFE_flow_max;        // 滤单芯10“聚四氟乙烯（空气过滤-Water浸入法）滤芯的最大流量

        public int WritePTFE_flow_max1
        {
            get { return WritePTFE_flow_max; }
            set { WritePTFE_flow_max = value; }
        }

       // struct Device_Param              // ------ （18）设备的基本参数
       //{
       // unsigned int      Inter_Volm          ;      // -----系统的内部体积          -- 4
       // unsigned int      Exter_Volm          ;      // -----外部缓冲罐的体积        -- 4
       // unsigned short    SourceP             ;      // -----外部的气源Pressure          -- 2
       // unsigned short    AddP_extent         ;      // -----对滤芯的Pressure增幅        -- 2
       // unsigned char     Print_setup         ;      // -----打印set                -- 1
       // unsigned char     Over_Modesetup      ;      // -----Testing结束的方式（泡点合格后Testing结束的方式）  手动/自动   -- 1
       // unsigned char     Language_setup      ;      // -----语言set                -- 1
       // unsigned char     Default_Load        ;      // -----缺省值得Load            -- 1
       // unsigned char     InitTestPara        ;      // -----初始化Testing Args          -- 1
       // unsigned char     Test_rate           ;      // -----Testing速度的级别          -- 1
       // } ;
        /// <summary>
        /// 系统的内部体积
        /// </summary>
        private int ReadInter_Volm;      // -----系统的内部体积

        public int ReadInter_Volm1
        {
            get { return ReadInter_Volm; }
            set { ReadInter_Volm = value; }
        }
        private int WriteInter_Volm;      // -----系统的内部体积

        public int WriteInter_Volm1
        {
            get { return WriteInter_Volm; }
            set { WriteInter_Volm = value; }
        }
        /// <summary>
        /// 外部缓冲罐的体积
        /// </summary>
        private int ReadExter_Volm;      // -----外部缓冲罐的体积

        public int ReadExter_Volm1
        {
            get { return ReadExter_Volm; }
            set { ReadExter_Volm = value; }
        }
        private int WriteExter_Volm;      // -----外部缓冲罐的体积     

        public int WriteExter_Volm1
        {
            get { return WriteExter_Volm; }
            set { WriteExter_Volm = value; }
        }
        /// <summary>
        /// 外部的气源Pressure
        /// </summary>
        private int ReadSourceP;      // -----外部的气源Pressure

        public int ReadSourceP1
        {
            get { return ReadSourceP; }
            set { ReadSourceP = value; }
        }
        private int WriteSourceP;      // -----外部的气源Pressure

        public int WriteSourceP1
        {
            get { return WriteSourceP; }
            set { WriteSourceP = value; }
        }
        /// <summary>
        /// 对滤芯的Pressure增幅
        /// </summary>
        private int ReadAddP_extent;      // -----对滤芯的Pressure增幅

        public int ReadAddP_extent1
        {
            get { return ReadAddP_extent; }
            set { ReadAddP_extent = value; }
        }
        private int WriteAddP_extent;      // -----对滤芯的Pressure增幅

        public int WriteAddP_extent1
        {
            get { return WriteAddP_extent; }
            set { WriteAddP_extent = value; }
        }
        /// <summary>
        /// 打印set
        /// </summary>
        private char ReadPrint_setup;      // -----打印set

        public char ReadPrint_setup1
        {
            get { return ReadPrint_setup; }
            set { ReadPrint_setup = value; }
        }
        private char WritePrint_setup;      // -----打印set

        public char WritePrint_setup1
        {
            get { return WritePrint_setup; }
            set { WritePrint_setup = value; }
        }
        /// <summary>
        /// Testing结束的方式（泡点合格后Testing结束的方式）  手动/自动
        /// </summary>
        private char ReadOver_Modesetup;      // -----Testing结束的方式（泡点合格后Testing结束的方式）  手动/自动

        public char ReadOver_Modesetup1
        {
            get { return ReadOver_Modesetup; }
            set { ReadOver_Modesetup = value; }
        }
        private char WriteOver_Modesetup;      // -----Testing结束的方式（泡点合格后Testing结束的方式）  手动/自动

        public char WriteOver_Modesetup1
        {
            get { return WriteOver_Modesetup; }
            set { WriteOver_Modesetup = value; }
        }
        /// <summary>
        /// 语言set
        /// </summary>
        private char ReadLanguage_setup;      // -----语言set

        public char ReadLanguage_setup1
        {
            get { return ReadLanguage_setup; }
            set { ReadLanguage_setup = value; }
        }
        private char WriteLanguage_setup;      // -----语言set

        public char WriteLanguage_setup1
        {
            get { return WriteLanguage_setup; }
            set { WriteLanguage_setup = value; }
        }
        /// <summary>
        /// 缺省值得Load
        /// </summary>
        private char ReadDefault_Load;      // -----缺省值得Load

        public char ReadDefault_Load1
        {
            get { return ReadDefault_Load; }
            set { ReadDefault_Load = value; }
        }
        private char WriteDefault_Load;      // -----缺省值得Load

        public char WriteDefault_Load1
        {
            get { return WriteDefault_Load; }
            set { WriteDefault_Load = value; }
        }
        /// <summary>
        /// 初始化Testing Args 
        /// </summary>
        private char ReadInitTestPara;      // -----初始化Testing Args 

        public char ReadInitTestPara1
        {
            get { return ReadInitTestPara; }
            set { ReadInitTestPara = value; }
        }
        private char WriteInitTestPara;      // -----初始化Testing Args 

        public char WriteInitTestPara1
        {
            get { return WriteInitTestPara; }
            set { WriteInitTestPara = value; }
        }

        /// <summary>
        /// Testing速度的级别 
        /// </summary>
        private char ReadTest_rate;      // -----Testing速度的级别

        public char ReadTest_rate1
        {
            get { return ReadTest_rate; }
            set { ReadTest_rate = value; }
        }
        private char WriteTest_rate;      // -----Testing速度的级别

        public char WriteTest_rate1
        {
            get { return WriteTest_rate; }
            set { WriteTest_rate = value; }
        }
       // struct Sensor_Param                     // ------ (8) Pressure传感器的校验参数
       //{
       //  unsigned short     Psense_Zero_0        ;       // 0号（缓冲罐中）Pressure传感器40PC的零点值                  -- 2
       //  unsigned short     Psense_Zero_1        ;       // 1号（Upstream Volume中）Pressure传感器40PC的零点值                -- 2
       //  unsigned short     Psense_Coeff_0       ;       // 0号（缓冲罐中）Pressure传感器40PC的系数                    -- 2
       //  unsigned short     Psense_Coeff_1       ;       // 1号（Upstream Volume中）Pressure传感器40PC的系数                  -- 2
       // } ;
        /// <summary>
        /// 0号（缓冲罐中）Pressure传感器40PC的零点值 
        /// </summary>
        private int ReadPsense_Zero_0;       // 0号（缓冲罐中）Pressure传感器40PC的零点值

        public int ReadPsense_Zero_01
        {
            get { return ReadPsense_Zero_0; }
            set { ReadPsense_Zero_0 = value; }
        }
        private int WritePsense_Zero_0;       // 0号（缓冲罐中）Pressure传感器40PC的零点值

        public int WritePsense_Zero_01
        {
            get { return WritePsense_Zero_0; }
            set { WritePsense_Zero_0 = value; }
        }
        /// <summary>
        ///1号（Upstream Volume中）Pressure传感器40PC的零点值 
        /// </summary>
        private int ReadPsense_Zero_1;       // 1号（Upstream Volume中）Pressure传感器40PC的零点值

        public int ReadPsense_Zero_11
        {
            get { return ReadPsense_Zero_1; }
            set { ReadPsense_Zero_1 = value; }
        }
        private int WritePsense_Zero_1;       // 1号（Upstream Volume中）Pressure传感器40PC的零点值

        public int WritePsense_Zero_11
        {
            get { return WritePsense_Zero_1; }
            set { WritePsense_Zero_1 = value; }
        }
        /// <summary>
        ///0号（缓冲罐中）Pressure传感器40PC的系数 
        /// </summary>
        private int ReadPsense_Coeff_0;       // 0号（缓冲罐中）Pressure传感器40PC的系数

        public int ReadPsense_Coeff_01
        {
            get { return ReadPsense_Coeff_0; }
            set { ReadPsense_Coeff_0 = value; }
        }
        private int WritePsense_Coeff_0;       // 0号（缓冲罐中）Pressure传感器40PC的系数

        public int WritePsense_Coeff_01
        {
            get { return WritePsense_Coeff_0; }
            set { WritePsense_Coeff_0 = value; }
        }
        /// <summary>
        /// 1号（Upstream Volume中）Pressure传感器40PC的系数
        /// </summary>
        private int ReadPsense_Coeff_1;       // 1号（Upstream Volume中）Pressure传感器40PC的系数

        public int ReadPsense_Coeff_11
        {
            get { return ReadPsense_Coeff_1; }
            set { ReadPsense_Coeff_1 = value; }
        }
        private int WritePsense_Coeff_1;       // 1号（Upstream Volume中）Pressure传感器40PC的系数

        public int WritePsense_Coeff_11
        {
            get { return WritePsense_Coeff_1; }
            set { WritePsense_Coeff_1 = value; }
        }
        //struct System_Manage_Param                     // ------ (49) 仪器系统的管理参数
        //{
        //unsigned char     senson_adj_year        ;         // Pressure传感器校验的Testing mode份             -- 1
        //unsigned char     senson_adj_month       ;         // Pressure传感器校验的月份             -- 1
        //unsigned char     OutFaction_year        ;         // 仪器出厂的Testing mode份                   -- 1
        //unsigned char     OutFaction_month       ;         // 仪器出厂的月份                   -- 1
        //unsigned char     IF_Outfaction          ;         //  出厂过期的By Detectingword解锁标记          -- 1
        //unsigned char     Device_Serial[12]      ;         //  出厂过期序列号                  -- 12
        //unsigned char     Using_CompanyName[32]  ;         // 使用企业的名称                   -- 32
        // } ;
        /// <summary>
        ///Pressure传感器校验的Testing mode份
        /// </summary>
        private char Readsenson_adj_year;         // Pressure传感器校验的Testing mode份

        public char Readsenson_adj_year1
        {
            get { return Readsenson_adj_year; }
            set { Readsenson_adj_year = value; }
        }
        private char Writesenson_adj_year;         // Pressure传感器校验的Testing mode份

        public char Writesenson_adj_year1
        {
            get { return Writesenson_adj_year; }
            set { Writesenson_adj_year = value; }
        }
        /// <summary>
        ///Pressure传感器校验的月份
        /// </summary>
        private char Readsenson_adj_month;         // Pressure传感器校验的月份

        public char Readsenson_adj_month1
        {
            get { return Readsenson_adj_month; }
            set { Readsenson_adj_month = value; }
        }
        private char Writesenson_adj_month;         // Pressure传感器校验的月份

        public char Writesenson_adj_month1
        {
            get { return Writesenson_adj_month; }
            set { Writesenson_adj_month = value; }
        }
        /// <summary>
        ///仪器出厂的Testing mode份
        /// </summary>
        private char ReadOutFaction_year;         // 仪器出厂的Testing mode份

        public char ReadOutFaction_year1
        {
            get { return ReadOutFaction_year; }
            set { ReadOutFaction_year = value; }
        }
        private char WriteOutFaction_year;         // 仪器出厂的Testing mode份

        public char WriteOutFaction_year1
        {
            get { return WriteOutFaction_year; }
            set { WriteOutFaction_year = value; }
        }
        /// <summary>
        ///仪器出厂的月份 
        /// </summary>
        private char ReadOutFaction_month;         // 仪器出厂的月份 

        public char ReadOutFaction_month1
        {
            get { return ReadOutFaction_month; }
            set { ReadOutFaction_month = value; }
        }
        private char WriteOutFaction_month;         // 仪器出厂的月份 

        public char WriteOutFaction_month1
        {
            get { return WriteOutFaction_month; }
            set { WriteOutFaction_month = value; }
        }
        /// <summary>
        ///出厂过期的By Detectingword解锁标记
        /// </summary>
        private char ReadIF_Outfaction;         //  出厂过期的By Detectingword解锁标记

        public char ReadIF_Outfaction1
        {
            get { return ReadIF_Outfaction; }
            set { ReadIF_Outfaction = value; }
        }
        private char WriteIF_Outfaction;         //  出厂过期的By Detectingword解锁标记

        public char WriteIF_Outfaction1
        {
            get { return WriteIF_Outfaction; }
            set { WriteIF_Outfaction = value; }
        }
        /// <summary>
        /// 出厂过期序列号
        /// </summary>
        private char ReadDevice_Serial;         //  出厂过期序列号

        public char ReadDevice_Serial1
        {
            get { return ReadDevice_Serial; }
            set { ReadDevice_Serial = value; }
        }
        private char WriteDevice_Serial;         //  出厂过期序列号

        public char WriteDevice_Serial1
        {
            get { return WriteDevice_Serial; }
            set { WriteDevice_Serial = value; }
        }
        /// <summary>
        /// 使用企业的名称
        /// </summary>
        private string ReadUsing_CompanyName;         // 使用企业的名称

        public string ReadUsing_CompanyName1
        {
            get { return ReadUsing_CompanyName; }
            set { ReadUsing_CompanyName = value; }
        }
        private string WriteUsing_CompanyName;         // 使用企业的名称

        public string WriteUsing_CompanyName1
        {
            get { return WriteUsing_CompanyName; }
            set { WriteUsing_CompanyName = value; }
        }
       // struct Communiction_Param                     // ------ (18) 仪器的通讯参数
       //{
       // unsigned short    Brate_Uart         ;          // 串行通行的Rate              -- 2
       // unsigned char     Databits_Uart       ;         // 串行通行的DataBits              -- 1
       // unsigned char     Parity_Uart        ;          // 串行通行的Parity              -- 1
       // unsigned char     Stopbit_Uart       ;          // 串行通行的StopBits              -- 1
       // unsigned char     IFAutoIP           ;          // 是否自动获取Ethernet的IP地址    -- 1
       // unsigned char     Net_IP1            ;          // Ethernet的IP地址1               -- 1
       // unsigned char     Net_IP2            ;          // Ethernet的IP地址2               -- 1
       // unsigned char     Net_IP3            ;          // Ethernet的IP地址3               -- 1
       // unsigned char     Net_IP4            ;          // Ethernet的IP地址4               -- 1
       // unsigned char     Subnet_Mask1       ;          // 子网掩码的地址1               -- 1
       // unsigned char     Subnet_Mask2       ;          // 子网掩码的地址2               -- 1
       // unsigned char     Subnet_Mask3       ;          // 子网掩码的地址3               -- 1
       // unsigned char     Subnet_Mask4       ;          // 子网掩码的地址4               -- 1
       // unsigned char     Default_Gateway1   ;          // 默认网关的地址1               -- 1
       // unsigned char     Default_Gateway2   ;          // 默认网关的地址2               -- 1
       // unsigned char     Default_Gateway3   ;          // 默认网关的地址3               -- 1
       // unsigned char     Default_Gateway4   ;          // 默认网关的地址4               -- 1
       // } ;
        /// <summary>
        /// 串行通行的Rate
        /// </summary>
        private int ReadBrate_Uart;          // 串行通行的Rate

        public int ReadBrate_Uart1
        {
            get { return ReadBrate_Uart; }
            set { ReadBrate_Uart = value; }
        }
        private int WriteBrate_Uart;          // 串行通行的Rate

        public int WriteBrate_Uart1
        {
            get { return WriteBrate_Uart; }
            set { WriteBrate_Uart = value; }
        }
        /// <summary>
        ///  串行通行的DataBits
        /// </summary>
        private char ReadDatabits_Uart;         // 串行通行的DataBits

        public char ReadDatabits_Uart1
        {
            get { return ReadDatabits_Uart; }
            set { ReadDatabits_Uart = value; }
        }
        private char WriteDatabits_Uart;         // 串行通行的DataBits

        public char WriteDatabits_Uart1
        {
            get { return WriteDatabits_Uart; }
            set { WriteDatabits_Uart = value; }
        }
        /// <summary>
        /// 串行通行的Parity
        /// </summary>
        private char ReadParity_Uart;          // 串行通行的Parity

        public char ReadParity_Uart1
        {
            get { return ReadParity_Uart; }
            set { ReadParity_Uart = value; }
        }
        private char WriteParity_Uart;          // 串行通行的Parity

        public char WriteParity_Uart1
        {
            get { return WriteParity_Uart; }
            set { WriteParity_Uart = value; }
        }
        /// <summary>
        ///串行通行的StopBits
        /// </summary>
        private char ReadStopbit_Uart;          // 串行通行的StopBits

        public char ReadStopbit_Uart1
        {
            get { return ReadStopbit_Uart; }
            set { ReadStopbit_Uart = value; }
        }
        private char WriteStopbit_Uart;          // 串行通行的StopBits

        public char WriteStopbit_Uart1
        {
            get { return WriteStopbit_Uart; }
            set { WriteStopbit_Uart = value; }
        }
        /// <summary>
        /// 是否自动获取Ethernet的IP地址
        /// </summary>
        private char ReadIFAutoIP;          // 是否自动获取Ethernet的IP地址

        public char ReadIFAutoIP1
        {
            get { return ReadIFAutoIP; }
            set { ReadIFAutoIP = value; }
        }
        private char WriteIFAutoIP;          // 是否自动获取Ethernet的IP地址

        public char WriteIFAutoIP1
        {
            get { return WriteIFAutoIP; }
            set { WriteIFAutoIP = value; }
        }
        /// <summary>
        ///Ethernet的IP地址1
        /// </summary>
        private char ReadNet_IP1;          // Ethernet的IP地址1

        public char ReadNet_IP11
        {
            get { return ReadNet_IP1; }
            set { ReadNet_IP1 = value; }
        }
        private char WriteNet_IP1;          // Ethernet的IP地址1

        public char WriteNet_IP11
        {
            get { return WriteNet_IP1; }
            set { WriteNet_IP1 = value; }
        }
        /// <summary>
        ///Ethernet的IP地址2
        /// </summary>
        private char ReadNet_IP2;          // Ethernet的IP地址2

        public char ReadNet_IP21
        {
            get { return ReadNet_IP2; }
            set { ReadNet_IP2 = value; }
        }
        private char WriteNet_IP2;          // Ethernet的IP地址2

        public char WriteNet_IP21
        {
            get { return WriteNet_IP2; }
            set { WriteNet_IP2 = value; }
        }
        /// <summary>
        ///Ethernet的IP地址3
        /// </summary>
        private char ReadNet_IP3;          // Ethernet的IP地址3

        public char ReadNet_IP31
        {
            get { return ReadNet_IP3; }
            set { ReadNet_IP3 = value; }
        }
        private char WriteNet_IP3;          // Ethernet的IP地址3

        public char WriteNet_IP31
        {
            get { return WriteNet_IP3; }
            set { WriteNet_IP3 = value; }
        }
        /// <summary>
        ///Ethernet的IP地址4
        /// </summary>
        private char ReadNet_IP4;          // Ethernet的IP地址4

        public char ReadNet_IP41
        {
            get { return ReadNet_IP4; }
            set { ReadNet_IP4 = value; }
        }
        private char WriteNet_IP4;          // Ethernet的IP地址4

        public char WriteNet_IP41
        {
            get { return WriteNet_IP4; }
            set { WriteNet_IP4 = value; }
        }
        /// <summary>
        ///子网掩码的地址1
        /// </summary>
        private char ReadSubnet_Mask1;          // 子网掩码的地址1

        public char ReadSubnet_Mask11
        {
            get { return ReadSubnet_Mask1; }
            set { ReadSubnet_Mask1 = value; }
        }
        private char WriteSubnet_Mask1;          // 子网掩码的地址1

        public char WriteSubnet_Mask11
        {
            get { return WriteSubnet_Mask1; }
            set { WriteSubnet_Mask1 = value; }
        }
        /// <summary>
        ///子网掩码的地址2
        /// </summary>
        private char ReadSubnet_Mask2;          // 子网掩码的地址2

        public char ReadSubnet_Mask21
        {
            get { return ReadSubnet_Mask2; }
            set { ReadSubnet_Mask2 = value; }
        }
        private char WriteSubnet_Mask2;          // 子网掩码的地址2

        public char WriteSubnet_Mask21
        {
            get { return WriteSubnet_Mask2; }
            set { WriteSubnet_Mask2 = value; }
        }
        /// <summary>
        ///子网掩码的地址3
        /// </summary>
        private char ReadSubnet_Mask3;          // 子网掩码的地址3

        public char ReadSubnet_Mask31
        {
            get { return ReadSubnet_Mask3; }
            set { ReadSubnet_Mask3 = value; }
        }
        private char WriteSubnet_Mask3;          // 子网掩码的地址3

        public char WriteSubnet_Mask31
        {
            get { return WriteSubnet_Mask3; }
            set { WriteSubnet_Mask3 = value; }
        }
        /// <summary>
        ///子网掩码的地址4
        /// </summary>
        private char ReadSubnet_Mask4;          // 子网掩码的地址4

        public char ReadSubnet_Mask41
        {
            get { return ReadSubnet_Mask4; }
            set { ReadSubnet_Mask4 = value; }
        }
        private char WriteSubnet_Mask4;          // 子网掩码的地址4

        public char WriteSubnet_Mask41
        {
            get { return WriteSubnet_Mask4; }
            set { WriteSubnet_Mask4 = value; }
        }
        /// <summary>
        ///默认网关的地址1
        /// </summary>
        private char ReadDefault_Gateway1;          // 默认网关的地址1

        public char ReadDefault_Gateway11
        {
            get { return ReadDefault_Gateway1; }
            set { ReadDefault_Gateway1 = value; }
        }
        private char WriteDefault_Gateway1;          // 默认网关的地址1

        public char WriteDefault_Gateway11
        {
            get { return WriteDefault_Gateway1; }
            set { WriteDefault_Gateway1 = value; }
        }
        /// <summary>
        ///默认网关的地址2
        /// </summary>
        private char ReadDefault_Gateway2;          // 默认网关的地址2

        public char ReadDefault_Gateway21
        {
            get { return ReadDefault_Gateway2; }
            set { ReadDefault_Gateway2 = value; }
        }
        private char WriteDefault_Gateway2;          // 默认网关的地址2

        public char WriteDefault_Gateway21
        {
            get { return WriteDefault_Gateway2; }
            set { WriteDefault_Gateway2 = value; }
        }
        /// <summary>
        ///默认网关的地址3 
        /// </summary>
        private char ReadDefault_Gateway3;          // 默认网关的地址3 

        public char ReadDefault_Gateway31
        {
            get { return ReadDefault_Gateway3; }
            set { ReadDefault_Gateway3 = value; }
        }
        private char WriteDefault_Gateway3;          // 默认网关的地址3 

        public char WriteDefault_Gateway31
        {
            get { return WriteDefault_Gateway3; }
            set { WriteDefault_Gateway3 = value; }
        }
        /// <summary>
        ///默认网关的地址4 
        /// </summary>
        private char ReadDefault_Gateway4;          // 默认网关的地址4

        public char ReadDefault_Gateway41
        {
            get { return ReadDefault_Gateway4; }
            set { ReadDefault_Gateway4 = value; }
        }
        private char WriteDefault_Gateway4;          // 默认网关的地址4

        public char WriteDefault_Gateway41
        {
            get { return WriteDefault_Gateway4; }
            set { WriteDefault_Gateway4 = value; }
        }
       // struct PowerManage_Param                     // ------ (6) 电源管理的参数
       //{
       //unsigned char     Power_Supply        ;       //    仪器的供电方式             -- 1 
       //unsigned char     BatterPower_light   ;       //    电池供电时的亮度           -- 1
       //unsigned char     ACPower_light       ;       //    电源供电时的亮度           -- 1           
       //unsigned char     Backlight_time      ;       //    电池供电时的背光Time       -- 1
       //unsigned char     BatterPower_ScreenSave ;    //    电源供电时的屏保Time       -- 1           
       //unsigned char     BattBacklight_time     ;    //    电池供电时的屏幕亮度       -- 1
       // } ;
        /// <summary>
        ///仪器的供电方式
        /// </summary>
        private char ReadPower_Supply;       //    仪器的供电方式

        public char ReadPower_Supply1
        {
            get { return ReadPower_Supply; }
            set { ReadPower_Supply = value; }
        }
        private char WritePower_Supply;       //    仪器的供电方式

        public char WritePower_Supply1
        {
            get { return WritePower_Supply; }
            set { WritePower_Supply = value; }
        }
        /// <summary>
        ///电池供电时的亮度
        /// </summary>
        private char ReadBatterPower_light;       //    电池供电时的亮度

        public char ReadBatterPower_light1
        {
            get { return ReadBatterPower_light; }
            set { ReadBatterPower_light = value; }
        }
        private char WriteBatterPower_light;       //    电池供电时的亮度

        public char WriteBatterPower_light1
        {
            get { return WriteBatterPower_light; }
            set { WriteBatterPower_light = value; }
        }
        /// <summary>
        ///电源供电时的亮度
        /// </summary>
        private char ReadACPower_light;       //    电源供电时的亮度

        public char ReadACPower_light1
        {
            get { return ReadACPower_light; }
            set { ReadACPower_light = value; }
        }
        private char WriteACPower_light;       //    电源供电时的亮度

        public char WriteACPower_light1
        {
            get { return WriteACPower_light; }
            set { WriteACPower_light = value; }
        }
        /// <summary>
        ///电池供电时的背光Time
        /// </summary>
        private char ReadBacklight_time;       //    电池供电时的背光Time

        public char ReadBacklight_time1
        {
            get { return ReadBacklight_time; }
            set { ReadBacklight_time = value; }
        }
        private char WriteBacklight_time;       //    电池供电时的背光Time

        public char WriteBacklight_time1
        {
            get { return WriteBacklight_time; }
            set { WriteBacklight_time = value; }
        }
        /// <summary>
        ///电源供电时的屏保Time 
        /// </summary>
        private char ReadBatterPower_ScreenSave;    //    电源供电时的屏保Time 

        public char ReadBatterPower_ScreenSave1
        {
            get { return ReadBatterPower_ScreenSave; }
            set { ReadBatterPower_ScreenSave = value; }
        }
        private char WriteBatterPower_ScreenSave;    //    电源供电时的屏保Time 

        public char WriteBatterPower_ScreenSave1
        {
            get { return WriteBatterPower_ScreenSave; }
            set { WriteBatterPower_ScreenSave = value; }
        }
        /// <summary>
        ///电池供电时的屏幕亮度 
        /// </summary>
        private char ReadBattBacklight_time;    //    电池供电时的屏幕亮度

        public char ReadBattBacklight_time1
        {
            get { return ReadBattBacklight_time; }
            set { ReadBattBacklight_time = value; }
        }
        private char WriteBattBacklight_time;    //    电池供电时的屏幕亮度

        public char WriteBattBacklight_time1
        {
            get { return WriteBattBacklight_time; }
            set { WriteBattBacklight_time = value; }
        }
       // struct TouchManage_Param                     // ------ (3) 触控管理的参数
       //{
       // unsigned short     CurrScreen_light   ;       //     当前屏幕的亮度           -- 2
       // unsigned char      Touch_Sound       ;        //     触摸屏的点击声音         -- 1           
       //} ;
        /// <summary>
        ///当前屏幕的亮度 
        /// </summary>
        private char ReadCurrScreen_light;       //     当前屏幕的亮度

        public char ReadCurrScreen_light1
        {
            get { return ReadCurrScreen_light; }
            set { ReadCurrScreen_light = value; }
        }
        private char WriteCurrScreen_light;       //     当前屏幕的亮度

        public char WriteCurrScreen_light1
        {
            get { return WriteCurrScreen_light; }
            set { WriteCurrScreen_light = value; }
        }
        /// <summary>
        ///触摸屏的点击声音
        /// </summary>
        private char ReadTouch_Sound;        //     触摸屏的点击声音

        public char ReadTouch_Sound1
        {
            get { return ReadTouch_Sound; }
            set { ReadTouch_Sound = value; }
        }
        private char WriteTouch_Sound;        //     触摸屏的点击声音

        public char WriteTouch_Sound1
        {
            get { return WriteTouch_Sound; }
            set { WriteTouch_Sound = value; }
        }

        #endregion
        #region 历史数据
        /// <summary>
        /// 历史Testing Args
        /// </summary>
      //  struct TTest_Param               // ------ 107
      // {
      // unsigned char      Test_type;               // Testing mode      -- 1                    
      // unsigned char      Test_Psernum[16];        // product_batch_NO      -- 16 
      // unsigned char      Test_Tsernum[16];        // Testingnum      -- 16   
      // unsigned char      Test_Fsernum[16];        // Filter Serial Number     --  16
      // unsigned char      Test_filt[16];           // Filter Material Type     --  16
      // unsigned char      Test_LIQU[15];           // Testing Liquid      -- 15
      // unsigned char      Test_Dt[5];              // Date/Time     -- 5
      // unsigned char      Test_LIQUType;           // Testing Liquid种类  -- 1
      // unsigned int       Test_LIQUConsistence;    // Testing Liquid浓度  -- 2
      // unsigned char      Test_Filter_type;        // 测量用过滤器的种类  筒式/平板/囊式/Other  -- 1  
      // unsigned short     Test_Filter_Config;      // 过滤材料的规格（或平板滤器的直径） （2.5",5“，10”，20“，30”, 40"） -- 4
      // unsigned char      Test_Filter_numer;       // Testing过滤器滤芯的数量           -- 1 
      // unsigned int       Test_Filter_Area  ;      // Filter Area
      // unsigned short     Test_Meme_Aper;          // 过滤材料的Aperture（精度） 如:0。22um       -- 2
      // unsigned short     Test_Velocity ;          // 基本泡点Test Mode / Water Immersion 的test_time  -- 2
      // unsigned int       Test_Up_Volm;            // 滤芯的Upstream Volume                           -- 4 
      // unsigned short     Test_startp ;            // Start Pressure（ 滤芯的DF检测时的Pressure ）   -- 2
      // unsigned short     Test_setBp  ;            // Min. BP                                 -- 2 
      // unsigned short     Test_Dif_max  ;          // Max. DF                               -- 2

      //};
        /// <summary>
        ///Testing mode
        /// </summary>
        private string ReadTest_type;               // Testing mode

        public string ReadTest_type1
        {
            get { return ReadTest_type; }
            set { ReadTest_type = value; }
        }
        private string WriteTest_type;               // Testing mode

        public string  WriteTest_type1
        {
            get { return WriteTest_type; }
            set { WriteTest_type = value; }
        }
        /// <summary>
        ///product_batch_NO
        /// </summary>
        private string ReadTest_Psernum;        // product_batch_NO

        public string ReadTest_Psernum1
        {
            get { return ReadTest_Psernum; }
            set { ReadTest_Psernum = value; }
        }
        private string WriteTest_Psernum;        // product_batch_NO

        public string WriteTest_Psernum1
        {
            get { return WriteTest_Psernum; }
            set { WriteTest_Psernum = value; }
        }
        /// <summary>
        ///Testingnum
        /// </summary>
        private string ReadTest_Tsernum;        // Testingnum

        public string ReadTest_Tsernum1
        {
            get { return ReadTest_Tsernum; }
            set { ReadTest_Tsernum = value; }
        }
        private string WriteTest_Tsernum;        // Testingnum

        public string WriteTest_Tsernum1
        {
            get { return WriteTest_Tsernum; }
            set { WriteTest_Tsernum = value; }
        }
        /// <summary>
        ///Filter Material Type
        /// </summary>
        private string ReadTest_filt;           // Filter Material Type

        public string ReadTest_filt1
        {
            get { return ReadTest_filt; }
            set { ReadTest_filt = value; }
        }
        private string WriteTest_filt;           // Filter Material Type

        public string WriteTest_filt1
        {
            get { return WriteTest_filt; }
            set { WriteTest_filt = value; }
        }
        /// <summary>
        ///Testing Liquid
        /// </summary>
        private string ReadTest_LIQU;           // Testing Liquid

        public string ReadTest_LIQU1
        {
            get { return ReadTest_LIQU; }
            set { ReadTest_LIQU = value; }
        }
        private string WriteTest_LIQU;           // Testing Liquid

        public string WriteTest_LIQU1
        {
            get { return WriteTest_LIQU; }
            set { WriteTest_LIQU = value; }
        }
        /// <summary>
        ///Testing Liquid种类
        /// </summary>
        private char ReadTest_LIQUType;           // Testing Liquid种类

        public char ReadTest_LIQUType1
        {
            get { return ReadTest_LIQUType; }
            set { ReadTest_LIQUType = value; }
        }
        private char WriteTest_LIQUType;           // Testing Liquid种类

        public char WriteTest_LIQUType1
        {
            get { return WriteTest_LIQUType; }
            set { WriteTest_LIQUType = value; }
        }
        /// <summary>
        ///Testing Liquid浓度
        /// </summary>
        private int ReadTest_LIQUConsistence;    // Testing Liquid浓度

        public int ReadTest_LIQUConsistence1
        {
            get { return ReadTest_LIQUConsistence; }
            set { ReadTest_LIQUConsistence = value; }
        }
        private int WriteTest_LIQUConsistence;    // Testing Liquid浓度

        public int WriteTest_LIQUConsistence1
        {
            get { return WriteTest_LIQUConsistence; }
            set { WriteTest_LIQUConsistence = value; }
        }
        /// <summary>
        ///测量用过滤器的种类  筒式/平板/囊式/Other
        /// </summary>
        private char ReadTest_Filter_type;        // 测量用过滤器的种类  筒式/平板/囊式/Other

        public char ReadTest_Filter_type1
        {
            get { return ReadTest_Filter_type; }
            set { ReadTest_Filter_type = value; }
        }
        private char WriteTest_Filter_type;        // 测量用过滤器的种类  筒式/平板/囊式/Other

        public char WriteTest_Filter_type1
        {
            get { return WriteTest_Filter_type; }
            set { WriteTest_Filter_type = value; }
        }
        /// <summary>
        ///过滤材料的规格（或平板滤器的直径）
        /// </summary>
        private int ReadTest_Filter_Config;      // 过滤材料的规格（或平板滤器的直径） 

        public int ReadTest_Filter_Config1
        {
            get { return ReadTest_Filter_Config; }
            set { ReadTest_Filter_Config = value; }
        }
        private int WriteTest_Filter_Config;      // 过滤材料的规格（或平板滤器的直径）

        public int WriteTest_Filter_Config1
        {
            get { return WriteTest_Filter_Config; }
            set { WriteTest_Filter_Config = value; }
        }
        /// <summary>
        ///Testing过滤器滤芯的数量
        /// </summary>
        private char ReadTest_Filter_numer;       // Testing过滤器滤芯的数量

        public char ReadTest_Filter_numer1
        {
            get { return ReadTest_Filter_numer; }
            set { ReadTest_Filter_numer = value; }
        }
        private char WriteTest_Filter_numer;       // Testing过滤器滤芯的数量

        public char WriteTest_Filter_numer1
        {
            get { return WriteTest_Filter_numer; }
            set { WriteTest_Filter_numer = value; }
        }
        /// <summary>
        ///Filter Area
        /// </summary>
        private int ReadTest_Filter_Area;      // Filter Area

        public int ReadTest_Filter_Area1
        {
            get { return ReadTest_Filter_Area; }
            set { ReadTest_Filter_Area = value; }
        }
        private int WriteTest_Filter_Area;      // Filter Area

        public int WriteTest_Filter_Area1
        {
            get { return WriteTest_Filter_Area; }
            set { WriteTest_Filter_Area = value; }
        }
        /// <summary>
        /// 过滤材料的Aperture（精度） 如:0.22um
        /// </summary>
        private int ReadTest_Meme_Aper;          // 过滤材料的Aperture（精度） 如:0.22um

        public int ReadTest_Meme_Aper1
        {
            get { return ReadTest_Meme_Aper; }
            set { ReadTest_Meme_Aper = value; }
        }
        private int WriteTest_Meme_Aper;          // 过滤材料的Aperture（精度） 如:0。22um

        public int WriteTest_Meme_Aper1
        {
            get { return WriteTest_Meme_Aper; }
            set { WriteTest_Meme_Aper = value; }
        }
        /// <summary>
        ///基本泡点Test Mode / Water Immersion 的test_time
        /// </summary>
        private int ReadTest_Velocity;          // 基本泡点Test Mode / Water Immersion 的test_time

        public int ReadTest_Velocity1
        {
            get { return ReadTest_Velocity; }
            set { ReadTest_Velocity = value; }
        }
        private int WriteTest_Velocity;          // 基本泡点Test Mode / Water Immersion 的test_time

        public int WriteTest_Velocity1
        {
            get { return WriteTest_Velocity; }
            set { WriteTest_Velocity = value; }
        }
        /// <summary>
        ///滤芯的Upstream Volume 
        /// </summary>
        private int ReadTest_Up_Volm;            // 滤芯的Upstream Volume 

        public int ReadTest_Up_Volm1
        {
            get { return ReadTest_Up_Volm; }
            set { ReadTest_Up_Volm = value; }
        }
        private int WriteTest_Up_Volm;            // 滤芯的Upstream Volume 

        public int WriteTest_Up_Volm1
        {
            get { return WriteTest_Up_Volm; }
            set { WriteTest_Up_Volm = value; }
        }
        /// <summary>
        ///Start Pressure（ 滤芯的DF检测时的Pressure ）
        /// </summary>
        private int ReadTest_startp;            // Start Pressure（ 滤芯的DF检测时的Pressure ）

        public int ReadTest_startp1
        {
            get { return ReadTest_startp; }
            set { ReadTest_startp = value; }
        }
        private int WriteTest_startp;            // Start Pressure（ 滤芯的DF检测时的Pressure ）

        public int WriteTest_startp1
        {
            get { return WriteTest_startp; }
            set { WriteTest_startp = value; }
        }
        /// <summary>
        ///Min. BP
        /// </summary>
        private int ReadTest_setBp;            // Min. BP

        public int ReadTest_setBp1
        {
            get { return ReadTest_setBp; }
            set { ReadTest_setBp = value; }
        }
        private int WriteTest_setBp;            // Min. BP

        public int WriteTest_setBp1
        {
            get { return WriteTest_setBp; }
            set { WriteTest_setBp = value; }
        }
        /// <summary>
        ///Max. DF
        /// </summary>
        private int ReadTest_Dif_max;          // Max. DF

        public int ReadTest_Dif_max1
        {
            get { return ReadTest_Dif_max; }
            set { ReadTest_Dif_max = value; }
        }
        private int WriteTest_Dif_max;          // Max. DF

        public int WriteTest_Dif_max1
        {
            get { return WriteTest_Dif_max; }
            set { WriteTest_Dif_max = value; }
        }

    //    //-----------------------------------------------------------------
    //  struct THistory_Data_Head
    // {
    //   struct TTest_Param  Htest_Para  ;             // Historical Records的Testing Args
    //   unsigned char       Htest_Name[32];           // Tester名
    //   unsigned int        Htest_DifValue ;          // Testing值1 （DF量）     
    //   unsigned int        Htest_TestValue ;         // Testing值2 （泡点值）  
    //   unsigned char       Htest_BP_Result;          // Result
    //   unsigned char       Htest_DIF_Result;         // Result 
    //   unsigned char       Htest_ALL_Result;         // Result 
    //   unsigned char       Htest_DiffePress ;        // Testing的Pressure差     Pressure Scale Fall ；（自检Testing，Pressure衰减）   
    //   unsigned char       Htest_testimes;           // 判断次数
    //};
        /// <summary>
        ///Tester名
        /// </summary>
        private string ReadHtest_Name;           // Tester名

        public string ReadHtest_Name1
        {
            get { return ReadHtest_Name; }
            set { ReadHtest_Name = value; }
        }
        private string WriteHtest_Name;           // Tester名

        public string WriteHtest_Name1
        {
            get { return WriteHtest_Name; }
            set { WriteHtest_Name = value; }
        }
        /// <summary>
        ///Testing值1 （DF量）
        /// </summary>
        private int ReadHtest_DifValue;          // Testing值1 （DF量）

        public int ReadHtest_DifValue1
        {
            get { return ReadHtest_DifValue; }
            set { ReadHtest_DifValue = value; }
        }
        private int WriteHtest_DifValue;          // Testing值1 （DF量）

        public int WriteHtest_DifValue1
        {
            get { return WriteHtest_DifValue; }
            set { WriteHtest_DifValue = value; }
        }
        /// <summary>
        ///Testing值2 （泡点值）
        /// </summary>
        private int ReadHtest_TestValue;         // Testing值2 （泡点值）

        public int ReadHtest_TestValue1
        {
            get { return ReadHtest_TestValue; }
            set { ReadHtest_TestValue = value; }
        }
        private int WriteHtest_TestValue;         // Testing值2 （泡点值）

        public int WriteHtest_TestValue1
        {
            get { return WriteHtest_TestValue; }
            set { WriteHtest_TestValue = value; }
        }
        /// <summary>
        ///Result
        /// </summary>
        private int ReadHtestResult;          // Result

        public int ReadHtestResult1
        {
            get { return ReadHtestResult; }
            set { ReadHtestResult = value; }
        }
        private int WriteHtestResult;          // Result

        public int WriteHtestResult1
        {
            get { return WriteHtestResult; }
            set { WriteHtestResult = value; }
        }
        /// <summary>
        ///Testing的Pressure差     Pressure Scale Fall ；（自检Testing，Pressure衰减） 
        /// </summary>
        private int ReadHtest_DiffePress;        // Testing的Pressure差     Pressure Scale Fall ；（自检Testing，Pressure衰减） 

        public int ReadHtest_DiffePress1
        {
            get { return ReadHtest_DiffePress; }
            set { ReadHtest_DiffePress = value; }
        }
        private int WriteHtest_DiffePress;        // Testing的Pressure差     Pressure Scale Fall ；（自检Testing，Pressure衰减） 

        public int WriteHtest_DiffePress1
        {
            get { return WriteHtest_DiffePress; }
            set { WriteHtest_DiffePress = value; }
        }
        private int ReadHtest_testimes;           // 判断次数

        public int ReadHtest_testimes1
        {
            get { return ReadHtest_testimes; }
            set { ReadHtest_testimes = value; }
        }
        private int WriteHtest_testimes;           // 判断次数

        public int WriteHtest_testimes1
        {
            get { return WriteHtest_testimes; }
            set { WriteHtest_testimes = value; }
        }
        #endregion

    }
}
