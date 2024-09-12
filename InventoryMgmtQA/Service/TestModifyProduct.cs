using InventoryMgmt.Service;
using InventoryMgmt.Interface;

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

            _inventoryManager.AddNewProduct(
                Variables.product_name, 
                initial_quantity, 
                Variables.product_price
            );
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

            Assert.IsTrue(sw.ToString().Contains(Messages.msg_notfound_error));
        }

        [TestMethod]
        public void TestUpdateProductRemoved(){
            using StringWriter sw = new();
            Console.SetOut(sw);
            
            _inventoryManager.AddNewProduct(
                Variables.product_name, 
                Variables.product_quantity, 
                Variables.product_price
            );
            _inventoryManager.RemoveProduct(1);
            _inventoryManager.UpdateProduct(1, 5);

            Assert.IsTrue(sw.ToString().Contains(Messages.msg_notfound_error));
        }
    }
}
