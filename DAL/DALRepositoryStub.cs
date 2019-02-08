using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig2.Models;

namespace Oblig2.DAL
{
    public class DALRepositoryStub : DAL.IDALRepository
    {
        public List<Accounts> getAllAccounts()
        {
            var accountList = new List<Accounts>();
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
            accountList.Add(admin);
            accountList.Add(testuser);
            return accountList;
        }
        public bool login(UserAccount user)
        {
            if (user.Username == "")
            {
                return false;
            }
            else
            {
                return true;

            }
        }
        public bool register(UserAccount user)
        {
            if (user.Username == "")
            {
                return false;
            }
            else
            {
                return true;

            }
        }
        public bool userExists(UserAccount user)
        {
            if (user.Username != null)
            {
                return false;
            }
            else
            {
                return true;

            }
        }
        public Accounts getAccount(int id)
        {
            if (id == 0)
            {
                var account = new Accounts();
                account.uid = 0;
                return account;
            }
            else
            {
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
                return acc;
            }
        }
        public bool editAccount(int id, Accounts newAcc)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool deleteAccount(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public List<allMovies> getAllMovies()
        {
            var movList = new List<allMovies>();
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
            movList.Add(mov1);
            movList.Add(mov2);
            return movList;
        }
        public bool addMovie(Movie movie)
        {
            if (movie.Title == "")
            {
                return false;
            }
            else
            {
                return true;

            }
        }
        public bool movieExists(Movie movie)
        {
            if (movie.Title != null)
            {
                return false;
            }
            else
            {
                return true;

            }
        }
        public allMovies getMovie(int id)
        {
            if (id == 0)
            {
                var mov = new allMovies();
                mov.mid = 0;
                return mov;
            }
            else
            {
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
                return movi;
            }
        }
        public bool editMovie(int id, allMovies editMovie)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool deleteMovie(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public List<allPurchases> getAllpurchases()
        {
            var pList = new List<allPurchases>();
            var purchase1 = new allPurchases()
            {
                pid = 1,
                title = "Project 1",
                price = 111,
                username = "Admin",
                datebought = DateTime.UtcNow
            };
            pList.Add(purchase1);

            return pList;
        }
        public allPurchases getPurchase(int id)
        {
            if (id == 0)
            {
                var purc = new allPurchases();
                purc.pid = 0;
                return purc;
            }
            else
            {
                var purch = new allPurchases()
                {
                    pid = 1,
                    title = "Project 1",
                    price = 111,
                    username = "Admin",
                    datebought = DateTime.UtcNow
                };
                return purch;
            }
        }
        public bool deletePurchase(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
