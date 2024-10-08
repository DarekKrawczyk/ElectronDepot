using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Context
{
    public class DatabaseContext : DbContext
    {
        #region DB Entities
        public DbSet<User> Users { get; set; }
        #endregion
        public DatabaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
