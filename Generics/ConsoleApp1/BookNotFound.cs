namespace ConsoleApp1
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(string code) : base($"Book with code '{code}' not found.") 
        {
        
        }
    }

}
