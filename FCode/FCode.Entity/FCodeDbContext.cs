using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCode.Entity
{
    public class FCodeDbContext : DbContext
    {
        public FCodeDbContext() : base("name=Test")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
    }
}
