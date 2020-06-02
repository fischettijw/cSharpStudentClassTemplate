using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace cSharpStudentClassTemplate
{
    public partial class FrmStudents : Form
    {
        Student student;

        List<string> studentInfo = new List<string>();
        List<string> gradeInfo = new List<string>();

        public FrmStudents()
        {
            InitializeComponent();
        }

        private void FrmTesting_Load(object sender, EventArgs e)
        {
            Txt01.Text = "00001";
            Random rnd = new Random();

            studentInfo = File.ReadAllLines(@".\RandomlyGeneratedStudents.csv").ToList();
            gradeInfo = File.ReadAllLines(@".\RandomlyGeneratedGrades.csv").ToList();

            ListBoxPrint pS = new ListBoxPrint(LbxStudents);
            ListBoxPrint pG = new ListBoxPrint(LbxGrades);

            foreach (string sInfo in studentInfo)
            {
                string[] parsedStudentInfo = sInfo.Split(',');  // Must be infront to establish the Student instance before adding grades
                student = new Student(parsedStudentInfo[0], parsedStudentInfo[1], Convert.ToInt32(parsedStudentInfo[2]));

                string[] parsedGradeInfo = gradeInfo[rnd.Next(0, 99)].ToString().Split(',');
                student.MathGrade = Convert.ToInt32(parsedGradeInfo[0]);
                student.MathGrade = Convert.ToInt32(parsedGradeInfo[1]);
                student.MathGrade = Convert.ToInt32(parsedGradeInfo[2]);
                pG.Print($"Math: {student.MathGrades[0]} ,{student.MathGrades[1]} ,{student.MathGrades[2]}");

                parsedGradeInfo = gradeInfo[rnd.Next(0, 99)].ToString().Split(',');
                student.SciGrade = Convert.ToInt32(parsedGradeInfo[0]);
                student.SciGrade = Convert.ToInt32(parsedGradeInfo[1]);
                student.SciGrade = Convert.ToInt32(parsedGradeInfo[2]);
                pG.Print($"Sci:  {student.SciGrades[0]} ,{student.SciGrades[1]} ,{student.SciGrades[2]}");

                parsedGradeInfo = gradeInfo[rnd.Next(0, 99)].ToString().Split(',');
                student.EngGrade = Convert.ToInt32(parsedGradeInfo[0]);
                student.EngGrade = Convert.ToInt32(parsedGradeInfo[1]);
                student.EngGrade = Convert.ToInt32(parsedGradeInfo[2]);
                pG.Print($"Eng:  {student.EngGrades[0]} ,{student.EngGrades[1]} ,{student.EngGrades[2]}");

                pS.Print($"{student.ToString()}");   // must be last for Student instance to have all grades
            }
        }

        private void BtnClick_Click(object sender, EventArgs e)
        {
            ListBoxPrint pS = new ListBoxPrint(LbxStudents);
            ListBoxPrint pG = new ListBoxPrint(LbxGrades);

            Single mathAward = 93;
            Single sciAward = 93;
            Single engAward = 93;
            Single allAward = 90;

            Txt01.Text = Txt01.Text.RJ(5, '0');
            Txt02.Text = Student.Students[Txt01.Text].ToString();

            List<Student> mathAwards = Student.AwardCandidates(Student.Subject.Math, mathAward);
            List<Student> sciAwards = Student.AwardCandidates(Student.Subject.Sci, sciAward);
            List<Student> engAwards = Student.AwardCandidates(Student.Subject.Eng, engAward);
            List<Student> allAwards = Student.AwardCandidates(Student.Subject.ALL, allAward);

            pG.Clear(5);
            pG.Print("Math Awards".RJ(35) + "  " + mathAwards.Count() + "  " + (int)mathAward);
            foreach (Student award in mathAwards)
            {
                pG.Print(award.ToString());
            }
            pG.Print("");

            pG.Print("Sci Awards".RJ(35) + "  " + sciAwards.Count() + "  " + (int)sciAward);
            foreach (Student award in sciAwards)
            {
                pG.Print(award.ToString());
            }
            pG.Print("");

            pG.Print("Eng Awards".RJ(35) + "  " + engAwards.Count() + "  " + (int)engAward);
            foreach (Student award in engAwards)
            {
                pG.Print(award.ToString());
            }
            pG.Print("");

            pG.Print("Overall Award".RJ(35) + "  " + allAwards.Count() + "  " + (int)allAward);
            foreach (Student award in allAwards)
            {
                pG.Print(award.ToString());
            }
            pG.Print("");

        }
    }

}



//add to Dictionary then convert to Array
//File.WriteAllLines(@".\RandomlyGeneratedStudentsTest.csv", studentInfo.ToArray());   ??????