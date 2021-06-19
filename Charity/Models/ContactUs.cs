using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Charity.Models
{
    public class ContactUs
    {

        [Key, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        [DataType(DataType.Text)]
        [StringLength(100,MinimumLength =4, ErrorMessage = "A mininum of 4 letters are allowed!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        [EmailAddress(ErrorMessage = "Please Insert a Valid Mail")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        [Display(Name = "Phone Number")]
        [StringLength(10, ErrorMessage = "Enter Valid Phone Number", MinimumLength = 10)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "This Field Is Required, Enter Your Phone Number in Phone Pattern Only")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        [DataType(DataType.Text)]
        [StringLength(500, ErrorMessage = "Please Ensure That Your Message in Range 500 Characters")]
        [Display(Name = "Message")]
        public string Message { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Time")]
        public string TimeStamp { get; set; }

        [Required]
        public bool IsReaded { get; set; }

        public ContactUs()
        {
            this.IsReaded = false;
            this.TimeStamp = DateTime.Now.ToLongDateString();
        }
    }
}