using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRental.Models;

namespace VideoRental.ViewModels
{
    public class NewRentViewModel
    {
        public int CustomerId { get; set; }        
        public List<int> MoviesId { get; set; }
    }
}