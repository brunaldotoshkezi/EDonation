<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminProducts.aspx.cs" Inherits="AdminProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
<span class="AdminTitle">
BalloonShop Admin
<br />
Products in 
<asp:HyperLink ID="catLink" runat="server" />
</span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" Runat="Server">
  <p>
    <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
  </p>
  <asp:GridView ID="grid" runat="server" DataKeyNames="Produkt_ID" 
    AutoGenerateColumns="False" Width="100%" 
    onrowcancelingedit="grid_RowCancelingEdit" onrowediting="grid_RowEditing" 
    onrowupdating="grid_RowUpdating">
    <Columns>
      <asp:ImageField DataImageUrlField="Thumb" 
        DataImageUrlFormatString="ProductImages/{0}" HeaderText="Imazhi" 
        ReadOnly="True">
      </asp:ImageField>
       <asp:TemplateField HeaderText="Pronarid" SortExpression="Pronar_ID">
        <EditItemTemplate>
          <asp:TextBox ID="pronarTextBox" runat="server" Width="97%" 
                       CssClass="GridEditingRow" Text='<%# String.Format("{0:0.00}", Eval("Pronar_ID")) %>'>
          </asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
          <asp:Label ID="Label1" runat="server" Text='<%# String.Format("{0:0.00}", Eval("Pronar_ID")) %>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
 

       <asp:TemplateField HeaderText="shportaid" SortExpression="Shporta_ID">
        <EditItemTemplate>
          <asp:TextBox ID="shportaTextBox" runat="server" Width="97%" 
                       CssClass="GridEditingRow" Text='<%# String.Format("{0:0}", Eval("Shporta_ID")) %>'>
          </asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
          <asp:Label ID="Label1" runat="server" Text='<%# String.Format("{0:0}", Eval("Shporta_ID")) %>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Emri" SortExpression="Emri">
        <EditItemTemplate>
          <asp:TextBox ID="nameTextBox" runat="server" Width="97%" 
                       CssClass="GridEditingRow" Text='<%# Bind("Emri") %>'>
          </asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
          <asp:Label ID="Label1" runat="server" Text='<%# Bind("Emri") %>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>

      

      <asp:TemplateField HeaderText="Pershkrimi" 
        SortExpression="Pershkrimi">
        <EditItemTemplate>
          <asp:TextBox ID="descriptionTextBox" runat="server" 
             Text='<%# Bind("Pershkrimi") %>' Height="100px" Width="97%"
             CssClass="GridEditingRow" TextMode="MultiLine" />
        </EditItemTemplate>
        <ItemTemplate>
          <asp:Label ID="Label2" runat="server" Text='<%# Bind("Pershkrimi") %>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Cmimi" SortExpression="Cmimi">
        <ItemTemplate>
          <asp:Label ID="Label2" runat="server" 
               Text='<%# String.Format("{0:0.00}", Eval("Cmimi")) %>'>
          </asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
          <asp:TextBox ID="priceTextBox" runat="server" Width="45px" 
                 Text='<%# String.Format("{0:0.00}", Eval("Cmimi")) %>'>
          </asp:TextBox>
        </EditItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Thumb File" SortExpression="Thumb">
        <EditItemTemplate>
          <asp:TextBox ID="thumbTextBox" Width="80px" runat="server" 
                   Text='<%# Bind("Thumb") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
          <asp:Label ID="Label3" runat="server" Text='<%# Bind("Thumb") %>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Imazh File" SortExpression="Imazhi">
        <EditItemTemplate>
          <asp:TextBox ID="imageTextBox" Width="80px" runat="server" 
                   Text='<%# Bind("Imazhi") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
          <asp:Label ID="Label4" runat="server" Text='<%# Bind("Imazhi") %>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
            <asp:TemplateField HeaderText="gjendja shitur" SortExpression="Gjendja_Shitur">
        <EditItemTemplate>
          <asp:TextBox ID="shiturTextBox" Width="80px" runat="server" 
                   Text='<%# Bind("Gjendja_Shitur") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
          <asp:Label ID="Label4" runat="server" Text='<%# Bind("Gjendja_Shitur") %>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
                  <asp:TemplateField HeaderText="gjendja magazine" SortExpression="Gjendja_Magazine">
        <EditItemTemplate>
          <asp:TextBox ID="magazineTextBox" Width="80px" runat="server" 
                   Text='<%# Bind("Gjendja_Magazine") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
          <asp:Label ID="Label4" runat="server" Text='<%# Bind("Gjendja_Magazine") %>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
                        <asp:TemplateField HeaderText="vendodhja" SortExpression="Vendodhja_ID">
        <EditItemTemplate>
          <asp:TextBox ID="vendTextBox" Width="80px" runat="server" 
                   Text='<%# Bind("Vendodhja_ID") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
          <asp:Label ID="Label4" runat="server" Text='<%# Bind("Vendodhja_ID") %>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>

      <asp:CheckboxField DataField="PromoNen" HeaderText="PromoNen" 
        SortExpression="PromoNen" />
      <asp:CheckboxField DataField="PromoFront" HeaderText="PromoFront" 
        SortExpression="PromoFront" />
      <asp:TemplateField>
        <ItemTemplate>
          <asp:HyperLink 
            Runat="server" Text="Select" 
            NavigateUrl='<%# "AdminProductDetails.aspx?Kategori_ID=" + 
            Request.QueryString["Kategori_ID"] + "&amp;Nenkategori_ID=" + 
            Request.QueryString["Nenkategori_ID"] + "&amp;Produkt_ID=" + 
            Eval("Produkt_ID") %>'
            ID="HyperLink1">
          </asp:HyperLink>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:CommandField ShowEditButton="True" />
    </Columns>
  </asp:GridView>


  <p><b>Krijo nje produkt te ri per kete kategori:</b></p>
    <p>
    <span class="WideLabel">Pronar_ID:</span>
    <asp:TextBox ID="newPronar" runat="server" Width="400px" />
  </p>
      <p>
    <span class="WideLabel">Shporta_ID:</span>
    <asp:TextBox ID="newShporta" runat="server" Width="400px" />
  </p>
  <p>
    <span class="WideLabel">Emri:</span>
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
    <span class="WideLabel">Thumb file:</span>      
    <asp:TextBox ID="newThumbnail" runat="server" Width="400px">Generic1.png</asp:TextBox>
  </p>  
  <p>
    <span class="WideLabel">Imazhi file:</span>
    <asp:TextBox ID="newImage" runat="server" Width="400px">Generic2.png</asp:TextBox>
  </p>  
      <p>
    <span class="WideLabel">Gjendja_Shitur:</span>
    <asp:TextBox ID="newShitur" runat="server" Width="400px" />
  </p>

        <p>
    <span class="WideLabel">Gjendja_Magazine:</span>
    <asp:TextBox ID="newMagazine" runat="server" Width="400px" />
  </p>
        <p>
    <span class="WideLabel">vendodhja:</span>
    <asp:TextBox ID="newVend" runat="server" Width="400px" />
  </p>
  <p>
    <span class="widelabel">PromoNen:</span>
    <asp:CheckBox ID="newPromoDept" runat="server" />
  </p>  
  <p>
    <span class="widelabel">PromoFront:</span>
    <asp:CheckBox ID="newPromoFront" runat="server" />
  </p>  
  <asp:Button ID="createProduct" runat="server" Text="Krijo Produkt" 
    onclick="createProduct_Click" />
</asp:Content>

