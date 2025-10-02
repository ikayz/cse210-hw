using System;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses for customers
        Address usaAddress = new Address("123 Main St", "Seattle", "WA", "USA");
        Address internationalAddress = new Address("456 Maple Rd", "Toronto", "ON", "Canada");

        // Create customers
        Customer usaCustomer = new Customer("John Doe", usaAddress);
        Customer internationalCustomer = new Customer("Jane Smith", internationalAddress);

        // Create some products
        Product laptop = new Product("Laptop", "TECH001", 999.99, 1);
        Product mouse = new Product("Wireless Mouse", "TECH002", 24.99, 2);
        Product headphones = new Product("Headphones", "TECH003", 79.99, 1);
        Product keyboard = new Product("Keyboard", "TECH004", 49.99, 1);

        // Create first order (USA)
        Order order1 = new Order(usaCustomer);
        order1.AddProduct(laptop);
        order1.AddProduct(mouse);

        // Create second order (International)
        Order order2 = new Order(internationalCustomer);
        order2.AddProduct(headphones);
        order2.AddProduct(keyboard);

        // Display order 1 details
        Console.WriteLine("ORDER 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():F2}\n");

        // Display order 2 details
        Console.WriteLine("ORDER 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():F2}");
    }
}
