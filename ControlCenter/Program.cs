using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsharpMySQLConnector;

namespace ControlCenter
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormMain fm = new FormMain();
            fm.StartPosition = FormStartPosition.CenterScreen;
           
            Application.Run(fm);
       
        }
    }
}
