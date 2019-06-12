using System;
using System.Text;
using System.Data.SqlClient;

namespace inventory_manager
{
    class Item 
    {
        public string _name;
        public string _description;

        public string _department;

        public double _price;

        public int _quantity;

        public Item(string name, string description, string department, double price, int quantity)
        {
            _name = name;
            _description = description;
            _department = department;
            _price = price;
            _quantity = quantity;
        }
    }
}