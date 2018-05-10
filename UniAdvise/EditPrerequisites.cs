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
    public partial class EditPrerequisites : Form {
        Database1Entities dbContext;
        public EditPrerequisites() {
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
            SolutionSet solution2 = prolog.GetAllSolutions("courses.pl", "prereq(ece462,ZZZ).");
            //Console.WriteLine(solution2[0]); // = "True" (Yes!)
            //Console.WriteLine(string.Join(",", solution2));
            for (int i = 0; i < solution2.Count; i++) // or: foreach (Solution s in ss.NextSolution)
        {
                Solution s = solution2[i];
                Console.WriteLine("Solution {0}", i + 1);

                foreach (Variable v in s.NextVariable)
                    Console.WriteLine(string.Format("{0} ({1}) = {2}", v.Name, v.Type, v.Value));
            }
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

        private void courseBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate();
            this.courseBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void EditPrerequisites_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'database1DataSet.prereq' table. You can move, or remove it, as needed.
            this.prereqTableAdapter.Fill(this.database1DataSet.prereq);
            // TODO: This line of code loads data into the 'database1DataSet.course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.database1DataSet.course);
            // TODO: This line of code loads data into the 'database1DataSet.prereq' table. You can move, or remove it, as needed.
            this.prereqTableAdapter.Fill(this.database1DataSet.prereq);
            // TODO: This line of code loads data into the 'database1DataSet.course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.database1DataSet.course);

        }

        private void courseBindingNavigatorSaveItem_Click_1(object sender, EventArgs e) {
            this.Validate();
            this.courseBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);
            updatePrologFile();
        }

        private void updatePrologFile() {
            // Create a file to write to.
            var contacts = (from c in dbContext.courses select c).ToList(); //read data
            string mydata = "";
            foreach (course myc in contacts) {
                mydata += "course("+myc.course_code.Trim()+ ")." + Environment.NewLine;
            }
            foreach (course myc in contacts) {
                var tempo = myc.prereqs.ToList();
                for (int i = 0; i < tempo.Count; i++) {
                    mydata += "prereq(" + myc.course_code.Trim()+","+tempo[i].prerequisite_code.Trim() + ")." + Environment.NewLine;
                }
            }
            File.WriteAllText("courses.pl", mydata);

            /*foreach (course myc in contacts) {
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
        }
    }
}