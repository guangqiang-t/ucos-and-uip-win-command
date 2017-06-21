using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleScoketTcp;
using System.IO;
using System.Threading;

namespace WinCommand
{
    public partial class FormMain : Form
    {
        SimpleScoketTcpConnect s = new SimpleScoketTcpConnect("192.168.0.128", 8080);
        bool SimpleScoketTcpConnectAutoSend = false;
        FileStream fs = null;
        string FilePath = "SYS.log";
        //int cnt = 0;
        int g_temp = 0;
        byte[] logic = new byte[5];
        Color rgb_led = new Color();
        Color b_color = new Color();
        public FormMain()
        {
            InitializeComponent();
            rgb_led = Color.FromArgb(0);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //fs = File.Open(FilePath, FileMode.Append, FileAccess.Write);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Connect to Sever 
            if (!s._isLink)
            {
                s.TcpSetIP(textBoxSeverIP.Text.ToString());
                s.TcpSetPort(int.Parse(textBoxSeverPort.Text.ToString()));
                s.TcpConnectToSever();
                //textBoxReceiveBuffer.AppendText(DateTime.Now.ToString() + " Received: \n" + Environment.NewLine + s.TcpReceiveData() + "\n");
                //s.TcpSendData("AccessibleDefaultActionDescription");
            }
            else
            {
                s.TcpDisConnectToSever(3);
            }
            //status
            if (s._isLink)
            {
                buttonConnect.Text = "DisConnect";
                labelIsLink.ForeColor = Color.DarkGreen;
                labelIsLink.Text = "Connected!";
            }
            else
            {
                buttonConnect.Text = "Connect";
                labelIsLink.ForeColor = Color.DarkRed;
                labelIsLink.Text = "DisConnected!";
            }

        }

