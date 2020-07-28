using Baidu.Aip.Ocr;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace OcrCenter
{
    class GetScreen
    {
        //截取全屏图象
        private void GetCurrentScreen()
        {
            //创建图象，保存将来截取的图象
            Bitmap image = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics imgGraphics = Graphics.FromImage(image);
            //设置截屏区域
            imgGraphics.CopyFromScreen(0, 0, 0, 0, new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
            //保存;
            SaveImage(image);
        }
        public void GetWholeScreen()
        {
            System.Threading.Thread importThread = new System.Threading.Thread(new ThreadStart(GetCurrentScreen));
            importThread.SetApartmentState(ApartmentState.STA); //重点
            importThread.Start();
        }
        //保存图象文件
        private void SaveImage(Image image)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension=true;
            saveFileDialog.Filter = "*.BMP| *.BMP|*.JPG|*.JPG |*.PNG|*.PNG| PDF文件(*.PDF) | *.PDF | All files(*.*) | *.* ";
            string fileName = string.Empty;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                 fileName = saveFileDialog.FileName;
                string extension = Path.GetExtension(fileName);
                if (!String.IsNullOrEmpty(extension))
                {
                    image.Save(fileName);
                }
                else
                {
                    image.Save(fileName, ImageFormat.Bmp);
                }
            }
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.FileName = fileName;
        }
    }
    public class API
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowsHookEx(int hookid, HookProc pfnhook, IntPtr hinst, int threadid);
        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetCurrentThreadId();
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhook);
        public enum WindowsHookCodes
        {
            WH_MSGFILTER = (-1),
            WH_JOURNALRECORD = 0,
            WH_JOURNALPLAYBACK = 1,
            WH_KEYBOARD = 2,
            WH_GETMESSAGE = 3,
            WH_CALLWNDPROC = 4,
            WH_CBT = 5,
            WH_SYSMSGFILTER = 6,
            WH_MOUSE = 7,
            WH_HARDWARE = 8,
            WH_DEBUG = 9,
            WH_SHELL = 10,
            WH_FOREGROUNDIDLE = 11,
            WH_CALLWNDPROCRET = 12,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14
        }
    }
    /// <summary>
    /// 一个根据矩形截图类
    /// zgke@Sina.com
    /// qq:116149
    /// </summary>
    public class CopyScreen
    {
        /// <summary>
        /// 屏幕大小
        /// </summary>
        private Size ScreenSize { get { return Screen.PrimaryScreen.Bounds.Size; } }
        /// <summary>
        /// 鼠标位置
        /// </summary>
        private Point MousePoint { get { return Cursor.Position; } }
        /// <summary>
        /// 私有方法获取屏幕图形(全部图形)
        /// </summary>
        public Bitmap ScreenImage
        {
            get
            {
                Bitmap m_BackBitmap = new Bitmap(ScreenSize.Width, ScreenSize.Height);
                Graphics _Graphics = Graphics.FromImage(m_BackBitmap);
                _Graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), ScreenSize);
                _Graphics.Dispose();
                return m_BackBitmap;
            }
        }
        /// <summary>
        /// 钩子
        /// </summary>
        private HookMessage m_HookMessage;
        /// <summary>
        /// 屏幕句柄
        /// </summary>
        private IntPtr m_ScreenForm;
        /// <summary>
        /// 图形
        /// </summary>
        private Bitmap m_Image;
        public delegate void GetImage(Image p_Image);
        /// <summary>
        /// 获取屏幕截图
        /// </summary>
        public event GetImage GetScreenImage;
        /// <summary>
        /// 构造
        /// </summary>
        public CopyScreen()
        {
            m_ScreenForm = API.GetDesktopWindow();
            m_HookMessage = new HookMessage(API.WindowsHookCodes.WH_MOUSE_LL, true);
            m_HookMessage.GetHook += new HookMessage.GetHookMessage(m_HookMessage_GetHook);
        }
        /// <summary>
        /// 钩子事件
        /// </summary>
        /// <param name="p_Code"></param>
        /// <param name="p_wParam"></param>
        /// <param name="p_lParam"></param>
        /// <param name="p_Send"></param>
        void m_HookMessage_GetHook(int p_Code, IntPtr p_wParam, IntPtr p_lParam, ref bool p_Send)
        {
            if (m_StarMouse)
            {
                switch (p_wParam.ToInt32())
                {
                    case 512: //Move
                        MouseMove();
                        break;
                    case 513:  //Down
                        MouseDown();
                        p_Send = false;
                        break;
                    case 514:  //Up
                        MouseUp();
                        p_Send = false;
                        break;
                    default:
                        m_StarMouse = false;
                        break;
                }
            }
        }
        /// <summary>
        /// 根据矩形 如果Width是正直接返回 如果使-会转换成正的矩形 保证大小位置不变
        /// </summary>
        /// <param name="p_Rectangle">矩形</param>
        /// <returns>正矩形</returns>
        public static Rectangle GetUprightRectangle(Rectangle p_Rectangle)
        {
            Rectangle _Rect = p_Rectangle;
            if (_Rect.Width < 0)
            {
                int _X = _Rect.X;
                _Rect.X = _Rect.Width + _Rect.X;
                _Rect.Width = _X - _Rect.X;
            }
            if (_Rect.Height < 0)
            {
                int _Y = _Rect.Y;
                _Rect.Y = _Rect.Height + _Rect.Y;
                _Rect.Height = _Y - _Rect.Y;
            }
            return _Rect;
        }
        private Rectangle m_MouseRectangle = new Rectangle(0, 0, 0, 0);
        private bool m_DrawStar = false;
        private void MouseDown()
        {
            m_MouseRectangle.X = MousePoint.X;
            m_MouseRectangle.Y = MousePoint.Y;
            m_DrawStar = true;
        }
        private void MouseMove()
        {
            if (m_DrawStar)
            {
                ControlPaint.DrawReversibleFrame(m_MouseRectangle, Color.Transparent, FrameStyle.Dashed);
                m_MouseRectangle.Width = MousePoint.X - m_MouseRectangle.X;
                m_MouseRectangle.Height = MousePoint.Y - m_MouseRectangle.Y;
                ControlPaint.DrawReversibleFrame(m_MouseRectangle, Color.White, FrameStyle.Dashed);
            }
        }
        private void MouseUp()
        {
            ControlPaint.DrawReversibleFrame(m_MouseRectangle, Color.Transparent, FrameStyle.Dashed);
            m_DrawStar = false;
            m_StarMouse = false;
            Rectangle _ScreenRectangle = GetUprightRectangle(m_MouseRectangle);
            m_MouseRectangle.X = 0;
            m_MouseRectangle.Y = 0;
            m_MouseRectangle.Width = 0;
            m_MouseRectangle.Height = 0;
            if (GetScreenImage != null)
            {
                if (_ScreenRectangle.Width != 0 && _ScreenRectangle.Height != 0) GetScreenImage(m_Image.Clone(_ScreenRectangle, m_Image.PixelFormat));
            }
        }
        private bool m_StarMouse = false;
        /// <summary>
        /// 获取图形
        /// </summary>
        public void GerScreenFormRectangle()
        {
            m_Image = ScreenImage;
            m_StarMouse = true;
        }
        /// <summary>
        /// 获取图形
        /// </summary>
        public void GetScreen()
        {
            if (GetScreenImage != null) GetScreenImage(ScreenImage);
        }
    }
    /// <summary>
    /// 用钩子获取消息
    /// zgke@Sina.com
    /// </summary>
    public class HookMessage
    {
        private IntPtr m_HookEx;
        /// <summary>
        /// 设置自己进程的钩子
        /// </summary>
        /// <param name="p_HookCodes">钩子类型</param>
        public HookMessage(API.WindowsHookCodes p_HookCodes)
        {
            m_HookEx = API.SetWindowsHookEx((int)p_HookCodes, new API.HookProc(SetHookProc), IntPtr.Zero, API.GetCurrentThreadId());
        }
        /// <summary>
        /// 设置进程的钩子
        /// </summary>
        /// <param name="p_HookCodes">钩子类型</param>
        /// <param name="p_ThreadID">全局钩子</param>
        public HookMessage(API.WindowsHookCodes p_HookCodes, bool p_Zero)
        {
            IntPtr _Value = System.Runtime.InteropServices.Marshal.GetHINSTANCE(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0]);
            m_HookEx = API.SetWindowsHookEx((int)p_HookCodes, new API.HookProc(SetHookProc), _Value, 0);
        }
        /// <summary>
        /// 关闭钩子
        /// </summary>
        public void UnHookMessage()
        {
            if (API.UnhookWindowsHookEx(m_HookEx))
            {
                m_HookEx = IntPtr.Zero;
            }
        }
        public delegate void GetHookMessage(int p_Code, IntPtr p_wParam, IntPtr p_lParam, ref bool p_Send);
        public event GetHookMessage GetHook;
        private IntPtr SetHookProc(int p_Code, IntPtr p_wParam, IntPtr p_lParam)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            bool _SendMessage = true;
            if (GetHook != null) GetHook(p_Code, p_wParam, p_lParam, ref _SendMessage);
            if (!_SendMessage) return new IntPtr(1);
            return IntPtr.Zero;
        }
    }
}
