<%@ Page Title="ecommerce: Catalog" Language="C#" MasterPageFile="~/other.master" AutoEventWireup="true" CodeFile="Catalog.aspx.cs" Inherits="Catalog" %>

<%@ Register src="UserControls/ProduktList.ascx" tagname="ProduktList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>
<asp:Label ID="catalogTitleLabel" CssClass="CatalogTitle"
runat="server" />
</h1>
<h2>
<asp:Label ID="catalogDescriptionLabel" CssClass="CatalogDescription"
runat="server" />
</h2>
&nbsp;<uc1:ProduktList ID="ProduktList1" runat="server" />
</asp:Content>

