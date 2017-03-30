<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProduktList.ascx.cs" Inherits="UserControls_ProduktList" %>
<%@ Register src="Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<uc1:Pager ID="topPager" runat="server" Visible="False" />
<asp:DataList ID="list" runat="server" RepeatColumns="2"
CssClass="ProduktList" EnableViewState="False">
<ItemTemplate>
<h3 class="ProduktTitle">
<a href="<%# Link.ToProdukt(Eval("Produkt_ID").ToString()) %>">
<%# HttpUtility.HtmlEncode(Eval("Emri").ToString()) %>
</a>
</h3>
<a href="<%# Link.ToProdukt(Eval("Produkt_ID").ToString()) %>">
<img width="100" border="0"
src="<%# Link.ToProduktImage(Eval("Thumb").ToString()) %>"
alt='<%# HttpUtility.HtmlEncode(Eval("Emri").ToString())%>' />
</a>
<%# HttpUtility.HtmlEncode(Eval("Pershkrimi").ToString()) %>
<p>
Price:
<%# Eval("Cmimi", "{0:c}") %>
</p>
</ItemTemplate>
</asp:DataList>
<uc1:Pager ID="bottomPager" runat="server" Visible="False" />

