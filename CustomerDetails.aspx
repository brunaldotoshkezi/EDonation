﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="CustomerDetails.aspx.cs" Inherits="CustomerDetails" %>

<%@ Register TagPrefix="uc1" TagName="CustomerDetailsEdit" Src="UserControls/CustomerDetailsEdit.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
    <h1>
<span class="CatalogTitle">Edit Your Details</span>
</h1>
<uc1:CustomerDetailsEdit ID="CustomerDetailsEdit1" runat="server" />
</asp:Content>
