﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace demoUniversity
{
    public partial class News : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Projectdatabase.mdf;Integrated Security=True");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                connect.Close();
            }
            connect.Open();
            if (Session["reg"] != null)
            {
                SqlCommand cmds = new SqlCommand("select name from stud where reg = '" + Session["reg"].ToString() + "'", connect);
                SqlDataAdapter da = new SqlDataAdapter(cmds);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);
                int ij = ds1.Tables[0].Rows.Count;
                if (ij > 0)
                {
                    SqlCommand cmd1 = new SqlCommand("select id from stud where reg = '" + Session["reg"].ToString() + "' and pass='" + Session["pword"].ToString() + "'", connect);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataSet ds2 = new DataSet();
                    da1.Fill(ds2);
                    int j = ds2.Tables[0].Rows.Count;
                    if (j > 0)
                    {
                        bt1.Text = ds1.Tables[0].Rows[0][0].ToString();
                        bt2.Visible = true;

                    }
                    else bt1.Text = "Login";

                }
                else bt1.Text = "Login";
            }
            else
            {
                bt1.Text = "Login";
            }

            if (Session["reg"] == null) bt2.Visible = false;
            else if (Session["reg"].ToString() == "admin")
            {
                bt1.Text = "admin";
                Response.Write("Admin");
            }
            Table1.Visible = false;
            Table2.Visible = false;
            Table3.Visible = false;
            Response.Write("Successful");
            {
                Response.Clear();
                if (true)
                {
                   // Response.Write("Connected");
                    DateTime dt = DateTime.Now;
                    var date1 = dt.Date;
                    date1 = date1.AddDays(-5);
                    var date2 = dt.Date;
                    date2 = date2.AddDays(30);
                    SqlCommand cmd5 = new SqlCommand("select Venue, Program_Type, Mont as Month, Start_Date, End_Date, Details, Contact from news  where Start_Date <= '" + date2 + "' and Start_Date >= '" + date1 + "' order by Start_Date", connect);
                    cmd5.ExecuteNonQuery();
                    SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);
                    int ii = ds5.Tables[0].Rows.Count;
                    if (ii > 0)
                    {
                        GridView4.DataSource = (ds5);
                        GridView4.DataBind();
                    }
                    else
                    {
                        Response.Clear();
                        Response.Write("<script language=\"javascript\" type=\"text/javascript\">alert('Information Not Found');</script>");
                        Response.Write("Information Not Found");
                    }
                }
            }

           if (!IsPostBack)
            {
               /* DropDownList2.Items.Clear();
                //  DropDownList1.DataValueField = "stf";

                SqlCommand cmd2 = new SqlCommand("select distinct Mont from news", connect);
                cmd2.ExecuteNonQuery();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                DataSet ds2 = new DataSet();
                da1.Fill(ds2);
                DropDownList2.DataSource = ds2;
                DropDownList2.DataBind();
                DropDownList2.DataTextField = "Mont";
                DropDownList2.DataValueField = "Mont";
                DropDownList2.DataBind();*/

            }
           if (!IsPostBack)
           {
               DropDownList1.Items.Clear();
               //  DropDownList1.DataValueField = "stf";

               SqlCommand cmd1 = new SqlCommand("select distinct Venue from news", connect);
               cmd1.ExecuteNonQuery();
               SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
               DataSet ds1 = new DataSet();
               da1.Fill(ds1);
               DropDownList1.DataSource = ds1;
               DropDownList1.DataBind();
               DropDownList1.DataTextField = "Venue";
               DropDownList1.DataValueField = "Venue";
               DropDownList1.DataBind();

           }
           if (!IsPostBack)
           {
               DropDownList3.Items.Clear();
               //  DropDownList1.DataValueField = "stf";

               SqlCommand cmd3 = new SqlCommand("select distinct Program_Type from news", connect);
               cmd3.ExecuteNonQuery();
               SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
               DataSet ds3 = new DataSet();
               da3.Fill(ds3);
               DropDownList3.DataSource = ds3;
               DropDownList3.DataBind();
               DropDownList3.DataTextField = "Program_Type";
               DropDownList3.DataValueField = "Program_Type";
               DropDownList3.DataBind();

           }
        }

            
            

        protected void Button_Click(object sender, EventArgs e)
        {    
            Response.Clear();
            //DropDownList1.AutoPostBack = false;
            //DropDownList1.AutoPostBack = true;
            if (true)
            {
                var fr = Convert.ToDateTime(TextBox1.Text.ToString());
                var to = Convert.ToDateTime(TextBox2.Text.ToString());
                SqlCommand cmd5 = new SqlCommand("select Venue, Program_Type, Mont as Month, Start_Date, End_Date, Details, Contact from news where Start_Date>='" + fr + "' and Start_Date<='" + to + "' order by Start_Date", connect);
                cmd5.ExecuteNonQuery();
                SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
                DataSet ds5 = new DataSet();
                da5.Fill(ds5);
                int ii = ds5.Tables[0].Rows.Count;
                if (ii > 0)
                {
                    GridView1.DataSource = (ds5);
                    GridView1.DataBind();
                    GridView4.Visible = false;
                    GridView3.Visible = false;
                    GridView2.Visible = false;
                    GridView1.Visible = true;
                    Table1.Visible = true;
                }
                else
                {
                    Response.Clear();
                    Response.Write("<script language=\"javascript\" type=\"text/javascript\">alert('Information Not Found');</script>");
                    Response.Write("Information Not Found");
                }
            }
        }

        protected void Button_Click1(object sender, EventArgs e)
        {
            Response.Clear();
            //DropDownList1.AutoPostBack = false;
            //DropDownList1.AutoPostBack = true;
            if (true)
            {
                SqlCommand cmd5 = new SqlCommand("select Venue, Program_Type, Mont as Month, Start_Date, End_Date, Details, Contact from news where Venue='" + DropDownList1.SelectedItem.Text + "' order by Start_Date", connect);
                cmd5.ExecuteNonQuery();
                SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
                DataSet ds5 = new DataSet();
                da5.Fill(ds5);
                int ii = ds5.Tables[0].Rows.Count;
                if (ii > 0)
                {
                    GridView2.DataSource = (ds5);
                    GridView2.DataBind();
                    GridView4.Visible = false;
                    GridView3.Visible = false;
                    GridView2.Visible = true;
                    GridView1.Visible = false;
                    Table2.Visible = true;
                }
                else
                {
                    Response.Clear();
                    Response.Write("<script language=\"javascript\" type=\"text/javascript\">alert('Information Not Found');</script>");
                    Response.Write("Information Not Found");
                }
            }
        }

        protected void Button_Click2(object sender, EventArgs e)
        {
            Response.Clear();
            //DropDownList1.AutoPostBack = false;
            //DropDownList1.AutoPostBack = true;
            if (true)
            {
                SqlCommand cmd5 = new SqlCommand("select Venue, Program_Type, Mont as Month, Start_Date, End_Date, Details, Contact from news where Program_type='" + DropDownList3.SelectedItem.Text + "' order by Start_Date", connect);
                cmd5.ExecuteNonQuery();
                SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
                DataSet ds5 = new DataSet();
                da5.Fill(ds5);
                int ii = ds5.Tables[0].Rows.Count;
                if (ii > 0)
                {
                    GridView3.DataSource = (ds5);
                    GridView3.DataBind();
                    GridView4.Visible = false;
                    GridView3.Visible = true;
                    GridView2.Visible = false;
                    GridView1.Visible = false;
                    Table3.Visible = true;
                }
                else
                {
                    Response.Clear();
                    Response.Write("<script language=\"javascript\" type=\"text/javascript\">alert('Information Not Found');</script>");
                    Response.Write("Information Not Found");
                }
            }
        }

        protected void Button_Click4(object sender, EventArgs e)
        {
            Response.Clear();
            if (true)
            {
                /*SqlCommand cmd5 = new SqlCommand("select Venue, Program_Type, Mont as Month, Start_Date, End_Date, Details, Contact from news order by Start_Date", connect);
                cmd5.ExecuteNonQuery();
                SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
                DataSet ds5 = new DataSet();
                da5.Fill(ds5);
                int ii = ds5.Tables[0].Rows.Count;
                if (ii > 0)
                {
                    GridView4.DataSource = (ds5);
                    GridView4.DataBind();
                }
                else
                {
                    Response.Clear();
                    Response.Write("<script language=\"javascript\" type=\"text/javascript\">alert('Information Not Found');</script>");
                    Response.Write("Information Not Found");
                }*/
                if (DropDownList4.SelectedItem.Text.ToString().ToLower() == "date")
                {
                    Table1.Visible = true;
                    Table2.Visible = false;
                    Table3.Visible = false;
                    GridView4.Visible = true;
                    GridView3.Visible = false;
                    GridView2.Visible = false;
                    GridView1.Visible = false;
                    
                }
                else if (DropDownList4.SelectedItem.Text.ToString().ToLower() == "type")
                {
                    Table1.Visible = false;
                    Table2.Visible = false;
                    Table3.Visible = true;
                    GridView4.Visible = true;
                    GridView3.Visible = false;
                    GridView2.Visible = false;
                    GridView1.Visible = false;
                }
                else
                {
                    Table1.Visible = false;
                    Table2.Visible = true;
                    Table3.Visible = false;
                    GridView4.Visible = true;
                    GridView3.Visible = false;
                    GridView2.Visible = false;
                    GridView1.Visible = false;
                }
            }
        }

        protected void bt1_Click(object sender, EventArgs e)
        {
            Session.Add("page", null);
            if (Session["reg"] == null) Response.Redirect("login.aspx");
            else if (Session["reg"].ToString() == "admin") Response.Redirect("Edit.aspx");
            else Response.Redirect("profile.aspx");
        }

        protected void Bt2_Click(object sender, EventArgs e)
        {
            Session.Clear();
            bt2.Visible = false;
            bt1.Text = "Login";
        }
    }
}