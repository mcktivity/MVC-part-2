using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;

namespace Oblig2.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DB")
        {
        }

        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Purchases> Purchases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}