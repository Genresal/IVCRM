﻿using IVCRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace IVCRM.DAL.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        public DbSet<ProductOrderEntity> ProductOrders { get; set; }
        public DbSet<ProductStorageEntity> ProductStorages { get; set; }
        public DbSet<StorageEntity> Storages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>(p => p.Property(x => x.Price).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<ProductEntity>().HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<ProductOrderEntity>(p => p.Property(x => x.Price).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<ProductOrderEntity>().HasKey(x => new { x.ProductId, x.OrderId});
            modelBuilder.Entity<ProductOrderEntity>().HasOne(x => x.Order).WithMany(x => x.ProductOrders).HasForeignKey(x => x.OrderId);
            modelBuilder.Entity<ProductOrderEntity>().HasOne(x => x.Product).WithMany(x => x.ProductOrders).HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<ProductStorageEntity>().HasKey(x => new { x.ProductId, x.StorageId });
            modelBuilder.Entity<ProductStorageEntity>().HasOne(x => x.Storage).WithMany(x => x.ProductStorages).HasForeignKey(x => x.StorageId);
            modelBuilder.Entity<ProductStorageEntity>().HasOne(x => x.Product).WithMany(x => x.ProductStorages).HasForeignKey(x => x.ProductId);
        }
    }
}