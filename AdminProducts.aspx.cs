using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
{
    string nenkategoriId = Request.QueryString["Nenkategori_ID"];
    string kategoriId = Request.QueryString["Kategori_ID"];

// Obtain the category name
NenkategoriDetails cd = CatalogAccess.CatalogMerrNenkategoriDetails(nenkategoriId);
string NenkategoriName = cd.Name;
// Link to department
catLink.Text = NenkategoriName;
catLink.NavigateUrl = "AdminNenkategori.aspx?Kategori_ID=" + kategoriId;
    }
        // Load the products grid
BindGrid();
}
// Populate the GridView with data
private void BindGrid()
{
// Get CategoryID from the query string
string nenkategoriId = Request.QueryString["Nenkategori_ID"];
// Get a DataTable object containing the products
grid.DataSource = CatalogAccess.MerrGjitheproduktetNeNenkategorite(nenkategoriId);
// Needed to bind the data bound controls to the data source
grid.DataBind();
}

// Enter row into edit mode
protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
{
// Set the row for which to enable edit mode
grid.EditIndex = e.NewEditIndex;
// Set status message 
statusLabel.Text = "Editing row # " + e.NewEditIndex.ToString();
// Reload the grid
BindGrid();
}
// Cancel edit mode
protected void grid_RowCancelingEdit(object sender,
GridViewCancelEditEventArgs e)
{
// Cancel edit mode
grid.EditIndex = -1;
// Set status message
statusLabel.Text = "Editing canceled";
// Reload the grid
BindGrid();

}
// Update a product
protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
{
// Retrieve updated data
try
{
string id = grid.DataKeys[e.RowIndex].Value.ToString();
  
    string idpronar = ((TextBox)grid.Rows[e.RowIndex].FindControl("pronarTextBox")).Text;
    string idshporta = ((TextBox)grid.Rows[e.RowIndex].FindControl("shportaTextBox")).Text;

string name = ((TextBox)grid.Rows[e.RowIndex].FindControl("nameTextBox")).Text;
string description = ((TextBox)grid.Rows[e.RowIndex].FindControl("descriptionTextBox")).Text;
string price = ((TextBox)grid.Rows[e.RowIndex].FindControl("priceTextBox")).Text;
string thumbnail = ((TextBox)grid.Rows[e.RowIndex].FindControl("thumbTextBox")).Text;
string image = ((TextBox)grid.Rows[e.RowIndex].FindControl("imageTextBox")).Text;
    string gjendjashitur = ((TextBox)grid.Rows[e.RowIndex].FindControl("shiturTextBox")).Text;
string gjendjamagazine = ((TextBox)grid.Rows[e.RowIndex].FindControl("magazineTextBox")).Text;
string vendodhja = ((TextBox)grid.Rows[e.RowIndex].FindControl("vendTextBox")).Text;
string promoNen = ((CheckBox)grid.Rows[e.RowIndex].Cells[11].Controls[0]).Checked.ToString();
string promoFront = ((CheckBox)grid.Rows[e.RowIndex].Cells[12].Controls[0]).Checked.ToString();
// Execute the update command
bool success = CatalogAccess.UpdateProduct(id,idpronar,idshporta, name, description, price, thumbnail, image,gjendjashitur,gjendjamagazine,vendodhja, promoNen, promoFront);
// Cancel edit mode
grid.EditIndex = -1;
// Display status message
statusLabel.Text = success ? "Produkt update successful" :"Product update failed";
}
catch
{
// Display error
statusLabel.Text = "Product update failed";
}
// Reload grid
BindGrid();
}
// Create a new product
protected void createProduct_Click(object sender, EventArgs e)
{
// Get CategoryID from the query string
string nenkategoriId = Request.QueryString["Nenkategori_ID"];
// Execute the insert command
bool success = CatalogAccess.CreateProduct(nenkategoriId,newPronar.Text,newShporta.Text, newName.Text, newDescription.Text, newPrice.Text, newThumbnail.Text, newImage.Text,newShitur.Text,newMagazine.Text,newVend.Text,
newPromoDept.Checked.ToString(), newPromoFront.Checked.ToString());

string userName = Page.User.Identity.Name;
// Display status message
statusLabel.Text = success ? "Insert successful" : "Insert failed";
// Reload the grid
BindGrid();
}



}