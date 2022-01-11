using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace milestone3
{
    public partial class CreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addCreditCard(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();


            SqlConnection conn = new SqlConnection(connStr);
            Boolean flag = true;

            SqlCommand cmd = new SqlCommand("addCreditCard", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            String Number = TextBox_Number.Text;
            String CardHolder = TextBox_CardHolder.Text;
            DateTime Expiry = Convert.ToDateTime(TextBox_ExpiryDate.Text);
            String CVV = TextBox_CVV.Text;
            int sid = (int)Session["id"];
            if (Number.Equals(""))
            {
                Label x = new Label();
                x.Text = "please enter The credit card Number  ";
                form1.Controls.Add(x);
                flag = false;
            }
            /*if (CardHolder.Equals(""))
            {
                Label x = new Label();
                x.Text = "please enter the CardHolder Name  ";
                form1.Controls.Add(x);
                flag = false;
            }*/
            //if (CVV.Equals(""))
            //{
            /*Label x = new Label();
            x.Text = "please enter an email ";
            form1.Controls.Add(x);
            flag = false;*/
            // CVV = null;
            // }

            if (flag)
            {
                cmd.Parameters.Add(new SqlParameter("@sid", sid));
                cmd.Parameters.Add(new SqlParameter("@number", Number));
                cmd.Parameters.Add(new SqlParameter("@cardHolderName", CardHolder));
                cmd.Parameters.Add(new SqlParameter("@cvv", CVV));
                cmd.Parameters.Add(new SqlParameter("@expiryDate", Expiry));
                Response.Write("Credit Card Added Succsessfully ");
            }
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        protected void ViewPromo(object sender, EventArgs e)
        {
            Response.Redirect("PromoCodes.aspx");
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
        protected void MobileNumber(object sender, EventArgs e)
        {

            Response.Redirect("AddMobileNumber.aspx");
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
    
}
}