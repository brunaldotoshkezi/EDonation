using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminShoppingCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void deleteButton_Click(object sender, EventArgs e)
    {
        byte days = byte.Parse(daysList.SelectedItem.Value);
        ShoppingCartAccess.DeleteOldShporta(days);
        countLabel.Text = "The old shopping carts were removed from the database";
    }
    protected void countButton_Click(object sender, EventArgs e)
    {
        byte days = byte.Parse(daysList.SelectedItem.Value);
        int oldItems = ShoppingCartAccess.CountOldshporta(days);
        if (oldItems == -1)
            countLabel.Text = "S'mund te numerohen shportat e vjetra!";
        else if (oldItems == 0)
            countLabel.Text = "S'ka shporte te vjeter.";
        else
            countLabel.Text = "Ka " + oldItems.ToString() +
            " shporta te vjetra.";
    }
}