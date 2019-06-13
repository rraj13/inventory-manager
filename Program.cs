using System;
using System.Text;
using System.Data.SqlClient;

namespace inventory_manager
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost";   
                builder.UserID = "sa";              
                builder.Password = "laCA1995$";      
                builder.InitialCatalog = "master";

                // Connect to SQL
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    
                    Console.WriteLine("Apple Product Inventory Manager");
                    
                    // Display inventory on load
                    DisplayInventory(connection);

                    int counter = 0;
                    
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

                        // Add product
                        if (userCommand.ToLower() == "add product")
                        {
                            counter++;
                            
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
                            counter++;

                            Console.Write("Please enter the ID of the product you would like to update. ");
                            int productID = int.Parse(Console.ReadLine());

                            Console.Write("Please enter the field you would like to update. (name, description, department, price, quantity) ");
                            string desiredField = Console.ReadLine();


                            if (desiredField == "name") 
                            {
                                UpdateDataStringField(connection, desiredField, productID);
                            } 
                            else if (desiredField == "description")
                            {
                                UpdateDataStringField(connection, desiredField, productID);
                            } 
                            else if (desiredField == "department")
                            {
                                UpdateDataStringField(connection, desiredField, productID);
                            }
                            else if (desiredField == "price")
                            {
                                UpdateDataDoubleField(connection, desiredField, productID);
                            }
                            else if (desiredField == "quantity")
                            {
                                UpdateDataIntegerField(connection, desiredField, productID);
                                
                            }  
                        }
                        else if (userCommand.ToLower() == "delete product")
                        {
                            counter++;
                            
                            Console.Write("Please enter the ID of the product you would like to delete. ");
                            int productID = int.Parse(Console.ReadLine());
                            DeleteProduct(connection, productID);
                        }
                        else if (userCommand.ToLower() == "view all inventory") 
                        {
                            counter++;
                            DisplayInventory(connection);
                        }
                        else if (userCommand.ToLower() == "exit")
                        {
                            counter = 0;
                            return;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
    
        }

        public static void DisplayInventory(SqlConnection connection) 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("USE inventoryDB; ");
            sb.Append("SELECT * FROM products;");  
            String sql = sb.ToString();

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("ID: {0}\nNAME: {1}\nDESCRIPTION: {2}\nDEPARTMENT: {3}\nPRICE: {4}\nQUANTITY: {5}", 
                        reader.GetInt32(0), 
                        reader.GetString(1), 
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetDouble(4),
                        reader.GetInt32(5));
                    }
                }
            }
            Console.WriteLine("-------------------------");
        }

        public static void UpdateDataStringField(SqlConnection connection, string desiredField, int productID)
        {
            Console.Write($"Please enter the new {desiredField}. ");
            string newValue = $"'{Console.ReadLine()}'";

            StringBuilder sb = new StringBuilder();
            sb.Append("USE inventoryDB; ");
            sb.Append($"UPDATE products SET {desiredField}  = {newValue} WHERE id = {productID}");
            String sql  = sb.ToString();

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Product field updated.");
            }
        }

        public static void UpdateDataIntegerField(SqlConnection connection, string desiredField, int productID)
        {
            Console.Write($"Please enter the new {desiredField}: ");
            int newValue = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            sb.Append("USE inventoryDB; ");
            sb.Append($"UPDATE products SET {desiredField} = {newValue} WHERE id = {productID}");
            String sql  = sb.ToString();

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Product field updated.");
            }
        }

        public static void UpdateDataDoubleField(SqlConnection connection, string desiredField, int productID)
        {
            Console.Write($"Please enter the new {desiredField}: ");
            double newValue = double.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            sb.Append("USE inventoryDB; ");
            sb.Append($"UPDATE products SET {desiredField} = {newValue} WHERE id = {productID}");
            String sql  = sb.ToString();

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Product field updated.");
            }
        }

        public static void DeleteProduct(SqlConnection connection, int productID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("USE inventoryDB; ");
            sb.Append($"DELETE FROM products WHERE id = {productID};");
            String sql = sb.ToString();

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Product deleted.");
            }
        }
    }
}
        
