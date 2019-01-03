using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Collections;
using System.Threading;


namespace SunManage.communication
{
    public partial class RS232 : Form
    {
        public static string mSerialPortState;
        public RS232()
        {
            try
            {
            InitializeComponent();
           
            CommPort com = CommPort.Instance;


            int found = 0;
            string[] portList = com.GetAvailablePorts();
            for (int i = 0; i < portList.Length; ++i)
            {
                string name = portList[i];
                comboBoxPortName.Items.Add(name);
                if (name == settings.Port.PortName)
                    found = i;
            }
            if (portList.Length > 0)
                comboBoxPortName.SelectedIndex = found;

            Int32[] baudRates = {
                100,300,600,1200,2400,4800,9600,14400,19200,
                38400,56000,57600,115200,128000,256000,0
            };
            found = 0;
            for (int i = 0; baudRates[i] != 0; ++i)
            {
                comboBoxBaudRate.Items.Add(baudRates[i].ToString());
                if (baudRates[i] == settings.Port.BaudRate)
                    found = i;
            }
            comboBoxBaudRate.SelectedIndex = found;

            comboBoxDataBits.Items.Add("5");
            comboBoxDataBits.Items.Add("6");
            comboBoxDataBits.Items.Add("7");
            comboBoxDataBits.Items.Add("8");
            comboBoxDataBits.SelectedIndex = settings.Port.DataBits - 5;

            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                comboBoxParity.Items.Add(s);
            }
            comboBoxParity.SelectedIndex = (int)settings.Port.Parity;

            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                comboBoxStopBits.Items.Add(s);
            }
            comboBoxStopBits.SelectedIndex = (int)settings.Port.StopBits;

            foreach (string s in Enum.GetNames(typeof(Handshake)))
            {
                comboBoxHandshake.Items.Add(s);
            }
            comboBoxHandshake.SelectedIndex = (int)settings.Port.Handshake;

            com.StatusChanged += OnStatusChanged;

            //com.DataReceived += OnDataReceived;

            com.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
        /// <summary>
        /// Open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                settings.Port.PortName = comboBoxPortName.Text;
                settings.Port.BaudRate = Int32.Parse(comboBoxBaudRate.Text);
                settings.Port.DataBits = comboBoxDataBits.SelectedIndex + 5;
                settings.Port.Parity = (Parity)comboBoxParity.SelectedIndex;
                settings.Port.StopBits = (StopBits)comboBoxStopBits.SelectedIndex;
                settings.Port.Handshake = (Handshake)comboBoxHandshake.SelectedIndex;
                CommPort com = CommPort.Instance;
                com.Open();


                if (com.IsOpen)
                {


                    MessageBox.Show("Serial COM open successfully", "Tips");
                }
                settings.Write();
               
                buttonOpen.Enabled = false;
                comboBoxPortName.Enabled = false;
                comboBoxBaudRate.Enabled = false;
                comboBoxDataBits.Enabled = false;
                comboBoxParity.Enabled = false;
                comboBoxStopBits.Enabled = false;
                comboBoxHandshake.Enabled = false;
               

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Error");
                return;
            }
            //Close();
        }
        /// <summary>
        /// Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
             try
            {
          
            buttonOpen.Enabled = true;
            comboBoxPortName.Enabled = true;
            comboBoxBaudRate.Enabled = true;
            comboBoxDataBits.Enabled = true;
            comboBoxParity.Enabled = true;
            comboBoxStopBits.Enabled = true;
            comboBoxHandshake.Enabled = true;
            CommPort com = CommPort.Instance;


           
            if (com.IsOpen == false)
            {
                MessageBox.Show("The serial port is not opened", "Tips");
            }
            if (com.IsOpen == true)
            {
                com.Close();
            }
            }
             catch (Exception ex)
             {
                 MessageBox.Show("Exception:" + ex.ToString(), "Tips");
             }
        }

        // delegate used for Invoke
        internal delegate void StringDelegate(string data);
        /// <summary>
        /// Update the connection status
        /// </summary>
        
        public void OnStatusChanged(string status)
        {
            try
            {
            //Handle multi-threading
            if (InvokeRequired)
            {
                Invoke(new StringDelegate(OnStatusChanged), new object[] { status });
                return;
            }
            mSerialPortState = status;
            USB.mUSBState = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
           
        }

        private void RS232_Load(object sender, EventArgs e)
        {
            try
            {
              CommPort com = CommPort.Instance;



              if (com.IsOpen == true)
              {
                  buttonOpen.Enabled = false;
                  comboBoxPortName.Enabled = false;
                  comboBoxBaudRate.Enabled = false;
                  comboBoxDataBits.Enabled = false;
                  comboBoxParity.Enabled = false;
                  comboBoxStopBits.Enabled = false;
                  comboBoxHandshake.Enabled = false;
              }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString(), "Tips");
            }
        }
    }
}
