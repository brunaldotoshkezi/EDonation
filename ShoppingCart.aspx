<%@ Page Title="" Language="C#" MasterPageFile="~/ecommerce.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" %>

<%@ Register src="UserControls/ProductRecommendations.ascx" tagname="ProductRecommendations" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>
<asp:Label ID="titleLabel1" runat="server" Text="Shporta juaj" 
        CssClass="CatalogTitle" />
</p>
<p>
<asp:Label ID="statusLabel" runat="server" />
</p> 
<asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" DataKeyNames="Produkt_ID"
    Width="100%" BorderWidth="1px" OnRowDeleting="grid_RowDeleting">
    <Columns>
        <asp:BoundField DataField="Emri" HeaderText="Emri" ReadOnly="True" 
            SortExpression="Emri" />
        <asp:BoundField DataField="Cmimi" DataFormatString="{0:c}" HeaderText="Cmimi" 
            ReadOnly="True" SortExpression="Cmimi" />
        <asp:BoundField DataField="Atribute" HeaderText="Atribute" ReadOnly="True" 
            SortExpression="Atribute" />
        <asp:TemplateField HeaderText="Sasia">
  
<ItemTemplate>
<asp:TextBox ID="editQuantity" runat="server" CssClass="GridEditingRow"
Width="24px" MaxLength="2" Text='<%#Eval("Sasia")%>' />
</ItemTemplate>
</asp:TemplateField>
        <asp:BoundField DataField="total" DataFormatString="{0:c}" HeaderText="Total" 
            ReadOnly="True" SortExpression="total" />
        <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete" 
            ShowHeader="True" Text="DeleteButton" />
    </Columns>
</asp:GridView>
<p align="right">
<span>Totali : </span>
<asp:Label ID="totalAmountLabel" runat="server" Text="Label" />
</p>
<p align="right">
    &nbsp;<asp:Button ID="updateButton" runat="server" Text="Update Quantities" 
        onclick="updateButton_Click" />
<asp:Button ID="checkoutButton" runat="server"
Text="Proceed to Checkout" onclick="checkoutButton_Click" />
</p>
    <uc1:ProductRecommendations ID="recommendations" runat="server" />
    <br />
</asp:Content>

