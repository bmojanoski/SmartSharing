using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace SmartSharing
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] != null)
            {
                Label1.Visible = false;
                Label1.Text = Session["New"].ToString();
                
              
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegiConnectionString"].ConnectionString);
                conn.Open();
                string getIme = "select Ime from Korisnik where Korisnickoime='" + Session["New"].ToString() + "'";
                SqlCommand im = new SqlCommand(getIme, conn);
                string ime = im.ExecuteScalar().ToString();
                conn.Close();
                Label11.Text = "Добредојде " + ime + ",";
                tekst.Visible = false;
            }
            else
            {
                Response.Redirect("home.aspx");
            }
        }

        protected void Button_logout(object sender, EventArgs e)
        {
            Session["New"] = null;
            Response.Redirect("home.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegiConnectionString"].ConnectionString);
                conn.Open();

                string checkPass = "select ID_donator from Donator, Korisnik where ID_donator=ID_korisnik and Korisnickoime='" + Session["New"].ToString() + "'";
                SqlCommand passcmd = new SqlCommand(checkPass, conn);
                int password = Convert.ToInt32(passcmd.ExecuteScalar().ToString());

                string getAdmin = "select TOP 1 * from Admin";
                SqlCommand cmdadmin = new SqlCommand(getAdmin, conn);
                int admin = Convert.ToInt32(cmdadmin.ExecuteScalar().ToString());

                string insertQuery = "insert into Donacija(Tipnadonacija,Dimenzii,Sostojba,Datum_objavuva,ID_korisnik_donator,ID_admin,ID_status)values (@tipna,@dimenzii,@sostojba,@objavena,@ID_korisnik_donator,@ID_admin,@ID_status)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "")
                {
                    cmd.Parameters.AddWithValue("@tipna", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@dimenzii", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@sostojba", TextBox3.Text);
                    DateTime today = DateTime.Now;
                    string format = "yyyy-MM-dd HH:mm:ss";

                    cmd.Parameters.AddWithValue("@objavena", today.ToString(format));
                    cmd.Parameters.AddWithValue("@ID_korisnik_donator", password);
                    cmd.Parameters.AddWithValue("@ID_admin", admin);
                    string st = "3";
                    cmd.Parameters.AddWithValue("@ID_status", st);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    //Response.Redirect("home.aspx");
                    tekst.Visible = true;
                    tekst.Text = "*Успешно ја поднесовте донацијата!";

                }
                else
                {
                    tekst.Visible = true;
                    tekst.Text = "*Неуспешно ја поднесовте донацијата! Пробајте повторно!";
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["New"] = Label1.Text;
            Response.Redirect("donacii.aspx");
        }
    }
}