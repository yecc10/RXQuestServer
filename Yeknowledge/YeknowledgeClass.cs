using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Yeknowledge
{
    class YeknowledgeClass
    {
        private void ReadWCPFile(Thread process)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "wcp files (*.wcp)|*.wcp";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string Path = openFileDialog.FileName;
                string text = File.ReadAllText(Path);
                string[] stringSeparators = new string[] { "\r\n" };
                string[] res= text.Split(stringSeparators, StringSplitOptions.None);//根据换行符进行拆分
                List<UrlLNode> nodes = new List<UrlLNode> { };
                bool StartRecord = false;
                int CheckNum = 0;
                for (int i = 0; i <= res.Length; i++)
                {
                    if (res[i] != "[TOPICS]" && !StartRecord)
                    {
                        continue;
                    }
                    if (res[i]== "[TOPICS]")
                    {
                        StartRecord = true;
                        CheckNum =Convert.ToInt32(res[i + 1].Split('=')[1]);
                        i += 1;
                        continue;
                    }
                    UrlLNode urlLNode = new UrlLNode();
                    urlLNode.SetValue(res[i].Split('=')[1], res[i+1].Split('=')[1], res[i+2].Split('=')[1], res[i+3].Split('=')[1], res[i+4].Split('=')[1], res[i+5].Split('=')[1], res[i+6].Split('=')[1], res[i+7].Split('=')[1], res[i+8].Split('=')[1], res[i+9].Split('=')[1]);
                    i += 9;
                    nodes.Add(urlLNode);
                    if (nodes.Count== CheckNum)
                    {
                        break;
                    }
                }
                UpdataXml(nodes, process);
            }
            else
            {
                //用户取消了文件选择
                return;
            }
        }
        public void UpdataXml(List <UrlLNode> urlLNodes, Thread process)
        {
            TextReader tr = new StringReader("<Root>Content</Root>");
            XDocument doc = XDocument.Load(tr);
            process.Resume();//恢复挂起的进程
        }
        public void UpdataTreeViewByWcp(TreeView treeView, Form form)
        {
            Thread thread = Thread.CurrentThread;
            System.Threading.Thread importThread = new System.Threading.Thread(new ThreadStart(delegate { ReadWCPFile(thread); }));
            importThread.SetApartmentState(ApartmentState.STA); //重点
            importThread.Start();
            thread.Suspend();
            treeView.Nodes.Clear();
            treeView.Nodes.Add("Knowledge");
            form.TopMost = true;
            form.WindowState = FormWindowState.Normal;
            form.StartPosition = FormStartPosition.CenterScreen;
        }
        [DllImport("ntdll.dll")]
        private static extern uint NtSuspendProcess([In] IntPtr ProcessHandle);//挂起进程
        [DllImport("ntdll.dll")]
        private static extern uint NtResumeProcess([In] IntPtr ProcessHandle);//恢复挂起的进程
    }
    class UrlLNode
    {
        private string Title { get; set; }
        private string Level { get; set; }
        private string Url { get; set; }
        private string Icon { get; set; }
        private string Status { get; set; }
        private string Keywords { get; set; }
        private string ContextNumber { get; set; }
        private string ApplyTemp { get; set; }
        private string Expanded { get; set; }
        private string Kind { get; set; }
        public void SetValue(string ITitle, string ILevel, string IUrl, string IIcon, string IStatus, string IKeywords, string IContextNumber, string IApplyTemp, string IExpanded, string IKind)
        {
            Title = ITitle;
            Level = ILevel;
            Url = IUrl;
            Icon = IIcon;
            Status = IStatus;
            Keywords = IKeywords;
            ContextNumber = IContextNumber;
            ApplyTemp = IApplyTemp;
            Expanded = IExpanded;
            Kind = IKind;
        }
    }
}
