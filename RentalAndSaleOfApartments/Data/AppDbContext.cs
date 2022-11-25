using Microsoft.EntityFrameworkCore;
using RentalAndSaleOfApartments.Models;
using System.Collections.Generic;

namespace RentalAndSaleOfApartments.Data
{
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            public DbSet<Rent> Rents { get; set; }

            public DbSet<Sale> Sales { get; set; }
        }
}



