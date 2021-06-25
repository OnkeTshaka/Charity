using Charity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Charity.Repository
{
    public class BlogRepository : RepositoryBase<Blog>
    {
        public BlogRepository(ApplicationDbContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
        }
    }
}