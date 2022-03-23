using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace webtruyen.Models
{
    public class webtruyenContext :DbContext
    {
        public webtruyenContext() : base("name=webtruyen") { }
        public virtual DbSet<Author> Authors { get; set;}
        public virtual DbSet<Category> Categories { get; set;}
        public virtual DbSet<Story> Stories { get; set;}
        public virtual DbSet<Account> Accounts { get; set;}
        public virtual DbSet<Anhbia> Anhbias { get; set;}
        
    }
}