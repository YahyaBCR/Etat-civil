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
    public partial class AddPersonne : UserControl
    {
        public AddPersonne()
        {
            InitializeComponent();
        }

        int Existe(string cin,string table)
        {
            d.cmd.CommandText = "select count(*) from ["+table+"] where CIN = '" + cin + "'";
            d.cmd.Connection = d.cnx;
            return (int)d.cmd.ExecuteScalar();
        }

        ADO d = new ADO();


        private void AddPersonne_Load(object sender, EventArgs e)
        {
            d.Connecter();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            
            if (guna2GradientButton1.Text == "Suivant")
            {
                foreach (Control crt in this.Controls)
                {
                    if (crt.GetType() == typeof(Label))
                        crt.Visible = true;
                    if(crt.GetType() == typeof(Guna.UI2.WinForms.Guna2TextBox) || crt.GetType() == typeof(Guna.UI2.WinForms.Guna2ComboBox) || crt.GetType() == typeof(Guna.UI2.WinForms.Guna2DateTimePicker))
                        crt.Visible = false;
                }
                lblCin.Text = txtCin.Text;
                lblNom.Text = txtNom.Text;
                lblPrenom.Text = txtPrenom.Text;
                lblProf.Text = txtProfession.Text;
                lblTel.Text = txtTelephone.Text;
                lbldate.Text = dateNaissance.Value.ToShortDateString();
                lblAdress.Text = txtAdress.Text;
                lblNation1.Text = comboNationalite1.Text;
                lblNation2.Text = comboNationalite2.Text;
                lblSexe.Text = comboSexe.Text;
                lblSituation.Text = comboSituation.Text;
                lblVille.Text = combVille.Text;
                guna2GradientButton1.Text = "Confirmer";
                foreach (Control crt in this.Controls)
                {
                    if (crt.GetType() == typeof(Guna.UI2.WinForms.Guna2Separator))
                        crt.Visible = true;
                    if (crt.GetType() == typeof(Guna.UI2.WinForms.Guna2VSeparator))
                        crt.Visible = true;
                }
                return;
            }
            if (guna2GradientButton1.Text == "Confirmer")
            {
                if (Existe(txtCin.Text,comboSexe.Text) != 0)
                {
                    MessageBox.Show(txtCin.Text + "Le CIN de cette citoyenne a déja existe","Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (comboSexe.Text == "Homme")
                {
                    d.cmd.CommandText = @"insert into Homme values ('" + txtCin.Text.Replace("'", " ") + "','" + txtNom.Text.Replace("'", " ") + "','" + txtPrenom.Text.Replace("'", " ") + "','" + dateNaissance.Value.ToShortDateString() + "'" +
                        ",'" + txtAdress.Text.Replace("'", " ") + "','" + combVille.Text.Replace("'", " ") + "','" + txtProfession.Text.Replace("'", " ") + "','" + comboSituation.Text.Replace("'", " ") + "','" + txtTelephone.Text.Replace("'", " ") + "','" + comboNationalite1.Text.Replace("'", " ") + "','" + comboNationalite2.Text.Replace("'", " ") + "')";
                    d.cmd.Connection = d.cnx;
                    d.cmd.ExecuteNonQuery();
                    Trace t = new Trace();
                    t.Evenement = "Ajouté personne";
                    t.Details = "Ajouté personne avec un CIN "+txtCin.Text;
                    Program.liste.Add(t);
                    MessageBox.Show("L'ajout a été fait avec succès", "Etat Civile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    d.cmd.CommandText = @"insert into Femme values ('" + txtCin.Text.Replace("'", " ") + "','" + txtNom.Text.Replace("'", " ") + "','" + txtPrenom.Text.Replace("'", " ") + "','" + dateNaissance.Value.ToShortDateString() + "'" +
                        ",'" + txtAdress.Text.Replace("'", " ") + "','" + combVille.Text.Replace("'", " ") + "','" + txtProfession.Text.Replace("'", " ") + "','" + comboSituation.Text.Replace("'", " ") + "','" + txtTelephone.Text.Replace("'", " ") + "','" + comboNationalite1.Text.Replace("'", " ") + "','" + comboNationalite2.Text.Replace("'", " ") + "')";
                    d.cmd.Connection = d.cnx;
                    d.cmd.ExecuteNonQuery();
                    Trace t = new Trace();
                    t.Evenement = "Ajouté personne";
                    t.Details = "Ajouté personne avec un CIN " + txtCin.Text;
                    Program.liste.Add(t);
                    MessageBox.Show("L'ajout a été fait avec succès", "Etat Civile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
