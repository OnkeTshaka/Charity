using Charity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Charity.Models
{
    public class Payment
    {

        [Key, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int PaymentID { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "A mininum of 4 letters are allowed!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "A mininum of 4 letters are allowed!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        [EmailAddress(ErrorMessage = "Please Insert a Valid Mail")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [StringLength(100, ErrorMessage = "invalid Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter a valid Phone Number")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        public DonationType DonationType { get; set; }
        [Required]
        [Display(Name = "Donation Amount")]
        public double Amount { get; set; }
    }
}