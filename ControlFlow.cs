using System;
using System.Text;
using System.Data.SqlClient;

namespace inventory_manager
{
    public class ControlFlow
    {
        public static void RunProgram(SqlConnection connection, int counter)
        {
            while(true)
            {

                if (counter == 0)
                {
                    Console.Write("Please enter a command: Add product | Update product | Delete product or type EXIT to close. ");
                }
                else 
                {
                    Console.Write("Please enter a command: View All Inventory | Add product | Update product | Delete product or type EXIT to close. ");
                }
        
                string userCommand = Console.ReadLine();
                
                counter++;
                // Add product
                if (userCommand.ToLower() == "add product")
                {

                    Console.Write("Enter product name: ");
                    string name = Console.ReadLine();
                    
                    Console.Write("Enter product description: ");
                    string description = Console.ReadLine();

                    Console.Write("Enter product department: ");
                    string department = Console.ReadLine();

                    Console.Write("Enter product price: ");
                    double price = double.Parse(Console.ReadLine());

                    Console.Write("Enter product quantity: ");
                    int quantity = int.Parse(Console.ReadLine());

                    //create new item object
                    Product newItem = new Product(name, description, department, price, quantity);

                    StringBuilder sb = new StringBuilder();
                    sb.Append("USE inventoryDB; ");
                    sb.Append("INSERT INTO products (name, description, department, price, quantity) VALUES ");
                    sb.Append($"(N'{newItem.getProductName()}', N'{newItem.getProductDesc()}', N'{newItem.getProductDept()}', {newItem.getProductPrice()}, {newItem.getProductQuantity()}); ");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Product added!");
                    }
                }
                // Update product 
                else if (userCommand == "update product") 
                {

                    Console.Write("Please enter the ID of the product you would like to update. ");
                    int productID = int.Parse(Console.ReadLine());

                    Console.Write("Please enter the field you would like to update. (name, description, department, price, quantity) ");
                    string desiredField = Console.ReadLine();


                    if (desiredField == "name") 
                    {
                        DatabaseQuery.UpdateDataStringField(connection, desiredField, productID);
                    } 
                    else if (desiredField == "description")
                    {
                        DatabaseQuery.UpdateDataStringField(connection, desiredField, productID);
                    } 
                    else if (desiredField == "department")
                    {
                        DatabaseQuery.UpdateDataStringField(connection, desiredField, productID);
                    }
                    else if (desiredField == "price")
                    {
                        DatabaseQuery.UpdateDataDoubleField(connection, desiredField, productID);
                    }
                    else if (desiredField == "quantity")
                    {
                        DatabaseQuery.UpdateDataIntegerField(connection, desiredField, productID);
                        
                    }  
                }
                else if (userCommand.ToLower() == "delete product")
                {
                    
                    Console.Write("Please enter the ID of the product you would like to delete. ");
                    int productID = int.Parse(Console.ReadLine());
                    DatabaseQuery.DeleteProduct(connection, productID);
                }
                else if (userCommand.ToLower() == "view all inventory") 
                {
                    DatabaseQuery.DisplayInventory(connection);
                }
                else if (userCommand.ToLower() == "exit")
                {
                    counter = 0;
                    return;
                }
            }
        }
    }
}
