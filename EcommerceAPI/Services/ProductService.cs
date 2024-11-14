using ECommerceAPI.Models;
using System;
using System.IO;
using System.Collections;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ECommerceAPI.Services;

// Handles the main e-commerce product management functionality (listing and managing products)

public static class ProductService
{
    static List<Product> Products { get; }
    static int nextId = 3;

    // TODO!!!!! initialize OrderDetails and Reviews

    static ProductService()
    {
        Products = new List<Product>
        {
            new Product { ProductID = 1, Name = "Jacket", CategoryID = 0, UnitPrice = 45.00m, ShortDescription = "winter jacket for snow and rain." },
            new Product { ProductID = 2, Name = "Toy dinosaur", CategoryID = 1, UnitPrice = 23.50m, ShortDescription = "T-Rex toy for children ages 6-12." }
        };
    }

    public static List<Product> GetAll() => Products;

    // Get
    public static Product? Get(int id) => Products.FirstOrDefault(p => p.ProductID == id);

    // Add
    public static void Add(Product product)
    {
        product.ProductID = nextId++;
        Products.Add(product);
    }

    // Delete
    public static void Delete(int id)
    {
        var product = Get(id);
        if(product is null)
            return;

        Products.Remove(product);
    }

    // Update
    public static void Update(Product product)
    {
        var index = Products.FindIndex(p => p.ProductID == product.ProductID);
        if(index == -1)
            return;

        Products[index] = product;
    }
}