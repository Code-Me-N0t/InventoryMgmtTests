using InventoryMgmt.Service;
using InventoryMgmt.Interface;

// guide: https://www.aligrant.com/web/blog/2020-07-20_capturing_console_outputs_with_microsoft_test_framework

namespace InventoryMgmtQA.Service
{
    [TestClass]
    public class TotalValueTest
    {
        private IInventoryManager _inventoryManager = new InventoryManager();

        [TestMethod]
        public void TestTotalValueOutput()
        {
            using StringWriter sw = new();
            Console.SetOut(sw);
            _inventoryManager.AddNewProduct(
                "TestProduct",
                1,
                2.56M
            );
            _inventoryManager.GetTotalValue();
            Assert.IsTrue(sw.ToString().Contains("2.56"));
        }

        [TestMethod]
        public void TestTotalValueComputation(){
            var quantity1 = 3;
            decimal price1 = 300;

            var quantity2 = 2;
            decimal price2 = 600;

            decimal expected_result = (quantity1 * price1) + (quantity2 * price2);

            using StringWriter sw = new();
            Console.SetOut(sw);

            _inventoryManager.AddNewProduct("TestProduct1", quantity1, price1);
            _inventoryManager.AddNewProduct("TestProduct2", quantity2, price2);

            _inventoryManager.GetTotalValue();

            var actual_result = sw.ToString().Replace(",","");

            Assert.IsTrue(actual_result.Contains(expected_result.ToString()));
        }

        [TestMethod]
        public void TestTotalValueAfterRemoval(){
            var quantity1 = 3;
            decimal price1 = 300;

            var quantity2 = 2;
            decimal price2 = 600;
            decimal product2 = quantity2 * price2;

            using StringWriter sw = new();
            Console.SetOut(sw);

            _inventoryManager.AddNewProduct("TestProduct1", quantity1, price1);
            _inventoryManager.AddNewProduct("TestProduct2", quantity2, price2);
            _inventoryManager.RemoveProduct(1);
            _inventoryManager.GetTotalValue();

            var actual_result = sw.ToString().Replace(",","");

            Assert.IsTrue(actual_result.Contains(product2.ToString()));
        }
    }
}