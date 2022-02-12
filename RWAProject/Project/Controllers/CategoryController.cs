using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        [HttpGet]
        public ActionResult Show()
        {
            return View(Repo.GetCategories());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(Repo.GetCategory(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(Repo.GetCategory(id));
        }
        
        [HttpPost]
        public ActionResult Edit(Category c)
        {
            try
            {
                Repo.UpdateCategory(c.IDCategory, c.Name);
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
        public ActionResult Create(Category c)
        {
            try
            {
                Repo.CreateCategory(c);
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
                Repo.DeleteCategory(id);
                return RedirectToAction("Show");
            }
            catch (Exception ex)
            {
                return Redirect("~/Error/BadRequest");
            }
        }
    }
}