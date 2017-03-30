using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminKategori : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!Page.IsPostBack)
        {
           
            BindGrid();
        }
    }

    // Populate the GridView with data
    private void BindGrid()
    {
        
        grid.DataSource = CatalogAccess.MerrKategori();
        grid.DataBind();
    }

    // enter edit mode
    protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
   
        grid.EditIndex = e.NewEditIndex;
        // Set status message 
        statusLabel.Text = "Editing row # " + e.NewEditIndex.ToString();
        // Reload the grid
        BindGrid();
    }


 
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

    // Update row
    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Retrieve updated data 
        string id = grid.DataKeys[e.RowIndex].Value.ToString();
        string name = ((TextBox)grid.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
        string description = ((TextBox)grid.Rows[e.RowIndex].FindControl("pershkrimTextBox")).Text;
        // Execute the update command
        bool success = CatalogAccess.UpdateKategori(id, name, description);
        // Cancel edit mode
        grid.EditIndex = -1;
        // Display status message
        statusLabel.Text = success ? "Update successful" : "Update failed";
        // Reload the grid
        BindGrid();
    }

    // Delete a record
    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Get the ID of the record to be deleted
        string id = grid.DataKeys[e.RowIndex].Value.ToString();
        // Execute the delete command
        bool success = CatalogAccess.DeleteKategori(id);
        // Cancel edit mode
        grid.EditIndex = -1;
        // Display status message
        statusLabel.Text = success ? "Delete successful" : "Delete failed";
        // Reload the grid
        BindGrid();
    }

    // Create a new department
    protected void createKategori_Click(object sender, EventArgs e)
    {
        // Execute the insert command
        bool success = CatalogAccess.AddKategori(newName.Text, newDescription.Text);
        // Display status message
        statusLabel.Text = success ? "Insert successful" : "Insert failed";
        // Reload the grid
        BindGrid();
    }
}