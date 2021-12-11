using E_Commerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace E_Commerce.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var baseEntityType = typeof(IBase);
        //    var entitiesAssembly = baseEntityType.Assembly;
        //    var allTypes = entitiesAssembly.GetTypes();
        //    var entities = allTypes.Where(q => q.BaseType == baseEntityType && q != baseEntityType).ToList();
        //    foreach (var entityType in entities)
        //    {
        //        UseAsEntity(modelBuilder, entityType);
        //    }
        //}

        //private static void UseAsEntity(ModelBuilder modelBuilder, Type type)
        //{
        //    modelBuilder.Entity(type);
        //}

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
