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
    public partial class 통행료지불 : Form
    {
        public 통행료지불()
        {
            InitializeComponent();
        }


        게임시작 게임시작;
        public bool temp;
        public void copy(게임시작 copied, bool possible)
        {
            this.게임시작 = copied;
            this.temp = possible;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("파산하였습니다.");
            this.Close();
            new 메인메뉴();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (temp)
            {
                MessageBox.Show("우대권 사용하였습니다");
                //게임시작.pass_by_money = false;
                게임시작.num3.Text = "a";
                this.Close();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            게임시작.pass_by_money = true;
            this.Close();
        }
    }
}
