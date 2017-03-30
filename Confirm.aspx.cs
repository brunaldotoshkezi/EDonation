using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;

public partial class Confirm : System.Web.UI.Page
{
    private string _userName;
    private string _accountKey;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            RolesList.DataSource = Roles.GetAllRoles();
            RolesList.DataBind();
        }
        _userName = Request.QueryString.Get("UserName");
        _accountKey = Request.QueryString.Get("ConfirmationKey");
    }
    protected void SaveChanges_Click(object sender, EventArgs e)
    {
        var profile = ProfileCommon.Create(_userName) as ProfileCommon;
        if (_accountKey == profile.AccountConfirmationKey)
        {
            var user = Membership.GetUser(_userName);
            user.IsApproved = true;
            Membership.UpdateUser(user);
            foreach (ListItem role in RolesList.Items)
            {
                if (role.Selected)
                {
                    Roles.AddUserToRole(_userName, role.Value);
                }
            }
            Status.Text = "Llogaria u krijua me sukses.";
        }
        else
        {
            Status.Text = "Gabim ne konfirmimin e llogarise.";
        }
    }
}