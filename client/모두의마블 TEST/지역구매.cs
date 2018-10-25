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
    public partial class 지역구매 : Form
    {
        public 지역구매()
        {
            InitializeComponent();
        }
        
        게임시작 게임시작;
        public void copy(게임시작 copied)
        {
            this.게임시작 = copied;
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Enabled == true && checkBox1.Checked == true)
                게임시작.checkBox1.Checked = true;

            if (checkBox2.Enabled == true && checkBox2.Checked == true)
                게임시작.checkBox2.Checked = true;
            if (checkBox3.Enabled == true && checkBox3.Checked == true)
                게임시작.checkBox3.Checked = true;
            if (checkBox4.Enabled == true && checkBox4.Checked == true)
                게임시작.checkBox4.Checked = true;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
