using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Context
{
    public class DatabaseContext : DbContext
    {
        #region DB Entities
        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        #endregion
        #region Constructor
        public DatabaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        #endregion
    }
}
