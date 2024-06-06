namespace SchoolERP.Core.Models
{
    public class Student: BaseModel
    {
        private static int _count;
       public string Fullname { get; set; }
        public double Grade { get; set; }
        public Teacher Teacher { get; set; }

        public int TeacherId { get; set; }

        public Student(string fullname, double grade , Teacher teacher)
        {
            Fullname = fullname;
            Grade = grade;
            Id = ++_count;
            Teacher = teacher;
            TeacherId = teacher.Id;
        }

        public override string ToString()
        {
            return $"Student datas: {Id} - {Fullname} - {Grade} - {Teacher.Fullname}";
        }
    }
}
