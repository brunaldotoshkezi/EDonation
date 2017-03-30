<%@ Page Title="ecommerce" Language="C#" MasterPageFile="~/ecommerce.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register src="UserControls/ProduktList.ascx" tagname="ProduktList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>
<span class="CatalogTitle">Miresevini ne ecommerce!</span>
</h1>
<h2>
<span class="CatalogDescription">Produkte speciale </span>
</h2>
&nbsp;<uc1:ProduktList ID="ProduktList1" runat="server" />
</asp:Content>

