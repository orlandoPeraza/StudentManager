using System.Text.Json;
using StudentManager.Models;


namespace StudentManager.Services{
    public class StudentService{
        private const string FilePath = "students.json";

        public async Task SaveStudentsAsync(List<Student> students)
        {
            string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(FilePath, json);
        }

        public async Task<List<Student>> LoadStudentsAsync()
        {
            if (!File.Exists(FilePath))
                return new List<Student>();

            string json = await File.ReadAllTextAsync(FilePath);
            return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
        }
    }
}