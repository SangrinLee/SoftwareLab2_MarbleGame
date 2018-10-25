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
    public partial class 건물정보 : Form
    {
        public 건물정보()
        {
            InitializeComponent();
        }

        게임시작 dup;

        public void copy(게임시작 copied, object sender, string s1, int s2, int s3, int s4, int s5, int s6, int s7)
        {
            PictureBox a = (PictureBox)sender;
            dup = copied;

            if (a.Name == "p0")
                pictureBox1.Image = dup.p0.Image;
            else if (a.Name == "p1")
                pictureBox1.Image = dup.p1.Image;
            else if (a.Name == "p2")
                pictureBox1.Image = dup.p2.Image;
            else if (a.Name == "p3")
                pictureBox1.Image = dup.p3.Image;
            else if (a.Name == "p4")
                pictureBox1.Image = dup.p4.Image;
            else if (a.Name == "p5")
                pictureBox1.Image = dup.p5.Image;
            else if (a.Name == "p6")
                pictureBox1.Image = dup.p6.Image;
            else if (a.Name == "p7")
                pictureBox1.Image = dup.p7.Image;
            else if (a.Name == "p8")
                pictureBox1.Image = dup.p8.Image;
            else if (a.Name == "p9")
                pictureBox1.Image = dup.p9.Image;
            else if (a.Name == "p10")
                pictureBox1.Image = dup.p10.Image;
            else if (a.Name == "p11")
                pictureBox1.Image = dup.p11.Image;
            else if (a.Name == "p12")
                pictureBox1.Image = dup.p12.Image;
            else if (a.Name == "p13")
                pictureBox1.Image = dup.p13.Image;
            else if (a.Name == "p14")
                pictureBox1.Image = dup.p14.Image;
            else if (a.Name == "p15")
                pictureBox1.Image = dup.p15.Image;
            else if (a.Name == "p16")
                pictureBox1.Image = dup.p16.Image;
            else if (a.Name == "p17")
                pictureBox1.Image = dup.p17.Image;
            else if (a.Name == "p18")
                pictureBox1.Image = dup.p18.Image;
            else if (a.Name == "p19")
                pictureBox1.Image = dup.p19.Image;
            else if (a.Name == "p20")
                pictureBox1.Image = dup.p20.Image;
            else if (a.Name == "p21")
                pictureBox1.Image = dup.p21.Image;
            else if (a.Name == "p22")
                pictureBox1.Image = dup.p22.Image;
            else if (a.Name == "p23")
                pictureBox1.Image = dup.p23.Image;
            else if (a.Name == "p24")
                pictureBox1.Image = dup.p24.Image;
            else if (a.Name == "p25")
                pictureBox1.Image = dup.p25.Image;
            else if (a.Name == "p26")
                pictureBox1.Image = dup.p26.Image;
            else if (a.Name == "p27")
                pictureBox1.Image = dup.p27.Image;


            i1.Text = s1;
            i2.Text = Convert.ToString(s2);
            i3.Text = Convert.ToString(s3);
            i4.Text = Convert.ToString(s4);
            i5.Text = Convert.ToString(s5);
            i6.Text = Convert.ToString(s6);
            i7.Text = Convert.ToString(s7);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
