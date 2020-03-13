using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRental.Models;

namespace VideoRental.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public string PageTitle { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}