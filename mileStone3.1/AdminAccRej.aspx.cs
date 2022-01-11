using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mileStone3._1
{
    public partial class AdminAccRej : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("AdminViewAllCoursesWithid", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            if ((int)(Session["type"]) == 1)
            {
                while (rdr.Read())
                {
                    if ((bool)(rdr["accepted"]) == false)
                    {
                        if (!(rdr.IsDBNull(1)))
                        {
                            string courseName = rdr.GetString(rdr.GetOrdinal("name"));
                            Label lbl_CourseName = new Label();
                            lbl_CourseName.Text = "  course Name: " + courseName + ", ";
                            form1.Controls.Add(lbl_CourseName);
                        }
                        if (!(rdr.IsDBNull(2)))
                        {
                            Int32 CreditHours = (Int32)(rdr["creditHours"]);
                            Label lbl_CreditHours = new Label();
                            lbl_CreditHours.Text = "Credit Hours: " + CreditHours + ", ";
                            form1.Controls.Add(lbl_CreditHours);
                        }
                        if (!(rdr.IsDBNull(3)))
                        {
                            decimal Price = rdr.GetDecimal(rdr.GetOrdinal("price"));
                            Label lbl_Price = new Label();
                            lbl_Price.Text = "Price: " + Price + ", ";
                            form1.Controls.Add(lbl_Price);
                        }
                        if (!(rdr.IsDBNull(4)))
                        {
                            String content = rdr.GetString(rdr.GetOrdinal("content"));
                            Label lbl_Content = new Label();
                            lbl_Content.Text = "Content: " + content + ", ";
                            form1.Controls.Add(lbl_Content);
                        }
                        

                        bool Accepted = (bool)(rdr["accepted"]);
                        Label lbl_Accepted = new Label();
                        lbl_Accepted.Text = "Accepted: " + Accepted;
                        form1.Controls.Add(lbl_Accepted);




                        //Create a new label and add it to the HTML form











                        Label test = new Label();
                        test.Text = "" + (Int32)(rdr["id"]);
                        test.Visible = false;
                        form1.Controls.Add(test);

                        Button b1 = new Button();
                        b1.Text = "Add";
                        //b1.Click += new EventHandler((sender, e => Accept(sender , e , 5));
                        b1.Click += delegate (object sender1, EventArgs e1) { Accept(sender1, e1, Int16.Parse(test.Text)); };
                        form1.Controls.Add(b1);


                        Label space = new Label();
                        space.Text = " " + "  <br /> <br />";
                        form1.Controls.Add(space);
                    }
                }

            }
            else {
                Response.Write("This action can be done by admins only");
            }
        }

        public void Accept(object sender, EventArgs e, int cid)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("AdminAcceptRejectCourse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            int Aid = (int)(Session["id"]);
            int courseid = cid;

            cmd.Parameters.Add(new SqlParameter("@adminId", Aid));
            cmd.Parameters.Add(new SqlParameter("@courseId", courseid));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("AdminAccRej.aspx", true);

        }
    }
}