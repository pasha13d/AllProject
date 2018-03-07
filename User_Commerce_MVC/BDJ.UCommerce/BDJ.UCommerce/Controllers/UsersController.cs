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
    public class UsersController : Controller
    {
        private bdjUCommerceEntities db = new bdjUCommerceEntities();

        // GET: Users

            
        public ActionResult Index()
        {
            if(Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["dv"] = "Index";
                Session["dc"] = "Users";
                return RedirectToAction("Login");
            }

            var users = db.users.Include(u => u.adminUser).Include(u => u.city);
            return View(users.ToList());
        }

        public ActionResult MyAccount()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.LoginModel loginModel)
        {
            if(ModelState.IsValid)
            {
                var usr = db.users.Where(u=>u.Email.ToLower() == loginModel.Email.ToLower() && u.Password == loginModel.Password).First();
                if(usr == null)
                {
                    ViewBag.error = "Invalid Login";
                }
                else if(usr.adminUser == null)
                {
                    ViewBag.error = "You have to login with admin account";
                }
                else
                {
                    Session["id"] = usr.Id;
                    Session["name"] = usr.Name;
                    Session["type"] = "Admin";
                    //system default identity set
                    //IsAuthorize Property true  

                    if (Session["dv"] == null || Session["dv"].ToString() == "")
                    {

                        return RedirectToAction("Index", "Home");
                    }
                    return RedirectToAction(Session["dv"].ToString(), Session["dc"].ToString());
                }
            }
            return View(loginModel);
        }


        public ActionResult Logout()
        {
            Session["id"] = "";
            Session["name"] = "";
            Session["type"] = "";
            return View();
        }

        public ActionResult LoginPublic()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginPublic(Models.LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var usr = db.users.Where(u => u.Email.ToLower() == loginModel.Email.ToLower() && u.Password == loginModel.Password).First();
                if (usr == null)
                {
                    ViewBag.error = "Invalid Login";
                }
                else if (usr.userVerifieds.Count <= 0)
                {
                    ViewBag.error = "You have to verify your account. check your email that you have given during registration. If you have not received the email <a href=\"../Users/Verify?id="+ usr.Id.ToString() +"\">click here</a> to verify your account";
                }

                else
                {
                    Session["id"] = usr.Id;
                    Session["name"] = usr.Name;

                    if(usr.adminUser != null)
                    {
                        Session["type"] = "Admin";
                    }
                    else
                    {
                        Session["type"] = "User";
                    }

                    if (Session["dv"] == null || Session["dv"].ToString() == "")
                    {

                        return RedirectToAction("Index", "Home");
                    }
                    return RedirectToAction(Session["dv"].ToString(), Session["dc"].ToString());
                }
            }
            return View(loginModel);
        }


        public ActionResult LogoutPublic()
        {
            Session["id"] = "";
            Session["name"] = "";
            Session["type"] = "";
            return View();
        }

        public ActionResult Verification(int id = 0)
        {
            if (id == 0)
                return HttpNotFound();

            var usr = db.users.Find(id);

            if (usr == null)
                return HttpNotFound();

            userVerified usrV = new Models.userVerified();
            usrV.DateTime = DateTime.Now;
            usrV.Ip = Request.UserHostAddress;
            usrV.UserId = id;

            db.userVerifieds.Add(usrV);

            db.SaveChanges();

            ViewBag.message = "Your account is verified now. you can <a href=\"../Users/LoginPublic\">login</a> now";

            return View(usr);
        }

        public ActionResult Verify(int id = 0)
        {
            if (id == 0)
                return HttpNotFound();

            var usr = db.users.Find(id);

            if (usr == null)
                return HttpNotFound();

            return View(usr);
        }

        [HttpPost]
        public ActionResult Verify(string email = "")
        {
            var usr = db.users.Where(u => u.Email == email).First();

            if(usr == null)
            {
                ViewBag.error = "Your email is not int our system. pleage <a href=\"../Users/Register\">register</a>";
            }
            else
            {
                string message = "Dear " + usr.Name + "\n<br>";
                message += "Please click the this <a href=\"../Users/Verification?id="+ usr.Id +"\">verify link to verify your account";

                //send the message to usr.Email address

                ViewBag.message = message;
            }

            return View();
        }


        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult RegisterSuccess()
        {
           
            return View();
        }

        public ActionResult Register()
        {
            ViewBag.CityId = new SelectList(db.cities, "id", "name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(user user ,HttpPostedFileBase Image, string retype = "")
        {
           
            user.Image = System.IO.Path.GetFileName(Image.FileName);
            user.Ip = Request.UserHostAddress;
            user.JoinDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                if(retype == "" || retype != user.Password)
                {
                    ViewBag.eretype = "Re type password or password missmatch";
                    ViewBag.CityId = new SelectList(db.cities, "id", "name");
                    return View(user);
                }

                db.users.Add(user);
                db.SaveChanges();

                Image.SaveAs(Server.MapPath("../uploads/usersImages/" + user.Id.ToString() + "_" + user.Image));

                return RedirectToAction("RegisterSuccess");
            }
            ViewBag.CityId = new SelectList(db.cities, "id", "name", user.CityId);
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {

            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "Users";
                return RedirectToAction("Login");
            }

            ViewBag.Id = new SelectList(db.adminUsers, "UserId", "UserId");
            ViewBag.CityId = new SelectList(db.cities, "id", "name");
            
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(user user, HttpPostedFileBase Image)
        {
            if(Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "Users";
                return RedirectToAction("Login");
            }
            user.Image = System.IO.Path.GetFileName(Image.FileName);
            user.Ip = Request.UserHostAddress;
            user.JoinDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();

                Image.SaveAs(Server.MapPath("../uploads/usersImages/" + user.Id.ToString() + "_" + user.Image));

                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.adminUsers, "UserId", "UserId", user.Id);
            ViewBag.CityId = new SelectList(db.cities, "id", "name", user.CityId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.adminUsers, "UserId", "UserId", user.Id);
            ViewBag.CityId = new SelectList(db.cities, "id", "name", user.CityId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Contact,Email,Password,Gender,JoinDate,Ip,DateOfBirth,Address,CityId,Image")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.adminUsers, "UserId", "UserId", user.Id);
            ViewBag.CityId = new SelectList(db.cities, "id", "name", user.CityId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
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
