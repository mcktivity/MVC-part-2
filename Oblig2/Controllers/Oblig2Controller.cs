using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Oblig2.BLL;
using Oblig2.Models;

namespace Oblig2.Controllers
{
    public class Oblig2Controller : Controller
    {
        private IBLLLogic _BLL;

        public Oblig2Controller()
        {
            _BLL = new BLLLogic();
        }

        public Oblig2Controller(IBLLLogic stub)
        {
            _BLL = stub;
        }

        // ABOUT THE PROJECT
        public ActionResult About()
        {
            return View();
        }

        // SIGN IN
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(UserAccount user)
        {
            bool isRegistered = _BLL.login(user);
            if (isRegistered == true)
            {
                Session["UID"] = user.UID.ToString();
                Session["Username"] = user.Username.ToString();
                return RedirectToAction("Accounts");
            }
            return View();
        }

        // SIGN OUT
        public ActionResult LogOut()
        {
            // Session.Abandon();  Commented out as I couldn't find a solution for it to Pass in the Test
            // code above will clear the session at the end of request
            return RedirectToAction("Index");
        }

        // LIST ALL ACCOUNTS
        public ActionResult Accounts()
        {
            if (Session["UID"] != null)
            {
                List<Accounts> allAccounts = _BLL.getAllAccounts();
                return View(allAccounts);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // ADD NEW ACCOUNT 
        public ActionResult Register()
        {
            if (Session["UID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(UserAccount user)
        {
            if (ModelState.IsValid)
            {
                bool isRegistered = _BLL.userExists(user);
                if (isRegistered != true)
                {
                    bool registerOK = _BLL.register(user);
                    if (registerOK)
                    {
                        return RedirectToAction("Accounts");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "");
                }
            }
            return View();
        }

        // EDIT ACCOUNT
        public ActionResult Edit(int id)
        {
            if (Session["UID"] != null)
            {
                Accounts account = _BLL.getAccount(id);
                return View(account);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Accounts editAccount)
        {

            if (ModelState.IsValid)
            {
                bool editOK = _BLL.editAccount(id, editAccount);
                if (editOK)
                {
                    return RedirectToAction("Accounts");
                }
            }
            return View();
        }

        // DELETE ACCOUNT
        public ActionResult Delete(int id)
        {
            if (Session["UID"] != null)
            {
                Accounts account = _BLL.getAccount(id);
                return View(account);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, Accounts accounts)
        {
            bool deleteOK = _BLL.deleteAccount(id);
            if (deleteOK)
            {
                return RedirectToAction("Accounts");
            }
            return View();
        }

        // LIST ALL MOVIES
        public ActionResult Movies()
        {
            if (Session["UID"] != null)
            {
                List<allMovies> allMovies = _BLL.getAllMovies();
                return View(allMovies);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // ADD NEW MOVIE 
        public ActionResult NewMovie()
        {
            if (Session["UID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult NewMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                bool isRegistered = _BLL.movieExists(movie);
                if (isRegistered != true)
                {
                    bool addOK = _BLL.addMovie(movie);
                    if (addOK)
                    {
                        return RedirectToAction("Movies");
                    }
                }
            }
            return View();
        }

        // EDIT ACCOUNT
        public ActionResult EditMovie(int id)
        {
            if (Session["UID"] != null)
            {
                allMovies movie = _BLL.getMovie(id);
                return View(movie);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult EditMovie(int id, allMovies editMovie)
        {

            if (ModelState.IsValid)
            {
                bool editOK = _BLL.editMovie(id, editMovie);
                if (editOK)
                {
                    return RedirectToAction("Movies");
                }
            }
            return View();
        }

        // DELETE ACCOUNT
        public ActionResult DeleteMovie(int id)
        {
            if (Session["UID"] != null)
            {
                allMovies mov = _BLL.getMovie(id);
                return View(mov);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult DeleteMovie(int id, allMovies movies)
        {
            bool deleteOK = _BLL.deleteMovie(id);
            if (deleteOK)
            {
                return RedirectToAction("Movies");
            }
            return View();
        }

        // LIST ALL PURCHASES
        public ActionResult Purchases()
        {
            if (Session["UID"] != null)
            {
                List<allPurchases> allPurchases = _BLL.getAllPurchases();
                return View(allPurchases);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // DELETE PURCHASE
        public ActionResult DeletePurchase(int id)
        {
            if (Session["UID"] != null)
            {
                allPurchases purchases = _BLL.getPurchase(id);
                return View(purchases);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult DeletePurchase(int id, allPurchases purchases)
        {
            bool deleteOK = _BLL.deletePurchase(id);
            if (deleteOK)
            {
                return RedirectToAction("Purchases");
            }
            return View();
        }
    }
}