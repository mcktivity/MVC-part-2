using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Oblig2.Models
{
    public class Movie
    {
        [Key]
        public int MId { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public string ImgUrl { get; set; }

        public int Year { get; set; }

        public string Dir { get; set; }

        public string Plot { get; set; }

        public string VidUrl { get; set; }
    }
}