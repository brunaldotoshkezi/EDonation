<%@ Page Title="" Language="C#" MasterPageFile="~/ecommerce.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Checkout" %>

<%@ Register TagPrefix="uc1" TagName="CustomerDetailsEdit"
Src="UserControls/CustomerDetailsEdit.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:Label ID="titleLabel" runat="server"
CssClass="CatalogTitle" Text="Confirm Your Order" />
<br /><br />
<asp:GridView ID="grid" runat="server" Width="100%"
AutoGenerateColumns="False" DataKeyNames="Produkt_ID"
BorderWidth="1px" >
<Columns>
<asp:BoundField DataField="Emri" HeaderText="Product Name"
ReadOnly="True" SortExpression="Emri" />
<asp:BoundField DataField="Cmimi" DataFormatString="{0:c}"
HeaderText="Cmimi" ReadOnly="True"
SortExpression="Price" />
<asp:BoundField DataField="Sasia" HeaderText="Sasia"
ReadOnly="True" SortExpression="Sasia" />
<asp:BoundField DataField="total" ReadOnly="True"
DataFormatString="{0:c}" HeaderText="total"
SortExpression="total" />
</Columns>
</asp:GridView>
<asp:Label ID="Label2" runat="server" Text="Total amount: "
CssClass="ProductDescription" />
<asp:Label ID="totalAmountLabel" runat="server" Text="Label"
CssClass="ProductPrice" />
<br /><br />
<uc1:CustomerDetailsEdit ID="CustomerDetailsEdit1"
runat="server" Editable="false" Title="User Details" />
<br />
<asp:Label ID="InfoLabel" runat="server" />
<br /><br />

Shipping type:
  <asp:DropDownList ID="shippingSelection" runat="server" />
  <br /><br />
<asp:Button ID="placeOrderButton" runat="server"
Text="Place order" OnClick="placeOrderButton_Click" />
</asp:Content>