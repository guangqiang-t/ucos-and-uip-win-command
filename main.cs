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
        SimpleScoketTcpConnect s = new SimpleScoketTcpConnect("192.168.0.112", 8080);
        bool SimpleScoketTcpConnectAutoSend = false;
        FileStream fs = null;
        string FilePath = "Receive.log";
        int cnt = 0;
        Color rgb_led = new Color();
        Color b_color = new Color();
        public FormMain()
        {
            InitializeComponent();
            rgb_led = Color.FromArgb(0);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            fs = File.Open(FilePath, FileMode.Append, FileAccess.Write);
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
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar))
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
                    timerAutoSend.Enabled = false;
                    SimpleScoketTcpConnectAutoSend = false;
                    buttonAutoSend.ForeColor = Color.Black;
                    buttonAutoSend.Text = "AutoSend";
                }
                else
                {
                    timerAutoSend.Enabled = true;
                    SimpleScoketTcpConnectAutoSend = true;
                    buttonAutoSend.ForeColor = Color.Red;
                    buttonAutoSend.Text = "Stop";
                }
            }
            else
            {
                MessageBox.Show("No Connection(s)","Warnning");
            }
        }

        private void timerAutoSend_Tick(object sender, EventArgs e)
        {
			    if (SimpleScoketTcpConnectAutoSend)
                 {
                    string rx, rx1;
                    s.TcpSendData("#This is" + (cnt++.ToString()) + "times Send" + "\n");
                    rx = s.TcpReceiveData();
                    rx1 = (DateTime.Now.ToString() + " Received: " + rx + Environment.NewLine);
                    textBoxReceiveBuffer.AppendText(rx1);
                    if (cnt < 65530)
                    {
                        fs.Write(Encoding.ASCII.GetBytes(rx1), 0, rx1.Length);
                        fs.Flush();
                    }
                    else
                    {
                        fs.Close();
                        System.Environment.Exit(0);
                    }
                 }    
        }


        private void trackBarPWM_MouseUp(object sender, MouseEventArgs e)
        {
            s.TcpSendData("SYS:LED:"+trackBarLed.Value.ToString()+"\0");
            //MessageBox.Show("SYS: LED:"+trackBarLedPWM.Value.ToString());
            textBoxReceiveBuffer.AppendText(DateTime.Now.ToString() + " Received: \n" + Environment.NewLine + s.TcpReceiveData() + "\n");
        }

        private void trackBarPWM_ValueChanged(object sender, EventArgs e)
        {
            if(s._isLink)
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
                rgb_led= colorDialogColorLed.Color;
                //MessageBox.Show(rgb_led.R.ToString());
                b_color = Color.FromArgb(rgb_led.ToArgb());
                buttonColorSelect.BackColor = b_color;//back color 

                /*if (b_color.ToArgb() == 0)
                {
                    buttonColorSelect.ForeColor = Color.FromArgb(0xFFFFFF);
                }*/

                buttonColorSelect.ForeColor = Color.FromArgb(0xFFFFFF-rgb_led.ToArgb());
            }
            else
            {

            }
        }

        private void buttonColorLed_Click(object sender, EventArgs e)
        {
            if (s._isLink)
            {
                s.TcpSendData("SYS:COLOR:" + rgb_led.R.ToString()+","+rgb_led.G.ToString() + "," + rgb_led.B.ToString()  + "\0");
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
                s.TcpSendData("SYS:RELAY_LK:"+ my_check_box_relay_lk.Checked+ "\0" );
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
                s.TcpSendData("SYS:RELAY_HK:"+ my_check_box_relay_hk.Checked+ "\0" );
                //MessageBox.Show("SYS:RELAY_HK:" + my_check_box_relay_hk.Checked.ToString());
                textBoxReceiveBuffer.AppendText(DateTime.Now.ToString() + " Received: \n" + Environment.NewLine + s.TcpReceiveData() + "\n");
            }
            else
            {
                MessageBox.Show("No Connection(s)", "Warnning");
            }
        }

    }
}

