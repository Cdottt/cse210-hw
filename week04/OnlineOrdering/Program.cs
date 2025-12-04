using System;

class Program
{
    static void Main(string[] args)
    {
        // ORDER 1
        Address add1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer cust1 = new Customer("John Smith", add1);

        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "L1001", 900, 1));
        order1.AddProduct(new Product("Headphones", "H2001", 50, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Order Type: {(order1.IsUSA() ? "US Order" : "International Order")}");
        Console.WriteLine($"Shipping Cost: ${order1.GetShippingCost()}");
        Console.WriteLine($"Total Price: ${order1.GetTotalCost()}\n");

        // ORDER 2
        Address add2 = new Address("45 Sunset Blvd", "Toronto", "ON", "Canada");
        Customer cust2 = new Customer("Emily Carter", add2);

        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Camera", "C9001", 450, 1));
        order2.AddProduct(new Product("Tripod", "T3001", 75, 1));
        order2.AddProduct(new Product("SD Card", "S5001", 20, 3));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Order Type: {(order2.IsUSA() ? "US Order" : "International Order")}");
        Console.WriteLine($"Shipping Cost: ${order2.GetShippingCost()}");
        Console.WriteLine($"Total Price: ${order2.GetTotalCost()}");
    }
}