        private void textBoxSeverPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar))// 8 isbackspace
            {
                e.Handled = true;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (s._isLink)
            {
                s.TcpSendData(textBoxSendBuffer.Text.ToString() + "\0");
                textBoxReceiveBuffer.AppendText(DateTime.Now.ToString() + " Received: \n" + Environment.NewLine + s.TcpReceiveData() + "\n");
            }
            else
            {
                MessageBox.Show("No Connection(s)", "Warnning");
            }
        }

        private void buttonAutoSend_Click(object sender, EventArgs e)
        {
            if (s._isLink)
            {
                if (SimpleScoketTcpConnectAutoSend)
                {
                    fs.Close();
                    label1_act_temp.Text = "NO TRACE";
                    timerAutoSend.Enabled = false;
                    SimpleScoketTcpConnectAutoSend = false;
                    button_heartbeat.ForeColor = Color.Black;
                    button_heartbeat.Text = "HEARTBEAT";
                }
                else
                {
                    fs = File.Open(FilePath, FileMode.Append, FileAccess.Write);
                    timerAutoSend.Enabled = true;
                    SimpleScoketTcpConnectAutoSend = true;
                    button_heartbeat.ForeColor = Color.Red;
                    button_heartbeat.Text = "STOP";
                }
            }
            else
            {
                MessageBox.Show("No Connection(s)", "Warnning");
            }
        }

        private void timerAutoSend_Tick(object sender, EventArgs e)
        {
            if (SimpleScoketTcpConnectAutoSend)
            {
                string rx, rx1;
                s.TcpSendData("SYS:TEMP?\0");
                rx = s.TcpReceiveData();
                try
                {
                    string result = System.Text.RegularExpressions.Regex.Replace(rx, @"[^0-9]+", "");
                    g_temp = int.Parse(result) / 25;
                }
                catch
                {
                    ;
                }
                
                if (g_temp>= progressBarTemp.Minimum && g_temp <= progressBarTemp.Maximum)
                {
                    progressBarTemp.Value =g_temp;
                    label1_act_temp.Text = "T="+(g_temp/4.0).ToString()+ "℃";
                }
                rx1 = (DateTime.Now.ToString() + " LOG: " + rx + Environment.NewLine);
                //textBoxReceiveBuffer.AppendText(rx1);
                fs.Write(Encoding.ASCII.GetBytes(rx1), 0, rx1.Length);
                fs.Flush();
            }
        }


        private void trackBarPWM_MouseUp(object sender, MouseEventArgs e)
        {
            s.TcpSendData("SYS:LED:" + trackBarLed.Value.ToString() + "\0");
            //MessageBox.Show("SYS: LED:"+trackBarLedPWM.Value.ToString());
            textBoxReceiveBuffer.AppendText(DateTime.Now.ToString() + " Received: \n" + Environment.NewLine + s.TcpReceiveData() + "\n");
        }

        private void trackBarPWM_ValueChanged(object sender, EventArgs e)
        {
            if (s._isLink)
            {
                labelLedPwm.Text = trackBarLed.Value.ToString();
            }
            else
            {
                MessageBox.Show("No Connection(s)", "Warnning");
            }
        }

        private void trackBarMotor_ValueChanged(object sender, EventArgs e)
        {
            if (s._isLink)
            {
                labelMotorPWM.Text = trackBarMotor.Value.ToString();
            }
            else
            {
                MessageBox.Show("No Connection(s)", "Warnning");
            }
        }

        private void trackBarMotor_MouseUp(object sender, MouseEventArgs e)
        {
            s.TcpSendData("SYS:MOTOR:" + trackBarMotor.Value.ToString() + "\0");
            //MessageBox.Show("SYS: LED:"+trackBarLedPWM.Value.ToString());
            textBoxReceiveBuffer.AppendText(DateTime.Now.ToString() + " Received: \n" + Environment.NewLine + s.TcpReceiveData() + "\n");
        }

        private void buttonColorSelect_Click(object sender, EventArgs e)
        {
            if (colorDialogColorLed.ShowDialog() == DialogResult.OK)
            {
                rgb_led = colorDialogColorLed.Color;
                //MessageBox.Show(rgb_led.R.ToString());
                b_color = Color.FromArgb(rgb_led.ToArgb());
                buttonColorSelect.BackColor = b_color;//back color 

                /*if (b_color.ToArgb() == 0)
                {
                    buttonColorSelect.ForeColor = Color.FromArgb(0xFFFFFF);
                }*/

                buttonColorSelect.ForeColor = Color.FromArgb(0xFFFFFF - rgb_led.ToArgb());
            }
            else
            {

            }
        }

        private void buttonColorLed_Click(object sender, EventArgs e)
        {
            if (s._isLink)
            {
                s.TcpSendData("SYS:COLOR:" + rgb_led.R.ToString() + "," + rgb_led.G.ToString() + "," + rgb_led.B.ToString() + "\0");
                //MessageBox.Show("SYS: LED:"+trackBarLedPWM.Value.ToString());
                textBoxReceiveBuffer.AppendText(DateTime.Now.ToString() + " Received: \n" + Environment.NewLine + s.TcpReceiveData() + "\n");
            }
            else
            {
                MessageBox.Show("No Connection(s)", "Warnning");
            }
        }

        private void my_check_box_relay_lk_click(object sender, EventArgs e)
        {
            if (s._isLink)
            {
                s.TcpSendData("SYS:RELAY_LK:" + my_check_box_relay_lk.Checked + "\0");
                //MessageBox.Show("SYS:RELAY_LK:" + my_check_box_relay_lk.Checked.ToString());
                textBoxReceiveBuffer.AppendText(DateTime.Now.ToString() + " Received: \n" + Environment.NewLine + s.TcpReceiveData() + "\n");
            }
            else
            {
                MessageBox.Show("No Connection(s)", "Warnning");
            }
        }

        private void my_check_box_relay_hk_Click(object sender, EventArgs e)
        {
            if (s._isLink)
            {
                s.TcpSendData("SYS:RELAY_HK:" + my_check_box_relay_hk.Checked + "\0");
                //MessageBox.Show("SYS:RELAY_HK:" + my_check_box_relay_hk.Checked.ToString());
                textBoxReceiveBuffer.AppendText(DateTime.Now.ToString() + " Received: \n" + Environment.NewLine + s.TcpReceiveData() + "\n");
            }
            else
            {
                MessageBox.Show("No Connection(s)", "Warnning");
            }
        }

        private void textBoxSeverIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '.' && e.KeyChar != 8 && !char.IsDigit(e.KeyChar))// 8 isbackspace
            {
                e.Handled = true;
            }
        }

        private void checkBoxbit7_Click(object sender, EventArgs e)
        {
            if (s._isLink)
            {
                sync_r();
            }
            else
            {
                MessageBox.Show("No Connection(s)", "Warnning");
            }
        }

        private void checkBoxbit6_Click(object sender, EventArgs e)
        {
            if (s._isLink)
            {
                sync_r();
            }
            else
            {
                MessageBox.Show("No Connection(s)", "Warnning");
            }
        }

        private void checkBoxbit5_Click(object sender, EventArgs e)
        {
            if (s._isLink)
            {
                sync_r();
            }
            else
            {
                MessageBox.Show("No Connection(s)", "Warnning");
            }
        }

        private void checkBoxbit4_Click(object sender, EventArgs e)
        {
            if (s._isLink)
            {
                sync_r();
            }
            else
            {
                MessageBox.Show("No Connection(s)", "Warnning");
            }
        }

        private void checkBoxbit3_Click(object sender, EventArgs e)
        {
            if (s._isLink)
            {
                sync_r();
            }
            else
            {
                MessageBox.Show("No Connection(s)", "Warnning");
            }
        }

        private void checkBoxbit2_Click(object sender, EventArgs e)
        {
            if (s._isLink)
            {
                sync_r();
            }
            else
            {
                MessageBox.Show("No Connection(s)", "Warnning");
            }
        }

        private void checkBoxbit1_Click(object sender, EventArgs e)
        {
            if (s._isLink)
            {
                sync_r();
            }
            else
            {
                MessageBox.Show("No Connection(s)", "Warnning");
            }
        }

        private void checkBoxbit0_Click(object sender, EventArgs e)
        {
            if (s._isLink)
            {
                sync_r();
            }
            else
            {
                MessageBox.Show("No Connection(s)", "Warnning");
            }
        }

        private void sync_r()
        {
            logic[0] = 0;
            if (checkBoxbit7.Checked == true) logic[0] += 128;
            if (checkBoxbit6.Checked == true) logic[0] += 64;
            if (checkBoxbit5.Checked == true) logic[0] += 32;
            if (checkBoxbit4.Checked == true) logic[0] += 16;
            if (checkBoxbit3.Checked == true) logic[0] += 8;
            if (checkBoxbit2.Checked == true) logic[0] += 4;
            if (checkBoxbit1.Checked == true) logic[0] += 2;
            if (checkBoxbit0.Checked == true) logic[0] += 1;
            textBoxlog0.Text = logic[0].ToString();
        }
        private void sync_l()
        {
            try
            {
                if (textBoxlog0.Text == "")
                {
                    logic[0] = 0;
                }
                else
                {
                    logic[0] = byte.Parse(textBoxlog0.Text);
                }
            }
            catch
            {
                MessageBox.Show("Wrong Number!", "Warnning");
                textBoxlog0.Text = "";
            }
            int tmp = logic[0];
            if (tmp >= 128) { checkBoxbit7.Checked = true; tmp -= 128; } else { checkBoxbit7.Checked = false; }
            if (tmp >= 64) { checkBoxbit6.Checked = true; tmp -= 64; } else { checkBoxbit6.Checked = false; }
            if (tmp >= 32) { checkBoxbit5.Checked = true; tmp -= 32; } else { checkBoxbit5.Checked = false; }
            if (tmp >= 16) { checkBoxbit4.Checked = true; tmp -= 16; } else { checkBoxbit4.Checked = false; }
            if (tmp >= 8) { checkBoxbit3.Checked = true; tmp -= 8; } else { checkBoxbit3.Checked = false; }
            if (tmp >= 4) { checkBoxbit2.Checked = true; tmp -= 4; } else { checkBoxbit2.Checked = false; }
            if (tmp >= 2) { checkBoxbit1.Checked = true; tmp -= 2; } else { checkBoxbit1.Checked = false; }
            if (tmp >= 1) { checkBoxbit0.Checked = true; tmp -= 1; } else { checkBoxbit0.Checked = false; }

        }

        private void textBoxlog0_TextChanged(object sender, EventArgs e)
        {
            sync_l();
        }
        private void all_reset()
        {

        }

        private void textBoxlog1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar))// 8 isbackspace
            {
                e.Handled = true;
            }
        }

        private void textBoxlog2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar))// 8 isbackspace
            {
                e.Handled = true;
            }
        }

        private void textBoxlog3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar))// 8 isbackspace
            {
                e.Handled = true;
            }
        }

        private void textBoxlog4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar))// 8 isbackspace
            {
                e.Handled = true;
            }
        }

        private void textBoxlog1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxlog1.Text == "")
                {
                    logic[1] = 0;
                }
                else
                {
                    logic[1] = byte.Parse(textBoxlog1.Text);
                }
            }
            catch
            {
                MessageBox.Show("Wrong Number!", "Warnning");
                textBoxlog1.Text = "";
            }
        }

        private void textBoxlog2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxlog2.Text == "")
                {
                    logic[2] = 0;
                }
                else
                {
                    logic[2] = byte.Parse(textBoxlog2.Text);
                }
            }
            catch
            {
                MessageBox.Show("Wrong Number!", "Warnning");
                textBoxlog2.Text = "";
            }
        }

        private void textBoxlog3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxlog3.Text == "")
                {
                    logic[3] = 0;
                }
                else
                {
                    logic[3] = byte.Parse(textBoxlog3.Text);
                }
            }
            catch
            {
                MessageBox.Show("Wrong Number!", "Warnning");
                textBoxlog3.Text = "";
            }
        }

        private void textBoxlog4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxlog4.Text == "")
                {
                    logic[4] = 0;
                }
                else
                {
                    logic[4] = byte.Parse(textBoxlog4.Text);
                }
            }
            catch
            {
                MessageBox.Show("Wrong Number!", "Warnning");
                textBoxlog4.Text = "";
            }
        }

        private void textBoxlog0_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar))// 8 isbackspace
            {
                e.Handled = true;
            }
        }

        private void button_logic_sync_Click(object sender, EventArgs e)
        {
            int n = 5;
            if (textBoxlog4.Text != "")
            {
                n = 5;
            }
            else if (textBoxlog3.Text != "")
            {
                n = 4;
            }
            else if (textBoxlog2.Text != "")
            {
                n = 3;
            }
            else if (textBoxlog1.Text != "")
            {
                n = 2;
            }
            else
            {
                n = 1;
            }

            int tmp = n-1;
            string s_tmp = "SYS:LOGIC:" + n.ToString() + ";" + logic[0].ToString();
            for( int i=1; tmp>0;tmp--)
            {
                s_tmp += "," + logic[i++].ToString();
            }
           // MessageBox.Show(s_tmp);
            s_tmp += "\0";

            s.TcpSendData(s_tmp);
            textBoxReceiveBuffer.AppendText(DateTime.Now.ToString() + " Received: \n" + Environment.NewLine + s.TcpReceiveData() + "\n");
        }

        private void FormMain_DoubleClick(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.Show();
        }

        private void groupBoxSendReceiveData_Enter(object sender, EventArgs e)
        {

        }
    }

}

