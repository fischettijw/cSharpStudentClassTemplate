using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cSharpStudentClassTemplate
{
    class Student
    {
        private static int studentID = 0;
        public static int NumberOfStudents = 0;
        public static Dictionary<string, Student> Students = new Dictionary<string, Student>();  // key = Student ID

        private List<int> mathGrades = new List<int>();
        private List<int> sciGrades = new List<int>();
        private List<int> engGrades = new List<int>();

        public String FirstName { get; }
        public String LastName { get; }
        public int GradeLevel { get; }

        public int MathGrade { set { mathGrades.Add(value); } }
        public List<int> MathGrades { get { return mathGrades; } }
        public int MathAvg { get { return MathAverage(); } }

        public int SciGrade { set { sciGrades.Add(value); } }
        public List<int> SciGrades { get { return sciGrades; } }
        public int SciAvg { get { return SciAverage(); } }

        public int EngGrade { set { engGrades.Add(value); } }
        public List<int> EngGrades { get { return engGrades; } }
        public int EngAvg { get { return EngAverage(); } }

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

        public int MathAverage()
        {
            int sum = 0;
            foreach (int grade in MathGrades)
            {
                sum += grade;
            }
            return sum / MathGrades.Count;
        }

        public int SciAverage()
        {
            int sum = 0;
            foreach (int grade in SciGrades)
            {
                sum += grade;
            }
            return sum / SciGrades.Count;
        }
        public int EngAverage()
        {
            int sum = 0;
            foreach (int grade in EngGrades)
            {
                sum += grade;
            }
            return sum / EngGrades.Count;
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

        public override string ToString()
        {
            return $"{StudentID.LJ(8)}{FirstLast().LJ(20)}{GradeLevel.RJ(4)}   M:{MathAvg.ToString().RJ(3)} S:{SciAvg.ToString().RJ(3)} E:{EngAvg.ToString().RJ(3)}";
        }

    }
}
