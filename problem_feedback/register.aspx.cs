using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace problem_feedback
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getDepartment();
          //  string dep = DropDownList1.SelectedValue.ToString();
          

        }

        void xianshi()
        {
            string con = "server= LAPTOP-2JA3HLGQ\\SQLEXPRESS;database=problem_feedback;uid=sa;pwd=root";
            string sql = "select * from PEOPLE";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataTable data = new DataTable();
            sda.Fill(data);


            conn.Close();
            GridView1.DataSource = data;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string account = TextBox1.Text.ToString();
            string password = TextBox2.Text.ToString();
            string name = TextBox3.Text.ToString();
getDepartment();
            String dep = DropDownList2.SelectedValue.ToString();
           Response.Write("部门是"+dep);

            string con = "server= LAPTOP-2JA3HLGQ\\SQLEXPRESS;database=problem_feedback;uid=sa;pwd=root";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            String sql_1 = " select *  from PEOPLE where account = '" + account + "'";
            SqlCommand cmd = conn.CreateCommand();
            //sql语句     
            cmd.CommandText = sql_1;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Response.Write("账号重复");
                conn.Close();
                return;


            }
          Response.Write(account + "  " + password+dep);
          string sql = "insert into PEOPLE(account,password,department,name) values ('" + account + "','" + password + "','"+dep+"','"+name+"')";
            dr.Close();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            Response.Write("注册成功");
            conn.Close();
            xianshi();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
        }
        void getDepartment()
        {
            SqlConnection cnn = new SqlConnection();//建立到数据库的连接
            cnn.ConnectionString = "server=LAPTOP-2JA3HLGQ\\SQLEXPRESS;database=problem_feedback;uid=sa;pwd=root";
            String sql = " select distinct depname  from  department";

            cnn.Open();//打开通道
            SqlCommand cmd = cnn.CreateCommand();
            //sql语句     
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList2.Items.Add(dr["depname"].ToString());
            }

            cnn.Close();


        }




        

      protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String dep = DropDownList2.SelectedValue.ToString();
            Response.Write("部门是" + dep);
     
            
        }
    }
}
