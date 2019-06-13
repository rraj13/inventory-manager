namespace inventory_manager
{
    class Product
    {
        
        private string _name { get; set; }
        private string _description { get; set; }

        private string _department { get; set; }

        private double _price { get; set; }

        private int _quantity { get; set; }

        public Product(string name, string description, string department, double price, int quantity)
        {
            _name = name;
            _description = description;
            _department = department;
            _price = price;
            _quantity = quantity;
        }

        public string getProductName() { return this._name; }
        public string getProductDesc() { return this._description; }
        public string getProductDept() { return this._department; }
        public double getProductPrice() { return this._price; }
        public int getProductQuantity() { return this._quantity;}
    }
}