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
    public partial class 세계여행 : Form
    {
        public 세계여행()
        {
            InitializeComponent();
        }

        게임시작 게임시작;
        
        public void copy(게임시작 copied)
        {
            this.게임시작 = copied;
        }
        
        private void Main_Load(object sender, EventArgs e)
        {
             
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rdo0.Checked == true)
                게임시작.num.Text = Convert.ToString(1);
            else if (rdo1.Checked == true)
                게임시작.num.Text = Convert.ToString(2);
            else if (rdo2.Checked == true)
                게임시작.num.Text = Convert.ToString(3);
            else if (rdo3.Checked == true)
                게임시작.num.Text = Convert.ToString(4);
            else if (rdo4.Checked == true)
                게임시작.num.Text = Convert.ToString(5);
            else if (rdo5.Checked == true)
                게임시작.num.Text = Convert.ToString(6);
            else if (rdo6.Checked == true)
                게임시작.num.Text = Convert.ToString(7);
            else if (rdo7.Checked == true)
                게임시작.num.Text = Convert.ToString(8);
            else if (rdo8.Checked == true)
                게임시작.num.Text = Convert.ToString(9);
            else if (rdo9.Checked == true)
                게임시작.num.Text = Convert.ToString(10);
            else if (rdo10.Checked == true)
                게임시작.num.Text = Convert.ToString(11);
            else if (rdo11.Checked == true)
                게임시작.num.Text = Convert.ToString(12);
            else if (rdo12.Checked == true)
                게임시작.num.Text = Convert.ToString(13);
            else if (rdo13.Checked == true)
                게임시작.num.Text = Convert.ToString(14);
            else if (rdo14.Checked == true)
                게임시작.num.Text = Convert.ToString(15);
            else if (rdo15.Checked == true)
                게임시작.num.Text = Convert.ToString(16);
            else if (rdo16.Checked == true)
                게임시작.num.Text = Convert.ToString(17);
            else if (rdo17.Checked == true)
                게임시작.num.Text = Convert.ToString(18);
            else if (rdo18.Checked == true)
                게임시작.num.Text = Convert.ToString(19);
            else if (rdo19.Checked == true)
                게임시작.num.Text = Convert.ToString(20);
            else if (rdo20.Checked == true)
                게임시작.num.Text = Convert.ToString(21);
            else if (rdo21.Checked == true)
                게임시작.num.Text = Convert.ToString(22);
            else if (rdo22.Checked == true)
                게임시작.num.Text = Convert.ToString(23);
            else if (rdo23.Checked == true)
                게임시작.num.Text = Convert.ToString(24);
            else if (rdo24.Checked == true)
                게임시작.num.Text = Convert.ToString(25);
            else if (rdo25.Checked == true)
                게임시작.num.Text = Convert.ToString(26);
            else if (rdo26.Checked == true)
                게임시작.num.Text = Convert.ToString(27);

            this.Close();
        }

    }
}
