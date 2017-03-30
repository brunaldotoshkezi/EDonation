using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class Produkt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Retrieve ProductID from the query string
        string produktId = Request.QueryString["Produkt_ID"];
        // Retrieves product details
        ProduktDetails pd = CatalogAccess.MerrProduktDetails(produktId);
        // Does the product exist?
        if (pd.Emri != null)
        {
            PopulateControls(pd);
        }
    }
    // Fill the control with data
    private void PopulateControls(ProduktDetails pd)
    {

        // Display product recommendations
        string productId = pd.ProduktID.ToString();
        recommendations.LoadProductRecommendations(productId);
        // Display product details
        titleLabel.Text = pd.Emri;
        descriptionLabel.Text = pd.Pershkrimi;
        priceLabel.Text = String.Format("{0:c}", pd.Cmimi);
        produktImage.ImageUrl = "ProductImages/" + pd.Imazhi;
        // Set the title of the page
        this.Title = ecommerceConfiguration.SiteName + pd.Emri;
    }
    protected void AddToCartButton_Click(object sender, EventArgs e)
    {
        // Retrieve ProductID from the query string
        string productId = Request.QueryString["Produkt_ID"];
        // Retrieve the selected product options
        string options = "";
        foreach (Control cnt in attrPlaceHolder.Controls)
        {
            if (cnt is Label)
            {
                Label attrLabel = (Label)cnt;
                options += attrLabel.Text;
            }
            if (cnt is DropDownList)
            {
                DropDownList attrDropDown = (DropDownList)cnt;
                options += attrDropDown.Items[attrDropDown.SelectedIndex] + "; ";
            }
        }
        // Add the product to the shopping cart
        ShoppingCartAccess.ShtoNeShporte(productId, options);
    }
    protected void AddToPaypal_Click(object sender, EventArgs e)
    {
        // Retrieve ProductID from the query string
        string productId = Request.QueryString["Produkt_ID"];
        // Retrieves product details
        ProduktDetails pd = CatalogAccess.MerrProduktDetails(productId);

        // Retrieve the selected product options
        string options = "";
        foreach (Control cnt in attrPlaceHolder.Controls)
        {
            if (cnt is Label)
            {
                Label attrLabel = (Label)cnt;
                options += attrLabel.Text;
            }

            if (cnt is DropDownList)
            {
                DropDownList attrDropDown = (DropDownList)cnt;
                options += attrDropDown.Items[attrDropDown.SelectedIndex] + "; ";
            }
        }

        // The Add to Cart link
        string productUrl = Link.ToProdukt(pd.ProduktID.ToString());
        string destination = Link.ToPayPalAddItem(productUrl, pd.Emri, pd.Cmimi, options);
        Response.Redirect(destination);
    }


    }
