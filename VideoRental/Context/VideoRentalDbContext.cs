using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRental.Models;

namespace VideoRental.Context
{


    public class VideoRentalDbContext : IdentityDbContext<ApplicationUser>
    {
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