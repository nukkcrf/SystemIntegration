using IntegrationSystem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationSystem;

public class OrderDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("Server=localhost;Database=OrderDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
