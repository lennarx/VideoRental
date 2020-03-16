﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoRental.Dtos
{
    public class MovieDto
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public DateTime DataAdded { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public byte NumberInStock { get; set; }
    }
}