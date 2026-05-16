using IMS.DAL.Context;
using IMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IMS.DAL.Seeders
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetRequiredService<AppDbContext>();

            if (await db.Categories.AnyAsync() ||
                await db.Suppliers.AnyAsync() ||
                await db.Products.AnyAsync())
            {
                return;
            }

            var categories = new List<Category>
            {
                new() { Name = "Electronics", Description = "Electronic devices", CreatedBy = "Seeder" },
                new() { Name = "Books", Description = "All kinds of books", CreatedBy = "Seeder" },
                new() { Name = "Clothing", Description = "Men & Women clothing", CreatedBy = "Seeder" },
                new() { Name = "Furniture", Description = "Home furniture", CreatedBy = "Seeder" },
                new() { Name = "Sports", Description = "Sports items", CreatedBy = "Seeder" },
                new() { Name = "Food", Description = "Food products", CreatedBy = "Seeder" },
                new() { Name = "Stationery", Description = "Office supplies", CreatedBy = "Seeder" }
            };

            db.Categories.AddRange(categories);
            await db.SaveChangesAsync();

            var suppliers = new List<Supplier>
            {
                new() { Name = "Tech Hub Ltd", ContactPerson = "Rahim", Email = "tech@demo.com", Phone = "01710000001", Address = "Dhaka", CreatedBy = "Seeder" },
                new() { Name = "Book World", ContactPerson = "Karim", Email = "books@demo.com", Phone = "01710000002", Address = "Chittagong", CreatedBy = "Seeder" },
                new() { Name = "Fashion House", ContactPerson = "Sadia", Email = "fashion@demo.com", Phone = "01710000003", Address = "Dhaka", CreatedBy = "Seeder" },
                new() { Name = "Home Center", ContactPerson = "Jamal", Email = "home@demo.com", Phone = "01710000004", Address = "Sylhet", CreatedBy = "Seeder" },
                new() { Name = "Sport Zone", ContactPerson = "Nadia", Email = "sports@demo.com", Phone = "01710000005", Address = "Khulna", CreatedBy = "Seeder" },
                new() { Name = "Fresh Foods", ContactPerson = "Rafi", Email = "food@demo.com", Phone = "01710000006", Address = "Dhaka", CreatedBy = "Seeder" },
                new() { Name = "Office Mart", ContactPerson = "Hasan", Email = "office@demo.com", Phone = "01710000007", Address = "Rajshahi", CreatedBy = "Seeder" }
            };

            db.Suppliers.AddRange(suppliers);
            await db.SaveChangesAsync();

            var products = new List<Product>
            {
                new() { Name = "Laptop", Price = 65000, Quantity = 0, CategoryId = categories[0].Id, SupplierId = suppliers[0].Id, CreatedBy = "Seeder" },
                new() { Name = "Novel Book", Price = 500, Quantity = 0, CategoryId = categories[1].Id, SupplierId = suppliers[1].Id, CreatedBy = "Seeder" },
                new() { Name = "T-Shirt", Price = 800, Quantity = 0, CategoryId = categories[2].Id, SupplierId = suppliers[2].Id, CreatedBy = "Seeder" },
                new() { Name = "Sofa", Price = 25000, Quantity = 0, CategoryId = categories[3].Id, SupplierId = suppliers[3].Id, CreatedBy = "Seeder" },
                new() { Name = "Football", Price = 1200, Quantity = 0, CategoryId = categories[4].Id, SupplierId = suppliers[4].Id, CreatedBy = "Seeder" },
                new() { Name = "Rice Bag", Price = 1500, Quantity = 0, CategoryId = categories[5].Id, SupplierId = suppliers[5].Id, CreatedBy = "Seeder" },
                new() { Name = "Notebook", Price = 100, Quantity = 0, CategoryId = categories[6].Id, SupplierId = suppliers[6].Id, CreatedBy = "Seeder" }
            };

            db.Products.AddRange(products);
            await db.SaveChangesAsync();
        }
    }
}