<%@ Page Title="" Language="C#" MasterPageFile="~/ecommerce.master" AutoEventWireup="true" CodeFile="SecurityLibTester2.aspx.cs" Inherits="SecurityLibTester2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
Enter data to encrypt:
<br />
<asp:TextBox ID="encryptBox" runat="server" />
<br />
Enter data to decrypt:
<br />
<asp:TextBox ID="decryptBox" runat="server" />
<br />
<asp:Button ID="processButton" runat="server" Text="Process" OnClick="processButton_Click" />
<br />
<asp:Label ID="result" runat="server" />
</asp:Content>

