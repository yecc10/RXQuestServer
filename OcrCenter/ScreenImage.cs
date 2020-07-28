using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace OcrCenter
{
    public partial class ScreenImage : Form
    {
        Rectangle RC = new Rectangle(0, 0, 0, 0);
        Point _StartPoint = new Point(0, 0);
        Point _EndPoint = new Point(0, 0);
        Form BeforeForm = null;
        bool StartDrawRec = false;
        private bool startdraw = false;//是否开始画图
        private Graphics gs;//画版
        private Pen pen;//画笔
        private Point startpt;//画图起点
        public Rectangle taskBarRect;//任务栏位置

        public ScreenImage()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            pictureBox.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.TransparencyKey = BackColor;
            this.DoubleBuffered = true;
        }
        public void SetCallerForm(Form PreForm)
        {
            BeforeForm = PreForm;
        }
        public void SetPictureBox(Image Picture)
        {
            pictureBox.Image = Picture;
            Cursor.Position = new Point(Screen.PrimaryScreen.Bounds.Width/2, Screen.PrimaryScreen.Bounds.Height/2);
        }
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _StartPoint.X = Cursor.Position.X;
            _StartPoint.Y = Cursor.Position.Y;
            StartDrawRec = true;
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.Hide();
            _EndPoint.X = Cursor.Position.X;
            _EndPoint.Y = Cursor.Position.Y;
            //创建图象，保存将来截取的图象
            Bitmap image = new Bitmap(Math.Abs(_StartPoint.X - _EndPoint.X), Math.Abs(_StartPoint.Y - _EndPoint.Y));
            Graphics imgGraphics = Graphics.FromImage(image);
            //设置截屏区域
            imgGraphics.CopyFromScreen(_StartPoint.X, _StartPoint.Y,0, 0,new Size(Math.Abs(_StartPoint.X- _EndPoint.X), Math.Abs(_StartPoint.Y - _EndPoint.Y)));
            //保存;
            GetScreen GS = new GetScreen();
            string Path=GS.SaveImage(image,true);
            OCR _ocr = (OCR)BeforeForm;
            _ocr.Show();
            _ocr.MaximizeBox = true;
            _ocr.TopMost = true;
            _ocr.TranslateOCRByScreenImage(Path);
            MouseHookProcedure = new HookProc(MouseHookProc); //声明钩子 
        }
        private int hMouseHook = 0;
        private MouseEventArgs mea;//鼠标事件参数
        //全局钩子常量  
        private const int WH_MOUSE_LL = 14;
        //声明消息的常量,鼠标按下和释放  
        private const int WM_LEFT_RBUTTONDOWN = 0x201;//鼠标左键按下事件监听值
        private const int WM_LEFT_RBUTTONUP = 0x202;//鼠标左键弹起事件监听值
        private const int WM_RIGHT_RBUTTONDOWN = 0x204;//鼠标右键按下事件监听值
        private const int WM_RIGHT_RBUTTONUP = 0x205;//鼠标右键按下事件监听值
        private const int WM_MOVE = 0x200;//鼠标移动事件监听值
        //保存任务栏的矩形区域  
        public Rectangle newTaskBarRect;
        //定义委托  
        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);
        private HookProc MouseHookProcedure;//寻找符合条件的窗口  
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(
            string lpClassName,
            string lpWindowName
        );
        //获取窗口的矩形区域  
        [DllImport("user32.dll", EntryPoint = "GetWindowRect")]
        public static extern int GetWindowRect(
            int hwnd,
            ref Rectangle lpRect
        );
        //安装钩子  
        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(int idHook,HookProc lpfn,IntPtr hInstance,int threadId);
        //卸载钩子  
        [DllImport("user32.dll", EntryPoint = "UnhookWindowsHookEx")]
        public static extern bool UnhookWindowsHookEx(int hHook);
        //调用下一个钩子  
        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(int idHook,int nCode,int wParam,IntPtr lParam);
        //获取当前线程的标识符  
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();
        //获取一个应用程序或动态链接库的模块句柄  
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);
        //鼠标结构，保存了鼠标的信息  
        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEHOOKSTRUCT
        {
            public Point pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }
        /// <summary>  
        /// 安装钩子  
        /// </summary>  
        private void StartHook()
        {
            if (hMouseHook == 0)
            {
                hMouseHook = SetWindowsHookEx(WH_MOUSE_LL, MouseHookProcedure, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
                if (hMouseHook == 0)
                {//如果设置钩子失败.   
                    this.StopHook();
                    MessageBox.Show("Set windows hook failed!");
                }
            }
        }
        /// <summary>  
        /// 卸载钩子  
        /// </summary>  
        private void StopHook()
        {
            bool stop = true;
            if (hMouseHook != 0)
            {
                stop = UnhookWindowsHookEx(hMouseHook);
                hMouseHook = 0;
                if (!stop)
                {//卸载钩子失败  
                    MessageBox.Show("Unhook failed!");
                }
            }
        }
        private int MouseHookProc(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                //把参数lParam在内存中指向的数据转换为MOUSEHOOKSTRUCT结构  
                MOUSEHOOKSTRUCT mouse = (MOUSEHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MOUSEHOOKSTRUCT));//鼠标  
                mea = new MouseEventArgs(MouseButtons.Left, 1, mouse.pt.X, mouse.pt.Y, 0);
                //这句为了看鼠标的位置  
                this.Text = "MousePosition:" +mouse.pt.ToString();
                mousdraw_MouseMove(mea);
                if (wParam == WM_LEFT_RBUTTONDOWN || wParam == WM_LEFT_RBUTTONUP || wParam == WM_RIGHT_RBUTTONDOWN || wParam == WM_RIGHT_RBUTTONUP)
                { //鼠标按下或者释放时候截获  
                    if (newTaskBarRect.Contains(mouse.pt))
                    { //当鼠标在任务栏的范围内  
                        //如果返回1，则结束消息，这个消息到此为止，不再传递。  
                        //如果返回0或调用CallNextHookEx函数则消息出了这个钩子继续往下传递，也就是传给消息真正的接受者  
                        return 0;
                    }
                    else if (wParam == WM_LEFT_RBUTTONDOWN)
                    {
                        return mousdraw_MouseDown(mea);
                    }
                    else if (wParam == WM_LEFT_RBUTTONUP)
                    {
                        return mousdraw_MouseUp(mea);
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            return CallNextHookEx(hMouseHook, nCode, wParam, lParam);
        }
        private int mousdraw_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startdraw = true;//开始画图
                startpt = e.Location;
            }
            return 1;
        }
        private int mousdraw_MouseMove(MouseEventArgs e)
        {
            if (startdraw)
            {
                gs.DrawLine(pen, startpt, e.Location);
                startpt = e.Location;
            }
            return 0;
        }
        private int mousdraw_MouseUp(MouseEventArgs e)
        {
            startdraw = false;//结束画图
            return 1;
        }
    }
}
