using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig2.Models;

namespace Oblig2.BLL
{
    public interface IBLLLogic
    {
        bool login(UserAccount user);
        List<Accounts> getAllAccounts();
        bool register(UserAccount user);
        bool userExists(UserAccount user);
        Accounts getAccount(int id);
        bool editAccount(int id, Accounts account);
        bool deleteAccount(int id);
        List<allMovies> getAllMovies();
        bool addMovie(Movie movie);
        bool movieExists(Movie movie);
        allMovies getMovie(int id);
        bool editMovie(int id, allMovies editMovie);
        bool deleteMovie(int id);
        List<allPurchases> getAllPurchases();
        allPurchases getPurchase(int id);
        bool deletePurchase(int id);
    }
}
