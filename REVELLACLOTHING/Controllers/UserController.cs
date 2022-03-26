using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using REVELLACLOTHING.Models;
using System.Threading.Tasks;
using System.Web.Security;
namespace REVELLACLOTHING.Controllers
{

    public class UserController : Controller
    {
        dbrevellaEntities dbobj = new dbrevellaEntities();
        
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tblcostumer model)
        {
            var res = dbobj.tblcostumers.Where(x => x.username.Equals(model.username)).FirstOrDefault();
            if (res == null)
            {
                if (ModelState.IsValid)
                {
                    tblcostumer obj = new tblcostumer();
                    obj.username = model.username;
                    obj.firstname = model.firstname;
                    obj.lastname = model.lastname;
                    obj.gender = model.gender;
                    obj.age = model.age;
                    obj.address = model.address;
                    obj.contact = model.contact;
                    obj.password = model.password;

                    dbobj.tblcostumers.Add(obj);
                    dbobj.SaveChanges();

                    return View("Login");
                }
                else {
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
        public ActionResult Login1(tblcostumer model)
        {
           
            var res = dbobj.tblcostumers.Where(a => a.username.Equals(model.username) && a.password.Equals(model.password)).FirstOrDefault();
            if (res != null)
            {
                FormsAuthentication.SetAuthCookie(model.username, false);
                return View("Shop");
                
            }
            else
            {
                ViewBag.Message = String.Format("Wrong Username or Password");
                return View("Login");
            }
            
           
        }
            [Authorize]
        public ActionResult Shop()
        {
            
            return View();
        }

        public ActionResult Child() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Child1(tblitem model)
        {
            tblitem obj = new tblitem();
            obj.category = "Children";
            obj.item = "item1";
            obj.status = "cart";
            obj.price = "100";
            obj.uid = User.Identity.Name;

            dbobj.tblitems.Add(obj);
            dbobj.SaveChanges();

            return View("Child");
        }
        [HttpPost]
        public ActionResult Child2(tblitem model)
        {
            tblitem obj = new tblitem();
            obj.category = "Children";
            obj.item = "item2";
            obj.status = "cart";
            obj.price = "100";
            obj.uid = User.Identity.Name;

            dbobj.tblitems.Add(obj);
            dbobj.SaveChanges();

            return View("Child");
        }
        [HttpPost]
        public ActionResult Child3(tblitem model)
        {
            tblitem obj = new tblitem();
            obj.category = "Children";
            obj.item = "item3";
            obj.status = "cart";
            obj.price = "100";
            obj.uid = User.Identity.Name;

            dbobj.tblitems.Add(obj);
            dbobj.SaveChanges();

            return View("Child");
        }
        [HttpPost]
        public ActionResult Child4(tblitem model)
        {
            tblitem obj = new tblitem();
            obj.category = "Children";
            obj.item = "item4";
            obj.status = "cart";
            obj.price = "100";
            obj.uid = User.Identity.Name;

            dbobj.tblitems.Add(obj);
            dbobj.SaveChanges();

            return View("Child");
        }
  
        public ActionResult Men()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Men1()
        {
            tblitem obj = new tblitem();
            obj.category = "Men";
            obj.item = "item1";
            obj.status = "cart";
            obj.price = "150";
            obj.uid = User.Identity.Name;

            dbobj.tblitems.Add(obj);
            dbobj.SaveChanges();
            return View("Men");
        }
        [HttpPost]
        public ActionResult Men2()
        {
            tblitem obj = new tblitem();
            obj.category = "Men";
            obj.item = "item2";
            obj.status = "cart";
            obj.price = "150";
            obj.uid = User.Identity.Name;

            dbobj.tblitems.Add(obj);
            dbobj.SaveChanges();
            return View("Men");
        }
        [HttpPost]
        public ActionResult Men3()
        {
            tblitem obj = new tblitem();
            obj.category = "Men";
            obj.item = "item3";
            obj.status = "cart";
            obj.price = "150";
            obj.uid = User.Identity.Name;

            dbobj.tblitems.Add(obj);
            dbobj.SaveChanges();
            return View("Men");
        }
        [HttpPost]
        public ActionResult Men4()
        {
            tblitem obj = new tblitem();
            obj.category = "Men";
            obj.item = "item4";
            obj.status = "cart";
            obj.price = "150";
            obj.uid = User.Identity.Name;

            dbobj.tblitems.Add(obj);
            dbobj.SaveChanges();
            return View("Men");
        }

        public ActionResult Women()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Women1()
        {
            tblitem obj = new tblitem();
            obj.category = "Women";
            obj.item = "item1";
            obj.status = "cart";
            obj.price = "150";
            obj.uid = User.Identity.Name;

            dbobj.tblitems.Add(obj);
            dbobj.SaveChanges();
            return View("Women");
        }
        [HttpPost]
        public ActionResult Women2()
        {
            tblitem obj = new tblitem();
            obj.category = "Women";
            obj.item = "item2";
            obj.status = "cart";
            obj.price = "150";
            obj.uid = User.Identity.Name;

            dbobj.tblitems.Add(obj);
            dbobj.SaveChanges();
            return View("Women");
        }
        [HttpPost]
        public ActionResult Women3()
        {
            tblitem obj = new tblitem();
            obj.category = "Women";
            obj.item = "item3";
            obj.status = "cart";
            obj.price = "150";
            obj.uid = User.Identity.Name;

            dbobj.tblitems.Add(obj);
            dbobj.SaveChanges();
            return View("Women");
        }
        [HttpPost]
        public ActionResult Women4()
        {
            tblitem obj = new tblitem();
            obj.category = "Women";
            obj.item = "item4";
            obj.status = "cart";
            obj.price = "150";
            obj.uid = User.Identity.Name;

            dbobj.tblitems.Add(obj);
            dbobj.SaveChanges();
            return View("Women");
        }

        public ActionResult Cart()
        {
            var list = dbobj.tblitems.Where(a => a.uid.Equals(User.Identity.Name)).ToList();
            return View("Cart", list);
        }

        public ActionResult Delete(int id)
        {
           
            var res = dbobj.tblitems.Where(x => x.id == id).First();
            if (res != null)
            {
                dbobj.tblitems.Remove(res);
                dbobj.SaveChanges();
            }


            var list = dbobj.tblitems.Where(a => a.uid.Equals(User.Identity.Name)).ToList();

            return View("Cart", list);
        }
        public ActionResult Out(int id)
        {

            var res = dbobj.tblitems.Find(id);
            if (res != null)
            {
                dbobj.tblitems.Remove(res);
                dbobj.SaveChanges();

                tblitem obj = new tblitem();
                obj.category = res.category;
                obj.item = res.item;
                obj.status = "Checked-Out";
                obj.price = res.price;
                obj.uid = User.Identity.Name;

                dbobj.tblitems.Add(obj);
                dbobj.SaveChanges();
            }
        
            var list = dbobj.tblitems.Where(a => a.uid.Equals(User.Identity.Name)).ToList();

            return View("Cart", list);
        }
    }

    
}