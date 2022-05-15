
namespace StudentInfoSystem.Model
{
    public class Student
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Faculty { get; set; }
        public string? Speciality { get; set; }
        public string? EducationDegree { get; set; }
        public string? Status { get; set; } 
        public string? FacultyNumber { get; set; }
        public int? Course { get; set; }
        public int? Flow { get; set; }
        public int? Group { get; set; }

        public Student()
        {
        }

        public Student(string? firstName, string? middleName, string? lastName, string? faculty, string? speciality, string? educationDegree, string? status, string? facultyNumber, int? course, int? flow, int? group)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Faculty = faculty;
            Speciality = speciality;
            EducationDegree = educationDegree;
            Status = status;
            FacultyNumber = facultyNumber;
            Course = course;
            Flow = flow;
            Group = group;
        }
    }
}