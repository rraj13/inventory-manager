using System;
using System.Text;
using System.Data.SqlClient;

namespace inventory_manager
{
    public class DatabaseQuery
    {
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