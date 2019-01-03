using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Collections;
using System.Windows.Forms; // for Application.StartupPath
using SunManage.communication;

namespace SunManage.communication
{
    /// <summary>
    /// Persistent settings
    /// </summary>
  public  class settings
    {

        /// <summary> Port settings. </summary>
        public class Port
        {
            public static string PortName = "COM1";
            public static int BaudRate = 115200;
            public static int DataBits = 8;
            public static System.IO.Ports.Parity Parity = System.IO.Ports.Parity.None;
            public static System.IO.Ports.StopBits StopBits = System.IO.Ports.StopBits.One;
            public static System.IO.Ports.Handshake Handshake = System.IO.Ports.Handshake.None;
        }


        /// <summary>
        ///   Read the settings from disk. </summary>
        public static void Read()
        {
            IniFile ini = new IniFile("..\\..\\XmlIni\\SerialPort.ini");
            Port.PortName = ini.ReadValue("Port", "PortName", Port.PortName);
            Port.BaudRate = ini.ReadValue("Port", "BaudRate", Port.BaudRate);
            Port.DataBits = ini.ReadValue("Port", "DataBits", Port.DataBits);
            Port.Parity = (Parity)Enum.Parse(typeof(Parity), ini.ReadValue("Port", "Parity", Port.Parity.ToString()));
            Port.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ini.ReadValue("Port", "StopBits", Port.StopBits.ToString()));
            Port.Handshake = (Handshake)Enum.Parse(typeof(Handshake), ini.ReadValue("Port", "Handshake", Port.Handshake.ToString()));


        }

        /// <summary>
        ///   Write the settings to disk. </summary>
        public static void Write()
        {
            IniFile ini = new IniFile("..\\..\\XmlIni\\SerialPort.ini");
            ini.WriteValue("Port", "PortName", Port.PortName);
            ini.WriteValue("Port", "BaudRate", Port.BaudRate);
            ini.WriteValue("Port", "DataBits", Port.DataBits);
            ini.WriteValue("Port", "Parity", Port.Parity.ToString());
            ini.WriteValue("Port", "StopBits", Port.StopBits.ToString());
            ini.WriteValue("Port", "Handshake", Port.Handshake.ToString());


        }

    }
}
