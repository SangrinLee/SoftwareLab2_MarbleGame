using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace _60
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool ServerConnected = false;
        private bool Client0Connected = false;
        private bool Client1Connected = false;
        private bool Client2Connected = false;
        private bool Client3Connected = false;
        private const int PORT = 2002;
        private int PLAYERS;
        private int isNum;

        private string player_num;//추가.

        private NetworkStream[] Stream;
        private StreamReader[] Reader;
        private StreamWriter[] Writer;
        private Thread[] ClientThread;
        private Socket[] HostClient;
        private Thread ServerThread;
        private TcpListener Listener;
        
        private delegate void Receive();
        private Receive[] function = new Receive[4];
        
        public void ServerStart()
        {
            function[0] = new Receive(Receive0);
            function[1] = new Receive(Receive1);
            function[2] = new Receive(Receive2);
            function[3] = new Receive(Receive3);

            Stream = new NetworkStream[PLAYERS];
            Reader = new StreamReader[PLAYERS];
            Writer = new StreamWriter[PLAYERS];
            ClientThread = new Thread[PLAYERS];
            HostClient = new Socket[PLAYERS];
            try
            {
                ServerConnected = true;
                Listener = new TcpListener(PORT);
                Listener.Start();
                StateMessage(PLAYERS + " 명의 플레이어를 기다리고 있습니다!");

                while (ServerConnected)
                {
                    for (int i = 0; i < PLAYERS; i++)
                    {
                        HostClient[i] = Listener.AcceptSocket();
                        if (HostClient[i].Connected)
                        {
                            StateMessage("플레이어" + i+1 + " 님이 접속하셨습니다!");
                            Stream[i] = new NetworkStream(HostClient[i]);
                            Reader[i] = new StreamReader(Stream[i]);
                            Writer[i] = new StreamWriter(Stream[i]);
                            ClientThread[i] = new Thread(new ThreadStart(function[i]));
                            ClientThread[i].Start();
                            try
                            {
                                Writer[i].WriteLine(player_num);
                                Writer[i].Flush();
                            }
                            catch
                            {

                            }
                        }
                    }
                    StateMessage("게임을 시작하겠습니다!");
                }
            }
            catch
            {
                StateMessage("서버 에러!");
                return;
            }
        }

        public void ServerStop()
        {
            if (!ServerConnected)
                return;
            
            for (int i = 0; i < PLAYERS; i++)
            {
                HostClient[i].Close();
                Stream[i].Close();
                Reader[i].Close();
                Writer[i].Close();
                ClientThread[i].Abort();
            }
            Listener.Stop();
            ServerThread.Abort();
            StateMessage("서비스가 종료되었습니다.");
        }

        public void Receive0()
        {
            try
            {
                while (true)
                {
                    string szMessage = Reader[0].ReadLine();
                    if (szMessage != null)
                        StateMessage("플레이어1 >>> : " + szMessage);
                    if (Client1Connected)
                    {
                        if (int.TryParse(szMessage, out isNum))
                        {
                            Writer[1].WriteLine(szMessage);
                            Writer[1].Flush();
                        }
                        else
                        {
                            Writer[1].WriteLine("플레이어1 >>> : " + szMessage);
                            Writer[1].Flush();
                        }
                    }
                    if (Client2Connected)
                    {
                        if (int.TryParse(szMessage, out isNum))
                        {
                            Writer[2].WriteLine(szMessage);
                            Writer[2].Flush();
                        }
                        else
                        {
                            Writer[2].WriteLine("플레이어1 >>> : " + szMessage);
                            Writer[2].Flush();
                        }
                    }
                    if (Client3Connected)
                    {
                        if (int.TryParse(szMessage, out isNum))
                        {
                            Writer[3].WriteLine(szMessage);
                            Writer[3].Flush();
                        }
                        else
                        {
                            Writer[3].WriteLine("플레이어1 >>> : " + szMessage);
                            Writer[3].Flush();
                        }
                    }
                    szMessage = null;
                }
            }
            catch
            {
                StateMessage("데이터를 읽는 과정에서 오류가 발생하였습니다.");
            }
        }

        public void Receive1()
        {
            try
            {
                while (true)
                {
                    string szMessage2 = Reader[1].ReadLine();
                    if (szMessage2 != null)
                        StateMessage("플레이어2 >>> : " + szMessage2);
                    if (Client0Connected)
                    {
                        if (int.TryParse(szMessage2, out isNum))
                        {
                            Writer[0].WriteLine(szMessage2);
                            Writer[0].Flush();
                        }
                        else
                        {
                            Writer[0].WriteLine("플레이어2 >>> : " + szMessage2);
                            Writer[0].Flush();
                        }
                    }
                    if (Client2Connected)
                    {
                        if (int.TryParse(szMessage2, out isNum))
                        {
                            Writer[2].WriteLine(szMessage2);
                            Writer[2].Flush();
                        }
                        else
                        {
                            Writer[2].WriteLine("플레이어2 >>> : " + szMessage2);
                            Writer[2].Flush();
                        }
                    }
                    if (Client3Connected)
                    {
                        if (int.TryParse(szMessage2, out isNum))
                        {
                            Writer[3].WriteLine(szMessage2);
                            Writer[3].Flush();
                        }
                        else
                        {
                            Writer[3].WriteLine("플레이어2 >>> : " + szMessage2);
                            Writer[3].Flush();
                        }
                    }
                    szMessage2 = null;
                }
            }
            catch
            {
                StateMessage("데이터를 읽는 과정에서 오류가 발생하였습니다.");
            }
        }

        public void Receive2()
        {
            try
            {
                while (true)
                {

                    string szMessage3 = Reader[2].ReadLine();
                    if (szMessage3 != null)
                        StateMessage("플레이어3 >>> : " + szMessage3);
                    if (Client0Connected)
                    {
                        if (int.TryParse(szMessage3, out isNum))
                        {
                            Writer[0].WriteLine(szMessage3);
                            Writer[0].Flush();
                        }
                        else
                        {
                            Writer[0].WriteLine("플레이어3 >>> : " + szMessage3);
                            Writer[0].Flush();
                        }
                    }
                    if (Client2Connected)
                    {
                        if (int.TryParse(szMessage3, out isNum))
                        {
                            Writer[1].WriteLine(szMessage3);
                            Writer[1].Flush();
                        }
                        else
                        {
                            Writer[1].WriteLine("플레이어3 >>> : " + szMessage3);
                            Writer[1].Flush();
                        }
                    }
                    if (Client3Connected)
                    {
                        if (int.TryParse(szMessage3, out isNum))
                        {
                            Writer[3].WriteLine(szMessage3);
                            Writer[3].Flush();
                        }
                        else
                        {
                            Writer[3].WriteLine("플레이어3 >>> : " + szMessage3);
                            Writer[3].Flush();
                        }
                    }
                    szMessage3 = null;
                }
            }
            catch
            {
                StateMessage("데이터를 읽는 과정에서 오류가 발생하였습니다.");
            }
        }

        public void Receive3()
        {
            try
            {
                while (true)
                {

                    string szMessage4 = Reader[3].ReadLine();
                    if (szMessage4 != null)
                        StateMessage("플레이어4 >>> : " + szMessage4);
                    if (Client0Connected)
                    {
                        if (int.TryParse(szMessage4, out isNum))
                        {
                            Writer[0].WriteLine(szMessage4);
                            Writer[0].Flush();
                        }
                        else
                        {
                            Writer[0].WriteLine("플레이어4 >>> : " + szMessage4);
                            Writer[0].Flush();
                        }
                    }
                    if (Client2Connected)
                    {
                        if (int.TryParse(szMessage4, out isNum))
                        {
                            Writer[1].WriteLine(szMessage4);
                            Writer[1].Flush();
                        }
                        else
                        {
                            Writer[1].WriteLine("플레이어4 >>> : " + szMessage4);
                            Writer[1].Flush();
                        }
                    }
                    if (Client3Connected)
                    {
                        if (int.TryParse(szMessage4, out isNum))
                        {
                            Writer[2].WriteLine(szMessage4);
                            Writer[2].Flush();
                        }
                        else
                        {
                            Writer[2].WriteLine("플레이어4 >>> : " + szMessage4);
                            Writer[2].Flush();
                        }
                    }
                    szMessage4 = null;
                }
            }
            catch
            {
                StateMessage("데이터를 읽는 과정에서 오류가 발생하였습니다.");
            }
        }

        public void Send()
        {
            try
            {
                if (Client0Connected)
                {
                    Writer[0].WriteLine("서버 >>> : " + send_text.Text);
                    Writer[0].Flush();
                }
                if (Client1Connected)
                {
                    Writer[1].WriteLine("서버 >>> : " + send_text.Text);
                    Writer[1].Flush();
                }
                if (Client2Connected)
                {
                    Writer[2].WriteLine("서버 >>> : " + send_text.Text);
                    Writer[2].Flush();
                }
                if (Client3Connected)
                {
                    Writer[3].WriteLine("서버 >>> : " + send_text.Text);
                    Writer[3].Flush();
                }
                ChatMessage("서버 >>> : " + send_text.Text);
                send_text.Text = "";
            }
            catch
            {
                StateMessage("데이터 보내기 실패!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServerStop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (single_mode.Checked)
            {
                PLAYERS = 1;
                player_num = "one";
                Client0Connected = true;
            }
            else if (multi2_mode.Checked)
            {
                PLAYERS = 2;
                player_num = "two";
                Client0Connected = true;
                Client1Connected = true;
            }
            else if (multi3_mode.Checked)
            {
                PLAYERS = 3;
                player_num = "three";
                Client0Connected = true;
                Client1Connected = true;
                Client2Connected = true;
            }
            else if (multi4_mode.Checked)
            {
                PLAYERS = 4;
                player_num = "four";
                Client0Connected = true;
                Client1Connected = true;
                Client2Connected = true;
                Client3Connected = true;
            }

            if (btn_Server.Text == "서버 켜기")
            {
                ServerThread = new Thread(new ThreadStart(ServerStart));
                ServerThread.Start();

                btn_Server.Text = "서버 종료";
                btn_Server.ForeColor = Color.Red;
            }
            else
            {
                ServerStop();
                btn_Server.Text = "서버 켜기";
                btn_Server.ForeColor = Color.Black;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Send();
        }

        public void StateMessage(string msg)
        {
            state_text.AppendText(msg + "\r\n");
            state_text.ScrollToCaret();
        }

        public void ChatMessage(string msg)
        {
            chat_text.AppendText(msg + "\r\n");
            chat_text.ScrollToCaret();

            send_text.Focus();
        }
    }
}