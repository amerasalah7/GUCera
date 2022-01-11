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
    public partial class AddMobileNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Submit(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();


            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand cmd = new SqlCommand("AddMobile", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            String mobile = TextBox_mobile.Text;
            int id = (int)Session["id"];
            cmd.Parameters.Add(new SqlParameter("@ID",id));
            if (mobile.Equals(""))
            {
                Response.Write("please add a mobile number ");

            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@mobile_number", mobile));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("Mobile Number Added Succsesfully");
              
            }

        }
        protected void ViewPromo(object sender, EventArgs e)
        {
            Response.Redirect("PromoCodes.aspx");
        }

        protected void ViewProfile(object sender, EventArgs e)
        {
            Response.Redirect("MyProfile.aspx");
        }

        protected void AddCreditCard(object sender, EventArgs e)
        {
            Response.Redirect("CreditCard.aspx");
        }


        protected void ViewCourses(object sender, EventArgs e)
        {
            Response.Redirect("Courses.aspx");
        }
        protected void MobileNumber(object sender, EventArgs e)
        {

            Response.Redirect("AddMobileNumber.aspx");
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

    }
}