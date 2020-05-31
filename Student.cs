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
        public static Dictionary<string, Student> Students = new Dictionary<string, Student>();  // key = Student ID

        public String FirstName { get; }
        public String LastName { get; }
        public int GradeLevel { get; }
        public List<Double> MathGrades { get; set; }
        public Double MathAvg { get; }
        public List<Double> SciGrades { get; set; }
        public Double SciAvg { get; }
        public List<Double> EngGrades { get; set; }
        public Double EngAvg { get; }
        public string StudentID { get; }
        public DateTime DateTimeCreated { get; }

        public Student(string firstName, string lastName, int gradeLevel)
        {
            NumberOfStudents++;
            studentID++;
            StudentID = studentID.ToString().RJ(5, '0');
            FirstName = firstName;
            LastName = lastName;
            GradeLevel = gradeLevel;
            DateTimeCreated = DateTime.Now;
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

        public double MathAverage()
        {
            double sum = 0;
            foreach (Single grade in MathGrades)
            {
                sum += grade;
            }
            return sum / MathGrades.Count;
        }


        public static List<Student> MathAwardCandidates()
        {
            List<Student> awardCandidates = new List<Student>();
            foreach (KeyValuePair<string, Student> s in Students)
            {
                if (s.Value.MathAvg > 90.0)
                {
                    awardCandidates.Add(s.Value);
                }
            }
            return awardCandidates;
        }
        public static List<Student> SciAwardCandidates()
        {
            List<Student> awardCandidates = new List<Student>();
            foreach (KeyValuePair<string, Student> s in Students)
            {
                if (s.Value.SciAvg > 90.0)
                {
                    awardCandidates.Add(s.Value);
                }
            }
            return awardCandidates;
        }
        public static List<Student> EngAwardCandidates()
        {
            List<Student> awardCandidates = new List<Student>();
            foreach (KeyValuePair<string, Student> s in Students)
            {
                if (s.Value.EngAvg > 90.0)
                {
                    awardCandidates.Add(s.Value);
                }
            }
            return awardCandidates;
        }

        public static List<Student> OverallAwardCandidates()
        {
            List<Student> awardCandidates = new List<Student>();
            double overallAverage = 0;
            foreach (KeyValuePair<string, Student> s in Students)
            {
                overallAverage = (s.Value.MathAvg + s.Value.SciAvg + s.Value.EngAvg) / 3;
                if (s.Value.EngAvg > 90.0)
                {
                    awardCandidates.Add(s.Value);
                }
            }
            return awardCandidates;
        }

    }
}
