﻿<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" ➥
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>ecommerce: Oops!</title>
</head>
<body>
<form id="form1" runat="server">
<asp:HyperLink ID="HeaderLink" ImageUrl="~/Images/BalloonShopLogo.png"
NavigateUrl="~/" ToolTip="BalloonShop logo" Text="BalloonShop logo"
runat="server" />
<p>Your request generated an internal error!</p>
<p>We apologize for the inconvenience. The error has been reported and will
be fixed as soon as possible. Thank you!</p>
<p>The <b>ecommerce</b> team</p>
</form>
</body>
</html>