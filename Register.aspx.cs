using System;
using System.Web.UI.WebControls;
using System.Linq;
using System.Web.Security;
public partial class Register : System.Web.UI.Page
{
    string _accountConfirmationKey = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Reference the SpecifyRolesStep WizardStep 
            WizardStep SpecifyRolesStep = RegisterUserWithRoles.FindControl("SpecifyRolesStep") as WizardStep;

            // Reference the RoleList CheckBoxList 
            CheckBoxList RoleList = SpecifyRolesStep.FindControl("RoleList") as CheckBoxList;

            // Bind the set of roles to RoleList 
            RoleList.DataSource = Roles.GetAllRoles();
            RoleList.DataBind();

        }
    }
    protected void RegisterUserWithRoles_ActiveStepChanged(object sender, EventArgs e)
    {
        ProfileCommon userProfile = ProfileCommon.Create(RegisterUserWithRoles.UserName) as ProfileCommon;
        _accountConfirmationKey = Guid.NewGuid().ToString();
        userProfile.AccountConfirmationKey = _accountConfirmationKey;
        userProfile.Save();

        // Have we JUST reached the Complete step? 
        if (RegisterUserWithRoles.ActiveStep.Title == "Complete")
        {
            // Reference the SpecifyRolesStep WizardStep 
            WizardStep SpecifyRolesStep = RegisterUserWithRoles.FindControl("SpecifyRolesStep") as WizardStep;

            // Reference the RoleList CheckBoxList 
            CheckBoxList RoleList = SpecifyRolesStep.FindControl("RoleList") as CheckBoxList;

            // Add the checked roles to the just-added user 
            foreach (ListItem li in RoleList.Items)
            {
                if (li.Selected)
                    Roles.AddUserToRole(RegisterUserWithRoles.UserName, li.Text);
            }
        }
    }
    

    protected void CreateUserWizard1_SendingMail(object sender, MailMessageEventArgs e)
    {
        // Remove the original recipient
        e.Message.To.Clear();
        // Add the Administrator account as the new recipient
        e.Message.To.Add("bruno.agalliu@gmail.com");
        string confirmLink = string.Format("{0}://{1}/Confirm.aspx?ConfirmationKey={2}&UserName={3}",
               Request.Url.Scheme, Request.Url.Authority, _accountConfirmationKey,
               RegisterUserWithRoles.UserName);
        e.Message.Body = e.Message.Body.Replace("##ConfirmLink##", confirmLink);
    }
}