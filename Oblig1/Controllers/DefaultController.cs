using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Oblig1.Models;

namespace Oblig1.Controllers
{
    public class DefaultController : Controller
    {
        private DataContext db = new DataContext(); // DbContext

        protected override void Dispose(bool disposing) 
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        // SIGN IN
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(UserAccount user)
        {
            // Check if account exists
            var userCheck = db.UserAccounts.Where(u => u.Username == user.Username && u.Password == user.Password && u.IsDeleted == false).FirstOrDefault();
            if (userCheck != null)
            {
                Session["UID"] = user.UID.ToString();
                Session["Username"] = user.Username.ToString();
                return RedirectToAction("Dashboard");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "");
            }
            return View();
        }

        // REGISTER 
        public ActionResult Register()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(UserAccount user)
        {
            if (ModelState.IsValid)
            {
                // Check if account exists
                var userCheck = db.UserAccounts.Where(u => u.Username == user.Username).FirstOrDefault();
                if (userCheck != null)
                {
                    ModelState.AddModelError(string.Empty, "Username already taken.");
                }
                else
                {
                    var newUser = new UserAccount()
                    {
                        Username = user.Username,
                        Password = user.Password,
                        ConfirmPassword = user.ConfirmPassword,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        DateRegistered = DateTime.UtcNow,
                        IsDeleted = false,
                        IsAdmin = false,
                    };
                    db.UserAccounts.Add(newUser);
                    db.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
                return View();
            }
            return View();
        }

        // DASHBOARD
        public ActionResult Dashboard()
        {
            var allMovies = db.Movies.ToList();
            return View(allMovies);
        }

        // BUY
        public ActionResult Buy(int id)
        {
            if (Session["UID"] != null) // Prevents access if user is not signed in
            {
                var findfilm = db.Movies.Find(id);

                if (findfilm == null)
                {
                    return View("Dashboard");
                }
                else
                {
                    // Get Session values then place them inside a Read-Only HTMLEditorFor as default value
                    Session["Title"] = findfilm.Title.ToString();
                    Session["Price"] = findfilm.Price.ToString();
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Buy(Purchases purchase)
        {
            if (ModelState.IsValid)
            {
                var newOrder = new Purchases()
                {
                    Title = purchase.Title,
                    Price = purchase.Price,
                    Username = purchase.Username,
                    DateBought = DateTime.UtcNow
                };

                using (DataContext db = new DataContext())
                {
                    db.Purchases.Add(newOrder);
                    db.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("Purchases");
            }
            return View();
        }

        // ORDERS
        public ActionResult Purchases()
        {
            if (Session["UID"] != null)
            {
                string value = Session["Username"].ToString();
                var all = db.Purchases.Where(o => o.Username == value).ToList();
                return View(all);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // ACCOUNT
        public ActionResult Account()
        {
            if (Session["UID"] != null)
            {
                string user = Session["Username"].ToString();
                var accnt = db.UserAccounts.Where(o => o.Username == user).ToList();
                return View(accnt);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // EDIT ACCOUNT
        public ActionResult EditAccount(int id)
        {
            var accnt = db.UserAccounts.Find(id);

            if (accnt == null)
            {
                return View("Account");
            }
            else
            {
                Session["UID"] = accnt.UID.ToString();
                Session["Username"] = accnt.Username.ToString();
                Session["Password"] = accnt.Password.ToString();
                Session["ConfirmPassword"] = accnt.ConfirmPassword.ToString();
                Session["FirstName"] = accnt.FirstName.ToString();
                Session["LastName"] = accnt.LastName.ToString();
                Session["Email"] = accnt.Email.ToString();
                return View();
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditAccount(int id, UserAccount edittedAcc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserAccount edited = db.UserAccounts.Find(id);
                    edited.UID = edittedAcc.UID;
                    edited.Username = edittedAcc.Username;
                    edited.Password = edittedAcc.Password;
                    edited.ConfirmPassword = edittedAcc.ConfirmPassword;
                    edited.FirstName = edittedAcc.FirstName;
                    edited.LastName = edittedAcc.LastName;
                    edited.Email = edittedAcc.Email;
                    edited.IsDeleted = false;
                    edited.IsAdmin = false;
                    db.SaveChanges();
                    return RedirectToAction("Account");
                }
                catch (Exception error)
                {

                }
            }
            return View();
        }

        // SIGN OUT
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index");
        }

        // ABOUT
        public ActionResult About()
        {
            return View();
        }

        // DELETE
        public void Delete(int id)
        {
            try
            {
                Purchases oid = db.Purchases.Find(id);
                db.Purchases.Remove(oid);
                db.SaveChanges();
            }
            catch (Exception error)
            {
                
            }
        }

        // DELETE USER
        public void DeleteUser(int id)
        {
            try
            {
                var SavedData = "AnonymousData";
                UserAccount deactivated = db.UserAccounts.Find(id);
                deactivated.Username = deactivated.Username;
                deactivated.Password = deactivated.Password;
                deactivated.ConfirmPassword = deactivated.ConfirmPassword;
                deactivated.FirstName = SavedData;
                deactivated.LastName = SavedData;
                deactivated.Email = SavedData;
                deactivated.IsDeleted = true;
                deactivated.IsAdmin = false;
                db.SaveChanges();
            }
            catch (Exception error)
            {

            }
        }
        
    }
}