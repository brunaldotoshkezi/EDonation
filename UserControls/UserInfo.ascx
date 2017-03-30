<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfo.ascx.cs" Inherits="UserControls_UserInfo" %>

<table cellspacing="0" border="0" width="200px" >

<asp:LoginView ID="LoginView1" runat="server">
<AnonymousTemplate>
<!--<tr>
<td class="UserInfoHead">Welcome!</td>
</tr>-->
<tr>
<td class="UserInfoContent">
You are not logged in.
<br />
<asp:LoginStatus ID="LoginStatus1" runat="server" />
or
<asp:HyperLink runat="server" ID="registerLink"
NavigateUrl="~/Register.aspx" Text="Register"
ToolTip="Go to the registration page"/>
</td>
</tr>
</AnonymousTemplate>
<RoleGroups>
<asp:RoleGroup Roles="Administrators">
<ContentTemplate>
<tr>
<td class="UserInfoHead">
<asp:LoginName ID="LoginName2" runat="server" FormatString="Pershendetje, <b>{0}</b>!" />
</td>
</tr>
<tr>
<td class="UserInfoContent">
<asp:LoginStatus ID="LoginStatus2" runat="server" />
<br />
<a href="/default.aspx">Home</a>
<br />
<a href="/AdminKategori.aspx">Catalog Admin</a>
<br />
<a href="/AdminShoppingCart.aspx">Shporta Admin</a>
<br />   
<a href="/AdminOrders.aspx">Orders Admin</a>
</td>
</tr>
</ContentTemplate>
</asp:RoleGroup>

<asp:RoleGroup Roles="klient">
<ContentTemplate>
<tr>
<td class="UserInfoHead">
<asp:LoginName ID="LoginName2" runat="server"
FormatString="Pershendetje, <b>{0}</b>!" />
</td>
</tr>
<tr>
<td class="UserInfoContent">
<asp:LoginStatus ID="LoginStatus1" runat="server" />
<br />
<asp:HyperLink runat="server" ID="detailsLink"
NavigateUrl="~/CustomerDetails.aspx"
Text="Edit Details"
ToolTip="Edit your personal details" />
<br />
<br />

<asp:HyperLink runat="server" ID="HyperLink1"
NavigateUrl="~/DhuroProduktet.aspx"
Text="Dhuro Produkt"
ToolTip="Dhuro Produkt" />
<br />
<br />

<asp:HyperLink runat="server" ID="HyperLink2"
NavigateUrl="~/UserProducts.aspx"
Text=" Produktet e dhuruara"
ToolTip="Produktet e dhuruara" />
</td>
</ContentTemplate>
</asp:RoleGroup>

</RoleGroups>
</asp:LoginView>


</table>

