using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Oblig1.Models
{
    public class Purchases
    {
        [Key]
        public int PId { get; set; }

        [Display(Name = "Movie Title")]
        public string Title { get; set; }

        [Display(Name = "Price in NOK")]
        public double Price { get; set; }

        public string Username { get; set; }

        public DateTime DateBought { get; set; }
    }
}