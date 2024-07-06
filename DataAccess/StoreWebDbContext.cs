﻿using Domain;
using Domain.Accounts;
using Domain.Store;
using Microsoft.EntityFrameworkCore;
using SmartEnum.EFCore;

namespace DataAccess
{
    public class StoreWebDbContext : DbContext
    {
        public StoreWebDbContext(DbContextOptions<StoreWebDbContext> options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.ConfigureSmartEnum();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Domain.File> Files { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<User> Users { get; set; }
    }
}