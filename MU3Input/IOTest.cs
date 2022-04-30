using System;
using System.Drawing;
using System.Windows.Forms;

namespace MU3Input
{
    public partial class IOTest : Form
    {
        private HidIO _io;

        private CheckBox[] _left;
        private CheckBox[] _right;
        bool testDown = false;
        private object _data;

        public IOTest(HidIO io)
        {
            InitializeComponent();

            _left = new[] {
                lA,
                lB,
                lC,
                lS,
                lM,
            };

            _right = new[] {
                rA,
                rB,
                rC,
                rS,
                rM,
            };

            _io = io;
        }
        
        public static byte[] StringToByteArray(string hex)
        {
            var numberChars = hex.Length;
            var bytes = new byte[numberChars / 2];
            for (var i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        internal void UpdateData()
        {
            if (!Enabled && Handle == IntPtr.Zero) return;

            try
            {
                BeginInvoke(new Action(() =>
                {
                    lblStatus.Text = _io.IsConnected ? "Nageki 已连接" : "Nageki 未连接";

                    if (!_io.IsConnected) return;

                    for (var i = 0; i < 5; i++)
                    {
                        if (i == 3)
                        {
                            _left[i].Checked = (Convert.ToBoolean(_io.Data.Buttons[i]));
                            _right[i].Checked = (Convert.ToBoolean(_io.Data.Buttons[i + 5]));
                        }
                        else
                        {
                            _left[i].Checked = Convert.ToBoolean(_io.Data.Buttons[i]);
                            _right[i].Checked = Convert.ToBoolean(_io.Data.Buttons[i + 5]);
                        }

                    }


                    trackBar1.Value = _io.Lever;

                    if (_io.Scan)
                    {
                        textAimiId.Text = BitConverter.ToString(_io.AimiId).Replace("-", "");
                    }
                }));
            }
            catch
            {
                // ignored
            }
        }
        
        public void SetColor(uint data)
        {
            try
            {
                BeginInvoke(new Action(() =>
                {
                    _left[0].BackColor = Color.FromArgb(
                        (int)((data >> 23) & 1) * 255,
                        (int)((data >> 19) & 1) * 255,
                        (int)((data >> 22) & 1) * 255
                    );
                    _left[1].BackColor = Color.FromArgb(
                        (int)((data >> 20) & 1) * 255,
                        (int)((data >> 21) & 1) * 255,
                        (int)((data >> 18) & 1) * 255
                    );
                    _left[2].BackColor = Color.FromArgb(
                        (int)((data >> 17) & 1) * 255,
                        (int)((data >> 16) & 1) * 255,
                        (int)((data >> 15) & 1) * 255
                    );
                    _right[0].BackColor = Color.FromArgb(
                        (int)((data >> 14) & 1) * 255,
                        (int)((data >> 13) & 1) * 255,
                        (int)((data >> 12) & 1) * 255
                    );
                    _right[1].BackColor = Color.FromArgb(
                        (int)((data >> 11) & 1) * 255,
                        (int)((data >> 10) & 1) * 255,
                        (int)((data >> 9) & 1) * 255
                    );
                    _right[2].BackColor = Color.FromArgb(
                        (int)((data >> 8) & 1) * 255,
                        (int)((data >> 7) & 1) * 255,
                        (int)((data >> 6) & 1) * 255
                    );
                }));
            }
            catch
            {
                // ignored
            }
        }
        


    private void btnSetOption_Click(object sender, EventArgs e)
        {
            byte[] aimiId;
            
            try
            {
                aimiId = StringToByteArray(textAimiId.Text);
            }
            catch
            {
                MessageBox.Show("无效卡号，卡号需要20个数字组成.", "错误");
                return;
            }
            
            if (aimiId.Length != 10)
            {
                MessageBox.Show("无效卡号，卡号需要20个数字组成.");
                return;
            }

            if (aimiId.Length != 20)
            {
                MessageBox.Show("已写入卡号，请长按两个menu刷卡.");
                return;
            }

            _io.SetAimiId(aimiId);
        }

        

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void rB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void IOTest_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        private void Test_Click(object sender, EventArgs e)
        {

        }

        private void Service_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lA_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rA_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            _io.TestButton = 1;
            return;

        }

        private void rC_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void lB_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Test2_Click(object sender, EventArgs e)
        {
            _io.TestButton = 2;
            return;
        }

        private void Test3_Click(object sender, EventArgs e)
        {
            _io.TestButton = 3;
            return;
        }

        private void lS_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textAimiId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
        }
    }
}
