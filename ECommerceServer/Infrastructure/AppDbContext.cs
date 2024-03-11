using Application.Interfaces;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        public AppDbContext(DbContextOptions options, ICurrentUserService currentUserService)
            :base (options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }

        public Task<int> SaveChangesAsync()
        {
            //var entries = ChangeTracker.Entries<IAuditableEntity>().ToList();

            //foreach (var entry in entries)
            //{
            //    if (entry.Entity.AddedOn == DateTime.MinValue)
            //    {
            //        entry.Entity.AddedOn = DateTime.Now;
            //        entry.Entity.AddeddBy = _currentUserService.UserId;
            //    }
            //    entry.Entity.ModifiedOn = DateTime.Now;
            //    entry.Entity.ModifiedBy = _currentUserService.UserId;
            //}

            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
