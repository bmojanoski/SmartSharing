using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace SmartSharing
{
    public partial class Donacii : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] != null)
            {
                Label1.Visible = false;
                Label1.Text = Session["New"].ToString();
            }
            else
            {
                Response.Redirect("home.aspx");
            }

            //showing the donations shared from the user
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegiConnectionString"].ConnectionString);
            con.Open();

            string checkPass = "select ID_donator from Donator, Korisnik where Donator.id_donator = Korisnik.id_korisnik and Korisnik.Korisnickoime='" + Session["New"].ToString() + "'";
            SqlCommand passcmd = new SqlCommand(checkPass, con);
            string id_donator = passcmd.ExecuteScalar().ToString();

            string query = "select d.tipnadonacija AS Тип, d.dimenzii as Димензии, d.sostojba as Состојба, sd.vrednost as Статус from donacija as d inner join statusnadonacija as sd on d.id_status = sd.id_status and d.ID_korisnik_donator = '" + id_donator + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView2.DataSource = ds;
            GridView2.DataBind();
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("donator.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["New"] = null;
            Response.Redirect("home.aspx");
        }
    }
}