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
    public partial class addCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonAdd_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand addCourse = new SqlCommand("InstAddCourse", conn);
            addCourse.CommandType = CommandType.StoredProcedure;

            if (courseC.Text == "" || courseP.Text == "" || courseN.Text == "")
            {
                MessageBox.Show("All the fields must be filled");
            }
            else
            {
                int credithours = Int32.Parse(courseC.Text);
                decimal price = decimal.Parse(courseP.Text);
                string name = courseN.Text;
                int id = Int32.Parse(Session["instructor"].ToString());
                addCourse.Parameters.Add(new SqlParameter("@creditHours", credithours));
                addCourse.Parameters.Add(new SqlParameter("@name", name));
                addCourse.Parameters.Add(new SqlParameter("@price", price));
                addCourse.Parameters.Add(new SqlParameter("@instructorId", id));

                try
                {
                    conn.Open();
                    addCourse.ExecuteNonQuery();
                    conn.Close();

                    courseC.Text = String.Empty;
                    courseN.Text = String.Empty;
                    courseP.Text = String.Empty;

                    Label.Text = "Added Successfully!!!";
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


        }
    }
}