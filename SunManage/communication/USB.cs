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
    public partial class USB : Form
    {
        public static int vid;
        public static int pid;
        public static string mUSBState;
        public USB()
        {
            InitializeComponent();
           
        }
        // Create an instance of the USB reference device
        private usbReferenceDevice theReferenceUsbDevice;
        private void open_Click(object sender, EventArgs e)
        {
            try
            {
                PIDTb.Enabled = false;
                VIDTb.Enabled = false;
                open.Enabled = false;
                CloseB.Enabled = true;
                if ((!(string.IsNullOrEmpty(PIDTb.Text))) && (!(string.IsNullOrEmpty(PIDTb.Text))))
                {
                    string mpid = "0x" + PIDTb.Text.ToString();
                    string mvid = "0x" + VIDTb.Text.ToString();
                    vid = Convert.ToInt32(mvid, 16);
                    pid = Convert.ToInt32(mpid, 16);
                    theReferenceUsbDevice = new usbReferenceDevice(vid, pid);

                    // Add a listener for usb events
                    theReferenceUsbDevice.usbEvent += new usbReferenceDevice.usbEventsHandler(usbEvent_receiver);


                    // Perform an initial search for the target device
                    theReferenceUsbDevice.findTargetDevice();
                    theReferenceUsbDevice.init();
                    theReferenceUsbDevice.StartReading();
                }
            }
            catch (Exception)
            {
            }
        }
        // Listener for USB events
        private void usbEvent_receiver(object o, EventArgs e)
        {
            try
            {
                // Check the status of the USB device and update the form accordingly
                if (theReferenceUsbDevice.isDeviceAttached)
                {
                    // Device is currently attached

                    // Update the status label
                    mUSBState = "USB Device is attached";
                    //StatusChangedUSB("USB Device is attached");

                    // Update the form

                }
                else
                {
                    // Device is currently unattached

                    // Update the status label
                    mUSBState = "USB Device is detached";
                    //StatusChangedUSB("USB Device is detached");

                    // Update the form

                }
            }
            catch (Exception)
            {
            }
        }
        private void CloseB_Click(object sender, EventArgs e)
        {
            try
            {

                PIDTb.Enabled = true;
                VIDTb.Enabled = true;
                open.Enabled = true;
                CloseB.Enabled = false;
                theReferenceUsbDevice.StopReading();
            }
            catch (Exception)
            {
            }
        }

        private void USB_Load(object sender, EventArgs e)
        {
            try
            {
                if (Communication.mConFlag==3)
                {
                    PIDTb.Enabled = false;
                    VIDTb.Enabled = false;
                    open.Enabled = false;
                    //CloseB.Enabled = true;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
