using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using SystemIntegration;

namespace ITSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new OrderDbContext();

            // Skapar databasen och tabellen om de inte finns
            context.Database.EnsureCreated();

            // Lägg till testordrar om tabellen är tom
            if (!context.Orders.Any())
            {
                var orders = new List<Order>
                {
                    new Order { ProductName = "Bolt", Quantity = 100 },
                    new Order { ProductName = "Nut", Quantity = 200 },
                    new Order { ProductName = "Screw", Quantity = 50 }
                };

                context.Orders.AddRange(orders);
                context.SaveChanges();
                Console.WriteLine("Seeded database with test orders.");
            }

            // Lista alla ordrar
            Console.WriteLine("Current Orders:");
            foreach (var order in context.Orders.ToList())
            {
                Console.WriteLine($"{order.Id}: {order.ProductName} x {order.Quantity}");
            }
        }
    }
}
