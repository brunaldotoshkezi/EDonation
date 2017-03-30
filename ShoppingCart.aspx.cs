using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShoppingCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // populate the control only on the initial page load
        if (!IsPostBack)
            PopulateControls();
    }

    private void PopulateControls()
    {
        // Display product recommendations
        recommendations.LoadCartRecommendations();
        // get the items in the shopping cart
        DataTable dt = ShoppingCartAccess.MerrNgaShporta();
        // if the shopping cart is empty...
        if (dt.Rows.Count == 0)
        {
            titleLabel1.Text = "Shporta eshte bosh!";
            grid.Visible = false;
            updateButton.Enabled = false;
            checkoutButton.Enabled = false;
            totalAmountLabel.Text = String.Format("{0:c}", 0);
        }
        else
        // if the shopping cart is not empty...
        {
            // populate the list with the shopping cart contents
            grid.DataSource = dt;
            grid.DataBind();
            // set up controls
            titleLabel1.Text = "keto produkte ndodhen ne shporten tuaj:";
            grid.Visible = true;
            updateButton.Enabled = true;
            checkoutButton.Enabled = true;
            // display the total amount
            decimal amount = ShoppingCartAccess.ShumaTotale();
            totalAmountLabel.Text = String.Format("{0:c}", amount);
        }
    }
    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Index of the row being deleted
        int rowIndex = e.RowIndex;
        // The ID of the product being deleted
        string productId = grid.DataKeys[rowIndex].Value.ToString();
        // Remove the product from the shopping cart
        bool success = ShoppingCartAccess.FshiNgaShporta(productId);
        // Display status
        statusLabel.Text = success ? "Produkti u hoq nga shporta!" :
                      "Error gjate heqjes nga shporta! ";
        // Repopulate the control
        PopulateControls();
    }
    protected void updateButton_Click(object sender, EventArgs e)
    {
        // Number of rows in the GridView
int rowsCount = grid.Rows.Count;
// Will store a row of the GridView
GridViewRow gridRow;
// Will reference a quantity TextBox in the GridView
TextBox quantityTextBox;
// Variables to store product ID and quantity
string productId;
int quantity;
// Was the update successful?
bool success = true;
// Go through the rows of the GridView
for (int i = 0; i < rowsCount; i++)
{
// Get a row
gridRow = grid.Rows[i];
// The ID of the product being deleted
productId = grid.DataKeys[i].Value.ToString();
// Get the quantity TextBox in the Row
    quantityTextBox = (TextBox)gridRow.FindControl("editQuantity");
// Get the quantity, guarding against bogus values
if (Int32.TryParse(quantityTextBox.Text, out quantity))
{
// Update product quantity
success = success && ShoppingCartAccess.ModifikoNeShporte(productId, quantity);
}
else
{
// if TryParse didn't succeed
success = false;
}
// Display status message
statusLabel.Text = success ?
"Your shopping cart was successfully updated!" :
"Some quantity updates failed! Please verify your cart!";
}
// Repopulate the control
PopulateControls();
    }
    protected void checkoutButton_Click(object sender, EventArgs e)
    {
        // Redirect to the checkout page
        Response.Redirect("Checkout.aspx");
    }
}