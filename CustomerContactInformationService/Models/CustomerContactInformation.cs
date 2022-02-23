using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerContactInformationService.Models
{
    public class CustomerContactInformation
    {
        [Key]
        [Required]
        public string SocialSecurityNumber { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
