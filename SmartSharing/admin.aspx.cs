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
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tekst.Visible = false;
                //GridView1 = Donacii
                GridView1.DataSource = SqlDataSource1;
                GridView1.DataBind();

            }
            //Making connection with database
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegiConnectionString"].ConnectionString);
            con.Open();

            //GridView3 = Podneseni baranja za donacija
            string query = "select d.Tipnadonacija as Тип_на_донација,  ko.Korisnickoime as Донатор, kk.Korisnickoime as Барател, Brclenovisemejstvo as Бр_на_чл_на_семејство, k.Prosecniprimanja as Проесечни_примања, p.tekst as Коментар  from Podnesuvabaranje as p  inner join Kriterium as k on p.ID_kriterium = k.ID_kriterium  inner join Donacija as d on p.ID_donacija = d.ID_donacija inner join Korisnik as ko on  d.ID_korisnik_donator = ko.ID_korisnik inner join Korisnik as kk on  p.ID_potencijalenprimach = kk.ID_korisnik";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView3.DataSource = ds;
            GridView3.DataBind();
            con.Close();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //This is class about when Edit button is clicked
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
            //Color the row when Edit button is clicked
            GridView1.EditRowStyle.BackColor = System.Drawing.Color.Orange;
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //This is class about when Cancel button is clicked
            GridView1.EditIndex = -1;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        { //When Update button is clicked

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegiConnectionString"].ConnectionString);
            conn.Open();

            //reading the id_donacija from tipnadonacija and result putting in int=iddonacija for next usage of id
            Label tip = GridView1.Rows[e.RowIndex].FindControl("Label15") as Label;
            string query = "select ID_donacija from Donacija where Tipnadonacija='" + tip.Text + "'";
            SqlCommand idcmd = new SqlCommand(query, conn);
            int iddonacija = Convert.ToInt32(idcmd.ExecuteScalar().ToString());

            //Taking Status.text from textbox
            TextBox status_text = GridView1.Rows[e.RowIndex].FindControl("TextBox4") as TextBox;

            //Viewing what is in the textbox and by it finding the ID_status 
            int status = 0;
            if (status_text.Text == "Dozvolena") status = 1;
            else if (status_text.Text == "Odbiena") status = 2;
            else if (status_text.Text == "Neodredeno") status = 0;
            else
            {
                tekst.Visible = true;
                tekst.Text = "Gresen vnes";
                status = 0;
            }



            //Taking username_donator from textbox
            TextBox username_admin = GridView1.Rows[e.RowIndex].FindControl("TextBox7") as TextBox;

            //finding id_korisnik from username_primac
            string checkusernameadmin = "select ID_admin from Admin where Account='" + username_admin.Text + "'";
            SqlCommand admincmd = new SqlCommand(checkusernameadmin, conn);
            int adminid = Convert.ToInt32(admincmd.ExecuteScalar().ToString());

            //finding today date
            DateTime today = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";


            //Taking username_primac from textbox
            TextBox username_primac = GridView1.Rows[e.RowIndex].FindControl("TextBox5") as TextBox;
            //finding id_korisnik from username_primac
            if (username_primac.Text == "")
            {
                //query for updating the data in GridView1

                String updatedata = "Update Donacija set ID_status='" + status + "', ID_admin='" + adminid + "', Datum_dodelena='" + today.ToString(format) + "' where ID_donacija =" + iddonacija;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = updatedata;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            else
            {
                string checkusername = "select ID_korisnik from Korisnik where Korisnickoime='" + username_primac.Text + "'";
                SqlCommand primaccmd = new SqlCommand(checkusername, conn);
                int primacid = Convert.ToInt32(primaccmd.ExecuteScalar().ToString());
                //query for updating the data in GridView1

                String updatedata = "Update Donacija set ID_status='" + status + "',ID_korisnik_primac='" + primacid + "', ID_admin='" + adminid + "', Datum_dodelena='" + today.ToString(format) + "' where ID_donacija =" + iddonacija;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = updatedata;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }

            //Executing the query and updating the data

            tekst.Visible = true;
            tekst.Text = "Успешно апдејтирано!";
            GridView1.EditIndex = -1;
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegiConnectionString"].ConnectionString);
            con.Open();
            //reading the id_donacija from tipnadonacija and result putting in int iddonacija for next usage of iddonacija
            Label tip = GridView1.Rows[e.RowIndex].FindControl("Label2") as Label;
            string query = "select ID_donacija from Donacija where Tipnadonacija='" + tip.Text + "'";
            SqlCommand idcmd = new SqlCommand(query, con);
            int iddonacija = Convert.ToInt32(idcmd.ExecuteScalar().ToString());


            //when clicked Delete button these queries are going to be executed
            String upadetedata_podnesuvabaranje = "delete from Podnesuvabaranje where ID_donacija='" + iddonacija + "'";
            String updatedata_donacija = "delete from Donacija where ID_donacija='" + iddonacija + "'";


            //executing first query
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = upadetedata_podnesuvabaranje;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            //executing secound query
            cmd.CommandText = updatedata_donacija;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            //writing that operation is succed
            tekst.Visible = true;
            tekst.Text = "Успешно бришење!";
            //refreshing GridView1 with new data
            GridView1.EditIndex = -1;
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {//displaying documents from database to datagridview


            //Making connection with database
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegiConnectionString"].ConnectionString);
            con.Open();

            SqlCommand query = new SqlCommand("select  k.name,k.type, p.ID_donacija, d.Tipnadonacija, ko.Korisnickoime, k.Brclenovisemejstvo, k.Prosecniprimanja, p.tekst  from Podnesuvabaranje as p inner join Kriterium as k on p.ID_kriterium = k.ID_kriterium inner join Donacija as d on p.ID_donacija = d.ID_donacija inner join Korisnik as ko on p.ID_potencijalenprimach = ko.ID_korisnik", con);
            query.Parameters.AddWithValue("ID_donacija", GridView3.SelectedRow.Cells[1].Text);

            SqlDataReader dr = query.ExecuteReader();

            if (dr.Read())
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = dr["type"].ToString();
                Response.AddHeader("content-disposition", "attachment;filename=" + dr["Name"].ToString());
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite((byte[])dr["Dokzaprihodi"]);
                Response.End();
            }
        }

        protected void bbaranje_Click(object sender, EventArgs e)
        {//searching from donations

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegiConnectionString"].ConnectionString);
            con.Open();

            if (baranje1.Text == "" || baranje2.Text == "")
            {
                tekst.Visible = true;
                tekst.Text = "Не внесовте доволно податоци!";
            }
            else
            {
                string checkTip = "select count(*) from Donacija where Tipnadonacija='" + baranje1.Text + "'";
                string checkUser = "select count(*) from Korisnik where Korisnickoime='" + baranje2.Text + "'";

                SqlCommand com = new SqlCommand(checkTip, con);
                int tip = Convert.ToInt32(com.ExecuteScalar().ToString());

                SqlCommand cmd = new SqlCommand(checkUser, con);
                int user = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                con.Close();


                if (tip == 1 && user == 1)
                {
                    string query1 = "select d.Tipnadonacija as Тип_на_донација,  ko.Korisnickoime as Донатор, kk.Korisnickoime as Барател, Brclenovisemejstvo as Бр_на_чл_на_семејство, k.Prosecniprimanja as Проесечни_примања, p.tekst as Коментар  from Podnesuvabaranje as p  inner join Kriterium as k on p.ID_kriterium = k.ID_kriterium  inner join Donacija as d on p.ID_donacija = d.ID_donacija and d.Tipnadonacija = '" + baranje1.Text + "'  inner join Korisnik as ko on  d.ID_korisnik_donator = ko.ID_korisnik  and ko.Korisnickoime ='" + baranje2.Text + "' inner join Korisnik as kk on  p.ID_potencijalenprimach = kk.ID_korisnik";
                    SqlDataAdapter da = new SqlDataAdapter(query1, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView3.DataSource = ds;
                    GridView3.DataBind();
                    con.Close();
                }
                else
                {
                    tekst.Visible = true;
                    tekst.Text = "Не постои таа донација";
                }
            }

        }

        protected void Button_logout(object sender, EventArgs e)
        {//logut is clicked
            Session["New"] = null;
            Response.Redirect("home.aspx");
        }
    }
}