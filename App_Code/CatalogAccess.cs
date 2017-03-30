using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Text.RegularExpressions;
/// <summary>
/// Wraps department details data
/// </summary>
public struct KategoriteDetails
{
    public string Name;
    public string Description;
}

/// <summary>
/// Wraps category details data
/// </summary>
public struct NenkategoriDetails
{
    public int kategoriId;
    public string Name;
    public string Description;
}
/// <summary>
/// Wraps product details data
/// </summary>
public struct ProduktDetails
{
    public int ProduktID;
    public int PronarID;
    public int ShportaID;
    public string Emri;
    public string Pershkrimi;
    public decimal Cmimi;
    public string Thumb;
    public string Imazhi;
    public string GjendjaShitur;
    public string GjendjaMagazine;
    public int VendodhjaID;
    public bool PromoFront;
    public bool PromoNen;
}

/// <summary>
/// Product catalog business tier component
/// </summary>
public static class CatalogAccess
{
    static CatalogAccess()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    // Retrieve the list of departments
    public static DataTable MerrKategori()
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "MerrKategorite";
        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    // get kategori details
    public static KategoriteDetails  CatalogMerrKategoriDetails(string kategoriId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogMerrKategoriDetails";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Kategori_ID";
        param.Value = kategoriId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        // wrap retrieved data into a DepartmentDetails object
        KategoriteDetails details = new KategoriteDetails();
        if (table.Rows.Count > 0)
        {
            details.Name = table.Rows[0]["Kategori_Emer"].ToString();
            details.Description = table.Rows[0]["Kategori_Pershkrim"].ToString();
        }
        // kthe kategori  details
        return details;
    }
    // Get nenkategori details
    public static NenkategoriDetails CatalogMerrNenkategoriDetails(string nenkategoriId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogMerrNenkategoriDetails";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Nenkategori_ID";
        param.Value = nenkategoriId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        // wrap retrieved data into a CategoryDetails object
        NenkategoriDetails details = new NenkategoriDetails();
        if (table.Rows.Count > 0)
        {
            details.kategoriId = Int32.Parse(table.Rows[0]["Kategori_ID"].ToString());
            details.Name = table.Rows[0]["Nenkategori_Emer"].ToString();
            details.Description = table.Rows[0]["Nenkategori_Pershkrim"].ToString();
        }
        // return department details
        return details;
    }

    // Get product details
public static ProduktDetails MerrProduktDetails(string ProduktID)
{
// get a configured DbCommand object
DbCommand comm = GenericDataAccess.CreateCommand();
// set the stored procedure name
comm.CommandText = "CatalogMerrProduktDetails";
// create a new parameter
DbParameter param = comm.CreateParameter();
param.ParameterName = "@Produkt_ID";
param.Value = ProduktID;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// execute the stored procedure
DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
// wrap retrieved data into a ProductDetails object
ProduktDetails details = new ProduktDetails();
if (table.Rows.Count > 0)
{
// get the first table row
DataRow dr = table.Rows[0];
// get product details
details.ProduktID = int.Parse(ProduktID);

details.PronarID = int.Parse(dr["Pronar_ID"].ToString());

details.ShportaID = int.Parse(dr["Shporta_ID"].ToString());

details.Emri = dr["Emri"].ToString();

details.Pershkrimi = dr["Pershkrimi"].ToString();

details.Cmimi = Decimal.Parse(dr["Cmimi"].ToString());
details.Thumb = dr["Thumb"].ToString();
details.Imazhi = dr["Imazhi"].ToString();
details.GjendjaShitur = dr["Gjendja_Shitur"].ToString();
details.GjendjaMagazine = dr["Gjendja_Magazine"].ToString();


details.VendodhjaID = int.Parse(dr["Vendodhja_ID"].ToString());

details.PromoFront = bool.Parse(dr["PromoFront"].ToString());
details.PromoNen =bool.Parse(dr["PromoNen"].ToString());
}
// return department details
return details;
}

// retrieve the list of categories in a department
public static DataTable MerrNenkategoriteNeKategorite(string kategoriId)
{
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "CatalogMerrNenkategoriteNeKategorite";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@Kategori_ID";
    param.Value = kategoriId;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // execute the stored procedure
    return GenericDataAccess.ExecuteSelectCommand(comm);
}

// Retrieve the list of products on catalog promotion
public static DataTable MerrProduktetNeFrontPromo(string pageNumber, out int
howManyPages)
{
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "CatalogMerrProduktetNeFrontPromo";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@DescriptionLength";
    param.Value = ecommerceConfiguration.ProductDescriptionLength;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@PageNumber";
    param.Value = pageNumber;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@ProductsPerPage";
    param.Value = ecommerceConfiguration.ProductsPerPage;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@HowManyProducts";
    param.Direction = ParameterDirection.Output;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // execute the stored procedure and save the results in a DataTable
    DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
    // calculate how many pages of products and set the out parameter
    int howManyProducts = Int32.Parse(comm.Parameters
    ["@HowManyProducts"].Value.ToString());
    howManyPages = (int)Math.Ceiling((double)howManyProducts /
    (double)ecommerceConfiguration.ProductsPerPage);
    // return the page of products
    return table;
}
    // retrieve the list of products featured for a department
public static DataTable MerrProduktetNeKatPromo
(string kategoriId, string pageNumber, out int howManyPages)
{
// get a configured DbCommand object
DbCommand comm = GenericDataAccess.CreateCommand();
// set the stored procedure name
comm.CommandText = "CatalogMerrProduktetNeKatPromo";
// create a new parameter
DbParameter param = comm.CreateParameter();
param.ParameterName = "@Kategori_ID";
param.Value = kategoriId;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@DescriptionLength";
param.Value = ecommerceConfiguration.ProductDescriptionLength;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@PageNumber";
param.Value = pageNumber;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@ProductsPerPage";
param.Value = ecommerceConfiguration.ProductsPerPage;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@HowManyProducts";
param.Direction = ParameterDirection.Output;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// execute the stored procedure and save the results in a DataTable
DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
// calculate how many pages of products and set the out parameter
int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());
howManyPages = (int)Math.Ceiling((double)howManyProducts /
(double)ecommerceConfiguration.ProductsPerPage);
// return the page of products
return table;
}
    // retrieve the list of products in a category
