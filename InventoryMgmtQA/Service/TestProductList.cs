using InventoryMgmt.Service;
using InventoryMgmt.Interface;

namespace InventoryMgmtQA.Service
{
    [TestClass]
    public class ProductListTest
    {
        private IInventoryManager _inventoryManager;
        public ProductListTest() => _inventoryManager = new InventoryManager();

        [TestMethod]
        public void TestViewProductList()
        {
            string product_name = Variables.product_name;
            int product_quantity = Variables.product_quantity;
            decimal product_price = Variables.product_price;

            using StringWriter sw = new();
            Console.SetOut(sw);

            _inventoryManager.AddNewProduct(
                product_name, 
                product_quantity, 
                product_price);
            _inventoryManager.ListProducts();

            string[] results = sw.ToString().Split(',');
            string getName = results[1];
            string getQuantity = results[2];
            string getPrice = results[3];

            Assert.IsTrue(getName.Contains(product_name));            
            Assert.IsTrue(getQuantity.Contains(product_quantity.ToString()));
            Assert.IsTrue(getName.Contains(product_name.ToString()));            
        }

        [TestMethod]
        public void TestViewUpdatedProductList(){
            string product_name = Variables.product_name;
            int initial_quantity = 4;
            int updated_quantity = 1;
            decimal product_price = Variables.product_price;

            using StringWriter sw = new();
            Console.SetOut(sw);

            _inventoryManager.AddNewProduct(product_name, initial_quantity, product_price);
            _inventoryManager.ListProducts();

            string[] results = sw.ToString().Split(',');
            string getQuantity = results[^2];

            Assert.IsTrue(getQuantity.Contains(initial_quantity.ToString()));


            using StringWriter sw2 = new();
            Console.SetOut(sw2);

            _inventoryManager.UpdateProduct(1, updated_quantity);
            _inventoryManager.ListProducts();

            string[] results2 = sw2.ToString().Split(',');
            string getQuantity2 = results2[^2];

            Assert.IsTrue(getQuantity2.Contains(updated_quantity.ToString()));
        }

        [TestMethod]
        public void TestProductListAfterRemoval(){
            string product_name = "TestProduct";
            int product_quantity = 4;
            decimal product_price = 1.23M;

            using StringWriter sw = new();
            Console.SetOut(sw);

            _inventoryManager.AddNewProduct(product_name, product_quantity, product_price);
            _inventoryManager.RemoveProduct(1);
            _inventoryManager.ListProducts();

            Assert.IsTrue(sw.ToString().Contains(Messages.msg_list_error));
        }

        [TestMethod]
        public void TestProductListIDAfterRemoval(){
            int product_id = 1;
            string product_name = "Product 1";
            int product_quantity = 4;
            decimal product_price = 1.23M;

            // int product_id2 = 2;
            string product_name2 = "Product 2";
            int product_quantity2 = 3;
            decimal product_price2 = 30;

            using StringWriter sw = new();
            Console.SetOut(sw);

            _inventoryManager.AddNewProduct(product_name, product_quantity, product_price);
            _inventoryManager.AddNewProduct(product_name2, product_quantity2, product_price2);
            _inventoryManager.RemoveProduct(1);
            _inventoryManager.ListProducts();

            string[] results = sw.ToString().Split(',');
            string[] getlast = results[^4].Split("\n");
            string getID = getlast[^1];
            string getName = results[^3];
            string getQuantity = results[^2];
            string getPrice = results[^1];

            Assert.IsFalse(getID.Contains(product_id.ToString()));
            Assert.IsFalse(getName.Contains(product_name));
            Assert.IsFalse(getQuantity.Contains(product_quantity.ToString()));
            Assert.IsFalse(getPrice.Contains(product_price.ToString()));
        }
    }
}
