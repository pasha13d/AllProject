using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BDJ.UCommerce.Models;

namespace BDJ.UCommerce.Controllers
{
    public class ProductController : Controller
    {
        private bdjUCommerceEntities db = new bdjUCommerceEntities();

        // GET: Product
        public ActionResult Index()
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["dv"] = "Index";
                Session["dc"] = "Product";
                return RedirectToAction("Login", "Users");
            }

            var products = db.products.Include(p => p.brand).Include(p => p.category).Include(p => p.condition).Include(p => p.user);
            return View(products.ToList());
        }

        public ActionResult All(int like = 0, int brand = 0, string search = " ", double priceFrom = 0, double priceTo = 0, string nego = "all")
        {

            ViewBag.search = search;
            ViewBag.brand = brand;
            ViewBag.priceFrom = priceFrom;
            ViewBag.priceTo = priceTo;
            ViewBag.nego = nego;

            if(like > 0)
            {
                productLike pk = new productLike();
                pk.ProductId = like;
                pk.DateTime = DateTime.Now;
                pk.Ip = Request.UserHostAddress;
                pk.UserId = (int)Session["id"];
                db.productLikes.Add(pk);
                db.SaveChanges();
            }

            var products = db.products.Where(p=>p.productVerifieds.Count > 0 && p.productCloseds.Count <= 0);

            if (!string.IsNullOrEmpty(search))
                products = products.Where(p => p.Description.ToLower().Contains(search.ToLower()) || p.Links.ToLower().Contains(search.ToLower()) || p.Name.ToLower().Contains(search.ToLower()));

            if (priceTo > 0)
                products = products.Where(p => p.OfferPrice >= priceFrom && p.OfferPrice <= priceTo);



            if(brand > 0)
            {
                ViewBag.brand = db.brands.Find(brand).name;
                products = products.Where(p => p.BrandId == brand);
            }

            if (nego == "Fixed")
                products = products.Where(p => p.Negotiable == false);
            else if (nego == "Not Fixed")
                products = products.Where(p => p.Negotiable == true);

            return View(products.ToList());
        }

        public ActionResult Category(int id = 0, int like = 0, int brand = 0)
        {

            if (like > 0)
            {
                productLike pk = new productLike();
                pk.ProductId = like;
                pk.DateTime = DateTime.Now;
                pk.Ip = Request.UserHostAddress;
                pk.UserId = (int)Session["id"];
                db.productLikes.Add(pk);
                db.SaveChanges();
            }

            var products = db.products.Where(p => p.productVerifieds.Count > 0);

            if(id > 0)
            {
                ViewBag.category = db.categories.Find(id).name;
                products = products.Where(p => p.CategoryId == id || ( p.category.category2 != null && p.category.category2.id == id));
            }

            if (brand > 0)
            {
                ViewBag.brand = db.brands.Find(brand).name;
                products = products.Where(p => p.BrandId == brand);
            }

            return View(products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id, string comments = "")
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            if(comments != null && comments != "")
            {
                var pc = new comment();
                pc.Comment1 = comments;
                pc.DateTime = DateTime.Now;
                pc.Ip = Request.UserHostAddress;
                pc.ProductId = (int)id;
                pc.UserId = (int)Session["id"];
                db.comments.Add(pc);
                db.SaveChanges();
                product = db.products.Find(id);
            }

            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "Product";
                return RedirectToAction("Login", "Users");
            }
            ViewBag.BrandId = new SelectList(db.brands, "id", "name");
            ViewBag.CategoryId = new SelectList(db.categories, "id", "name");
            ViewBag.ConditionId = new SelectList(db.conditions, "Id", "Name");
            
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CategoryId,BrandId,ConditionId,UserId,RegularPrice,OfferPrice,Negotiable,Links,Video,CreateDate,Ip")] product product)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "Product";
                return RedirectToAction("Login", "Users");
            }
            product.UserId = (int)Session["id"];
            product.CreateDate = DateTime.Now;
            product.Ip = Request.UserHostAddress;

            if (ModelState.IsValid)
            {
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.brands, "id", "name", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.categories, "id", "name", product.CategoryId);
            ViewBag.ConditionId = new SelectList(db.conditions, "Id", "Name", product.ConditionId);
           
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["dv"] = "Edit";
                Session["dc"] = "Product";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.brands, "id", "name", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.categories, "id", "name", product.CategoryId);
            ViewBag.ConditionId = new SelectList(db.conditions, "Id", "Name", product.ConditionId);
            ViewBag.UserId = new SelectList(db.users, "Id", "Name", product.UserId);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CategoryId,BrandId,ConditionId,UserId,RegularPrice,OfferPrice,Negotiable,Links,Video,CreateDate,Ip")] product product)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["dv"] = "Edit";
                Session["dc"] = "Product";
                return RedirectToAction("Login", "Users");
            }
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.brands, "id", "name", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.categories, "id", "name", product.CategoryId);
            ViewBag.ConditionId = new SelectList(db.conditions, "Id", "Name", product.ConditionId);
            ViewBag.UserId = new SelectList(db.users, "Id", "Name", product.UserId);
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["dv"] = "Delete";
                Session["dc"] = "Product";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["dv"] = "DeleteConfirmed";
                Session["dc"] = "Product";
                return RedirectToAction("Login", "Users");
            }
            product product = db.products.Find(id);
            db.products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
