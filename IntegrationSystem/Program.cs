using EasyModbus;
using IntegrationSystem;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1 = Add new order");
            Console.WriteLine("2 = Send orders (G or VG mode)");
            Console.WriteLine("3 = Exit");
            Console.Write("Choose: ");
            string choice = Console.ReadLine();

            using var context = new OrderDbContext();

            if (choice == "1")
            {
                Console.Write("Product name: ");
                string product = Console.ReadLine();

                Console.Write("Quantity: ");
                int qty = int.Parse(Console.ReadLine());

                var newOrder = new Order { ProductName = product, Quantity = qty, IsSent = false };
                context.Orders.Add(newOrder);
                context.SaveChanges();

                Console.WriteLine($"New order added: {product} x {qty}");
            }
            else if (choice == "2")
            {
                Console.Write("Mode (G = all orders, VG = only new orders): ");
                string mode = Console.ReadLine()?.Trim().ToUpper();

                var orders = (mode == "G")
                    ? context.Orders.ToList()
                    : context.Orders.Where(o => !o.IsSent).ToList();

                if (!orders.Any())
                {
                    Console.WriteLine("No orders to send.");
                }
                else
                {
                    var client = new ModbusClient("127.0.0.1", 502);
                    client.Connect();

                    foreach (var order in orders)
                    {
                        client.WriteSingleRegister(0, order.Id);
                        client.WriteSingleRegister(1, order.Quantity);

                        Console.WriteLine($"Sent order {order.Id} with Quantity {order.Quantity} to OTSystem.");

                        if (mode != "G") order.IsSent = true;
                    }

                    context.SaveChanges();
                    client.Disconnect();
                }
            }
            else if (choice == "3")
            {
                running = false;
            }
        }
    }
}
