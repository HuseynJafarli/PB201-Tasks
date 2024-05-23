namespace library
{
    public class Book : Product
    {
        public string Genre { get; set; }

        public Book(int id) : base(id){ }

        public Book(int id, string name) : base(id, name){ }

        public Book(int id, string name, double price , string genre) : base(id, name, price)
        {
            this.Genre = genre;
        }
    }
}
