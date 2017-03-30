<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminKategori.aspx.cs" Inherits="AdminKategori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder"
Runat="Server">
<span class="AdminTitle">ecommerce admin<br /> Kategorite </span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="Server">
  <p>
    <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
  </p>
  <asp:GridView ID="grid" runat="server" DataKeyNames="Kategori_ID" Width="100%" 
    AutoGenerateColumns="False" onrowcancelingedit="grid_RowCancelingEdit" 
    onrowdeleting="grid_RowDeleting" onrowediting="grid_RowEditing" 
    onrowupdating="grid_RowUpdating">
    <Columns>
      <asp:BoundField DataField="Kategori_Emer" HeaderText="Kategori Emer" 
        SortExpression="Kategori_Emer" />
      <asp:TemplateField HeaderText="Kategori Pershkrim" 
        SortExpression="Kategori_Pershkrim">
        <EditItemTemplate>
          <asp:TextBox ID="pershkrimTextBox" runat="server" 
            Text='<%# Bind("Kategori_Pershkrim") %>' Height="70px" TextMode="MultiLine" 
            Width="400px"></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
          <asp:Label ID="Label1" runat="server" Text='<%# Bind("Kategori_Pershkrim") %>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:HyperLinkField DataNavigateUrlFields="Kategori_ID" 
        DataNavigateUrlFormatString="AdminNenkategori.aspx?Kategori_ID={0}" 
        HeaderText="Shiko Nenkategorite" Text="Shiko Nenkategorite" />
      <asp:CommandField ShowEditButton="True" />
      <asp:ButtonField CommandName="Delete" Text="Delete" />
    </Columns>
  </asp:GridView>
  <p>Krijo kategori te re:</p>
  <p>Emri:</p>
  <asp:TextBox ID="newName" runat="server" Width="400px" />
  <p>Pershkrimi:</p>
  <asp:TextBox ID="newDescription" runat="server" Width="400px" Height="70px" TextMode="MultiLine" />
  <p><asp:Button ID="krijoKategori" Text="krijo kategori" runat="server" 
      onclick="createKategori_Click" /></p>
</asp:Content>
