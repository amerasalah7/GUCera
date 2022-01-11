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
    public partial class addPhone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addNumber(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand addMobile = new SqlCommand("addMobile", conn);
            addMobile.CommandType = CommandType.StoredProcedure;

            if (number.Text == "") {
                MessageBox.Show("Field Required !!!");

            }
            else
            {

            
            string id = Session["instructor"].ToString();
            string mobile_number = number.Text; 
            addMobile.Parameters.Add(new SqlParameter("@ID", id));
            addMobile.Parameters.Add(new SqlParameter("@mobile_number", mobile_number));

                try
                {
                    conn.Open();
                    addMobile.ExecuteNonQuery();
                    added.Text = "Added Successfully!!";
                    number.Text = String.Empty;
                }
                catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            
            conn.Close();

           
            }

        }
    }
}