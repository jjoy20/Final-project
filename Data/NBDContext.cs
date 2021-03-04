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

        public DbSet<Category> Categories { get; set; }


        public DbSet<Employee> Employees { get; set; }

   
        public DbSet<Bid> Bids { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Labor> Labors { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Designer> Designers { get; set; }


        public DbSet<Sales> Sales { get; set; }






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
            modelBuilder.Entity<Designer>()
               .HasMany<Bid>(d => d.Bids)
               .WithOne(b => b.Designer)
               .HasForeignKey(b => b.DesignerID)
               .OnDelete(DeleteBehavior.Restrict);

            //Prevent Cascade Delete 
            modelBuilder.Entity<Sales>()
              .HasMany<Bid>(s => s.Bids)
              .WithOne(b => b.Sales)
              .HasForeignKey(b => b.SalesID)
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
            modelBuilder.Entity<Labor>()
               .HasMany<Staff>(l => l.Staffs)
               .WithOne(s => s.Labor)
               .HasForeignKey(s => s.LaborID)
               .OnDelete(DeleteBehavior.Restrict);

            //Prevent Cascade Delete 
            modelBuilder.Entity<Labor>()
               .HasMany<Employee>(l => l.Employees)
               .WithOne(e => e.Labor)
               .HasForeignKey(e => e.LaborID)
               .OnDelete(DeleteBehavior.Restrict);

            //Prevent Cascade Delete 
            modelBuilder.Entity<Category>()
              .HasMany<Material>(c => c.Materials)
              .WithOne(p => p.Category)
              .HasForeignKey(p => p.CategoryID)
              .OnDelete(DeleteBehavior.Restrict);

            //Prevent Cascade Delete 
            modelBuilder.Entity<Material>()
               .HasMany<Inventory>(b => b.Inventories)
               .WithOne(i => i.Material)
               .HasForeignKey(i => i.MaterialID)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
