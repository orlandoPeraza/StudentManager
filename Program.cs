using StudentManager.Models;

List<Student> students = new List<Student>();
bool running = true;
while (running){
    Console.WriteLine("\n--- Student Manager ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. List Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    ListStudents();
                    break;
                case "3":
                    SearchStudent();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
}

void AddStudent()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        Console.Write("Enter student age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Student newStudent = new Student { Name = name, Age = age };
        students.Add(newStudent);

        Console.WriteLine("Student added!");
    }

void ListStudents()
    {
        Console.WriteLine("\n--- All Students ---");
        foreach (var student in students)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}");
        }
    }

void SearchStudent()
    {
        Console.Write("Enter name to search: ");
        string search = Console.ReadLine();

        var found = students.Find(s => s.Name.Equals(search, StringComparison.OrdinalIgnoreCase));

        if (found != null)
        {
            Console.WriteLine($"Found: {found.Name}, Age: {found.Age}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
