using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 모두의마블_TEST
{
    public partial class 메인메뉴 : Form
    {
        public 메인메뉴()
        {
            InitializeComponent();
        }

        랭킹정보 랭킹정보;
        환경설정 환경설정;
        게임시작 게임시작;

        /* 추가됨 */
        로그인 로그인 = new 로그인();
        public void copy(로그인 copied)
        {
            this.로그인 = copied;
        }
/*
        public void copy2(환경설정 copied)
        {
            this.환경설정 = copied;
        }
        */
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            로그인.label1.Visible = true;
            로그인.label2.Visible = true;
            로그인.textBox1.Visible = true;
            로그인.textBox2.Visible = true;
            로그인.textBox1.Text = "";
            로그인.textBox2.Text = "";
            로그인.textBox1.Focus();
            로그인.button2.Visible = false;
            로그인.label3.Text = "로그아웃 되었습니다";
            로그인.button1.Text = "로그인";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            랭킹정보 = new 랭킹정보();
            랭킹정보.Show();
            랭킹정보.copy(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            환경설정 = new 환경설정();
            환경설정.Show();
            환경설정.copy(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
            게임시작 = new 게임시작();
            게임시작.Show();
            게임시작.copy(this);
            */
            게임시작 = new 게임시작();
            게임시작.Show();
            게임시작.copy(this, this.로그인, this.랭킹정보, this.환경설정);
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            로그인.Close();
            //this.Close();
        }
    }
}
