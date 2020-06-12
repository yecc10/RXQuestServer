using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Security.Principal;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RXQuestServer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        [DllImportAttribute("kernel32.dll", EntryPoint = "OpenProcess")]
        public static extern IntPtr OpenProcess
     (
         int dwDesiredAccess,
         bool bInheritHandle,
         int dwProcessId
     );
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            bool RunAdmin = identity != null && new WindowsPrincipal(identity).IsInRole(WindowsBuiltInRole.Administrator);
            if (!RunAdmin)
            {
                try
                {
                    Process.Start(new ProcessStartInfo(Assembly.GetEntryAssembly().CodeBase) { UseShellExecute = true, Verb = "runs" });
                }
                catch (Exception)
                {
                    MessageBox.Show("管理员运行失败");
                }
            }
            Application.Run(new Main());
        }
    }
}
