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
    }
}