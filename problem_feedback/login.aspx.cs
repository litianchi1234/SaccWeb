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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ID"] = "";
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //denglu
            string account = TextBox1.Text.ToString();
            string password = TextBox2.Text.ToString();
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
                //string result = dr["password"].ToString();
                if (dr["password"].ToString().Trim().Equals(password))
                {
                    Response.Write("进入跳转");
                    //Session["ID"] = "dr["id"].ToString().Trim()";
                    conn.Close();
                    Response.Redirect("~/main.aspx");
                    
                    return;
                }
             
                    conn.Close();
                    Response.Write("密码错误");
               
                 return;

            }
            Response.Write("无此账号！");
            conn.Close();


          
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/register.aspx");
        }
    }
}