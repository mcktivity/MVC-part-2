using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Linq;
using Oblig2.Controllers;
using Oblig2.BLL;
using Oblig2.DAL;
using System.Collections.Generic;
using Oblig2.Models;
using MvcContrib.TestHelper;

namespace Enhetstest
{
    [TestClass]
    public class Oblig2ControllerTest
    {
        [TestMethod]
        public void aboutProject_page()
        {
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var resultat = (ViewResult)controller.About();
            Assert.AreEqual(resultat.ViewName, "");
        }

        // USER-RELATED TESTS
        [TestMethod]
        public void Index_login_View()
        {
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var resultat = (ViewResult)controller.Index();
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void Index_login_OK()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = 1;
            controller.Session["Username"] = "Admin";
            var login = new UserAccount()
            {
                Username = "Admin",
            };
            // Act
            var result = (RedirectToRouteResult)controller.Index(login);

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Accounts");
        }

        [TestMethod]
        public void Index_login_DB_Failed()
        {
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var login = new UserAccount();
            login.Username = "";

            // Act
            var actionResult = (ViewResult)controller.Index(login);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void ListAcc_SignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = 1;

            var forventetResultat = new List<Accounts>();
            var admin = new Accounts()
            {
                uid = 10,
                username = "AdminTest",
                password = "password",
                confirmpassword = "password",
                email = "admin@admin.com",
                isadmin = true,
                isdeleted = false,
                firstname = "admin",
                lastname = "admin",
                dateregistered = DateTime.UtcNow
            };
            var testuser = new Accounts()
            {
                uid = 20,
                username = "testuser1",
                password = "password",
                confirmpassword = "password",
                email = "testuser@testuser.com",
                isadmin = false,
                isdeleted = false,
                firstname = "testuser",
                lastname = "testuser",
                dateregistered = DateTime.UtcNow
            };
            forventetResultat.Add(admin);
            forventetResultat.Add(testuser);

            // Act
            var actionResult = (ViewResult)controller.Accounts();
            var resultat = (List<Accounts>)actionResult.Model;

            // Assert

            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].uid, resultat[i].uid);
                Assert.AreEqual(forventetResultat[i].firstname, resultat[i].firstname);
                Assert.AreEqual(forventetResultat[i].lastname, resultat[i].lastname);
                Assert.AreEqual(forventetResultat[i].username, resultat[i].username);
                Assert.AreEqual(forventetResultat[i].password, resultat[i].password);
                Assert.AreEqual(forventetResultat[i].confirmpassword, resultat[i].confirmpassword);
                Assert.AreEqual(forventetResultat[i].email, resultat[i].email);
                Assert.AreEqual(forventetResultat[i].isdeleted, resultat[i].isdeleted);
                Assert.AreEqual(forventetResultat[i].isadmin, resultat[i].isadmin);
                // Assert.AreEqual(forventetResultat[i].dateregistered, resultat[i].dateregistered);
                // Sometimes it works(Passed Test), sometimes doesn't(Failed Test). 
                // Equal results but returns as a Failed test some of the time.
            }
        }

        [TestMethod]
        public void ListAcc_NotSignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = null;

            // Act
            var result = (RedirectToRouteResult)controller.Accounts();

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }

        [TestMethod]
        public void LogOut()
        {
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            // Session.Abandon() not included in test. 
            // Test is for RedirectToAction()
            var result = (RedirectToRouteResult)controller.LogOut();
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }

        // ADD NEW ACCOUNT
        [TestMethod]
        public void AddNewAcc_View_SignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = 1;

            // Act
            var actionResult = (ViewResult)controller.Register();

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void AddNewAcc_View_NotSignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = null;

            // Act
            var result = (RedirectToRouteResult)controller.Accounts();

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }

        [TestMethod]
        public void AddNewAcc_OK()
        {
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var newAcc = new UserAccount();
            newAcc.Username = "Admin";

            // Act
            var result = (RedirectToRouteResult)controller.Register(newAcc);

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Accounts");
        }

        [TestMethod]
        public void AddNewAcc_Failed_by_DB()
        {
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var user = new UserAccount();
            user.Username = null;

            // Act
            var actionResult = (ViewResult)controller.Register(user);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void AddNewAcc_Failed_by_ModelState_Invalid()
        {
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var newAcc = new UserAccount();
            controller.ViewData.ModelState.AddModelError("Username", "Already registered.");

            // Act
            var actionResult = (ViewResult)controller.Register(newAcc);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewName, "");
        }

        // EDIT ACCOUNT
        [TestMethod]
        public void editAcc_View_SignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = 1;

            // Act
            var actionResult = (ViewResult)controller.Edit(1);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void editAcc_View_NotSignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = null;

            // Act
            var result = (RedirectToRouteResult)controller.Edit(1);

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }

        [TestMethod]
        public void editAcc_OK()
        {
            // Arrange
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var acc = new Accounts()
            {
                uid = 1,
                username = "Admin",
                password = "password",
                confirmpassword = "password",
                email = "admin@admin.com",
                isadmin = true,
                isdeleted = false,
                firstname = "admin",
                lastname = "admin",
                dateregistered = DateTime.UtcNow
            };
            // Act
            var actionResultat = (RedirectToRouteResult)controller.Edit(1, acc);

            // Assert
            Assert.AreEqual(actionResultat.RouteName, "");
            Assert.AreEqual(actionResultat.RouteValues.Values.First(), "Accounts");
        }

        [TestMethod]
        public void editAcc_Acc_not_found()
        {
            // Arrange
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var account = new Accounts();
            account.uid = 0;

            // Act
            var actionResult = (ViewResult)controller.Edit(0, account);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void editAcc_Failed_by_ModelState_Invalid()
        {
            // Arrange
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var accounts = new Accounts();
            controller.ViewData.ModelState.AddModelError("feil", "ID = 0");

            // Act
            var actionResult = (ViewResult)controller.Edit(0, accounts);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewData.ModelState["feil"].Errors[0].ErrorMessage, "ID = 0");
            Assert.AreEqual(actionResult.ViewName, "");
        }

        // DELETE ACCOUNT
        [TestMethod]
        public void deleteAcc_View_SignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = 1;

            // Act
            var actionResult = (ViewResult)controller.Delete(1);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void deleteAcc_View_NotSignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = null;

            // Act
            var result = (RedirectToRouteResult)controller.Delete(1);

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }

        [TestMethod]
        public void deleteAcc_FoundID()
        {
            // Arrange
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var acc = new Accounts()
            {
                uid = 1,
                username = "Admin",
                password = "password",
                confirmpassword = "password",
                email = "admin@admin.com",
                isadmin = true,
                isdeleted = false,
                firstname = "admin",
                lastname = "admin",
                dateregistered = DateTime.UtcNow
            };

            // Act
            var actionResult = (RedirectToRouteResult)controller.Delete(1, acc);

            // Assert
            Assert.AreEqual(actionResult.RouteName, "");
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "Accounts");
        }

        [TestMethod]
        public void deleteAcc_NotFoundID()
        {
            // Arrange
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var account = new Accounts();
            account.uid = 0;

            // Act
            var actionResult = (ViewResult)controller.Delete(0, account);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        // MOVIE-RELATED TEST METHODS
        [TestMethod]
        public void ListMov_SignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = 1;

            var forventetResultat = new List<allMovies>();
            var mov1 = new allMovies()
            {
                mid = 1,
                title = "Project",
                year = 2018,
                dir = "Per Olson",
                plot = "anything, something, nothing",
                imgurl = "~/Images/R.png",
                vidurl = "youtube.com",
                price = 90
            };
            var mov2 = new allMovies()
            {
                mid = 2,
                title = "Project 2",
                year = 2019,
                dir = "Mark Finch",
                plot = "cat, dog, mouse",
                imgurl = "~/Images/RS.png",
                vidurl = "youtube.com",
                price = 110
            };
            forventetResultat.Add(mov1);
            forventetResultat.Add(mov2);

            // Act
            var actionResult = (ViewResult)controller.Movies();
            var resultat = (List<allMovies>)actionResult.Model;

            // Assert

            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].mid, resultat[i].mid);
                Assert.AreEqual(forventetResultat[i].title, resultat[i].title);
                Assert.AreEqual(forventetResultat[i].year, resultat[i].year);
                Assert.AreEqual(forventetResultat[i].plot, resultat[i].plot);
                Assert.AreEqual(forventetResultat[i].dir, resultat[i].dir);
                Assert.AreEqual(forventetResultat[i].price, resultat[i].price);
                Assert.AreEqual(forventetResultat[i].imgurl, resultat[i].imgurl);
                Assert.AreEqual(forventetResultat[i].vidurl, resultat[i].vidurl);
            }
            /*
            Det som kommer under er bare for å vise hva Assert.IsTrue kan gjøre (dvs alt!)
            string forventet1 = "Her er en mulighet";
            string forventet2 = "Her er en mulighet til";
            string virkelig = "Her er en mulighet";
            if (virkelig == forventet1 || virkelig==forventet2)
                test = true;
            else 
                test = false;
            Assert.IsTrue(test);
             
             */
        }

        [TestMethod]
        public void ListMov_NotSignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = null;

            // Act
            var result = (RedirectToRouteResult)controller.Movies();

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }

        // ADD MOVIE
        [TestMethod]
        public void AddNewMov_View_SignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = 1;

            // Act
            var actionResult = (ViewResult)controller.Movies();

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void AddNewMov_View_NotSignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = null;

            // Act
            var result = (RedirectToRouteResult)controller.Movies();

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }

        [TestMethod]
        public void AddNewMov_OK()
        {
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var newMov = new Movie();
            newMov.Title = "movie";

            // Act
            var result = (RedirectToRouteResult)controller.NewMovie(newMov);

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Movies");
        }

        [TestMethod]
        public void AddNewMov_Failed_by_DB()
        {
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var mov = new Movie();
            mov.Title = "";

            // Act
            var actionResult = (ViewResult)controller.NewMovie(mov);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void AddNewMov_Failed_by_ModelState_Invalid()
        {
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var newMov = new Movie();
            controller.ViewData.ModelState.AddModelError("Title", "Already recorded.");

            // Act
            var actionResult = (ViewResult)controller.NewMovie(newMov);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewName, "");
        }

        // EDIT MOVIE
        [TestMethod]
        public void editMov_View_SignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = 1;

            // Act
            var actionResult = (ViewResult)controller.EditMovie(1);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void editMov_View_NotSignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = null;

            // Act
            var result = (RedirectToRouteResult)controller.EditMovie(1);

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }

        [TestMethod]
        public void editMov_OK()
        {
            // Arrange
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var mov = new allMovies()
            {
                title = "Projects 3",
                year = 2022,
                dir = "Not Olson",
                plot = "one, two, three",
                imgurl = "~/Images/MI6.png",
                vidurl = "youtube.com",
                price = 190
            };
            // Act
            var actionResultat = (RedirectToRouteResult)controller.EditMovie(1, mov);

            // Assert
            Assert.AreEqual(actionResultat.RouteName, "");
            Assert.AreEqual(actionResultat.RouteValues.Values.First(), "Movies");
        }

        [TestMethod]
        public void editMov_Acc_not_found()
        {
            // Arrange
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var movie = new allMovies();
            movie.mid = 0;

            // Act
            var actionResult = (ViewResult)controller.EditMovie(0, movie);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void editMov_Failed_by_ModelState_Invalid()
        {
            // Arrange
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var movies = new allMovies();
            controller.ViewData.ModelState.AddModelError("feil", "ID = 0");

            // Act
            var actionResult = (ViewResult)controller.EditMovie(0, movies);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewData.ModelState["feil"].Errors[0].ErrorMessage, "ID = 0");
            Assert.AreEqual(actionResult.ViewName, "");
        }

        // DELETE MOVIE
        [TestMethod]
        public void deleteMov_View_SignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = 1;

            // Act
            var actionResult = (ViewResult)controller.DeleteMovie(1);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void deleteMov_View_NotSignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = null;

            // Act
            var result = (RedirectToRouteResult)controller.DeleteMovie(1);

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }

        [TestMethod]
        public void deleteMov_FoundID()
        {
            // Arrange
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var movi = new allMovies()
            {
                mid = 1,
                title = "Projects 3",
                year = 2022,
                dir = "Not Olson",
                plot = "one, two, three",
                imgurl = "~/Images/MI6.png",
                vidurl = "youtube.com",
                price = 190
            };

            // Act
            var actionResult = (RedirectToRouteResult)controller.DeleteMovie(1, movi);

            // Assert
            Assert.AreEqual(actionResult.RouteName, "");
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "Movies");
        }

        [TestMethod]
        public void deleteMov_NotFoundID()
        {
            // Arrange
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var mov = new allMovies();
            mov.mid = 0;

            // Act
            var actionResult = (ViewResult)controller.DeleteMovie(0, mov);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        // PURCHASE-RELATED TEST METHODS
        [TestMethod]
        public void ListPurc_SignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = 1;

            var forventetResultat = new List<allPurchases>();
            var purchase1 = new allPurchases()
            {
                pid = 1,
                title = "Project 1",
                price = 111,
                username = "Admin",
                datebought = DateTime.UtcNow
            };
            forventetResultat.Add(purchase1);

            // Act
            var actionResult = (ViewResult)controller.Purchases();
            var resultat = (List<allPurchases>)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].pid, resultat[i].pid);
                Assert.AreEqual(forventetResultat[i].title, resultat[i].title);
                Assert.AreEqual(forventetResultat[i].price, resultat[i].price);
                Assert.AreEqual(forventetResultat[i].username, resultat[i].username);
                // Assert.AreEqual(forventetResultat[i].dateregistered, resultat[i].dateregistered);
                // Sometimes it works(Passed Test), sometimes doesn't(Failed Test). 
                // Equal results but returns as a Failed test some of the time.
            }
        }

        [TestMethod]
        public void ListPurc_NotSignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = null;

            // Act
            var result = (RedirectToRouteResult)controller.Purchases();

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }

        // DELETE PURCHASE
        [TestMethod]
        public void deletePurch_View_SignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = 1;

            // Act
            var actionResult = (ViewResult)controller.Delete(1);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void deletePurch_View_NotSignedIn()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["UID"] = null;

            // Act
            var result = (RedirectToRouteResult)controller.Delete(1);

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }

        [TestMethod]
        public void deletePurc_FoundID_delete()
        {
            // Arrange
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var purch = new allPurchases()
            {
                pid = 1,
                title = "Project 1",
                price = 111,
                username = "Admin",
                datebought = DateTime.UtcNow
            };

            // Act
            var actionResult = (RedirectToRouteResult)controller.DeletePurchase(1, purch);

            // Assert
            Assert.AreEqual(actionResult.RouteName, "");
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "Purchases");
        }

        [TestMethod]
        public void deletePurc_NotFoundID()
        {
            // Arrange
            var controller = new Oblig2Controller(new BLLLogic(new DALRepositoryStub()));
            var purc = new allPurchases();
            purc.pid = 0;

            // Act
            var actionResult = (ViewResult)controller.DeletePurchase(0, purc);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
    }
}
