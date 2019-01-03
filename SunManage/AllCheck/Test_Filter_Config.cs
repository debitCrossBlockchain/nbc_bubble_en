using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace SunManage.AllCheck
{
    public partial class Test_Filter_Config : Form
    {
        public static string mTest_Filter_Config="";
        bool formMove = false;//窗体是否移动
        Point formPoint;//记录窗体的位置
        public Test_Filter_Config()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 鼠标按下的处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Test_Filter_Config_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                formPoint = new Point();
                int xOffset;
                int yOffset;
                if (e.Button == MouseButtons.Left)
                {
                    xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                    yOffset = -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height;
                    formPoint = new Point(xOffset, yOffset);
                    formMove = true;//开始移动
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Test_Filter_Config_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (formMove == true)
                {
                    Point mousePos = Control.MousePosition;
                    mousePos.Offset(formPoint.X, formPoint.Y);
                    Location = mousePos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 鼠标左键放下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Test_Filter_Config_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)//按下的是鼠标左键
                {
                    formMove = false;//停止移动
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// Cancel和关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 桶式选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelCartridge_Click(object sender, EventArgs e)
        {
            try
            {
                mTest_Filter_Config = "Cartridge";
                Cartridge mCartridge = new Cartridge();
                this.Close();
                this.Dispose();
                mCartridge.Show();
               
   
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }

        }
        /// <summary>
        /// 囊式的选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelPurse_Click(object sender, EventArgs e)
        {
            try
            {
              
                mTest_Filter_Config = "Bag";
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// 平板的选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelFlat_Click(object sender, EventArgs e)
        {
            try
            {
                mTest_Filter_Config = "Pannel";

                Plate mPl = new Plate();
                this.Close();
                this.Dispose();
                mPl.Show();

  
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// Other的选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelOther_Click(object sender, EventArgs e)
        {
            try
            {
                mTest_Filter_Config = "Other";
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }

        
    }
}
