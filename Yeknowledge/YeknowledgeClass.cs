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
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Xml.Linq;

namespace Yeknowledge
{
    class YeknowledgeClass
    {
        private string XmlPath { get; set; }
        private TreeView TargettreeView { get; set; }
        private void ReadWCPFile(Thread process)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Recent);
            openFileDialog.Filter = "wcp files (*.wcp)|*.wcp";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string Path = openFileDialog.FileName;
                string text = File.ReadAllText(Path);
                string[] stringSeparators = new string[] { "\r\n" };
                string[] res = text.Split(stringSeparators, StringSplitOptions.None);//根据换行符进行拆分
                List<UrlLNode> nodes = new List<UrlLNode> { };
                bool StartRecord = false;
                int CheckNum = 0;
                for (int i = 0; i <= res.Length; i++)
                {
                    if (res[i] != "[TOPICS]" && !StartRecord)
                    {
                        continue;
                    }
                    if (res[i] == "[TOPICS]")
                    {
                        StartRecord = true;
                        CheckNum = Convert.ToInt32(res[i + 1].Split('=')[1]);
                        i += 1;
                        continue;
                    }
                    UrlLNode urlLNode = new UrlLNode();
                    urlLNode.SetValue(res[i].Split('=')[1], res[i + 1].Split('=')[1], res[i + 2].Split('=')[1], res[i + 3].Split('=')[1], res[i + 4].Split('=')[1], res[i + 5].Split('=')[1], res[i + 6].Split('=')[1], res[i + 7].Split('=')[1], res[i + 8].Split('=')[1], res[i + 9].Split('=')[1]);
                    i += 9;
                    nodes.Add(urlLNode);
                    if (nodes.Count == CheckNum)
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
        public void UpdataXml(List<UrlLNode> urlLNodes, Thread process)
        {
            TextReader tr = new StringReader("<YeKnowledge></YeKnowledge>");
            XDocument doc = XDocument.Load(tr);
            XElement xDocument = doc.Root;
            NodeXmlFrame nodeXmlFrame = new NodeXmlFrame();
            nodeXmlFrame.FrameXmlElement = new List<XElement> { };
            nodeXmlFrame.AddNodeFrame(xDocument); //InitRoot
            for (int i = 0; i < urlLNodes.Count; i++)
            {
                int RecordMark = nodeXmlFrame.FrameXmlElement.Count-1;
                if (RecordMark != urlLNodes[i].Level)
                {
                    if (RecordMark < urlLNodes[i].Level)
                    {
                        XElement xmlElement = nodeXmlFrame.FrameXmlElement[RecordMark];
                        xmlElement = WriteXmlRecord(urlLNodes[i], xmlElement);
                        nodeXmlFrame.AddNodeFrame(xmlElement); //新的目录级别
                        continue;
                    }
                    else
                    {
                        int ij = 0;
                        do
                        {
                            nodeXmlFrame.FrameXmlElement.RemoveAt(RecordMark - ij); //退级
                            ij += 1;
                        } while ((nodeXmlFrame.FrameXmlElement.Count - 1) != urlLNodes[i].Level);//级别和目录级别匹配
                    }
                }
                //此处级别和目录级别已经匹配
                XElement xElement = nodeXmlFrame.FrameXmlElement[urlLNodes[i].Level];
                xElement = WriteXmlRecord(urlLNodes[i], xElement);
                nodeXmlFrame.AddNodeFrame(xElement); //新的目录级别
            }
            string datatime = DateTime.Now.ToString("yyyymmddHHmmssffff");
            string strDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            XmlPath = strDesktopPath + datatime + "Data.xml";
            doc.Save(XmlPath);
            process.Resume();//恢复挂起的进程
        }
        public XElement WriteXmlRecord(UrlLNode urlLNodes, XElement xDocument)
        {
            XElement xElement = new XElement("ID_" + GenerateId());
            xElement.SetElementValue("Title", urlLNodes.Title);
            xElement.SetElementValue("Level", urlLNodes.Level);
            xElement.SetElementValue("Url", urlLNodes.Url);
            xElement.SetElementValue("Icon", urlLNodes.Icon);
            xElement.SetElementValue("Status", urlLNodes.Status);
            xElement.SetElementValue("Keywords", urlLNodes.Keywords);
            xElement.SetElementValue("ContextNumber", urlLNodes.ContextNumber);
            xElement.SetElementValue("ApplyTemp", urlLNodes.ApplyTemp);
            xElement.SetElementValue("Expanded", urlLNodes.Expanded);
            xElement.SetElementValue("Kind", urlLNodes.Kind);
            xDocument.Add(xElement);
            return xElement;
        }
        public void UpdataTreeViewByWcp(TreeView treeView, Form form)
        {
            Thread thread = Thread.CurrentThread;
            System.Threading.Thread importThread = new System.Threading.Thread(new ThreadStart(delegate { ReadWCPFile(thread); }));
            importThread.SetApartmentState(ApartmentState.STA); //重点
            importThread.Start();
            thread.Suspend();
            TargettreeView = treeView; 
            XDocument doc = XDocument.Load(XmlPath);
            XElement xDocument = doc.Root;
            IEnumerable<XElement> elements = xDocument.Elements();//获得根节点下的元素集合 
            foreach (XElement item in elements)
            {
                Console.WriteLine(item.Name);
                DiGuiNode(item); //递归获得此元素下的子元素                
            }
            treeView.Nodes.Clear();
            treeView.Nodes.Add("Knowledge");
            //form.TopMost = true;
            form.WindowState = FormWindowState.Normal;
            form.StartPosition = FormStartPosition.CenterScreen;
        }
        private static void DiGuiNode(XElement xroot)
        {
            if (xroot != null)
            {
                foreach (var item in xroot.Elements())
                {
                    SetTreeView(item.Name, item.Value);
                    DiGuiNode(item);
                }
            }
        }
        private static void SetTreeView(XName Name,String Value)
        {
            //TargettreeView;
        }
        [DllImport("ntdll.dll")]
        private static extern uint NtSuspendProcess([In] IntPtr ProcessHandle);//挂起进程
        [DllImport("ntdll.dll")]
        private static extern uint NtResumeProcess([In] IntPtr ProcessHandle);//恢复挂起的进程

        private string GenerateId()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
        //private long GenerateId()
        //{
        //    byte[] buffer = Guid.NewGuid().ToByteArray();
        //    return BitConverter.ToInt64(buffer, 0);
        //}
    }
    class UrlLNode
    {
        public string Title { get; set; }
        public int Level { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string Status { get; set; }
        public string Keywords { get; set; }
        public string ContextNumber { get; set; }
        public string ApplyTemp { get; set; }
        public string Expanded { get; set; }
        public string Kind { get; set; }
        public List<UrlLNode> NodesFrame { get; set; }
        public void SetValue(string ITitle, string ILevel, string IUrl, string IIcon, string IStatus, string IKeywords, string IContextNumber, string IApplyTemp, string IExpanded, string IKind)
        {
            Title = ITitle;
            Level = Convert.ToInt32(ILevel);
            Url = IUrl;
            Icon = IIcon;
            Status = IStatus;
            Keywords = IKeywords;
            ContextNumber = IContextNumber;
            ApplyTemp = IApplyTemp;
            Expanded = IExpanded;
            Kind = IKind;
        }
        public void AddNodeFrame(params UrlLNode[] nodes)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                NodesFrame.Add(nodes[i]);
            }
        }
    }
    class NodeXmlFrame
    {
        public List<XElement> FrameXmlElement { get; set; }
        public void AddNodeFrame(params XElement[] nodes)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                FrameXmlElement.Add(nodes[i]);
            }
        }
    }

}
