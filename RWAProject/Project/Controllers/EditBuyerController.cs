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
            var model = Repo.GetBuyer(id);
            return View(model);
        }
    }
}