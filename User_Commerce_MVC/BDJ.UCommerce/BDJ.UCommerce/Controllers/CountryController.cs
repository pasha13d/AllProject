using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDJ.UCommerce.Controllers
{
    public class CountryController : Controller
    {
        Models.bdjUCommerceEntities db = new Models.bdjUCommerceEntities();


        // GET: Country
        public ActionResult Index()
        {


            return View(db.countries);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.country country)
        {
            if(ModelState.IsValid)
            {
                db.countries.Add(country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(country);
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