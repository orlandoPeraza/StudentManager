using System.Threading.Tasks;
using StudentManager.Models;
using StudentManager.Services;

StudentService service = new StudentService();
List<Student> students = await service.LoadStudentsAsync();

bool running = true;
while (running){
    Console.WriteLine("\n--- Student Manager ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. List Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    await AddStudent();
                    break;
                case "2":
                    ListStudents();
                    break;
                case "3":
                    SearchStudent();
                    break;
                case "4":
                    await DeleteStudent();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
}

async Task AddStudent()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        Console.Write("Enter student last name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter student age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Student newStudent = new Student { Name = name, LastName = lastName, Age = age };
        students.Add(newStudent);

        await service.SaveStudentsAsync(students);

        Console.WriteLine("Student added!");
    }

void ListStudents()
    {
        Console.WriteLine("\n--- All Students ---");
        foreach (var student in students)
        {
            Console.WriteLine($"Name: {student.Name} {student.LastName}, Age: {student.Age}");
        }
    }

void SearchStudent()
    {
        Console.Write("Enter name to search: ");
        string name = Console.ReadLine();

        Console.Write("Enter last name to search: ");
        string lastName = Console.ReadLine();


        var found = students.Find(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && s.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

        if (found != null)
        {
            Console.WriteLine($"Found: {found.Name} {found.LastName}, Age: {found.Age}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    async Task DeleteStudent()
    {
        if (students.Count == 0)
    {
        Console.WriteLine("No students to delete.");
        return;
    }
        Console.Write("Enter name to delete: ");
        string name = Console.ReadLine();

        Console.Write("Enter last name to search: ");
        string lastName = Console.ReadLine();

        var found = students.Find(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && s.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

        if (found != null)
        {
            Console.Write($"Are you sure you want to delete de student: {found.Name} {found.LastName} ? (y/n):");
            string confirmation = Console.ReadLine()?.Trim().ToLower();
            if(confirmation == "y"){
                students.Remove(found);
                await service.SaveStudentsAsync(students);
                Console.WriteLine("Student deleted!");
            }
            else{
                Console.WriteLine("Deletion canceled.");
            }

            
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
