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
            //当前用户是管理员的时候，直接启动应用程序
            //如果不是管理员，则使用启动对象启动程序，以确保使用管理员身份运行
            //获得当前登录的Windows用户标示
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            bool RunAdmin = identity != null && new WindowsPrincipal(identity).IsInRole(WindowsBuiltInRole.Administrator);
            if (!RunAdmin)
            {
                //创建启动对象
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.UseShellExecute = false;
                startInfo.WorkingDirectory = Environment.CurrentDirectory;
                startInfo.FileName = Application.ExecutablePath;
                //设置启动动作,确保以管理员身份运行
                startInfo.Verb = "runas";
                try
                {
                    Process.Start(new ProcessStartInfo(Assembly.GetEntryAssembly().CodeBase) { UseShellExecute = true, Verb = "runs" });
                    //System.Diagnostics.Process.Start(startInfo);
                }
                catch (Exception)
                {
                    MessageBox.Show("非管理员,该应用程序可能无法完整运行!");
                }
            }
             Application.Run(new Main());
        }
    }
}
