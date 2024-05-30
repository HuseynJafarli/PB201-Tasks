namespace ConsoleApp1
{
    public class Student : User
    {
        public int Point { get; set; }
        public void StudentInfo()
        {
            Console.WriteLine($"Student Name: {FullName}, Point: {Point}");
        }
    }
}
