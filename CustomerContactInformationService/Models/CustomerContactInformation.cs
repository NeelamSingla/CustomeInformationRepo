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
        public int Id { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
