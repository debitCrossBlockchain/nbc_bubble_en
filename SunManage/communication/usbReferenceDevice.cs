//-----------------------------------------------------------------------------
//
//  usbReferenceDevice.cs
//
//  USB Generic HID Communications 3_0_0_0
//
//  A reference test application for the usbGenericHidCommunications library
//  Copyright (C) 2011 Simon Inns
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
//  Web:    http://www.waitingforfriday.com
//  Email:  simon.inns@gmail.com
//
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Collections;
using ADOX;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data;
using SunManage.AllCheck;

// The following namespace allows debugging output (when compiled in debug mode)
using System.Diagnostics;
namespace SunManage.communication
{
    using usbGenericHidCommunications;

    /// <summary>
    /// This class performs several different tests against the 
    /// reference hardware/firmware to confirm that the USB
    /// communication library is functioning correctly.
    /// 
    /// It also serves as a demonstration of how to use the class
    /// library to perform different types of read and write
    /// operations.
    /// </summary>
  partial  class usbReferenceDevice : usbGenericHidCommunication
    {
        /// <summary>
        /// Class constructor - place any initialisation here
        /// </summary>
        /// <param name="vid"></param>
        /// <param name="pid"></param>
        //static Queue<byte[]> serialRead = new Queue<byte[]>();
        //SerialPort _serialPort;
        Thread _readThread;
        volatile bool _keepReading;
        Thread _dealRead;
        volatile bool _keepDeal;
        Thread _dealReadA;
        static int mHistory = 1;
       //usbReferenceDevice theReferenceUsbDevice = new usbReferenceDevice(USB.vid, USB.pid);
        //begin Singleton pattern
       //static readonly usbReferenceDevice instance = new usbReferenceDevice();
        public int count;
        int mK = 0;
        int mKN = 0;
        private static int mflag = 0;//增加记录的标志位查看数据库是否存在这条记录
        private static int mflagC = 0;//增加记录的标志位查看数据库是否存在这条记录
        /// <summary>
        /// 数据库操作
        /// </summary>
        //private OleDbConnection mConnectionDeviceConcatenateParameter;
        //string sAccessConnectionDeviceConcatenateParameter = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\DeviceConcatenate.mdb";
        private OleDbConnection mConnection;
        string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\TestHistoryData.mdb";
        public static ArrayList MCurrent = new ArrayList();
        public void init()
        {

            _readThread = null;
            _keepReading = false;
            _dealRead = null;
            _keepDeal = false;
        }

        public static int mDeviceAddress;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        //static CommPort()
        //{
        //}

       
        /// <summary>
        /// Pressure的当前值
        /// </summary>
        public Int32 DeviceID;
        public Int32 CurrentState;
        public string CurrentType;
        public Int32 CurrentPress;
         public void usbReferenceDeviceC(Int32 mDeviceID, Int32 mCurrentState, string mCurrentType, Int32 mCurrentPress)
       {
           DeviceID = mDeviceID;
           CurrentState = mCurrentState;
           CurrentType = mCurrentType;
           CurrentPress = mCurrentPress;
           
       }
       /// <summary>
       /// Test result

       /// </summary>
       public static ArrayList MResult = new ArrayList();

       

       public string Test_type;
       public string Htest_Name;
       public Int32 Htest_DifValue;
       public Int32 Htest_TestValue;
       public Int32 Htest_DiffePress;
       public string  Htest_BP_Result;
       public string Htest_DIF_Result;
       public string Htest_ALL_Result;
       public Int32 Htest_testimes;

       //public void usbReferenceDeviceR(string mTest_type, string mHtest_Name, Int32 mHtest_DifValue, Int32 mHtest_TestValue, Int32 mHtest_DiffePress, string mHtest_BP_Result, string mHtest_DIF_Result, string mHtest_ALL_Result, Int32 mHtest_testimes)
       //{
       //    Test_type = mTest_type;
       //    Htest_Name = mHtest_Name;
       //    Htest_DifValue = mHtest_DifValue;
       //    Htest_TestValue = mHtest_TestValue;
       //    Htest_DiffePress = mHtest_DiffePress;
       //    Htest_BP_Result = mHtest_BP_Result;
       //    Htest_DIF_Result = mHtest_DIF_Result;
       //    Htest_ALL_Result = mHtest_ALL_Result;
       //    Htest_testimes = mHtest_testimes;


       //}
        public usbReferenceDevice(int vid, int pid)
            : base(vid, pid)
        {
            //_serialPort = new SerialPort();

           // InitializeComponent();
        }

       /// <summary>
        /// Historical Records
        /// </summary>
        /// <summary>
        /// Historical Records参数
        /// </summary>
        private static ArrayList mHistoryRecordP = new ArrayList();

public static ArrayList MHistoryRecordP
{
  get { return usbReferenceDevice.mHistoryRecordP; }
  set { usbReferenceDevice.mHistoryRecordP = value; }
}

        //public static ArrayList MHistoryRecordP
        //{
        //    get { return CommPort.mHistoryRecordP; }
        //    set { CommPort.mHistoryRecordP = value; }
        //}

        /// </summary>
        /// <summary>
        /// Historical RecordsChart
        /// </summary>
        private static ArrayList mHistoryRecordC = new ArrayList();

public static ArrayList MHistoryRecordC
{
  get { return usbReferenceDevice.mHistoryRecordC; }
  set { usbReferenceDevice.mHistoryRecordC = value; }
}

       
        public void usbReferenceDeviceH(string mRecordTheSerialNumber, string mTest_type, string mTest_Psernum, string mTest_Tsernum, string mTest_Fsernum, string mTest_filt, string mTest_LIQU, string mTest_Dt, string mTest_LIQUType, string mTest_LIQUConsistence, string mTest_Filter_type, string mTest_Filter_Config, string mTest_Filter_numer, string mTest_Filter_Area, string mTest_Meme_Aper, string mTest_Velocity, string mTest_Up_Volm, string mTest_startp, string mTest_setBp, string mTest_Dif_max, string mHtest_Name, string mHtest_DifValue, string mHtest_TestValue, string mHtest_BP_Result, string mHtest_DIF_Result, string mHtest_ALL_Result, string mHtest_DiffePress)
        {   //         （0） RecordTheSerialNumber          -------    'NO.'   -- 2;

            RecordTheSerialNumber = mRecordTheSerialNumber;

            //         （1） Test_type          -------    ‘Test Mode’ (M/B/A/P/D/H)    -- 1;
            HTest_type = mTest_type;



            //（2） Test_Psernum[16]   -------   'Production batch.'       -- 16     ;
            Test_Psernum = mTest_Psernum;


            //（3） Test_Tsernum[16]   -------   产品编号       -- 16     ;
            HTest_Tsernum = mTest_Tsernum;


            //（4） Test_Fsernum [16]   -------  滤器'NO.'       -- 16     ;
            Test_Fsernum = mTest_Fsernum;



            //（5） Test_filt[16]        -------  Filter Material Type       -- 16     ;
            Test_filt = mTest_filt;



            //（6）Test_LIQU[15]       -------  Testing Liquid       -- 15    ;
            Test_LIQU = mTest_LIQU;



            //（7）Test_Dt[5]           -------  Date/Time       -- 5    ;
            Test_Dt = mTest_Dt;



            //（8）Test_LIQUType      -------  Testing Liquid种类    -- 1    ;
            Test_LIQUType = mTest_LIQUType;




            //（9）Test_LIQUConsistence -------  Testing Liquid浓度    -- 2    ;
            Test_LIQUConsistence = mTest_LIQUConsistence;



            //（10）Test_Filter_type ------- 测量用过滤器的种类(筒式/平板/囊式/Other) -- 1 ;
            Test_Filter_type = mTest_Filter_type;



            //（11）Test_Filter_Config  ------- 过滤材料的规格（或平板滤器的Diameter）  -- 4 ;
            Test_Filter_Config = mTest_Filter_Config;



            //（12）Test_Filter_numer  -------  Testing过滤器滤芯的Amount        -- 1 ;
            Test_Filter_numer = mTest_Filter_numer;



            //（13）Test_Filter_Area   -------  Aperture           -- 2    ;
            Test_Filter_Area = mTest_Filter_Area;



            //（14）Test_Meme_Aper  -------  过滤材料的Filter Area（精度）      -- 2  ;
            Test_Meme_Aper = mTest_Meme_Aper;



            //（15）Test_Velocity  ------- 基本泡点Test Mode / Water浸入的'Test Time'  -- 2 ;
            Test_Velocity = mTest_Velocity;



            //（16）Test_Up_Volm  ------- 滤芯的Upstream Volume  -- 4 ;
            Test_Up_Volm = mTest_Up_Volm;



            //（17）Test_startp   -------  Start Pressure（ 滤芯的DF检测时的Pressure ） -- 2 ;
            Test_startp = mTest_startp;


            //（18）Test_setBp   -------   Min. BP     -- 2 ;
            Test_setBp = mTest_setBp;


            //（19）Test_Dif_max   -------   Max. DF   -- 2  ；

            Test_Dif_max = mTest_Dif_max;


            //    （20）Htest_Name    -------   Tester员名   -- 16 ；
            HHtest_Name = mHtest_Name;



            //    （21）Htest_DifValue    -------   Testing值1 （DF量）-- 2  ；
            HHtest_DifValue = mHtest_DifValue;



            //    （22）Htest_TestValue    -------   Testing值2 （泡点值）-- 2  ；
            HHtest_TestValue = mHtest_TestValue;


            //    （23）Htest_BP_Result    -------   Test result-- 1 ;

            HHtest_BP_Result = mHtest_BP_Result;


            //    （24）Htest_DIF_Result   -------   Test result -- 1 ;
            HHtest_DIF_Result = mHtest_DIF_Result;



            //    （25）Htest_ALL_Result  -------   Test result-- 1 ;
            HHtest_ALL_Result = mHtest_ALL_Result;



            //    （26）Htest_DiffePress ------ Testing的Pressure Scale Fall ；（自检Testing，Pressure衰减）-- 2；
            HHtest_DiffePress = mHtest_DiffePress;

        }

