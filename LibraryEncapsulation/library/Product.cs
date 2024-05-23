namespace library
{
    public class Product
    {
        private double _price;
        private int _count;
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price
        {
            get => _price;
            set
            { 
                if(value > 0)
                    _price = value;
            }
        }
        public int Count
        {
            get => _count;
            set
            {
                if (value > 0)
                    _count = value;
            }
        }





        public Product(int id)
        {
            this.Id = id;
        }
        public Product(int id , string name): this(id)
        {
            this.Name = name;
        }
        public Product(int id, string name , double price) : this(id , name)
        {
            this.Price = price;
        }

    }
}
