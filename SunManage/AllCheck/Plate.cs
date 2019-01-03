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
    public partial class Plate : Form
    {
        public static string Test_Area="";
        public static string Test_Filter_Diameter = "";
        static Double mArea = 0;
        bool formMove = false;//窗体是否移动
        Point formPoint;//记录窗体的位置
        public Plate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 鼠标按下的处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Plate_MouseDown(object sender, MouseEventArgs e)
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
        private void Plate_MouseMove(object sender, MouseEventArgs e)
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
        private void Plate_MouseUp(object sender, MouseEventArgs e)
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
        /// Confirm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTrue_Click(object sender, EventArgs e)
        {
            try
            {


                Double mAr;
                Test_Filter_Diameter = textBoxTest_Filter_Diameter.Text;

                if (!string.IsNullOrEmpty(textBoxTest_Filter_Diameter.Text))
                {
                    mAr = (((Convert.ToInt64(textBoxTest_Filter_Diameter.Text)) / 2)) * (((Convert.ToInt64(textBoxTest_Filter_Diameter.Text)) / 2)) * (3.14);
                     mArea = mAr/1000000;
                }

                if ( BasicBubblePoint.BacicBubble!=null)
                {

                    BasicBubblePoint.BacicBubble.textBoxTest_Filter_Area.Text = String.Format("{0:N4}", Convert.ToDecimal(mArea).ToString("F4"));
                    
                }
               
                if (ManualBubblePoint.MManualBubblePoint != null)
                {

                    ManualBubblePoint.MManualBubblePoint.textBoxTest_Filter_Area.Text = String.Format("{0:N4}", Convert.ToDecimal(mArea).ToString("F4"));

                }
                if (DiffusionFlowCheck.mDiffusionFlowCheck != null)
                {

                    DiffusionFlowCheck.mDiffusionFlowCheck.textBoxTest_Filter_Area.Text = String.Format("{0:N4}", Convert.ToDecimal(mArea).ToString("F4"));

                }
                if (StrengthenTheBubble.MStrengthenTheBubble != null)
                {

                    StrengthenTheBubble.MStrengthenTheBubble.textBoxTest_Filter_Area.Text = String.Format("{0:N4}", Convert.ToDecimal(mArea).ToString("F4"));

                }
                if (WaterImmersionTest.MWaterImmersionTest != null)
                {

                    WaterImmersionTest.MWaterImmersionTest.textBoxTest_Filter_Area.Text = String.Format("{0:N4}", Convert.ToDecimal(mArea).ToString("F4"));

                }
                if (RateOfRise.MRateOfRise != null)
                {

                    RateOfRise.MRateOfRise.textBoxTest_Filter_Area.Text = String.Format("{0:N4}", Convert.ToDecimal(mArea).ToString("F4"));

                }
                this.Close();
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
       
    }
}
