using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 모두의마블_TEST
{
    public partial class 로그인 : Form
    {
        public 로그인()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "로그인")
            {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = "data source=MYCOMPUTER\\DBSERVER;" + "initial catalog=모두의마블;" + "user id=LSR;" + "password=thtlf!";
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                myCommand.CommandText = "Select 회원아이디 from 멤버 where 회원아이디 = @Id and 비밀번호 = @Password";

                myCommand.Parameters.Add("@Id", SqlDbType.VarChar, 10);
                myCommand.Parameters.Add("@Password", SqlDbType.VarChar, 10);
                myCommand.Parameters["@Id"].Value = textBox1.Text;
                myCommand.Parameters["@Password"].Value = textBox2.Text;

                if (myCommand.ExecuteScalar() != null)
                {
                    label3.Text = textBox1.Text + "님이 로그인 완료되었습니다";
                    button1.Text = "로그아웃";
                    label1.Visible = false;
                    label2.Visible = false;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    button2.Visible = true;
                }
                else
                {
                    MessageBox.Show("로그인 실패");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Focus();
                }

                myConnection.Close();
            }
            else if (button1.Text == "로그아웃")
            {
                label1.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
                button2.Visible = false;
                label3.Text = "로그아웃 되었습니다";
                button1.Text = "로그인";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            로딩화면 ma = new 로딩화면();
            ma.Show();
            ma.copy(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            회원가입 ma = new 회원가입();
            ma.Show();
        }
    }
}
