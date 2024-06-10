namespace GroupERP.Core.Models
{
    public class Student : BaseModel
    {
        private static int count;
        public string Fullname { get; set; }
        public double Grade { get; set; }

        public Group? Group { get; set; }

        public Student(string fullname, double grade)
        {
            Fullname = fullname;
            Grade = grade;
            Group = null;
            count++;
            Id = count;
        }

        public override string ToString()
        {
            return $"Student{Id}: {Fullname} - {Grade} - {(Group is not null ? Group.Name : "No Group")}";
        }
    }
}