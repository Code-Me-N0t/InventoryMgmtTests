using InventoryMgmt.Service;
using InventoryMgmt.Interface;
using InventoryMgmtQA;

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
            _inventoryManager.AddNewProduct(
                Variables.product_name, 
                Variables.product_quantity, 
                Variables.product_price
            );
            Assert.IsTrue(sw.ToString().Contains(Messages.msg_added_success));
        }

        [TestMethod]
        public void TestNewAddedProduct()
        {
            using StringWriter sw = new();
            Console.SetOut(sw);
            _inventoryManager.AddNewProduct(
                Variables.product_name, 
                Variables.product_quantity, 
                Variables.product_price
            );
            _inventoryManager.ListProducts();
            Assert.IsTrue(sw.ToString().Contains(Variables.product_name));
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
            _inventoryManager.AddNewProduct(
                "", 
                Variables.product_quantity,
                Variables.product_price
            );
            _inventoryManager.ListProducts();
            Assert.IsTrue(sw.ToString().Contains(Messages.msg_name_error));
        }

        [TestMethod]
        public void TestProductNameWhitespace()
        {
            using StringWriter sw = new();
            Console.SetOut(sw);
            _inventoryManager.AddNewProduct(
                " ", 
                Variables.product_quantity, 
                Variables.product_price
            );
            _inventoryManager.ListProducts();
            Assert.IsTrue(sw.ToString().Contains(Messages.msg_name_error));
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
            _inventoryManager.AddNewProduct(
                Variables.product_name,
                -1, 
                Variables.product_price
            );
            Assert.IsTrue(sw.ToString().Contains(Messages.msg_number_error));
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
            _inventoryManager.AddNewProduct(
                Variables.product_name, 
                Variables.product_quantity, 
                -1.0M
            );
            Assert.IsTrue(sw.ToString().Contains(Messages.msg_number_error));
        }
    }
}
