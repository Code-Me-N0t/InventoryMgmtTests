using InventoryMgmt.Service;
using InventoryMgmt.Interface;

// guide: https://www.aligrant.com/web/blog/2020-07-20_capturing_console_outputs_with_microsoft_test_framework

namespace InventoryMgmtQA.Service
{
    [TestClass]
    public class RemoveProductTest
    {
        private IInventoryManager _inventoryManager = new InventoryManager();

        [TestMethod]
        public void TestRemoveProduct()
        {
            using StringWriter sw = new();
            Console.SetOut(sw);
            _inventoryManager.AddNewProduct(
                "Test Product",
                1,
                1.23M
            );
            _inventoryManager.RemoveProduct(1);
            Assert.IsTrue(sw.ToString().Contains("Product removed successfully."));
        }

        [TestMethod]
        public void TestRemoveProductNotFound()
        {
            using StringWriter sw = new();
            Console.SetOut(sw);
            _inventoryManager.RemoveProduct(1);
            Assert.IsTrue(sw.ToString().Contains("Product not found, please try again."));
        }

        [TestMethod]
        public void TestRemoveProductZeroID()
        {
            using StringWriter sw = new();
            var originalOut = Console.Out;

            Console.SetOut(sw);
            _inventoryManager.AddNewProduct(
                "Test Product",
                1,
                1.23M
            );
            _inventoryManager.RemoveProduct(0);
            Console.SetOut(originalOut);

            Console.WriteLine(sw.ToString());
            
            Assert.IsTrue(sw.ToString().Contains("Product not found"));
        }
    }
}