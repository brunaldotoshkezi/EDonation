<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NenkategoriList.ascx.cs" Inherits="UserControls_NenkategoriList" %>
<asp:DataList ID="list" runat="server" CssClass="NenkategoriList" Width="200px">
    <HeaderStyle CssClass="NenkategoriListHead" />
    <HeaderTemplate>
        Zgjidh nenkategorine
    </HeaderTemplate>
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" Runat="server"
NavigateUrl='<%# Link.ToNenkategori(Request.QueryString["Kategori_ID"],
Eval("Nenkategori_ID").ToString()) %>'
Text='<%# HttpUtility.HtmlEncode(Eval("Nenkategori_Emer").ToString()) %>'
ToolTip='<%# HttpUtility.HtmlEncode(Eval("Nenkategori_Pershkrim").ToString()) %>'
CssClass='<%# Eval("Nenkategori_ID").ToString() ==
Request.QueryString["Nenkategori_ID"] ?
"nenkategorizgjedhur" : "nenkategoripazgjedhur" %>'>>
</asp:HyperLink>


    </ItemTemplate>
</asp:DataList>

<asp:DropDownList class="DD" ID="ddlSubject" runat="server" AppendDataBoundItems="true">
    <asp:ListItem Text="<Zgjidhni kategorite>" Value="0" />

</asp:DropDownList>


