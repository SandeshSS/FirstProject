using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.Data.EFRepository
{
    public class EntityContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GiftProduct> GiftProducts { get; set; }
        public DbSet<GiftProductCategory> GiftProductCategory { get; set; }
        public DbSet<ClubCardReg> ClubCardRegs { get; set; }
               
    }
}
