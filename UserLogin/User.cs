using System;

namespace UserLogin
{
    public class User
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FacultyNumber { get; set; }
        public UserRoles Role { get; set; }
        
        public DateTime CreationDate { get; set; }
        public DateTime ValidDate { get; set; }

        public User()
        {
            
        }
        public User(string? username, string? password, string? facultyNumber, UserRoles role, DateTime creationDate, DateTime validDate)
        {
            Username = username;
            Password = password;
            FacultyNumber = facultyNumber;
            Role = role;
            CreationDate = creationDate;
            ValidDate = validDate;
        }
        
        public User(string? username, string? password, string? facultyNumber, UserRoles role)
        {
            Username = username;
            Password = password;
            FacultyNumber = facultyNumber;
            Role = role;
            CreationDate = DateTime.Now;
            ValidDate = DateTime.MaxValue;
        }
    
        public override string ToString()
        {
            return Username + " " + FacultyNumber + " " + Role;
        }
    }
}