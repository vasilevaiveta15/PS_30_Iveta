using System;
using System.Linq;
using StudentInfoSystem.Model;
using StudentInfoSystem.Storage;
using UserLogin;

namespace StudentInfoSystem.Utils;

public class StudentValidation
{
    public Student GetStudentDataByUser(User user)
    {
        try
        {
            return StudentData.TestStudents.First(student => student.FacultyNumber == user.FacultyNumber);
        }
        catch (InvalidOperationException)
        {
            throw new Exception("Student not found");
        }
    }
}