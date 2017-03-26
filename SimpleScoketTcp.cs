using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SimpleScoketTcp
{
    public class SimpleScoketTcpConnect
    {
        private string TcpSeverIP = "192.168.0.1";
        private int TcpSeverPort = 8080;
        private IPAddress ip;
        private IPEndPoint ip_end_point;
        private Socket scoket_tcp_connect;
        private bool isLink = false;
        public bool _isLink { get { return isLink; } } 

        //Great Function
        public SimpleScoketTcpConnect(String s,int port)
        {
            this.TcpSeverIP = s;
            this.TcpSeverPort = port;
        }

        public void TcpSetIP(String s)
        {
            this.TcpSeverIP = s;
        }
        public void TcpSetPort(int port)
        {
            this.TcpSeverPort = port; ;
        }
        public string TcpGetSeverInformations()
        {
            return (this.TcpSeverIP + ":"+this.TcpSeverPort.ToString());
        }

        //Config to Connect
        public bool TcpConnectToSever()
        {
            try
            {
                this.ip = IPAddress.Parse(this.TcpSeverIP);
                this.ip_end_point = new IPEndPoint(this.ip, this.TcpSeverPort);
            }
            catch
            {
                MessageBox.Show("Invalid parameter! ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            this.scoket_tcp_connect = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建Socket
            try
            {
                this.scoket_tcp_connect.Connect(ip_end_point);
            }
            catch (System.Net.Sockets.SocketException e)
            {
                MessageBox.Show(e.Message.ToString() + "\r\nError Code:" + e.ErrorCode.ToString(),"Warnning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            this.isLink = true;
            return true;
        }
        public bool TcpConnectToSever(string ip,int port)
        {
            this.TcpSetIP(ip);
            this.TcpSetPort(port);
            this.ip = IPAddress.Parse(this.TcpSeverIP);
            this.ip_end_point = new IPEndPoint(this.ip, this.TcpSeverPort);
            this.scoket_tcp_connect = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建Socket
            try
            {
                this.scoket_tcp_connect.Connect(ip_end_point);
            }
            catch (System.Net.Sockets.SocketException e)
            {
                MessageBox.Show(e.Message.ToString() + "\r\nError Code:" + e.ErrorCode.ToString(), "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            this.isLink = true;
            return true;
        }
        public bool TcpDisConnectToSever()
        {
            try
            {
                this.scoket_tcp_connect.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            this.isLink = false;
            return true;

        }
        public bool TcpDisConnectToSever(int timeout)
        {
            try
            {
                this.scoket_tcp_connect.Close(timeout);
            }
            catch (Exception e)
            {
                return false;
            }
            this.isLink = false;
            return true;

        }
        // Send or Receive Data 
        public bool TcpSendData(string s)
        {
            try
            {
                byte[] SendBuffer = Encoding.ASCII.GetBytes(s);
                scoket_tcp_connect.Send(SendBuffer, SendBuffer.Length, 0);
            }
            catch (System.NullReferenceException e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
            return true;
        }
        public string TcpReceiveData()
        {
            byte[] temp = new byte[128];
            string ReceiveStr = "";
            int cnt = 0;
            try
            {
                cnt = scoket_tcp_connect.Receive(temp, temp.Length, SocketFlags.None);
                Console.WriteLine(cnt);
            }
            catch (System.NullReferenceException e)
            {
                return "Receive ERROR ";
            }
            if (cnt != 0)
            {
                ReceiveStr += Encoding.ASCII.GetString(temp, 0, cnt);
                return ReceiveStr;
            }
            else
            {
                return "NO DATA ";
            }

        }
    }
}
