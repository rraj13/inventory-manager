using System;
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
                    DatabaseQuery.DisplayInventory(connection);
                    
                    int counter = 0;
                    
                    ControlFlow.RunProgram(connection, counter);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}

        
