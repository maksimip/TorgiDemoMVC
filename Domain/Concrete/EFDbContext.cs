using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entitis;

namespace Domain.Concrete
{
    public class EFDbContext : DbContext
    { 
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
