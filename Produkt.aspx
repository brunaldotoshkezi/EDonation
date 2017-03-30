<%@ Page Title="" Language="C#" MasterPageFile="~/ecommerce.master" AutoEventWireup="true" CodeFile="Produkt.aspx.cs" Inherits="Produkt" %>

<%@ Register src="UserControls/ProductRecommendations.ascx" tagname="ProductRecommendations" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2"
ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<p>
<asp:Label CssClass="CatalogTitle" ID="titleLabel" runat="server"
Text="Label"></asp:Label>
</p>
<p>
<asp:Image ID="produktImage" runat="server" />
</p>
<p>
<asp:Label ID="descriptionLabel" runat="server" Text="Label"></asp:Label>
</p>
<p>
<b>Price:</b>
<asp:Label CssClass="ProduktPrice" ID="priceLabel" runat="server"
Text="Label"></asp:Label>
</p>
<p>
<asp:PlaceHolder ID="attrPlaceHolder" runat="server"></asp:PlaceHolder>
</p>
<p>
<asp:LinkButton ID="AddToCartButton" runat="server"
onclick="AddToCartButton_Click">Add to Shopping Cart</asp:LinkButton>
</p>
<p>
<asp:LinkButton ID="AddToPaypal" runat="server"
onclick="AddToPaypal_Click">Add to paypal</asp:LinkButton>
</p>
    <p>
        <uc1:ProductRecommendations ID="recommendations" runat="server" />
</p>
   
</asp:Content>

