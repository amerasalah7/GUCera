using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace milestone3
{
    public partial class Courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();


            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand courses = new SqlCommand("availableCourses", conn);
            courses.CommandType = CommandType.StoredProcedure;
            conn.Open();
            if (!IsPostBack)
            {
                list.DataSource = courses.ExecuteReader();// <-- Get your data from somewhere.
                list.DataTextField = "name";
                list.DataValueField = "id";

                list.DataBind();
            }
          //  SqlDataReader rdr = courses.ExecuteReader(CommandBehavior.CloseConnection);
            //while(rdr.Read())
           // {
            //    String courseName = rdr.GetString(rdr.GetOrdinal("name"));
             //   Label name = new Label();
             //   name.Text = courseName + "<br >";
             //   form1.Controls.Add(name);
                
            //}
            

            conn.Close();

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

        protected void ViewContent(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();


            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand courses = new SqlCommand("viewInstructors", conn);
            courses.CommandType = CommandType.StoredProcedure;
            int id = Int16.Parse(list.SelectedValue);
            courses.Parameters.Add(new SqlParameter("@cid", id));
            conn.Open();
            list2.Visible = true;
            // if (!IsPostBack)
            // {
            // <-- Get your data from somewhere.
            list2.DataSource = courses.ExecuteReader();
            list2.DataTextField = "firstName";
                list2.DataValueField = "id";
            
                list2.DataBind();
            // }

            
            conn.Close();
            Button6.Visible = true;
        }

       
        protected void OnSelectedIndexChangedMethod(object sender, EventArgs e)
        {

            int id = Int16.Parse(list.SelectedValue);
            

            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();


            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand courses = new SqlCommand("courseInformation", conn);
            conn.Open();
            courses.CommandType = CommandType.StoredProcedure;
            courses.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader rdr = courses.ExecuteReader(CommandBehavior.CloseConnection);

            while (rdr.Read())
            {
                if (!(rdr.IsDBNull(0)))
                {
                    Int32 courseName = (Int32)(rdr["id"]);


                    Label name = new Label();
                    name.Text = "id :  "+ courseName + "<br >";
                    form1.Controls.Add(name);

                }
                if (!(rdr.IsDBNull(1)))
                {
                  Int32 courseName = (Int32)rdr["creditHours"];


                    Label name = new Label();
                    name.Text ="Credit Hours :"+ courseName + "<br >";
                    form1.Controls.Add(name);

                }
                if (!(rdr.IsDBNull(2)))
                {
                    String courseName = rdr.GetString(rdr.GetOrdinal("name"));


                    Label name = new Label();
                    name.Text ="courseName :"+courseName + "<br >";
                    form1.Controls.Add(name);

                }
                if (!(rdr.IsDBNull(3)))
                {
                    String courseName = rdr.GetString(rdr.GetOrdinal("courseDescription"));


                    Label name = new Label();
                    name.Text = "Course Description:  " +courseName + "<br >";
                    form1.Controls.Add(name);

                }
                if (!(rdr.IsDBNull(4)))
                {
                    decimal price = rdr.GetDecimal(rdr.GetOrdinal("price"));


                    Label name = new Label();
                    name.Text ="price : "+ price + "<br >";
                    form1.Controls.Add(name);

                }
                if (!(rdr.IsDBNull(5)))
                {
                    String courseName = rdr.GetString(rdr.GetOrdinal("content"));


                    Label name = new Label();
                    name.Text = "Content : "+courseName + "<br >";
                    form1.Controls.Add(name);

                }
                if (!(rdr.IsDBNull(6)))
                {
                    Int32 courseName = (Int32)rdr["adminId"];


                    Label name = new Label();
                    name.Text = "adminID : "+courseName + "<br >";
                    form1.Controls.Add(name);

                }

                if  (!(rdr.IsDBNull(7)))
                {
                      Int32 courseName = (Int32) rdr["instructorId"];
                    
                    
                        Label name = new Label();
                        name.Text = "Instructor ID :" +courseName + "<br >";
                        form1.Controls.Add(name);
                    
                }

                
                /*if (!(rdr.IsDBNull(8)))
                {
                    String courseName =(String) rdr.GetString(rdr.GetOrdinal("accepted"));


                    Label name = new Label();
                    name.Text = "Accepted : " + courseName + "<br >";
                    form1.Controls.Add(name);

                }*/
                if (!(rdr.IsDBNull(9)))
                {
                    String courseName = rdr.GetString(rdr.GetOrdinal("firstName"));


                    Label name = new Label();
                    name.Text = "Instructor First Name  :" + courseName + "<br >";
                    form1.Controls.Add(name);

                }
                if (!(rdr.IsDBNull(10)))
                {
                    String courseName = rdr.GetString(rdr.GetOrdinal("lastName"));


                    Label name = new Label();
                    name.Text = "Instructor Last Name  :" + courseName + "<br >";
                    form1.Controls.Add(name);

                }
              
            }

        }

        protected void enroll(object sender, EventArgs e)
        {
           
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();


            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand courses = new SqlCommand("enrollInCourse", conn);
            courses.CommandType = CommandType.StoredProcedure;
            conn.Open();
           
               

            int cid = Int16.Parse(list.SelectedValue);
            int instid = Int16.Parse(list2.SelectedValue);
            int id = (int)Session["id"];
            courses.Parameters.Add(new SqlParameter("@cid", cid));
            courses.Parameters.Add(new SqlParameter("@sid", id));
            courses.Parameters.Add(new SqlParameter("@instr", instid));
            Response.Write("course enrolled in succsesfully");
            courses.ExecuteNonQuery();

            conn.Close();
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