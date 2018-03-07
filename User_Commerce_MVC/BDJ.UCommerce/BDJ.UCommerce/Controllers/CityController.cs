using BDJ.UCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDJ.UCommerce.Controllers
{
    public class CityController : Controller
    {
        bdjUCommerceEntities db = new bdjUCommerceEntities();


        // GET: Country
        public ActionResult Index()
        {


            return View(db.cities);
        }

        public ActionResult Create()
        {
            ViewBag.countryId = new SelectList(db.countries, "id", "name");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.city city)
        {
            if(ModelState.IsValid)
            {
                db.cities.Add(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.countryId = new SelectList(db.countries, "id", "name", city.countryId);
            return View(city);
        }

        public ActionResult Update(int id = 0)
        {
            if (id <= 0)
                return HttpNotFound();

            var country = db.countries.Find(id);

            if (country == null)
                return HttpNotFound();



            return View(country);
        }

        [HttpPost]
        public ActionResult Update(Models.country country, int id = 0)
        {
            
            var Oldcountry = db.countries.Find(id);

            Oldcountry.name = country.name;
            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch { }
            
            return View(country);
        }

    }
}