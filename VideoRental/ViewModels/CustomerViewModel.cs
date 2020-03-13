using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRental.Models;

namespace VideoRental.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public string PageTitle { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}