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
    public partial class Registracija : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                poraka.Visible = false;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegiConnectionString"].ConnectionString);
                conn.Open();
                
                string checkuser = "select count(*) from Korisnik where Korisnickoime='" + TextBox6.Text + "'";
                SqlCommand cmd = new SqlCommand(checkuser, conn);
                int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());


                if (temp == 1)
                {
                    poraka.Visible = true;
                    poraka.Text = "Корисничкото име веќе постои!";
                }

                conn.Close();
                
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "" || TextBox6.Text == "" || TextBox7.Text == "" || TextBox8.Text == "" || tip.SelectedItem == null) {
                    poraka.Visible = true;
                    poraka.Text = "Пополнете ги сите полиња!";
                }
                else
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegiConnectionString"].ConnectionString);
                    conn.Open();
                    string insertQuery = "insert into Korisnik(Ime,Prezime,Grad,Ulica,Drzava,Korisnickoime,Lozinka,Tip)values (@ime,@prezime,@grad,@ulica,@drzava,@korisnickoime,@lozinka,@tip)";
                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@ime", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@prezime", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@grad", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@ulica", TextBox4.Text);
                    cmd.Parameters.AddWithValue("@drzava", TextBox5.Text);
                    cmd.Parameters.AddWithValue("@korisnickoime", TextBox6.Text);
                    cmd.Parameters.AddWithValue("@lozinka", TextBox7.Text);
                    cmd.Parameters.AddWithValue("@tip", tip.SelectedItem.Text);
                    cmd.ExecuteNonQuery();

                    string insertTel = "insert into Telefon(broj)values (@broj)";
                    SqlCommand tel = new SqlCommand(insertTel, conn);
                    tel.Parameters.AddWithValue("@broj", TextBox8.Text);
                    tel.ExecuteNonQuery();

                    if (tip.SelectedItem.Text == "Donator")
                    {
                        string getID = "select ID_korisnik from Korisnik WHERE Korisnickoime='" + TextBox6.Text + "'";
                        SqlCommand cmdid = new SqlCommand(getID, conn);
                        int id = Convert.ToInt32(cmdid.ExecuteScalar().ToString());

                        string insertID = "insert into Donator(ID_donator)values (@id)";
                        SqlCommand idd = new SqlCommand(insertID, conn);
                        idd.Parameters.AddWithValue("@id", id);
                        idd.ExecuteNonQuery();
                    }
                    else if (tip.SelectedItem.Text == "Baratel na donacija")
                    {
                        string getID = "select ID_korisnik from Korisnik WHERE Korisnickoime='" + TextBox6.Text + "'";
                        SqlCommand cmdid = new SqlCommand(getID, conn);
                        int id = Convert.ToInt32(cmdid.ExecuteScalar().ToString());

                        string insertID = "insert into Potencijalenprimach(ID_potencijalenprimach)values (@id)";
                        SqlCommand idd = new SqlCommand(insertID, conn);
                        idd.Parameters.AddWithValue("@id", id);
                        idd.ExecuteNonQuery();
                    }


                    //Response.Redirect("home.aspx");
                    poraka.Visible = true;
                    poraka.Text = "УСПЕШНО СТЕ РЕГИСТРИРАНИ! ВИ БЛАГОДАРИМЕ!";


                    /*
                    string getID = "select ID_korisnik from Korisnik where Korisnickoime='" + TextBox1.Text + "'";
                    SqlCommand getid = new SqlCommand(getID, conn);
                    string id = getid.ExecuteScalar().ToString();
                    int idd = Convert.ToInt32(id);

                    if (tip.SelectedItem.Text == "Donator")
                    {
                        string insertQueryy = "insert into Donator(ID_donator)values (@id)";
                        SqlCommand cmde = new SqlCommand(insertQueryy, conn);
                        cmde.Parameters.AddWithValue("@id", idd);
                        cmde.ExecuteNonQuery();
                        Response.Write("</br> Додаден админ ид");
                    }
                    else if (tip.SelectedItem.Text == "Baratel na donacija")
                    {
                        string insertQueryy = "insert into PotencijalenPrimach(ID_potencijalenprimach)values (@id)";
                        SqlCommand cmde = new SqlCommand(insertQueryy, conn);
                        cmde.Parameters.AddWithValue("@id", idd);
                        cmde.ExecuteNonQuery();
                        Response.Write("</br> Додаден барател ид");
                    }
                    */
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}