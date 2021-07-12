using PrintApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintApp.Data
{
   public class AppDbContext : DbContext
    {

        public AppDbContext() : base("MyConnection")
        {
                
        }

       public   DbSet<Pageform> Pageforms { get; set; }
        public DbSet<Pageinfo> Pageinfoes { get; set; }


    }
}
