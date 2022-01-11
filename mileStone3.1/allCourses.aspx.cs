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
    public partial class allCourses : System.Web.UI.Page
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
                    if (!(rdr.IsDBNull(5)))
                    {
                        bool Accepted = (bool)(rdr["accepted"]);
                        Label lbl_Accepted = new Label();
                        lbl_Accepted.Text = "Accepted: " + Accepted + "  <br /> <br />";
                        form1.Controls.Add(lbl_Accepted);
                    }






                }


            }
            else {
                Response.Write("This action is done by admins only");
            }

        }

    }

}