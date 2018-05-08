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
    public partial class MainWindow : Form {
        Database1Entities dbContext;

        public MainWindow() {
            InitializeComponent();
            dbContext = new Database1Entities();
            var prolog = new PrologEngine(persistentCommandHistory: false);
            prolog.Consult("courses.pl");

            /*// 'socrates' is human.
            prolog.ConsultFromString("human(socrates).");
            // human is bound to die.
            prolog.ConsultFromString("mortal(X) :- human(X).");*/

            // Question: Shall 'socrates' die?
            //var solution = prolog.GetFirstSolution(query: "prereq(ece462,ZZZ).");
            SolutionSet solution2 = prolog.GetAllSolutions("courses.pl", "prereq(ece561,ZZZ).");
            //Console.WriteLine(solution2[0]); // = "True" (Yes!)
            //Console.WriteLine(string.Join(",", solution2));
            //for (int i = 0; i < solution2.Count; i++){
                /*Solution s = solution2[i];
                Variable abc = s.NextVariable.ToList()[0];
                if (abc.Value == "ZZZ")
                    continue;
                Console.WriteLine(abc.Value);*/
                //Create Course
                /*using (var dbContext = new Database1Entities()) {
                    var records = dbContext.Set<courses>();
                    records.Add(new courses {
                        course_name = abc.Value
                    });
                    dbContext.SaveChanges();
                }*/
            //}
            //Console.WriteLine(solution.Solved); // = "True" (Yes!)
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
            if (result != null) {
                Console.WriteLine("EXIST"); // = "True" (Yes!)
                StudentAdvise myForm = new StudentAdvise();
                myForm.mystudent = result;
                this.Hide();
                myForm.ShowDialog();
                this.Close();
            } else {
                Console.WriteLine("No Exist"); // = "True" (Yes!)
            }
        }
    }
}