        public void usbReferenceDeviceHC(string mRecordTheSerialNumber, string mHtest_testimes, string mp0, string mp1, string mp2, string mp3, string mp4, string mp5, string mp6, string mp7, string mp8, string mp9, string mp10, string mp11, string mp12, string mp13, string mp14, string mp15, string mp16, string mp17, string mp18, string mp19, string mp20, string mp21, string mp22, string mp23, string mp24, string mp25, string mp26, string mp27, string mp28, string mp29, string mp30, string mp31, string mp32, string mp33, string mp34, string mp35, string mp36, string mp37, string mp38, string mp39, string mp40, string mp41, string mp42, string mp43, string mp44, string mp45, string mp46, string mp47, string mp48, string mp49)
        {
            //         （0） RecordTheSerialNumber          -------    'NO.'   -- 2;

            RecordTheSerialNumberC = mRecordTheSerialNumber;

            //    （27）Htest_testimes  -------   Chart的采样次数  -- 1 ;
            HHtest_testimes = mHtest_testimes;

            ///// <summary>
            ///// Historical RecordsChart
            ///// </summary>
            p0 = mp0;
            p1 = mp1;
            p2 = mp2;
            p3 = mp3;
            p4 = mp4;
            p5 = mp5;
            p6 = mp6;
            p7 = mp7;
            p8 = mp8;
            p9 = mp9;
            p10 = mp10;
            p11 = mp11;
            p12 = mp12;
            p13 = mp13;
            p14 = mp14;
            p15 = mp15;
            p16 = mp16;
            p17 = mp17;
            p18 = mp18;
            p19 = mp19;
            p20 = mp20;
            p21 = mp21;
            p22 = mp22;
            p23 = mp23;
            p24 = mp24;
            p25 = mp25;
            p26 = mp26;
            p27 = mp27;
            p28 = mp28;
            p29 = mp29;
            p30 = mp30;
            p31 = mp31;
            p32 = mp32;
            p33 = mp33;
            p34 = mp34;
            p35 = mp35;
            p36 = mp36;
            p37 = mp37;
            p38 = mp38;
            p39 = mp39;
            p40 = mp40;
            p41 = mp41;
            p42 = mp42;
            p43 = mp43;
            p44 = mp44;
            p45 = mp45;
            p46 = mp46;
            p47 = mp47;
            p48 = mp48;
            p49 = mp49;

        }
        /// <summary>Send data to the serial port after appending line ending. </summary>
        /// <param name="data">An string containing the data to send. </param>

