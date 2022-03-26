using REVELLACLOTHING.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace REVELLACLOTHING.Controllers
{
    
    public class AdminController : Controller
    {
        dbrevellaEntities dbobj = new dbrevellaEntities();
        public ActionResult Home()
        {
            FormsAuthentication.SignOut();
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tbladmin model)
        {
            var res = dbobj.tblcostumers.Where(x => x.username.Equals(model.username)).FirstOrDefault();
            if (res == null)
            {
                if (ModelState.IsValid)
                {
                    tbladmin obj = new tbladmin();
                    obj.username = model.username;
                    obj.firstname = model.firstname;
                    obj.lastname = model.lastname;
                    obj.address = model.address;
                    obj.contact = model.contact;
                    obj.password = model.password;

                    dbobj.tbladmins.Add(obj);
                    dbobj.SaveChanges();

                    ModelState.Clear();

                    return View("Login");

                }
                else
                {
                    return View("Register");
                }
            }
            else
            {
                ViewBag.Message = String.Format("Invalid Username");
                return View("Register");
            }
        }
           public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
           public ActionResult Login1(tbladmin model)
        {
           
            var res = dbobj.tbladmins.Where(a => a.username.Equals(model.username) && a.password.Equals(model.password)).FirstOrDefault();
            if (res != null)
            {
                FormsAuthentication.SetAuthCookie(model.username, false);
                var list = dbobj.tblitems.Where(a => a.status.Equals("Checked-Out")).ToList();
                return View("Order", list);  
                
            }
            else
            {
                ViewBag.Message = String.Format("Wrong Username or Password");
                return View("Login");
            }
            
           
        }
        [Authorize]
        public ActionResult Order()
        {
            
            var list = dbobj.tblitems.Where(a => a.status.Equals("Checked-Out")).ToList();
            return View("Order", list);     
        }

        public ActionResult Sold(int id)
        {

            var res = dbobj.tblitems.Find(id);
            if (res != null)
            {
                dbobj.tblitems.Remove(res);
                dbobj.SaveChanges();

                tblitem obj = new tblitem();
                obj.category = res.category;
                obj.item = res.item;
                obj.status = "Sold-Out";
                obj.price = res.price;
                obj.uid = res.uid;

                dbobj.tblitems.Add(obj);
                dbobj.SaveChanges();
            }

            var list = dbobj.tblitems.Where(a => a.status.Equals("Checked-Out")).ToList();

            return View("Order", list);
        }

        public ActionResult Confirm(int id)
        {

            var res = dbobj.tblitems.Find(id);
            if (res != null)
            {
                dbobj.tblitems.Remove(res);
                dbobj.SaveChanges();

                tblitem obj = new tblitem();
                obj.category = res.category;
                obj.item = res.item;
                obj.status = "Confirm";
                obj.price = res.price;
                obj.uid = res.uid;

                dbobj.tblitems.Add(obj);
                dbobj.SaveChanges();
            }

            var list = dbobj.tblitems.Where(a => a.status.Equals("Checked-Out")).ToList();

            return View("Order", list);
        }
        public ActionResult Customer()
        {
            var list = dbobj.tblcostumers.ToList();
            return View("Customer",list);
        }

        public ActionResult Info(string view)
        {
            var list = dbobj.tblcostumers.Where(a => a.username.Equals(view)).ToList();
            return View("Customer", list);
        }

        public ActionResult Deliver()
        {
              var list = dbobj.tblitems.Where(a => a.status.Equals("Confirm")).ToList();

            return View("Deliver", list);
        }

        public ActionResult Delete(int id)
        {
            var res = dbobj.tblitems.Where(x => x.id == id).First();
            if (res != null)
            {
                dbobj.tblitems.Remove(res);
                dbobj.SaveChanges();
            }


            var list = dbobj.tblitems.Where(a => a.status.Equals("Confirm")).ToList();

            return View("Deliver", list);
        }
    }
}