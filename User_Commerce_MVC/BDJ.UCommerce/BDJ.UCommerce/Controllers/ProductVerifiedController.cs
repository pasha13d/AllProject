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
    public class ProductVerifiedController : Controller
    {
        private bdjUCommerceEntities db = new bdjUCommerceEntities();

        // GET: ProductVerified
        public ActionResult Index()
        {
            var productVerifieds = db.productVerifieds.Include(p => p.adminUser).Include(p => p.product);
            return View(productVerifieds.ToList());
        }

        // GET: ProductVerified/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productVerified productVerified = db.productVerifieds.Find(id);
            if (productVerified == null)
            {
                return HttpNotFound();
            }
            return View(productVerified);
        }

        // GET: ProductVerified/Create
        public ActionResult Create()
        {
            
            ViewBag.ProductId = new SelectList(db.products.Where(p=>p.productVerifieds.Count() <= 0), "Id", "Name");
            return View();
        }

        // POST: ProductVerified/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ProductId,AdminUserId,DateTime,Ip")] productVerified productVerified)
        {

            productVerified.Ip = Request.UserHostAddress;
            productVerified.AdminUserId = (int)Session["id"];
            productVerified.DateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.productVerifieds.Add(productVerified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.products.Where(p => p.productVerifieds.Count() <= 0), "Id", "Name");
            return View(productVerified);
        }

        // GET: ProductVerified/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productVerified productVerified = db.productVerifieds.Find(id);
            if (productVerified == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdminUserId = new SelectList(db.adminUsers, "UserId", "UserId", productVerified.AdminUserId);
            ViewBag.ProductId = new SelectList(db.products, "Id", "Name", productVerified.ProductId);
            return View(productVerified);
        }

        // POST: ProductVerified/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ProductId,AdminUserId,DateTime,Ip")] productVerified productVerified)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productVerified).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdminUserId = new SelectList(db.adminUsers, "UserId", "UserId", productVerified.AdminUserId);
            ViewBag.ProductId = new SelectList(db.products, "Id", "Name", productVerified.ProductId);
            return View(productVerified);
        }

        // GET: ProductVerified/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productVerified productVerified = db.productVerifieds.Find(id);
            if (productVerified == null)
            {
                return HttpNotFound();
            }
            return View(productVerified);
        }

        // POST: ProductVerified/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productVerified productVerified = db.productVerifieds.Find(id);
            db.productVerifieds.Remove(productVerified);
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
