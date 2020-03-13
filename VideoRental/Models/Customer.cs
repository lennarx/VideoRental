using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoRental.Models
{
    public class Customer
    {        
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public bool IsSuscribedToNewsletter { get; set; }
        [Display(Name="Membership Type")]
        public byte? MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }        
        [Display(Name="Date of Birth")]
        public DateTime BirthDate { get; set; }
        
    }
}