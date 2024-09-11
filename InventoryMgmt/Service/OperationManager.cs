using InventoryMgmt.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMgmt.Service
{
    public class OperationManager: IOperationManager
    {
        private IInventoryManager _inventoryManager = new InventoryManager();
        public void StartOperation(int operationId)
        {
            switch (operationId)
            {
                case 1:
                    AddOperation();
                    break;
                case 2:
                    RemoveOperation();
                    break;
                case 3:
                    UpdateOperation();
                    break;
                case 4:
                    _inventoryManager.GetTotalValue();
                    break;
                case 5:
                    _inventoryManager.ListProducts();
                    break;
                default:
                    throw new InvalidOperationException("Invalid operation! Please try again.");
            }
        }

        private void AddOperation()
        {
            Console.WriteLine("Add a product");
            Console.WriteLine("Name:");
            string productName = Console.ReadLine();
            Console.WriteLine("Quantity:");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Price:");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            _inventoryManager.AddNewProduct(productName, quantity, price);
        }

        private void RemoveOperation()
        {
            Console.WriteLine("Remove a product");
            Console.WriteLine("Product ID:");
            int productID = Convert.ToInt32(Console.ReadLine());
            _inventoryManager.RemoveProduct(productID);
        }

        private void UpdateOperation()
        {
            Console.WriteLine("Update a product");
            Console.WriteLine("Product ID:");
            int productID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("New quantity:");
            int quantity = Convert.ToInt32(Console.ReadLine());
            _inventoryManager.UpdateProduct(productID, quantity);
        }
    }
}
