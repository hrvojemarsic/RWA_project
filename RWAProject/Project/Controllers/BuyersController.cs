using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    public class BuyersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetBuyers()
        {
            var buyers = Repo.GetKupci();
            return Ok(buyers);
        }

        [HttpGet]
        public IHttpActionResult GetBuyer(int id)
        {
            var buyer = Repo.GetKupac(id);
            if (buyer == null)
            {
                return NotFound();
            }
            return Ok(buyer);
        }

        [HttpPost]
        public IHttpActionResult CreateBuyer(BuyerDB b)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Repo.InsertKupac(b);
            return Ok(b);
        }

        [HttpPut]
        public IHttpActionResult UpdateBuyer(int id, BuyerDB b)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (Repo.GetKupac(id) == null)
            {
                return NotFound();
            }
            b.IDBuyer = id;
            Repo.UpdateKupac(id, b.FirstName, b.LastName, b.Email, b.Tel, b.CityID);
            return Ok("Kupac uspješno ažuriran");
        }

        [HttpDelete]
        public IHttpActionResult DeleteBuyer(int id)
        {
            var buyer = Repo.GetKupac(id);
            if (buyer == null)
            {
                return NotFound();
            }
            Repo.DeleteKupac(id);
            return Ok("Kupac uspješno obrisan");
        }
    }
}
