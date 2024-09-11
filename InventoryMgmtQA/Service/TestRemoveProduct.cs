using InventoryMgmt.Model;
using InventoryMgmt.Service;
using InventoryMgmt.Interface;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _inventoryManager.AddNewProduct(
                    "Test Product",
                    1,
                    1.23M
                );
                _inventoryManager.RemoveProduct(1);
                Assert.IsTrue(sw.ToString().Contains("Product removed successfully."));
            }
        }
    }
}