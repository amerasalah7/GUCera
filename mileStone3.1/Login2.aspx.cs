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
    public partial class Login2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["id1"] == null)
            {
                welcome.Text += "";
                welcome.Visible = false;
            }
            else
            {
                welcome.Text += Session["id1"].ToString();

            }
        }

        protected void loginOnClick(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand loginProc = new SqlCommand("userLogin", conn);
            loginProc.CommandType = CommandType.StoredProcedure;

            if (username.Text == "" || password.Text == "")
            {
                MessageBox.Show("Fields Required !!");
            }
            else
            {


                int id = Int16.Parse(username.Text);
                string pass = password.Text;
                loginProc.Parameters.Add(new SqlParameter("@id", id));
                loginProc.Parameters.Add(new SqlParameter("@password", pass));
                SqlParameter success = loginProc.Parameters.Add("@success", SqlDbType.Int);
                SqlParameter type = loginProc.Parameters.Add("@type", SqlDbType.Int);
                success.Direction = ParameterDirection.Output;
                type.Direction = ParameterDirection.Output;

                conn.Open();
                loginProc.ExecuteNonQuery();
                conn.Close();

                if (success.Value.ToString() == "1")
                {
                    if (type.Value.ToString() == "0")
                    {
                        Session["x"] = id;
                        Response.Redirect("instructorsLinks2.aspx");
                    }
                    else
                    if (type.Value.ToString() == "1")
                    {
                        Session["id"] = id;
                        Session["type"] = type.Value;
                        Response.Redirect("home.aspx", true);
                    }
                    else
                    {
                        Session["id"] = id;
                        Session["type"] = type;
                        Response.Redirect("Courses.aspx", true);
                    }
                }
                else
                {
                    Response.Write("User Id Not Found !!!!");
                }
            }
        }

    }
}