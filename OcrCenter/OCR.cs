using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using asprise_ocr_api;
using asprise_ocr_dll_bundle_64;
using asprise_ocr_dll_bundle_32;

namespace OcrCenter
{
    public partial class OCR : Form
    {
        public OCR()
        {
            InitializeComponent();
        }

        private void ReadTarget_Click(object sender, EventArgs e)
        {
            PBOCR.Value = 0;
            PBOCR.Step = 1;
            System.Threading.Thread importThread = new System.Threading.Thread(new ThreadStart(GetFileDocument));
            importThread.SetApartmentState(ApartmentState.STA); //重点
            importThread.Start();
            PBOCR.Value = 10;
        }
        private void GetFileDocument()
        {
            CheckForIllegalCrossThreadCalls = false;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图片 文件(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|PDF文件(*.PDF)|*.PDF|All files (*.*)|*.*";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.InitialDirectory = "C:\\Users\\Administrator\\Desktop";
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                FilePath.Text = openFileDialog.FileName;
                PBOCR.Value = 20;
                TranslateFile();
            }
            else
            {
                PBOCR.Value = 100;
            }
        }
        private void TranslateFile()
        {
            AspriseOCR.SetUp();
            AspriseOCR ocr = new AspriseOCR();
            PBOCR.Value = 30;
            ocr.StartEngine("eng", AspriseOCR.SPEED_FASTEST);
            string file = FilePath.Text; // ☜ jpg, gif, tif, pdf, etc.
            string Result = ocr.Recognize(file, -1, -1, -1, -1, -1, AspriseOCR.RECOGNIZE_TYPE_ALL, AspriseOCR.OUTPUT_FORMAT_PLAINTEXT);
            Console.WriteLine("Result: " + Result);
            ocr.StopEngine();
            PBOCR.Value = 90;
            ResultTest.Text = Result;
            PBOCR.Value = 100;
        }

        private void OCR_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            System.Environment.Exit(0);
        }
    }
}
