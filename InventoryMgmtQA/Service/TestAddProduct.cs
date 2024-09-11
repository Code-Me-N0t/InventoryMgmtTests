using InventoryMgmt.Service;
using InventoryMgmt.Interface;
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InventoryMgmtQA.Service
{
    [TestClass]
    public class ProductTest
    {
        private IInventoryManager _inventoryManager;
        public ProductTest() => _inventoryManager = new InventoryManager();

        [TestMethod]
        public void TestAddProduct()
        {
            using StringWriter sw = new();
            Console.SetOut(sw);
            _inventoryManager.AddNewProduct("TestProduct", 1, 1.23M);
            Assert.IsTrue(sw.ToString().Contains("success"));
        }

        [TestMethod]
        public void TestNewAddedProduct()
        {
            using StringWriter sw = new();
            Console.SetOut(sw);
            _inventoryManager.AddNewProduct("Newly Added Product", 1, 1.23M);
            _inventoryManager.ListProducts();
            Assert.IsTrue(sw.ToString().Contains("Newly Added Product"));
        }
    }

    [TestClass]
    public class ProductNameErrorMessageTest
    {
        private IInventoryManager _inventoryManager;

        public ProductNameErrorMessageTest() => _inventoryManager = new InventoryManager();

        [TestMethod]
        public void TestProductNameEmpty()
        {
            using StringWriter sw = new();
            Console.SetOut(sw);
            _inventoryManager.AddNewProduct("", 1, 1.23M);
            _inventoryManager.ListProducts();
            Assert.IsTrue(sw.ToString().Contains("Name should not be empty"));
        }

        [TestMethod]
        public void TestProductNameWhitespace()
        {
            using StringWriter sw = new();
            Console.SetOut(sw);
            _inventoryManager.AddNewProduct(" ", 1, 1.23M);
            _inventoryManager.ListProducts();
            Assert.IsTrue(sw.ToString().Contains("Name should not be empty"));
        }
    }

    [TestClass]
    public class ProductQuantityErrorMessageTest
    {
        private IInventoryManager _inventoryManager;
        public ProductQuantityErrorMessageTest() => _inventoryManager = new InventoryManager();

        [TestMethod]
        public void TestProductQuantityNegative()
        {
            using StringWriter sw = new();
            Console.SetOut(sw);
            _inventoryManager.AddNewProduct("TestProduct", -1, 1);
            Assert.IsTrue(sw.ToString().Contains("Quantity must be greater than or equal to 0."));
        }
    }

    [TestClass]
    public class ProductPriceErrorMessageTest
    {
        private IInventoryManager _inventoryManager;
        public ProductPriceErrorMessageTest() => _inventoryManager = new InventoryManager();

        [TestMethod]
        public void TestProductPriceNegative()
        {
            using StringWriter sw = new();
            Console.SetOut(sw);
            _inventoryManager.AddNewProduct("TestProduct", 1, -1.0M);
            Assert.IsTrue(sw.ToString().Contains("Price must be greater than or equal to 0."));
        }
    }
}
