using SbsSW.SwiPlCs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniAdvise {
    public partial class MainWindow : Form {
        public MainWindow() {
            InitializeComponent();
            //var curPath = Environment.GetEnvironmentVariable("PATH");
            Environment.SetEnvironmentVariable("SWI_HOME_DIR", @"C:\Program Files\swipl");
            Environment.SetEnvironmentVariable("PATH", @"C:\Program Files\swipl");
            Environment.SetEnvironmentVariable("PATH", @"C:\Program Files\swipl\bin");
            if (!PlEngine.IsInitialized) {
                String[] param = { "-q", "-f", @"family.pl" };  // suppressing informational and banner messages
                PlEngine.Initialize(param);
                PlQuery.PlCall("assert(father(martin, inka))");
                PlQuery.PlCall("assert(father(uwe, gloria))");
                PlQuery.PlCall("assert(father(uwe, melanie))");
                PlQuery.PlCall("assert(father(uwe, ayala))");
                using (PlQuery q = new PlQuery("father(P, C), atomic_list_concat([P,' is_father_of ',C], L)")) {
                    foreach (PlQueryVariables v in q.SolutionVariables)
                        Console.WriteLine(v["L"].ToString());

                    Console.WriteLine("all child's from uwe:");
                    q.Variables["P"].Unify("uwe");
                    foreach (PlQueryVariables v in q.SolutionVariables)
                        Console.WriteLine(v["C"].ToString());
                }
                PlEngine.PlCleanup();
                Console.WriteLine("finshed!");
            }
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
