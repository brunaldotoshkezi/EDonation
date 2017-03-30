<%@ Page Title="" Language="C#" MasterPageFile="~/ecommerce.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<%@ Register src="UserControls/ProduktList.ascx" tagname="ProduktList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
   <asp:Label ID="titleLabel" runat="server" Text="titleLabel" 
        CssClass="CatalogTitle"></asp:Label>
    <br />
    <asp:Label ID="descriptionLabel" runat="server" Text="descriptionLabel" 
        CssClass="CatalogDescription"></asp:Label>
    <br />
    <uc1:ProduktList ID="ProduktList1" runat="server" />
    <br />
</asp:Content>

