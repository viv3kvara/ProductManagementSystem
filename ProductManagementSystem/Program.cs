using System;
using ProductManagementSystem.Models;
using ProductManagementSystem.Services;

namespace ProductManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();
            int choice;

            do
            {
                Console.WriteLine("\n--- Product Management System ---");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Search Product by Id");
                Console.WriteLine("4. Filter Products by Price");
                Console.WriteLine("5. Remove Product");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Product product = new Product();

                        Console.Write("Enter Product Id: ");
                        product.Id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Product Name: ");
                        product.Name = Console.ReadLine();

                        Console.Write("Enter Product Price: ");
                        product.Price = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("Enter Product Quantity: ");
                        product.quantity = Convert.ToInt32(Console.ReadLine());

                        productService.AddProduct(product);
                        Console.WriteLine("Product added successfully!");
                        break;

                    case 2:
                        var products = productService.GetAllProducts();
                        Console.WriteLine("\n--- All Products ---");

                        foreach (var p in products)
                        {
                            Console.WriteLine(
                                $"Id: {p.Id}, Name: {p.Name}, Price: {p.Price}, Quantity: {p.quantity}"
                            );
                        }
                        break;

                    case 3:
                        Console.Write("Enter Product Id to search: ");
                        int searchId = Convert.ToInt32(Console.ReadLine());

                        var foundProduct = productService.GetProductById(searchId);
                        if (foundProduct != null)
                        {
                            Console.WriteLine(
                                $"Id: {foundProduct.Id}, Name: {foundProduct.Name}, Price: {foundProduct.Price}, Quantity: {foundProduct.quantity}"
                            );
                        }
                        else
                        {
                            Console.WriteLine("Product not found!");
                        }
                        break;

                    case 4:
                        Console.Write("Enter Min Price: ");
                        decimal minPrice = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("Enter Max Price: ");
                        decimal maxPrice = Convert.ToDecimal(Console.ReadLine());

                        var filteredProducts = productService.GetProductsByPriceRange(minPrice, maxPrice);

                        Console.WriteLine("\n--- Filtered Products ---");
                        foreach (var p in filteredProducts)
                        {
                            Console.WriteLine(
                                $"Id: {p.Id}, Name: {p.Name}, Price: {p.Price}, Quantity: {p.quantity}"
                            );
                        }
                        break;

                    case 5:
                        Console.Write("Enter Product Id to remove: ");
                        int removeId = Convert.ToInt32(Console.ReadLine());

                        bool isremoved = productService.RemoveProduct(removeId);
                        if (isremoved) { Console.WriteLine("Product removed successfully!"); }
                        else { Console.WriteLine("sorry because you enter id is not valid so enter valid id "); }
                        break;

                    case 0:
                        Console.WriteLine("Exiting application...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

            } while (choice != 0);

            Console.ReadLine();
        }
    }
}
