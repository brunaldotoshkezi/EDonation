using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class UserProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet subjects = new DataSet();
            string connectionString = System.Configuration.ConfigurationManager.
           ConnectionStrings["ecommerceConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("select Emri,Pershkrimi,Cmimi,Imazhi,Adresa as Vendodhja,Data from Produkt,Vendodhja" +
"where Produkt.Vendodhja_ID=Vendodhja.Vendodhja_ID and Userid in (select Userid from aspnet_Users where UserName='" + Page.User.Identity.Name + "')", con);
                    adapter.Fill(subjects);
                    GridView1.DataSource = subjects;
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle the error
                }
            }
        }

    }
}