using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Link
/// </summary>
public class Link
{
// Builds an absolute URL
private static string BuildAbsolute(string relativeUri)
{
// get current uri
Uri uri = HttpContext.Current.Request.Url;
// build absolute path
string app = HttpContext.Current.Request.ApplicationPath;
if (!app.EndsWith("/")) app += "/";
relativeUri = relativeUri.TrimStart('/');
// return the absolute path
return HttpUtility.UrlPathEncode(
String.Format("http://{0}:{1}{2}{3}",
uri.Host, uri.Port, app, relativeUri));
}
// Generate a department URL
public static string ToKategori(string kategoriId, string page)
{
if (page == "1")
return BuildAbsolute(String.Format("Catalog.aspx?Kategori_ID={0}", kategoriId));
else
    return BuildAbsolute(String.Format("Catalog.aspx?Kategori_ID={0}&Page={1}", kategoriId, page));
}
// Generate a department URL for the first page
public static string ToKategori(string kategoriId)
{
return ToKategori(kategoriId, "1");
}
public static string ToNenkategori(string kategoriId, string nenkategoriId, string
page)
{
    if (page == "1")
        return BuildAbsolute(String.Format(
        "Catalog.aspx?Kategori_ID={0}&Nenkategori_ID={1}",
        kategoriId, nenkategoriId));
    else
        return BuildAbsolute(String.Format(
        "Catalog.aspx?Kategori_ID={0}&Nenkategori_ID={1}&Page={2}",
        kategoriId, nenkategoriId, page));
}
public static string ToNenkategori(string kategoriId, string nenkategoriId)
{
    return ToNenkategori(kategoriId, nenkategoriId, "1");
}
public static string ToProdukt(string produktId)
{
    return BuildAbsolute(String.Format("Produkt.aspx?Produkt_ID={0}", produktId));
}
public static string ToProduktImage(string fileName)
{
    // build product URL
    return BuildAbsolute("/ProductImages/" + fileName);
}
public static string ToSearch(string searchString, bool allWords, string page)
{
    if (page == "1")
        return BuildAbsolute(
        String.Format("/Search.aspx?Search={0}&AllWords={1}",
        searchString, allWords.ToString()));
    else
        return BuildAbsolute(
        String.Format("/Search.aspx?Search={0}&AllWords={1}&Page={2}",
        searchString, allWords.ToString(), page));
}

    public static string ToPayPalViewCart()
{
return HttpUtility.UrlPathEncode(
String.Format("{0}&business={1}&return={2}&cancel_return={3}&display=1",
ecommerceConfiguration.PaypalUrl,
ecommerceConfiguration.PaypalEmail,
ecommerceConfiguration.PaypalReturnUrl,
ecommerceConfiguration.PaypalCancelUrl));
}
public static string ToPayPalAddItem(string productUrl, string productName
, decimal productPrice, string productOptions)
{
return HttpUtility.UrlPathEncode(
String.Format("{0}&business={1}&return={2}&cancel_return={3}&shopping_url={4}&item_name={5}&amount={6:0.00}&currency={7}&on0=Options&os0={8}&add=1",
ecommerceConfiguration.PaypalUrl,
ecommerceConfiguration.PaypalEmail,
ecommerceConfiguration.PaypalReturnUrl,
ecommerceConfiguration.PaypalCancelUrl,
productUrl,
productName,productPrice,
ecommerceConfiguration.PaypalCurrency,
productOptions));
}

    public static string ToPayPalCheckout(string orderName, decimal orderAmount)
{
    return HttpUtility.UrlPathEncode(
        String.Format("{0}/business={1}&item_name={2}&amount={3:0.00}&currency={4}&return={5}&cancel_return={6}",
            ecommerceConfiguration.PaypalUrl,
            ecommerceConfiguration.PaypalEmail,
            orderName,
            orderAmount,
            ecommerceConfiguration.PaypalCurrency,
            ecommerceConfiguration.PaypalReturnUrl,
            ecommerceConfiguration.PaypalCancelUrl));
}
}