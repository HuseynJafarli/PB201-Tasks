namespace GroupERP.Core.Models
{
    public class Group : BaseModel
    {
        private static int count;
        public string Name { get; set; }
        public string Code;
        public List<Student> Students = new List<Student>();

        public Group(string name)
        {
            Name = name;
            count++;
            Id = count;
            Code = string.Concat(char.ToUpper(name[0]), char.ToUpper(name[1]), Id.ToString());
        }

        public override string ToString()
        {
            string studentList = Students.Count > 0 ? string.Join(", ", Students.Select(s => s.Fullname)) : "No students";
            return $"Group Id: {Id}, Name: {Name}, Code: {Code}, Students: {studentList}";
        }
    }
}