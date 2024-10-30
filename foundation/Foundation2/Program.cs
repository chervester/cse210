using System;
using System.Collections.Generic;

class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return price * quantity;
    }

    public string GetPackingLabel()
    {
        return $"Product: {name} | ID: {productId}";
    }
}

class Address
{
    private string streetAddress;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        this.streetAddress = street;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToUpper() == "USA";
    }

    public string GetAddressString()
    {
        return $"{streetAddress}\n{city}, {stateOrProvince}\n{country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetShippingLabel()
    {
        return $"Customer: {name}\nAddress:\n{address.GetAddressString()}";
    }
}

class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.GetTotalCost();
        }
        totalCost += customer.IsInUSA() ? 5 : 35;
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += product.GetPackingLabel() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return customer.GetShippingLabel();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Address and Customer for Order 1
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        // Create Order 1 and add Products
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P001", 899.99m, 1));
        order1.AddProduct(new Product("Mouse", "P002", 25.99m, 2));

        // Display Order 1 details
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}");

        // Address and Customer for Order 2
        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create Order 2 and add Products
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Tablet", "P003", 299.99m, 1));
        order2.AddProduct(new Product("Headphones", "P004", 49.99m, 2));

        // Display Order 2 details
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}");
    }
}
