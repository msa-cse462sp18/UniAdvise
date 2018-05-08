using System;
using Prolog;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniAdvise {//it's me
    public partial class StudentAdvise : Form {
        Database1Entities dbContext;
        public user mystudent;
        public StudentAdvise() {
            InitializeComponent();
            dbContext = new Database1Entities();
        }


        private void bunifuImageButton1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e) {
            this.Close();
        }

        private void header_Paint(object sender, PaintEventArgs e) {

        }

        private void bunifuImageButton4_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e) {
            if (WindowState.ToString() == "Normal") {
                this.WindowState = FormWindowState.Maximized;
            } else {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void createAdmin1_Load(object sender, EventArgs e) {

        }

        private void minimize_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void createAdmin_Load(object sender, EventArgs e) {

        }


        private void tile1_Click(object sender, EventArgs e) {

        }

        private void panel2_Paint(object sender, PaintEventArgs e) {

        }

        private void createAdmin_Load_1(object sender, EventArgs e) {

        }

        private void prereqButton_Click(object sender, EventArgs e) {
            if(dbContext.courses.Any(x => x.course_code == courseCode.Text.ToLower())) {
                List<string> mypre = prereqOf(courseCode.Text.ToLower());
                if (mypre.Count == 0) {
                    resultText.Text = "This course has no prerequisites.";
                } else {
                    resultText.Text = "This course prerequisites are:\n";
                    for (int i=0; i<mypre.Count; i++) {
                        string temp = mypre[i];
                        var result = dbContext.courses.First(x => x.course_code == temp);
                        resultText.Text += result.course_name+": "+ result.course_code + " opens in:" + result.course_semester + "\n";
                    }
                }
            } else {
                resultText.Text = "The course code doesn't exist \n Please check the course code.";
            }
        }

        private void futureButton_Click(object sender, EventArgs e) {
            if (dbContext.courses.Any(x => x.course_code == courseCode.Text.ToLower())) {
                List<string> mypre = opensCourse(courseCode.Text.ToLower());
                if (mypre.Count == 0) {
                    resultText.Text = "This course doesn't open any course.";
                } else {
                    resultText.Text = "This course opens the following courses:\n";
                    for (int i = 0; i < mypre.Count; i++) {
                        string temp = mypre[i];
                        var result = dbContext.courses.First(x => x.course_code == temp);
                        resultText.Text += result.course_name + ": " + result.course_code + " opens in:" + result.course_semester + "\n";
                    }
                }
            } else {
                resultText.Text = "The course code doesn't exist \n Please check the course code.";
            }
        }

        private void dropButton_Click(object sender, EventArgs e) {
            if (dbContext.courses.Any(x => x.course_code == courseCode.Text.ToLower())) {
                var mycors = dbContext.courses.First(x => x.course_code == courseCode.Text.ToLower());
                if (dbContext.studentcourses.Any(x => x.student_id == mystudent.user_id && x.course_id == mycors.course_id)) {
                    List<string> mypre = opensCourse(courseCode.Text.ToLower());
                    if (mypre.Count == 0) {
                        resultText.Text = "Droping this course will not prevent you from taking any course.";
                    } else {
                        resultText.Text = "If you drop this course these courses won't open:\n";
                        for (int i = 0; i < mypre.Count; i++) {
                            string temp = mypre[i];
                            var result = dbContext.courses.First(x => x.course_code == temp);
                            resultText.Text += result.course_name + ": " + result.course_code +" opens in:"+ result.course_semester+ "\n";
                        }
                    }
                } else {
                    resultText.Text = "You are not registered in this course to drop it.";
                }
            } else {
                resultText.Text = "The course code doesn't exist \n Please check the course code.";
            }
        }

        private List<string> prereqOf(string a) {
            List<string> mylist = new List<string>();
            var prolog = new PrologEngine(persistentCommandHistory: false);
            prolog.Consult("courses.pl");
            SolutionSet solution2 = prolog.GetAllSolutions("courses.pl", "prereq("+a+",ZZZ).");
            for (int i = 0; i < solution2.Count; i++) {
                Solution s = solution2[i];
                Variable abc = s.NextVariable.ToList()[0];
                if (abc.Value == "ZZZ")
                    continue;
                mylist.Add(abc.Value);
                //Console.WriteLine(abc.Value);
            }
            return mylist;
        }

        private List<string> opensCourse(string a) {
            List<string> mylist = new List<string>();
            var prolog = new PrologEngine(persistentCommandHistory: false);
            prolog.Consult("courses.pl");
            SolutionSet solution2 = prolog.GetAllSolutions("courses.pl", "prereq(ZZZ,"+a+").");
            for (int i = 0; i < solution2.Count; i++) {
                Solution s = solution2[i];
                Variable abc = s.NextVariable.ToList()[0];
                if (abc.Value == "ZZZ")
                    continue;
                mylist.Add(abc.Value);
                //Console.WriteLine(abc.Value);
            }
            return mylist;
        }
    }
}