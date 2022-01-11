using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace milestone3
{
    public partial class PromoCodes : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();


            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand promo = new SqlCommand("viewPromocode", conn);
            promo.CommandType = CommandType.StoredProcedure;
            int id = (int)Session["id"];
            promo.Parameters.Add(new SqlParameter("@sid", id));
            
            conn.Open();
            SqlDataReader rdr = promo.ExecuteReader(CommandBehavior.CloseConnection);
            int i = 0;
            while (rdr.Read())
            {
                i = i + 1;
                Label name6 = new Label();
                name6.Text = "<br>" +i+ "-   Code:  ";
                form1.Controls.Add(name6);
                if (!(rdr.IsDBNull(0)))
                {
                    String pcode = rdr.GetString(rdr.GetOrdinal("code"));
                    Label name = new Label();
                    name.Text = pcode;
                    form1.Controls.Add(name);
                }
                if (!(rdr.IsDBNull(1)))
                {
                    DateTime issue = rdr.GetDateTime(rdr.GetOrdinal("isuueDate"));
                    Label name2 = new Label();
                    name2.Text = " ,IssueDate: " + issue;
                    form1.Controls.Add(name2);
                }
                if (!(rdr.IsDBNull(2)))
                {
                    DateTime expiry = rdr.GetDateTime(rdr.GetOrdinal("expiryDate"));
                    Label name3 = new Label();
                    name3.Text = " ExpiryDate :  " + expiry;
                    form1.Controls.Add(name3);

                }
                if (!(rdr.IsDBNull(3)))
                {
                    Decimal discount = rdr.GetDecimal(rdr.GetOrdinal("discount"));
                    Label name4 = new Label();
                    name4.Text = "     ,Discount:  " + discount + "<br >";
                    form1.Controls.Add(name4);
                   
                }
                if (!(rdr.IsDBNull(4)))
                {
                    Int32 adminId = (Int32)(rdr["adminId"]);

                    Label name4 = new Label();
                    name4.Text = "     ,Admin Id:  " + adminId ;
                    form1.Controls.Add(name4);
                
                }

            }

            conn.Close();
        }


        protected void MobileNumber(object sender, EventArgs e)

        { 
            Response.Redirect("AddMobileNumber.aspx");
        }

        protected void ViewProfile(object sender, EventArgs e)
        {
            Response.Redirect("MyProfile.aspx");
        }

        protected void AddCreditCard(object sender, EventArgs e)
        {
            Response.Redirect("CreditCard.aspx");
        }

        protected void ViewCourses(object sender, EventArgs e)
        {
            Response.Redirect("Courses.aspx");
        }
        protected void AddFeedback(object sender, EventArgs e)
        {
            Response.Redirect("AddFeedback.aspx");
        }

        protected void ListCertificates(object sender, EventArgs e)
        {
            Response.Redirect("List certificates.aspx");
        }

        protected void SubmitAssignment(object sender, EventArgs e)
        {
            Response.Redirect("SubmitAssignment.aspx");
        }

        protected void ViewAssignment(object sender, EventArgs e)
        {
            Response.Redirect("ViewAssignment.aspx");
        }

        protected void ViewGrade(object sender, EventArgs e)
        {
            Response.Redirect("ViewGrade.aspx");
        }

        protected void ViewPromo(object sender, EventArgs e)
        {
            Response.Redirect("PromoCodes.aspx");
        }
    }
}