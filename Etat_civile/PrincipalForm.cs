using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etat_civile
{
    public partial class PrincipalForm : Form
    {
        public PrincipalForm()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            DeclarationDeNaissance Dn = new DeclarationDeNaissance();
            addUserControl(Dn);
        }
        public void addUserControl(UserControl uc)
        {
            guna2CustomGradientPanel2.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            guna2CustomGradientPanel2.Controls.Add(uc);
        }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {
            if (Form1.TypeProfile != "admin")
                guna2CirclePictureBox5.Visible = false;
            lblID.Text = Form1.IDUser;
            Dashboard ds = new Dashboard();
            addUserControl(ds);
        }
        

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            Deces de = new Deces();
            addUserControl(de);
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            DeclarationMariage dM = new DeclarationMariage();
            addUserControl(dM);
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            DeclarationDivorce div = new DeclarationDivorce();
            addUserControl(div);
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            addUserControl(ds);
        }

        private void guna2GradientButton1_MouseEnter(object sender, EventArgs e)
        {
            //Message.Create(;
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;

            // Set up the ToolTip text for the Button.
            toolTip1.SetToolTip(this.guna2GradientButton1, "Hey it works!");
        }
        ADO d = new ADO();
        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            d.Connecter();
            //try
            //{
                for (int i = 0; i < Program.liste.Count; i++)
                {
                    Program.liste[i].TimeSortie = DateTime.Now.ToShortTimeString();
                }
                for (int i = 0; i < Program.liste.Count; i++)
                {
                    d.cmd.CommandText = "insert into Trace (Id,TimeEntrer,TimeSortie,Evenement,Details,Date) values ('" + Program.liste[i].User.ToString() + "','" + Program.liste[i].TimeEntrer.ToString() + "','" + Program.liste[i].TimeSortie.ToString() + "','" + Program.liste[i].Evenement.ToString() + "','" + Program.liste[i].Details.ToString() + "','"+Program.liste[i].Date.ToString()+"')";
                    d.cmd.Connection = d.cnx;
                    d.cmd.ExecuteNonQuery();
                }
            //}
            //catch { }
            Application.Exit();
        }
        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            AddPersonne addP = new AddPersonne();
            addUserControl(addP);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            addUserControl(dash);
        }

        private void guna2CirclePictureBox5_Click(object sender, EventArgs e)
        {
            addUserControl(new Traces());
        }
    }
}
