using InventoryMgmt.Service;
using InventoryMgmt.Interface;
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InventoryMgmtQA.Service
{
    [TestClass]
    public class TestModifyProduct
    {
        private IInventoryManager _inventoryManager;
        public TestModifyProduct() => _inventoryManager = new InventoryManager();

        [TestMethod]
        public void TestUpdateProduct()
        {
            int initial_quantity = 1;
            int updated_quantity = 5;

            using StringWriter sw = new();
            Console.SetOut(sw);

            _inventoryManager.AddNewProduct("TestProduct", initial_quantity, 1.23M);
            _inventoryManager.UpdateProduct(1, updated_quantity);
            _inventoryManager.ListProducts();

            string[] results = sw.ToString().Split(',');
            string getLastResult = results[^2];

            Assert.IsFalse(initial_quantity == updated_quantity);
        }

        [TestMethod]
        public void TestUpdateProductEmpty(){
            using StringWriter sw = new();
            Console.SetOut(sw);

            _inventoryManager.UpdateProduct(1, 5);

            Assert.IsTrue(sw.ToString().Contains("Product not found"));
        }

        [TestMethod]
        public void TestUpdateProductRemoved(){
            using StringWriter sw = new();
            Console.SetOut(sw);
            
            _inventoryManager.AddNewProduct("TestProduct", 2, 1.23M);
            _inventoryManager.RemoveProduct(1);
            _inventoryManager.UpdateProduct(1, 5);

            Assert.IsTrue(sw.ToString().Contains("Product not found"));
        }
    }
}
