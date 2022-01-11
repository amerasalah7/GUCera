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
    public partial class ViewAssignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ViewAss(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int course = Int16.Parse(CourseId.Text);
            int student = (int)Session["id"];


            SqlCommand loginproc = new SqlCommand("viewAssign", conn);
            loginproc.CommandType = CommandType.StoredProcedure;
            loginproc.Parameters.Add(new SqlParameter("@courseId", course));
            loginproc.Parameters.Add(new SqlParameter("@Sid ", student));

            conn.Open();
            SqlDataReader rdr = loginproc.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string assignmentContent = rdr.GetString(rdr.GetOrdinal("content"));
               

                Label lbl_AssignmentContent = new Label();
                lbl_AssignmentContent.Text = "Content "+ assignmentContent + ",";
                form1.Controls.Add(lbl_AssignmentContent);

                Int32 Assignmentcid = (Int32)(rdr["cid"]);


                Label lbl_Assignmentcid = new Label();
                lbl_Assignmentcid.Text = "Course id " + Assignmentcid + ",";
                form1.Controls.Add(lbl_Assignmentcid);

                Int32 Assignmentnumber = (Int32)(rdr["number"]);


                Label lbl_Assignmentnumber = new Label();
                lbl_Assignmentnumber.Text = "Assignment number " + Assignmentnumber + ",";
                form1.Controls.Add(lbl_Assignmentnumber);

                string AssignmentType = rdr.GetString(rdr.GetOrdinal("type"));


                Label lbl_AssignmentType = new Label();
                lbl_AssignmentType.Text = "Assignment Type" + AssignmentType + ",";
                form1.Controls.Add(lbl_AssignmentType);

                Int32 AssignmentFullgrade = (Int32)(rdr["fullGrade"]);
                Label lbl_AssignmentFullgrade = new Label();
                lbl_AssignmentFullgrade.Text = "Assignment Full grade " + AssignmentFullgrade + ",";
                form1.Controls.Add(lbl_AssignmentFullgrade);


                decimal AssignmentWeight = rdr.GetDecimal(rdr.GetOrdinal("weight"));
                Label lbl_AssignmentWeight = new Label();
                lbl_AssignmentWeight.Text = "Assignment Weight " + AssignmentWeight + ",";
                form1.Controls.Add(lbl_AssignmentWeight);


                DateTime AssignmentDeadline = rdr.GetDateTime(rdr.GetOrdinal("deadline"));
                Label lbl_AssignmentDeadline = new Label();
                lbl_AssignmentDeadline.Text = "Assignment deadline " + AssignmentDeadline +"<br>";
                form1.Controls.Add(lbl_AssignmentDeadline);



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

        protected void viewAssignment(object sender, EventArgs e)
        {
            Response.Redirect("ViewAssignment.aspx");
        }

        protected void ViewGrade(object sender, EventArgs e)
        {
            Response.Redirect("ViewGrade.aspx");
        }

    }
}

//Int32 CreditHours = (Int32)(rdr["creditHours"]);
//decimal Price = rdr.GetDecimal(rdr.GetOrdinal("price"));
//DateTime issueDate = DateTime.Parse(issdate.Text);