namespace ConsoleApp1
{
    public class Group
    {
        private int _studentLimit;
        private Student[] _students;

        public string GroupNo { get; set; }

        public int StudentLimit
        {
            get => _studentLimit;
            set
            {
                if (value >= 5 && value <= 18)
                {
                    _studentLimit = value;
                }
                else
                {
                    Console.WriteLine("Limit must be between 5 and 18");
                }
            }
        }

        public Group(string groupNo, int studentLimit)
        {
            if (!CheckGroupNo(groupNo))
            {
                Console.WriteLine("Invalid Group Number.");
            }

            GroupNo = groupNo;
            StudentLimit = studentLimit;
            _students = Array.Empty<Student>();
        }

        public bool CheckGroupNo(string groupNo)
        {
            if (groupNo.Length != 5) return false;

            for (int i = 0; i < 2; i++)
            {
                if (!char.IsUpper(groupNo[i])) return false;
            }

            for (int i = 2; i < 5; i++)
            {
                if (!char.IsDigit(groupNo[i])) return false;
            }

            return true;
        }

        public void AddStudent(Student student)
        {
            if (_students.Length >= StudentLimit)
            {
                Console.WriteLine("Student limit exceeded.");
            }

            Array.Resize(ref _students, _students.Length + 1);
            _students[_students.Length - 1] = student;
        }

        public Student? GetStudent(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Id cant be null");
            }

            foreach (var student in _students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }

        public Student[] GetAllStudents()
        {
            return _students;
        }
    }
}
