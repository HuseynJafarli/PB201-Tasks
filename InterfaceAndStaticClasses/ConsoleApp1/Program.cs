using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create a new user:");
            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            string password;
            User user = new User();
            while (true)
            {
                Console.Write("Enter password: ");
                password = Console.ReadLine();
                if (user.PasswordChecker(password))
                {
                    user.FullName = fullName;
                    user.Email = email;
                    user.Password = password;
                    break;
                }
                else
                {
                    Console.WriteLine("Password does not meet the requirements. Please try again.");
                }
            }

            Console.WriteLine("User created successfully!");
            UserMenu(user);
        }

        static void UserMenu(User user)
        {
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Show info");
                Console.WriteLine("2. Create new group");
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        user.ShowInfo();
                        break;
                    case "2":
                        CreateGroupMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void CreateGroupMenu()
        {
            Console.Write("Enter group number: ");
            string groupNo = Console.ReadLine();

            Group group = new Group(groupNo, 0);
            while (!group.CheckGroupNo(groupNo))
            {
                Console.Write("Enter group number: ");
                groupNo = Console.ReadLine();
            }

            int studentLimit;
            Console.Write("Enter student limit (5-18): ");
            studentLimit = Convert.ToInt32(Console.ReadLine());
            group = new Group(groupNo, studentLimit);
            GroupMenu(group);
        }

        static void GroupMenu(Group group)
        {
            while (true)
            {
                Console.WriteLine("\nGroup Menu:");
                Console.WriteLine("1. Show all students");
                Console.WriteLine("2. Get student by id");
                Console.WriteLine("3. Add student");
                Console.WriteLine("0. Quit");
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllStudents(group);
                        break;
                    case "2":
                        GetStudentById(group);
                        break;
                    case "3":
                        AddStudent(group);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void ShowAllStudents(Group group)
        {
            var students = group.GetAllStudents();
            if (students.Length == 0)
            {
                Console.WriteLine("No students in the group.");
            }
            else
            {
                foreach (var student in students)
                {
                    student.StudentInfo();
                }
            }
        }

        static void GetStudentById(Group group)
        {
            Console.WriteLine("Enter student ID: ");
            int id =Convert.ToInt32(Console.ReadLine());

                var student = group.GetStudent(id);
                if (student != null)
                {
                    student.StudentInfo();
                }
                else
                {
                    Console.WriteLine($"Student with ID {id} not found.");
                }
        }

        static void AddStudent(Group group)
        {
            if (group.GetAllStudents().Length >= group.StudentLimit)
            {
                Console.WriteLine("Student limit exceeded. Cannot add more students.");
                return;
            }

            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine();

            int point;

            Console.WriteLine("Enter point: ");
            point = Convert.ToInt32(Console.ReadLine());
                
            var student = new Student
            {
                FullName = fullName,
                Point = point
            };

            group.AddStudent(student);
            Console.WriteLine("Student added successfully!");
        }
    }
}
