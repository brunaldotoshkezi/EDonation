<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminShoppingCart.aspx.cs" Inherits="AdminShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titlePlaceHolder" Runat="Server">
<span class="AdminTitle">
Ecommerce  Admin
<br />
Shporta
</span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="adminPlaceHolder" Runat="Server">
<p>
<asp:Label ID="countLabel" runat="server">Pershendetje!
</asp:Label></p>
<p>
<span>Sa Dite?</span>
<asp:DropDownList ID="daysList" runat="server">
<asp:ListItem Value="0">Gjithe Shportat</asp:ListItem>
<asp:ListItem Value="1">Nje</asp:ListItem>
<asp:ListItem Value="10" Selected="True">Dhjete</asp:ListItem>
<asp:ListItem Value="20">Njezet</asp:ListItem>
<asp:ListItem Value="30">Tridhjete</asp:ListItem>
<asp:ListItem Value="90">Nentedhjete</asp:ListItem>
</asp:DropDownList>
</p>
<p>
<asp:Button ID="countButton" runat="server" Text="Numero shportat e vjetra" 
        onclick="countButton_Click" />
<asp:Button ID="deleteButton" runat="server" Text="Fshi shportat e vjetra" 
        onclick="deleteButton_Click" />
</p>
</asp:Content>

