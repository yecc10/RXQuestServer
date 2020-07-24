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
            var Ocr = new IronOcr.AdvancedOcr();
            {
                Ocr.CleanBackgroundNoise = true;
                Ocr.EnhanceContrast = true;
                Ocr.EnhanceResolution = true;
                Ocr.Language = IronOcr.Languages.English.OcrLanguagePack;
                Ocr.Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced;
                Ocr.ColorSpace = AdvancedOcr.OcrColorSpace.Color;
                Ocr.DetectWhiteTextOnDarkBackgrounds = true;
                Ocr.InputImageType = AdvancedOcr.InputTypes.AutoDetect;
                Ocr.RotateAndStraighten = true;
                Ocr.ReadBarCodes = true;
                Ocr.ColorDepth = 4;
            }
            var Result = Ocr.Read(@"C:\Users\Administrator\Desktop\image.png");
            Console.WriteLine(Result.Text);
        }
    }
}
