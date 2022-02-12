using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Repo
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private static string cs_project = ConfigurationManager.ConnectionStrings["cs_project"].ConnectionString;

        public static IEnumerable<BuyerDB> GetKupci()
        {
            var tblBuyers = SqlHelper.ExecuteDataset(cs, "GetKupci").Tables[0];

            foreach (DataRow row in tblBuyers.Rows)
            {
                yield return new BuyerDB()
                {
                    IDBuyer = (int)row["IDKupac"],
                    FirstName = row["Ime"].ToString(),
                    LastName = row["Prezime"].ToString(),
                    Email = row["Email"].ToString(),
                    CityID = (int)row["Naziv_Grada"]
                };
            }
        }

        public static BuyerDB GetKupac(int id)
        {
            var buyer = SqlHelper.ExecuteDataset(cs, "GetKupac", id).Tables[0].Rows[0];

            return new BuyerDB()
            {
                IDBuyer = id,
                FirstName = buyer["Ime"].ToString(),
                LastName = buyer["Prezime"].ToString(),
                Email = buyer["Email"].ToString(),
                CityID = (int)buyer["GradID"]
            };
        }

        public static int InsertKupac(BuyerDB b)
            => SqlHelper.ExecuteNonQuery(cs, "InsertKupac", b.FirstName, b.LastName, b.Email, b.Tel, b.CityID);

        public static int DeleteKupac(int id)
            => SqlHelper.ExecuteNonQuery(cs, "DeleteKupac", id);

        public int CreateUser(string userName, string email, string userPass)
            => SqlHelper.ExecuteNonQuery(cs_project, "CreateUser", email, userName, userPass);

        public bool CheckUser(string email, string userPass)
            //=> SqlHelper.ExecuteNonQuery(cs_project, "CheckUser", email, userPass) == 1;
            => Convert.ToInt32(SqlHelper.ExecuteScalar(cs_project, "CheckUser", email, userPass)) == 1;

        public static IEnumerable<Country> GetCountries()
        {
            var tblCountries = SqlHelper.ExecuteDataset(cs, "GetCountries").Tables[0];

            foreach (DataRow row in tblCountries.Rows)
            {
                yield return new Country()
                {
                    IDCountry = (int)row["IDDrzava"],
                    Name = row["Naziv"].ToString()
                };
            }
        }

        public static int GetCountryID(int buyerID)
        {
            // int countryID = SqlHelper.ExecuteNonQuery(cs, "GetCountryID", buyerID); zašto ovo vraća za id "-1" a ne id koji bi triba ka ovo doli?
            var row = SqlHelper.ExecuteDataset(cs, "GetCountryID", buyerID).Tables[0].Rows[0];
            int countryID = (int)row["IDDrzava"];
            return countryID;
        }

        public static int GetCityID(int buyerID)
        {
            var row = SqlHelper.ExecuteDataset(cs, "GetCityID", buyerID).Tables[0].Rows[0];
            int cityID = (int)row["GradID"];
            return cityID;
        }

        public static IEnumerable<City> GetCities(int countryID)
        {
            var tblCities = SqlHelper.ExecuteDataset(cs, "GetCities", countryID).Tables[0];

            foreach (DataRow row in tblCities.Rows)
            {
                yield return new City()
                {
                    IDCity = (int)row["IDGrad"],
                    Name = row["Naziv"].ToString(),
                    CountryID = countryID
                };
            }
        }

        public static int DeleteCity(int cityID)
            => SqlHelper.ExecuteNonQuery(cs, "DeleteCity", cityID);

        public static int InsertCity(City city)
            => SqlHelper.ExecuteNonQuery(cs, "InsertCity", city.Name, city.CountryID);

        public static Buyer GetBuyer(int idBuyer)
        {
            var buyer = SqlHelper.ExecuteDataset(cs, "GetBuyer", idBuyer).Tables[0].Rows[0];

            return new Buyer()
            {
                IDBuyer = idBuyer,
                FirstName = buyer["Ime"].ToString(),
                LastName = buyer["Prezime"].ToString(),
                Email = buyer["Email"].ToString(),
                CityName = buyer["Naziv_Grada"].ToString(),
                CountryName = buyer["Naziv_Drzave"].ToString()
            };
        }

        public static IEnumerable<Buyer> GetBuyers()
        {
            var tblBuyers = SqlHelper.ExecuteDataset(cs, "GetBuyers").Tables[0];

            foreach (DataRow row in tblBuyers.Rows)
            {
                yield return new Buyer()
                {
                    IDBuyer = (int)row["IDKupac"],
                    FirstName = row["Ime"].ToString(),
                    LastName = row["Prezime"].ToString(),
                    Email = row["Email"].ToString(),
                    CityName = row["Naziv_Grada"].ToString(),
                    CountryName = row["Naziv_Drzave"].ToString()
                };
            }
        }

        public static IEnumerable<Buyer> GetBuyersByCity(int cityID)
        {
            var tblBuyers = SqlHelper.ExecuteDataset(cs, "GetBuyersByCity", cityID).Tables[0];

            foreach (DataRow row in tblBuyers.Rows)
            {
                yield return new Buyer()
                {
                    IDBuyer = (int)row["IDKupac"],
                    FirstName = row["Ime"].ToString(),
                    LastName = row["Prezime"].ToString(),
                    Email = row["Email"].ToString(),
                    CityName = row["Naziv_Grada"].ToString(),
                    CountryName = row["Naziv_Drzave"].ToString()
                };
            }
        }

        public static int UpdateKupac(int idBuyer, string firstName, string lastName, string email, string tel, int cityID)
            => SqlHelper.ExecuteNonQuery(cs, "UpdateBuyer", idBuyer, firstName, lastName, email, tel, cityID);


        public static IEnumerable<Bill> GetBillsByBuyer(int buyerID)
        {
            var tblBillsByBuyer = SqlHelper.ExecuteDataset(cs, "GetBillsByBuyer", buyerID).Tables[0];

            foreach (DataRow row in tblBillsByBuyer.Rows)
            {
                yield return new Bill()
                {
                    IDBill = (int)row["IDRacun"],
                    DateOfIssue = (DateTime)row["DatumIzdavanja"],
                    BillNumber = row["BrojRacuna"].ToString(),
                    BuyerID = buyerID,
                    CommercialistID = (int)row["KomercijalistID"],
                    CreditCardID = (int)row["KreditnaKarticaID"],
                    Comment = row["Komentar"].ToString()
                };
            }
        }

        public static List<BillDetail> GetBillDetails(int billID)
        {
            List<BillDetail> billDetails = new List<BillDetail>();
            var tblBillDetails = SqlHelper.ExecuteDataset(cs, "GetBillDetails", billID).Tables[0];

            foreach (DataRow row in tblBillDetails.Rows)
            {
                billDetails.Add(new BillDetail()
                {
                    ID = (int)row["ID"],
                    Product = row["Proizvod"].ToString(),
                    Subcategory = row["Potkategorija"].ToString(),
                    Category = row["Kategorija"].ToString(),
                    BillID = billID
                });
            }

            return billDetails;
        }

        public static IEnumerable<Category> GetCategories()
        {
            var tblCategories = SqlHelper.ExecuteDataset(cs, "GetCategories").Tables[0];

            foreach (DataRow row in tblCategories.Rows)
            {
                yield return new Category()
                {
                    IDCategory = (int)row["IDKategorija"],
                    Name = row["Naziv"].ToString()
                };
            }
        }

        public static Category GetCategory(int categoryID)
        {
            var category = SqlHelper.ExecuteDataset(cs, "GetCategory", categoryID).Tables[0].Rows[0];

            return new Category
            {
                IDCategory = categoryID,
                Name = category["Naziv"].ToString()
            };
        }

        public static int CreateCategory(Category c)
            => SqlHelper.ExecuteNonQuery(cs, "CreateCategory", c.Name);

        public static int UpdateCategory(int categoryID, string name)
            => SqlHelper.ExecuteNonQuery(cs, "UpdateCategory", categoryID, name);

        public static int DeleteCategory(int categoryiD)
            => SqlHelper.ExecuteNonQuery(cs, "DeleteCategory", categoryiD);

        public static IEnumerable<Subcategory> GetSubcategories()
        {
            var tblSubcategories = SqlHelper.ExecuteDataset(cs, "GetSubCategories").Tables[0];

            foreach (DataRow row in tblSubcategories.Rows)
            {
                yield return new Subcategory()
                {
                    IDSubcategory = (int)row["IDPotkategorija"],
                    CategoryID = (int)row["KategorijaID"],
                    Name = row["Naziv"].ToString()
                };
            }
        }

        public static Subcategory GetSubcategory(int id)
        {
            var subCategory = SqlHelper.ExecuteDataset(cs, "GetSubCategory", id).Tables[0].Rows[0];

            return new Subcategory
            {
                IDSubcategory = id,
                CategoryID = (int)subCategory["KategorijaID"],
                Name = subCategory["Naziv"].ToString()
            };
        }

        public static int CreateSubcategory(Subcategory sc)
            => SqlHelper.ExecuteNonQuery(cs, "CreateSubCategory", sc.CategoryID, sc.Name);

        public static int UpdateSubcategory(Subcategory sc)
            => SqlHelper.ExecuteNonQuery(cs, "UpdateSubCategory", sc.IDSubcategory, sc.CategoryID, sc.Name);

        public static int DeleteSubcategory(int id)
            => SqlHelper.ExecuteNonQuery(cs, "DeleteSubCategory", id);

        public static IEnumerable<Product> GetProducts()
        {
            var tblProducts = SqlHelper.ExecuteDataset(cs, "GetProducts").Tables[0];

            foreach (DataRow row in tblProducts.Rows)
            {
                yield return new Product()
                {
                    IDProduct = (int)row["IDPotkategorija"],
                    Name = row["Naziv"].ToString(),
                    ProductNumber = row["BrojProizvoda"].ToString(),
                    Color = row["Boja"].ToString(),
                    MinQuantityAtLager = (int)row["MinimalnaKolicinaNaSkladistu"],
                    PriceWithoutPDV = (double)row["CijenaBezPDV"],
                    SubcategoryID = (int)row["KategorijaID"]
                };
            }
        }

        public static Product GetProduct(int id)
        {
            var product = SqlHelper.ExecuteDataset(cs, "GetProduct", id).Tables[0].Rows[0];

            return new Product
            {
                IDProduct = id,
                SubcategoryID = (int)product["KategorijaID"],
                Name = product["Naziv"].ToString(),
                Color = product["Boja"].ToString(),
                MinQuantityAtLager = (int)product["MinimalnaKolicinaNaSkladistu"],
                PriceWithoutPDV = (double)product["CijenaBezPDV"],
                ProductNumber = product["BrojProizvoda"].ToString(),
            };
        }

        public static int CreateProduct(Product p)
            => SqlHelper.ExecuteNonQuery(cs, "CreateProduct", p.Name, p.ProductNumber, p.Color, p.MinQuantityAtLager, p.PriceWithoutPDV, p.SubcategoryID);

        public static int UpdateProduct(Product p)
            => SqlHelper.ExecuteNonQuery(cs, "UpdateProduct", p.IDProduct, p.Name, p.ProductNumber, p.Color, p.MinQuantityAtLager, p.PriceWithoutPDV, p.SubcategoryID);

        public static int DeleteProduct(int id)
            => SqlHelper.ExecuteNonQuery(cs, "DeleteProduct", id);
    }

}
