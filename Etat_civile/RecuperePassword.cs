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
    public partial class RecuperePassword : Form
    {
        public RecuperePassword()
        {
            InitializeComponent();
        }

        public RecuperePassword(string email,int code)
        {
            InitializeComponent();
            this.email = email;
            this.code = code;
        }
        string email;
        int code;
        private void RecuperePassword_Load(object sender, EventArgs e)
        {
            d.Connecter();
            lblemail.Text = email;
        }
        ADO d = new ADO();
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if(txtConfirm.Visible)
            {
                if (txtConfirm.Text == this.code.ToString())
                {
                    txtConfirm.Visible = false;
                    txtConfirmPass.Visible = true;
                    txtNouvelle.Visible = true;
                    guna2GradientButton1.Text = "Changer votre mot de pass";
                    guna2GradientButton1.Enabled = false;
                }
            }
            else
            {
                if(txtNouvelle.Text == txtConfirmPass.Text)
                {
                    d.cmd.CommandText = "update Officiers set Motdepass = hashbytes ('MD5','" + txtConfirmPass.Text + "') where Email = '" + this.email + "'";
                    d.cmd.Connection = d.cnx;
                    d.cmd.ExecuteNonQuery();
                    MessageBox.Show("Votre mot de passe a modifié avec succes");
                    this.Close();
                }
            }
            
        }

        private void txtConfirm_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirm.Text.Length == 6)
                guna2GradientButton1.Enabled = true;
            else
                guna2GradientButton1.Enabled = false;
        }

        private void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {
            if(txtConfirmPass.Text == txtNouvelle.Text)
                guna2GradientButton1.Enabled = true;
            else
                guna2GradientButton1.Enabled = false;

        }
    }
}
