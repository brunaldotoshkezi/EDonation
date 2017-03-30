using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
public partial class DhuroProduktet : System.Web.UI.Page
{   private string useidetifikues;
private string dFillimi;
private string produktid;
    private String Useri;
    private String textimage;
    DataTable userid = new DataTable();
    DataTable lastproduct = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            Useri = Page.User.Identity.Name;
            newPronar.Text = Useri;
          
            DataTable subjects = new DataTable();
            DataTable vendodhja = new DataTable();
            string connectionString = System.Configuration.ConfigurationManager.
        ConnectionStrings["ecommerceConnection"].ConnectionString; ;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT Kategori_ID, Kategori_Emer FROM Kategori", con);
                    adapter.Fill(subjects);

                    kategoria.DataSource = subjects;
                    kategoria.DataTextField = "Kategori_Emer";
                    kategoria.DataValueField = "Kategori_ID";
                    kategoria.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle the error
                }
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT Vendodhja_ID, Adresa FROM Vendodhja", con);
                    adapter.Fill(vendodhja);

                    vendodhjaid.DataSource = vendodhja;
                    vendodhjaid.DataTextField = "Adresa";
                    vendodhjaid.DataValueField = "Vendodhja_ID";
                    vendodhjaid.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle the error
                }
               
            }

        }
    }
   
    protected void kategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        var currid = kategoria.SelectedValue;
        HttpContext.Current.Response.Write(currid);
       

            DataTable subject = new DataTable();
            string connectionString = System.Configuration.ConfigurationManager.
        ConnectionStrings["ecommerceConnection"].ConnectionString; ;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT Nenkategori_ID, Nenkategori_Emer FROM Nenkategori WHERE Kategori_ID=" + currid, con);
                    adapter.Fill(subject);

                    nenkategoria.DataSource = subject;
                    nenkategoria.DataTextField = "Nenkategori_Emer";
                    nenkategoria.DataValueField = "Nenkategori_ID";
                    nenkategoria.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle the error
                }

            
          //  nenkategoria.Visible = true;

        }
    }
    protected void upload1Button_Click(object sender, EventArgs e)
    {
        if (image1FileUpload.HasFile)
        {
            try
            {

                 textimage = image1FileUpload.FileName;
                 string location = Server.MapPath("./ProductImages/") + textimage;
         
                image1FileUpload.SaveAs(location);
                newImage.Text=textimage;
                newImage.Visible=true;
               // textimage = fileName;

            }
            catch (Exception ex) { }
        }
    }
    protected void createProduct_Click(object sender, EventArgs e)
    {
        
        string connectionString = System.Configuration.ConfigurationManager.
     ConnectionStrings["ecommerceConnection"].ConnectionString; ;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            try
            {
               
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT UserId FROM aspnet_Users Where UserName=" +"'"+ Page.User.Identity.Name+"'", con);
                adapter.Fill(userid);
               

            }
            catch (Exception ex)
            {
                // Handle the error
            }
            
            for(int i=0;i<userid.Rows.Count;i++)
                for (int j = 0; j < userid.Columns.Count; j++)
                {
                    useidetifikues = Convert.ToString(userid.Rows[i].ItemArray[j]);
                   
                    
                }
      
            try
            {
                string query1 = "insert into Produkt(Pronar_ID,Shporta_ID,Emri,Pershkrimi,Cmimi,Thumb,Imazhi,Gjendja_Shitur,Gjendja_Magazine,Vendodhja_ID,PromoFront,PromoNen,UserId,Data) values (1,1,'"
            + newName.Text + "','" + newDescription.Text + "'," + Double.Parse(newPrice.Text) + ",'" + newImage.Text + "','" + newImage.Text + "'," + sasia.Text + ",0," + vendodhjaid.SelectedValue + ",0,0,'" + useidetifikues + "','" + dfText.Text + "')";

                SqlCommand cmd1 = new SqlCommand(query1, con);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
               
               SqlDataAdapter adapter = new SqlDataAdapter("select top 1 Produkt_ID from Produkt order by Produkt_ID desc", con);
               adapter.Fill(lastproduct);
               for (int i = 0; i < userid.Rows.Count; i++)
                   for (int j = 0; j < userid.Columns.Count; j++)
                   {
                       produktid = Convert.ToString(lastproduct.Rows[i].ItemArray[j]);
                   }
               string query = "insert into ProduktNenkategori values ("+produktid+",6)";

               SqlCommand cmd = new SqlCommand(query, con);
               con.Open();
               cmd1.ExecuteNonQuery();
               con.Close();

               Label1.Visible = true;
               Label1.Text = "Shtimi u krye me sukses";

            }
            catch (Exception ex)
            { Label1.Visible=true;
            Label1.Text = "Shtimi nuk u krye me sukses";
            }

        } 
    }
    protected void imgButtonOne_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (dfText.Text.Trim() != "")
            {
                CalOne.SelectedDate = Convert.ToDateTime(dfText.Text);
                dFillimi = dfText.Text.Trim();
            }
        }
        catch (Exception)
        {
            //throw e;
        }
        CalOne.Visible = true;
    }
    protected void CalOne_SelectionChanged(object sender, EventArgs e)
    {
        dfText.Text = CalOne.SelectedDate.ToShortDateString();
        dFillimi = dfText.Text.Trim();

        CalOne.Visible = false;
        dfLabel.Visible = false;
    }
}