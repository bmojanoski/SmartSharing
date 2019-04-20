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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tekst.Visible = false;
           // string potencijalenID = Request.QueryString["Name"];
           // string donacijaID = Request.QueryString["Sostojba"];
           // Response.Write(potencijalenID + donacijaID);
        }

        protected void Button_logout(object sender, EventArgs e)
        {
            Session["New"] = null;
            Response.Redirect("home.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string potencijalenID = Request.QueryString["Name"];
            string donacijaID = Request.QueryString["Sostojba"];

            try
            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegiConnectionString"].ConnectionString);
                conn.Open();

                tekst.Visible = true;
                
                string filePath = FileUpload1.PostedFile.FileName; // getting the file path of uploaded file  
                string filename1 = Path.GetFileName(filePath); // getting the file name of uploaded file  
                string ext = Path.GetExtension(filename1); // getting the file extension of uploaded file  
                string type = String.Empty;
                if (!FileUpload1.HasFile && (TextBox1.Text != "" || TextBox2.Text != "" || TextBox4.Text != ""))
                {
                    tekst.Text = "Ве молиме пополнете ги сите полиња!"; //if file uploader has no file selected  
                }
                else
                if (FileUpload1.HasFile)
                {
                    try
                    {
                        switch (ext) // this switch code validate the files which allow to upload only PDF file   
                        {
                            case ".pdf":
                                type = "application/pdf";
                                break;
                        }
                        if (type != String.Empty || TextBox1.Text != "" || TextBox2.Text != "" || TextBox4.Text != "")
                        {
                            
                            Stream fs = FileUpload1.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs); //reads the binary files  
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length); //counting the file length into bytes  

                            string insertQuery = "insert into Kriterium (name,type,Dokzaprihodi,Brclenovisemejstvo,Prosecniprimanja)" + " values (@name, @type, @Dokzaprihodi,@Brclenovisemejstvo,@Prosecniprimanja)"; //insert query  
                            SqlCommand cmd = new SqlCommand(insertQuery, conn);
                            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = filename1;
                            cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
                            cmd.Parameters.Add("@Dokzaprihodi", SqlDbType.Binary).Value = bytes;
                            cmd.Parameters.AddWithValue("@Brclenovisemejstvo", TextBox1.Text);
                            cmd.Parameters.AddWithValue("@Prosecniprimanja", TextBox2.Text);
                            cmd.ExecuteNonQuery();

                            string getID_donacija = "select ID_kriterium from Kriterium where Brclenovisemejstvo='" + TextBox1.Text + "'";
                            SqlCommand don = new SqlCommand(getID_donacija, conn);
                            string kriteriumID = don.ExecuteScalar().ToString();


                            string insertKom = "insert into Podnesuvabaranje(ID_potencijalenprimach,ID_donacija,ID_kriterium,tekst)values (@ID_potencijalenprimach,@ID_donacija,@ID_kriterium,@tekst)";
                            SqlCommand kom = new SqlCommand(insertKom, conn);
                            kom.Parameters.AddWithValue("@ID_potencijalenprimach", potencijalenID);
                            kom.Parameters.AddWithValue("@ID_donacija", donacijaID);
                            kom.Parameters.AddWithValue("@ID_kriterium", kriteriumID);
                            kom.Parameters.AddWithValue("@tekst", TextBox4.Text);
                            kom.ExecuteNonQuery();

                            
                            
                            tekst.Text = "Успешно го поднесовте барањето!";
                            //Response.Redirect("home.aspx");
                           
                        }
                        else
                        {
                            
                            tekst.Text = "Ве молиме пополнете ги сите полиња!"; 
                            // if file is other than speified extension   
                        }
                    }
                    catch (Exception ex)
                    {
                        tekst.Text = "Error:  " + ex.Message.ToString();
                    }
                }
                conn.Close();
            }

            catch (Exception ex)
            {
                Response.Write("error..........." + ex.ToString());
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("baratel1.aspx");
        }

    }
}