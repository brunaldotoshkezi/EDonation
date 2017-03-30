<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminProduktDetail.aspx.cs" Inherits="AdminProduktDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titlePlaceHolder" Runat="Server">
<span class="AdminTitle">
Ecommerce Admin
<br />
Kthehu ne  
<asp:HyperLink ID="catLink" runat="server" />
</span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="adminPlaceHolder" Runat="Server">
<asp:Label CssClass="AdminTitle" ID="productNameLabel" runat="server" />
<p>
<asp:Label ID="statusLabel" CssClass="AdminError" runat="server" />
</p>
<p>
Produktet permbajne  keto Nenkategori:
<asp:Label ID="categoriesLabel" runat="server" />
</p>
<p>
Hiq produktet nga kjo nenkategori :
<asp:DropDownList ID="categoriesListRemove" runat="server" />
<asp:Button ID="removeButton" runat="server" Text="Remove" OnClick="removeButton_Click" />
<asp:Button ID="deleteButton" runat="server" Text="DELETE FROM Kategoria" OnClick="deleteButton_Click" />
</p>
<p>
Assign Produktet ne nenkategori:
<asp:Button ID="assignButton" runat="server" Text="Assign" OnClick="assignButton_Click" />
<asp:DropDownList ID="categoriesListAssign" runat="server" /> 

</p>
<p>
Zhvendos produktet ne kete nenkategori category:
<asp:DropDownList ID="categoriesListMove" runat="server" />
<asp:Button ID="moveButton" runat="server" Text="Move" OnClick="moveButton_Click" />
</p>
<p>
Imazhi1 file :
<asp:Label ID="Image1Label" runat="server" />
<asp:FileUpload ID="image1FileUpload" runat="server" />
<asp:Button ID="upload1Button" runat="server" Text="Upload" 
        onclick="upload1Button_Click" /><br />
<asp:Image ID="image1" runat="server" />
</p>
<p>
Imazhi2 file :
<asp:Label ID="Image2Label" runat="server" />
<asp:FileUpload ID="image2FileUpload" runat="server" />
<asp:Button ID="upload2Button" runat="server" Text="Upload" 
        onclick="upload2Button_Click" /><br />
<asp:Image ID="image2" runat="server" />
</p>
</asp:Content>

