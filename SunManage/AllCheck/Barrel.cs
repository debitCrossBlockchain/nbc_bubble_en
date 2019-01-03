using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SunManage.AllCheck
{
    public partial class Cartridge : Form
    {
        bool formMove = false;//窗体是否移动
        Point formPoint;//记录窗体的位置
        public static string Test_filter_Area = "";
        public static string Test_filter_Hight = "";
        public static string Test_filter_Num = "";
       static Double mAr;

        public Cartridge()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 鼠标按下的处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cartridge_MouseDown(object sender, MouseEventArgs e)
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
        private void Cartridge_MouseMove(object sender, MouseEventArgs e)
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
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelFalse_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// Confirm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTrue_Click(object sender, EventArgs e)
        {
            try
            {
                Double mArea;
               
                 
                 Test_filter_Hight = textBoxTest_Filter_Hight.Text;
                 Test_filter_Num = textBoxTest_Filter_Num.Text;
                 if ((!string.IsNullOrEmpty(textBoxTest_Filter_Hight.Text)) && (!string.IsNullOrEmpty(textBoxTest_Filter_Num.Text)))
                 {
                     mArea = ((Convert.ToInt64(textBoxTest_Filter_Hight.Text)) * (Convert.ToInt64(textBoxTest_Filter_Num.Text))) * 600;
                     Test_filter_Area = mArea.ToString();
                     mAr = mArea / 10000;
                 }
                
                 if (BasicBubblePoint.BacicBubble!=null)
                 {

                      BasicBubblePoint.BacicBubble.textBoxTest_Filter_Area.Text = String.Format("{0:N4}", Convert.ToDecimal(mAr).ToString("F4"));
                     
                      BasicBubblePoint.Test_Filter_ConfigBP = (Convert.ToInt64(textBoxTest_Filter_Num.Text)).ToString("X4");
                      BasicBubblePoint.Test_Filter_numerBP = (Convert.ToInt64(textBoxTest_Filter_Num.Text)).ToString("X2");

                    
                      BasicBubblePoint.HTest_Filter_ConfigBP = textBoxTest_Filter_Hight.Text; ;
                      BasicBubblePoint.HTest_Filter_numerBP = textBoxTest_Filter_Num.Text;

                 }
               
                 if (ManualBubblePoint.MManualBubblePoint!=null)
                 {

                     ManualBubblePoint.MManualBubblePoint.textBoxTest_Filter_Area.Text = String.Format("{0:N4}", Convert.ToDecimal(mAr).ToString("F4"));

                     ManualBubblePoint.Test_Filter_ConfigMP = (Convert.ToInt64(textBoxTest_Filter_Num.Text)).ToString("X4");
                     ManualBubblePoint.Test_Filter_numerMP = (Convert.ToInt64(textBoxTest_Filter_Num.Text)).ToString("X2");

                     ManualBubblePoint.HTest_Filter_ConfigMP = textBoxTest_Filter_Hight.Text; ;
                     ManualBubblePoint.HTest_Filter_numerMP = textBoxTest_Filter_Num.Text;


                 }

                 if (DiffusionFlowCheck.mDiffusionFlowCheck != null)
                 {

                     DiffusionFlowCheck.mDiffusionFlowCheck.textBoxTest_Filter_Area.Text = String.Format("{0:N4}", Convert.ToDecimal(mAr).ToString("F4"));

                     DiffusionFlowCheck.Test_Filter_ConfigDF = (Convert.ToInt64(textBoxTest_Filter_Num.Text)).ToString("X4");
                     DiffusionFlowCheck.Test_Filter_numerDF = (Convert.ToInt64(textBoxTest_Filter_Num.Text)).ToString("X2");

                     DiffusionFlowCheck.HTest_Filter_ConfigDF = textBoxTest_Filter_Hight.Text; ;
                     DiffusionFlowCheck.HTest_Filter_numerDF = textBoxTest_Filter_Num.Text;

                 }


                 if (StrengthenTheBubble.MStrengthenTheBubble != null)
                 {

                     StrengthenTheBubble.MStrengthenTheBubble.textBoxTest_Filter_Area.Text = String.Format("{0:N4}", Convert.ToDecimal(mAr).ToString("F4"));

                     StrengthenTheBubble.Test_Filter_ConfigSP = (Convert.ToInt64(textBoxTest_Filter_Num.Text)).ToString("X4");
                     StrengthenTheBubble.Test_Filter_numerSP = (Convert.ToInt64(textBoxTest_Filter_Num.Text)).ToString("X2");

                     StrengthenTheBubble.HTest_Filter_ConfigSP = textBoxTest_Filter_Hight.Text; ;
                     StrengthenTheBubble.HTest_Filter_numerSP = textBoxTest_Filter_Num.Text;

                 }

                 if (WaterImmersionTest.MWaterImmersionTest != null)
                 {

                     WaterImmersionTest.MWaterImmersionTest.textBoxTest_Filter_Area.Text = String.Format("{0:N4}", Convert.ToDecimal(mAr).ToString("F4"));

                     WaterImmersionTest.Test_Filter_ConfigWT = (Convert.ToInt64(textBoxTest_Filter_Num.Text)).ToString("X4");
                     WaterImmersionTest.Test_Filter_numerWT = (Convert.ToInt64(textBoxTest_Filter_Num.Text)).ToString("X2");

                     WaterImmersionTest.HTest_Filter_ConfigWT = textBoxTest_Filter_Hight.Text; ;
                     WaterImmersionTest.HTest_Filter_numerWT = textBoxTest_Filter_Num.Text;

                 }
                 if (RateOfRise.MRateOfRise != null)
                 {

                     RateOfRise.MRateOfRise.textBoxTest_Filter_Area.Text = String.Format("{0:N4}", Convert.ToDecimal(mAr).ToString("F4"));

                     RateOfRise.Test_Filter_ConfigRR = (Convert.ToInt64(textBoxTest_Filter_Num.Text)).ToString("X4");
                     RateOfRise.Test_Filter_numerRR = (Convert.ToInt64(textBoxTest_Filter_Num.Text)).ToString("X2");

                     RateOfRise.HTest_Filter_ConfigRR = textBoxTest_Filter_Hight.Text; ;
                     RateOfRise.HTest_Filter_numerRR = textBoxTest_Filter_Num.Text;

                 }
                this.Close();
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
        private void Cartridge_MouseUp(object sender, MouseEventArgs e)
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

       
    }
}
