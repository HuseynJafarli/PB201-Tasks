using SchoolERP.Business.Services.Implementations;
using SchoolERP.Business.Services.Interfaces;
using SchoolERP.Core.Models;

namespace SchoolERP.CA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStudentService studentService = new StudentService();
            ITeacherService teacherService = new TeacherService();

            Teacher teacher1 = new("Scorpion", 10000);
            Teacher teacher2 = new("Jax", 8000);
            Teacher teacher3 = new("Kenshi", 6000);

            Student student1 = new("Lui Kang", 89, teacher1);
            Student student2 = new("Sonya Blade" , 100 , teacher2);
            Student student3 = new("Johnny Cage" , 65 , teacher2);

            teacherService.Create(teacher1);
            teacherService.Create(teacher2);
            teacherService.Create(teacher3);
            teacherService.GetAll().ForEach(x => Console.WriteLine(x.ToString()));

            Console.WriteLine("=========================================================");

            studentService.Create(student1);
            studentService.Create(student2);
            studentService.Create(student3);
            studentService.GetAll().ForEach(x => Console.WriteLine(x.ToString()));

            Console.WriteLine();
            Console.WriteLine();
            // NO NEED TO ADD MANUALLY.
            //teacher1.Students.Add(student1);


            //teacherService.Remove(1);

            Console.WriteLine("Teacher's students:");

            //teacher1.Students.ForEach(x => Console.WriteLine(x.Fullname));
            studentService.Remove(2);
            teacher2.Students.ForEach(x => Console.WriteLine(x.Fullname));

            Console.WriteLine();
            Console.WriteLine();

            //teacherService.Remove(1)

            Console.WriteLine("Student teacher check:");
            try
            {
                Console.WriteLine(student1.Teacher.ToString());
            }
            catch (NullReferenceException)
            {

                Console.WriteLine($"{student1.Fullname} dont have any teacher!");
            }

            //For better console readability
            Console.ReadKey();
        }
    }
}
