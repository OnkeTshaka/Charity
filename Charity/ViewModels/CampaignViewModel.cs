using Charity.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Charity.ViewModels
{
    public class CampaignViewModel
    {
        public ContactUs ContactUs { get; set; }
        public int Trainers { get; set; }
        public int Donors { get; set; }
        public IEnumerable<Organisation> Organisations { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Delivered> Delivereds { get; set; }
        public IEnumerable<Delivery> Deliveries { get; set; }
        public IEnumerable<OnRoute> OnRoutes { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
        public PagedList.PagedList<Blog> Blog { get; set; }
    }
}