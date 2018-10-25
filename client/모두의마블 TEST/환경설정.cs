using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace 모두의마블_TEST
{
    public partial class 환경설정 : Form
    {
        public 환경설정()
        {
            InitializeComponent();
        }
        SoundPlayer player;
        public static string mapinfo;
        메인메뉴 메인메뉴 = new 메인메뉴();
        public void copy(메인메뉴 copied)
        {
            this.메인메뉴 = copied;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            메인메뉴.label1.Text = "메인메뉴 -> 환경설정 -> 확인";
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            메인메뉴.label1.Text = "메인메뉴 -> 환경설정 -> 취소";
            this.Close();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                메인메뉴.label2.Text = "2";
                checkBox4.Checked = false;
            }
           
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                메인메뉴.label2.Text = "1";
                checkBox3.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                player = new SoundPlayer("sosil.wav"); // (안에는 경로)

                player.Play();
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                player.Stop();
                checkBox1.Checked = false;
            }
        }
    }
}
