using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SmartSharing
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] != null)
            {

                Label1.Visible = false;
                tekst.Visible = false;
                Label1.Text = Session["New"].ToString();
            }
            else
            {
                Response.Redirect("home.aspx");
            }
        }

        protected void Button_sledno(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex < 0)
            {
                tekst.Visible = true;
                tekst.Text = "Мора да одберете донација за да продолжите!";

            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegiConnectionString"].ConnectionString);
                con.Open();

                string checkID_potencijalen = "select ID_korisnik from Korisnik where Korisnickoime='" + Session["New"].ToString() + "'";
                SqlCommand pot = new SqlCommand(checkID_potencijalen, con);
                string potencijalenID = pot.ExecuteScalar().ToString();

                string getID_donacija = "select ID_donacija from Donacija where Tipnadonacija='" + GridView1.SelectedRow.Cells[1].Text + "'";
                SqlCommand don = new SqlCommand(getID_donacija, con);
                string donacija = don.ExecuteScalar().ToString();

                Response.Redirect("baratel2.aspx?Name=" + potencijalenID + "&Sostojba=" + donacija);
            }
        }

        protected void Button_logout(object sender, EventArgs e)
        {//logout is clicked
            Session["New"] = null;
            Response.Redirect("home.aspx");
        }

    }
}