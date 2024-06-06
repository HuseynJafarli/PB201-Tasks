namespace SchoolERP.Core.Models
{
    public class Teacher: BaseModel
    {
        private static int _count;
        public string Fullname { get; set; }
        public double Salary { get; set; }

        public List<Student> Students = [];

        public Teacher(string fullname , double salary) 
        {
            Fullname = fullname;
            Salary = salary;
            Id = ++_count;
        }

        public override string ToString() 
        { 
            return $"Teacher datas: {Id} - {Fullname} - {Salary}";
        }

    }
}
