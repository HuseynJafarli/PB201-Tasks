using GroupERP.Business.Services.Implementations;
using GroupERP.Business.Services.Interfaces;
using GroupERP.Core.Models;

namespace GroupERP.Business.Services.Controller
{
    public static class Controller
    {
        static IStudentServices studentServices = new StudentServices();
        static IGroupServices groupServices = new GroupServices();
        public static void CreateStudent()
        {
            Console.Clear();
            Console.WriteLine("Creating Student:");

            Console.Write("Enter fullname: ");
            string fullname = Console.ReadLine();

            Console.Write("Enter grade: ");
            double grade;
            while (!double.TryParse(Console.ReadLine(), out grade))
            {
                Console.Write("Invalid input. Enter a numeric grade: ");
            }

            Group selectedGroup = null;

            Student newStudent = new Student(fullname, grade);

            studentServices.Create(newStudent);
            Console.WriteLine($"Student created: {newStudent}");

            Console.WriteLine("Press any key to return to student menu...");
            Console.ReadKey();


        }
        public static void GetStudentById()
        {
            Console.Clear();
            Console.WriteLine("Please enter integer Id to find the student with the corresponding Id.");
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Invalid input. Enter a numeric grade: ");
            }
            try
            {
                Console.WriteLine(studentServices.Get(choice));

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("Press any key to return to student menu...");
            Console.ReadKey();
        }

        public static void GetAllStudents()
        {
            Console.Clear();
            Console.WriteLine("Gathering all students...");
            studentServices.GetAll().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("Press any key to return to student menu...");
            Console.ReadKey();
        }

        public static void RemoveStudent()
        {
            Console.Clear();
            Console.WriteLine("Please enter Id of the student you want to remove: ");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Invalid input. Enter a numeric grade: ");
            }

            try
            {
                studentServices.Remove(choice);

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void CreateGroup()
        {
            Console.Clear();
            Console.WriteLine("Creating Group:");

            Console.Write("Enter Group Name: ");
            string name = Console.ReadLine();
            while (true)
            {
                if (name != null)
                {
                    Group newGroup = new Group(name);
                    groupServices.Create(newGroup);
                    Console.WriteLine($"Group created: {newGroup}");
                    break;
                }
                else 
                {
                    Console.WriteLine("Invalid name type. Please try again: ");
                    name = Console.ReadLine();
                }
            }

            Console.WriteLine("Press any key to return to group menu...");
            Console.ReadKey();

        }

        public static void GetGroupById()
        {
            Console.Clear();
            Console.WriteLine("Please enter integer Id to find the group with the corresponding Id.");
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Invalid input. Enter a numeric grade: ");
            }
            try
            {
                Console.WriteLine(groupServices.Get(choice));

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("Press any key to return to group menu...");
            Console.ReadKey();
        }

        public static void GetAllGroups()
        {
            Console.Clear();
            Console.WriteLine("Gathering all groups...");
            groupServices.GetAll().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("Press any key to return to group menu...");
            Console.ReadKey();
        }

        public static void RemoveGroup()
        {
            Console.Clear();
            Console.WriteLine("Please enter Id of the group you want to remove: ");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Invalid input. Enter a numeric grade: ");
            }

            try
            {
                groupServices.Remove(choice);
                Console.WriteLine("Group removed successfully.");

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
