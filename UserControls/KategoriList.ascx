<%@ Control Language="C#" AutoEventWireup="true" CodeFile="KategoriList.ascx.cs" Inherits="UserControls_KategoriList" %>

<asp:DataList ID="list" runat="server" CssClass="KategoriList" Width="200px">
    <HeaderStyle CssClass="KategoriListHead" />
    <HeaderTemplate>
        Zgjidh kategorine
    </HeaderTemplate>
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" runat="server"
        
        NavigateUrl='<%# Link.ToKategori(Eval("Kategori_ID").ToString())%>'
Text='<%# HttpUtility.HtmlEncode(Eval("Kategori_Emer").ToString()) %>'
ToolTip='<%# HttpUtility.HtmlEncode(Eval("Kategori_Pershkrim").ToString()) %>'
CssClass='<%# Eval("Kategori_ID").ToString() ==
Request.QueryString["Kategori_ID"] ? "Kategoriazgjedhur" :
"Kategoriapazgjedhur" %>'>

</asp:HyperLink>
    </ItemTemplate>
</asp:DataList>

