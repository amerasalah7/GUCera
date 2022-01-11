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
    public partial class registeration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Male_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void Female_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void signIn_Click(object sender, EventArgs e)

        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (firstname.Text == "" || lastname.Text == "" || password1.Text == "" || password2.Text == "" || email.Text == "" || address.Text == "")
            {
                MessageBox.Show("Fields Required !!!");
            }
            else
            {
                string first_name = firstname.Text;
                string last_name = lastname.Text;
                string password = password1.Text;
                string passwordC = password2.Text;
                string email1 = email.Text;
                int gender = -1;
                if(Male.Checked || Female.Checked)
                {
                    if (Male.Checked)
                    {
                        gender = 0;
                    }
                    else
                    if (Female.Checked)
                    {
                        gender = 1;
                    }
                    string address1 = address.Text;

                if(student.Checked || instructor.Checked) { 
                   if (student.Checked)
                    {
                        SqlCommand studentReg = new SqlCommand("studentRegister", conn);
                        studentReg.CommandType = CommandType.StoredProcedure;

                        if (password == passwordC)
                        {
                            studentReg.Parameters.Add(new SqlParameter("@first_name", first_name));
                            studentReg.Parameters.Add(new SqlParameter("@last_name", last_name));
                            studentReg.Parameters.Add(new SqlParameter("@password", password));
                            studentReg.Parameters.Add(new SqlParameter("@email", email1));
                            studentReg.Parameters.Add(new SqlParameter("@gender", gender));
                            studentReg.Parameters.Add(new SqlParameter("@address", address1));
                                SqlParameter id = studentReg.Parameters.Add("@id1", SqlDbType.Int);
                                id.Direction = ParameterDirection.Output;

                                try
                                {
                                    conn.Open();
                                    studentReg.ExecuteNonQuery();
                                    Session["id1"] = id.Value.ToString();
                                    Response.Redirect("Login2.aspx");
                                   

                                }
                                catch(SqlException ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            
                            conn.Close();
                            
                        }
                        else
                        {
                            Label1.Text = "Passwords don't Match!!!!";
                        }

                    }
                    else if (instructor.Checked)
                    {

                        SqlCommand instructorReg = new SqlCommand("InstructorRegister", conn);
                        instructorReg.CommandType = CommandType.StoredProcedure;

                        if (password == passwordC)
                        {
                            instructorReg.Parameters.Add(new SqlParameter("@first_name", first_name));
                            instructorReg.Parameters.Add(new SqlParameter("@last_name", last_name));
                            instructorReg.Parameters.Add(new SqlParameter("@password", password));
                            instructorReg.Parameters.Add(new SqlParameter("@email", email1));
                            instructorReg.Parameters.Add(new SqlParameter("@gender", gender));
                            instructorReg.Parameters.Add(new SqlParameter("@address", address1));
                                SqlParameter id = instructorReg.Parameters.Add("@id1", SqlDbType.Int);
                                id.Direction = ParameterDirection.Output;

                                try
                                {
                                    conn.Open();
                                    instructorReg.ExecuteNonQuery();
                                    Session["id1"] = id.Value.ToString();
                                    Response.Redirect("Login2.aspx");

                                }catch(SqlException ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            
                            conn.Close();

                            
                        }
                        else
                        {
                            Label1.Text = "Passwords don't Match!!!!";
                        }

                    }
                    
                    }
                    else
                    {
                        Label1.Text = "Please Choose Instructor or Student !!!";
                    }
                }
                else
                {
                    Label1.Text = "Please Choose Gender !!";
                }
            }
        }

        protected void instructor_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void student_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}