using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etat_civile
{
    public partial class Form1 : Form
    {
        ADO d = new ADO();
        public static string use;
        public static string timeEntre;
        public static string TypeProfile;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            d.Connecter();
        }
        int Nbr = 0;
        

        Random rand = new Random();
        int a;
    

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public static string IDUser;
        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            string pass;
            Nbr++;
            if (Nbr <= 3)
            {
                d.cmd.Parameters.Clear();
                d.cmd.CommandType = CommandType.Text;
                d.cmd.CommandText = "select Motdepass from Officiers where Email = '" + txtUser.Text + "'";
                d.cmd.Connection = d.cnx;
                pass = (string)d.cmd.ExecuteScalar();
                d.cmd.CommandType = CommandType.StoredProcedure;
                d.cmd.CommandText = "Decrypte";
                d.cmd.Parameters.Add("@pass", SqlDbType.VarChar, 50).Value = txtPass.Text;
                SqlParameter ok = new SqlParameter("@pass_crypt", SqlDbType.VarChar, 50);
                d.cmd.Parameters.Add(ok);
                ok.Direction = ParameterDirection.Output;
                d.cmd.Connection = d.cnx;
                d.cmd.ExecuteNonQuery();
                if (ok.Value.ToString() == pass)
                {
                    use = txtUser.Text;
                    timeEntre = DateTime.Now.ToShortTimeString();
                    d.cmd.Parameters.Clear();
                    d.cmd.CommandType = CommandType.Text;
                    d.cmd.CommandText = "select ID from Officiers where Email = '" + txtUser.Text + "'";
                    d.cmd.Connection = d.cnx;
                    IDUser = (string)d.cmd.ExecuteScalar();
                    d.cmd.CommandText = "select Type from Officiers where Email = '" + txtUser.Text + "'";
                    d.cmd.Connection = d.cnx;
                    TypeProfile = (string)d.cmd.ExecuteScalar();
                    Program.trace.User = IDUser;
                    Program.trace.TimeEntrer = DateTime.Now.ToShortTimeString();
                    Program.trace.Evenement = "Login";
                    Program.liste.Add(Program.trace);
                    PrincipalForm f = new PrincipalForm();
                    this.Hide();
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username ou Password n'est pas correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (Nbr == 3)
                    {
                        txtUser.Enabled = false;
                        txtPass.Enabled = false;
                        btnlogin.Enabled = false;
                        //timer1.Enabled = true;
                        MessageBox.Show("Cliquer sur Mot de passe oublié pour récupérer votre informations ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            AddOfficier Of = new AddOfficier();
            Of.ShowDialog();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        int ChecherEmail(string email)
        {
            d.cmd.CommandText = "select count(*) from Officiers where Email = '" + email + "'";
            d.cmd.Connection = d.cnx;
            return (int)d.cmd.ExecuteScalar();
        }
        private void label2_Click_1(object sender, EventArgs e)
        {
            if (ChecherEmail(txtUser.Text.Trim()) == 0)
            {
                MessageBox.Show("Ce compte n'existe pas", "Information", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            a = rand.Next(100000, 999999);
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("nilusilu3@gmail.com");
                msg.To.Add(txtUser.Text);
                msg.Subject = "Confirmation";
                msg.Body = a.ToString();
                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                System.Net.NetworkCredential ntcd = new NetworkCredential();
                ntcd.UserName = "etatcivil.gov@gmail.com";
                ntcd.Password = "qelwiledsvxozbzo";
                smt.Credentials = ntcd;
                smt.EnableSsl = true;
                smt.Port = 587;
                smt.Send(msg);
                MessageBox.Show("Verifier votre boite email si tu n'a pas trouver le message de confirmation veullez verifier la partie spam", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RecuperePassword rc = new RecuperePassword(txtUser.Text, a);
                rc.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
