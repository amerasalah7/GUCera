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
    public partial class List_certificates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Certificate_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int course = Int16.Parse(CourseId.Text);
            int student = (int)Session["id"];


            SqlCommand loginproc = new SqlCommand("viewCertificate", conn); 
            loginproc.CommandType = CommandType.StoredProcedure;
            loginproc.Parameters.Add(new SqlParameter("@sid ", student));
            loginproc.Parameters.Add(new SqlParameter("@cid ", course));


            conn.Open();
            SqlDataReader rdr = loginproc.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                //Get the value of the attribute name in the Company table
                Int32 StudentId = (Int32)rdr["sid"];
                Int32 CourseId = (Int32)rdr["cid"];

                DateTime issueDate = rdr.GetDateTime(rdr.GetOrdinal("issueDate"));

                //Create a new label and add it to the HTML form
                Label lbl_StudentId = new Label();
                lbl_StudentId.Text = "Student ID:  " + StudentId + ",";
                form1.Controls.Add(lbl_StudentId);

                Label lbl_CourseId = new Label();
                lbl_CourseId.Text = "CourseId:  " + CourseId + ",";
                form1.Controls.Add(lbl_CourseId);

                Label lbl_IssueDate = new Label();
                lbl_IssueDate.Text = "IssueDate:  " + issueDate + ",";
                form1.Controls.Add(lbl_IssueDate);

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