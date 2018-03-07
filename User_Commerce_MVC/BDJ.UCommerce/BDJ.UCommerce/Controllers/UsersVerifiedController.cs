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
    public class UsersVerifiedController : Controller
    {
        private bdjUCommerceEntities db = new bdjUCommerceEntities();

        // GET: UsersVerified
        public ActionResult Index()
        {
            var userVerifieds = db.userVerifieds;
            return View(userVerifieds.ToList());
        }

        // GET: UsersVerified/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userVerified userVerified = db.userVerifieds.Find(id);
            if (userVerified == null)
            {
                return HttpNotFound();
            }
            return View(userVerified);
        }

        // GET: UsersVerified/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.vwNonVerifiedUsers, "Id", "Name");
            return View();
        }

        // POST: UsersVerified/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,DateTime,Ip")] userVerified userVerified)
        {
            if (ModelState.IsValid)
            {
                db.userVerifieds.Add(userVerified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.vwNonVerifiedUsers, "Id", "Name", userVerified.UserId);
            return View(userVerified);
        }

        // GET: UsersVerified/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userVerified userVerified = db.userVerifieds.Find(id);
            if (userVerified == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.users, "Id", "Name", userVerified.UserId);
            return View(userVerified);
        }

        // POST: UsersVerified/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,DateTime,Ip")] userVerified userVerified)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userVerified).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.users, "Id", "Name", userVerified.UserId);
            return View(userVerified);
        }

        // GET: UsersVerified/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userVerified userVerified = db.userVerifieds.Find(id);
            if (userVerified == null)
            {
                return HttpNotFound();
            }
            return View(userVerified);
        }

        // POST: UsersVerified/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userVerified userVerified = db.userVerifieds.Find(id);
            db.userVerifieds.Remove(userVerified);
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
