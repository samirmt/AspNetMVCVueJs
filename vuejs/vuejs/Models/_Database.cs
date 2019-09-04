using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace vuejs.Models
{
    public class _Database : DbContext
    {
        public _Database() : base("MyConnect")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<UrlBackendMobile> urlBackendMobile { get; set; }
    }
}