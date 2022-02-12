using Project.Models;
using Project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class EditBuyerController : Controller
    {
        public ActionResult Index()
        {
            var model = Repo.GetBuyers();
            return View(model);
        }

        // GET: EditBuyer/1
        [HttpGet]
        public ActionResult Edit(int id)
        {
            int countryID = Repo.GetCountryID(id);
            int cityID = Repo.GetCityID(id);
            ViewBag.countries = Repo.GetCountries();
            ViewBag.cities = Repo.GetCities(countryID);
            ViewBag.countryID = countryID;
            Buyer buyer = Repo.GetBuyer(id);
            var model = new EditBuyerVM
            {
                IDBuyer = buyer.IDBuyer,
                FirstName = buyer.FirstName,
                LastName = buyer.LastName,
                Email = buyer.Email,
                CityName = buyer.CityName,
                CountryName = buyer.CountryName,
                Countries = ViewBag.countries,
                Cities = ViewBag.cities,
                IDCountry = countryID,
                IDCity = cityID
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditBuyerVM b)
        {
            try
            {
                Repo.UpdateKupac(b.IDBuyer, b.FirstName, b.LastName, b.Email, "000", b.IDCity);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Redirect("~/Error/BadRequest");
            }
        }
    }
}