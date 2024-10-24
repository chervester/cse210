using System;
using System.Collections.Generic;

namespace Foundation2
{
    // Address Class
    public class Address
    {
        private string street;
        private string city;
        private string state;
        private string country;

        public Address(string street, string city, string state, string country)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.country = country;
        }

        public bool IsInUSA()
        {
            return country == "USA";
        }

        public string DisplayAddress()
        {
            return $"{street}\n{city}, {state}\n{country}";
        }
    }

    // Customer Class
    public class Customer
    {
        private string name;
        private Address address;

        public Customer(string name, Address address)
        {
            this.name = name;
            this.address = address;
        }

        public bool IsUSAResident()
        {
            return address.IsInUSA();
        }

        public string GetName()
        {
            return name;
        }

        public Address GetAddress()
        {
            return address;
        }
    }

    // Product Class
    public class Product
    {
        private string productName;
        private string productId;
        private double price;
        private int quantity;

        public Product(string productName, string productId, double price, int quantity)
        {
            this.productName = productName;
            this.productId = productId;
            this.price = price;
            this.quantity = quantity;
        }

        public double GetTotalCost()
        {
            return price * quantity;
        }

        public string GetProductName()
        {
            return productName;
        }

        public string GetProductId()
        {
            return productId;
        }
    }

    // Order Class
    public class Order
    {
        private List<Product> products;
        private Customer customer;

        public Order(Customer customer)
        {
            products = new List<Product>();
            this.customer = customer;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public double CalculateTotalCost()
        {
            double totalCost = 0;
            foreach (Product product in products)
            {
                totalCost += product.GetTotalCost();
            }

            // Add shipping cost
            totalCost += customer.IsUSAResident() ? 5 : 35;
            return totalCost;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (Product product in products)
            {
                label += $"{product.GetProductName()} (ID: {product.GetProductId()})\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress().DisplayAddress()}";
        }
    }

    // Program Class
    class Program
    {
        static void Main(string[] args)
        {
            // Create Address instances
            Address address1 = new Address("123 Main St", "Los Angeles", "CA", "USA");
            Address address2 = new Address("456 Another Rd", "Toronto", "ON", "Canada");

            // Create Customer instances
            Customer customer1 = new Customer("John Doe", address1);
            Customer customer2 = new Customer("Jane Smith", address2);

            // Create Product instances
            Product product1 = new Product("Laptop", "LP123", 1200.99, 1);
            Product product2 = new Product("Mouse", "MS456", 25.50, 2);
            Product product3 = new Product("Keyboard", "KB789", 75.00, 1);

            Product product4 = new Product("Monitor", "MN321", 300.00, 1);
            Product product5 = new Product("Desk Lamp", "DL654", 40.75, 2);

            // Create Order instances
            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);
            order1.AddProduct(product3);

            Order order2 = new Order(customer2);
            order2.AddProduct(product4);
            order2.AddProduct(product5);

            // Display order details
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}\n");

            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}");
        }
    }
}
