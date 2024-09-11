using InventoryMgmt.Interface;
using InventoryMgmt.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMgmt.Service
{
    public class InventoryManager: IInventoryManager
    {
        private readonly List<Product> _products = [];
        private int _currentID = 1;

        public void AddNewProduct(string name, int quantity, decimal price) => AddProduct(new() { Name = name, QuantityInStock = quantity, Price = price });

        private void AddProduct(Product product)
        {
            try
            {
                var results = new List<ValidationResult>();
                var context = new ValidationContext(product, null, null);
                bool isValid = Validator.TryValidateObject(product, context, results, true);
                if (!isValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    foreach (var validationResult in results)
                    {
                        Console.WriteLine($"- {validationResult.ErrorMessage}");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    product.ProductID = _currentID++;
                    _products.Add(product);
                    Console.WriteLine("Product added successfully.");
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error adding product, please try again.");
            }
            Console.ResetColor();
        }

        public void RemoveProduct(int productID)
        {
            if(_products.RemoveAll(x => x.ProductID == productID) > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Product removed successfully.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Product not found, please try again.");
            }
            Console.ResetColor();
        }
        public void UpdateProduct(int productID, int quantity)
        {
            var product = _products.FirstOrDefault(x => x.ProductID == productID);
            if (product == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Product not found, please try again.");
            }
            else
            {
                if (quantity < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Quantity should not be less than 0. Please try again.");
                }
                else
                {
                    product.QuantityInStock = quantity;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Product updated successfully.");
                }
            }
            Console.ResetColor();
        }
        public void GetTotalValue()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (_products.Count == 0)
                Console.WriteLine("Total value of inventory: 0.00");
            else
                Console.WriteLine($"Total value of inventory: {String.Format("{0:0,0.00}", _products.Select(x => x.Price * x.QuantityInStock).Sum())}");
            Console.ResetColor();
        }

        public void ListProducts()
        {
            if (_products.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No products in here.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var product in _products)
                    Console.WriteLine(JsonConvert.SerializeObject(product));
            }
            Console.ResetColor();
        }
    }
}