        /// <summary> Get the data and pass it on. </summary>
        /// 
        private List<byte> readBuffer = new List<byte>(94096);
        private void ReadPort()
        {


            while (_keepReading)
            {
                //_readThread.Priority = ThreadPriority.AboveNormal;
                Thread.Sleep(30);
                if (isDeviceAttached)
                {
                //    int n = _serialPort.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间Time长，缓存不一致  
                    
                    try
                    {
                        byte[] Buffer = new byte[65*5]; //声明一个临时数组存储当前来的串口数据      
                        // If there are bytes available on the serial port,
                        // Read returns up to "count" bytes, but will not block (wait)
                        // for the remaining bytes. If there are no bytes available
                        // on the serial port, Read will block until at least one byte
                        // is available on the port, up until the ReadTimeout milliseconds
                        // have elapsed, at which time a TimeoutException will be thrown.
                        //Thread.Sleep(20);
                       readMultipleReportsFromDevice(ref Buffer, 5);
                        if (_keepDeal == false)
                        {
                            readBuffer.AddRange(Buffer);
                        }
                        if (_keepDeal != false)
                        {
                            lock (_dealRead)
                            {
                                readBuffer.AddRange(Buffer);
                            }
                        }
                        //_serialPort.DiscardInBuffer();
                        if (readBuffer.Count >= 5)
                        {
                            StartDealReading();
                            //_dealRead.Priority = ThreadPriority.BelowNormal;
                        }
                    }

                    catch (TimeoutException) { }
                }

                else
                {
                    TimeSpan waitTime = new TimeSpan(0, 0, 0, 0, 50);
                    Thread.Sleep(waitTime);
                }
            }

        }
        //end Observer pattern
        /// <summary>
        /// 分析数据包的完整性
        /// </summary>
        public void AnalysisPackage()
        {

            try
            {

                Int64 mSumReadBuffer = 0x00;
                if (readBuffer.Count >= 5)
                {
                    mKN = 0;

                    while ((mKN < readBuffer.Count - 1) && (readBuffer[mKN] != 0xFF))
                    {

                        mKN++;
                    }
                    readBuffer.RemoveRange(0, mKN);
                    mKN = 0;

                    if ((readBuffer[mKN] == 0xFF) && (readBuffer.Count > 0))
                    {
                        if (readBuffer.Count - mKN >= 5)//DeviceAddress = readBuffer[1];//用于各个界面进行比较
                        {
                            int len = readBuffer[mKN + 2];
                            //while (readBuffer.Count - mKN >= len)
                            //{
                            if (readBuffer.Count - mKN >= len)//DeviceAddress = readBuffer[1];//用于各个界面进行比较
                            {
                                for (int i = mKN; i < len + mKN - 1; i++)
                                {
                                    mSumReadBuffer = mSumReadBuffer + readBuffer[i];
                                }
                                mSumReadBuffer = mSumReadBuffer & 0xFF;


                                if (readBuffer[len + mK - 1] == mSumReadBuffer)
                                {
                                    byte[] mBuf = new byte[len];
                                    readBuffer.CopyTo(mKN, mBuf, 0, len);


                                    _dealReadA = new Thread(delegate()
                                    {
                                        DealRead(mBuf);
                                    });
                                    _dealReadA.Start();
                                    readBuffer.RemoveRange(mKN, len);

                                }
                                else
                                {
                                    int mkk = 0;
                                    while ((mkk + 1 < readBuffer.Count - 1) && (readBuffer[mkk + 1] != 0xFF))
                                    {
                                        mkk++;

                                    }
                                    readBuffer.RemoveRange(0, mkk + 1);

                                }
                            }
                        }
                    }
                }

            }
            catch (TimeoutException) { }
        }
        public void DealRead(byte[] readBuffer)
        {
            try
            {
                mK = 0;
                //SearchDeviceAddress();//查询设备地址
                while ((mK < readBuffer.Length - 1) && (readBuffer[mK] != 0xFF))
                {
                    mK++;
                }

                switch (readBuffer[mK + 3])
                {
                    case 0x03:
                        {
                            string mCurrentType = "";
                            switch (readBuffer[mK + 4])
                            {
                                case 0x4d:
                                    {
                                        mCurrentType = "Manual Bubble Point";
                                    }
                                    break;
                                case 0x42:
                                    {
                                        mCurrentType = "Basic Bubble Point";
                                    }
                                    break;
                                case 0x41:
                                    {
                                        mCurrentType = "Extensive Bubble Point";
                                    }
                                    break;
                                case 0x50:
                                    {
                                        mCurrentType = "Pressure Holding";
                                    }
                                    break;
                                case 0x44:
                                    {
                                        mCurrentType = "Diffusion Flow";
                                    }
                                    break;
                                case 0x48:
                                    {
                                        mCurrentType = "Water Immersion ";
                                    }
                                    break;
                                default: break;
                            }
                            Int32 mDeviceID = readBuffer[mK + 1];
                            Int32 mCurrentState = readBuffer[mK + 7];

                            Int32 mCurrentPress = (((byte)readBuffer[mK + 5]) << 8) + readBuffer[mK + 6];
                            //if (readBuffer[4] == 0x52)
                            //{
                            CommPort mCommPort = new CommPort(mDeviceID, mCurrentState, mCurrentType, mCurrentPress);
                            MCurrent.Add(mCommPort);
                            //}
                        }
                        break;
                    case 0x04:
                        {
                            //（1） Test_type          -------    ‘Test Mode’ (M/B/A/P/D/H)    -- 1;
                            //（2） Htest_Name[32]     -------   Tester员名       --  32     ;
                            //（3） Htest_DifValue      -------   Testing值1 （DF量）   --  2     ;
                            //（4） Htest_TestValue      -------   Testing值2 （泡点值）    --  2     ;
                            //（5） Htest_DiffePress    -------    Testing的Pressure差       --  2     ;
                            //（6） Htest_BP_Result     -------   Test result--  2     ;
                            //（7） Htest_DIF_Result    -------   Test result --  2     ;
                            //（8） Htest_ALL_Result    -------   Test result --  2     ;
                            //（9） Htest_testimes        ------   Chart的采样次数   --  1    ;
                            switch (readBuffer[mK + 3])
                            {
                                case 0x4D:
                                    {
                                        Test_type = "Manual Bubble Point";
                                    }
                                    break;
                                case 0x42:
                                    {
                                        Test_type = "Basic Bubble Point";
                                    }
                                    break;
                                case 0x41:
                                    {
                                        Test_type = "Extensive Bubble Point";
                                    }
                                    break;
                                case 0x50:
                                    {
                                        Test_type = "Pressure Holding";
                                    }
                                    break;
                                case 0x44:
                                    {
                                        Test_type = "Diffusion Flow";
                                    }
                                    break;
                                case 0x48:
                                    {
                                        Test_type = "Water Immersion ";
                                    }
                                    break;
                                default: break;
                            }

                            Htest_Name = "";
                            for (int i = mK + 4; i < mK + 36; i++)
                            {
                                Htest_Name = Htest_Name + readBuffer[i];
                            }
                            Htest_DifValue = readBuffer[mK + 36] << 8 + readBuffer[mK + 37];
                            Htest_TestValue = readBuffer[mK + 38] << 8 + readBuffer[mK + 39];
                            Htest_DiffePress = readBuffer[mK + 40] << 8 + readBuffer[mK + 41];

                            switch (readBuffer[mK + 42])
                            {
                                case 0x47:
                                    {
                                        Htest_BP_Result = "By Detecting";
                                    }
                                    break;
                                case 0x55:
                                    {
                                        Htest_BP_Result = "Did Not By Detecting";
                                    }
                                    break;

                                default: break;
                            }
                            switch (readBuffer[mK + 43])
                            {
                                case 0x47:
                                    {
                                        Htest_DIF_Result = "By Detecting";
                                    }
                                    break;
                                case 0x55:
                                    {
                                        Htest_DIF_Result = "Did Not By Detecting";
                                    }
                                    break;

                                default: break;
                            }
                            switch (readBuffer[mK + 44])
                            {
                                case 0x47:
                                    {
                                        Htest_ALL_Result = "By Detecting";
                                    }
                                    break;
                                case 0x55:
                                    {
                                        Htest_ALL_Result = "Did Not By Detecting";
                                    }
                                    break;

                                default: break;
                            }

                            Htest_testimes = readBuffer[mK + 45];
                            CommPort mCommPortResult = new CommPort(Test_type, Htest_Name, Htest_DifValue, Htest_TestValue, Htest_DiffePress, Htest_BP_Result, Htest_DIF_Result, Htest_ALL_Result, Htest_testimes);
                            MResult.Add(mCommPortResult);
                        }
                        break;
                    case 0x05:
                        {
                            //         5. 读取系统参数set:
                            //   返回字符串:
                            //（1） PES_Dif_max     -------   单芯10“PES滤芯的Max. DF--  2;
                            //（2） PVDF_Dif_max   -------   单芯10“PVDF滤芯的Max. DF--  2;
                            //（3）PTFE_Dif_max ------- 单芯10“聚四氟乙烯滤芯的Max. DF --  2;
                            //（4） NYLON_Dif_max  ------- 单芯10“尼龙滤芯的Max. DF --  2 ;
                            //（5） OTHER_Dif_max ------- 单芯10“OTHER_Dif_max（空气过滤--Water浸入法）滤芯的最大流量 --  2 ;
                            //（6） Exter_Volm    -----   外部缓冲罐的体积        ---  4  ;
                            //（7） SourceP       -----   外部的气源Pressure          --   2     ;
                            //（8） AddP_extent   -----   对滤芯的Pressure增幅        --   2     ;
                            //（9） Print_setup    -----   打印set                -- 1   ;
                            //（10）Over_Modesetup ----- Testing结束的方式  (手动/自动)   -- 1 ;
                            //（11）Language_setup  ----- 语言set                -- 1
                            //（12）Default_Load    ----- 缺省值得Load            -- 1
                            //（13）InitTestPara      ----- 初始化Testing Args          -- 1

                            //（1） PES_Dif_max     -------   单芯10“PES滤芯的Max. DF--  2;
                            string SPES_Dif_max = (((readBuffer[mK + 4] << 8) & 0xff00) + (readBuffer[mK + 5] & 0x00ff)).ToString();


                            PES_Dif_max = "";
                            for (int i = mK; i < mK + SPES_Dif_max.Length - 1; i++)
                            {
                                if (Char.IsNumber(SPES_Dif_max, i) == true)
                                {
                                    PES_Dif_max = PES_Dif_max + SPES_Dif_max.Substring(i, 1);
                                }
                            }
                            if (Char.IsNumber(SPES_Dif_max, SPES_Dif_max.Length - 1) == true)
                            {
                                PES_Dif_max = PES_Dif_max + "." + SPES_Dif_max[SPES_Dif_max.Length - 1];
                            }

                            //（2） PVDF_Dif_max   -------   单芯10“PVDF滤芯的Max. DF--  2; 
                            string SPVDF_Dif_max = (((readBuffer[mK + 6] << 8) & 0xff00) + (readBuffer[mK + 7] & 0x00ff)).ToString();
                            PVDF_Dif_max = "";
                            for (int i = 0; i < SPVDF_Dif_max.Length - 1; i++)
                            {
                                if (Char.IsNumber(SPVDF_Dif_max, i) == true)
                                {
                                    PVDF_Dif_max = PVDF_Dif_max + SPVDF_Dif_max.Substring(i, 1);
                                }
                            }
                            if (Char.IsNumber(SPVDF_Dif_max, SPVDF_Dif_max.Length - 1) == true)
                            {
                                PVDF_Dif_max = PVDF_Dif_max + "." + SPVDF_Dif_max[SPVDF_Dif_max.Length - 1];
                            }

                            //（3）PTFE_Dif_max ------- 单芯10“聚四氟乙烯滤芯的Max. DF --  2;
                            string SPTFE_Dif_max = (((readBuffer[mK + 8] << 8) & 0xff00) + (readBuffer[mK + 9] & 0x00ff)).ToString();
                            PTFE_Dif_max = "";
                            for (int i = mK; i < mK + SPTFE_Dif_max.Length - 1; i++)
                            {
                                if (Char.IsNumber(SPTFE_Dif_max, i) == true)
                                {
                                    PTFE_Dif_max = PTFE_Dif_max + SPTFE_Dif_max.Substring(i, 1);
                                }
                            }
                            if (Char.IsNumber(SPTFE_Dif_max, SPTFE_Dif_max.Length - 1) == true)
                            {
                                PTFE_Dif_max = PTFE_Dif_max + "." + SPTFE_Dif_max[SPTFE_Dif_max.Length - 1];
                            }
                            //（4） NYLON_Dif_max  ------- 单芯10“尼龙滤芯的Max. DF --  2 ;

                            string SNYLON_Dif_max = (((readBuffer[mK + 10] << 8) & 0xff00) + (readBuffer[mK + 11] & 0x00ff)).ToString();
                            NYLON_Dif_max = "";
                            for (int i = 0; i < SNYLON_Dif_max.Length - 1; i++)
                            {
                                if (Char.IsNumber(SNYLON_Dif_max, i) == true)
                                {
                                    NYLON_Dif_max = NYLON_Dif_max + SNYLON_Dif_max.Substring(i, 1);
                                }
                            }
                            if (Char.IsNumber(SNYLON_Dif_max, SNYLON_Dif_max.Length - 1) == true)
                            {
                                NYLON_Dif_max = NYLON_Dif_max + "." + SNYLON_Dif_max[SNYLON_Dif_max.Length - 1];
                            }
                            //（5） OTHER_Dif_max ------- 单芯10“OTHER_Dif_max（空气过滤--Water浸入法）滤芯的最大流量 --  2 ;
                            string SOTHER_Dif_max = (((readBuffer[mK + 12] << 8) & 0xff00) + (readBuffer[mK + 13] & 0x00ff)).ToString();
                            OTHER_Dif_max = "";
                            for (int i = mK; i < mK + SOTHER_Dif_max.Length - 2; i++)
                            {
                                if (Char.IsNumber(SOTHER_Dif_max, i) == true)
                                {
                                    OTHER_Dif_max = OTHER_Dif_max + SOTHER_Dif_max.Substring(i, 1);
                                }
                            }
                            if (Char.IsNumber(SOTHER_Dif_max, SOTHER_Dif_max.Length - 1) == true)
                            {
                                if (OTHER_Dif_max.Length > 0)
                                {

                                    OTHER_Dif_max = OTHER_Dif_max + "." + SOTHER_Dif_max[SOTHER_Dif_max.Length - 2] + SOTHER_Dif_max[SOTHER_Dif_max.Length - 1];
                                }
                                else
                                {
                                    OTHER_Dif_max = "0." + SOTHER_Dif_max[SOTHER_Dif_max.Length - 2] + SOTHER_Dif_max[SOTHER_Dif_max.Length - 1];
                                }
                            }

                            //（6） Exter_Volm    -----   外部缓冲罐的体积        ---  4  ;
                            Exter_Volm = ((readBuffer[mK + 14] << 24) + (readBuffer[mK + 15] << 16) + (readBuffer[mK + 16] << 8) + readBuffer[mK + 17]).ToString();
                            //（7） SourceP       -----   外部的气源Pressure          --   2     ;
                            SourceP = (((readBuffer[mK + 18] << 8) & 0xff00) + (readBuffer[mK + 19] & 0x00ff)).ToString();
                            //（8） AddP_extent   -----   对滤芯的Pressure增幅        --   2     ;
                            AddP_extent = (((readBuffer[mK + 20] << 8) & 0xff00) + (readBuffer[mK + 21] & 0x00ff)).ToString();
                            //（9） Print_setup    -----   打印set                -- 1   ;
                            Print_setup = readBuffer[mK + 22].ToString();
                            //（10）Over_Modesetup ----- Testing结束的方式  (手动/自动)   -- 1 ;
                            Over_Modesetup = readBuffer[mK + 23].ToString();
                            //（11）Language_setup  ----- 语言set                -- 1
                            Language_setup = readBuffer[mK + 24].ToString();
                            //（12）Default_Load    ----- 缺省值得Load            -- 1
                            Default_Load = readBuffer[mK + 25].ToString();
                            //（13）InitTestPara      ----- 初始化Testing Args          -- 1
                            InitTestPara = readBuffer[mK + 26].ToString();
                        }
                        break;
                    case 0x07:
                        {
                            //（1） Test_type          -------    ‘Test Mode’ (M/B/A/P/D/H)    -- 1;
                            //（2） Test_Psernum[16]   -------   'Production batch.'       -- 16     ;
                            //（3） Test_Tsernum[16]   -------   产品编号       -- 16     ;
                            //（4） Test_Fsernum [16]   -------  滤器'NO.'       -- 16     ;
                            //（5） Test_filt[16]        -------  Filter Material Type       -- 16     ;
                            //（6）Test_LIQU[15]       -------  Testing Liquid       -- 15    ;
                            //（7）Test_Dt[5]           -------  Date/Time       -- 5    ;
                            //（8）Test_LIQUType      -------  Testing Liquid种类    -- 1    ;
                            //（9）Test_LIQUConsistence -------  Testing Liquid浓度    -- 2    ;
                            //（10）Test_Filter_type ------- 测量用过滤器的种类(筒式/平板/囊式/Other) -- 1 ;
                            //（11）Test_Filter_Config  ------- 过滤材料的规格（或平板滤器的Diameter）  -- 4 ;
                            //（12）Test_Filter_numer  -------  Testing过滤器滤芯的Amount        -- 1 ;
                            //（13）Test_Filter_Area   -------  Aperture           -- 2    ;
                            //（14）Test_Meme_Aper  -------  过滤材料的Filter Area（精度）      -- 2  ;
                            //（15）Test_Velocity  ------- 基本泡点Test Mode / Water浸入的'Test Time'  -- 2 ;
                            //（16）Test_Up_Volm  ------- 滤芯的Upstream Volume  -- 4 ;
                            //（17）Test_startp   -------  Start Pressure（ 滤芯的DF检测时的Pressure ） -- 2 ;
                            //（18）Test_setBp   -------   Min. BP     -- 2 ;
                            //（19）Test_Dif_max   -------   Max. DF   -- 2  ；
                            //（20）Htest_Name    -------   Tester员名   -- 16 ；
                            //（21）Htest_DifValue    -------   Testing值1 （DF量）-- 2  ；
                            //（22）Htest_TestValue    -------   Testing值2 （泡点值）-- 2  ；
                            //（23）Htest_BP_Result    -------   Test result-- 1 ;
                            //（24）Htest_DIF_Result   -------   Test result-- 1 ;
                            //（25）Htest_ALL_Result  -------   Test result -- 1 ;
                            //（26）Htest_DiffePress ------ Testing的Pressure Scale Fall ；（自检Testing，Pressure衰减）-- 2；
                            //（27）Htest_testimes  -------   Chart的采样次数  -- 1 ;
                            //（28）Hisdata (n)     -------   Historical Records的Chart数据 2 *n ;
                            if (readBuffer[mK + 2] == 0x8F)
                            {
                                string mRecordTheSerialNumber = ((readBuffer[mK + 4] << 8) + readBuffer[mK + 5]).ToString();
                                string mTest_type = "";
                                switch (readBuffer[mK + 6])
                                {
                                    case 0x4d:
                                        {
                                            mTest_type = "Manual Bubble Point";
                                        }
                                        break;
                                    case 0x42:
                                        {
                                            mTest_type = "Basic Bubble Point";
                                        }
                                        break;
                                    case 0x41:
                                        {
                                            mTest_type = "Extensive Bubble Point";
                                        }
                                        break;
                                    case 0x50:
                                        {
                                            mTest_type = "Pressure Holding";
                                        }
                                        break;
                                    case 0x44:
                                        {
                                            mTest_type = "Diffusion Flow";
                                        }
                                        break;
                                    case 0x48:
                                        {
                                            mTest_type = "Water Immersion ";
                                        }
                                        break;
                                    default: break;
                                }
                                string mTest_Psernum = "";
                                for (int i = mK + 7; i < mK + 23; i++)
                                {
                                    mTest_Psernum = mTest_Psernum + (((char)readBuffer[i]).ToString());
                                }
                                mTest_Psernum = mTest_Psernum.Replace("\0", "");
                                string mTest_Tsernum = "";
                                for (int i = mK + 23; i < mK + 39; i++)
                                {
                                    mTest_Tsernum = mTest_Tsernum + (((char)readBuffer[i]).ToString());
                                }
                                mTest_Tsernum = mTest_Tsernum.Replace("\0", "");
                                string mTest_Fsernum = "";
                                for (int i = mK + 39; i < mK + 55; i++)
                                {
                                    mTest_Fsernum = mTest_Fsernum + (((char)readBuffer[i]).ToString());
                                }
                                mTest_Fsernum = mTest_Fsernum.Replace("\0", "");
                                string mTest_filt = "";
                                for (int i = mK + 55; i < mK + 71; i++)
                                {
                                    mTest_filt = mTest_filt + (((char)readBuffer[i]).ToString());
                                }
                                mTest_filt = mTest_filt.Replace("\0", "");
                                string mTest_LIQU = "";
                                byte[] mLiqu = new byte[15];
                                for (int i = mK + 71; i < mK + 86; i++)
                                {
                                    mLiqu[i - 71] = readBuffer[i];
                                }
                                mTest_LIQU = Encoding.GetEncoding("gb2312").GetString(mLiqu);
                                mTest_LIQU = mTest_LIQU.Replace("\0", "");
                                string mTest_Dt = " " + "20" + readBuffer[mK + 86].ToString("D2") + "-" + readBuffer[mK + 87].ToString("D2") + "-" + readBuffer[mK + 88].ToString("D2") + " " + readBuffer[mK + 89].ToString("D2") + ":" + readBuffer[mK + 90].ToString("D2") + "";
                                string mTest_LIQUType = "";

                                switch (readBuffer[mK + 91])
                                {
                                    case 0x01:
                                        {
                                            mTest_LIQUType = "Water";
                                        }
                                        break;
                                    case 0x02:
                                        {
                                            mTest_LIQUType = "Enthanol";
                                        }
                                        break;
                                    case 0x03:
                                        {
                                            mTest_LIQUType = "l_Alcohol";
                                        }
                                        break;
                                    case 0x04:
                                        {
                                            mTest_LIQUType = "Other";
                                        }
                                        break;
                                    default: break;
                                }
                                string mTest_LIQUConsistence = ((readBuffer[mK + 92] << 8) + readBuffer[mK + 93]).ToString();
                                string mTest_Filter_type = "";
                                switch (readBuffer[mK + 94])
                                {
                                    case 0x01:
                                        {
                                            mTest_Filter_type = "Cartridge";
                                        }
                                        break;
                                    case 0x02:
                                        {
                                            mTest_Filter_type = "Pannel";
                                        }
                                        break;
                                    case 0x03:
                                        {
                                            mTest_Filter_type = "Bag";
                                        }
                                        break;
                                    case 0x04:
                                        {
                                            mTest_Filter_type = "Other";
                                        }
                                        break;
                                    default: break;
                                }
                                string mTest_Filter_Config = "";
                                switch (readBuffer[mK + 94])
                                {
                                    case 0x01:
                                        {
                                            mTest_Filter_Config = ((readBuffer[mK + 95] << 8) + readBuffer[mK + 96]).ToString() + '"'.ToString();
                                        }
                                        break;
                                    case 0x02:
                                        {
                                            mTest_Filter_Config = ((readBuffer[mK + 95] << 8) + readBuffer[mK + 96]).ToString() + "mm";
                                        }
                                        break;

                                    default:
                                        break;
                                }
                                string mTest_Filter_numer = readBuffer[mK + 97].ToString();
                                string mTest_Filter_Area = ((readBuffer[mK + 98] << 24) + (readBuffer[mK + 99] << 16) + (readBuffer[mK + 100] << 8) + readBuffer[mK + 101]).ToString();
                                string mTest_Filter_Area1 = "";
                                switch (mTest_Filter_Area.Length)
                                {
                                    case 0:
                                        {
                                            mTest_Filter_Area1 = "0.0000";
                                        }
                                        break;
                                    case 1:
                                        {
                                            mTest_Filter_Area1 = "0.000" + mTest_Filter_Area;
                                        }
                                        break;
                                    case 2:
                                        {
                                            mTest_Filter_Area1 = "0.00" + mTest_Filter_Area;
                                        }
                                        break;
                                    case 3:
                                        {
                                            mTest_Filter_Area1 = "0.0" + mTest_Filter_Area;
                                        }
                                        break;
                                    case 4:
                                        {
                                            mTest_Filter_Area1 = "0." + mTest_Filter_Area;
                                        }
                                        break;

                                    default:

                                        for (int i = 0; i < mTest_Filter_Area.Length - 4; i++)
                                        {

                                            mTest_Filter_Area1 = mTest_Filter_Area1 + mTest_Filter_Area[i];
                                        }
                                        mTest_Filter_Area1 = mTest_Filter_Area1 + ".";
                                        for (int i = mTest_Filter_Area.Length - 4; i < mTest_Filter_Area.Length; i++)
                                        {

                                            mTest_Filter_Area1 = mTest_Filter_Area1 + mTest_Filter_Area[i];
                                        }
                                        break;

                                }
                                string mTest_Meme_Aper1 = "";
                                string mTest_Meme_Aper = (Convert.ToInt32((readBuffer[mK + 102] << 8) + readBuffer[mK + 103])).ToString();
                                switch (mTest_Meme_Aper.Length)
                                {
                                    case 0:
                                        {
                                            mTest_Meme_Aper1 = "0.00";
                                        }
                                        break;
                                    case 1:
                                        {
                                            mTest_Meme_Aper1 = "0.0" + mTest_Meme_Aper;
                                        }
                                        break;
                                    case 2:
                                        {
                                            mTest_Meme_Aper1 = "0." + mTest_Meme_Aper;
                                        }
                                        break;

                                    default:
                                        {
                                            for (int i = 0; i < mTest_Meme_Aper.Length - 2; i++)
                                            {

                                                mTest_Meme_Aper1 = mTest_Meme_Aper1 + mTest_Meme_Aper[i];
                                            }
                                            mTest_Meme_Aper1 = mTest_Meme_Aper1 + ".";
                                            for (int i = mTest_Meme_Aper.Length - 2; i < mTest_Meme_Aper.Length; i++)
                                            {

                                                mTest_Meme_Aper1 = mTest_Meme_Aper1 + mTest_Meme_Aper[i];
                                            }
                                        }
                                        break;
                                }
                                string mTest_Velocity1 = "";
                                string mTest_Velocity = ((readBuffer[mK + 104] << 8) + readBuffer[mK + 105]).ToString();
                                switch (mTest_Velocity)
                                {
                                    case "0":
                                        {
                                            mTest_Velocity1 = "Normal";
                                        }
                                        break;
                                    case "1":
                                        {
                                            mTest_Velocity1 = "Fast";
                                        }
                                        break;
                                    default:
                                        mTest_Velocity1 = ((readBuffer[mK + 104] << 8) + readBuffer[mK + 105]).ToString();
                                        break;

                                }
                                string mTest_Up_Volm = ((readBuffer[mK + 106] << 24) + (readBuffer[mK + 107] << 16) + (readBuffer[mK + 108] << 8) + readBuffer[mK + 109]).ToString();
                                string mTest_startp = ((readBuffer[mK + 110] << 8) + readBuffer[mK + 111]).ToString();
                                string mTest_setBp = ((readBuffer[mK + 112] << 8) + readBuffer[mK + 113]).ToString();
                                string mTest_Dif_max = ((readBuffer[mK + 114] << 8) + readBuffer[mK + 115]).ToString();
                                string mTest_Dif_max1 = "";
                                switch (mTest_Dif_max.Length)
                                {
                                    case 0:
                                        {
                                            mTest_Dif_max1 = "0.0";
                                        }
                                        break;
                                    case 1:
                                        {
                                            mTest_Dif_max1 = "0." + mTest_Dif_max;
                                        }
                                        break;


                                    default:
                                        {
                                            for (int i = 0; i < mTest_Dif_max.Length - 1; i++)
                                            {

                                                mTest_Dif_max1 = mTest_Dif_max1 + mTest_Dif_max[i];
                                            }

                                            for (int i = mTest_Dif_max.Length - 1; i < mTest_Dif_max.Length; i++)
                                            {

                                                mTest_Dif_max1 = mTest_Dif_max1 + mTest_Dif_max[i];
                                            }
                                            mTest_Dif_max1 = mTest_Dif_max1 + ".0";
                                        }
                                        break;

                                }
                                string mHtest_Name = "";
                                for (int i = mK + 116; i < mK + 132; i++)
                                {
                                    mHtest_Name = mHtest_Name + (((char)readBuffer[i]).ToString());
                                }
                                mHtest_Name = mHtest_Name.Replace("\0", "");
                                string mHtest_DifValue = ((readBuffer[mK + 132] << 8) + readBuffer[mK + 133]).ToString();
                                string mHtest_DifValue1 = "";
                                switch (mHtest_DifValue.Length)
                                {
                                    case 0:
                                        {
                                            mHtest_DifValue1 = "0.0";
                                        }
                                        break;
                                    case 1:
                                        {
                                            mHtest_DifValue1 = "0." + mTest_Dif_max;
                                        }
                                        break;


                                    default:
                                        for (int i = 0; i < mHtest_DifValue.Length - 1; i++)
                                        {

                                            mHtest_DifValue1 = mHtest_DifValue1 + mHtest_DifValue[i];
                                        }
                                        mHtest_DifValue1 = mHtest_DifValue1 + ".";
                                        for (int i = mHtest_DifValue.Length - 1; i < mHtest_DifValue.Length; i++)
                                        {

                                            mHtest_DifValue1 = mHtest_DifValue1 + mHtest_DifValue[i];
                                        }
                                        break;

                                }

                                string mHtest_TestValue = ((readBuffer[mK + 134] << 8) + readBuffer[mK + 135]).ToString();
                                string mHtest_BP_Result = "";

                                switch (readBuffer[mK + 136])
                                {
                                    case 0x47:
                                        {
                                            mHtest_BP_Result = "By Detecting";
                                        }
                                        break;
                                    case 0x55:
                                        {
                                            mHtest_BP_Result = "Did Not By Detecting";
                                        }
                                        break;

                                    default: break;
                                }

                                string mHtest_DIF_Result = "";

                                switch (readBuffer[mK + 137])
                                {
                                    case 0x47:
                                        {
                                            mHtest_DIF_Result = "By Detecting";
                                        }
                                        break;
                                    case 0x55:
                                        {
                                            mHtest_DIF_Result = "Did Not By Detecting";
                                        }
                                        break;

                                    default: break;
                                }

                                string mHtest_ALL_Result = "";

                                switch (readBuffer[mK + 138])
                                {
                                    case 0x47:
                                        {
                                            mHtest_ALL_Result = "By Detecting";
                                        }
                                        break;
                                    case 0x55:
                                        {
                                            mHtest_ALL_Result = "Did Not By Detecting";
                                        }
                                        break;

                                    default: break;
                                }

                                string mHtest_DiffePress = ((readBuffer[mK + 139] << 8) + readBuffer[mK + 140]).ToString();
                                string mHtest_testimes = readBuffer[141].ToString();
                                string mTreeView = Main.MTreeName.ToString();
                                lock (_dealRead)
                                {

                                    if (!string.IsNullOrEmpty(mRecordTheSerialNumber.ToString()))
                                    {
                                        try
                                        {
                                            string m = mRecordTheSerialNumber.ToString();




                                            string mSelectQuery = "Select * From {0} where [TestHisData]= '" + m + "'";

                                            mSelectQuery = string.Format(mSelectQuery, mTreeView);
                                            mConnection = new OleDbConnection(sAccessConnection);


                                            if (mConnection.State != ConnectionState.Open) { mConnection.Open(); }
                                            OleDbCommand cmd = new OleDbCommand(mSelectQuery, mConnection);
                                            object result = cmd.ExecuteScalar();
                                            if (result == null || result is DBNull)
                                            {
                                                mflag = 1;


                                            }
                                            else
                                            {
                                                mflag = 0;

                                            }

                                        }

                                        catch (Exception)
                                        {



                                        }

                                        finally
                                        {

                                            mConnection.Close();

                                        }
                                    }
                                    if (mflag == 1)
                                    {


                                        string mQuery = String.Format("insert into {0}([TestHisData],[Htest_type],[Test_Psernum],[Test_Tsernum],[Test_Fsernum],[Test_filt],[Test_LIQU],[HA_STime],[Test_LIQUType],[Test_LIQUConsistence],[Test_Filter_type],[Test_Filter_Config],[Test_Filter_number],[Test_Filter_Area],[Test_Meme_Aper],[Test_Velocity],[Test_Up_Volm],[Test_startp],[Test_setBp],[Test_Dif_max],[Htest_Name],[Htest_DifValue],[Htest_Value],[Htest_BP_Result],[Htest_DIF_Result],[Test_Result],[Htest_DiffePress],[Test_testimes])" + " values ('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}')", mTreeView, mRecordTheSerialNumber, mTest_type, mTest_Psernum, mTest_Tsernum, mTest_Fsernum, mTest_filt, mTest_LIQU, mTest_Dt, mTest_LIQUType, mTest_LIQUConsistence, mTest_Filter_type, mTest_Filter_Config, mTest_Filter_numer, mTest_Filter_Area1, mTest_Meme_Aper1, mTest_Velocity1, mTest_Up_Volm, mTest_startp, mTest_setBp, mTest_Dif_max1, mHtest_Name, mHtest_DifValue1, mHtest_TestValue, mHtest_BP_Result, mHtest_DIF_Result, mHtest_ALL_Result, mHtest_DiffePress, mHtest_testimes);
                                        //mHistoryRecord.Add(mComHistory);

                                        mQuery = string.Format(mQuery, mTreeView);


                                        mConnection = new OleDbConnection(sAccessConnection);

                                        OleDbCommand da = new OleDbCommand(mQuery, mConnection);

                                        //

                                        try
                                        {
                                            mConnection.Open();
                                            da.ExecuteNonQuery();


                                        }

                                        catch (Exception)
                                        {

                                        }

                                        finally
                                        {
                                            mflag = 0;
                                            mConnection.Close();

                                        }

                                    }
                                }
                            }
                        }
                        break;
                    case 0x4D:
                        {
                            string[] HistoryC = new string[51];
                            for (int i = 0; i < 51; i++)
                            {
                                HistoryC[i] = "";
                            }
                            //HistoryC[0] = readBuffer[mK + 4].ToString();
                            for (int i = 0; (i < (readBuffer[mK + 2] - 5) / 2) && (i < 51); i++)
                            {
                                HistoryC[i] = ((readBuffer[mK + i + 4] << 8) + readBuffer[mK + i + 5]).ToString();
                            }
                            //string mHtest_testimes = HistoryC[0];
                            string mRecordTheSerialNumber = HistoryC[0];
                            ///Historical Records的Chart 
                            string mP0 = HistoryC[1];
                            string mP1 = HistoryC[2];
                            string mP2 = HistoryC[3];
                            string mP3 = HistoryC[4];
                            string mP4 = HistoryC[5];
                            string mP5 = HistoryC[6];
                            string mP6 = HistoryC[7];
                            string mP7 = HistoryC[8];
                            string mP8 = HistoryC[9];
                            string mP9 = HistoryC[10];
                            string mP10 = HistoryC[11];
                            string mP11 = HistoryC[12];
                            string mP12 = HistoryC[13];
                            string mP13 = HistoryC[14];
                            string mP14 = HistoryC[15];
                            string mP15 = HistoryC[16];
                            string mP16 = HistoryC[17];
                            string mP17 = HistoryC[18];
                            string mP18 = HistoryC[19];
                            string mP19 = HistoryC[20];
                            string mP20 = HistoryC[21];
                            string mP21 = HistoryC[22];
                            string mP22 = HistoryC[23];
                            string mP23 = HistoryC[24];
                            string mP24 = HistoryC[25];
                            string mP25 = HistoryC[26];
                            string mP26 = HistoryC[27];
                            string mP27 = HistoryC[28];
                            string mP28 = HistoryC[29];
                            string mP29 = HistoryC[30];
                            string mP30 = HistoryC[31];
                            string mP31 = HistoryC[32];
                            string mP32 = HistoryC[33];
                            string mP33 = HistoryC[34];
                            string mP34 = HistoryC[35];
                            string mP35 = HistoryC[36];
                            string mP36 = HistoryC[37];
                            string mP37 = HistoryC[38];
                            string mP38 = HistoryC[39];
                            string mP39 = HistoryC[40];
                            string mP40 = HistoryC[41];
                            string mP41 = HistoryC[42];
                            string mP42 = HistoryC[43];
                            string mP43 = HistoryC[44];
                            string mP44 = HistoryC[45];
                            string mP45 = HistoryC[46];
                            string mP46 = HistoryC[47];
                            string mP47 = HistoryC[48];
                            string mP48 = HistoryC[49];
                            string mP49 = HistoryC[50];


                            string mTreeView = Main.MTreeName.ToString();

                            lock (_dealRead)
                            {
                                if (!string.IsNullOrEmpty(mRecordTheSerialNumber.ToString()))
                                {
                                    try
                                    {
                                        string m = mRecordTheSerialNumber.ToString();




                                        string mSelectQuery = "Select * From {0} where [TestHisData]= '" + m + "'";

                                        mSelectQuery = string.Format(mSelectQuery, mTreeView);
                                        mConnection = new OleDbConnection(sAccessConnection);


                                        if (mConnection.State != ConnectionState.Open) { mConnection.Open(); }
                                        OleDbCommand cmd = new OleDbCommand(mSelectQuery, mConnection);
                                        object result = cmd.ExecuteScalar();
                                        if (result == null || result is DBNull)
                                        {
                                            mflagC = 0;

                                        }
                                        else
                                        {
                                            mflagC = 1;

                                        }

                                    }

                                    catch (Exception)
                                    {



                                    }

                                    finally
                                    {

                                        mConnection.Close();

                                    }
                                }
                                if (mflagC == 1)
                                {


                                    //string mQuery = String.Format("insert into {0}([TestHisData],[Htest_type],[Test_Psernum],[Test_Tsernum],[Test_Fsernum],[Test_filt],[Test_LIQU],[HA_STime],[Test_LIQUType],[Test_LIQUConsistence],[Test_Filter_type],[Test_Filter_Config],[Test_Filter_number],[Test_Filter_Area],[Test_Meme_Aper],[Test_Velocity],[Test_Up_Volm],[Test_startp],[Test_setBp],[Test_Dif_max],[Htest_Name],[Htest_DifValue],[Htest_Value],[Htest_BP_Result],[Htest_DIF_Result],[Test_Result],[Htest_DiffePress],[Test_testimes],[p0],[p1],[p2],[p3],[p4],[p5],[p6],[p7],[p8],[p9],[p10],[p11],[p12],[p13],[p14],[p15],[p16],[p17],[p18],[p19],[p20],[p21],[p22],[p23],[p24],[p25],[p26],[p27],[p28],[p29],[p30],[p31],[p32],[p33],[p34],[p35],[p36],[p37],[p38],[p39],[p40],[p41],[p42],[p43],[p44],[p45],[p46],[p47],[p48],[p49])" + " values ('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}','{52}','{53}','{54}','{55}','{56}','{57}','{58}','{59}','{60}','{61}','{62}','{63}','{64}','{65}','{66}','{67}','{68}','{69}','{70}','{71}','{72}','{73}','{74}','{75}','{76}','{77}','{78}')", mTreeView, mRecordTheSerialNumber, mTest_type, mTest_Psernum, mTest_Tsernum, mTest_Fsernum, mTest_filt, mTest_LIQU, mTest_Dt, mTest_LIQUType, mTest_LIQUConsistence, mTest_Filter_type, mTest_Filter_Config, mTest_Filter_numer, mTest_Filter_Area1, mTest_Meme_Aper1, mTest_Velocity1, mTest_Up_Volm, mTest_startp, mTest_setBp, mTest_Dif_max1, mHtest_Name, mHtest_DifValue1, mHtest_TestValue, mHtest_BP_Result, mHtest_DIF_Result, mHtest_ALL_Result, mHtest_DiffePress, mHtest_testimes, mP0, mP1, mP2, mP3, mP4, mP5, mP6, mP7, mP8, mP9, mP10, mP11, mP12, mP13, mP14, mP15, mP16, mP17, mP18, mP19, mP20, mP21, mP22, mP23, mP24, mP25, mP26, mP27, mP28, mP29, mP30, mP31, mP32, mP33, mP34, mP35, mP36, mP37, mP38, mP39, mP40, mP41, mP42, mP43, mP44, mP45, mP46, mP47, mP48, mP49);
                                    //mHistoryRecord.Add(mComHistory);
                                    string mQuery = "update {0} set [p0]='" + "{1}" + "',[p1]='" + "{2}" + "',[p2]='" + "{3}" + "',[p3]='" + "{4}" + "',[p4]='" + "{5}" + "',[p5]='" + "{6}" + "',[p6]='" + "{7}" + "',[p7]='" + "{8}" + "',[p8]='" + "{9}" + "',[p9]='" + "{10}" + "',[p10]='" + "{11}" + "',[p11]='" + "{12}" + "',[p12]='" + "{13}" + "',[p13]='" + "{14}" + "',[p14]='" + "{15}" + "',[p15]='" + "{16}" + "',[p16]='" + "{17}" + "',[p17]='" + "{18}" + "',[p18]='" + "{19}" + "',[p19]='" + "{20}" + "',[p20]='" + "{21}" + "',[p21]='" + "{22}" + "',[p22]='" + "{23}" + "',[p23]='" + "{24}" + "',[p24]='" + "{25}" + "',[p25]='" + "{26}" + "',[p26]='" + "{27}" + "',[p27]='" + "{28}" + "',[p28]='" + "{29}" + "',[p29]='" + "{30}" + "',[p30]='" + "{31}" + "',[p31]='" + "{32}" + "',[p32]='" + "{33}" + "',[p33]='" + "{34}" + "',[p34]='" + "{35}" + "',[p35]='" + "{36}" + "',[p36]='" + "{37}" + "',[p37]='" + "{38}" + "',[p38]='" + "{39}" + "',[p39]='" + "{40}" + "',[p40]='" + "{41}" + "',[p41]='" + "{42}" + "',[p42]='" + "{43}" + "',[p43]='" + "{44}" + "',[p44]='" + "{45}" + "',[p45]='" + "{46}" + "',[p46]='" + "{47}" + "',[p47]='" + "{48}" + "',[p48]='" + "{49}" + "',[p49]='" + "{50}" + "' where [TestHisData]='" + mRecordTheSerialNumber.Trim() + "'";


                                    mQuery = string.Format(mQuery, mTreeView, mP0, mP1, mP2, mP3, mP4, mP5, mP6, mP7, mP8, mP9, mP10, mP11, mP12, mP13, mP14, mP15, mP16, mP17, mP18, mP19, mP20, mP21, mP22, mP23, mP24, mP25, mP26, mP27, mP28, mP29, mP30, mP31, mP32, mP33, mP34, mP35, mP36, mP37, mP38, mP39, mP40, mP41, mP42, mP43, mP44, mP45, mP46, mP47, mP48, mP49);



                                    mConnection = new OleDbConnection(sAccessConnection);

                                    OleDbCommand da = new OleDbCommand(mQuery, mConnection);

                                    //

                                    try
                                    {
                                        mConnection.Open();
                                        da.ExecuteNonQuery();


                                    }

                                    catch (Exception)
                                    {

                                    }

                                    finally
                                    {
                                        mflagC = 0;
                                        mConnection.Close();
                                    }

                                }
                            }
                        }
                        break;
                    case 0x08:
                        {
                            if (HistoricalRecords.mHistoricalRecords != null)
                            {
                                mHistory++;
                                if (mHistory <= HistoricalRecords.mHistoricalRecords.dataGridViewHistorical.Rows.Count)
                                {


                                    if (HistoricalRecords.mHistoricalRecords.dataGridViewHistorical.Rows.Count > 0)
                                    {
                                        string Hisdatasum = HistoricalRecords.mHistoricalRecords.dataGridViewHistorical.Rows.Count.ToString("X4");
                                        //for (int n = 1; n <= dataGridViewHistorical.Rows.Count; n++)
                                        //{
                                        string Hisdatacurnum = (1).ToString("X4");
                                        string mTreeView = Main.MTreeName.ToString();

                                        string mQuery = "Select * From {0} where TestHisData='" + HistoricalRecords.mHistoricalRecords.dataGridViewHistorical.Rows[0].Cells[0].Value.ToString() + "'";
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
                                                /// 'NO.'
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
                                                    default:

                                                        Test_type = (0).ToString("X2");

                                                        break;


                                                }


                                                /// <summary>
                                                /// 'Production batch.'
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
                                                /// 滤器'NO.'
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
                                                /// 'Test Time'
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
                                                /// 过滤材料的规格（或平板滤器的Diameter）  -- 2;
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
                                                ///Testing过滤器滤芯的Amount        -- 1 ;
                                                /// </summary>
                                                /// <param name="sender"></param>
                                                /// <param name="e"></param>
                                                string Test_Filter_numer = (0).ToString("X2");
                                                if (!string.IsNullOrEmpty(reader[12].ToString()))
                                                {
                                                    Test_Filter_numer = Convert.ToInt32(reader[12].ToString().Replace("芯", "")).ToString("X2");
                                                }
                                                /// <summary>
                                                ///Test_Filter_Area   -------  Aperture           -- 4    ;
                                                /// </summary>
                                                /// <param name="sender"></param>
                                                /// <param name="e"></param>

                                                string Test_Filter_Area = (0).ToString("X8");
                                                if (!string.IsNullOrEmpty(reader[13].ToString()))
                                                {
                                                    Test_Filter_Area = (Convert.ToInt64(reader[13].ToString().Replace(".", ""))).ToString("X8");
                                                }
                                                /// <summary>
                                                ///Test_Meme_Aper  -------  过滤材料的Filter Area（精度）      -- 2  ;
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
                                                ///Test_Velocity  ------- 基本泡点Test Mode / Water浸入的'Test Time'  -- 2 ;基本泡点分为:0或1  0是Normal 1Fast
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
                                                ///Htest_Name    -------   Tester员名   -- 16 ；
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

                                                    Htest_DifValue = reader[21].ToString().Replace("0.", "");
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
                                                ///Htest_BP_Result    -------   Test result -- 1 ;
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
                                                ///Htest_DIF_Result   -------   Test result -- 1 ;
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
                                                ///Htest_ALL_Result  -------   Test result -- 1 ;
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
                                                    usbReferenceDevice theReferenceUsbDevice = new usbReferenceDevice(USB.vid, USB.pid);
                                                    sendData[sendData.Length - 1] = (byte)(sum % 256);
                                                    theReferenceUsbDevice.Send(sendData);
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
                                else
                                {
                                    mHistory = 1;
                                }
                            }

                        }
                        break;
                    default: break;

                }
            }
            catch (TimeoutException) { }

        }
           
                
           
        public void StartReading()
        {
            if (!_keepReading)
            {
                _keepReading = true;
                _readThread = new Thread(ReadPort);
                _readThread.Start();
            }
        }

        public void StopReading()
        {
            if (_keepReading)
            {
                _keepReading = false;
                _readThread.Join();	//block until exits
                _readThread = null;
            }
        }

        private void StartDealReading()
        {


            if (!_keepDeal)
            {
                _keepReading = true;
                _dealRead = new Thread(AnalysisPackage);
                _dealRead.Start();
            }
        }

        private void StopDealReading()
        {
            if (_keepDeal)
            {
                _keepDeal = false;
                _dealRead.Join();	//block until exits
                _dealRead = null;
            }
        }
        public void Send(byte[] data)
        {
            try
            {
                writeRawReportToDevice(data);
            }
            catch (Exception)
            { }


           
        }
       
        /// <summary>
        /// 将字符串转换为字节
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public byte[] convertstringtobyte(string txt)
        {
            MatchCollection mc = Regex.Matches(txt, @"(?i)[\da-f]{2}");
            List<byte> list = new List<byte>();//填充到这个临时列表中
            //依次添加到列表中
            foreach (Match m in mc)
            {
                list.Add(byte.Parse(m.Value, System.Globalization.NumberStyles.HexNumber));
            }
            byte[] byteBuffer = new byte[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                byteBuffer[i] = (byte)list[i];
            }
            return byteBuffer;
        }
       #region 字段
        #region 启动Testing Args
        /// <summary>
        ///设备地址
        /// </summary>
        private int DeviceAddress;

        public int DeviceAddress1
        {
            get { return DeviceAddress; }
            set { DeviceAddress = value; }
        }

        /// <summary>
        /// 'Test Type'
        /// </summary>
        private string StartTest_type;

        public string StartTest_type1
        {
            get { return StartTest_type; }
            set { StartTest_type = value; }
        }
        /// <summary>
        /// 'Production batch.'
        /// </summary>
        private string StartTest_Psernum;

        public string StartTest_Psernum1
        {
            get { return StartTest_Psernum; }
            set { StartTest_Psernum = value; }
        }
        /// <summary>
        /// Testing'NO.'
        /// </summary>
        private string StartTest_Num;

        public string StartTest_Num1
        {
            get { return StartTest_Num; }
            set { StartTest_Num = value; }
        }
        /// <summary>
        /// 滤器'NO.'
        /// </summary>
        private string StartTest_Fsernum;

        public string StartTest_Fsernum1
        {
            get { return StartTest_Fsernum; }
            set { StartTest_Fsernum = value; }
        }
        /// <summary>
        /// Filter Material Type 
        /// </summary>
        private string StartTest_filt;

        public string StartTest_filt1
        {
            get { return StartTest_filt; }
            set { StartTest_filt = value; }
        }
        /// <summary>
        /// Testing Liquid
        /// </summary>
        private string StartTest_LIQU;

        public string StartTest_LIQU1
        {
            get { return StartTest_LIQU; }
            set { StartTest_LIQU = value; }
        }
        /// <summary>
        /// Date/Time
        /// </summary>
        private string StartTest_Dt;

        public string StartTest_Dt1
        {
            get { return StartTest_Dt; }
            set { StartTest_Dt = value; }
        }
        /// <summary>
        /// Testing Liquid种类 
        /// </summary>
        private string StartTest_LIQUType;

        public string StartTest_LIQUType1
        {
            get { return StartTest_LIQUType; }
            set { StartTest_LIQUType = value; }
        }
        /// <summary>
        /// Testing Liquid浓度
        /// </summary>
        private string StartTest_LIQUConsistence;

        public string StartTest_LIQUConsistence1
        {
            get { return StartTest_LIQUConsistence; }
            set { StartTest_LIQUConsistence = value; }
        }
        /// <summary>
        /// 测量用过滤器的种类(筒式/平板/囊式/Other)
        /// </summary>
        private string StartTest_Filter_type;

        public string StartTest_Filter_type1
        {
            get { return StartTest_Filter_type; }
            set { StartTest_Filter_type = value; }
        }
        /// <summary>
        /// 过滤材料的规格（或平板滤器的Diameter）
        /// </summary>
        private string StartTest_Filter_Config;

        public string StartTest_Filter_Config1
        {
            get { return StartTest_Filter_Config; }
            set { StartTest_Filter_Config = value; }
        }
        /// <summary>
        /// Testing过滤器滤芯的Amount
        /// </summary>
        private string StartTest_Filter_numer;

        public string StartTest_Filter_numer1
        {
            get { return StartTest_Filter_numer; }
            set { StartTest_Filter_numer = value; }
        }
        /// <summary>
        /// Aperture         
        /// </summary>
        private string StartTest_Filter_Area;

        public string StartTest_Filter_Area1
        {
            get { return StartTest_Filter_Area; }
            set { StartTest_Filter_Area = value; }
        }
        /// <summary>
        /// 过滤材料的Filter Area（精度）
        /// </summary>
        private string StartTest_Meme_Aper;

        public string StartTest_Meme_Aper1
        {
            get { return StartTest_Meme_Aper; }
            set { StartTest_Meme_Aper = value; }
        }
        /// <summary>
        /// 基本泡点Test Mode / Water Immersion 的'Test Time' 
        /// </summary>
        private string StartTest_Velocity;

        public string StartTest_Velocity1
        {
            get { return StartTest_Velocity; }
            set { StartTest_Velocity = value; }
        }
        /// <summary>
        /// 滤芯的Upstream Volume
        /// </summary>
        private string StartTest_Up_Volm;

        public string StartTest_Up_Volm1
        {
            get { return StartTest_Up_Volm; }
            set { StartTest_Up_Volm = value; }
        }
        /// <summary>
        /// Start Pressure（ 滤芯的DF检测时的Pressure ）
        /// </summary>
        private string StartTest_startp;

        public string StartTest_startp1
        {
            get { return StartTest_startp; }
            set { StartTest_startp = value; }
        }
        /// <summary>
        ///  Min. BP 
        /// </summary>
        private string StartTest_setBp;

        public string StartTest_setBp1
        {
            get { return StartTest_setBp; }
            set { StartTest_setBp = value; }
        }
        /// <summary>
        /// Max. DF
        /// </summary>
        private string StartTest_Dif_max;

        public string StartTest_Dif_max1
        {
            get { return StartTest_Dif_max; }
            set { StartTest_Dif_max = value; }
        }
        #endregion
        #region 读取当前系统State
        private string StateTest_type;

        public string StateTest_type1
        {
            get { return StateTest_type; }
            set { StateTest_type = value; }
        }
        private string Test_press;

        public string Test_press1
        {
            get { return Test_press; }
            set { Test_press = value; }
        }
        #endregion
        #region 系统参数表
//         5. 读取系统参数set:
//   返回字符串:
//（1） PES_Dif_max     -------   单芯10“PES滤芯的Max. DF--  2;
//（2） PVDF_Dif_max   -------   单芯10“PVDF滤芯的Max. DF--  2;
//（3）PTFE_Dif_max ------- 单芯10“聚四氟乙烯滤芯的Max. DF --  2;
//（4） NYLON_Dif_max  ------- 单芯10“尼龙滤芯的Max. DF --  2;
//（5）  OTHER_Dif_max ------- 单芯10“ OTHER_Dif_max（空气过滤--Water浸入法）滤芯的最大流量 --  2 ;
//（6） Exter_Volm    -----   外部缓冲罐的体积        ---  4  ;
//（7） SourceP       -----   外部的气源Pressure          --   2     ;
//（8） AddP_extent   -----   对滤芯的Pressure增幅        --   2     ;
//（9） Print_setup    -----   打印set                -- 1   ;
//（10）Over_Modesetup ----- Testing结束的方式  (手动/自动)   -- 1 ;
//（11）Language_setup  ----- 语言set                -- 1
//（12）Default_Load    ----- 缺省值得Load            -- 1
//（13）InitTestPara      ----- 初始化Testing Args          -- 1

        private string PES_Dif_max; // PES_Dif_max     -------   单芯10“PES滤芯的Max. DF--  2;

        public string PES_Dif_max1
        {
            get { return PES_Dif_max; }
            set { PES_Dif_max = value; }
        }

        private string PVDF_Dif_max;//PVDF_Dif_max   -------   单芯10“PVDF滤芯的Max. DF--  2;

        public string PVDF_Dif_max1
        {
            get { return PVDF_Dif_max; }
            set { PVDF_Dif_max = value; }
        }

        private string PTFE_Dif_max;//PTFE_Dif_max ------- 单芯10“聚四氟乙烯滤芯的Max. DF --  2;

        public string PTFE_Dif_max1
        {
            get { return PTFE_Dif_max; }
            set { PTFE_Dif_max = value; }
        }

        private string NYLON_Dif_max;//单芯10“尼龙滤芯的Max. DF --  2 ;

        public string NYLON_Dif_max1
        {
            get { return NYLON_Dif_max; }
            set { NYLON_Dif_max = value; }
        }

        private string OTHER_Dif_max;//单芯10“ OTHER_Dif_max（空气过滤--Water浸入法）滤芯的最大流量 --  2 ;

        public string OTHER_Dif_max1
        {
            get { return OTHER_Dif_max; }
            set { OTHER_Dif_max = value; }
        }

        

        private string Exter_Volm; //外部缓冲罐的体积        ---  4  ;

        public string Exter_Volm1
        {
            get { return Exter_Volm; }
            set { Exter_Volm = value; }
        }


        private string SourceP;//外部的气源Pressure          --   2     ;

        public string SourceP1
        {
            get { return SourceP; }
            set { SourceP = value; }
        }

        private string AddP_extent;//对滤芯的Pressure增幅        --   2     ;

        public string AddP_extent1
        {
            get { return AddP_extent; }
            set { AddP_extent = value; }
        }

        private string Print_setup;//打印set                -- 1   ;

        public string Print_setup1
        {
            get { return Print_setup; }
            set { Print_setup = value; }
        }

        private string Over_Modesetup;//Testing结束的方式  (手动/自动)   -- 1 ;

        public string Over_Modesetup1
        {
            get { return Over_Modesetup; }
            set { Over_Modesetup = value; }
        }

        private string Language_setup;//语言set                -- 1

        public string Language_setup1
        {
            get { return Language_setup; }
            set { Language_setup = value; }
        }

        private string Default_Load;//缺省值得Load            -- 1

        public string Default_Load1
        {
            get { return Default_Load; }
            set { Default_Load = value; }
        }

        private string InitTestPara;//初始化Testing Args          -- 1

        public string InitTestPara1
        {
            get { return InitTestPara; }
            set { InitTestPara = value; }
        }

        #endregion
       #region 历史数据
        //         （1） Test_type          -------    ‘Test Mode’ (M/B/A/P/D/H)    -- 1;
        //（2） Test_Psernum[16]   -------   'Production batch.'       -- 16     ;
        //（3） Test_Tsernum[16]   -------   产品编号       -- 16     ;
        //（4） Test_Fsernum [16]   -------  滤器'NO.'       -- 16     ;
        //（5） Test_filt[16]        -------  Filter Material Type       -- 16     ;
        //（6）Test_LIQU[15]       -------  Testing Liquid       -- 15    ;
        //（7）Test_Dt[5]           -------  Date/Time       -- 5    ;
        //（8）Test_LIQUType      -------  Testing Liquid种类    -- 1    ;
        //（9）Test_LIQUConsistence -------  Testing Liquid浓度    -- 2    ;
        //（10）Test_Filter_type ------- 测量用过滤器的种类(筒式/平板/囊式/Other) -- 1 ;
        //（11）Test_Filter_Config  ------- 过滤材料的规格（或平板滤器的Diameter）  -- 4 ;
        //（12）Test_Filter_numer  -------  Testing过滤器滤芯的Amount        -- 1 ;
        //（13）Test_Filter_Area   -------  Aperture           -- 2    ;
        //（14）Test_Meme_Aper  -------  过滤材料的Filter Area（精度）      -- 2  ;
        //（15）Test_Velocity  ------- 基本泡点Test Mode / Water浸入的'Test Time'  -- 2 ;
        //（16）Test_Up_Volm  ------- 滤芯的Upstream Volume  -- 4 ;
        //（17）Test_startp   -------  Start Pressure（ 滤芯的DF检测时的Pressure ） -- 2 ;
        //（18）Test_setBp   -------   Min. BP     -- 2 ;
        //（19）Test_Dif_max   -------   Max. DF   -- 2  ；
        //    （20）Htest_Name    -------   Tester员名   -- 16 ；
        //    （21）Htest_DifValue    -------   Testing值1 （DF量）-- 2  ；
        //    （22）Htest_TestValue    -------   Testing值2 （泡点值）-- 2  ；
        //    （23）Htest_BP_Result    -------   Test result-- 1 ;
        //    （24）Htest_DIF_Result   -------   Test result-- 1 ;
        //    （25）Htest_ALL_Result  -------   Test result -- 1 ;
        //    （26）Htest_DiffePress ------ Testing的Pressure Scale Fall ；（自检Testing，Pressure衰减）-- 2；
        //    （27）Htest_testimes  -------   Chart的采样次数  -- 1 ;
        //（28）Hisdata (n)     -------   Historical Records的Chart数据 2 *n ;

        //         （0） RecordTheSerialNumber         -------    'NO.'    -- 2;
        private string RecordTheSerialNumber = "";

        public string RecordTheSerialNumber1
        {
            get { return RecordTheSerialNumber; }
            set { RecordTheSerialNumber = value; }
        }

        private string RecordTheSerialNumberC = "";

        public string RecordTheSerialNumberC1
        {
            get { return RecordTheSerialNumberC; }
            set { RecordTheSerialNumberC = value; }
        }

        //         （1） Test_type          -------    ‘Test Mode’ (M/B/A/P/D/H)    -- 1;
        private string HTest_type = "";

        public string HTest_type1
        {
            get { return HTest_type; }
            set { HTest_type = value; }
        }

        //（2） Test_Psernum[16]   -------   'Production batch.'       -- 16     ;
        private string Test_Psernum = "";

        public string Test_Psernum1
        {
            get { return Test_Psernum; }
            set { Test_Psernum = value; }
        }

        //（3） Test_Tsernum[16]   -------   产品编号       -- 16     ;
        private string HTest_Tsernum = "";

        public string HTest_Tsernum1
        {
            get { return HTest_Tsernum; }
            set { HTest_Tsernum = value; }
        }

        //（4） Test_Fsernum [16]   -------  滤器'NO.'       -- 16     ;
        private string Test_Fsernum = "";

        public string Test_Fsernum1
        {
            get { return Test_Fsernum; }
            set { Test_Fsernum = value; }
        }

        //（5） Test_filt[16]        -------  Filter Material Type       -- 16     ;
        private string Test_filt = "";

        public string Test_filt1
        {
            get { return Test_filt; }
            set { Test_filt = value; }
        }

        //（6）Test_LIQU[15]       -------  Testing Liquid       -- 15    ;
        private string Test_LIQU = "";

        public string Test_LIQU1
        {
            get { return Test_LIQU; }
            set { Test_LIQU = value; }
        }

        //（7）Test_Dt[5]           -------  Date/Time       -- 5    ;
        private string Test_Dt = "";

        public string Test_Dt1
        {
            get { return Test_Dt; }
            set { Test_Dt = value; }
        }

        //（8）Test_LIQUType      -------  Testing Liquid种类    -- 1    ;
        private string Test_LIQUType = "";

        public string Test_LIQUType1
        {
            get { return Test_LIQUType; }
            set { Test_LIQUType = value; }
        }


        //（9）Test_LIQUConsistence -------  Testing Liquid浓度    -- 2    ;

        private string Test_LIQUConsistence = "";

        public string Test_LIQUConsistence1
        {
            get { return Test_LIQUConsistence; }
            set { Test_LIQUConsistence = value; }
        }



        //（10）Test_Filter_type ------- 测量用过滤器的种类(筒式/平板/囊式/Other) -- 1 ;
        private string Test_Filter_type = "";

        public string Test_Filter_type1
        {
            get { return Test_Filter_type; }
            set { Test_Filter_type = value; }
        }

        //（11）Test_Filter_Config  ------- 过滤材料的规格（或平板滤器的Diameter）  -- 4 ;
        private string Test_Filter_Config = "";

        public string Test_Filter_Config1
        {
            get { return Test_Filter_Config; }
            set { Test_Filter_Config = value; }
        }

        //（12）Test_Filter_numer  -------  Testing过滤器滤芯的Amount        -- 1 ;
        private string Test_Filter_numer = "";

        public string Test_Filter_numer1
        {
            get { return Test_Filter_numer; }
            set { Test_Filter_numer = value; }
        }

        //（13）Test_Filter_Area   -------  Aperture           -- 2    ;
        private string Test_Filter_Area = "";

        public string Test_Filter_Area1
        {
            get { return Test_Filter_Area; }
            set { Test_Filter_Area = value; }
        }

        //（14）Test_Meme_Aper  -------  过滤材料的Filter Area（精度）      -- 2  ;
        private string Test_Meme_Aper = "";

        public string Test_Meme_Aper1
        {
            get { return Test_Meme_Aper; }
            set { Test_Meme_Aper = value; }
        }

        //（15）Test_Velocity  ------- 基本泡点Test Mode / Water浸入的'Test Time'  -- 2 ;
        private string Test_Velocity = "";

        public string Test_Velocity1
        {
            get { return Test_Velocity; }
            set { Test_Velocity = value; }
        }

        //（16）Test_Up_Volm  ------- 滤芯的Upstream Volume  -- 4 ;
        private string Test_Up_Volm = "";

        public string Test_Up_Volm1
        {
            get { return Test_Up_Volm; }
            set { Test_Up_Volm = value; }
        }

        //（17）Test_startp   -------  Start Pressure（ 滤芯的DF检测时的Pressure ） -- 2 ;
        private string Test_startp = "";

        public string Test_startp1
        {
            get { return Test_startp; }
            set { Test_startp = value; }
        }

        //（18）Test_setBp   -------   Min. BP     -- 2 ;
        private string Test_setBp = "";

        public string Test_setBp1
        {
            get { return Test_setBp; }
            set { Test_setBp = value; }
        }

        //（19）Test_Dif_max   -------   Max. DF   -- 2  ；

        private string Test_Dif_max = "";

        public string Test_Dif_max1
        {
            get { return Test_Dif_max; }
            set { Test_Dif_max = value; }
        }

        //    （20）Htest_Name    -------   Tester员名   -- 16 ；
        private string HHtest_Name = "";

        public string HHtest_Name1
        {
            get { return HHtest_Name; }
            set { HHtest_Name = value; }
        }

        //    （21）Htest_DifValue    -------   Testing值1 （DF量）-- 2  ；
        private string HHtest_DifValue = "";

        public string HHtest_DifValue1
        {
            get { return HHtest_DifValue; }
            set { HHtest_DifValue = value; }
        }

        //    （22）Htest_TestValue    -------   Testing值2 （泡点值）-- 2  ；
        private string HHtest_TestValue = "";

        public string HHtest_TestValue1
        {
            get { return HHtest_TestValue; }
            set { HHtest_TestValue = value; }
        }
        //    （23）Htest_BP_Result    -------   Test result-- 1 ;

        private string HHtest_BP_Result = "";

        public string HHtest_BP_Result1
        {
            get { return HHtest_BP_Result; }
            set { HHtest_BP_Result = value; }
        }
        //    （24）Htest_DIF_Result   -------   Test result-- 1 ;
        private string HHtest_DIF_Result = "";

        public string HHtest_DIF_Result1
        {
            get { return HHtest_DIF_Result; }
            set { HHtest_DIF_Result = value; }
        }

        //    （25）Htest_ALL_Result  -------   Test result -- 1 ;
        private string HHtest_ALL_Result = "";

        public string HHtest_ALL_Result1
        {
            get { return HHtest_ALL_Result; }
            set { HHtest_ALL_Result = value; }
        }

        //    （26）Htest_DiffePress ------ Testing的Pressure Scale Fall ；（自检Testing，Pressure衰减）-- 2；
        private string HHtest_DiffePress = "";

        public string HHtest_DiffePress1
        {
            get { return HHtest_DiffePress; }
            set { HHtest_DiffePress = value; }
        }

        //    （27）Htest_testimes  -------   Chart的采样次数  -- 1 ;
        private string HHtest_testimes = "";

        public string HHtest_testimes1
        {
            get { return HHtest_testimes; }
            set { HHtest_testimes = value; }
        }

        //（28）Hisdata (n)     -------   Historical Records的Chart数据 2 *n ;
        private string p0 = "";

        public string P0
        {
            get { return p0; }
            set { p0 = value; }
        }
        private string p1 = "";

        public string P1
        {
            get { return p1; }
            set { p1 = value; }
        }
        private string p2 = "";

        public string P2
        {
            get { return p2; }
            set { p2 = value; }
        }
        private string p3 = "";

        public string P3
        {
            get { return p3; }
            set { p3 = value; }
        }
        private string p4 = "";

        public string P4
        {
            get { return p4; }
            set { p4 = value; }
        }
        private string p5 = "";

        public string P5
        {
            get { return p5; }
            set { p5 = value; }
        }
        private string p6 = "";

        public string P6
        {
            get { return p6; }
            set { p6 = value; }
        }
        private string p7 = "";

        public string P7
        {
            get { return p7; }
            set { p7 = value; }
        }
        private string p8 = "";

        public string P8
        {
            get { return p8; }
            set { p8 = value; }
        }
        private string p9 = "";

        public string P9
        {
            get { return p9; }
            set { p9 = value; }
        }
        private string p10 = "";

        public string P10
        {
            get { return p10; }
            set { p10 = value; }
        }
        private string p11 = "";

        public string P11
        {
            get { return p11; }
            set { p11 = value; }
        }
        private string p12 = "";

        public string P12
        {
            get { return p12; }
            set { p12 = value; }
        }
        private string p13 = "";

        public string P13
        {
            get { return p13; }
            set { p13 = value; }
        }
        private string p14 = "";

        public string P14
        {
            get { return p14; }
            set { p14 = value; }
        }
        private string p15 = "";

        public string P15
        {
            get { return p15; }
            set { p15 = value; }
        }
        private string p16 = "";

        public string P16
        {
            get { return p16; }
            set { p16 = value; }
        }
        private string p17 = "";

        public string P17
        {
            get { return p17; }
            set { p17 = value; }
        }
        private string p18 = "";

        public string P18
        {
            get { return p18; }
            set { p18 = value; }
        }
        private string p19 = "";

        public string P19
        {
            get { return p19; }
            set { p19 = value; }
        }
        private string p20 = "";

        public string P20
        {
            get { return p20; }
            set { p20 = value; }
        }
        private string p21 = "";

        public string P21
        {
            get { return p21; }
            set { p21 = value; }
        }
        private string p22 = "";

        public string P22
        {
            get { return p22; }
            set { p22 = value; }
        }
        private string p23 = "";

        public string P23
        {
            get { return p23; }
            set { p23 = value; }
        }
        private string p24 = "";

        public string P24
        {
            get { return p24; }
            set { p24 = value; }
        }
        private string p25 = "";

        public string P25
        {
            get { return p25; }
            set { p25 = value; }
        }
        private string p26 = "";

        public string P26
        {
            get { return p26; }
            set { p26 = value; }
        }
        private string p27 = "";

        public string P27
        {
            get { return p27; }
            set { p27 = value; }
        }
        private string p28 = "";

        public string P28
        {
            get { return p28; }
            set { p28 = value; }
        }
        private string p29 = "";

        public string P29
        {
            get { return p29; }
            set { p29 = value; }
        }
        private string p30 = "";

        public string P30
        {
            get { return p30; }
            set { p30 = value; }
        }
        private string p31 = "";

        public string P31
        {
            get { return p31; }
            set { p31 = value; }
        }
        private string p32 = "";

        public string P32
        {
            get { return p32; }
            set { p32 = value; }
        }
        private string p33 = "";

        public string P33
        {
            get { return p33; }
            set { p33 = value; }
        }
        private string p34 = "";

        public string P34
        {
            get { return p34; }
            set { p34 = value; }
        }
        private string p35 = "";

        public string P35
        {
            get { return p35; }
            set { p35 = value; }
        }
        private string p36 = "";

        public string P36
        {
            get { return p36; }
            set { p36 = value; }
        }
        private string p37 = "";

        public string P37
        {
            get { return p37; }
            set { p37 = value; }
        }
        private string p38 = "";

        public string P38
        {
            get { return p38; }
            set { p38 = value; }
        }
        private string p39 = "";

        public string P39
        {
            get { return p39; }
            set { p39 = value; }
        }
        private string p40 = "";

        public string P40
        {
            get { return p40; }
            set { p40 = value; }
        }
        private string p41 = "";

        public string P41
        {
            get { return p41; }
            set { p41 = value; }
        }
        private string p42 = "";

        public string P42
        {
            get { return p42; }
            set { p42 = value; }
        }
        private string p43 = "";

        public string P43
        {
            get { return p43; }
            set { p43 = value; }
        }
        private string p44 = "";

        public string P44
        {
            get { return p44; }
            set { p44 = value; }
        }
        private string p45 = "";

        public string P45
        {
            get { return p45; }
            set { p45 = value; }
        }
        private string p46 = "";

        public string P46
        {
            get { return p46; }
            set { p46 = value; }
        }
        private string p47 = "";

        public string P47
        {
            get { return p47; }
            set { p47 = value; }
        }
        private string p48 = "";

        public string P48
        {
            get { return p48; }
            set { p48 = value; }
        }
        private string p49 = "";

        public string P49
        {
            get { return p49; }
            set { p49 = value; }
        }


        /// <summary>
        ///对方应当模式:R 例如: $FF $01$05$09$R$08
        ///写入成功的应答模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private string request;

        public string Request
        {
            get { return request; }
            set { request = value; }
        }

     #endregion
        #endregion
    }
}
