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

    // TODO!!!!! initialize OrderDetails and Reviews

    static ProductService()
    {
        Products = new List<Product>
        {
            new Product { ProductID = Guid.NewGuid(), Name = "Jacket", CategoryID = Guid.NewGuid(), UnitPrice = 45.00m, ShortDescription = "winter jacket for snow and rain." },
            new Product { ProductID = Guid.NewGuid(), Name = "Toy dinosaur", CategoryID = Guid.NewGuid(), UnitPrice = 23.50m, ShortDescription = "T-Rex toy for children ages 6-12." }
        };
    }

    public static List<Product> GetAll() => Products;

    // Get
    public static Product? Get(Guid id) => Products.FirstOrDefault(p => p.ProductID == id);

    // Add
    public static void Add(Product product)
    {
        product.ProductID = Guid.NewGuid();
        Products.Add(product);
    }

    // Delete
    public static void Delete(Guid id)
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