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
    public partial class viewFeedback : System.Web.UI.Page
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

            while (rdr.Read())
            {
                String courseName = rdr.GetString(rdr.GetOrdinal("name"));
                Int32 ins = rdr.GetInt32(rdr.GetOrdinal("id"));
                courses.Items.Insert(c, new ListItem(courseName,ins.ToString()));
                c++;
            }
            
        }

        protected void show_Click(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            DataTable conn2 = new DataTable();
            if (courses.SelectedValue == "") {
                MessageBox.Show("Make sure you are choosing a course !!!");
            }       
            else { 
            SqlCommand viewfeedback = new SqlCommand("ViewFeedbacksAddedByStudentsOnMyCourse", conn);
            viewfeedback.CommandType = CommandType.StoredProcedure;

            string id = Session["instructor"].ToString();
            viewfeedback.Parameters.Add(new SqlParameter("@instrId", Int16.Parse(id)));
            viewfeedback.Parameters.Add(new SqlParameter("@cid", Int16.Parse(courses.SelectedValue)));


            SqlDataAdapter conn1 = new SqlDataAdapter(viewfeedback);
           
            conn1.Fill(conn2);
            feedback.DataSource = conn2;
            feedback.DataBind();
            
            conn.Close();
            }

        }
    }
}