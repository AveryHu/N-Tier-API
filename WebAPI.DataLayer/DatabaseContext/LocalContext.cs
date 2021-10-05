using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Domain.Entities;

namespace WebAPI.DataLayer.DatabaseContext
{
    public class LocalContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public LocalContext(DbContextOptions<LocalContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Auto-increment id
            modelBuilder.Entity<Account>()
                    .HasIndex(a => a.Id)
                    .IsUnique();

            modelBuilder.Entity<Account>()
                    .Property(a => a.Id)
                    .ValueGeneratedOnAdd();

            modelBuilder.Entity<Account>()
                .Property(a => a.Password)
                .HasMaxLength(32)
                .IsRequired();
        }
    }
}
