using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GuestPay.Models
{
    [Serializable]
    public class SubscriberDetails
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        public DateTime DateOfBirth { get; set; } 

        [Required]
        [Display(Name = "Reference Id")]
        [StringLength(9, ErrorMessage = "Reference Number cannot be more than 9 digits")]
        public string ReferenceId { get; set; }
    }
}
