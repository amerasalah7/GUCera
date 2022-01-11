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
    public partial class defineAssignment : System.Web.UI.Page
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
            courses.Items.Insert(0, new ListItem("Select a course",""));

            while (rdr.Read())
            {
                String courseName = rdr.GetString(rdr.GetOrdinal("name"));
                Int32 ins = rdr.GetInt32(rdr.GetOrdinal("id"));
                courses.Items.Insert(c, new ListItem(courseName, ins.ToString()));
                c++;
            }

        }

        protected void addAss_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            if ((quiz.Checked || project.Checked || exam.Checked) &&  Calendar1.SelectedDate.ToString() != "" && courses.SelectedValue != "")
            {
                int ins = Int16.Parse(Session["instructor"].ToString());
                int course = Int16.Parse(courses.SelectedValue);
                int num = Int16.Parse(number.Text);
                int full = Int16.Parse(fullgrade.Text);
                decimal wei = Decimal.Parse(weight.Text);
                string type1;
                if (quiz.Checked)
                {
                     type1 = "quiz";
                }
                else if (project.Checked)
                {
                     type1 = "project";
                }
                else 
                {
                     type1 = "exam";
                }
                
                string deadline1 = Calendar1.SelectedDate.ToString();
                string content1 = content.Text;
                SqlCommand addAssin = new SqlCommand("DefineAssignmentOfCourseOfCertianType", conn);
                addAssin.CommandType = CommandType.StoredProcedure;
                addAssin.Parameters.Add(new SqlParameter("@instId", ins));
                addAssin.Parameters.Add(new SqlParameter("@cid", course));
                addAssin.Parameters.Add(new SqlParameter("@number", num));
                addAssin.Parameters.Add(new SqlParameter("@type", type1));
                addAssin.Parameters.Add(new SqlParameter("@fullGrade", full));
                addAssin.Parameters.Add(new SqlParameter("@weight", wei));
                addAssin.Parameters.Add(new SqlParameter("@deadline", deadline1));
                addAssin.Parameters.Add(new SqlParameter("@content", content1));

                try
                {
                    conn.Open();
                    addAssin.ExecuteNonQuery();
                }catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();

                added.Text = "Added Successfully!!!";
                number.Text = String.Empty;
                fullgrade.Text = String.Empty;
                weight.Text = String.Empty;
                content.Text = String.Empty;

            }
            else
            {
               MessageBox.Show("Make Sure You Fill All Requirements !!") ;
            }

        }

        protected void courses_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}