<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Confirm.aspx.cs" Inherits="Confirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titlePlaceHolder" Runat="Server">
    <p>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="adminPlaceHolder" Runat="Server">

  <form id="form1" runat="server">
  <div>
    <asp:Label ID="Status" runat="server" Text=""></asp:Label>
    <p>Aprovo Perdoruesin (opsionale)</p>
    <asp:CheckBoxList ID="RolesList" runat="server" />
    <asp:Button ID="SaveChanges" runat="server" Text="Konfirmo Perdoruesin" 
          OnClick="SaveChanges_Click" />
  </div>
  </form>


</asp:Content>

