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
    public partial class AdminView : Form {
        public AdminView() {
            InitializeComponent();
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

    }
}