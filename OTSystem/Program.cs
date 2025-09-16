using EasyModbus;
using System;

class Program
{
    static void Main(string[] args)
    {
        var server = new ModbusServer();

        // Event som triggas när holding registers ändras
        server.HoldingRegistersChanged += (register, numberOfRegisters) =>
        {
            int orderId = server.holdingRegisters[0];
            int quantity = server.holdingRegisters[1];
            Console.WriteLine($"OTSystem received -> OrderId: {orderId}, Quantity: {quantity}");
        };

        server.Listen();
        Console.WriteLine("OT System running. Listening for Modbus messages on port 502...");

        Console.WriteLine("Press any key to stop.");
        Console.ReadKey();
    }
}
