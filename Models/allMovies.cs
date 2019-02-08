using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig2.Models
{
    public class allMovies
    {
        [Key]
        public int mid { get; set; }

        public string title { get; set; }

        public double price { get; set; }

        public string imgurl { get; set; }

        public int year { get; set; }

        public string dir { get; set; }

        public string plot { get; set; }

        public string vidurl { get; set; }

        public virtual List<Movie> Movies { get; set; }

    }
}
