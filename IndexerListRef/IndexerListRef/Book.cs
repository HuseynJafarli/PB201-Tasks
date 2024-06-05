using MyHelpers;

namespace IndexerListRef
{
    public class Book
    {
        private static int count;
        public string Name { get; set; }
        public int Id { get; set; }
        public string AuthorName { get; set; }

        public int PageCount { get; set; }



        public string Code { get; set; }

        public Book(string name, string authorName, int pageCount)
        {
            count++;
            Id = count;
            Name = name;
            AuthorName = authorName;
            PageCount = pageCount;
            Code = Helper.CreateBookCode(name , Id);
        }

        public override string ToString()
        {
            return $"Book: {Name} , Author: {AuthorName} , Page Count: {PageCount} , Code: {Code}";
        }

    }
}
