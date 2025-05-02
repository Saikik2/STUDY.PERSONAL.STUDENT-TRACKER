using System;
using System.IO;
using System.Linq;
namespace lol
{
    class Program
    {
        static Dictionary<string, int> Students = new Dictionary<string, int>();
        static void AddStudent()
        {
            Console.WriteLine("------------------");
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            if (name.Any(char.IsDigit))
            {
                Console.WriteLine("A name must not have any digits");
                return;
            }
            Console.Write("Enter Student Grade: ");
            string grade = Console.ReadLine();
            if (!int.TryParse(grade, out int grade2))
            {
                Console.WriteLine("A grade must be a number");
                return;
            }
            Console.WriteLine("------------------\n");

            Students.Add(name, grade2);
        }
        static void ViewStudent()
        {
            Console.WriteLine("------------------");
            foreach (var student in Students)
            {
                Console.WriteLine($"Student Name: {student.Key}\nStudent Grade: {student.Value}");
            }
            Console.WriteLine("------------------\n");
        }
        static void ViewAverage()
        {
            int sum = 0;
            foreach (var student in Students)
            {
                sum = +student.Value;
            }
            Console.WriteLine("------------------");
            Console.WriteLine($"Average Grade is: {(double)sum / Students.Count}");
            Console.WriteLine("------------------\n");
        }

        static void FindHighest()
        {
            string topStudent = "";
            int topScore = int.MinValue;

            foreach (var student in Students)
            {
                if (student.Value > topScore)
                {
                    topScore = student.Value;
                    topStudent = student.Key;
                }
            }
            Console.WriteLine("------------------");
            Console.WriteLine($"Highest Grade is {topStudent} by {topScore}");
            Console.WriteLine("------------------\n");
        }

        static void Main(string[] args)
        {
            bool run = true;
            do
            {
                Console.WriteLine("------------------");
                Console.Write("Choose Operation:");
                Console.WriteLine("\n 1. Add Student\n 2. View Students\n 3. View Average Grade\n 4. Find Highest Grade\n 5. Exit\n");
                Console.Write("Choose Operation: ");
                char operation = char.Parse(Console.ReadLine());
                switch (operation)
                {
                    case '1':
                        AddStudent();
                        break;
                    case '2':
                        ViewStudent();
                        break;
                    case '3':
                        ViewAverage();
                        break;
                    case '4':
                        FindHighest();
                        break;
                    case '5':
                        Console.WriteLine("Exiting...");
                        run = false;
                        break;
                }
            } while (run);
        }
    }
}