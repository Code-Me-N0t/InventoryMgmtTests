using InventoryMgmt.Model;
using System.ComponentModel.DataAnnotations;
using InventoryMgmtQA;

// guide: https://learn.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022

namespace InventoryMgmtQA.Model
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void TestAddProduct()
        {
            // create a new product with compliant attribute values
            Product product = new()
            {
                Name = Variables.product_name,
                QuantityInStock = Variables.product_quantity,
                Price = Variables.product_price
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);

            // the product must be valid since all attributes values validated correctly
            Assert.IsTrue(isProductValid);
        }

        [TestMethod]
        public void TestProductNameEmpty()
        {
            Product product = new()
            {
                Name = "",
                QuantityInStock = Variables.product_quantity,
                Price = Variables.product_price
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);

            Assert.IsFalse(isProductValid);
        }

        [TestMethod]
        public void TestProductNameWhitespace()
        {
            Product product = new()
            {
                Name = " ",
                QuantityInStock = Variables.product_quantity,
                Price = Variables.product_price
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);

            Assert.IsFalse(isProductValid);
        }

        [TestMethod]
        public void TestAddProductQuantityNegative()
        {
            Product product = new()
            {
                Name = Variables.product_name,
                QuantityInStock = -1,
                Price = Variables.product_price
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);

            Assert.IsFalse(isProductValid);
        }

        [TestMethod]
        public void TestAddProductQuantityLargeNumber()
        {
            int Quantity = 2147483647;

            Product product = new()
            {
                Name = Variables.product_name,
                QuantityInStock = Quantity,
                Price = Variables.product_price
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);

            Assert.IsTrue(isProductValid);
        }

        [TestMethod]
        public void TestAddProductPriceNegative()
        {
            Product product = new()
            {
                Name = Variables.product_name,
                QuantityInStock = Variables.product_quantity,
                Price = -1.0M
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);

            Assert.IsFalse(isProductValid);
        }

        [TestMethod]
        public void TestAddProductPriceLargeDecimal()
        {
            Product product = new()
            {
                Name = Variables.product_name,
                QuantityInStock = Variables.product_quantity,
                Price = 1.79228162514264337593543950335m
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);

            Assert.IsTrue(isProductValid);
        }

        [TestMethod]
        public void TestProductIDValid()
        {
            Product product = new()
            {
                ProductID = 1,
                Name = Variables.product_name,
                QuantityInStock = Variables.product_quantity,
                Price = Variables.product_price
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);

            Assert.IsTrue(isProductValid);
        }

        [TestMethod]
        public void TestProductIDZero()
        {
            Product product = new()
            {
                ProductID = 0,
                Name = Variables.product_name,
                QuantityInStock = Variables.product_quantity,
                Price = Variables.product_price
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);

            Assert.IsTrue(isProductValid);
        }

        [TestMethod]
        public void TestProductIDNegative()
        {
            Product product = new()
            {
                ProductID = -1,
                Name = Variables.product_name,
                QuantityInStock = Variables.product_quantity,
                Price = Variables.product_price
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);

            Assert.IsTrue(isProductValid);
        }
    }
}