public static DataTable MerrProduktetNeNenkategori
(string nenkategoriId, string pageNumber, out int howManyPages)
{
// get a configured DbCommand object
DbCommand comm = GenericDataAccess.CreateCommand();
// set the stored procedure name
comm.CommandText = "CatalogMerrProduktetNeNenkategori";
// create a new parameter
DbParameter param = comm.CreateParameter();
param.ParameterName = "@Nenkategori_ID";
param.Value = nenkategoriId;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@DescriptionLength";
param.Value = ecommerceConfiguration.ProductDescriptionLength;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@PageNumber";
param.Value = pageNumber;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@ProductsPerPage";
param.Value = ecommerceConfiguration.ProductsPerPage;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@HowManyProducts";
param.Direction = ParameterDirection.Output;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// execute the stored procedure and save the results in a DataTable
DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
// calculate how many pages of products and set the out parameter
int howManyProducts = Int32.Parse
(comm.Parameters["@HowManyProducts"].Value.ToString());
howManyPages = (int)Math.Ceiling((double)howManyProducts /
(double)ecommerceConfiguration.ProductsPerPage);
// return the page of products
return table;
}
    // Search the product catalog
public static DataTable Search(string searchString, string allWords,
string pageNumber, out int howManyPages)
{
// get a configured DbCommand object
DbCommand comm = GenericDataAccess.CreateCommand();
// set the stored procedure name
comm.CommandText = "SearchCatalog";
    // create a new parameter
DbParameter param = comm.CreateParameter();
param.ParameterName = "@DescriptionLength";
param.Value = ecommerceConfiguration.ProductDescriptionLength;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@AllWords";
param.Value = allWords.ToUpper() == "TRUE" ? "1" : "0";
param.DbType = DbType.Byte;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@PageNumber";
param.Value = pageNumber;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@ProductsPerPage";
param.Value = ecommerceConfiguration.ProductsPerPage;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@HowManyResults";
param.Direction = ParameterDirection.Output;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// define the maximum number of words
int howManyWords = 5;
// transform search string into array of words
string[] words = Regex.Split(searchString, "[^a-zA-Z0-9]+");
// add the words as stored procedure parameters
int index = 1;
for (int i = 0; i <= words.GetUpperBound(0) && index <= howManyWords; i++)
// ignore short words
if (words[i].Length > 2)
{
// create the @Word parameters
param = comm.CreateParameter();
param.ParameterName = "@Word" + index.ToString();
param.Value = words[i];
param.DbType = DbType.String;
comm.Parameters.Add(param);
index++;
}
// execute the stored procedure and save the results in a DataTable
DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
// calculate how many pages of products and set the out parameter
int howManyProducts =
Int32.Parse(comm.Parameters["@HowManyResults"].Value.ToString());
howManyPages = (int)Math.Ceiling((double)howManyProducts /
(double)ecommerceConfiguration.ProductsPerPage);
// return the page of products
return table;
}
    // Update Kategori details
