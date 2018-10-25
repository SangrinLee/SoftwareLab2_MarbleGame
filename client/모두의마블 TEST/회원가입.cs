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
    public partial class 회원가입 : Form
    {
        public 회원가입()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = "data source=MYCOMPUTER\\DBSERVER;" + "initial catalog=모두의마블;" + "user id=LSR;" + "password=thtlf!";
            myConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConnection;
            cmd.CommandText = "Insert into 멤버(회원아이디, 비밀번호, 이름, 점수) values('"
                + this.textBox1.Text + "','" + this.textBox3.Text + "','" + this.textBox2.Text + "', 0)";

            cmd.ExecuteNonQuery();
            myConnection.Close();

            MessageBox.Show("회원가입이 되었습니다.");
            //Response.Redirect("메뉴.aspx");
            this.Close();
            new 로그인();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new 로그인();
        }
    }
}
