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
    public partial class 랭킹정보 : Form
    {
        public 랭킹정보()
        {
            InitializeComponent();
        }

        메인메뉴 메인메뉴;
        public void copy(메인메뉴 copied)
        {
            this.메인메뉴 = copied;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            메인메뉴.label1.Text = "메인메뉴 -> 랭킹정보 -> 확인";
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            SqlConnection myconnection = new SqlConnection();
            myconnection.ConnectionString = "data source=MYCOMPUTER\\DBSERVER;" + "initial catalog=모두의마블;" + "user id=LSR;" + "password=thtlf!";

            myconnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myconnection;

            cmd.CommandText = "select 회원아이디 from 멤버";
            cmd.CommandType = CommandType.Text;

            string temp = cmd.ExecuteScalar().ToString();
            label2.Text = temp;

            SqlDataReader dr = cmd.ExecuteReader();
            dataGridView1.DataSource = dr;
            
            //dataGridView1.DataBind();

            //dr.Close();
            myconnection.Close();
            //ImageButton6.ImageUrl = "~/Image/book_1.png";
            */
        }

        private void 랭킹정보_Load(object sender, EventArgs e)
        {
            DataSet ds = GetData();
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void temp()
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private DataSet GetData()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = "data source=MYCOMPUTER\\DBSERVER;" + "initial catalog=모두의마블;" + "user id=LSR;" + "password=thtlf!";
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT 회원아이디,점수 FROM 멤버 Order by 점수 desc", myConnection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;

        }
    }
}
