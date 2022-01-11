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
    public partial class CreatePromoCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreatePromo(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("AdminCreatePromocode", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if ((int)(Session["type"]) == 1)
            {
                if (string.IsNullOrEmpty(discount.Text) || string.IsNullOrEmpty(code.Text) || 
                    string.IsNullOrEmpty(issdate.Text) || string.IsNullOrEmpty(expdate.Text))
                {
                    Response.Write("can not leave a field empty");
                }

                else
                {
                    int Aid = (int)(Session["id"]);
                    String Code = code.Text;
                    DateTime issueDate = DateTime.Parse(issdate.Text);
                    DateTime expiryDate = DateTime.Parse(expdate.Text);
                    decimal Discount = decimal.Parse(discount.Text);



                    cmd.Parameters.Add(new SqlParameter("@code", Code));
                    cmd.Parameters.Add(new SqlParameter("@isuueDate", issueDate));
                    cmd.Parameters.Add(new SqlParameter("@expiryDate", expiryDate));
                    cmd.Parameters.Add(new SqlParameter("@discount", Discount));
                    cmd.Parameters.Add(new SqlParameter("@adminId", Aid));

                    bool flag = true;

                    conn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 61000)
                        {
                            Response.Write(ex.Message);
                            flag = false;
                        }
                        if (ex.Number == 60000)
                        {
                            Response.Write(ex.Message);
                            flag = false;

                        }
                    }
                    conn.Close();

                    if (flag)
                    {
                        Response.Write("promo code id added successfuly");


                    }


                }
            }
            else
            {
                Response.Write("This action can be done by Admins only");

            }
            }
        }
    }
