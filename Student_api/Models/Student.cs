using System.Globalization;

namespace Student_api.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhone { get; set; }
        public Address StudentAdress {get;set;}

    }
}
