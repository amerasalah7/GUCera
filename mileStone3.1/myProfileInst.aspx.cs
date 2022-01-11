using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera1
{
    public partial class myProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand viewProfile = new SqlCommand("ViewInstructorProfile", conn);
            viewProfile.CommandType = CommandType.StoredProcedure;

            string id = Session["instructor"].ToString();
            viewProfile.Parameters.Add(new SqlParameter("@instrId", Int16.Parse(id)));

            conn.Open();
            SqlDataReader rdr = viewProfile.ExecuteReader(CommandBehavior.CloseConnection);

            int c = 0;
            while (rdr.Read())
            {   if (c == 0)
                {
                    String first = rdr.GetString(rdr.GetOrdinal("firstName"));
                    String last = rdr.GetString(rdr.GetOrdinal("lastName"));
                    byte[] gen = (byte[])(rdr.GetSqlBinary(rdr.GetOrdinal("gender")));
                    String mail = rdr.GetString(rdr.GetOrdinal("email"));
                    String address1 = rdr.GetString(rdr.GetOrdinal("address"));
                    decimal rate = rdr.GetDecimal(rdr.GetOrdinal("rating"));
                    string mobile1;

                    if (rdr.IsDBNull(rdr.GetOrdinal("mobileNumber")) )
                    {
                        mobile1 = "No Mobile Number Added Yet !!!!";
                    }
                    else
                    {

                        mobile1 = rdr.GetString(rdr.GetOrdinal("mobileNumber"));
                    }
                    
                    firstName.Text = first;
                    lastName.Text = last;
                    if(gen[0].ToString() == "0")
                     gender.Text = "male";
                    else
                        gender.Text = "female";
                    email.Text = mail;
                    address.Text = address1;
                    rating.Text = rate.ToString();
                    mobile.Text += mobile1 + "<br>";
                    c++;
                }
                else
                {
                    string mobile1 = rdr.GetString(rdr.GetOrdinal("mobileNumber"));
                    mobile.Text += mobile1 + "<br>";
                    c++ ;

                }
            }

        }
    }
}