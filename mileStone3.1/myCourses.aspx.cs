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
    public partial class myCourses : System.Web.UI.Page
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
            updateCourse.Items.Insert(0, new ListItem("Select a course", ""));
            addInstructor.Items.Insert(0, new ListItem("Select a course", ""));

            while (rdr.Read())
            {
                String courseName = rdr.GetString(rdr.GetOrdinal("name"));
                Int32 ins = rdr.GetInt32(rdr.GetOrdinal("id"));    
                courses.Items.Insert(c, new ListItem(courseName,ins.ToString()));
                updateCourse.Items.Insert(c, new ListItem(courseName, ins.ToString()));
                addInstructor.Items.Insert(c, new ListItem(courseName, ins.ToString()));
                c++;
            }

            conn.Close();
            conn.Open();
            SqlCommand viewInstructor = new SqlCommand("listInstructors", conn);
            viewInstructor.CommandType = CommandType.StoredProcedure;
            viewInstructor.Parameters.Add(new SqlParameter("@id", Int16.Parse(id)));

            SqlDataReader rdr1 = viewInstructor.ExecuteReader(CommandBehavior.CloseConnection);
            c = 1;
            selectIns.Items.Insert(0, new ListItem("Select a instructor", ""));
            while (rdr1.Read())
            {
                string fname = rdr1.GetString(rdr1.GetOrdinal("firstName"));
                string lname = rdr1.GetString(rdr1.GetOrdinal("lastName"));
                Int32 insid = rdr1.GetInt32(rdr1.GetOrdinal("id"));
                string fullname = fname + "   " + lname;
                selectIns.Items.Insert(c, new ListItem(fullname, insid.ToString()));
            }
           
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (texthere.Text == "" || updateCourse.SelectedValue == "")
            {
                MessageBox.Show("Please fill required fields!!!");
            }
            else
            {
                int ins = Int16.Parse(Session["instructor"].ToString());
                int course = Int16.Parse(updateCourse.SelectedValue);
                string text = texthere.Text;

                if (content.Checked)
                {
                    SqlCommand contentAdd = new SqlCommand("UpdateCourseContent", conn);
                    contentAdd.CommandType = CommandType.StoredProcedure;
                    contentAdd.Parameters.Add(new SqlParameter("@instrId", ins));
                    contentAdd.Parameters.Add(new SqlParameter("@courseId", course));
                    contentAdd.Parameters.Add(new SqlParameter("@content", text));
                    conn.Open();
                    contentAdd.ExecuteNonQuery();
                    conn.Close();
                    Label1.Text = " Added Successfully";
                }
                else
                    if (descrp.Checked)
                {
                    SqlCommand desAdd = new SqlCommand("UpdateCourseDescription", conn);
                    desAdd.CommandType = CommandType.StoredProcedure;
                    desAdd.Parameters.Add(new SqlParameter("@instrId", ins));
                    desAdd.Parameters.Add(new SqlParameter("@courseId", course));
                    desAdd.Parameters.Add(new SqlParameter("@courseDescription", text));
                    conn.Open();
                    desAdd.ExecuteNonQuery();
                    conn.Close();
                    Label1.Text = " Added Successfully";
                }
            }   
            
        }

        protected void addIns_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if(addInstructor.SelectedValue == "" || selectIns.SelectedValue == "")
            {
                MessageBox.Show("Required Fields !!!");
            }
            else { 
            
            int ins = Int16.Parse(Session["instructor"].ToString());
            int course = Int16.Parse(addInstructor.SelectedValue);
            int added = Int16.Parse(selectIns.SelectedValue);


            SqlCommand insAdd = new SqlCommand("AddAnotherInstructorToCourse", conn);
            insAdd.CommandType = CommandType.StoredProcedure;
            insAdd.Parameters.Add(new SqlParameter("@insid", added));
            insAdd.Parameters.Add(new SqlParameter("@cid", course));
            insAdd.Parameters.Add(new SqlParameter("@adderIns", ins));

                try
                {
                    conn.Open();
                    insAdd.ExecuteNonQuery();
                    insadd.Text = "Added Successfully !!";
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
            conn.Close();

           
            }

        }

     

        protected void courses_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        protected void choose_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if(courses.SelectedValue == "")
            {
                MessageBox.Show("Fields Required !!!");
            }
            else
            {
            SqlCommand viewCourse = new SqlCommand("listCourse", conn);
            viewCourse.CommandType = CommandType.StoredProcedure;
            conn.Open();
            DataTable conn2 = new DataTable();

            viewCourse.Parameters.Add(new SqlParameter("@cid", Int16.Parse(courses.SelectedValue)));


            SqlDataAdapter conn1 = new SqlDataAdapter(viewCourse);

            conn1.Fill(conn2);
            courses1.DataSource = conn2;
            courses1.DataBind();

            conn.Close();
            }
        }

        protected void addInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}