using Charity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Charity.ViewModels
{
    public class UsersRolesViewModel
    {
        public ICollection<ApplicationUser> Admins { get; set; }
        public ICollection<ApplicationUser> Donors { get; set; }
        public ICollection<ApplicationUser> OrganisationRep { get; set; }
    }
}