public static bool UpdateKategori(string id, string name, string description)
{
// get a configured DbCommand object
DbCommand comm = GenericDataAccess.CreateCommand();
// set the stored procedure name
comm.CommandText = "CatalogUpdateKategori";
// create a new parameter
DbParameter param = comm.CreateParameter();
param.ParameterName = "@KategoriId";
param.Value = id;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
    // create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@KategoriName";
param.Value = name;
param.DbType = DbType.String;
param.Size = 50;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@KategoriDescription";
param.Value = description;
param.DbType = DbType.String;
param.Size = 1000;
comm.Parameters.Add(param);
// result will represent the number of changed rows
int result = -1;
try
{
// execute the stored procedure
result = GenericDataAccess.ExecuteNonQuery(comm);
}
catch
{
// any errors are logged in GenericDataAccess, we ignore them here
}
// result will be 1 in case of success
return (result != -1);
}
// Delete Kategori
public static bool DeleteKategori(string id)
{
// get a configured DbCommand object
DbCommand comm = GenericDataAccess.CreateCommand();
// set the stored procedure name
comm.CommandText = "CatalogDeleteKategori";
// create a new parameter
DbParameter param = comm.CreateParameter();
param.ParameterName = "@KategoriId";
param.Value = id;
param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
// execute the stored procedure; an error will be thrown by the
// database if the department has related categories, in which case
// it is not deleted
int result = -1;
try
{
result = GenericDataAccess.ExecuteNonQuery(comm);
}
catch
{
// any errors are logged in GenericDataAccess, we ignore them here
}
// result will be 1 in case of success
return (result != -1);
}
// Add a new Kategori
public static bool AddKategori(string name, string description)
{
// get a configured DbCommand object
DbCommand comm = GenericDataAccess.CreateCommand();
// set the stored procedure name
comm.CommandText = "CatalogAddKategori";
// create a new parameter
DbParameter param = comm.CreateParameter();
param.ParameterName = "@KategoriName";
param.Value = name;
param.DbType = DbType.String;
param.Size = 50;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@KategoriDescription";
param.Value = description;
param.DbType = DbType.String;
param.Size = 1000;
comm.Parameters.Add(param);
// result will represent the number of changed rows
int result = -1;
try
{
    // execute the stored procedure
    result = GenericDataAccess.ExecuteNonQuery(comm);
}
catch
{
    // any errors are logged in GenericDataAccess, we ignore them here
}
// result will be 1 in case of success
return (result != -1);
}

    // Create a new Category
public static bool CreateNenkategori(string kategoriId,
string name, string description)
{
// get a configured DbCommand object
DbCommand comm = GenericDataAccess.CreateCommand();
// set the stored procedure name
comm.CommandText = "CatalogCreateNenkategori";
// create a new parameter
DbParameter param = comm.CreateParameter();
param.ParameterName = "@KategoriID";
param.Value = kategoriId;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@NenkategoriName";
param.Value = name;
param.DbType = DbType.String;
param.Size = 50;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@NenkategoriDescription";
param.Value = description;
param.DbType = DbType.String;
param.Size = 1000;
comm.Parameters.Add(param);
// result will represent the number of changed rows
int result = -1;
try
{
// execute the stored procedure
result = GenericDataAccess.ExecuteNonQuery(comm);
}
catch
{
// any errors are logged in GenericDataAccess, we ignore them here
}
    // result will be 1 in case of success
return (result != -1);
}
// Update category details
public static bool UpdateNenkategori(string id, string name, string description)
{
// get a configured DbCommand object
DbCommand comm = GenericDataAccess.CreateCommand();
// set the stored procedure name
comm.CommandText = "CatalogUpdateNenkategori";
// create a new parameter
DbParameter param = comm.CreateParameter();
param.ParameterName = "@NenkategoriId";
param.Value = id;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@NenkategoriName";
param.Value = name;
param.DbType = DbType.String;
param.Size = 50;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@NenkategoriDescription";
param.Value = description;
param.DbType = DbType.String;
param.Size = 1000;
comm.Parameters.Add(param);
// result will represent the number of changed rows
int result = -1;
try
{
// execute the stored procedure
result = GenericDataAccess.ExecuteNonQuery(comm);
}
catch
{
    // any errors are logged in GenericDataAccess, we ignore them here
}
// result will be 1 in case of success
return (result != -1);
}
// Delete Category
public static bool DeleteNenkategori(string id)
{
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "CatalogDeleteNenkategori";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@NenkategoriId";
    param.Value = id;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // execute the stored procedure; an error will be thrown by the
    // database if the Category has related categories, in which case
    // it is not deleted
    int result = -1;
    try
    {
        result = GenericDataAccess.ExecuteNonQuery(comm);
    }
    catch
    {
        // any errors are logged in GenericDataAccess, we ignore them here
    }
    // result will be 1 in case of success
    return (result != -1);
}
public static DataTable MerrGjitheproduktetNeNenkategorite(string nenkategoriId)
{
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "MerrGjitheproduktetNeNenkategorite";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@Nenkategori_ID";
    param.Value = nenkategoriId;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // execute the stored procedure and save the results in a DataTable
    DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
    return table;
}
  
