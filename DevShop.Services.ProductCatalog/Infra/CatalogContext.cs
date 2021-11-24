using System;
using Catalog.API.Entities;
using Catalog.API.Infra.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infra
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<Category>(new CategoryEntityConfiguration());
        }
    }
}
