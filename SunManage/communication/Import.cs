using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
//引用创建Access数据库的库
using System.Data.OleDb;
using System.Collections;

namespace SunManage.communication
{
    public partial class Import : Form
    {
       
        private static int mflag = 0;//标志位查看数据库是否存在这条记录
        private static int flag = 0;
        string firstLine = "";//文本文件的第一行
        private OleDbConnection mConnection;
        string sAccessConnection = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source=..\\..\\DataBase\\TestHistoryData.mdb";
        public Import()
        {
            InitializeComponent();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            flag++;
            if (buttonImport.Text == "Start Import")
            {
                timerInfo.Enabled = true;
                buttonImport.Text = "Close";

                DriveInfo[] drvs = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drvs)
                {
                    if (drive.IsReady && drive.DriveType == DriveType.Removable)
                    {
                        listBoxInfo.Items.Clear();
                        listBoxInfo.Items.Add("Device Info:");
                        listBoxInfo.Items.Add("");
                        listBoxInfo.Items.Add("Drive:" + drive.Name);
                        listBoxInfo.Items.Add("Type:" + drive.DriveType);
                        listBoxInfo.Items.Add("File Format:" + drive.DriveFormat);
                        listBoxInfo.Items.Add("Capacity:" + drive.TotalSize / 1000000000 + "GB");
                        listBoxInfo.Items.Add("");

                        treeViewInfo.Nodes.Clear();
                        TreeNode root = treeViewInfo.Nodes.Add(drive.Name);
                        root.ImageIndex = 1;

                        string[] dirs = Directory.GetDirectories(drive.Name);
                        for (int i = 0; i < dirs.Length; i++)
                        {
                            TreeNode subFolder = root.Nodes.Add(dirs[i]);
                            subFolder.ImageIndex = 2;
                        }
                        root.Expand();
                        treeViewInfo.SelectedNode = root;

                        getListItem(treeViewInfo.SelectedNode);
                    }
                }
            }
            else
            {
                timerInfo.Enabled = false;
                buttonImport.Text = "Start Import";
            }
        }
        /// <summary>
        /// 显示相应的图标
        /// </summary>
        /// <param name="selectNode"></param>
        public void getListItem(TreeNode selectNode)
        {
            try
            {
                listViewInfo.Items.Clear();
                string[] dirs = Directory.GetDirectories(selectNode.Text);
                foreach (string dir in dirs)
                {
                    ListViewItem item = new ListViewItem(Path.GetFileName(dir));
                    item.ImageIndex = 2;
                    listViewInfo.Items.Add(item);
                }

                string[] docs = Directory.GetFiles(selectNode.Text);
                foreach (string s in docs)
                {
                    if (File.Exists(s))
                    {
                        switch (Path.GetExtension(s))
                        {
                            case ".doc":
                                {
                                    ListViewItem item = new ListViewItem(Path.GetFileName(s));
                                    item.ImageIndex = 0;
                                    listViewInfo.Items.Add(item);
                                }
                                break;
                            case ".png":
                                {
                                    ListViewItem item = new ListViewItem(Path.GetFileName(s));
                                    item.ImageIndex = 3;
                                    listViewInfo.Items.Add(item);
                                }
                                break;
                            case ".jpg":
                                {
                                    ListViewItem item = new ListViewItem(Path.GetFileName(s));
                                    item.ImageIndex = 3;
                                    listViewInfo.Items.Add(item);
                                }
                                break;
                            case ".pdf":
                                {
                                    ListViewItem item = new ListViewItem(Path.GetFileName(s));
                                    item.ImageIndex = 4;
                                    listViewInfo.Items.Add(item);
                                }
                                break;
                            case ".ppt":
                                {
                                    ListViewItem item = new ListViewItem(Path.GetFileName(s));
                                    item.ImageIndex = 5;
                                    listViewInfo.Items.Add(item);
                                }
                                break;
                        }
                    }
                }
            }
            catch (ArgumentException err)
            {
                MessageBox.Show(err.Message, "Exception！", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (PathTooLongException err)
            {
                MessageBox.Show(err.Message, "Exception！", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (IOException err)
            {
                MessageBox.Show(err.Message, "Exception！", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 启动复制相应东西
        /// </summary>
        /// <param name="path"></param>
        public void getBackup(string path)
        {
            try
            {
                //setParameter sp = new setParameter();
                string[] files = Directory.GetFiles(path);
                foreach (string s in files)
                {
                    //
                    if (Path.GetExtension(s) == "*.txt" && File.Exists(s))
                    {
                        string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string record = @"..\..\USB";
                        Directory.CreateDirectory(record);
                        File.Copy(s, record + @"\" + Path.GetFileName(s), true);
                        if (!File.Exists(@"..\..\log\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt"))
                        {
                            StreamWriter sw = new StreamWriter(@"..\..\log\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", true);
                            sw.WriteLine("Copy File:{0}", Path.GetFileName(s));
                            sw.WriteLine("File Size:{0}", s.Length.ToString());
                            sw.WriteLine("Path:{0}", Path.GetDirectoryName(s));
                            sw.WriteLine("Copy Time:{0}", currentTime);
                            sw.WriteLine("");
                            sw.Close();
                        }
                        else
                        {
                            StreamWriter sw = new StreamWriter(@"..\..\log\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", true);
                            sw.WriteLine("Copy File:{0}", Path.GetFileName(s));
                            sw.WriteLine("File Size:{0}", s.Length.ToString());
                            sw.WriteLine("Path:{0}", Path.GetDirectoryName(s));
                            sw.WriteLine("CopyTime:{0}", currentTime);
                            sw.WriteLine("");
                            sw.Close();
                        }
                    }
                }
            }
            catch (ArgumentException err)
            {
                MessageBox.Show(err.Message, "Exception！", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (PathTooLongException err)
            {
                MessageBox.Show(err.Message, "Exception！", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (IOException err)
            {
                MessageBox.Show(err.Message, "Exception！", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException err)
            {
                MessageBox.Show(err.Message, "Exception！", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void timerInfo_Tick(object sender, EventArgs e)
        {
            if (timerInfo.Enabled == true)
            {
                DriveInfo[] drvs = DriveInfo.GetDrives();
                foreach (DriveInfo drv in drvs)
                {
                    if (drv.DriveType == DriveType.Removable && drv.IsReady == true)
                    {
                        getBackup(drv.Name);

                        string[] dirs = Directory.GetDirectories(drv.Name);
                        foreach (string s1 in dirs)
                        {
                            string[] subDirs = Directory.GetDirectories(s1);
                            if (subDirs.Length == 0)
                            {
                                getBackup(s1);
                            }
                            else
                            {
                                foreach (string s2 in subDirs)
                                {
                                    getBackup(s2);
                                }
                            }
                        }
                    }
                }
                timerInfo.Enabled = false;
                MessageBox.Show("Import Success！", "Tips", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void treeViewInfo_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listViewInfo.Items.Clear();
            getListItem(treeViewInfo.SelectedNode);
        }

        private void buttonLoadSQL_Click(object sender, EventArgs e)
        {
            //string InitialDireectory = string.Format(@"{0}\..\..\", AppDomain.CurrentDomain.setupInformation.ApplicationBase);Application.StartupPath +
            openFileDialogtxt.InitialDirectory = @"../../USB";
            openFileDialogtxt.Filter = "File|*.*";
            openFileDialogtxt.FilterIndex = 2;
            openFileDialogtxt.RestoreDirectory = false;
            //openFileDialog1.ShowHelp = true;// 对话框 发生变化
            openFileDialogtxt.Title = "Open";
            openFileDialogtxt.FileName = "";
            openFileDialogtxt.Multiselect = true;
  
            if (openFileDialogtxt.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialogtxt.FileName.ToString();

                StreamReader objReader = new StreamReader(filePath,System.Text.Encoding.GetEncoding("GB2312"));

                char[] parsChar = { ',' };

                string sLine = "";
                firstLine = objReader.ReadLine();
                //MessageBox.Show(firstLine);
                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null && !sLine.Equals(""))
                    {
                       
                        string mTreeView = Main.MTreeName.ToString();

                        if (!string.IsNullOrEmpty(sLine.Split(parsChar)[0].ToString()))
                        {
                            try
                            {


                                string m = sLine.Split(parsChar)[0].ToString();


                                string mSelectQuery = "Select * From {0} where [TestHisData]= '" + m + "'";

                                mSelectQuery = string.Format(mSelectQuery, mTreeView);
                                mConnection = new OleDbConnection(sAccessConnection);
                                mConnection.Open();
                                OleDbCommand cmd = new OleDbCommand(mSelectQuery, mConnection);
                               int reader = Convert.ToInt32(cmd.ExecuteScalar());
                                if (reader!=0)
                                {
                                    //MessageBox.Show("此条记录存在，请重新输入不同的NO.！");
                                    mflag = 0;
                                }
                                else
                                {
                                   
                                        mflag = 1;

                                
                                }
                                
                                mConnection.Close();

                            }
                            catch (Exception)
                            {
                               // MessageBox.Show("Exception:" + ex.ToString(), "Tips");
                            }
                        }
                        if (mflag == 1)
                        {
                            string Htest_type = "";
                            switch (sLine.Split(parsChar)[1].ToString())
                            {
                                case "M":
                                    {
                                        Htest_type = "Manual Bubble Point";
                                    }
                                    break;
                                case "B":
                                    {
                                        Htest_type = "Basic Bubble Point";
                                    }
                                    break;
                                case "A":
                                    {
                                        Htest_type = "Extensive Bubble Point";
                                    }
                                    break;
                                case "P":
                                    {
                                        Htest_type = "Pressure Holding";
                                    }
                                    break;
                                case "D":
                                    {
                                        Htest_type = "Diffusion Flow";
                                    }
                                    break;
                                case "H":
                                    {
                                        Htest_type = "Water Immersion ";
                                    }
                                    break;
                                case "d":
                                    {
                                        Htest_type = "Ultrafiltration";
                                    }
                                    break;
                                default: break;


                            }
                            string mTest_Filter_Area1 = "";
                            string mTest_Filter_Area = sLine.Split(parsChar)[17].ToString();
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
                            string mTest_Meme_Aper = sLine.Split(parsChar)[18].ToString();
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
                                    for (int i = 0; i < mTest_Meme_Aper.Length - 2; i++)
                                    {

                                        mTest_Meme_Aper1 = mTest_Meme_Aper1 + mTest_Meme_Aper[i];
                                    }
                                    mTest_Meme_Aper1 = mTest_Meme_Aper1 + ".";
                                    for (int i = mTest_Meme_Aper.Length - 2; i < mTest_Meme_Aper.Length; i++)
                                    {

                                        mTest_Meme_Aper1 = mTest_Meme_Aper1 + mTest_Meme_Aper[i];
                                    }
                                    break;
                            }
                            string m0 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[0].ToString()).Trim()))
                            {
                                m0 = sLine.Split(parsChar)[0].ToString();
                            }
                            string m2 = "";
                           
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[2].ToString()).Trim()))
                            {
                                m2 = sLine.Split(parsChar)[2].ToString();
                            }
                            string m3 = "";
                            if (!string.IsNullOrEmpty(sLine.Split(parsChar)[3].ToString()))
                            {
                                m3 = sLine.Split(parsChar)[3].ToString();
                            }
                            string m4 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[4].ToString()).Trim()))
                            {
                                m4 = sLine.Split(parsChar)[4].ToString();
                            }
                            string m5 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[5].ToString()).Trim()))
                            {
                                m5 = sLine.Split(parsChar)[5].ToString();
                            }
                            string m6 ="";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[6].ToString()).Trim()))
                            {
                                m6 = sLine.Split(parsChar)[6].ToString();
                            }
                            string m7 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[7].ToString()).Trim()))
                            {
                                m7 = sLine.Split(parsChar)[7].ToString();
                            }
                            string m8 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[8].ToString()).Trim()))
                            {
                                m8 = sLine.Split(parsChar)[8].ToString();
                            }
                            string m9 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[9].ToString()).Trim()))
                            {
                                m9 = sLine.Split(parsChar)[9].ToString();
                            }
                            string m10 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[10].ToString()).Trim()))
                            {
                                m10 = sLine.Split(parsChar)[10].ToString();
                            }
                            string m11 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[11].ToString()).Trim()))
                            {
                                m11 = sLine.Split(parsChar)[11].ToString();
                            }
                            string m12 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[12].ToString()).Trim()))
                            {
                                m12 = sLine.Split(parsChar)[12].ToString();
                            }
                            string m13 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[13].ToString()).Trim()))
                            {
                                m13 = sLine.Split(parsChar)[13].ToString();
                            }
                            string m14 = "";
                            string mKP = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[14].ToString()).Trim()))
                            {
                                switch (sLine.Split(parsChar)[1].ToString())
                                {
                                   
                                    case "A":
                                        {

                                            string mDF = sLine.Split(parsChar)[14].ToString();
                                            switch (mDF.Length)
                                            {
                                                case 0:
                                                    {
                                                        m14 = "0.0";
                                                    }
                                                    break;
                                                case 1:
                                                    {
                                                        m14 = "0.0" + mDF;
                                                    }
                                                    break;


                                                default:
                                                    for (int i = 0; i < mDF.Length - 1; i++)
                                                    {

                                                        m14 = m14 + mDF[i];
                                                    }
                                                    m14 = m14 + ".";
                                                    for (int i = mDF.Length - 1; i < mDF.Length; i++)
                                                    {

                                                        m14 = m14 + mDF[i];
                                                    }
                                                    break;
                                            }
                                           
                                        }
                                        break;
                                  
                                    case "D":
                                        {
                                      
                                            string mDF = sLine.Split(parsChar)[14].ToString();
                                            switch (mDF.Length)
                                            {
                                                case 0:
                                                    {
                                                        m14 = "0.0";
                                                    }
                                                    break;
                                                case 1:
                                                    {
                                                        m14 = "0.0" + mDF;
                                                    }
                                                    break;


                                                default:
                                                    for (int i = 0; i < mDF.Length - 1; i++)
                                                    {

                                                        m14 = m14 + mDF[i];
                                                    }
                                                    m14 = m14 + ".";
                                                    for (int i = mDF.Length - 1; i < mDF.Length; i++)
                                                    {

                                                        m14 = m14 + mDF[i];
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                 
                                    case "H":
                                        {
                                            string mDF = sLine.Split(parsChar)[14].ToString();
                                            switch (mDF.Length)
                                            {
                                                case 0:
                                                    {
                                                        m14 = "0.00";
                                                    }
                                                    break;
                                                case 1:
                                                    {
                                                        m14 = "0.0" + mDF;
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        m14 = "0." + mDF;
                                                    }
                                                    break;

                                                default:
                                                    for (int i = 0; i < mDF.Length - 2; i++)
                                                    {

                                                        m14 = m14 + mDF[i];
                                                    }
                                                    m14 = m14 + ".";
                                                    for (int i = mDF.Length - 2; i < mDF.Length; i++)
                                                    {

                                                        m14 = m14 + mDF[i];
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    default: break;


                                }
                              
                            }
                            string m15 = "";
                         
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[15].ToString()).Trim()))
                            {
                                switch (sLine.Split(parsChar)[1].ToString())
                                {

                                    case "A":
                                        {

                                            string mDF = sLine.Split(parsChar)[15].ToString();
                                            switch (mDF.Length)
                                            {
                                                case 0:
                                                    {
                                                        m15 = "0.0";
                                                    }
                                                    break;
                                                case 1:
                                                    {
                                                        m15 = "0.0" + mDF;
                                                    }
                                                    break;


                                                default:
                                                    for (int i = 0; i < mDF.Length - 1; i++)
                                                    {

                                                        m15 = m15 + mDF[i];
                                                    }
                                                    m15 = m15 + ".";
                                                    for (int i = mDF.Length - 1; i < mDF.Length; i++)
                                                    {

                                                        m15 = m15 + mDF[i];
                                                    }
                                                    break;
                                            }

                                        }
                                        break;
                                 
                                    case "D":
                                        {
                                           
                                            string mDF = sLine.Split(parsChar)[15].ToString();
                                            switch (mDF.Length)
                                            {
                                                case 0:
                                                    {
                                                        m15 = "0.0";
                                                    }
                                                    break;
                                                case 1:
                                                    {
                                                        m15 = "0.0" + mDF;
                                                    }
                                                    break;


                                                default:
                                                    for (int i = 0; i < mDF.Length - 1; i++)
                                                    {

                                                        m15 = m15 + mDF[i];
                                                    }
                                                    m15 = m15 + ".";
                                                    for (int i = mDF.Length - 1; i < mDF.Length; i++)
                                                    {

                                                        m15 = m15 + mDF[i];
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case "d":
                                        {

                                            string mDF = sLine.Split(parsChar)[15].ToString();
                                            switch (mDF.Length)
                                            {
                                                case 0:
                                                    {
                                                        m15 = "0.0";
                                                    }
                                                    break;
                                                case 1:
                                                    {
                                                        m15 = "0.0" + mDF;
                                                    }
                                                    break;


                                                default:
                                                    for (int i = 0; i < mDF.Length - 1; i++)
                                                    {

                                                        m15 = m15 + mDF[i];
                                                    }
                                                    m15 = m15 + ".";
                                                    for (int i = mDF.Length - 1; i < mDF.Length; i++)
                                                    {

                                                        m15 = m15 + mDF[i];
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case "P":
                                        {
                                            mKP = sLine.Split(parsChar)[15].ToString();
                                            m15 = sLine.Split(parsChar)[15].ToString();
                                        }
                                        break;
                                    case "H":
                                        {
                                            string mDF = sLine.Split(parsChar)[15].ToString();
                                            switch (mDF.Length)
                                            {
                                                case 0:
                                                    {
                                                        m15 = "0.00";
                                                    }
                                                    break;
                                                case 1:
                                                    {
                                                        m15 = "0.0" + mDF;
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        m15 = "0." + mDF;
                                                    }
                                                    break;
                                              
                                                default:
                                                    for (int i = 0; i < mDF.Length - 2; i++)
                                                    {

                                                        m15 = m15 + mDF[i];
                                                    }
                                                    m15 = m15 + ".";
                                                    for (int i = mDF.Length - 2; i < mDF.Length; i++)
                                                    {

                                                        m15 = m15 + mDF[i];
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    default: break;


                                }
                            }
                            string m16 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[16].ToString()).Trim()))
                            {
                                m16 = sLine.Split(parsChar)[16].ToString();
                            }
                            string m19 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[19].ToString()).Trim().Replace("          ", "")))
                            {
                                 m19 = (sLine.Split(parsChar)[19].ToString()).Replace("          ", "");
                            }
                            string m20 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[20].ToString()).Trim()))
                            {
                                m20 = sLine.Split(parsChar)[20].ToString();
                            }
                            string m21 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[21].ToString()).Trim()))
                            {
                                m21 = sLine.Split(parsChar)[21].ToString();
                            }
                            string m22 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[22].ToString()).Trim()))
                            {
                                m22 = sLine.Split(parsChar)[22].ToString();
                            }
                            string m23 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[23].ToString()).Trim()))
                            {
                                m23 = sLine.Split(parsChar)[23].ToString();
                            }
                            string m24 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[24].ToString()).Trim()))
                            {
                                m24 = sLine.Split(parsChar)[24].ToString();
                            }
                            string m25 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[25].ToString()).Trim()))
                            {
                                m25 = sLine.Split(parsChar)[25].ToString();
                            }
                            string m26 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[26].ToString()).Trim()))
                            {
                                m26 = sLine.Split(parsChar)[26].ToString();
                            }
                            string m27 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[27].ToString()).Trim()))
                            {
                                m27 = sLine.Split(parsChar)[27].ToString();
                            }
                            string m28 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[28].ToString()).Trim()))
                            {
                                m28 = sLine.Split(parsChar)[28].ToString();
                            }
                            string m29 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[29].ToString()).Trim()))
                            {
                                m29 = sLine.Split(parsChar)[29].ToString();
                            }
                            string m30 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[30].ToString()).Trim()))
                            {
                                m30 = sLine.Split(parsChar)[30].ToString();
                            }
                            string m31 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[31].ToString()).Trim()))
                            {
                                m31 = sLine.Split(parsChar)[31].ToString();
                            }
                            string m32 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[32].ToString()).Trim()))
                            {
                                m32 = sLine.Split(parsChar)[32].ToString();
                            }
                            string m33 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[33].ToString()).Trim()))
                            {
                                m33 = sLine.Split(parsChar)[33].ToString();
                            }
                            string m34 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[34].ToString()).Trim()))
                            {
                                m34 = sLine.Split(parsChar)[34].ToString();
                            }
                            string m35 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[35].ToString()).Trim()))
                            {
                                m35 = sLine.Split(parsChar)[35].ToString();
                            }
                            string m36 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[36].ToString()).Trim()))
                            {
                                m36 = sLine.Split(parsChar)[36].ToString();
                            }
                            string m37 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[37].ToString()).Trim()))
                            {
                                m37 = sLine.Split(parsChar)[37].ToString();
                            }
                            string m38 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[38].ToString()).Trim()))
                            {
                                m38 = sLine.Split(parsChar)[38].ToString();
                            }
                            string m39 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[39].ToString()).Trim()))
                            {
                                m39 = sLine.Split(parsChar)[39].ToString();
                            }
                            string m40 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[40].ToString()).Trim()))
                            {
                                m40 = sLine.Split(parsChar)[40].ToString();
                            }
                            string m41 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[41].ToString()).Trim()))
                            {
                                m41 = sLine.Split(parsChar)[41].ToString();
                            }
                            string m42 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[42].ToString()).Trim()))
                            {
                                m42 = sLine.Split(parsChar)[42].ToString();
                            }
                            string m43 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[43].ToString()).Trim()))
                            {
                                m43 = sLine.Split(parsChar)[43].ToString();
                            }
                            string m44 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[44].ToString()).Trim()))
                            {
                                m44 = sLine.Split(parsChar)[44].ToString();
                            }
                            string m45 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[45].ToString()).Trim()))
                            {
                                m45 = sLine.Split(parsChar)[45].ToString();
                            }
                            string m46 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[46].ToString()).Trim()))
                            {
                                m46 = sLine.Split(parsChar)[46].ToString();
                            }
                            string m47 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[47].ToString()).Trim()))
                            {
                                m47 = sLine.Split(parsChar)[47].ToString();
                            }
                            string m48 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[48].ToString()).Trim()))
                            {
                                m48 = sLine.Split(parsChar)[48].ToString();
                            }
                            string m49 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[49].ToString()).Trim()))
                            {
                                m49 = sLine.Split(parsChar)[49].ToString();
                            }
                            string m50 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[50].ToString()).Trim()))
                            {
                                m50 = sLine.Split(parsChar)[50].ToString();
                            }
                            string m51 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[51].ToString()).Trim()))
                            {
                                m51 = sLine.Split(parsChar)[51].ToString();
                            }
                            string m52 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[52].ToString()).Trim()))
                            {
                                m52 = sLine.Split(parsChar)[52].ToString();
                            }
                            string m53 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[53].ToString()).Trim()))
                            {
                                m53 = sLine.Split(parsChar)[53].ToString();
                            }
                            string m54 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[54].ToString()).Trim()))
                            {
                                m54 = sLine.Split(parsChar)[54].ToString();
                            }
                            string m55 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[55].ToString()).Trim()))
                            {
                                m55 = sLine.Split(parsChar)[55].ToString();
                            }
                            string m56 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[56].ToString()).Trim()))
                            {
                                m56 = sLine.Split(parsChar)[56].ToString();
                            }
                            string m57 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[57].ToString()).Trim()))
                            {
                                m57 = sLine.Split(parsChar)[57].ToString();
                            }
                            string m58 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[58].ToString()).Trim()))
                            {
                                m58 = sLine.Split(parsChar)[58].ToString();
                            }
                            string m59 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[59].ToString()).Trim()))
                            {
                                m59 = sLine.Split(parsChar)[59].ToString();
                            }
                            string m60 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[60].ToString()).Trim()))
                            {
                                m60 = sLine.Split(parsChar)[60].ToString();
                            }
                            string m61 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[61].ToString()).Trim()))
                            {
                                m61 = sLine.Split(parsChar)[61].ToString();
                            }
                            string m62 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[62].ToString()).Trim()))
                            {
                                m62 = sLine.Split(parsChar)[62].ToString();
                            }
                            string m63 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[63].ToString()).Trim()))
                            {
                                m63 = sLine.Split(parsChar)[63].ToString();
                            }
                            string m64 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[64].ToString()).Trim()))
                            {
                                m64 = sLine.Split(parsChar)[64].ToString();
                            }
                            string m65 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[65].ToString()).Trim()))
                            {
                                m65 = sLine.Split(parsChar)[65].ToString();
                            }
                            string m66 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[66].ToString()).Trim()))
                            {
                                m66 = sLine.Split(parsChar)[66].ToString();
                            }
                            string m67 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[67].ToString()).Trim()))
                            {
                                m67 = sLine.Split(parsChar)[67].ToString();
                            }
                            string m68 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[68].ToString()).Trim()))
                            {
                                m68 = sLine.Split(parsChar)[68].ToString();
                            }
                            string m69 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[69].ToString()).Trim()))
                            {
                                m69 = sLine.Split(parsChar)[69].ToString();
                            }
                            string m70 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[70].ToString()).Trim()))
                            {
                                m70 = sLine.Split(parsChar)[70].ToString();
                            }
                            string m71 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[71].ToString()).Trim()))
                            {
                                m71 = sLine.Split(parsChar)[71].ToString();
                            }
                            string m72 = "";
                            if (!string.IsNullOrEmpty((sLine.Split(parsChar)[72].ToString()).Trim()))
                            {
                                m72 = sLine.Split(parsChar)[72].ToString();
                            }

                           // string mQuery = String.Format("INSERT INTO {0}([TestHisData],[Htest_type],[Test_Psernum],[HA_STime],[Test_Tsernum],[Test_Fsernum],[Test_filt],[Test_LIQUType],[Test_Filter_Config],[Test_Filter_number],[Test_Result],[Test_startp],[Test_setBp],[Test_Up_Volm],[Test_Dif_max],[Htest_DifValue],[Htest_Value],[Test_Filter_Area],[Test_Meme_Aper],[Test_Filter_type],[Htest_DiffePress],[Test_testimes],[Htest_Name],[p0],[p1],[p2],[p3],[p4],[p5],[p6],[p7],[p8],[p9],[p10],[p11],[p12],[p13],[p14],[p15],[p16],[p17],[p18],[p19],[p20],[p21],[p22],[p23],[p24],[p25],[p26],[p27],[p28],[p29],[p30],[p31],[p32],[p33],[p34],[p35],[p36],[p37],[p38],[p39],[p40],[p41],[p42],[p43],[p44],[p45],[p46],[p47],[p48],[p49]) VALUES ('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}','{52}','{53}','{54}','{55}','{56}','{57}','{58}','{59}','{60}','{61}','{62}','{63}','{64}','{65}','{66}','{67}','{68}','{69}','{70}','{71}','{72}','{73}')", mTreeView, m0, Htest_type, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16, mTest_Filter_Area1, mTest_Meme_Aper1, m19, m20, m21, m22, m23, m24, m25, m26, m27, m28, m29, m30, m31, m32, m33, m34, m35, m36, m37, m38, m39, m40, m41, m42, m43, m44, m45, m46, m47, m48, m49, m50, m51, m52, m53, m54, m55, m56, m57, m58, m59, m60, m61, m62, m63, m64, m65, m66, m67, m68, m69, m70, m71, m72);

                            string mQuery = String.Format("INSERT INTO {0}([TestHisData],[Htest_type],[Test_Psernum],[HA_STime],[Test_Tsernum],[Test_Fsernum],[Test_filt],[Test_LIQUType],[Test_Filter_Config],[Test_Filter_number],[Test_Result],[Test_startp],[Test_setBp],[Test_Up_Volm],[Test_Dif_max],[Htest_DifValue],[Htest_Value],[Test_Filter_Area],[Test_Meme_Aper],[Test_Filter_type],[Htest_DiffePress],[Test_testimes],[Htest_Name],[p0],[p1],[p2],[p3],[p4],[p5],[p6],[p7],[p8],[p9],[p10],[p11],[p12],[p13],[p14],[p15],[p16],[p17],[p18],[p19],[p20],[p21],[p22],[p23],[p24],[p25],[p26],[p27],[p28],[p29],[p30],[p31],[p32],[p33],[p34],[p35],[p36],[p37],[p38],[p39],[p40],[p41],[p42],[p43],[p44],[p45],[p46],[p47],[p48],[p49]) VALUES ('" + m0.ToString() + "','" + Htest_type.ToString() + "','" + m2.ToString() + "','" + m3.ToString() + "','" + m5.ToString() + "','" + m4.ToString() + "','" + m6.ToString() + "','" + m7.ToString() + "','" + m8.ToString() + "','" + m9.ToString() + "','" + m10.ToString() + "','" + m11.ToString() + "','" + m12.ToString() + "','" + m13.ToString() + "','" + m14.ToString() + "','" + m15.ToString() + "','" + m16.ToString() + "','" + mTest_Filter_Area1.ToString() + "','" + mTest_Meme_Aper1.ToString() + "','" + m19.ToString() + "','" + mKP.ToString() + "','" + m21.ToString() + "','" + m22.ToString() + "','" + m23.ToString() + "','" + m24.ToString() + "','" + m25.ToString() + "','" + m26.ToString() + "','" + m27.ToString() + "','" + m28.ToString() + "','" + m29.ToString() + "','" + m30.ToString() + "','" + m31.ToString() + "','" + m32.ToString() + "','" + m33.ToString() + "','" + m34.ToString() + "','" + m35.ToString() + "','" + m36.ToString() + "','" + m37.ToString() + "','" + m38.ToString() + "','" + m39.ToString() + "','" + m40.ToString() + "','" + m41.ToString() + "','" + m42.ToString() + "','" + m43.ToString() + "','" + m44.ToString() + "','" + m45.ToString() + "','" + m46.ToString() + "','" + m47.ToString() + "','" + m48.ToString() + "','" + m49.ToString() + "','" + m50.ToString() + "','" + m51.ToString() + "','" + m52.ToString() + "','" + m53.ToString() + "','" + m54.ToString() + "','" + m55.ToString() + "','" + m56.ToString() + "','" + m57.ToString() + "','" + m58.ToString() + "','" + m59.ToString() + "','" + m60.ToString() + "','" + m61.ToString() + "','" + m62.ToString() + "','" + m63.ToString() + "','" + m64.ToString() + "','" + m65.ToString() + "','" + m66.ToString() + "','" + m67.ToString() + "','" + m68.ToString() + "','" + m69.ToString() + "','" + m70.ToString() + "','" + m71.ToString() + "','" + m72.ToString() + "')", mTreeView);

                            OleDbCommand da = new OleDbCommand(mQuery, mConnection);

                            try
                            {
                                da.CommandType = CommandType.Text;
                                if (mConnection.State != ConnectionState.Open) { mConnection.Open(); }
                               
                                da.ExecuteNonQuery();

                                this.Close();

                            }

                            catch (Exception ex)
                            {

                                File.WriteAllText(DateTime.Now.ToShortDateString(), "Exception:" + ex.ToString());
                                MessageBox.Show("The program is out of order. Check the log");

                            }

                            finally
                            {
                                mflag = 0;
                                mConnection.Close();

                            }
                        }
                    }
                }
                objReader.Close();
               
                this.Close();
            } 
            }
        }


    }


