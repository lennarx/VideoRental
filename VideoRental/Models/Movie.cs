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
        [Display(Name="Added on Date:")]
        public DateTime DateAdded { get; set; }        
        [Display(Name="Released on Date:")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name="Genre")]
        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        [Range(1, 20)]
        [Display(Name="Stock")]
        public byte NumberInStock { get; set; }
    }
}