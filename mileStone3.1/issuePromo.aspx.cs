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
    public partial class issuePromo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("AdminListAllStudentsWithID", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (rdr.Read())
            {
                if ((int)(Session["type"]) == 1)
                {
                    string StFName = rdr.GetString(rdr.GetOrdinal("firstName"));
                    Int32 stID = (Int32)(rdr["id"]);
                    string StLName = rdr.GetString(rdr.GetOrdinal("lastName"));





                    //Create a new label and add it to the HTML form
                    Label lbl_stID = new Label();
                    lbl_stID.Text = "Student ID: " + stID + ", ";
                    form1.Controls.Add(lbl_stID);


                    Label lbl_StFName = new Label();
                    lbl_StFName.Text = "  First Name: " + StFName + ", ";
                    form1.Controls.Add(lbl_StFName);

                    Label lbl_StLName = new Label();
                    lbl_StLName.Text = "  Last Name: " + StLName + " ";
                    form1.Controls.Add(lbl_StLName);

                    Label test = new Label();
                    test.Text = "" + (Int32)(rdr["id"]);
                    test.Visible = false;
                    form1.Controls.Add(test);

                    TextBox promo = new TextBox();
                    //promo.ID = "promoCode" + test;
                    form1.Controls.Add(promo);



                    

                    Button AddPromo = new Button();
                    AddPromo.Text = "Add promo code";
                    //b1.Click += new EventHandler((sender, e => Accept(sender , e , 5));
                    AddPromo.Click += delegate (object sender1, EventArgs e1) { AddPromoCodeToSt(sender1, e1, Int16.Parse(test.Text), promo.Text); };
                    form1.Controls.Add(AddPromo);




                    Label space = new Label();
                    space.Text = " " + "  <br /> <br />";
                    form1.Controls.Add(space);


                }
                else {
                    Response.Write("Only Admins can issue a promo codes");
                }
            }

        }

        public void AddPromoCodeToSt(object sender, EventArgs e, int sid, String promo)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("AdminIssuePromocodeToStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (string.IsNullOrEmpty(promo))
            {
                Response.Write("can not leave the field empty");
            }
            else
            {

                int stid = sid;
                String promoC = promo;

                cmd.Parameters.Add(new SqlParameter("@sid", stid));
                cmd.Parameters.Add(new SqlParameter("@pid", promoC));

                bool flag = true;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                if (flag)
                {
                    Response.Write("succ added");

                }
            }

        }


    }
}

       