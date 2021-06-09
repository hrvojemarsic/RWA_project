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
        public ActionResult Edit(string buyerID)
        {
            var model = Repo.GetBuyer(int.Parse(buyerID));
            return View(model);
        }
    }
}