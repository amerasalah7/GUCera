using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace milestone3
{
   public partial class MyProfile : System.Web.UI.Page { 
        public static byte[] StrToByteArray(string value)
    {
        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
        return encoding.GetBytes(value);
    }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();


            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand profile = new SqlCommand("viewMyProfile", conn);
            profile.CommandType = CommandType.StoredProcedure;

            int id = (int)(Session["id"]);

            profile.Parameters.Add(new SqlParameter("@id", id));
            conn.Open();
            SqlDataReader rdr = profile.ExecuteReader(CommandBehavior.CloseConnection);




            if (rdr.Read())
            {
                Label name11 = new Label();
                name11.Text = "ID :  "+id + " <br ";
                form1.Controls.Add(name11);
                if (!(rdr.IsDBNull(3)))
                {
                    String firstName = rdr.GetString(rdr.GetOrdinal("firstName"));
                    Label name = new Label();
                    name.Text = "First Name :  " + firstName + "<br >";
                    form1.Controls.Add(name);
                }
                if (!(rdr.IsDBNull(4)))
                {
                    String lastName = rdr.GetString(rdr.GetOrdinal("lastName"));
                    Label name2 = new Label();
                    name2.Text = "Last Name :  " + lastName + "<br >";
                    form1.Controls.Add(name2);
                }
                if (!(rdr.IsDBNull(7)))
                {
                    String email = rdr.GetString(rdr.GetOrdinal("email"));
                    Label name3 = new Label();
                    name3.Text = "Email :  " + email + "<br >";
                    form1.Controls.Add(name3);
                }
                if (!(rdr.IsDBNull(8)))
                {
                    String address = rdr.GetString(rdr.GetOrdinal("address"));

                    Label name4 = new Label();
                    name4.Text = "Address :  " + address + "<br >";
                    form1.Controls.Add(name4);
                }
                if (!(rdr.IsDBNull(5)))
                {
                    String pass = rdr.GetString(rdr.GetOrdinal("password"));
                    Label name5 = new Label();
                    name5.Text = "Password :  " + pass + "<br >";
                    form1.Controls.Add(name5);
                }
                if (!(rdr.IsDBNull(6)))
                {
                    Byte[] gender = (byte[])(rdr.GetSqlBinary(rdr.GetOrdinal("gender")));

                    Label name6 = new Label();
                    name6.Text = "Gender :  " + gender[0] + "<br >";
                    form1.Controls.Add(name6);
                }
                if (!(rdr.IsDBNull(1)))
                {
                    Decimal GPA = rdr.GetDecimal(rdr.GetOrdinal("gpa"));
                    Label name7 = new Label();
                    name7.Text = "GPA :  " + GPA + "<br >";
                    form1.Controls.Add(name7);
                }


            }

            conn.Close();

        }
        protected void ViewPromo(object sender, EventArgs e)
        {
            Response.Redirect("PromoCodes.aspx");
        }

        protected void MobileNumber(object sender, EventArgs e)
        {

            Response.Redirect("AddMobileNumber.aspx");
        }

        protected void AddCreditCard(object sender, EventArgs e)
        {
            Response.Redirect("CreditCard.aspx");
        }

        protected void ViewCourses(object sender, EventArgs e)
        {
            Response.Redirect("Courses.aspx");
        }
        protected void AddFeedback(object sender, EventArgs e)
        {
            Response.Redirect("AddFeedback.aspx");
        }

        protected void ListCertificates(object sender, EventArgs e)
        {
            Response.Redirect("List certificates.aspx");
        }

        protected void SubmitAssignment(object sender, EventArgs e)
        {
            Response.Redirect("SubmitAssignment.aspx");
        }

        protected void ViewAssignment(object sender, EventArgs e)
        {
            Response.Redirect("ViewAssignment.aspx");
        }

        protected void ViewGrade(object sender, EventArgs e)
        {
            Response.Redirect("ViewGrade.aspx");
        }
        protected void ViewProfile(object sender, EventArgs e)
        {
            Response.Redirect("MyProfile.aspx");
        }



    }
}