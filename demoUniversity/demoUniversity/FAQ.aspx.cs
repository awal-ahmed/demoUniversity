﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace demoUniversity
{
    public partial class FAQ : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Projectdatabase.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                connect.Close();
            }
            connect.Open();
            cons_table();
            //Button1.Visible = true;
            Button2.Visible = false;
            Button3.Visible = false;
            //Table1.Visible = false;
            //Button4.Visible = false;
            Table2.Visible = false;
            Table3.Visible = false;

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
            else if(Session["reg"].ToString() == "admin")
            {
                                bt1.Text = "admin";
                Response.Write("Admin");
            }
            if (Session["reg"] == null)
            {

            }
            else if (Session["reg"].ToString() == "admin")
            {
                //Button1.Visible = false;
                Button3.Visible = true;
                //Table1.Visible = false;
                //Button4.Visible = true;
            }
            else
            {
                //Button1.Visible = false;
                Button2.Visible = true;
                //Table1.Visible = false;
                //Button4.Visible = true;
                //Table1.Visible = false;
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Button1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            //Table1.Visible = true;
            //Button4.Visible = false;
            cons_table();
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Button1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            //Table1.Visible = false;
            //Button4.Visible = true;
            Table2.Visible = true;
            cons_table();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Table5.Visible = false;
            SqlCommand cmd5 = new SqlCommand("select * from faq ", connect);
            cmd5.ExecuteNonQuery();
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            int ii = ds5.Tables[0].Rows.Count;
            if (ii > 0)
            {
                GridView1.DataSource = (ds5);
                GridView1.DataBind();

            }
            //Button1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            //Table1.Visible = false;
            //Button4.Visible = true;
            Table2.Visible = false;
            Table3.Visible = true;
            GridView1.Visible = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {


            //Button1.Visible = true;
            Button2.Visible = false;
            Button3.Visible = false;
            //Table1.Visible = false;
            //Button4.Visible = false;
            Table2.Visible = false;
            Table3.Visible = false;
            GridView1.Visible = false;
            cons_table();
            Table5.Visible = true;
        }



        protected void Button6_Click(object sender, EventArgs e)
        {
            SqlCommand cmd4 = connect.CreateCommand();
            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "insert into faq(q) values ('" + TextBox3.Text + "')";
            if (TextBox3.Text.ToString() != "") cmd4.ExecuteNonQuery();
            else Response.Write("Empty Question\n");

            //Button1.Visible = false;
            Button2.Visible = true;
            Button3.Visible = false;
            //Table1.Visible = false;
            //Button4.Visible = true;
            cons_table();
            Table2.Visible = false;
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("select id from faq where id = '" + TextBox4.Text + "'", connect);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds2 = new DataSet();
            da1.Fill(ds2);
            int j = ds2.Tables[0].Rows.Count;
            if (j > 0)
            {
                SqlCommand cmd6 = new SqlCommand("delete from faq where id='" + TextBox4.Text + "'", connect);
                cmd6.ExecuteNonQuery();
                SqlDataAdapter da6 = new SqlDataAdapter(cmd6);
                

            }
            else Response.Write("<div style='background-color:green ;color:red;font-size:20px'> Invalid id selected</div>");


            SqlCommand cmd5 = new SqlCommand("select * from faq ", connect);
            cmd5.ExecuteNonQuery();
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            int ii = ds5.Tables[0].Rows.Count;
            if (ii > 0)
            {
                GridView1.DataSource = (ds5);
                GridView1.DataBind();

            }
           // Button1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            //Table1.Visible = false;
            //Button4.Visible = true;
            Table2.Visible = false;
            Table3.Visible = true;
            GridView1.Visible = true;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("select id from faq where id = '" + TextBox4.Text + "'", connect);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds2 = new DataSet();
            da1.Fill(ds2);
            int j = ds2.Tables[0].Rows.Count;
            if (j > 0)
            {
                String sql = "UPDATE faq SET a='" + TextBox5.Text + "' where id='" + TextBox4.Text + "' ";
                SqlCommand command = new SqlCommand(sql, connect);
                command.ExecuteNonQuery();
               

            }
            else Response.Write("<div style='background-color:green ;color:red;font-size:20px'> Invalid id selected</div>");


            SqlCommand cmd5 = new SqlCommand("select * from faq ", connect);
            cmd5.ExecuteNonQuery();
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            int ii = ds5.Tables[0].Rows.Count;
            if (ii > 0)
            {
                GridView1.DataSource = (ds5);
                GridView1.DataBind();

            }
            //Button1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            //Table1.Visible = false;
            //Button4.Visible = true;
            Table2.Visible = false;
            Table3.Visible = true;
            GridView1.Visible = true;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        void cons_table()
        {
            Response.Clear();
            String sql = "SELECT * FROM faq";
            SqlCommand command = new SqlCommand(sql, connect);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            int j = dataSet.Tables[0].Rows.Count;
            //Table5.Dispose = true;
            Table5.Rows.Clear();

            for (int i = 0; i < j; i++)
            {
                DataTable tables = dataSet.Tables[0];

                
                TableRow row = new TableRow();
                /*TableCell cell = new TableCell();
                cell.Width=5;
                cell.BackColor = System.Drawing.Color.LightGreen;
                row.Cells.Add(cell);*/
                TableCell cell1 = new TableCell();
                cell1.BackColor = System.Drawing.Color.FromArgb(0);
                cell1.Text = tables.Rows[i][1].ToString();
                cell1.ForeColor = System.Drawing.Color.Blue;
                cell1.Font.Size = 25;
                cell1.Font.Bold = true;
                row.Cells.Add(cell1);
                
                Table5.Rows.Add(row);
                
                TableRow row1 = new TableRow();
                /*TableCell cell2 = new TableCell();
                cell2.Width = 5;
                cell2.BackColor = System.Drawing.Color.LightGreen;
                row1.Cells.Add(cell2);*/
                TableCell cell11 = new TableCell();
                Label lb1 = new Label();
                lb1.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                lb1.BackColor = System.Drawing.Color.FromArgb(0);
                lb1.Width = 20;
                cell11.Controls.Add(lb1);
                
                string st= tables.Rows[i][2].ToString();
                Label lb2 = new Label();
                st = "&nbsp; &nbsp; &nbsp;  " + st;
                lb2.Text = st;
                lb2.Font.Size = 15;
 
                lb2.BackColor = System.Drawing.Color.FromArgb(0);
                
                cell11.Controls.Add(lb2);
                
               // cell11.Text = st;
                cell11.BackColor = System.Drawing.Color.FromArgb(0);  
                row1.Cells.Add(cell11);
                Table5.Rows.Add(row1);
                TableRow row2 = new TableRow();
                /*TableCell cell = new TableCell();
                cell.Width=5;
                cell.BackColor = System.Drawing.Color.LightGreen;
                row.Cells.Add(cell);*/
                TableCell cell12 = new TableCell();
                cell12.BackColor = System.Drawing.Color.FromArgb(0);
                cell12.Text = "&nbsp;";
                row2.Cells.Add(cell12);

                Table5.Rows.Add(row2);

            }
            // Loop through rows

        }

        protected void Bt2_Click(object sender, EventArgs e)
        {
            Session.Clear();
            bt2.Visible = false;
            bt1.Text = "Login";
                       // Button1.Visible = true;
            Button2.Visible = false;
            Button3.Visible = false;
           // Table1.Visible = false;
           // Button4.Visible = false;
            Table2.Visible = false;
            Table3.Visible = false;
            GridView1.Visible = false;
            cons_table();
            Table5.Visible = true;
        }

        protected void bt1_Click(object sender, EventArgs e)
        {
            Session.Add("page", "FAQ.aspx");

            if (Session["reg"] == null) Response.Redirect("login.aspx");
            else if (Session["reg"].ToString() == "admin") Response.Redirect("adprofile.aspx");
            else Response.Redirect("profile.aspx");
        }
    }
}