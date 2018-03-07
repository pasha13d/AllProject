﻿using System;
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
    public class CloseTypeController : Controller
    {
        private bdjUCommerceEntities db = new bdjUCommerceEntities();

        // GET: CloseType
        public ActionResult Index()
        {
            return View(db.closeTypes.ToList());
        }

        // GET: CloseType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            closeType closeType = db.closeTypes.Find(id);
            if (closeType == null)
            {
                return HttpNotFound();
            }
            return View(closeType);
        }

        // GET: CloseType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CloseType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Decription")] closeType closeType)
        {
            if (ModelState.IsValid)
            {
                db.closeTypes.Add(closeType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(closeType);
        }

        // GET: CloseType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            closeType closeType = db.closeTypes.Find(id);
            if (closeType == null)
            {
                return HttpNotFound();
            }
            return View(closeType);
        }

        // POST: CloseType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Decription")] closeType closeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(closeType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(closeType);
        }

        // GET: CloseType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            closeType closeType = db.closeTypes.Find(id);
            if (closeType == null)
            {
                return HttpNotFound();
            }
            return View(closeType);
        }

        // POST: CloseType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            closeType closeType = db.closeTypes.Find(id);
            db.closeTypes.Remove(closeType);
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
