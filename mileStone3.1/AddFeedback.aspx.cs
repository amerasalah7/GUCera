using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class AddFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendComment_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

           int course = Int16.Parse(CourseId.Text);
           int student = (int)Session["id"];
            String Comm = Comment.Text;

            SqlCommand loginproc = new SqlCommand("addFeedback", conn);
            loginproc.CommandType = CommandType.StoredProcedure;
            loginproc.Parameters.Add(new SqlParameter("@cid", course));
            loginproc.Parameters.Add(new SqlParameter("@sid ", student));
            loginproc.Parameters.Add(new SqlParameter("@comment", Comm));
           
            conn.Open();
            loginproc.ExecuteNonQuery();
            conn.Close();
            Response.Write("Feedback Submitted Sucessfully");

        }
        protected void MobileNumber(object sender, EventArgs e)

        {
            Response.Redirect("AddMobileNumber.aspx");
        }

        protected void ViewProfile(object sender, EventArgs e)
        {
            Response.Redirect("MyProfile.aspx");
        }
        protected void ViewPromo(object sender, EventArgs e)
        {
            Response.Redirect("PromoCodes.aspx");
        }

        protected void AddCreditCard(object sender, EventArgs e)
        {
            Response.Redirect("CreditCard.aspx");
        }

        protected void ViewCourses(object sender, EventArgs e)
        {
            Response.Redirect("Courses.aspx");
        }
        protected void addFeedback(object sender, EventArgs e)
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