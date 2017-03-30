<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DhuroProduktet.aspx.cs" Inherits="DhuroProduktet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titlePlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="adminPlaceHolder" Runat="Server">
  <p><b>Krijo nje produkt te ri per kete kategori:</b></p>
    <p>
    <span class="WideLabel">Useri</span>
    <asp:TextBox ID="newPronar" runat="server" Width="400px" ReadOnly="True" />
  </p>
  <p><span class="WideLabel">Kategoria</span>
      <asp:DropDownList ID="kategoria" runat="server" AutoPostBack="True"
          onselectedindexchanged="kategoria_SelectedIndexChanged" Width="189px">
      </asp:DropDownList>
  </p>
    <p><span class="WideLabel">Nenkategoria</span>
        <asp:DropDownList ID="nenkategoria" runat="server" Width="153px">
        </asp:DropDownList>
  </p>
  <p>
    <span class="WideLabel">Emri Produktit:</span>
    <asp:TextBox ID="newName" runat="server" Width="400px" />
  </p>
  <p>
    <span class="WideLabel">Pershkrimi:</span>
    <asp:TextBox ID="newDescription" runat="server" Width="400px"
                 Height="70px" TextMode="MultiLine" />
  </p>          
  <p>
    <span class="WideLabel">Cmimi:</span>
    <asp:TextBox ID="newPrice" runat="server" Width="400px">0.00</asp:TextBox>
  </p>  
  <p>
    <span class="WideLabel">Imazhi file:</span>
    <asp:TextBox ID="newImage" runat="server" Width="97px" Visible="False"></asp:TextBox>
    <asp:FileUpload ID="image1FileUpload" runat="server" />
<asp:Button ID="upload1Button" runat="server" Text="Upload" 
        onclick="upload1Button_Click" /><br />
<asp:Image ID="image1" runat="server" />
  </p> 
  <p>
    <span class="WideLabel">Sasia:</span>
    <asp:TextBox ID="sasia" runat="server" Width="400px">1</asp:TextBox>
  </p> 
        <p>
    <span class="WideLabel">vendodhja:</span>
            <asp:DropDownList ID="vendodhjaid" runat="server" Height="16px" Width="166px">
            </asp:DropDownList>
  </p>
  Data dorëzimit ne vendodhjen e mesiperme :<asp:TextBox ID="dfText" runat="server" Width="77px" 
			></asp:TextBox>
		<asp:ImageButton ID="imgButtonOne" runat="server" CausesValidation="false" Height="19px" Width="15px" ImageUrl="Images/cal.gif" OnClick="imgButtonOne_Click" />
		<br />
		<asp:Label ID="dfLabel" runat="server"></asp:Label>
		<asp:Calendar ID="CalOne" runat="server" Visible="False" 
			onselectionchanged="CalOne_SelectionChanged"></asp:Calendar>
		<br />
  <asp:Button ID="createProduct" runat="server" Text="Krijo Produkt" 
    onclick="createProduct_Click" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
</asp:Content>

