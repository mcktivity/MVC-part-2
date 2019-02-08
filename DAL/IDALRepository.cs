using System;
using System.Collections.Generic;
using Oblig2.Models;

namespace Oblig2.DAL
{
    public interface IDALRepository
    {
        bool login(UserAccount user);
        List<Accounts> getAllAccounts();
        bool register(UserAccount user);
        bool userExists(UserAccount user);
        Accounts getAccount(int id);
        bool editAccount(int id, Accounts newAcc);
        bool deleteAccount(int id);
        List<allMovies> getAllMovies();
        bool addMovie(Movie movie);
        bool movieExists(Movie movie);
        allMovies getMovie(int id);
        bool editMovie(int id, allMovies editMovie);
        bool deleteMovie(int id);
        List<allPurchases> getAllpurchases();
        allPurchases getPurchase(int id);
        bool deletePurchase(int id);
    }
}
