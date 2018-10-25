using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace 모두의마블_TEST
{
    public partial class 로딩화면 : Form
    {
        public 로딩화면()
        {
            InitializeComponent();
        }

        로그인 로그인;
        public void copy(로그인 copied)
        {
            this.로그인 = copied;
        }

        private void 로딩화면_Load(object sender, EventArgs e)
        {

        }

        private void 로딩화면_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
            메인메뉴 ma = new 메인메뉴();
            ma.Show();
            ma.copy(this.로그인);

        }
    }
}
