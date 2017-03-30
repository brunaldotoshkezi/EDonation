using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ProduktList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PopulateControls();
    }

    private void PopulateControls()
    {
            // Retrieve DepartmentID from the query string
            string kategoriId = Request.QueryString["Kategori_ID"];
            // Retrieve CategoryID from the query string
            string nenkategoriId = Request.QueryString["Nenkategori_ID"];
            // Retrieve Page from the query string
            string page = Request.QueryString["Page"];
            if (page == null) page = "1";
            // Retrieve Search string from query string
            string searchString = Request.QueryString["Search"];
            // How many pages of products?
            int howManyPages = 1;
            // pager links format
            string firstPageUrl = "";
            string pagerFormat = "";

        // If performing a product search
            if (searchString != null)
            {
            // Retrieve AllWords from query string
            string allWords = Request.QueryString["AllWords"];
            // Perform search
            list.DataSource = CatalogAccess.Search(searchString, allWords,page, out howManyPages);
            list.DataBind();
            // Display pager
            firstPageUrl = Link.ToSearch(searchString, allWords.ToUpper() == "TRUE", "1");
            pagerFormat = Link.ToSearch(searchString, allWords.ToUpper() == "TRUE", "{0}");
            }

            // If browsing a category...
            else if (nenkategoriId != null)
            {
            // Retrieve list of products in a category
            list.DataSource =
            CatalogAccess.MerrProduktetNeNenkategori(nenkategoriId, page, out howManyPages);
            list.DataBind();
            // get first page url and pager format
            firstPageUrl = Link.ToNenkategori(kategoriId, nenkategoriId, "1");
            pagerFormat = Link.ToNenkategori(kategoriId, nenkategoriId, "{0}");
            }
            else if (kategoriId != null)
            {
            // Retrieve list of products on department promotion
            list.DataSource = CatalogAccess.MerrProduktetNeKatPromo
            (kategoriId, page, out howManyPages);
            list.DataBind();
            // get first page url and pager format
            firstPageUrl = Link.ToKategori(kategoriId, "1");
            pagerFormat = Link.ToKategori(kategoriId, "{0}");
            }
            else
            {
            // Retrieve list of products on catalog promotion
            list.DataSource =
            CatalogAccess.MerrProduktetNeFrontPromo(page, out howManyPages);
            list.DataBind();
            // have the current page as integer
            int currentPage = Int32.Parse(page);
            }
            // Display pager controls
            topPager.Show(int.Parse(page), howManyPages, firstPageUrl, pagerFormat,false);
            bottomPager.Show(int.Parse(page), howManyPages, firstPageUrl,pagerFormat,
            true);
        }
    }
