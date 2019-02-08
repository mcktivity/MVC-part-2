using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig2.Models;

namespace Oblig2.DAL
{
    public class DALRepository :DAL.IDALRepository
    {
        private DataContext db = new DataContext(); // DbContext

        // USERS
        public bool login(UserAccount user)
        {
            var userCheck = db.UserAccounts.Where(
                u => u.Username == user.Username &&
                u.Password == user.Password &&
                u.IsDeleted == false && u.IsAdmin == true).FirstOrDefault();

            if (userCheck != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Accounts> getAllAccounts()
        {
            List<Accounts> allAccounts = db.UserAccounts.Select(k => new Accounts()
            {
                uid = k.UID,
                firstname = k.FirstName,
                lastname = k.LastName,
                email = k.Email,
                username = k.Username,
                password = k.Password,
                confirmpassword = k.ConfirmPassword,
                isadmin = k.IsAdmin,
                isdeleted = k.IsDeleted,
                dateregistered = k.DateRegistered,
            }
            ).ToList();
            return allAccounts;
        }

        public bool register(UserAccount user)
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
                IsAdmin = user.IsAdmin,
            };

            db.UserAccounts.Add(newUser);
            db.SaveChanges();
            return true;
        }

        public bool userExists(UserAccount user)
        {
            var userCheck = db.UserAccounts.Where(u => u.Username == user.Username).FirstOrDefault();

            if (userCheck != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Accounts getAccount(int id)
        {
            var account = db.UserAccounts.Find(id);

            if (account == null)
            {
                return null;
            }
            else
            {
                var acc = new Accounts()
                {
                    uid = account.UID,
                    username = account.Username,
                    password = account.Password,
                    confirmpassword = account.ConfirmPassword,
                    email = account.Email,
                    dateregistered = account.DateRegistered,
                    lastname = account.LastName,
                    firstname = account.FirstName,
                    isadmin = account.IsAdmin,
                    isdeleted = account.IsDeleted
                };
                return acc;
            }
        }

        public bool editAccount(int id, Accounts newAcc)
        {
            try
            {
                UserAccount oldAcc = db.UserAccounts.Find(id);
                oldAcc.Password = newAcc.password;
                oldAcc.ConfirmPassword = newAcc.confirmpassword;
                oldAcc.Email = newAcc.email;
                oldAcc.FirstName = newAcc.firstname;
                oldAcc.LastName = newAcc.lastname;
                oldAcc.IsAdmin = newAcc.isadmin;
                oldAcc.IsDeleted = newAcc.isdeleted;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteAccount(int id)
        {
            try
            {
                UserAccount oldAcc = db.UserAccounts.Find(id);
                db.UserAccounts.Remove(oldAcc);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // MOVIES 
        public List<allMovies> getAllMovies()
        {
            List<allMovies> allMovies = db.Movies.Select(k => new allMovies()
            {
                mid = k.MId,
                title = k.Title,
                price = k.Price,
                year = k.Year,
                dir = k.Dir,
                plot = k.Plot,
                imgurl = k.ImgUrl,
                vidurl = k.VidUrl,
            }
            ).ToList();
            return allMovies;
        }

        public bool addMovie(Movie movie)
        {
            var newMovie = new Movie()
            {
                MId = movie.MId,
                Title = movie.Title,
                Price = movie.Price,
                Year = movie.Year,
                Dir = movie.Dir,
                Plot = movie.Plot,
                ImgUrl = movie.ImgUrl,
                VidUrl = movie.VidUrl,
            };

            db.Movies.Add(newMovie);
            db.SaveChanges();
            return true;
        }

        public bool movieExists(Movie movie)
        {
            var movieCheck = db.Movies.Where(u => u.Title == movie.Title).FirstOrDefault();

            if (movieCheck != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public allMovies getMovie(int id)
        {
            var Movie = db.Movies.Find(id);

            if (Movie == null)
            {
                return null;
            }
            else
            {
                var mov = new allMovies()
                {
                    mid = Movie.MId,
                    title = Movie.Title,
                    plot = Movie.Plot,
                    year = Movie.Year,
                    dir = Movie.Dir,
                    imgurl = Movie.ImgUrl,
                    vidurl = Movie.VidUrl,
                    price = Movie.Price,
                };
                return mov;
            }
        }

        public bool editMovie(int id, allMovies editMovie)
        {
            try
            {
                Movie oldMov = db.Movies.Find(id);
                oldMov.Title = editMovie.title;
                oldMov.Year = editMovie.year;
                oldMov.Dir = editMovie.dir;
                oldMov.ImgUrl = editMovie.imgurl;
                oldMov.VidUrl = editMovie.vidurl;
                oldMov.Price = editMovie.price;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteMovie(int id)
        {
            try
            {
                Movie oldMov = db.Movies.Find(id);
                db.Movies.Remove(oldMov);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // PURCHASES

        public List<allPurchases> getAllpurchases()
        {
            List<allPurchases> allpurchases = db.Purchases.Select(k => new allPurchases()
            {
                pid = k.PId,
                title = k.Title,
                price = k.Price,
                username = k.Username,
                datebought = k.DateBought,
            }
            ).OrderByDescending(c => c.datebought).ToList();
            return allpurchases;
        }

        public allPurchases getPurchase(int id)
        {
            var purchase = db.Purchases.Find(id);

            if (purchase == null)
            {
                return null;
            }
            else
            {
                var acc = new allPurchases()
                {
                    pid = purchase.PId,
                    title = purchase.Title,
                    price = purchase.Price,
                    username = purchase.Username,
                    datebought = purchase.DateBought,
                };
                return acc;
            }
        }

        public bool deletePurchase(int id)
        {
            try
            {
                Purchases purchase = db.Purchases.Find(id);
                db.Purchases.Remove(purchase);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
 }