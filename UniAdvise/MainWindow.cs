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
using System.IO;

namespace UniAdvise {//it's me
    public partial class MainWindow : Form {
        Database1Entities dbContext;

        public MainWindow() {
            InitializeComponent();
            dbContext = new Database1Entities();
            updatePrologFile();
            var prolog = new PrologEngine(persistentCommandHistory: false);
            prolog.Consult("courses.pl");

            /*// 'socrates' is human.
            prolog.ConsultFromString("human(socrates).");
            // human is bound to die.
            prolog.ConsultFromString("mortal(X) :- human(X).");*/

            // Question: Shall 'socrates' die?
            //var solution = prolog.GetFirstSolution(query: "prereq(ece462,ZZZ).");
            //SolutionSet solution2 = prolog.GetAllSolutions("courses.pl", "prereq(ece561,ZZZ).");
            //Console.WriteLine(solution2[0]); // = "True" (Yes!)
            //Console.WriteLine(string.Join(",", solution2));
           /* var contacts = (from c in dbContext.courses select c).ToList(); //read data
            foreach (course myc in contacts) {
                List<string> mylist = prereqOf(myc.course_code);
                for (int i = 0; i < mylist.Count; i++) {
                    string temp = mylist[i];
                    var result = dbContext.courses.First(x => x.course_code == temp);
                    var records = dbContext.Set<prereq>();
                    prereq abb = new prereq {
                        course_code = myc.course_code,
                        prerequisite_code = result.course_code
                    };
                    records.Add(abb);
                    dbContext.SaveChanges();
                }
            }*/
            //Console.WriteLine(solution.Solved); // = "True" (Yes!)
        }

        private List<string> prereqOf(string a) {
            List<string> mylist = new List<string>();
            var prolog = new PrologEngine(persistentCommandHistory: false);
            prolog.Consult("courses.pl");
            SolutionSet solution2 = prolog.GetAllSolutions("courses.pl", "prereq(" + a + ",ZZZ).");
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

        private void loginButton_Click(object sender, EventArgs e) {
            /*if(dbContext.user.Any(x => x.username == idText.Text && x.password == passwordText.Text)) {
                Console.WriteLine("EXIST"); // = "True" (Yes!)
            } else {
                Console.WriteLine("No Exist"); // = "True" (Yes!)
            }*/
            var result = dbContext.users.FirstOrDefault(x => x.username == idText.Text && x.password == passwordText.Text);
            if (result == null) {

            }else if (result.privilage == 0) {
                EditPrerequisites myForm = new EditPrerequisites();
                this.Hide();
                myForm.ShowDialog();
                this.Show();
            } else {
                //Console.WriteLine("No Exist"); // = "True" (Yes!)
                //Console.WriteLine("EXIST"); // = "True" (Yes!)
                StudentAdvise myForm = new StudentAdvise();
                myForm.mystudent = result;
                this.Hide();
                myForm.ShowDialog();
                this.Show();
            }
        }

        private void updatePrologFile() {
            // Create a file to write to.
            var contacts = (from c in dbContext.courses select c).ToList(); //read data
            string mydata = "";
            foreach (course myc in contacts) {
                mydata += "course(" + myc.course_code.Trim() + ")." + Environment.NewLine;
            }
            foreach (course myc in contacts) {
                var tempo = myc.prereqs.ToList();
                for (int i = 0; i < tempo.Count; i++) {
                    mydata += "prereq(" + myc.course_code.Trim() + "," + tempo[i].prerequisite_code.Trim() + ")." + Environment.NewLine;
                }
            }
            File.WriteAllText("courses.pl", mydata);
        }

        private void loginLabel_Click(object sender, EventArgs e) {

        }
    }
}