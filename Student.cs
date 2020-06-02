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
        public enum Subject
        {
            Math,
            Sci,
            Eng,
            ALL
        }

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
        public Single MathAvg { get { return (Single)MathGrades.Average(); } }

        public int SciGrade { set { sciGrades.Add(value); } }
        public List<int> SciGrades { get { return sciGrades; } }
        public Single SciAvg { get { return (Single)SciGrades.Average(); } }

        public int EngGrade { set { engGrades.Add(value); } }
        public List<int> EngGrades { get { return engGrades; } }
        public Single EngAvg { get { return (Single)EngGrades.Average(); } }

        public string StudentID { get; }
        public DateTime DateTimeCreated { get; }
        public static object Invoke { get; private set; }

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

        public static List<Student> AwardCandidates(Subject subject, Single gradeCutoff)
        {
            List<Student> awardCandidates = new List<Student>();
            foreach (KeyValuePair<string, Student> s in Students)
            {
                if (subject == Subject.Math) { if (s.Value.MathAvg >= gradeCutoff) awardCandidates.Add(s.Value); }
                if (subject == Subject.Sci) { if (s.Value.SciAvg >= gradeCutoff) awardCandidates.Add(s.Value); }
                if (subject == Subject.Eng) { if (s.Value.EngAvg >= gradeCutoff) awardCandidates.Add(s.Value); }
                if (subject == Subject.ALL) { if ((s.Value.MathAvg + s.Value.SciAvg + s.Value.EngAvg) / 3 >= gradeCutoff) awardCandidates.Add(s.Value); }
            }
            return awardCandidates;
        }


        public static List<Student> MathAwardCandidates(Single gradeCutoff)
        {
            List<Student> awardCandidates = new List<Student>();
            foreach (KeyValuePair<string, Student> s in Students)
            {
                if (s.Value.MathAvg > gradeCutoff)
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
            return $"{StudentID.LJ(8)}{FirstLast().LJ(20)}{GradeLevel.RJ(4)}   M:{MathAvg.ToString("F2").RJ(3)} S:{SciAvg.ToString("F2").RJ(3)} E:{EngAvg.ToString("F2").RJ(3)}";
        }

    }
}
