﻿using Microsoft.EntityFrameworkCore;
using ProductTask2.Entites;

namespace ProductTask2.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
           : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
