using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Charity.Enum
{
    public enum Region
    {
        [Display(Name = "Durban")]
        Durban,
        [Display(Name = " The South Coast")]
        The_South_Coast,
        [Display(Name = "The North Coast")]
        The_North_Coast,
        [Display(Name = "Pietermaritzburg")]
        Pietermaritzburg,
        [Display(Name = "The Midlands")]
        The_Midlands,
        [Display(Name = "The Drankensburg")]
        The_Drankensburg,
        [Display(Name = "The Battlefields")]
        The_Battlefields,
        [Display(Name = "The Zululand")]
        The_Zululand,
        [Display(Name = " The Maputaland")]
        The_Maputaland
    }
}