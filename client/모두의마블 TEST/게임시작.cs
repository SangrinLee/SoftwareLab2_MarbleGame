using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace 모두의마블_TEST
{
    public partial class 게임시작 : Form
    {
        public 게임시작()
        {
            InitializeComponent();
        }
        public int count;

        메인메뉴 메인메뉴 = new 메인메뉴();
        로그인 로그인 = new 로그인();
        랭킹정보 랭킹정보 = new 랭킹정보();
        환경설정 환경설정 = new 환경설정();
               
        public void copy(메인메뉴 copied1, 로그인 copied2, 랭킹정보 copied3, 환경설정 copied4)
        {
            this.메인메뉴 = copied1;
            this.로그인 = copied2;
            this.랭킹정보 = copied3;
            this.환경설정 = copied4;
            num.Text = 로그인.textBox1.Text;
            num2.Text = 메인메뉴.label2.Text;
        }

        지역구매 지역구매;
        통행료지불 통행료지불;

        /// <summary>
        /// //////////////////////// 소켓 통신(상태) /////////////////////////
        /// </summary>
        public NetworkStream m_Stream;
        public StreamReader m_Read;
        public StreamWriter m_Write;

        const int PORT = 2002;
        private Thread m_thReader;

        public bool m_bConnect = false;
        TcpClient m_Client;

        public void Connect()
        {
            m_Client = new TcpClient();

            try
            {
                m_Client.Connect("localhost", PORT);
            }
            catch
            {
                m_bConnect = false;
                return;
            }

            m_bConnect = true;
            Message("서버에 연결되었습니다.");

            m_Stream = m_Client.GetStream();
            m_Read = new StreamReader(m_Stream);
            m_Write = new StreamWriter(m_Stream);

            m_thReader = new Thread(new ThreadStart(Receive));
            m_thReader.Start();
        }

        public void Disconnect()
        {
            if (!m_bConnect)
                return;

            m_bConnect = false;
            m_Read.Close();
            m_Write.Close();
            m_Stream.Close();
            m_thReader.Abort();
            Message("상대편과 연결이 중단됨!");
        }

        public void Receive()
        {
            int number;
            try
            {
                while (m_bConnect)
                {
                    string szMessage = m_Read.ReadLine();
                    //if (szMessage != null)
                    //    Message("플레이어 >>> : " + szMessage);
                    if (szMessage == "one")
                        count = 1;
                    else if (szMessage == "two")
                        count = 2;
                    else if (szMessage == "three")
                        count = 3;
                    else if (szMessage == "four")
                        count = 4;
                    else if (!int.TryParse(szMessage, out number))
                    {
                        ChatMessage(szMessage);
                    }
                    else if (number >= 2 && number <= 12)
                    {
                        process(number, false);
                    }
                    else if (number == 100)
                    {
                        int position = player[current_user].position;
                        player[current_user].DrawMoney(places[position].price);
                        places[position].pass_money = places[position].land1;
                        places[position].owner = current_user + 1;

                        setColor_Land(current_user, position);
                        displayPlacesInfo();
                    }
                    else if (number == 200)
                    {
                        int position = player[current_user].position;
                        player[current_user].DrawMoney(places[position].land1);
                        places[position].pass_money += places[position].land1 + 500;

                        setColor_Villa(position);
                        displayPlacesInfo();
                    }
                    else if (number == 300)
                    {
                        int position = player[current_user].position;
                        player[current_user].DrawMoney(places[position].land1);
                        places[position].pass_money += places[position].land1 + 1000;

                        setColor_Building(position);
                        displayPlacesInfo();
                    }
                    else if (number == 400)
                    {
                        int position = player[current_user].position;
                        player[current_user].DrawMoney(places[position].land1);
                        places[position].pass_money += places[position].land1 + 1500;

                        setColor_Hotel(position);
                        displayPlacesInfo();
                    }
                }
            }
            catch
            {
                Message("데이터를 읽는 과정에서 오류가 발생하였습니다.");
            }
            Disconnect();
        }

        public void Send()
        {
            try
            {
                m_Write.WriteLine(txt_send.Text);
                m_Write.Flush();

                ChatMessage("나 >>> : " + txt_send.Text);
                txt_send.Text = "";
            }
            catch
            {
                Message("데이터 보내기 실패!");
            }
        }

        public void Message(string msg)
        {
            state_text.AppendText(msg + "\r\n");

            state_text.Focus();
            state_text.ScrollToCaret();

            txt_send.Focus();
        }

        public void ChatMessage(string msg)
        {
            chat_text.AppendText(msg + "\r\n");

            chat_text.Focus();
            chat_text.ScrollToCaret();

            txt_send.Focus();
        }
        /// <summary>
        /// ////////////////////// 소켓 통신 ///////////////////
        /// </summary>

        private void Form1_Load(object sender, EventArgs e)
        {
            Connect();
            temp.Visible = false;
            temp2.Visible = false;
            temp3.Visible = false;
            temp4.Visible = false;

            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            initPlayer();
            initPlaces();
            displayPlacesInfo();
            
            //aaa();

        }

        public void aaa()
        {
            temp.Visible = false;
            temp2.Visible = false;
            temp3.Visible = false;
            temp4.Visible = false;

            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            initPlayer();
            initPlaces();
            displayPlacesInfo();
            Connect();
        }

        public enum MoveState
        {
            BEGIN,
            RUNNING,
            DONE
        }

        public int warp = 0;

        public int num_of_player = 4;
        public int x, y;
        Player[] player;
        Places[] places;

        Point[] places_xy;
        
        public string[] places_info;
        public bool pass_by_money = true;
        public static int current_user = 0;
        public int use_turn;
        public bool bturn;
        MoveState isMoving = MoveState.BEGIN;
        public int dice1, dice2;

        public void initPlayer()
        {
            player = new Player[count];
            string[] name = new string[count];
            if (count == 1)
            {
                p1Img.Visible = true; p2Img.Visible = true; p3Img.Visible = true; p4Img.Visible = true;

                name[0] = "Player1";
            }
            else if (count == 2)
            {
                p1Img.Visible = true; p2Img.Visible = true; p3Img.Visible = false; p4Img.Visible = false;
                name[0] = "Player1";
                name[1] = "Player2";
            }
            else if (count == 3)
            {
                p1Img.Visible = true; p2Img.Visible = true; p3Img.Visible = true; p4Img.Visible = false;
                name[0] = "Player1";
                name[1] = "Player2";
                name[2] = "Player3";
            }
            else if (count == 4)
            {
                p1Img.Visible = true; p2Img.Visible = true; p3Img.Visible = true; p4Img.Visible = true;
                name[0] = "Player1";
                name[1] = "Player2";
                name[2] = "Player3";
                name[3] = "Player4";
            }

            for (int i = 0; i < count; i++)
                player[i] = new Player(name[i], 25000);
            //temp.Text = name[3];
        }

        public void initPlaces()
        {
            //button6.Text = 메인메뉴.label2.Text;
            places = new Places[28];
            places_xy = new Point[28];
            if (num2.Text == "1")    // 월드맵
            {
                places[0] = new Places("시작", 0, 0, 0, 0, 0, 0); places_xy[0] = p0.Location;
                places[1] = new Places("방콕", 500, 0, 500, 1000, 2000, 50); places_xy[1] = a1.Location;
                places[2] = new Places("베이징", 700, 0, 500, 1000, 2000, 120); places_xy[2] = a2.Location;
                places[3] = new Places("독도", 1100, 0, 500, 1000, 2000, 120); places_xy[3] = a3.Location;
                places[4] = new Places("타이페이", 1200, 0, 500, 1000, 2000, 120); places_xy[4] = a4.Location;
                places[5] = new Places("두바이", 1200, 0, 500, 1000, 2000, 120); places_xy[5] = a5.Location;
                places[6] = new Places("카이로", 1200, 0, 500, 1000, 2000, 120); places_xy[6] = a6.Location;

                places[7] = new Places("무인도", 0, 0, 0, 0, 0, 0); places_xy[7] = p7.Location;

                places[8] = new Places("발리", 1200, 0, 500, 1000, 2000, 120); places_xy[8] = b1.Location;
                places[9] = new Places("도쿄", 1200, 0, 500, 1000, 2000, 120); places_xy[9] = b2.Location;
                places[10] = new Places("시드니", 1500, 0, 500, 1000, 2000, 120); places_xy[10] = b3.Location;
                places[11] = new Places("퀘백", 1500, 0, 500, 1000, 2000, 120); places_xy[11] = b4.Location;
                places[12] = new Places("하와이", 1500, 0, 500, 1000, 2000, 120); places_xy[12] = b5.Location;
                places[13] = new Places("상파울로", 1500, 0, 500, 1000, 2000, 120); places_xy[13] = b6.Location;

                places[14] = new Places("올림픽", 0, 0, 0, 0, 0, 0); places_xy[14] = p14.Location;

                places[15] = new Places("프라하", 1500, 0, 500, 1000, 2000, 120); places_xy[15] = c1.Location;
                places[16] = new Places("푸켓", 1500, 0, 500, 1000, 2000, 120); places_xy[16] = c2.Location;
                places[17] = new Places("베를린", 1500, 0, 500, 1000, 2000, 120); places_xy[17] = c3.Location;
                places[18] = new Places("모스크바", 1800, 0, 500, 1000, 2000, 120); places_xy[18] = c4.Location;
                places[19] = new Places("제네바", 1800, 0, 500, 1000, 2000, 120); places_xy[19] = c5.Location;
                places[20] = new Places("로마", 1800, 0, 500, 1000, 2000, 120); places_xy[20] = c6.Location;

                places[21] = new Places("세계여행", 0, 0, 0, 0, 0, 0); places_xy[21] = p21.Location;

                places[22] = new Places("타히티", 1800, 0, 500, 1000, 2000, 120); places_xy[22] = d1.Location;
                places[23] = new Places("런던", 1800, 0, 500, 1000, 2000, 120); places_xy[23] = d2.Location;
                places[24] = new Places("파리", 1800, 0, 500, 1000, 2000, 120); places_xy[24] = d3.Location;
                places[25] = new Places("뉴욕", 1800, 0, 500, 1000, 2000, 120); places_xy[25] = d4.Location;
                places[26] = new Places("국세청", 1800, 0, 500, 1000, 2000, 120); places_xy[26] = d5.Location;
                places[27] = new Places("서울", 1800, 0, 500, 1000, 2000, 120); places_xy[27] = d6.Location;
            }
            
            else if (num2.Text == "2")   // 한국맵
            {
                places[0] = new Places("시작", 0, 0, 0, 0, 0, 0); places_xy[0] = p0.Location;
                places[1] = new Places("방콕", 500, 0, 500, 1000, 2000, 50); places_xy[1] = a1.Location;
                places[2] = new Places("베이징", 700, 0, 500, 1000, 2000, 120); places_xy[2] = a2.Location;
                places[3] = new Places("독도", 1100, 0, 500, 1000, 2000, 120); places_xy[3] = a3.Location;
                places[4] = new Places("타이페이", 1200, 0, 500, 1000, 2000, 120); places_xy[4] = a4.Location;
                places[5] = new Places("두바이", 1200, 0, 500, 1000, 2000, 120); places_xy[5] = a5.Location;
                places[6] = new Places("카이로", 1200, 0, 500, 1000, 2000, 120); places_xy[6] = a6.Location;

                places[7] = new Places("무인도", 0, 0, 0, 0, 0, 0); places_xy[7] = p7.Location;

                places[8] = new Places("발리", 1200, 0, 500, 1000, 2000, 120); places_xy[8] = b1.Location;
                places[9] = new Places("도쿄", 1200, 0, 500, 1000, 2000, 120); places_xy[9] = b2.Location;
                places[10] = new Places("시드니", 1500, 0, 500, 1000, 2000, 120); places_xy[10] = b3.Location;
                places[11] = new Places("퀘백", 1500, 0, 500, 1000, 2000, 120); places_xy[11] = b4.Location;
                places[12] = new Places("하와이", 1500, 0, 500, 1000, 2000, 120); places_xy[12] = b5.Location;
                places[13] = new Places("상파울로", 1500, 0, 500, 1000, 2000, 120); places_xy[13] = b6.Location;

                places[14] = new Places("올림픽", 0, 0, 0, 0, 0, 0); places_xy[14] = p14.Location;

                places[15] = new Places("프라하", 1500, 0, 500, 1000, 2000, 120); places_xy[15] = c1.Location;
                places[16] = new Places("푸켓", 1500, 0, 500, 1000, 2000, 120); places_xy[16] = c2.Location;
                places[17] = new Places("베를린", 1500, 0, 500, 1000, 2000, 120); places_xy[17] = c3.Location;
                places[18] = new Places("모스크바", 1800, 0, 500, 1000, 2000, 120); places_xy[18] = c4.Location;
                places[19] = new Places("제네바", 1800, 0, 500, 1000, 2000, 120); places_xy[19] = c5.Location;
                places[20] = new Places("로마", 1800, 0, 500, 1000, 2000, 120); places_xy[20] = c6.Location;

                places[21] = new Places("세계여행", 0, 0, 0, 0, 0, 0); places_xy[21] = p21.Location;

                places[22] = new Places("타히티", 1800, 0, 500, 1000, 2000, 120); places_xy[22] = d1.Location;
                places[23] = new Places("런던", 1800, 0, 500, 1000, 2000, 120); places_xy[23] = d2.Location;
                places[24] = new Places("파리", 1800, 0, 500, 1000, 2000, 120); places_xy[24] = d3.Location;
                places[25] = new Places("뉴욕", 1800, 0, 500, 1000, 2000, 120); places_xy[25] = d4.Location;
                places[26] = new Places("국세청", 1800, 0, 500, 1000, 2000, 120); places_xy[26] = d5.Location;
                places[27] = new Places("서울", 1800, 0, 500, 1000, 2000, 120); places_xy[27] = d6.Location;
            }
        }

        public void displayPlacesInfo()
        {
            int position = player[current_user].position;
            string owner = null;
            switch (places[position].owner)
            {
                case 0: owner = "없음"; break;
                case 1: owner = player[0].name; break;
                case 2: owner = player[1].name; break;
                case 3: owner = player[2].name; break;
                case 4: owner = player[3].name; break;
            }
            info1.Text = places[position].name;
            info2.Text = Convert.ToString(places[position].price) + "만원";
            info3.Text = Convert.ToString(places[position].owner);
            info4.Text = Convert.ToString(places[position].land1) + "만원";
            info5.Text = Convert.ToString(places[position].land2) + "만원";
            info6.Text = Convert.ToString(places[position].land3) + "만원";
            info7.Text = Convert.ToString(places[position].pass_money) + "만원";
        }

        public void paint(bool isMe)
        {
            if (isMoving == MoveState.RUNNING)
                move();
            int position = player[current_user].position;

            if (isMe)
            {
                if (position != 0 && position != 7 && position != 14 && position != 21)
                {
                    if (places[position].owner == 0 && isMoving == MoveState.DONE)
                    {
                        지역구매 = new 지역구매();
                        지역구매.Show();
                        지역구매.copy(this);
                        지역구매.checkBox1.Visible = true;
                        지역구매.checkBox1.Checked = true;
                        지역구매.checkBox2.Visible = false;
                        지역구매.checkBox3.Visible = false;
                        지역구매.checkBox4.Visible = false;
                    }
                    else if (places[position].owner == current_user + 1 && isMoving == MoveState.DONE)
                    {
                        지역구매 = new 지역구매();
                        지역구매.Show();
                        지역구매.copy(this);
                        지역구매.checkBox1.Visible = false;
                        지역구매.checkBox2.Visible = true;
                        지역구매.checkBox3.Visible = true;
                        지역구매.checkBox4.Visible = true;
                    }
                }
            }
        }

        public void move()
        {
            player[current_user].SetPosition(1);
            int position = player[current_user].position;

            switch(current_user)
            {
                case 0: p1Img.SetBounds(places_xy[position].X, places_xy[position].Y, 25, 25); break;
                case 1: p2Img.SetBounds(places_xy[position].X + 25, places_xy[position].Y, 25, 25); break;
                case 2: p3Img.SetBounds(places_xy[position].X, places_xy[position].Y + 25, 25, 25); break;
                case 3: p4Img.SetBounds(places_xy[position].X + 25, places_xy[position].Y + 25, 25, 25); break;
            }

            displayPlacesInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random dice = new Random();
            dice1 = dice.Next(1, 7);
            dice2 = dice.Next(1, 7);
            dice1Label.Text = Convert.ToString(dice1);
            dice2Label.Text = Convert.ToString(dice2);

            //소켓
            m_Write.WriteLine(Convert.ToString(dice1 + dice2));
            m_Write.Flush();

            process(dice1+dice2, true);
        }

        public void process(int dicesum, bool isMe)
        {
            if (button1.Text == "시작")
            {
                Message(dicesum + "만큼 이동합니다!");

                if (player[current_user].status != 3) // 무인도에 있지 않을 경우
                {
                    player[current_user].status = player[current_user].status + 1;
                    current_user = (current_user + 1) % count;
                    use_turn = current_user;
                }
                isMoving = MoveState.RUNNING;

                if (player[current_user].warp == true) // 세계여행
                {
                    int a = Convert.ToInt32(num.Text);
                    isMoving = MoveState.RUNNING;
                    for (int i = 0; i < a; i++)
                    {
                        paint(isMe);
                        Thread.Sleep(100);
                    }
                    isMoving = MoveState.DONE;
                    paint(isMe);
                    player[current_user].warp = false;
                }
                else if (player[current_user].warp == false) // 세계여행이 아닐 경우
                {
                    temp.Text = Convert.ToString(player[current_user].position + (dicesum));
                    temp2.Text = Convert.ToString(current_user);

                    if (player[current_user].position + (dicesum) >= 28)
                    {
                        player[current_user].AddMoney(200);
                        switch (current_user)
                        {
                            case 0: player1Asset.Text = Convert.ToString(player[current_user].asset); break;
                            case 1: player2Asset.Text = Convert.ToString(player[current_user].asset); break;
                            case 2: player3Asset.Text = Convert.ToString(player[current_user].asset); break;
                            case 3: player4Asset.Text = Convert.ToString(player[current_user].asset); break;
                        }
                    }
                    for (int i = 0; i < dicesum; i++)
                    {
                        paint(isMe);
                        Thread.Sleep(100);
                    }
                    isMoving = MoveState.DONE;
                    paint(isMe);
                }

                if (places[player[current_user].position] == places[7]) // 무인도
                {
                    player[current_user].status = 0;
                }
                else if (places[player[current_user].position] == places[14]) // 세금
                {
                    int position = player[current_user].position;
                    player[current_user].DrawMoney(places[position].pass_money);
                    switch (current_user)
                    {
                        case 0: player1Asset.Text = Convert.ToString(player[current_user].asset); break;
                        case 1: player2Asset.Text = Convert.ToString(player[current_user].asset); break;
                        case 2: player3Asset.Text = Convert.ToString(player[current_user].asset); break;
                        case 3: player4Asset.Text = Convert.ToString(player[current_user].asset); break;
                    }
                }

                else if (places[player[current_user].position] == places[21]) // 세계 여행
                {
                    if (isMe)
                    {
                        세계여행 ma = new 세계여행();
                        ma.Show();
                        ma.copy(this);
                        player[current_user].warp = true;
                    }
                }

                else if (places[player[current_user].position].owner > 0 &&
                        places[player[current_user].position].owner != current_user + 1) // 상대편 땅에 도착했을시
                {
                    if (isMe)
                    {
                        통행료지불 통행료지불 = new 통행료지불();
                        통행료지불.Show();
                        if (player[current_user].freepass)
                            통행료지불.copy(this, true);
                        else
                            통행료지불.copy(this, false);

                        
                        if (pass_by_money) // 돈으로 지불할 경우
                        {
                            int position = player[current_user].position;
                            player[current_user].DrawMoney(places[position].pass_money);
                            switch (current_user)
                            {
                                case 0: player1Asset.Text = Convert.ToString(player[current_user].asset); break;
                                case 1: player2Asset.Text = Convert.ToString(player[current_user].asset); break;
                                case 2: player3Asset.Text = Convert.ToString(player[current_user].asset); break;
                                case 3: player4Asset.Text = Convert.ToString(player[current_user].asset); break;
                            }

                            int income_position = (places[player[current_user].position].owner) - 1;
                            player[income_position].AddMoney(places[position].pass_money);
                            switch (income_position)
                            {
                                case 0: player1Asset.Text = Convert.ToString(player[income_position].asset); break;
                                case 1: player2Asset.Text = Convert.ToString(player[income_position].asset); break;
                                case 2: player3Asset.Text = Convert.ToString(player[income_position].asset); break;
                                case 3: player4Asset.Text = Convert.ToString(player[income_position].asset); break;
                            }
                            pass_by_money = true;
                        }
                        else // 돈으로 지불하지 않을 경우
                        {
                            player[current_user].freepass = false;
                        }
                    }
                }
                else // 일반 땅일 경우
                {

                }
                button1.Text = "다음 턴";
                isMoving = MoveState.BEGIN;
                return;
            }

            button1.Text = "시작";
            switch (current_user)
            {
                case 0: player1Asset.Text = Convert.ToString(player[current_user].asset); break;
                case 1: player2Asset.Text = Convert.ToString(player[current_user].asset); break;
                case 2: player3Asset.Text = Convert.ToString(player[current_user].asset); break;
                case 3: player4Asset.Text = Convert.ToString(player[current_user].asset); break;
            }
            current_user = (current_user + 1) % count;
            use_turn = current_user;
            isMoving = MoveState.BEGIN;
        }

        public void setColor_Land(int current_user, int position)
        {
            Color color = new Color();

            if (current_user == 0)
                color = Color.Blue;
            else if (current_user == 1)
                color = Color.Green;
            else if (current_user == 2)
                color = Color.Violet;
            else if (current_user == 3)
                color = Color.DarkOrange;

            switch (position)
            {
                case 1: a1.BackColor = color; break;
                case 2: a2.BackColor = color; break;
                case 3: a3.BackColor = color; break;
                case 4: a4.BackColor = color; break;
                case 5: a5.BackColor = color; break;
                case 6: a6.BackColor = color; break;

                case 8: b1.BackColor = color; break;
                case 9: b2.BackColor = color; break;
                case 10: b3.BackColor = color; break;
                case 11: b4.BackColor = color; break;
                case 12: b5.BackColor = color; break;
                case 13: b6.BackColor = color; break;

                case 15: c1.BackColor = color; break;
                case 16: c2.BackColor = color; break;
                case 17: c3.BackColor = color; break;
                case 18: c4.BackColor = color; break;
                case 19: c5.BackColor = color; break;
                case 20: c6.BackColor = color; break;

                case 22: d1.BackColor = color; break;
                case 23: d2.BackColor = color; break;
                case 24: d3.BackColor = color; break;
                case 25: d4.BackColor = color; break;
                case 26: d5.BackColor = color; break;
                case 27: d6.BackColor = color; break;
            }
        }

        public void setColor_Villa(int position)
        {
            Color color = new Color();
            color = Color.YellowGreen;

            switch (position)
            {
                case 1: a11.BackColor = color; break;
                case 2: a21.BackColor = color; break;
                case 3: a31.BackColor = color; break;
                case 4: a41.BackColor = color; break;
                case 5: a51.BackColor = color; break;
                case 6: a61.BackColor = color; break;

                case 8: b11.BackColor = color; break;
                case 9: b21.BackColor = color; break;
                case 10: b31.BackColor = color; break;
                case 11: b41.BackColor = color; break;
                case 12: b51.BackColor = color; break;
                case 13: b61.BackColor = color; break;

                case 15: c11.BackColor = color; break;
                case 16: c21.BackColor = color; break;
                case 17: c31.BackColor = color; break;
                case 18: c41.BackColor = color; break;
                case 19: c51.BackColor = color; break;
                case 20: c61.BackColor = color; break;

                case 22: d11.BackColor = color; break;
                case 23: d21.BackColor = color; break;
                case 24: d31.BackColor = color; break;
                case 25: d41.BackColor = color; break;
                case 26: d51.BackColor = color; break;
                case 27: d61.BackColor = color; break;
            }
        }

        public void setColor_Building(int position)
        {
            Color color = new Color();
            color = Color.Silver;

            switch (position)
            {
                case 1: a12.BackColor = color; break;
                case 2: a22.BackColor = color; break;
                case 3: a32.BackColor = color; break;
                case 4: a42.BackColor = color; break;
                case 5: a52.BackColor = color; break;
                case 6: a62.BackColor = color; break;

                case 8: b12.BackColor = color; break;
                case 9: b22.BackColor = color; break;
                case 10: b32.BackColor = color; break;
                case 11: b42.BackColor = color; break;
                case 12: b52.BackColor = color; break;
                case 13: b62.BackColor = color; break;

                case 15: c12.BackColor = color; break;
                case 16: c22.BackColor = color; break;
                case 17: c32.BackColor = color; break;
                case 18: c42.BackColor = color; break;
                case 19: c52.BackColor = color; break;
                case 20: c62.BackColor = color; break;

                case 22: d12.BackColor = color; break;
                case 23: d22.BackColor = color; break;
                case 24: d32.BackColor = color; break;
                case 25: d42.BackColor = color; break;
                case 26: d52.BackColor = color; break;
                case 27: d62.BackColor = color; break;
            }
        }

        public void setColor_Hotel(int position)
        {
            Color color = new Color();
            color = Color.Gold;

            switch (position)
            {
                case 1: a13.BackColor = color; break;
                case 2: a23.BackColor = color; break;
                case 3: a33.BackColor = color; break;
                case 4: a43.BackColor = color; break;
                case 5: a53.BackColor = color; break;
                case 6: a63.BackColor = color; break;

                case 8: b13.BackColor = color; break;
                case 9: b23.BackColor = color; break;
                case 10: b33.BackColor = color; break;
                case 11: b43.BackColor = color; break;
                case 12: b53.BackColor = color; break;
                case 13: b63.BackColor = color; break;

                case 15: c13.BackColor = color; break;
                case 16: c23.BackColor = color; break;
                case 17: c33.BackColor = color; break;
                case 18: c43.BackColor = color; break;
                case 19: c53.BackColor = color; break;
                case 20: c63.BackColor = color; break;
                
                case 22: d13.BackColor = color; break;
                case 23: d23.BackColor = color; break;
                case 24: d33.BackColor = color; break;
                case 25: d43.BackColor = color; break;
                case 26: d53.BackColor = color; break;
                case 27: d63.BackColor = color; break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Disconnect();
        }



        private void showInfo(object sender, EventArgs e)
        {
            건물정보 ppp = new 건물정보();
            PictureBox a = (PictureBox)sender;

            string send1 = null;
            int send2 = 0, send3 = 0, send4 = 0, send5 = 0, send6 = 0, send7 = 0;
            if (a.Name == "p1")
            {
                send1 = places[1].name;
                send2 = places[1].price;
                send3 = places[1].owner;
                send4 = places[1].pass_money;
                send5 = places[1].land1;
                send6 = places[1].land2;
                send7 = places[1].land3;
            }
            else if (a.Name == "p2")
            {
                send1 = places[2].name;
                send2 = places[2].price;
                send3 = places[2].owner;
                send4 = places[2].pass_money;
                send5 = places[2].land1;
                send6 = places[2].land2;
                send7 = places[2].land3;
            }
            else if (a.Name == "p3")
            {
                send1 = places[3].name;
                send2 = places[3].price;
                send3 = places[3].owner;
                send4 = places[3].pass_money;
                send5 = places[3].land1;
                send6 = places[3].land2;
                send7 = places[3].land3;
            }
            else if (a.Name == "p4")
            {
                send1 = places[4].name;
                send2 = places[4].price;
                send3 = places[4].owner;
                send4 = places[4].pass_money;
                send5 = places[4].land1;
                send6 = places[4].land2;
                send7 = places[4].land3;
            }
            else if (a.Name == "p5")
            {
                send1 = places[5].name;
                send2 = places[5].price;
                send3 = places[5].owner;
                send4 = places[5].pass_money;
                send5 = places[5].land1;
                send6 = places[5].land2;
                send7 = places[5].land3;
            }
            else if (a.Name == "p6")
            {
                send1 = places[6].name;
                send2 = places[6].price;
                send3 = places[6].owner;
                send4 = places[6].pass_money;
                send5 = places[6].land1;
                send6 = places[6].land2;
                send7 = places[6].land3;
            }
            else if (a.Name == "p7")
            {
                send1 = places[7].name;
                send2 = places[7].price;
                send3 = places[7].owner;
                send4 = places[7].pass_money;
                send5 = places[7].land1;
                send6 = places[7].land2;
                send7 = places[7].land3;
            }
            else if (a.Name == "p8")
            {
                send1 = places[8].name;
                send2 = places[8].price;
                send3 = places[8].owner;
                send4 = places[8].pass_money;
                send5 = places[8].land1;
                send6 = places[8].land2;
                send7 = places[8].land3;
            }

            else if (a.Name == "p9")
            {
                send1 = places[9].name;
                send2 = places[9].price;
                send3 = places[9].owner;
                send4 = places[9].pass_money;
                send5 = places[9].land1;
                send6 = places[9].land2;
                send7 = places[9].land3;
            }

            else if (a.Name == "p10")
            {
                send1 = places[10].name;
                send2 = places[10].price;
                send3 = places[10].owner;
                send4 = places[10].pass_money;
                send5 = places[10].land1;
                send6 = places[10].land2;
                send7 = places[10].land3;
            }

            else if (a.Name == "p11")
            {
                send1 = places[11].name;
                send2 = places[11].price;
                send3 = places[11].owner;
                send4 = places[11].pass_money;
                send5 = places[11].land1;
                send6 = places[11].land2;
                send7 = places[11].land3;
            }

            else if (a.Name == "p12")
            {
                send1 = places[12].name;
                send2 = places[12].price;
                send3 = places[12].owner;
                send4 = places[12].pass_money;
                send5 = places[12].land1;
                send6 = places[12].land2;
                send7 = places[12].land3;
            }

            else if (a.Name == "p13")
            {
                send1 = places[13].name;
                send2 = places[13].price;
                send3 = places[13].owner;
                send4 = places[13].pass_money;
                send5 = places[13].land1;
                send6 = places[13].land2;
                send7 = places[13].land3;
            }

            else if (a.Name == "p14")
            {
                send1 = places[14].name;
                send2 = places[14].price;
                send3 = places[14].owner;
                send4 = places[14].pass_money;
                send5 = places[14].land1;
                send6 = places[14].land2;
                send7 = places[14].land3;
            }

            else if (a.Name == "p15")
            {
                send1 = places[15].name;
                send2 = places[15].price;
                send3 = places[15].owner;
                send4 = places[15].pass_money;
                send5 = places[15].land1;
                send6 = places[15].land2;
                send7 = places[15].land3;
            }

            else if (a.Name == "p16")
            {
                send1 = places[16].name;
                send2 = places[16].price;
                send3 = places[16].owner;
                send4 = places[16].pass_money;
                send5 = places[16].land1;
                send6 = places[16].land2;
                send7 = places[16].land3;
            }

            else if (a.Name == "p17")
            {
                send1 = places[17].name;
                send2 = places[17].price;
                send3 = places[17].owner;
                send4 = places[17].pass_money;
                send5 = places[17].land1;
                send6 = places[17].land2;
                send7 = places[17].land3;
            }

            else if (a.Name == "p18")
            {
                send1 = places[18].name;
                send2 = places[18].price;
                send3 = places[18].owner;
                send4 = places[18].pass_money;
                send5 = places[18].land1;
                send6 = places[18].land2;
                send7 = places[18].land3;
            }

            else if (a.Name == "p19")
            {
                send1 = places[19].name;
                send2 = places[19].price;
                send3 = places[19].owner;
                send4 = places[19].pass_money;
                send5 = places[19].land1;
                send6 = places[19].land2;
                send7 = places[19].land3;
            }

            else if (a.Name == "p20")
            {
                send1 = places[20].name;
                send2 = places[20].price;
                send3 = places[20].owner;
                send4 = places[20].pass_money;
                send5 = places[20].land1;
                send6 = places[20].land2;
                send7 = places[20].land3;
            }

            else if (a.Name == "p21")
            {
                send1 = places[21].name;
                send2 = places[21].price;
                send3 = places[21].owner;
                send4 = places[21].pass_money;
                send5 = places[21].land1;
                send6 = places[21].land2;
                send7 = places[21].land3;
            }

            else if (a.Name == "p22")
            {
                send1 = places[22].name;
                send2 = places[22].price;
                send3 = places[22].owner;
                send4 = places[22].pass_money;
                send5 = places[22].land1;
                send6 = places[22].land2;
                send7 = places[22].land3;
            }

            else if (a.Name == "p23")
            {
                send1 = places[23].name;
                send2 = places[23].price;
                send3 = places[23].owner;
                send4 = places[23].pass_money;
                send5 = places[23].land1;
                send6 = places[23].land2;
                send7 = places[23].land3;
            }

            else if (a.Name == "p24")
            {
                send1 = places[24].name;
                send2 = places[24].price;
                send3 = places[24].owner;
                send4 = places[24].pass_money;
                send5 = places[24].land1;
                send6 = places[24].land2;
                send7 = places[24].land3;
            }

            else if (a.Name == "p25")
            {
                send1 = places[25].name;
                send2 = places[25].price;
                send3 = places[25].owner;
                send4 = places[25].pass_money;
                send5 = places[25].land1;
                send6 = places[25].land2;
                send7 = places[25].land3;
            }

            else if (a.Name == "p26")
            {
                send1 = places[26].name;
                send2 = places[26].price;
                send3 = places[26].owner;
                send4 = places[26].pass_money;
                send5 = places[26].land1;
                send6 = places[26].land2;
                send7 = places[26].land3;
            }

            else if (a.Name == "p27")
            {
                send1 = places[27].name;
                send2 = places[27].price;
                send3 = places[27].owner;
                send4 = places[27].pass_money;
                send5 = places[27].land1;
                send6 = places[27].land2;
                send7 = places[27].land3;
            }
            // p10 - p35도 구현할 것
            
            ppp.Show();
            ppp.copy(this, sender, send1, send2, send3, send4, send5, send6, send7);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                int position = player[current_user].position;
                player[current_user].DrawMoney(places[position].price);
                places[position].pass_money = places[position].land1;
                places[position].owner = current_user + 1;

                setColor_Land(current_user, position);
                displayPlacesInfo();
                //소켓
                m_Write.WriteLine("100");
                m_Write.Flush();
            }
            checkBox1.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                int position = player[current_user].position;
                player[current_user].DrawMoney(places[position].land1);
                places[position].pass_money += places[position].land1 + 500;

                setColor_Villa(position);
                displayPlacesInfo();
                //소켓
                m_Write.WriteLine("200");
                m_Write.Flush();
            }
            checkBox2.Checked = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                int position = player[current_user].position;
                player[current_user].DrawMoney(places[position].land1);
                places[position].pass_money += places[position].land1 + 1000;

                setColor_Building(position);
                displayPlacesInfo();
                //소켓
                m_Write.WriteLine("300");
                m_Write.Flush();
            }
            checkBox3.Checked = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                int position = player[current_user].position;
                player[current_user].DrawMoney(places[position].land1);
                places[position].pass_money += places[position].land1 + 1500;

                setColor_Hotel(position);
                displayPlacesInfo();
                //소켓
                m_Write.WriteLine("400");
                m_Write.Flush();
            }
            checkBox4.Checked = false;
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            
        }
    }
}