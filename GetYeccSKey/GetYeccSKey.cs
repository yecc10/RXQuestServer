using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetYeccSKey
{
    public partial class GetYeccSKey : Form
    {
        public GetYeccSKey()
        {
            InitializeComponent();
        }

        private void GetUserKey_Click(object sender, EventArgs e)
        {
            if (UserApplicatCode.Text.Trim() != string.Empty)
            {
                GetUserKeyData getComputerData = new GetUserKeyData();
                var res = getComputerData.GetUsrRegKey(UserApplicatCode.Text.Trim());
                if (res != string.Empty)
                {
                    KeyCode.Text = res;
                }
                else
                {
                    MessageBox.Show("申请码转换失败!");
                }
            }
            else
            {
                KeyCode.Text = "输入的为无效申请码!";
            }
        }
    }
}
