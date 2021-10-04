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
    }
}
