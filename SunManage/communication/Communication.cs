using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SunManage.communication
{
    public partial class Communication : Form
    {
        public static int  mConFlag=0;
        public Communication()
        {
            InitializeComponent();
           
        }
       
        private void radioButtonIPV4_Click(object sender, EventArgs e)
        {
            try
            {
                IPV4 mIp4 = new IPV4();

                mIp4.FormBorderStyle = FormBorderStyle.None;
                mIp4.TopLevel = false;
                mIp4.Dock = DockStyle.Fill;
                this.MyPanel2.Controls.Clear();
                this.MyPanel2.Controls.Add(mIp4);
                mIp4.Show();
                mConFlag = 1;
            }
            catch (Exception)
            {
            }
            
        }

        private void radioButtonRS232_Click(object sender, EventArgs e)
        {
            try
            {

                RS232 mRs232 = new RS232();
                mRs232.FormBorderStyle = FormBorderStyle.None;
                mRs232.TopLevel = false;
                mRs232.Dock = DockStyle.Fill;
                this.MyPanel2.Controls.Clear();
                this.MyPanel2.Controls.Add(mRs232);
                mRs232.Show();
                mConFlag = 2;
            }
            catch (Exception)
            {
            }
            
        }

       

        private void radioButtonUSB_Click(object sender, EventArgs e)
        {
            try
            {
                USB mUsb = new USB();

                mUsb.FormBorderStyle = FormBorderStyle.None;
                mUsb.TopLevel = false;
                mUsb.Dock = DockStyle.Fill;
                this.MyPanel2.Controls.Clear();
                this.MyPanel2.Controls.Add(mUsb);
                mUsb.Show();
                mConFlag = 3;
            }
            catch (Exception)
            {
            }
            
        }

        private void Communication_Load(object sender, EventArgs e)
        {
            try
            {
                switch (mConFlag)
                {
                    case 0:
                        {
                            radioButtonIPV4.TabIndex = 1;
                            radioButtonUSB.TabIndex = 3;
                            radioButtonRS232.TabIndex = 2;
                            

                        }
                        break;
                    case 1:
                        {
                            radioButtonIPV4.TabIndex = 1;
                            radioButtonUSB.TabIndex = 3;
                            radioButtonRS232.TabIndex = 2;

                           
                        }
                        break;
                    case 2:
                        {
                            radioButtonIPV4.TabIndex = 2;
                            radioButtonUSB.TabIndex = 3;
                            radioButtonRS232.TabIndex = 1;
                           
                        }
                        break;
                    case 3:
                        {
                            radioButtonIPV4.TabIndex = 3;
                            radioButtonUSB.TabIndex = 1;
                            radioButtonRS232.TabIndex = 2;
                            
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
            }
            
        }
    }
}
