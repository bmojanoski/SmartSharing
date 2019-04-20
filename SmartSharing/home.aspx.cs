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
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            kopcinja.Visible = false;
            akaunt.Visible = false;
            pasvord.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox11.Text.EndsWith("admin.com"))
            {
                Session["New"] = TextBox11.Text;
                Response.Redirect("admin.aspx");
            }
            else
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegiConnectionString"].ConnectionString);
                conn.Open();

                string checkuser = "select count(*) from Korisnik where Korisnickoime='" + TextBox11.Text + "'";
                SqlCommand com = new SqlCommand(checkuser, conn);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                kopcinja.Visible = true;
                pasvord.Visible = true;
                akaunt.Visible = true;

                conn.Close();

                if (temp == 1)
                {
                    conn.Open();
                    string checkPass = "select Lozinka from Korisnik where Korisnickoime='" + TextBox11.Text + "'";
                    SqlCommand passcmd = new SqlCommand(checkPass, conn);
                    string password = passcmd.ExecuteScalar().ToString();

                    if (password == TextBox22.Text)
                    {
                        string checktip = "select Tip from Korisnik where Korisnickoime='" + TextBox11.Text + "'";
                        SqlCommand tip1 = new SqlCommand(checktip, conn);
                        string tipp = tip1.ExecuteScalar().ToString();
                        if (tip.SelectedIndex == -1)
                        {
                            pasvord.Visible = false;
                            akaunt.Visible = false;
                            kopcinja.Text = "*Не внесовте тип на корисник!";
                        }
                        else
                        {
                            if (tip.SelectedItem.Value == "Donator" && tipp == "Donator")
                            {
                                Session["New"] = TextBox11.Text;
                                Response.Redirect("donator.aspx");
                            }
                            else if (tip.SelectedItem.Value == "Baratel na donacija" && tipp == "Baratel na donacija")
                            {
                                Session["New"] = TextBox11.Text;
                                Response.Redirect("baratel1.aspx");
                            }
                            else if (tip.SelectedItem.Value == "Baratel na donacija" && tipp == "Donator")
                            {
                                pasvord.Visible = false;
                                akaunt.Visible = false;
                                kopcinja.Text = "*Вие не сте Барател на донација";
                                //Response.Write("<div class=\"myMessage\">Вие не сте Барател на донација!</div>");
                            }
                            else if (tip.SelectedItem.Value == "Donator" && tipp == "Baratel na donacija")
                            {
                                pasvord.Visible = false;
                                akaunt.Visible = false;
                                kopcinja.Text = "*Вие сте донатор";
                            }
                        }
                    }
                    else
                    {
                        kopcinja.Visible = false;
                        akaunt.Visible = false;
                        pasvord.Text = "*Вашиот пасворд не е точен!";
                        //  Response.Write("Вашиот пасворд не е точен!");
                    }
                }
                else
                {
                    kopcinja.Visible = false;
                    pasvord.Visible = false;
                    akaunt.Text = "*Вашето корисничко име не е точно!";
                }
            }
        }
    }
}
