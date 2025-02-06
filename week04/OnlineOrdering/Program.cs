using System;
using System.Collections.Generic;

public class Address
{
    // Private fields
    private string streetAddress;
    private string city;
    private string stateOrProvince;
    private string country;

    // Constructor to initialize Address fields
    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    // Method to return the full address as a string
    public string GetFullAddress()
    {
        return $"{streetAddress}\n{city}, {stateOrProvince}\n{country}";
    }
}

public class Customer
{
    // Private fields
    private string name;
    private Address address;

    // Constructor to initialize customer fields
    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    // Method to return customer name
    public string GetName()
    {
        return name;
    }

    // Method to check if the customer is in the USA
    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    // Method to return the customer's address
    public string GetAddress()
    {
        return address.GetFullAddress();
    }
}

public class Product
{
    // Private fields
    private string name;
    private int productId;
    private double price;
    private int quantity;

    // Constructor to initialize Product fields
    public Product(string name, int productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    // Method to return the product's total cost (price * quantity)
    public double GetTotalCost()
    {
        return price * quantity;
    }

    // Method to return the product name and product ID
    public string GetPackingLabel()
    {
        return $"{name} (ID: {productId})";
    }
}

public class Order
{
    // Private fields
    private List<Product> products;
    private Customer customer;
    private const double USA_SHIPPING_COST = 5.0;
    private const double INTERNATIONAL_SHIPPING_COST = 35.0;

    // Constructor to initialize Order fields
    public Order(List<Product> products, Customer customer)
    {
        this.products = products;
        this.customer = customer;
    }

    // Method to calculate the total price of the order (sum of product costs + shipping)
    public double GetTotalPrice()
    {
        double totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.GetTotalCost();
        }

        double shippingCost = customer.IsInUSA() ? USA_SHIPPING_COST : INTERNATIONAL_SHIPPING_COST;
        return totalCost + shippingCost;
    }

    // Method to return the packing label (product details)
    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in products)
        {
            packingLabel += product.GetPackingLabel() + "\n";
        }
        return packingLabel;
    }

    // Method to return the shipping label (customer details)
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress()}";
    }
}

class Program
{
    static void Main()
    {
        // Create some products
        Product product1 = new Product("Laptop", 101, 999.99, 1);
        Product product2 = new Product("Wireless Mouse", 102, 25.50, 2);
        Product product3 = new Product("Smartphone", 103, 599.99, 1);

        // Create customer addresses
        Address address1 = new Address("123 Tech Lane", "Silicon Valley", "California", "USA");
        Address address2 = new Address("456 Elm Street", "Toronto", "Ontario", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create orders for each customer
        Order order1 = new Order(new List<Product> { product1, product2 }, customer1);
        Order order2 = new Order(new List<Product> { product3 }, customer2);

        // Display order details
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():F2}\n");

        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():F2}");
    }
}
