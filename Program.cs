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
                Console.WriteLine("Connect to SQL Server and demo Create, Read, Update and Delete operations.");

                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost";   
                builder.UserID = "sa";              
                builder.Password = "laCA1995$";      
                builder.InitialCatalog = "master";

                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connected to inventory database.");
                    Console.WriteLine("What would you like to do? View all inventory/Add product/Update product/Delete product");

                    string userCommand = Console.ReadLine();

                    //add product
                    
                    if (userCommand.ToLower() == "add product")
                    {
                        Console.Write("Enter product name: ");
                        string name = Console.ReadLine();
                        
                        Console.Write("Enter product description: ");
                        string description = Console.ReadLine();

                        Console.Write("Enter product department: ");
                        string department = Console.ReadLine();

                        Console.Write("Enter product price: ");
                        double price = int.Parse(Console.ReadLine());

                        Console.Write("Enter product quantity: ");
                        int quantity = int.Parse(Console.ReadLine());

                        //create new item object
                        Item newItem = new Item(name, description, department, price, quantity);

                        StringBuilder sb = new StringBuilder();
                        sb.Append("USE inventoryDB; ");
                        sb.Append("INSERT INTO products (name, description, department, price, quantity) VALUES ");
                        sb.Append($"(N'{newItem._name}', N'{newItem._description}', N'{newItem._department}', {newItem._price}, {newItem._quantity}); ");
                        String sql = sb.ToString();

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine("Product added!");
                        }

                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }



        }
    }
}
        
