
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductRecommendations.ascx.cs" Inherits="UserControls_ProductRecommendations" %>
<asp:DataList ID="list" runat="server" ShowHeader="false">
  <HeaderStyle CssClass=" RecommendationsHead " />
  <HeaderTemplate>
    We also recommend:
  </HeaderTemplate>  
  <ItemTemplate>
    <a class="RecommendationLabel" href='<%# Link.ToProdukt(Eval("Produkt_ID").ToString())%>'>
      <%# Eval("Emri") %>
    </a> 
    <%# Eval("Pershkrimi") %>
  </ItemTemplate>
</asp:DataList>