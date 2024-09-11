using InventoryMgmt.Model;
using InventoryMgmt.Service;
using InventoryMgmt.Interface;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

// guide: https://www.aligrant.com/web/blog/2020-07-20_capturing_console_outputs_with_microsoft_test_framework

namespace InventoryMgmtQA.Service
{
    [TestClass]
    public class TotalValueTest
    {
        private IInventoryManager _inventoryManager = new InventoryManager();

        [TestMethod]
        public void TestGetTotalValue()
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
        public void TestGetTotalValueUpdates()
        {
            var quantity1 = 3;
            var price1 = 300;

            var quantity2 = 2;
            var price2 = 600;

            using StringWriter sw = new();
            Console.SetOut(sw);
            _inventoryManager.AddNewProduct(
                "TestProduct",
                3,
                300
            );

            _inventoryManager.AddNewProduct(
                "TestProduct 2",
                2,
                600
            );

            var result1 = quantity1 * price1;
            var result2 = quantity2 * price2;

            var totalResult = Convert.ToDecimal(result1 + result2);

            _inventoryManager.GetTotalValue();
        }

    }
}