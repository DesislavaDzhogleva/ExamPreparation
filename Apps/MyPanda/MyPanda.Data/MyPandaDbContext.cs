using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MyPanda.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPanda.Data
{
    public class MyPandaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(x => x.Packages)
                .WithOne(x => x.Recipient)
                .HasForeignKey(x => x.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasMany(x => x.Receipts)
              .WithOne(x => x.Recipient)
              .HasForeignKey(x => x.RecipientId)
              .OnDelete(DeleteBehavior.Restrict);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }
    }
}
