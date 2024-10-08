using InventoryMgmt.Service;
using InventoryMgmt.Interface;
using InventoryMgmt;

// guide: https://www.aligrant.com/web/blog/2020-07-20_capturing_console_outputs_with_microsoft_test_framework

namespace InventoryMgmtQA.Service
{
    [TestClass]
    public class TestLobby
    {
        private IOperationManager _operationManager = new OperationManager();

        [TestMethod]
        public void TestNavigateAddProduct(){
            string input = "TestProduct\n10\n99.99\n";
            using StringReader stringReader = new(input);
            Console.SetIn(stringReader);

            using StringWriter sw = new();
            Console.SetOut(sw);

            _operationManager.StartOperation(1);

            string output = sw.ToString();

            Assert.IsTrue(output.Contains("Add a product"));
        }

        [TestMethod]
        public void TestNavigateRemoveProduct(){
            string input = "1";
            using StringReader stringReader = new(input);
            Console.SetIn(stringReader);

            using StringWriter sw = new();
            Console.SetOut(sw);

            _operationManager.StartOperation(2);

            string output = sw.ToString();

            Assert.IsTrue(output.Contains("Remove a product"));
        }

        [TestMethod]
        public void TestNavigateModifyProduct(){
            string input = "1\n1";
            using StringReader stringReader = new(input);
            Console.SetIn(stringReader);

            using StringWriter sw = new();
            Console.SetOut(sw);

            _operationManager.StartOperation(3);

            string output = sw.ToString();

            Assert.IsTrue(output.Contains("Update a product"));
        }

        [TestMethod]
        public void TestNavigateGetTotalValue(){

            using StringWriter sw = new();
            Console.SetOut(sw);

            _operationManager.StartOperation(4);

            string output = sw.ToString();

            Assert.IsTrue(output.Contains("Total value of inventory"));
        }

        [TestMethod]
        public void TestNavigateListProducts(){

            using StringWriter sw = new();
            Console.SetOut(sw);

            _operationManager.StartOperation(5);

            string output = sw.ToString();

            Assert.IsTrue(output.Contains(Messages.msg_list_error));
        }

        [TestMethod]
        public void TestNavigateInvalidInput(){
            string input = "0";
            using StringReader stringReader = new(input);
            Console.SetIn(stringReader);
            using StringWriter sw = new();
            Console.SetOut(sw);

            var exception = Assert.ThrowsException<InvalidOperationException>(() =>
            {
                _operationManager.StartOperation(0);
            });

            Assert.IsTrue(exception.Message.Contains(Messages.msg_invalid_error));
        }
    }
}