namespace InventoryMgmtQA
{
    public static class Variables{
        public static string product_name = "Product Name";
        public static int product_quantity = 40;
        public static decimal product_price = 1.23M;
    }
    public static class Messages{
        public static string msg_added_success = "Product added successfully.";
        public static string msg_removed_success = "Product removed successfully.";
        public static string msg_name_error = "Name should not be empty";
        public static string msg_number_error = "must be greater than or equal to 0.";
        public static string msg_notfound_error = "Product not found, please try again";
        public static string msg_list_error = "No products in here.";
        public static string msg_invalid_error = "Invalid operation! Please try again.";
    }
}