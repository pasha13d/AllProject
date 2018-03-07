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
    public class MessageController : Controller
    {
        private bdjUCommerceEntities db = new bdjUCommerceEntities();

        // GET: Message
        public ActionResult Index()
        {
            var messages = db.messages.Include(m => m.product).Include(m => m.user);
            return View(messages.ToList());
        }

        public string CloseProduct(int product = 0, int ClosingTypeId = 0)
        {
            if (ClosingTypeId > 0 && product > 0)
            {
                Models.productClosed pcl = new productClosed();
                //pcl.closeType = new closeType() {  }
                pcl.ClosingTypeId = ClosingTypeId;
                pcl.DateTime = DateTime.Now;
                pcl.ProductId = product;
                db.productCloseds.Add(pcl);
                db.SaveChanges();
                return "OK";
            }
            return "Not OK";
        }

        public string MakeComments(int product = 0, string comments = "")
        {
            if (!string.IsNullOrEmpty(comments) && product > 0)
            {
                Models.message msg = new Models.message();
                msg.DateTime = DateTime.Now;
                msg.Ip = Request.UserHostAddress;
                msg.message1 = comments;
                msg.ProductId = product;
                msg.UserId = (int)Session["id"];
                db.messages.Add(msg);
                db.SaveChanges();
                return "OK";
            }

            return "Error Occured " + product.ToString() + ", " + comments;
        }

        public ActionResult Dasboard(string messageData = "", int product = 0, int ClosingTypeId = 0)
        {
            if(ClosingTypeId > 0)
            {
                Models.productClosed pcl = new productClosed();
                //pcl.closeType = new closeType() {  }
                pcl.ClosingTypeId = ClosingTypeId;
                pcl.DateTime = DateTime.Now;
                pcl.ProductId = product;
                db.productCloseds.Add(pcl);
                db.SaveChanges();
            }

            if(!string.IsNullOrEmpty(messageData) && product > 0)
            {
                Models.message msg = new Models.message();
                msg.DateTime = DateTime.Now;
                msg.Ip = Request.UserHostAddress;
                msg.message1 = messageData;
                msg.ProductId = product;
                msg.UserId = (int)Session["id"];
                db.messages.Add(msg);
                db.SaveChanges();
            }

            int uid = (int)Session["id"];

            var messages = db.messages.Where(m => m.UserId == uid || m.product.UserId == uid);

            List<message> uniqueByProduct = new List<message>();

            foreach(var msg in messages)
            {
                if( uniqueByProduct.Where(ubp=>ubp.ProductId == msg.ProductId).Count() <= 0)
                {
                    uniqueByProduct.Add(msg);
                }
            }


            return View(uniqueByProduct.ToList());
        }

        // GET: Message/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            message message = db.messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.products, "Id", "Name");
            ViewBag.UserId = new SelectList(db.users, "Id", "Name");
            return View();
        }

        // POST: Message/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,UserId,DateTime,Ip,message1")] message message)
        {
            if (ModelState.IsValid)
            {
                db.messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.products, "Id", "Name", message.ProductId);
            ViewBag.UserId = new SelectList(db.users, "Id", "Name", message.UserId);
            return View(message);
        }

        // GET: Message/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            message message = db.messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.products, "Id", "Name", message.ProductId);
            ViewBag.UserId = new SelectList(db.users, "Id", "Name", message.UserId);
            return View(message);
        }

        // POST: Message/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,UserId,DateTime,Ip,message1")] message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.products, "Id", "Name", message.ProductId);
            ViewBag.UserId = new SelectList(db.users, "Id", "Name", message.UserId);
            return View(message);
        }

        // GET: Message/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            message message = db.messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            message message = db.messages.Find(id);
            db.messages.Remove(message);
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
