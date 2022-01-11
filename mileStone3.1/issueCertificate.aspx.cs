using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;


namespace GUCera1
{
    public partial class issueCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand viewCourse = new SqlCommand("InstructorViewAcceptedCoursesByAdmin", conn);
            viewCourse.CommandType = CommandType.StoredProcedure;

            students.Items.Clear();
            courses.Items.Clear();

            string id = Session["instructor"].ToString();
            viewCourse.Parameters.Add(new SqlParameter("@instrId", Int16.Parse(id)));
            conn.Open();

            SqlDataReader rdr = viewCourse.ExecuteReader(CommandBehavior.CloseConnection);

            int c = 1;
            courses.Items.Insert(0, new ListItem("Select a course", ""));

            while (rdr.Read())
            {
                String courseName = rdr.GetString(rdr.GetOrdinal("name"));
                Int32 ins = rdr.GetInt32(rdr.GetOrdinal("id"));
                courses.Items.Insert(c, new ListItem(courseName, ins.ToString()));
                c++;
            }

            students.Items.Insert(0, new ListItem("Please select a course"));

        }

        protected void issue_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand issueC = new SqlCommand("InstructorIssueCertificateToStudent", conn);
            issueC.CommandType = CommandType.StoredProcedure;

            if(courses.SelectedValue == "" || students.SelectedValue == "")
            {
                MessageBox.Show("Fields Required !!");
            }
            else { 
            issueC.Parameters.Add(new SqlParameter("@cid", Int16.Parse(courses.SelectedValue)));
            issueC.Parameters.Add(new SqlParameter("@sid", Int16.Parse(students.SelectedValue)));
            string id = Session["instructor"].ToString();
            issueC.Parameters.Add(new SqlParameter("@insId", Int16.Parse(id)));
            issueC.Parameters.Add(new SqlParameter("@issueDate", DateTime.Now.ToString()));

            try
            {
                conn.Open();
                issueC.ExecuteNonQuery();

                issued.Text = "Issued Successfully !!!";
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            conn.Close();


            }

        }

        protected void selectCourse_Click(object sender, EventArgs e)
        {
            students.Items.Clear();
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (courses.SelectedValue == "")
            {
                MessageBox.Show("Fields Required!!!");
            }
            else
            {
                SqlCommand listStudents = new SqlCommand("listStudents", conn);
                listStudents.CommandType = CommandType.StoredProcedure;

                listStudents.Parameters.Add(new SqlParameter("@cid", Int16.Parse(courses.SelectedValue)));

                conn.Open();
                SqlDataReader rdr1 = listStudents.ExecuteReader(CommandBehavior.CloseConnection);

                int c = 0;
                while (rdr1.Read())
                {
                    string fname = rdr1.GetString(rdr1.GetOrdinal("firstName"));
                    string lname = rdr1.GetString(rdr1.GetOrdinal("lastName"));
                    Int32 sid = rdr1.GetInt32(rdr1.GetOrdinal("sid"));
                    string fullname = fname + "   " + lname;
                    students.Items.Insert(c, new ListItem(fullname, sid.ToString()));
                }
            }

        }
    }
}