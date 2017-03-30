using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Catalog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            PopulateControls();
        }
    }
    private void PopulateControls()
    {
      
        string kategoriId = Request.QueryString["Kategori_ID"];
     
        string nenkategoriId = Request.QueryString["Nenkategori_ID"];
        
        if (nenkategoriId != null)
        {

            NenkategoriDetails cd = CatalogAccess.CatalogMerrNenkategoriDetails(nenkategoriId);
            catalogTitleLabel.Text = HttpUtility.HtmlEncode(cd.Name);
            KategoriteDetails dd =
            CatalogAccess.CatalogMerrKategoriDetails(kategoriId);
            catalogDescriptionLabel.Text =
            HttpUtility.HtmlEncode(cd.Description);
            // Set the title of the page
            this.Title = HttpUtility.HtmlEncode(ecommerceConfiguration.SiteName +
            ": " + dd.Name + ": " + cd.Name);
        }
      
        else if (kategoriId != null)
        {
           
            KategoriteDetails dd =
            CatalogAccess.CatalogMerrKategoriDetails(kategoriId);
            catalogTitleLabel.Text = HttpUtility.HtmlEncode(dd.Name);
            catalogDescriptionLabel.Text =
            HttpUtility.HtmlEncode(dd.Description);
            // Set the title of the page
            this.Title = HttpUtility.HtmlEncode(ecommerceConfiguration.SiteName +
            ": " + dd.Name);
        }
    }
}