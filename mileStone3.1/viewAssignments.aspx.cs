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
    public partial class viewAssignments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand viewCourse = new SqlCommand("InstructorViewAcceptedCoursesByAdmin", conn);
            viewCourse.CommandType = CommandType.StoredProcedure;


            string id = Session["instructor"].ToString();
            viewCourse.Parameters.Add(new SqlParameter("@instrId", Int16.Parse(id)));
            conn.Open();


            SqlDataReader rdr = viewCourse.ExecuteReader(CommandBehavior.CloseConnection);

            int c = 1;
            courses.Items.Insert(0, new ListItem("Select a course", ""));
            courses2.Items.Insert(0, new ListItem("Select a course", ""));

            while (rdr.Read())
            {
                String courseName = rdr.GetString(rdr.GetOrdinal("name"));
                Int32 ins = rdr.GetInt32(rdr.GetOrdinal("id"));
                courses.Items.Insert(c, new ListItem(courseName, ins.ToString()));
                courses2.Items.Insert(c, new ListItem(courseName, ins.ToString()));
                c++;
            }
        }

        protected void course_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            
            DataTable conn2 = new DataTable();

            SqlCommand viewAssignment = new SqlCommand("InstructorViewAssignmentsStudents", conn);
            viewAssignment.CommandType = CommandType.StoredProcedure;

            if(courses.SelectedValue == "")
            {
                MessageBox.Show("Fields Required !!");
            }
            else { 
            string id = Session["instructor"].ToString();
            viewAssignment.Parameters.Add(new SqlParameter("@instrId", Int16.Parse(id)));
            viewAssignment.Parameters.Add(new SqlParameter("@cid", Int16.Parse(courses.SelectedValue)));

            try
            {
                conn.Open();
                SqlDataAdapter conn1 = new SqlDataAdapter(viewAssignment);

                conn1.Fill(conn2);
                assignments.DataSource = conn2;
                assignments.DataBind();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            students.Items.Clear();
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand listStudents = new SqlCommand("listStudents", conn);
            listStudents.CommandType = CommandType.StoredProcedure;

            if(courses2.SelectedValue == "")
            {
                MessageBox.Show("Fields Required !!");
            }
            else { 
            listStudents.Parameters.Add(new SqlParameter("@cid", Int16.Parse(courses2.SelectedValue)));

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

        protected void button_Click(object sender, EventArgs e)
        {
            
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand gradeStudents = new SqlCommand("InstructorgradeAssignmentOfAStudent", conn);
            gradeStudents.CommandType = CommandType.StoredProcedure;

            if (assignmentNumber.Text == "" || assignmentType.Text == "" || students.SelectedValue == "" || courses2.SelectedValue == "")
            {
                MessageBox.Show("Fields Required !!!");
            }
            else
            {
                string id = Session["instructor"].ToString();
                gradeStudents.Parameters.Add(new SqlParameter("@instrId", Int16.Parse(id)));
                gradeStudents.Parameters.Add(new SqlParameter("@sid", Int16.Parse(students.SelectedValue)));
                gradeStudents.Parameters.Add(new SqlParameter("@cid", Int16.Parse(courses2.SelectedValue)));
                gradeStudents.Parameters.Add(new SqlParameter("@assignmentNumber", Int16.Parse(assignmentNumber.Text)));
                gradeStudents.Parameters.Add(new SqlParameter("@type", assignmentType.Text));
                gradeStudents.Parameters.Add(new SqlParameter("@grade", decimal.Parse(grade.Text)));

                try
                {
                    conn.Open();
                    gradeStudents.ExecuteNonQuery();
                }catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
                course_Click(sender,e);
            }
        }
    }
}