public static bool CreateProduct(string nenkategoriId,string pronarId, string shportaId, string produktemri,
string pershkrimi, string cmimi, string Thumb, string 
imazhi,string gjendjashitur,string gjendjamagazine,string vendodhja, string PromoNen, string PromoFront)
{
// get a configured DbCommand object
DbCommand comm = GenericDataAccess.CreateCommand();
// set the stored procedure name
comm.CommandText = "CatalogKrijoProduktet";
// create a new parameter
DbParameter param = comm.CreateParameter();
param.ParameterName = "@Nenkategori_ID";
param.Value = nenkategoriId;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// pronar parameter
param = comm.CreateParameter();
param.ParameterName = "@Pronar_ID";
param.Value = pronarId;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// shporta parameter
param = comm.CreateParameter();
param.ParameterName = "@Shporta_ID";
param.Value = shportaId;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@ProduktEmri";
param.Value = produktemri;
param.DbType = DbType.String;
param.Size = 50;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@ProduktPershkrimi";
param.Value = pershkrimi;
param.DbType = DbType.String;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@Cmimi";
param.Value = cmimi;
param.DbType = DbType.Decimal;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@Thumb";
param.Value = Thumb;
param.DbType = DbType.String;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@Imazhi";
param.Value = imazhi;
param.DbType = DbType.String;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@Gjendja_Shitur";
param.Value = gjendjashitur;
param.DbType = DbType.String;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@Gjendja_Magazine";
param.Value = gjendjamagazine;
param.DbType = DbType.String;
comm.Parameters.Add(param);
param = comm.CreateParameter();
param.ParameterName = "@Vendodhja_ID";
param.Value = vendodhja;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@PromoNen";
param.Value = PromoNen;
param.DbType = DbType.Boolean;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@PromoFront";
param.Value = PromoFront;
param.DbType = DbType.Boolean;
comm.Parameters.Add(param);
// result will represent the number of changed rows
int result = -1;
try
{
// execute the stored procedure
result = GenericDataAccess.ExecuteNonQuery(comm);
}
catch
{
// any errors are logged in GenericDataAccess, we ignore them here
}
// result will be 1 in case of success 
return (result >= 1);
}
    // Update an existing product
