using Microsoft.EntityFrameworkCore;
using Server.Models;
using System.Reflection.Metadata;

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
        public DbSet<Component> Components { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectComponent> ProjectComponents { get; set; }
        public DbSet<OwnsComponent> OwnsComponent { get; set; }
        #endregion
        #region Constructor
        public DatabaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// Correct the foreign key relationship between Component and Category
            //modelBuilder.Entity<Component>()
            //    .HasOne(c => c.Category)            // Navigation property
            //    .WithMany()                         // Assuming no reverse navigation from Category
            //    .HasForeignKey(c => c.CategoryID)   // Explicitly specify the FK property
            //    .OnDelete(DeleteBehavior.Restrict); // Use restrict to avoid cascading deletes for now

            //// Ensure proper relationship for User -> Component
            //modelBuilder.Entity<Component>()
            //    .HasOne(c => c.User)
            //    .WithMany(u => u.Components)
            //    .HasForeignKey(c => c.UserID)
            //    .OnDelete(DeleteBehavior.Cascade);  // User deletion cascades to Component


            //modelBuilder.Entity<Component>()
            //    .HasOne(c => c.Category)
            //    .WithMany()
            //    .HasForeignKey(c => c.CategoryID)
            //    .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade deletes here

            //// Cascade delete for User -> Component
            //modelBuilder.Entity<Component>()
            //    .HasOne(c => c.User)
            //    .WithMany(u => u.Components)
            //    .HasForeignKey(c => c.UserID)
            //    .OnDelete(DeleteBehavior.Cascade); // Cascading delete for User

            //// Restrict delete for Category -> Component
            //modelBuilder.Entity<Component>()
            //    .HasOne(c => c.Category)
            //    .WithMany()
            //    .HasForeignKey(c => c.CategoryID)
            //    .OnDelete(DeleteBehavior.Restrict); // No cascading delete for Category

            //// Prevent cascading delete for Project -> Component
            //modelBuilder.Entity<ProjectComponent>()
            //    .HasOne(pc => pc.Component)
            //    .WithMany(c => c.ProjectComponents)
            //    .HasForeignKey(pc => pc.ComponentID)
            //    .OnDelete(DeleteBehavior.NoAction); // No cascading delete for ProjectComponent


            //modelBuilder
            //    .Entity<Blog>()
            //    .HasOne(e => e.Owner)
            //    .WithOne(e => e.OwnedBlog)
            //    .OnDelete(DeleteBehavior.ClientCascade);
            //// Enable cascading delete from User to Component
            //modelBuilder.Entity<Component>()
            //    .HasOne(c => c.User)
            //    .WithMany()
            //    .HasForeignKey(c => c.UserID)
            //    .OnDelete(DeleteBehavior.Cascade); // Cascade delete when User is deleted

            //// Disable cascading delete from Category to Component
            //modelBuilder.Entity<Component>()
            //    .HasOne(c => c.Category)
            //    .WithMany()
            //    .HasForeignKey(c => c.CategoryID)
            //    .OnDelete(DeleteBehavior.Restrict); // No cascade delete when Category is deleted
        }
    }
}
