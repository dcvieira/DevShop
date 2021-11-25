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
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CategoryEntityConfiguration());
            builder.ApplyConfiguration(new CatalogItemEntityConfiguration());

            var tshirtGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var mugGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var accessoriesGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");

            builder.Entity<Category>().HasData(
                new Category { CategoryId = tshirtGuid, Name = "T-Shirt" },
                new Category { CategoryId = mugGuid, Name = "Mug" },
                new Category { CategoryId = accessoriesGuid, Name = "Accessories" }
                );

            builder.Entity<CatalogItem>().HasData(
                new CatalogItem
                {
                    Id = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                    Name = "ANGULAR T-Shirt",
                    Description = "ANGULAR T-Shirt",
                    ImgUrl = "https://cdn.shopify.com/s/files/1/0528/4148/0360/products/unisex-premium-t-shirt-true-royal-front-601befd7623e4_360x.jpg?v=1612443619",
                    Price = 25,
                    CategoryId = tshirtGuid
                },
                      new CatalogItem
                      {
                          Id = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                          Name = "VUE T-Shirt",
                          Description = "VUE T-Shirt",
                          ImgUrl = "https://cdn.shopify.com/s/files/1/0528/4148/0360/products/unisex-premium-t-shirt-navy-front-601bf2c110bb9_1800x1800.jpg?v=1612444364",
                          Price = 25,
                          CategoryId = tshirtGuid
                      },
                             new CatalogItem
                             {
                                 Id = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                                 Name = "JAVASCRIPT Mug with Color Inside",
                                 Description = "JAVASCRIPT Mug with Color Inside",
                                 ImgUrl = "https://cdn.shopify.com/s/files/1/0528/4148/0360/products/white-ceramic-mug-with-color-inside-yellow-11oz-left-602ed2f551170_1800x1800.jpg?v=1613681400",
                                 Price = 16,
                                 CategoryId = mugGuid
                             }
                );

        }
    }
}
