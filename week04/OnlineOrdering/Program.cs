using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Order 1
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
        
        Address address1 = new Address("123 Main Street", "Phoenix", "Arizona", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Product product1 = new Product("Notebook", "P100", 5.00, 3);
        Product product2 = new Product("Pen", "P200", 1.50, 4);
        Product product3 = new Product("Bag", "P300", 25.00, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        // Order 2
        Address address2 = new Address("45 King Road", "Toronto", "Ontario", "Canada");
        Customer customer2 = new Customer("Mary Jones", address2);

        Product product4 = new Product("Shoes", "P400", 40.00, 1);
        Product product5 = new Product("Socks", "P500", 6.00, 2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Puting the orders in a list
        List<Order> orders = new List<Order>();
        orders.Add(order1);
        orders.Add(order2);

        foreach (Order order in orders)
        {
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());

            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());

            Console.WriteLine($"Total Cost: ${order.CalculateTotalCost()}");
            Console.WriteLine();
        }
    }
}