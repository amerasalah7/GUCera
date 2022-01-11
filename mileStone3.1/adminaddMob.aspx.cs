using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mileStone3._1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();


            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand cmd = new SqlCommand("AddMobile", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            String mobile = TextBox_mobile.Text;
            int id = (int)Session["id"];
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            if (mobile.Equals(""))
            {
                Response.Write("please add a mobile number ");

            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@mobile_number", mobile));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("Mobile Number Added Succsesfully");

            }

        }
    }
}