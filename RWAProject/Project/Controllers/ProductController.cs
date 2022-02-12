using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [HttpGet]
        public ActionResult Show()
        {
            return View(Repo.GetProducts());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(Repo.GetProduct(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(Repo.GetProduct(id));
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            try
            {
                Repo.UpdateProduct(p);
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
        public ActionResult Create(Product p)
        {
            try
            {
                Repo.CreateProduct(p);
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
                Repo.DeleteProduct(id);
                return RedirectToAction("Show");
            }
            catch (Exception ex)
            {
                return Redirect("~/Error/BadRequest");
            }
        }
    }
}