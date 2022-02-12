using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class SubcategoryController : Controller
    {
        // GET: Category
        [HttpGet]
        public ActionResult Show()
        {
            return View(Repo.GetSubcategories());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(Repo.GetSubcategory(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(Repo.GetSubcategory(id));
        }

        [HttpPost]
        public ActionResult Edit(Subcategory sc)
        {
            try
            {
                Repo.UpdateSubcategory(sc);
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Redirect("~/Error/BadRequest");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Subcategory sc)
        {
            try
            {
                Repo.CreateSubcategory(sc);
                return RedirectToAction("Show");
            }
            catch (Exception ex)
            {
                return Redirect("~/Error/BadRequest");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Repo.DeleteSubcategory(id);
                return RedirectToAction("Show");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Show");
            }
        }
    }
}