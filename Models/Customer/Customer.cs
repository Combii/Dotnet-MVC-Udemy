using System;
using System.ComponentModel.DataAnnotations;

namespace Dotnet_MVC_Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Birthday { get; set; }


        public override string ToString()
        {
            var rString = "@Name: " + Name + "@IsSubscribedToNewsletter: " + IsSubscribedToNewsletter + 
                   "@MemberShipTypeId: " + MembershipType + "@Birthday: " + Birthday;
            return rString.Replace("@", Environment.NewLine);    
        }

    }
}

