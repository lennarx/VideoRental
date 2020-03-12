using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VideoRental.Models;

namespace VideoRental.Context
{


    public class VideoRentalDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public VideoRentalDbContext()
            : base("VideoRentalConnectionString", throwIfV1Schema: false)
        {

        }

        public static VideoRentalDbContext Create()
        {
            return new VideoRentalDbContext();
        }
        
    }
}