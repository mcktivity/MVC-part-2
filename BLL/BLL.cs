using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig2.DAL;
using Oblig2.Models;

namespace Oblig2.BLL
{
    public class BLLLogic : BLL.IBLLLogic
    {
        private IDALRepository _repository;

        public BLLLogic()
        {
            _repository = new DALRepository();
        }

        public BLLLogic(IDALRepository stub)
        {
            _repository = stub;
        }

        // ADMIN LOGIN
        public bool login(UserAccount user)
        {
            return _repository.login(user);
        }

        // LISTS ALL ACCOUNTS
        public List<Accounts> getAllAccounts()
        {
            List<Accounts> AllAcounts = _repository.getAllAccounts();
            return AllAcounts;
        }

        // ADD NEW ACCOUNT
        public bool register(UserAccount user)
        {
            return _repository.register(user);
        }

        // CHECKS IF USER EXISTS
        public bool userExists(UserAccount user)
        {
            return _repository.userExists(user);
        }

        // GET ACCOUNT
        public Accounts getAccount(int id)
        {
            return _repository.getAccount(id);
        }

        // EDIT ACCOUNT
        public bool editAccount(int id, Accounts account)
        {
            return _repository.editAccount(id, account);
        }

        // DELETE ACCOUNT
        public bool deleteAccount(int id)
        {
            return _repository.deleteAccount(id);
        }

        // MOVIE LIST
        public List<allMovies> getAllMovies()
        {
            List<allMovies> AllMovies = _repository.getAllMovies();
            return AllMovies;
        }

        // ADD NEW MOVIE
        public bool addMovie(Movie movie)
        {
            return _repository.addMovie(movie);
        }

        // CHECKS IF TITLE EXISTS
        public bool movieExists(Movie movie)
        {
            return _repository.movieExists(movie);
        }

        // GET MOVIE
        public allMovies getMovie(int id)
        {
            return _repository.getMovie(id);
        }

        // EDIT MOVIE
        public bool editMovie(int id, allMovies editMovie)
        {
            return _repository.editMovie(id, editMovie);
        }

        // DELETE MOVIE
        public bool deleteMovie(int id)
        {
            return _repository.deleteMovie(id);
        }

        // PURCHASE LIST
        public List<allPurchases> getAllPurchases()
        {
            List<allPurchases> AllPurchases = _repository.getAllpurchases();
            return AllPurchases;
        }

        // GET PURCHASE
        public allPurchases getPurchase(int id)
        {
            return _repository.getPurchase(id);
        }

        // DELETE PURCHASE
        public bool deletePurchase(int id)
        {
            return _repository.deletePurchase(id);
        }
    }
}
