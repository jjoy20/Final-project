using Microsoft.EntityFrameworkCore;
using NBDcase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDcase.Data
{
    public class NBDContext : DbContext
    {
        public NBDContext(DbContextOptions<NBDContext> options)
         : base(options)
        {

        }

        public DbSet<Bid> Bids { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Labor> Labors { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("NBD");

            //Prevent Cascade Delete 
            modelBuilder.Entity<Client>()
                .HasMany<Project>(c => c.Projects)
                .WithOne(p => p.Client)
                .HasForeignKey(p => p.ClientID)
                .OnDelete(DeleteBehavior.Restrict);

            //Prevent Cascade Delete 
            modelBuilder.Entity<Project>()
               .HasMany<Bid>(p => p.Bids)
               .WithOne(b => b.Project)
               .HasForeignKey(b => b.ProjectID)
               .OnDelete(DeleteBehavior.Restrict);

            //Prevent Cascade Delete 
            modelBuilder.Entity<Bid>()
               .HasMany<Staff>(b => b.Staffs)
               .WithOne(s => s.Bid)
               .HasForeignKey(s => s.BidID)
               .OnDelete(DeleteBehavior.Restrict);

            //Prevent Cascade Delete 
            modelBuilder.Entity<Bid>()
               .HasMany<Inventory>(b => b.Inventories)
               .WithOne(i => i.Bid)
               .HasForeignKey(i => i.BidID)
               .OnDelete(DeleteBehavior.Restrict);

            //Prevent Cascade Delete 
            modelBuilder.Entity<Staff>()
               .HasMany<Labor>(b => b.Labors)
               .WithOne(l => l.Staff)
               .HasForeignKey(l => l.StaffID)
               .OnDelete(DeleteBehavior.Restrict);

            //Prevent Cascade Delete 
            modelBuilder.Entity<Inventory>()
               .HasMany<Material>(b => b.Materials)
               .WithOne(m => m.Inventory)
               .HasForeignKey(m => m.InventoryID)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
