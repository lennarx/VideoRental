using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoRental.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }        
        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }        
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}