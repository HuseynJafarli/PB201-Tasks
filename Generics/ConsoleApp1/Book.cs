namespace ConsoleApp1
{
    public class Book
    {
        private static int count;
        public string Name { get; set; }
        public string AuthorName { get; set; }

        public int PageCount { get; set; }

        public string Code { get; set;}

        public Book(string name , string authorName , int pageCount) 
        {
            count++;
            Name = name;
            AuthorName = authorName;
            PageCount = pageCount;
            Code = string.Concat(char.ToUpper(name[0]), char.ToUpper(name[1]), count.ToString());
        }

        public override string ToString()
        {
            return $"Book: {Name} , Author: {AuthorName} , Page Count: {PageCount} , Code: {Code}";
        }

    }
}
