using InventoryMgmt.Model;
using System.ComponentModel.DataAnnotations;

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
                Name = "TestProduct",
                QuantityInStock = 1,
                Price = 1.0M
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
                QuantityInStock = 1,
                Price = 1.0M
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
                QuantityInStock = 1,
                Price = 1.0M
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
                Name = "TestProduct",
                QuantityInStock = -1,
                Price = 1.0M
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);

            Assert.IsFalse(isProductValid);
        }

        [TestMethod]
        public void TestAddProductQuantityLargeNumber()
        {
            Product product = new()
            {
                Name = "TestProduct",
                QuantityInStock = 2147483647,
                Price = 1.0M
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
                Name = "TestProduct",
                QuantityInStock = 1,
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
                Name = "TestProduct",
                QuantityInStock = 1,
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
                Name = "TestProduct",
                QuantityInStock = 1,
                Price = 1.0M
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);

            Assert.IsTrue(isProductValid);
        }
//dotnet test --logger "console;verbosity=detailed" ==filter "TestProductIDZero"
        [TestMethod]
        public void TestProductIDZero()
        {
            Product product = new()
            {
                ProductID = 0,
                Name = "TestProduct",
                QuantityInStock = 1,
                Price = 1.0M
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
                Name = "TestProduct",
                QuantityInStock = 1,
                Price = 1.0M
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);

            Assert.IsTrue(isProductValid);
        }
    }
}