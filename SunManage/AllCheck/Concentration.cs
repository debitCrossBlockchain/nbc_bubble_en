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
    public partial class Concentration : Form
    {
        public static string mTest_LIQUConsistence = (0).ToString("X4");
        public static string mHTest_LIQUConsistence = "";
        bool formMove = false;//窗体是否移动
        Point formPoint;//记录窗体的位置
        public Concentration()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTrue_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxTest_Filter_Concentration.Text))
                {
                    mTest_LIQUConsistence =(Convert.ToInt32 (textBoxTest_Filter_Concentration.Text.Replace("%", ""))).ToString("X4");
                    mHTest_LIQUConsistence = textBoxTest_Filter_Concentration.Text.Replace("%", "");
                }
                if (BasicBubblePoint.BacicBubble != null)
                {

                    BasicBubblePoint.Test_LIQUConsistenceBP = mTest_LIQUConsistence;
                    BasicBubblePoint.HTest_LIQUConsistenceBP = mHTest_LIQUConsistence;

                }

                if (ManualBubblePoint.MManualBubblePoint != null)
                {

                    ManualBubblePoint.Test_LIQUConsistenceMP = mTest_LIQUConsistence;
                    ManualBubblePoint.HTest_LIQUConsistenceMP = mHTest_LIQUConsistence;
                   

                }

                if (DiffusionFlowCheck.mDiffusionFlowCheck != null)
                {

                    DiffusionFlowCheck.Test_LIQUConsistenceDF = mTest_LIQUConsistence;
                    DiffusionFlowCheck.HTest_LIQUConsistenceDF = mHTest_LIQUConsistence;

                }


                if (StrengthenTheBubble.MStrengthenTheBubble != null)
                {

                    StrengthenTheBubble.Test_LIQUConsistenceSP = mTest_LIQUConsistence;
                    StrengthenTheBubble.HTest_LIQUConsistenceSP = mHTest_LIQUConsistence;

                }

                if (WaterImmersionTest.MWaterImmersionTest != null)
                {

                    WaterImmersionTest.Test_LIQUConsistenceWT = mTest_LIQUConsistence;
                    WaterImmersionTest.HTest_LIQUConsistenceWT = mHTest_LIQUConsistence;


                }
                if (RateOfRise.MRateOfRise != null)
                {

                    RateOfRise.Test_LIQUConsistenceRR = mTest_LIQUConsistence;
                    RateOfRise.HTest_LIQUConsistenceRR = mHTest_LIQUConsistence;

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
        /// <summary>
        /// 鼠标按下的处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Concentration_MouseDown(object sender, MouseEventArgs e)
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
        private void Concentration_MouseMove(object sender, MouseEventArgs e)
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
        private void Concentration_MouseUp(object sender, MouseEventArgs e)
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
