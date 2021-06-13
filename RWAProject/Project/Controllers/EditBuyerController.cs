using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class EditBuyerController : Controller
    {
        // GET: EditBuyer
        public ActionResult Edit(int id)
        {
            ViewBag.cities = Repo.GetCities(Repo.GetCountryID(id));
            return View(Repo.GetBuyer(id));
        }
    }
}