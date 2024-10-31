using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etat_civile
{
    public partial class AddOfficier : Form
    {
        public AddOfficier()
        {
            InitializeComponent();
        }
        ADO d = new ADO();
        bool TestValidationdePss()
        {
            if(txtPass.Text == txtPass2.Text)
            {
                if(txtPass.Text.Contains("*") || txtPass.Text.Contains("*") || txtPass.Text.Contains("*") || txtPass.Text.Contains("*") || txtPass.Text.Contains("*"))
                {
                    return true;
                }
            }
            return false;
        }
        d.cmd.Command = "select * from Personnes where id = '+txtNum.Text+'";
        d.cmd.Connection = d.cnx;

        
        Random rand = new Random();
        int a;
        private void btnlogin_Click(object sender, EventArgs e)
        {
            //char [] TabSpéce =  { '*', '_', '/','\\', '@' };
            if(btnlogin.Text == "S'inscrire")
            {
                a = rand.Next(100000, 999999);
                try
                {
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("nilusilu3@gmail.com");
                    msg.To.Add(txtEmail.Text);
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
                    btnlogin.Text = "Confirmer";
                    txtEmail.Enabled = false;
                    txtPass.Enabled = false;
                    txtPass2.Enabled = false;
                    txtNom.Enabled = false;
                    txtPrenom.Enabled = false;
                    guna2DateTimePicker1.Visible = false;
                    txtOfficier.Visible = false;
                    txtCodeConfirmation.Visible = true;
                    txtCodeConfirmation.Focus();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                if(txtCodeConfirmation.Text == a.ToString())
                {
                    string date = guna2DateTimePicker1.Value.ToString();
                    String[] spearator = { "/", ":", " " };
                    String[] id = date.Split(spearator, 6, StringSplitOptions.RemoveEmptyEntries);
                    string id_ = "";
                    foreach (String s in id)
                    {
                        id_ += s;
                    }
                    d.cmd.CommandText = "insert into Officiers values (CONCAT ('"+id_+ "',next value for IdOfficier),'" + txtEmail.Text+ "',HASHBYTES('md5','"+txtPass.Text+"'),'"+txtNom.Text+"','"+txtPrenom.Text+"','Officier') ";
                    d.cmd.Connection = d.cnx;
                    d.cmd.ExecuteNonQuery();
                    this.Close();
                }
            }
        }

        private void AddOfficier_Load(object sender, EventArgs e)
        {
            d.Connecter();
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
