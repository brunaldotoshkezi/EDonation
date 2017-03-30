using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminProduktDetail : System.Web.UI.Page
{
    private string currentProductId, currentKategoriId, currentnenkategoriId;
    protected void Page_Load(object sender, EventArgs e)
    {
      // Get DepartmentID, CategoryID, and ProductID from the query string 
// and save their values
currentnenkategoriId = Request.QueryString["Nenkategori_ID"];
currentKategoriId = Request.QueryString["Kategory_ID"];
currentProductId = Request.QueryString["Produkt_ID"];
// Fill the controls with data only on the initial page load
if (!IsPostBack)
{
// Fill controls with data
PopulateControls();
}
}// Populate the controls
    private void PopulateControls()
    {
        // Retrieve product details and category details from database
        ProduktDetails productDetails = CatalogAccess.MerrProduktDetails(currentProductId);
        NenkategoriDetails categoryDetails = CatalogAccess.CatalogMerrNenkategoriDetails(currentnenkategoriId);
        // Set up labels and images
        productNameLabel.Text = productDetails.Emri;
        image1.ImageUrl = Link.ToProduktImage(productDetails.Thumb);
        image2.ImageUrl = Link.ToProduktImage(productDetails.Imazhi);
        // Link to department
        catLink.Text = categoryDetails.Name;
        catLink.NavigateUrl = "AdminNenkategori.aspx?Kategori_ID=" + currentKategoriId;
        // Clear form
        categoriesLabel.Text = "";
        categoriesListAssign.Items.Clear();
        categoriesListMove.Items.Clear();
        categoriesListRemove.Items.Clear();
        // Fill categoriesLabel and categoriesListRemove with data
        string nenkategoriId, nenkategoriemer;
        DataTable productNenkategori = CatalogAccess.MerrNenkategoriMeProduktet(currentProductId);
        for (int i = 0; i < productNenkategori.Rows.Count; i++)
        {
            // obtain category id and name
            nenkategoriId = productNenkategori.Rows[i]["Nenkategori_ID"].ToString();
            nenkategoriemer = productNenkategori.Rows[i]["Nenkategori_Emer"].ToString();
            // add a link to the category admin page
            categoriesLabel.Text +=
            (categoriesLabel.Text == "" ? "" : ", ") +
            "<a href='AdminProducts.aspx?Kategory_ID=" +
            CatalogAccess.CatalogMerrNenkategoriDetails(currentnenkategoriId).kategoriId +
            "&Nenkategori_ID=" + nenkategoriId + "'>" +
            nenkategoriemer + "</a>";
            // populate the categoriesListRemove combo box
            categoriesListRemove.Items.Add(new ListItem(nenkategoriemer, nenkategoriId));
        }
        // Delete from catalog or remove from category?
        if (productNenkategori.Rows.Count > 1)
        {
            deleteButton.Visible = false;
            removeButton.Enabled = true;
        }
        else
        {
            deleteButton.Visible = true;
            removeButton.Enabled = false;
        }
        // Fill categoriesListMove and categoriesListAssign with data
        productNenkategori = CatalogAccess.MerrNenkategoriPaProduktet(currentProductId);
        for (int i = 0; i < productNenkategori.Rows.Count; i++)
        {
            // obtain category id and name
            nenkategoriId = productNenkategori.Rows[i]["Nenkategori_ID"].ToString();
            nenkategoriemer = productNenkategori.Rows[i]["Nenkategori_Emer"].ToString();
            // populate the list boxes
            categoriesListAssign.Items.Add(new ListItem(nenkategoriemer, nenkategoriId));
            categoriesListMove.Items.Add(new ListItem(nenkategoriemer, nenkategoriId));
        }
    }
protected void  removeButton_Click(object sender, EventArgs e)
{
    // Check if a category was selected
if (categoriesListRemove.SelectedIndex != -1)
{
// Get the category ID that was selected in the DropDownList
string nenkategoriId = categoriesListRemove.SelectedItem.Value;
// Remove the product from the category 
bool success = CatalogAccess.RemoveProductFromCategory(currentProductId, nenkategoriId);
}
}
protected void deleteButton_Click(object sender, EventArgs e)
{
    // Delete the product from the catalog
    CatalogAccess.DeleteProdukt(currentProductId);
    // Need to go back to the categories page now
    Response.Redirect("AdminKategori.aspx");
}
protected void assignButton_Click(object sender, EventArgs e)
{
    // Check if a category was selected
if (categoriesListAssign.SelectedIndex != -1)
{
// Get the category ID that was selected in the DropDownList
string nenkategoriId = categoriesListAssign.SelectedItem.Value;
// Assign the product to the category
bool success = CatalogAccess.AssignProductToCategory(currentProductId, nenkategoriId);
// Display status message
statusLabel.Text = success ? "Produkt assigned successfully": "Produkt assignation failed";
// Refresh the page
PopulateControls();
}
else
statusLabel.Text = "Duhet te zgjedhesh nenkategorine";
}

protected void moveButton_Click(object sender, EventArgs e)
{
    // Check if a category was selected
if (categoriesListMove.SelectedIndex != -1)
{
// Get the category ID that was selected in the DropDownList
string newnenkategoriId = categoriesListMove.SelectedItem.Value;
// Move the product to the category
bool success = CatalogAccess.MoveProductToCategory(currentProductId, currentnenkategoriId, newnenkategoriId);
// If the operation was successful, reload the page, 
// so the new category will reflect in the query string
if (!success)
statusLabel.Text = "Couldn't move the product to the specified category";
else
Response.Redirect("AdminProductDetails.aspx" +
"?Kategori_ID=" + currentKategoriId +
"&Nenkategory_ID=" + newnenkategoriId +
"&Produkt_ID=" + currentProductId);
}
else
statusLabel.Text = "You need to select a category";
}
protected void upload1Button_Click(object sender, EventArgs e)
{
    // proceed with uploading only if the user selected a file
if (image1FileUpload.HasFile)
{
try
{
string fileName = image1FileUpload.FileName;
string location = Server.MapPath("./ProductImages/") + fileName;
// save image to server
image1FileUpload.SaveAs(location);
// update database with new product details
ProduktDetails pd = CatalogAccess.MerrProduktDetails(currentProductId);
CatalogAccess.UpdateProduct(currentProductId, pd.PronarID.ToString(), pd.ShportaID.ToString(), pd.Emri, pd.Pershkrimi, pd.Cmimi.ToString(), fileName, pd.Imazhi,
pd.GjendjaShitur, pd.GjendjaMagazine, pd.VendodhjaID.ToString(), pd.PromoNen.ToString(), pd.PromoFront.ToString());
// reload the page 
Response.Redirect("AdminProductDetails.aspx" +
"?Kategori_ID=" + currentKategoriId +
"&Nenkategory_ID=" + currentnenkategoriId +
"&Produkt_ID=" + currentProductId);
}
catch
{
statusLabel.Text = "Uploading image 1 failed";
}
}
}
protected void upload2Button_Click(object sender, EventArgs e)
{
    // proceed with uploading only if the user selected a file
    if (image2FileUpload.HasFile)
    {
        try
        {
            string fileName = image2FileUpload.FileName;
            string location = Server.MapPath("./ProductImages/") + fileName;
            // save image to server
            image2FileUpload.SaveAs(location);
            // update database with new product details
            ProduktDetails pd = CatalogAccess.MerrProduktDetails(currentProductId);
            CatalogAccess.UpdateProduct(currentProductId, pd.PronarID.ToString(), pd.ShportaID.ToString(), pd.Emri, pd.Pershkrimi, pd.Cmimi.ToString(), fileName, pd.Imazhi,
            pd.GjendjaShitur, pd.GjendjaMagazine, pd.VendodhjaID.ToString(), pd.PromoNen.ToString(), pd.PromoFront.ToString());
            // reload the page 
            Response.Redirect("AdminProductDetails.aspx" +
            "?Kategori_ID=" + currentKategoriId +
            "&Nenkategory_ID=" + currentnenkategoriId +
            "&Produkt_ID=" + currentProductId);
        }
        catch
        {
            statusLabel.Text = "Uploading image 2 failed";
        }
    }
}
}