public static bool UpdateProduct(string produktId, string pronarid,string shportaid,string emri, string
pershkrimi, string cmimi, string Thumb, string Imazhi, string gjendjashitur, string gjendjamagazine, string vendodhja, string 
PromoNen, string PromoFront)
{
// get a configured DbCommand object
DbCommand comm = GenericDataAccess.CreateCommand();
// set the stored procedure name
comm.CommandText = "CatalogUpdateProdukt";
// create a new parameter
DbParameter param = comm.CreateParameter();
param.ParameterName = "@Produkt_ID";
param.Value = produktId;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@Pronar_ID";
param.Value = produktId;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@Shporta_ID";
param.Value = produktId;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@ProduktEmri";
param.Value = emri;
param.DbType = DbType.String;
param.Size = 50;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@ProduktPershkrimi";
param.Value = pershkrimi;
param.DbType = DbType.String;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@Cmimi";
param.Value = cmimi;
param.DbType = DbType.Decimal;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@Thumb";
param.Value = Thumb;
param.DbType = DbType.String;
param.Size = 50;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@Imazhi";
param.Value = Imazhi;
param.DbType = DbType.String;
param.Size = 50;
comm.Parameters.Add(param);
    //create
param = comm.CreateParameter();
param.ParameterName = "@Gjendja_Shitur";
param.Value = gjendjashitur;
param.DbType = DbType.String;
param.Size = 50;
comm.Parameters.Add(param);
//create
param = comm.CreateParameter();
param.ParameterName = "@Gjendja_Magazine";
param.Value = gjendjamagazine;
param.DbType = DbType.String;
param.Size = 50;
comm.Parameters.Add(param);
    //create
param.ParameterName = "@Vendodhja_ID";
param.Value = vendodhja;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@PromoNen";
param.Value = PromoNen;
param.DbType = DbType.Boolean;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@PromoFront";
param.Value = PromoFront;
param.DbType = DbType.Boolean;
comm.Parameters.Add(param);
// result will represent the number of changed rows
int result = -1;
try
{
    // execute the stored procedure
    result = GenericDataAccess.ExecuteNonQuery(comm);
}
catch
{
    // any errors are logged in GenericDataAccess, we ignore them here
}
// result will be 1 in case of success 
return (result != -1);
}
    public static DataTable MerrNenkategoriMeProduktet(string produktId)
{
// get a configured DbCommand object
DbCommand comm = GenericDataAccess.CreateCommand();
// set the stored procedure name
comm.CommandText = "CatalogMerrNenKategoriesmeProduktet";
// create a new parameter
DbParameter param = comm.CreateParameter();
param.ParameterName = "@Produkt_ID";
param.Value = produktId;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// execute the stored procedure
return GenericDataAccess.ExecuteSelectCommand(comm);
}
    public static DataTable MerrNenkategoriPaProduktet(string produktId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogMerrNenkategoriesPaProduktet";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Produkt_ID";
        param.Value = produktId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    // assign a produ
    public static bool AssignProductToCategory(string produktId, string nenkategoryId)
{
// get a configured DbCommand object
DbCommand comm = GenericDataAccess.CreateCommand();
// set the stored procedure name
comm.CommandText = "CatalogAssignProduktNenkategori";
// create a new parameter
DbParameter param = comm.CreateParameter();
param.ParameterName = "@Produkt_ID";
param.Value = produktId;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@Nenkategori_ID";
param.Value = nenkategoryId;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// result will represent the number of changed rows
int result = -1;
try
{
// execute the stored procedure
result = GenericDataAccess.ExecuteNonQuery(comm);
}
catch
{
// any errors are logged in GenericDataAccess, we ignore them here
}
// result will be 1 in case of success 
return (result != -1);
}
    public static bool MoveProductToCategory(string productId, string oldnenkategoriId,
string newnenkategoriId)
{
// get a configured DbCommand object
DbCommand comm = GenericDataAccess.CreateCommand();
// set the stored procedure name
comm.CommandText = "CatalogMoveProductToNenkategori";
// create a new parameter
DbParameter param = comm.CreateParameter();
param.ParameterName = "@Produkt_ID";
param.Value = productId;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@OldNenkategoryID";
param.Value = oldnenkategoriId;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@NewNenkategoryID";
param.Value = newnenkategoriId;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// result will represent the number of changed rows
int result = -1;
    try
{
// execute the stored procedure
result = GenericDataAccess.ExecuteNonQuery(comm);
}
catch
{
// any errors are logged in GenericDataAccess, we ignore them here
}
// result will be 1 in case of success 
return (result != -1);
}
    public static bool RemoveProductFromCategory(string produktId, string 
nenkategoriId)
{
// get a configured DbCommand object
DbCommand comm = GenericDataAccess.CreateCommand();
// set the stored procedure name
comm.CommandText = "CatalogRemoveProduktetngaNenkategori";
// create a new parameter
DbParameter param = comm.CreateParameter();
param.ParameterName = "@Produkt_ID";
param.Value = produktId;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// create a new parameter
param = comm.CreateParameter();
param.ParameterName = "@Nenkategori_ID";
param.Value = nenkategoriId;
param.DbType = DbType.Int32;
comm.Parameters.Add(param);
// result will represent the number of changed rows
int result = -1;
try
{
// execute the stored procedure
result = GenericDataAccess.ExecuteNonQuery(comm);
}
catch
{
// any errors are logged in GenericDataAccess, we ignore them here
}
// result will be 1 in case of success 
return (result != -1);
}
    public static bool DeleteProdukt(string produktId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogDeleteProduktet";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Produkt_ID";
        param.Value = produktId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccess, we ignore them here
        }
        // result will be 1 in case of success 
        return (result != -1);
    }

    // gets product recommendations
    public static DataTable GetRecommendations(string productId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetProductRecommendations";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@DescriptionLength";
        param.Value = ecommerceConfiguration.ProductDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
}