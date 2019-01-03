using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SunManage.AllCheck;
namespace SunManage
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.setCompatibleTextRenderingDefault(false);
            //Application.Run(new SunManage.AllCheck.Login());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login mLogin = new Login();
            mLogin.Show();
            Application.Run();
         }
    }
}
