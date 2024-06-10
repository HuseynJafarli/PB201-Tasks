using GroupERP.Business.Services.Interfaces;
using GroupERP.Business.Services.Implementations;
using GroupERP.Core.Models;
using GroupERP.Business.Services.Controller;
using GroupERP.Data.DAL;
using System.Collections.Concurrent;

namespace GroupERPCA
{
    public class Program
    {
        static void Main(string[] args)
        {
            

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Group Operations:");
                Console.WriteLine("2. Student Operations:");
                Console.WriteLine("3. Add student to group()");
                Console.WriteLine("0. Exit");

                Console.Write("\nSelect an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GroupOperations();
                        break;
                    case "2":
                        StudentOperations();
                        break;
                    case "3":
                        AddStudentToGroup();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void GroupOperations()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Group Operations:");
                Console.WriteLine("1. Create() Group");
                Console.WriteLine("2. Get() Group");
                Console.WriteLine("3. GetAll() Groups");
                Console.WriteLine("4. Remove() Group");
                Console.WriteLine("5. Exit");

                Console.Write("\nSelect an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Controller.CreateGroup();
                        break;
                    case "2":
                        Controller.GetGroupById();
                        break;
                    case "3":
                        Controller.GetAllGroups();
                        break;
                    case "4":
                        Controller.RemoveGroup();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void StudentOperations()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Student Operations:");
                Console.WriteLine("1. Create() Student");
                Console.WriteLine("2. Get() Student");
                Console.WriteLine("3. GetAll() Students");
                Console.WriteLine("4. Remove() Student");
                Console.WriteLine("5. Exit");

                Console.Write("\nSelect an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Controller.CreateStudent();
                        break;
                    case "2":
                        Controller.GetStudentById();
                        break;
                    case "3":
                        Controller.GetAllStudents();
                        break;
                    case "4":
                        Controller.RemoveStudent();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddStudentToGroup()
        {
            IGroupServices groupServices = new GroupServices();
            Console.Clear();
            Console.WriteLine("Add student to group:");

            Console.WriteLine("Available groups:");
            var avalibleGroups = groupServices.GetAll();
            if (avalibleGroups.Count == 0)
            {
                Console.WriteLine("There are no groups in the system.");
                Console.WriteLine("Press any key to return to main menu...");
                Console.ReadKey();
                return;
            }
            avalibleGroups.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Please choose a group by entering the corresponding number: ");

            int groupChoice;
            while (!int.TryParse(Console.ReadLine(), out groupChoice) || groupChoice < 1 || groupChoice > GroupData.Groups.Count)
            {
                Console.Write("Invalid input. Enter a valid group number: ");
            }

            Group chosenGroup = GroupData.Groups[groupChoice - 1];
            Console.WriteLine($"You chose the group: {chosenGroup.Name}");

            Console.WriteLine("Here is the list of students without a group: ");
            var studentsWithoutGroup = GroupData.Students.FindAll(x => x.Group == null);

            if (studentsWithoutGroup.Count == 0)
            {
                Console.WriteLine("There are no students without a group.");
            }
            else
            {
                for (int i = 0; i < studentsWithoutGroup.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {studentsWithoutGroup[i]}");
                }

                Console.WriteLine("Please choose a student by entering the corresponding number: ");
                int studentChoice;
                while (!int.TryParse(Console.ReadLine(), out studentChoice) || studentChoice < 1 || studentChoice > studentsWithoutGroup.Count)
                {
                    Console.Write("Invalid input. Enter a valid student number: ");
                }

                Student chosenStudent = studentsWithoutGroup[studentChoice - 1];
                chosenStudent.Group = chosenGroup;
                chosenGroup.Students.Add(chosenStudent);
                Console.WriteLine($"You successfully added {chosenStudent.Fullname} to the group {chosenGroup.Name}");
            }

            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
        }

    }
}
