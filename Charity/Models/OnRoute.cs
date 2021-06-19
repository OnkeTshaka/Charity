using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Charity.Models
{
    public class OnRoute
    {

        [Key, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeliveryID { get; set; }
        [Display(Name = "Delivery Address")]
        public string Address { get; set; }
        [Display(Name = "Delivery Address")]
        public string PickUpAddress { get; set; } = "Berea Centre Road, Bulwer, Berea, South Africa";
        [Display(Name = "Donate Clothes")]
        public bool Clothes { get; set; }
        [Display(Name = "Donate Food")]
        public bool Food { get; set; }
        [Display(Name = "Total QTY")]
        public int TotalQTY { get; set; }

        [Display(Name = "Image")]
        public byte[] image { get; set; }
        public string status { get; set; }
        [ForeignKey("Organisation")]
        public int OrganisationId { get; set; }
        public virtual Organisation Organisation { get; set; }
    }
}