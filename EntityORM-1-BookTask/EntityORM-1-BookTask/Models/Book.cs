namespace EntityORM_1_BookTask.Models
{
    public class Book
    {
        public int Id { get; set; }

        public int GenreId { get; set; }
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal Saleprice { get; set; }

        public Genre Genre { get; set; }

        public override string ToString()
        {
            return $"{Id}|{Name}|{Genre.Name}|{CostPrice}|{Saleprice}";
        }
    }
}
