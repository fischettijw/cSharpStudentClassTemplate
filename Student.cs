using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpStudentClassTemplate
{
    class Student
    {
        private static int studentID = 0;
        public static int NumberOfStudents = 0;
        public static Dictionary<string, Student> Students = null;  // key = Student ID

        public String FirstName { get; }
        public String LastName { get; }
        public int GradeLevel { get; set; }
        public List<Single> MathGrades { get; set; }
        public List<Single> SciGrades { get; set; }
        public List<Single> EngGrades { get; set; }
        public string StudentID { get; }

        public Student(string firstName, string lastName, int gradeLevel)
        {
            NumberOfStudents++;
            studentID++;
            StudentID = studentID.ToString().RJ(5, '0');
            FirstName = firstName;
            LastName = lastName;
            GradeLevel = gradeLevel;
            Students.Add(StudentID, this);
        }

        public string LastFirst()
        {
            return LastName + ", " + FirstName;
        }

        public String FirstLast()
        {
            return FirstName + " " + LastName;
        }


    }
}
