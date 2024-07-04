namespace EntityORM_1_BookTask.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        List<Book> books { get; set; } = new List<Book>();

        public override string ToString()
        {
            return $"{Id}|{Name}";
        }
    }
}
