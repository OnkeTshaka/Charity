using Charity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Charity.Models
{
  

    public class Organisation
    {
        [Key, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrganisationId { get; set; }
        [Required]
        [Display(Name ="Organisation Name")]
        public string OrganisationName { get; set; }
        [Required]
        [Display(Name = "Organisation City")]
        public string OrganisationCity { get; set; }
        [Required]
        [Display(Name = "State")]
        public string OrganisationState { get; set; }
        [Required]
        [Display(Name = "Type")]
        public OrgType OrganisationType { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
        public string OrganisationZipCode { get; set; }
    }
}