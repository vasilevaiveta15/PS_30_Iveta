using System.Collections.Generic;
using StudentInfoSystem.Model;

namespace StudentInfoSystem.Storage;

public static class StudentData
{
    public static List<Student> TestStudents { get; } = new()
    {
        new Student("Iveta", "Veselinova", "Vasileva", "FKST", "KSI", "Middle", "Assigned", "121219054", 6, 2, 30)
    };
}