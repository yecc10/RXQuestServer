using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronOcr.Languages;
using IronOcr;
using System.Threading;

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
            System.Threading.Thread importThread = new System.Threading.Thread(new ThreadStart(GetFileDocument));
            importThread.SetApartmentState(ApartmentState.STA); //重点
            importThread.Start();
        }
        private void GetFileDocument()
        {
            CheckForIllegalCrossThreadCalls = false;
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                FilePath.Text = openFileDialog.FileName;
                TranslateFile();
            }
        }
        private void TranslateFile()
        {
            var Ocr = new IronOcr.AdvancedOcr();
            {
                Ocr.CleanBackgroundNoise = true;
                Ocr.EnhanceContrast = true;
                Ocr.EnhanceResolution = true;
                Ocr.Language = IronOcr.Languages.MultiLanguage.OcrLanguagePack(IronOcr.Languages.English.OcrLanguagePack, IronOcr.Languages.ChineseSimplified.OcrLanguagePack);
                Ocr.Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced;
                Ocr.ColorSpace = AdvancedOcr.OcrColorSpace.Color;
                Ocr.DetectWhiteTextOnDarkBackgrounds = true;
                Ocr.InputImageType = AdvancedOcr.InputTypes.AutoDetect;
                Ocr.RotateAndStraighten = true;
                Ocr.ReadBarCodes = true;
                Ocr.ColorDepth = 4;
            }
            string Path = string.Empty;
            var Result = Ocr.Read(@FilePath.Text);
            ResultTest.Text = Result.Text;
        }
    }
}
