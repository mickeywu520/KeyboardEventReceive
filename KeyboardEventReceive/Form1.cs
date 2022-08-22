using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace KeyboardEventReceive
{
    public partial class Form1 : Form
    {

        // Get a handle to an application window.
        [DllImport("USER32.DLL")]
        public static extern IntPtr FindWindow(string lpClassName,
        string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        String SERVER_IP = "192.168.1.109";
        int PORT_NO = 13000;
        bool isServiceStart = false;
        Thread tcpThread = null;
        TcpListener listener = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Load_Setting();
            //tcpServer();
        }

        private void Load_Setting()
        {
            // loading save data
            //SERVER_IP = Properties.Settings.Default.SERVER_IP;
            SERVER_IP = GetLocalIPAddress();
            PORT_NO = Properties.Settings.Default.PORT_NO;

            // update UI contain
            textBox1_IP.Text = SERVER_IP;
            textBox2_PORT.Text = PORT_NO.ToString();

            // thread
            tcpThread = new Thread(tcpServer);
        }

        private void ReLoad_Setting()
        {
            if(!SERVER_IP.Equals(textBox1_IP.Text))
            {
                SERVER_IP = textBox1_IP.Text;
                Console.WriteLine("current input IP not equal dafault, so changed it : " + SERVER_IP);
            }
            if (!PORT_NO.ToString().Equals(textBox2_PORT.Text))
            {
                int i = int.Parse(textBox2_PORT.Text);
                PORT_NO = i;
                Console.WriteLine("current input PORT not equal dafault, so changed it : " + PORT_NO);
            }
        }


        private void tcpServer()
        {
            try
            {
                //---listen at the specified IP and port no.---
                System.Net.IPAddress localAdd = IPAddress.Parse(SERVER_IP);
                //TcpListener listener = new TcpListener(localAdd, PORT_NO);
                listener = new TcpListener(localAdd, PORT_NO);
                Console.WriteLine("Listening...");
                listener.Start();
                while (isServiceStart)
                {
                //---incoming client connected---
                TcpClient client = listener.AcceptTcpClient();

                //---get the incoming data through a network stream---
                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];

                //---read incoming stream---
                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                //---convert the data received into a string---
                string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received : " + dataReceived);

                // send keyboard event
                SendKeys.SendWait(dataReceived);

                //---write back the text to the client---
                /*
                Console.WriteLine("Sending back : " + dataReceived);
                nwStream.Write(buffer, 0, bytesRead);
                */
                client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                isServiceStart = false;
                listener.Stop();
                Console.WriteLine("listener stop!!");
                Console.WriteLine("thread state : " + tcpThread.ThreadState);

                if(!SERVER_IP.Equals(GetLocalIPAddress()))
                {
                    this.Invoke(new Action(() => { MessageBox.Show(this, "無效的IP, 請確認是否與主機IP一致");}));
                    this.Invoke((MethodInvoker)delegate {
                        button1_startService.Text = "Start";
                    });
                }
            }
            //listener.Stop();
            //Console.WriteLine("listener stop!!");
            Console.ReadLine();
        }

        private void button1_startService_Click(object sender, EventArgs e)
        {
            switch (tcpThread.ThreadState)
            {
                case ThreadState.Unstarted:
                    {
                        Console.WriteLine("tcpThread start");
                        button1_startService.Text = "Stop";
                        isServiceStart = true;
                        ReLoad_Setting();
                        tcpThread.Start();
                    }
                    break;

                case ThreadState.Aborted:
                case ThreadState.Stopped:
                    if (button1_startService.Text == "Start")
                    {
                        Console.WriteLine("tcpThread start");
                        button1_startService.Text = "Stop";
                        tcpThread = new Thread(tcpServer);
                        isServiceStart = true;
                        ReLoad_Setting();
                        tcpThread.Start();
                    }
                    break;

                case ThreadState.Running:
                    if (button1_startService.Text == "Stop")
                    {
                        Console.WriteLine("tcpThread stop");
                        button1_startService.Text = "Start";
                        isServiceStart = false;
                        listener.Stop();
                    }
                    break;
            }
        }
        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine("get local IP address : " + ip);
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private void Form1_Closed(object sender, System.EventArgs e)
        {
            //startServiceFlag = false;
        }

    }
}
