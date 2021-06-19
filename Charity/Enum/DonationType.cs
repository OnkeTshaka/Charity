using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Charity.Enum
{
    public enum DonationType
    {
        [Display(Name = "Once-Off-Gift")]
        onetime,
        [Display(Name = "Regular-Monthly-Gift")]
        regular
    }
}