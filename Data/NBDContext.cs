using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NBDcase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NBDcase.Data
{
    public class NBDContext : DbContext
    {
        //To give access to IHttpContextAccessor for Audit Data with IAuditable
        private readonly IHttpContextAccessor _httpContextAccessor;

        //Property to hold the UserName value
        public string UserName
        {
            get; private set;
        }
        public NBDContext(DbContextOptions<NBDContext> options, IHttpContextAccessor httpContextAccessor)
         : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            UserName = _httpContextAccessor.HttpContext?.User.Identity.Name;
            UserName = UserName ?? "Unknown";
        }

        public NBDContext(DbContextOptions<NBDContext> options)
            : base(options)
        {
            UserName = "SeedData";
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
       
        public DbSet<EmployeeAcc> EmployeeAccs { get; set; }

        public DbSet<BidEmployees> BidEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("NBD");

            //Add a unique index to the Employee Email
            modelBuilder.Entity<EmployeeAcc>()
            .HasIndex(a => new { a.Email })
            .IsUnique();

            //Many to Many Intersection
            modelBuilder.Entity<Staff>()
                .HasKey(t => new { t.BidID, t.LaborID });


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
            modelBuilder.Entity<Labor>()
               .HasMany<Staff>(l => l.Staffs)
               .WithOne(s => s.Labor)
               .HasForeignKey(s => s.LaborID)
               .OnDelete(DeleteBehavior.Restrict);
       
          /*  //Prevent Cascade Delete 
            modelBuilder.Entity<Employee>()
               .HasMany<BidEmployees>(e => e.BidEmployees)
               .WithOne(b => b.Employee)
               .HasForeignKey(b => b.EmployeeID)
               .OnDelete(DeleteBehavior.Restrict);*/

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
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is IAuditable trackable)
                {
                    var now = DateTime.UtcNow;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.UpdatedOn = now;
                            trackable.UpdatedBy = UserName;
                            break;

                        case EntityState.Added:
                            trackable.CreatedOn = now;
                            trackable.CreatedBy = UserName;
                            trackable.UpdatedOn = now;
                            trackable.UpdatedBy = UserName;
                            break;
                    }
                }
            }
        }
    }
}
