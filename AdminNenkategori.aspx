<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminNenkategori.aspx.cs" Inherits="AdminNenkategori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
  <span class="AdminTitle">
    ecommerce Admin
    <br />
    Nenkategorite ne 
    <asp:HyperLink ID="deptLink" runat="server" />
  </span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" Runat="Server">
  <p>
    <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
  </p>
  <asp:GridView ID="grid" runat="server" DataKeyNames="Nenkategori_ID" 
    AutoGenerateColumns="False" Width="100%" 
    onrowcancelingedit="grid_RowCancelingEdit" onrowdeleting="grid_RowDeleting" 
    onrowediting="grid_RowEditing" onrowupdating="grid_RowUpdating">
    <Columns>
      <asp:BoundField DataField="Nenkategori_Emer" HeaderText="Category Name" SortExpression="Nenkategori_Emer" />
      <asp:TemplateField HeaderText="Category Description" SortExpression="Description">
        <ItemTemplate>
          <asp:Label ID="Label1" runat="server" Text='<%# Bind("Nenkategori_Pershkrim") %>'>
          </asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
          <asp:TextBox ID="descriptionTextBox" runat="server" TextMode="MultiLine" Text='<%# Bind("Nenkategori_Pershkrim") %>' Height="70px" Width="400px" />
        </EditItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField>
        <ItemTemplate>
          <asp:HyperLink runat="server" ID="link" NavigateUrl='<%# "AdminProducts.aspx?Kategori_ID=" + Request.QueryString["Kategori_ID"] + "&amp;Nenkategori_ID=" + Eval("Nenkategori_ID")%>' Text="Shiko produktet">
          </asp:HyperLink>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:CommandField ShowEditButton="True" />
      <asp:ButtonField CommandName="Delete" Text="Delete" />
    </Columns>
  </asp:GridView>
  <p>Krijo nenkategori:</p>
  <p>Emri:</p>
  <asp:TextBox ID="newName" runat="server" Width="400px" />
  <p>Pershkrimi:</p>
  <asp:TextBox ID="newDescription" runat="server" Width="400px" Height="70px" TextMode="MultiLine" />
  <p><asp:Button ID="createCategory" Text="Krijo Nenkategori" runat="server" 
      onclick="createNenkategori_Click" /></p>
</asp:Content>
