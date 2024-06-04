using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace VegetableProject.Model
{
    public class VegetableDbContext : DbContext
    {
        public VegetableDbContext() : base("VegetableContext")
        {

        }
        public DbSet<Vegetable> Vegetables { get; set; }
        public DbSet<VegetableType> VegetableTypes { get; set; }
    }
}
