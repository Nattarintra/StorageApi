using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StorageApi.Models.Entities;

namespace StorageApi.Data
{
    public class StorageApiContext : DbContext
    {
        public StorageApiContext (DbContextOptions<StorageApiContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Sample Product",
                    Price = 100,
                    Category = "Sample Category",
                    Shelf = "A1",
                    Count = 10,
                    Description = "This is a sample product description."
                },
                new Product
                {
                    Id = 2,
                    Name = "Another Product",
                    Price = 200,
                    Category = "Another Category",
                    Shelf = "B2",
                    Count = 20,
                    Description = "This is another product description."
                },
                new Product
                {
                    Id = 3,
                    Name = "Third Product",
                    Price = 300,
                    Category = "Third Category",
                    Shelf = "C3",
                    Count = 30,
                    Description = "This is the third product description."
                },
                new Product
                {
                    Id = 4,
                    Name = "Fourth Product",
                    Price = 400,
                    Category = "Fourth Category",
                    Shelf = "D4",
                    Count = 40,
                    Description = "This is the fourth product description."
                }
            );           
        }
    }
}
