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
            Random rnd = new Random();

            studentInfo = File.ReadAllLines(@".\RandomlyGeneratedStudents.csv").ToList();
            gradeInfo = File.ReadAllLines(@".\RandomlyGeneratedGrades.csv").ToList();

            ListBoxPrint pS = new ListBoxPrint(LbxStudents);
            ListBoxPrint pG = new ListBoxPrint(LbxGrades);

            foreach (string sInfo in studentInfo)
            {
                string[] parsedStudentInfo = sInfo.Split(',');
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

                pS.Print($"{student.ToString()}");
            }
        }

        private void BtnClick_Click(object sender, EventArgs e)
        {
            Txt01.Text = Txt01.Text.RJ(5, '0');
            Txt02.Text = Student.Students[Txt01.Text].ToString();
        }
    }

}

//Student.Students["00058"].ToString()
//"00058   Richard Prescott    "


//var random = new Random();
//var list = new List<string> { "one", "two", "three", "four" };
//int index = random.Next(list.Count);
//Console.WriteLine(list[index]);

//add to Dictionary then convert to Array
//File.WriteAllLines(@".\RandomlyGeneratedStudentsTest.csv", studentInfo.ToArray());   ??????