using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_NenkategoriList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // don't reload data during postbacks
        if (!IsPostBack)
        {
            // Obtain the ID of the selected department
            string kategoriid = Request.QueryString["Kategori_ID"];
            // Continue only if DepartmentID exists in the query string
            if (kategoriid != null)
            {
                // Catalog.GetCategoriesInDepartment returns a DataTable
                // object containing category data, which is displayed by the DataList
                list.DataSource = CatalogAccess.MerrNenkategoriteNeKategorite(kategoriid);
                // Needed to bind the data bound controls to the data source
                list.DataBind();
                ddlSubject.DataSource = list.DataSource;
                ddlSubject.DataTextField = "Nenkategori_Emer";
                ddlSubject.DataValueField = "Nenkategori_ID";
                ddlSubject.DataBind();


                ddlSubject.SelectedIndex =
                    ddlSubject.Items.IndexOf(ddlSubject.Items.FindByValue(""));


                
            }
        }
    }
}