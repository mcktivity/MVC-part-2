using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig2.Models
{
    public class allPurchases
    {
        [Key]
        public int pid { get; set; }

        [Display(Name = "Movie Title")]
        public string title { get; set; }

        [Display(Name = "Price in NOK")]
        public double price { get; set; }

        [Display(Name = "Buyer")]
        public string username { get; set; }

        [Display(Name = "Date Bought")]
        public DateTime datebought { get; set; }

    }
}
