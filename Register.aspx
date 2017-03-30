<%@ Page Title="" Language="C#" MasterPageFile="~/ecommerce.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
    <LoggedInTemplate>
      You are already registered.
    </LoggedInTemplate>
  </asp:LoginView>
  <asp:CreateUserWizard ID="RegisterUserWithRoles" runat="server" BackColor="#F7F6F3" 
    BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" 
    CancelDestinationPageUrl="~/" ContinueDestinationPageUrl="CustomerDetails.aspx" 
    CreateUserButtonText="Sign Up" Font-Names="Verdana" Font-Size="0.8em" DisableCreatedUser="True" 
    oncreateduser="RegisterUserWithRoles_ActiveStepChanged" OnSendingMail="CreateUserWizard1_SendingMail" 
     CompleteSuccessText="Llogaria juaj u krijua me sukses. 
     Ju nuk mund te aksesoni llogarine derisa te aprovohet nga administratori. ">


 


    <SideBarStyle BackColor="#5D7B9D" BorderWidth="0px" Font-Size="0.9em" 
      VerticalAlign="Top" />
    <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
    <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
      BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
      ForeColor="#284775" />
    <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
      BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
      ForeColor="#284775" />
    <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" 
      Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
    <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
      BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
      ForeColor="#284775" />
    <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <StepStyle BorderWidth="0px" />

    <MailDefinition BodyFileName="~/App_Data/NewAccount.txt" From="bruno.agalliu@gmail.com" 
       Subject="Llogari e re u krijua">
  </MailDefinition>

    <WizardSteps>
      <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" />

        <asp:WizardStep ID="SpecifyRolesStep" runat="server" StepType="Step" 
            Title="Specify Roles" AllowReturn="False"> 

                <asp:CheckBoxList ID="RoleList" runat="server">
            </asp:CheckBoxList>

          </asp:WizardStep> 
      <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" />
    </WizardSteps>
  </asp:CreateUserWizard>
</asp:Content>
