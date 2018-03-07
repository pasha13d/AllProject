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
    public class UsersAdminController : Controller
    {
        private bdjUCommerceEntities db = new bdjUCommerceEntities();

        // GET: UsersAdmin
        public ActionResult Index()
        {
            var adminUsers = db.adminUsers.Include(a => a.user);
            return View(adminUsers.ToList());
        }

        // GET: UsersAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adminUser adminUser = db.adminUsers.Find(id);
            if (adminUser == null)
            {
                return HttpNotFound();
            }
            return View(adminUser);
        }

        // GET: UsersAdmin/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.users.Where(usr=>usr.adminUser == null), "Id", "Name");
            return View();
        }

        // POST: UsersAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId")] adminUser adminUser)
        {
            if (ModelState.IsValid)
            {
                db.adminUsers.Add(adminUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.users.Where(usr=>usr.adminUser == null), "Id", "Name", adminUser.UserId);
            return View(adminUser);
        }

        // GET: UsersAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adminUser adminUser = db.adminUsers.Find(id);
            if (adminUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.users, "Id", "Name", adminUser.UserId);
            return View(adminUser);
        }

        // POST: UsersAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId")] adminUser adminUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.users, "Id", "Name", adminUser.UserId);
            return View(adminUser);
        }

        // GET: UsersAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adminUser adminUser = db.adminUsers.Find(id);
            if (adminUser == null)
            {
                return HttpNotFound();
            }
            return View(adminUser);
        }

        // POST: UsersAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            adminUser adminUser = db.adminUsers.Find(id);
            db.adminUsers.Remove(adminUser);
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
