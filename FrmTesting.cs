using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POCTemplate
{
    public partial class FrmTesting : Form
    {
        public FrmTesting()
        {
            InitializeComponent();
        }

        private void FrmTesting_Load(object sender, EventArgs e)
        {

        }

        private void BtnClick_Click(object sender, EventArgs e)
        {
            ListBoxPrint p = new ListBoxPrint(LbxOutput);

            //Sets student's properties

            Student s1 = new Student("Miguel", "Secilano", "MAS", 99, 96);
            Student s2 = new Student("Marcela", "Secillano", "MGS", 100, 99);
            Student s3 = new Student("Janet", "Gabriel", "JG", 93, 89);
            Student s4 = new Student("Alex", "Avery", "AA", 87, 99);
            Student s5 = new Student("Miguel", "Secillano", "MAS", 89, 100);
            Student s6 = s5 + s1;

            // Adds students to LbxOutput

            //LbxOutput.Items.Add(s1);
            //LbxOutput.Items.Add(s2);
            //LbxOutput.Items.Add(s3);
            //LbxOutput.Items.Add(s4);

            p.Print("Name".LJ(18), "Init".RJ(4), "Math".RJ(5), "Sci".RJ(5));
            p.Print(s1); p.Print(s2); p.Print(s3); p.Print(s4); p.Print(s5); p.Print(s6);

        }
    }


    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Initials { get; set; }
        public int MathAvg { get; set; }
        public int SciAvg { get; set; }

        public Student(string firstName, string lastName, string initials, int mathAvg, int sciAvg)
        {
            FirstName = firstName;
            LastName = lastName;
            Initials = initials;
            MathAvg = mathAvg;
            SciAvg = sciAvg;
        }

        public Student(Student existingStudent)
        {
            FirstName = existingStudent.FirstName;
            LastName = existingStudent.LastName;
            Initials = existingStudent.Initials;
            MathAvg = existingStudent.MathAvg;
            SciAvg = existingStudent.SciAvg;
        }

        //overriding ToString()

        public override string ToString()
        {
            if (FirstName == null)
            {
                return "[DELETED]".LJ(18);
            }
            return $"{(FirstName + " " + LastName).LJ(18)}{Initials.RJ(4)}{MathAvg.RJ(5)}{SciAvg.RJ(5)}";
        }

        public static Student operator +(Student newerStudent, Student oldStudent)
        {
            Student combinedStudent = new Student(newerStudent);
            combinedStudent.MathAvg = (newerStudent.MathAvg + oldStudent.MathAvg) / 2;
            combinedStudent.SciAvg = (newerStudent.SciAvg + oldStudent.SciAvg) / 2;

            newerStudent.NullStudent();
            oldStudent.NullStudent();

            return combinedStudent;
        }

        private void NullStudent()
        {
            FirstName = null;
            LastName = null;
            Initials = null;
            MathAvg = -1;
            SciAvg = -1;
        }
    }
}
