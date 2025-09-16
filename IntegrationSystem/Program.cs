using EasyModbus;
using IntegrationSystem;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using var context = new OrderDbContext();

        // Hämta bara ordrar som inte skickats
        var orders = context.Orders.Where(o => !o.IsSent).ToList();

        if (!orders.Any())
        {
            Console.WriteLine("No new orders to send.");
            return;
        }

        var client = new ModbusClient("127.0.0.1", 502);
        client.Connect();
        Console.WriteLine("Connected to OTSystem via Modbus.");

        foreach (var order in orders)
        {
            client.WriteSingleRegister(0, order.Id);
            client.WriteSingleRegister(1, order.Quantity);

            Console.WriteLine($"Sent order {order.Id} with Quantity {order.Quantity} to OTSystem.");

            // Markera som skickad
            order.IsSent = true;
        }

        context.SaveChanges();
        client.Disconnect();

        Console.WriteLine("All new orders sent. Press any key to exit.");
        Console.ReadKey();
    }
}
