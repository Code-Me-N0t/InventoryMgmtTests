// See https://aka.ms/new-console-template for more information
using InventoryMgmt.Interface;
using InventoryMgmt.Service;

Console.WriteLine("Welcome to HuanLe Noodles Pte. Ltd. inventory management system.");
Console.WriteLine("");
IOperationManager _operationManager = new OperationManager();

while (true)
{
    try
    {
        Console.WriteLine("Press 1 to add a product");
        Console.WriteLine("Press 2 to remove a product");
        Console.WriteLine("Press 3 to modify a product");
        Console.WriteLine("Press 4 to get total value of inventory");
        Console.WriteLine("Press 5 to get list of products");
        Console.WriteLine("----------------------------------------------------------");

        // read user input and start inventory management operations
        Console.Write("Enter here: ");
        int operationNo = Convert.ToInt32(Console.ReadLine());
        _operationManager.StartOperation(operationNo);
    }
    catch
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input, please try again.");
        Console.ResetColor();
    }
    Console.WriteLine("***");
    Console.WriteLine("");
}

