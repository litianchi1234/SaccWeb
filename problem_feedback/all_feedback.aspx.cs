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
    public partial class ALL_FEEDBACK : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                Calendar4.Visible = false;
                Calendar3.Visible = false;
                xianshi();
                ViewState["dep"] = "*";
                ViewState["type"] = "*";
                ViewState["urg"] = "*";
                ViewState["pro"] = "*";
                ViewState["ksdate"] = "*";
                ViewState["jsdate"] = "*";
                getDepartment();
                gettype();
                geturgency();
                getprogress();
            }
        }

        private void dtinit_Pri(DataTable dt)
        {
            ////   ID, JiaoJieDH, wlh,wlms,ddh,pgh,xqsl,RSNUM,RSPOS,RSART
            //     <asp:BoundField DataField="wlh" HeaderText="部门" />
            //       <asp:BoundField DataField="wlms" HeaderText="提问人" />
            //       <asp:BoundField DataField="lotno" HeaderText="问题编号" />
            //       <asp:BoundField DataField="gyspc" HeaderText="问题" />
            //       <asp:BoundField DataField="kcsl" HeaderText="日期" />
            //       <asp:BoundField DataField="dw" HeaderText="审批" />
            //       <asp:BoundField DataField="dw" HeaderText="完成度" />

            //       <asp:BoundField  HeaderText="备注" />

            dt.Columns.Add("部门", System.Type.GetType("System.String"));    //0
            dt.Columns.Add("提问人", System.Type.GetType("System.String"));//1
            dt.Columns.Add("问题编号", System.Type.GetType("System.String"));//2
            dt.Columns.Add("问题", System.Type.GetType("System.String"));  //3
            dt.Columns.Add("日期", System.Type.GetType("System.String"));//7
            dt.Columns.Add("审批", System.Type.GetType("System.String"));//8  
            dt.Columns.Add("完成度", System.Type.GetType("System.String"));//9

            ViewState["dt"] = dt;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        void xianshi()
        {
            string con = "server= LAPTOP-2JA3HLGQ\\SQLEXPRESS;database=problem_feedback;uid=sa;pwd=root";
            string sql = "  select p1.department,p1.name as asker,PROBLEM.*,p2.department,p2.name as answerer from people p1,problem,APPROVE,PEOPLE p2 where problem.people_id=p1.id and PROBLEM.id=APPROVE.PROBLEM_ID AND APPROVE.PEOPLE_ID=p2.id order by id";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataTable data = new DataTable();
            sda.Fill(data);
            conn.Close();
            GridView1.DataSource = data;
            GridView1.DataBind();
        }
        void getDepartment()
        {
            SqlConnection cnn = new SqlConnection();//建立到数据库的连接
            cnn.ConnectionString = "server= LAPTOP-2JA3HLGQ\\SQLEXPRESS;database=problem_feedback;uid=sa;pwd=root";
            String sql = " select *  from  department";
            cnn.Open();//打开通道
            SqlCommand cmd = cnn.CreateCommand();
            //sql语句     
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                DropDownList1.Items.Add(dr["depname"].ToString());
            }
            dr.Close();
            cnn.Close();
        }
        void gettype()
        {
            SqlConnection cnn = new SqlConnection();//建立到数据库的连接
            cnn.ConnectionString = "server= LAPTOP-2JA3HLGQ\\SQLEXPRESS;database=problem_feedback;uid=sa;pwd=root";
            String sql = " select *  from  type";

            cnn.Open();//打开通道

            SqlCommand cmd = cnn.CreateCommand();
            //sql语句     
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList3.Items.Add(dr["type"].ToString());
            }

            cnn.Close();
        }
        void geturgency()
        {
            SqlConnection cnn = new SqlConnection();//建立到数据库的连接
            cnn.ConnectionString = "server= LAPTOP-2JA3HLGQ\\SQLEXPRESS;database=problem_feedback;uid=sa;pwd=root";
            String sql = " select *  from  urg ";

            cnn.Open();//打开通道

            SqlCommand cmd = cnn.CreateCommand();
            //sql语句     
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList4.Items.Add(dr["urg"].ToString());
            }

            cnn.Close();
        }
        void getprogress()
        {
            SqlConnection cnn = new SqlConnection();//建立到数据库的连接
            cnn.ConnectionString = "server= LAPTOP-2JA3HLGQ\\SQLEXPRESS;database=problem_feedback;uid=sa;pwd=root";
            String sql = " select *  from  progress ";

            cnn.Open();//打开通道

            SqlCommand cmd = cnn.CreateCommand();
            //sql语句     
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList5.Items.Add(dr["pro"].ToString());
            }

            cnn.Close();
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["dep"] = DropDownList1.SelectedValue.ToString();


            ///String dep = DropDownList1.SelectedValue.ToString();
            // getdepartment(dep);
        }
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["type"] = DropDownList3.SelectedValue.ToString();

        }
        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["urg"] = DropDownList4.SelectedValue.ToString();

        }
        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["pro"] = DropDownList5.SelectedValue.ToString();

        }



        protected void getdepartment(string dep)
        {

            SqlConnection cnn = new SqlConnection();//建立到数据库的连接
            cnn.ConnectionString = "server= LAPTOP-2JA3HLGQ\\SQLEXPRESS;database=problem_feedback;uid=sa;pwd=root";
            String sql = " select people.*,problem.* from people,problem where problem.people_id=people.id and people.department='" + dep + "'";

            cnn.Open();//打开通道

            SqlCommand cmd = new SqlCommand(sql, cnn);//执行查询命令各
            SqlDataAdapter sdap = new SqlDataAdapter();
            sdap.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sdap.Fill(dt);
            cnn.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();


        }



        protected void Button1_Click(object sender, EventArgs e)
        {


            SqlConnection cnn = new SqlConnection();//建立到数据库的连接
            string sql_dep = "";
            string sql_type = "";
            string sql_urg = "";
            string sql_pro = "";
            string sql_ksdate = "";
            string sql_jsdate = "";

            if (!ViewState["dep"].ToString().Trim().Equals("*"))
            {
                sql_dep = "and p1.department='" + ViewState["dep"] + "'";
            }
            if (!ViewState["type"].ToString().Trim().Equals("*"))
            {
                sql_type = "and problem.type='" + ViewState["type"] + "'";
            }
            if (!ViewState["urg"].ToString().Trim().Equals("*"))
            {
                sql_urg = "and problem.urg='" + ViewState["urg"] + "'";
            }
            if (!ViewState["pro"].ToString().Trim().Equals("*"))
            {
                sql_pro = "and problem.pro='" + ViewState["pro"] + "'";
            }
            if (!ViewState["ksdate"].ToString().Trim().Equals("*"))
            {
                sql_ksdate = "and date>='" + ViewState["ksdate"] + "'";
            }
            if (!ViewState["jsdate"].ToString().Trim().Equals("*"))
            {
                sql_jsdate = "and date<='" + ViewState["jsdate"] + "'";
            }


            cnn.ConnectionString = "server= LAPTOP-2JA3HLGQ\\SQLEXPRESS;database=problem_feedback;uid=sa;pwd=root";
            String sql = "  select p1.department,p1.name as asker,PROBLEM.*,p2.department,p2.name as answerer from people p1,problem,APPROVE,PEOPLE p2 where problem.people_id=p1.id and PROBLEM.id=APPROVE.PROBLEM_ID AND APPROVE.PEOPLE_ID=p2.id " +
            "" + sql_dep + "" + sql_type + "" + sql_urg + "" + sql_pro + "" + sql_ksdate + " " + sql_jsdate + " order by id";
            //Response.Write(sql_ksdate);
            // Response.Write(sql);

            cnn.Open();//打开通道

            SqlCommand cmd = new SqlCommand(sql, cnn);//执行查询命令各
            SqlDataAdapter sdap = new SqlDataAdapter();
            sdap.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sdap.Fill(dt);

            cnn.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            Calendar3.Visible = true;
        }

        protected void Calendar3_SelectionChanged(object sender, EventArgs e)
        {    //起始   
            Label2.Text = Calendar3.SelectedDate.ToShortDateString();
            String date = Calendar3.SelectedDate.Year.ToString();
            ViewState["ksdate"] = Calendar3.SelectedDate.ToShortDateString();
            //  Response.Write(date); 
            Calendar3.Visible = false;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            Calendar4.Visible = true;
        }

        protected void Calendar4_SelectionChanged(object sender, EventArgs e)
        {
            //终止 
            Label1.Text = Calendar4.SelectedDate.ToShortDateString();
            String date = Calendar4.SelectedDate.Year.ToString();
            ViewState["jsdate"] = Calendar4.SelectedDate.ToShortDateString();
            //  Response.Write(date);
            Calendar4.Visible = false;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }

    }
}