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
    public partial class Deces : UserControl
    {
        public Deces()
        {
            InitializeComponent();
        }
        
        ADO d = new ADO();
        private void Deces_Load(object sender, EventArgs e)
        {
            d.Connecter();
            lblID.Text = Form1.IDUser;
            d.cmd.CommandText = "select Nom ,Prenom from Officiers where ID = '" + lblID.Text + "'";
            d.cmd.Connection = d.cnx;
            d.dr = d.cmd.ExecuteReader();
            while (d.dr.Read())
            {
                lblNom.Text = d.dr[0].ToString();
                lblPrenom.Text = d.dr[1].ToString();
            }
            lblDate.Text = DateTime.Now.ToString();
            d.dr.Close();
        }

        private void txtCin_TextChanged(object sender, EventArgs e)
        {
            if (txtCinHomme.Text.Trim() == "")
            {
                lblCinHomme.Text = "Ce champ est obligatoire *";
            }
            else
                lblCinHomme.Text = "";
            try
            {
                DataTable dt = new DataTable();
                dt = Search.SearchPersonne(txtCinHomme.Text, "Homme");
                txtNomHomme.Text = dt.Rows[0][1].ToString();
                txtPrenomHomme.Text = dt.Rows[0][2].ToString();
                dateNaissHomme.Value = (DateTime)dt.Rows[0][3];
                txtAdresseHomme.Text = dt.Rows[0][4].ToString();
                comboVilleHomme.Text = dt.Rows[0][5].ToString();
                txtProfessionHomme.Text = dt.Rows[0][6].ToString();
                comboSituationHomme.Text = dt.Rows[0][7].ToString();
                txtTelHomme.Text = dt.Rows[0][8].ToString();
                comboNationalite1Homme.Text = dt.Rows[0][9].ToString();
                comboNationalite2Homme.Text = dt.Rows[0][10].ToString();
            }
            catch
            {
                txtNomHomme.Text = "";
                txtPrenomHomme.Text = "";
                txtAdresseHomme.Text = "";
                comboVilleHomme.SelectedIndex = 0;
                txtProfessionHomme.Text = "";
                comboSituationHomme.SelectedIndex = 0;
                txtTelHomme.Text = "";
                comboNationalite1Homme.SelectedIndex = 0;
                comboNationalite2Homme.SelectedIndex = 0;
                RadioPereDeces.Checked = false;
                RadioPereVivant.Checked = false;
            } 
        }

        private void txtCinFemme_TextChanged(object sender, EventArgs e)
        {
            if (txtCinFemme.Text.Trim() == "")
            {
                lblCinFemme.Text = "Ce champ est obligatoire *";
            }
            else
                lblCinFemme.Text = "";
            try
            {
                DataTable dt = new DataTable();
                dt = Search.SearchPersonne(txtCinFemme.Text, "Femme");
                txtNomFemme.Text = dt.Rows[0][1].ToString();
                txtPrenomFemme.Text = dt.Rows[0][2].ToString();
                dateNaissFemme.Value = (DateTime)dt.Rows[0][3];
                txtAdresseFemme.Text = dt.Rows[0][4].ToString();
                comboVilleFemme.Text = dt.Rows[0][5].ToString();
                txtProfessionFemme.Text = dt.Rows[0][6].ToString();
                comboSituationFemme.Text = dt.Rows[0][7].ToString();
                txtTelFemme.Text = dt.Rows[0][8].ToString();
                comboNationalite1Femme.Text = dt.Rows[0][9].ToString();
                comboNationalite2Femme.Text = dt.Rows[0][10].ToString();
            }
            catch
            {
                txtNomFemme.Text = "";
                txtPrenomFemme.Text = "";
                txtAdresseFemme.Text = "";
                comboVilleFemme.SelectedIndex = 0;
                txtProfessionFemme.Text = "";
                comboSituationFemme.SelectedIndex = 0;
                txtTelFemme.Text = "";
                comboNationalite1Femme.SelectedIndex = 0;
                comboNationalite2Femme.SelectedIndex = 0;
            }
        }

        private void Check_Homme(object sender, EventArgs e)
        {
            if (txtPrenomHomme.Focused)
                lblPrenomHomme.Text = txtPrenomHomme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            if (txtNomHomme.Focused)
                lblNomHomme.Text = txtNomHomme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            if (txtAdresseHomme.Focused)
                lblAdresseHomme.Text = txtAdresseHomme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            if (txtProfessionHomme.Focused)
                lblProfessionHomme.Text = txtProfessionHomme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            if (txtTelHomme.Focused)
                lblTelHomme.Text = txtTelHomme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            if (txtCinHomme.Focused)
                lblCinHomme.Text = txtCinHomme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
        }

        private void Check_Femme(object sender, EventArgs e)
        {
            if (txtPrenomFemme.Focused)
                lblPrenomFemme.Text = txtPrenomFemme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            if (txtNomFemme.Focused)
                lblNomFemme.Text = txtNomFemme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            if (txtAdresseFemme.Focused)
                lblAdresseFemme.Text = txtAdresseFemme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            if (txtProfessionFemme.Focused)
                lblProfessionFemme.Text = txtProfessionFemme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            if (txtTelFemme.Focused)
                lblTelFemme.Text = txtTelFemme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            if (txtCinFemme.Focused)
                lblCinFemme.Text = txtCinFemme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
        }
        private void txtCinDefunt_TextChanged(object sender, EventArgs e)
        {
            if (txtCinDefunt.Text.Trim() == "")
            {
                lblCinDefunt.Text = "Ce champ est obligatoire *";
            }
            else
                lblCinDefunt.Text = "";
            try
            {
                DataTable dt = new DataTable();
                dt = Search.SearchPersonne(txtCinDefunt.Text, comboGenre.Text);
                txtNomDefunt.Text = dt.Rows[0][1].ToString();
                txtPrenomDefunt.Text = dt.Rows[0][2].ToString();
                dateNaissDefunt.Value = (DateTime)dt.Rows[0][3];
                txtAdresseResidenceDefunt.Text = dt.Rows[0][4].ToString();
                comboVilleDefunt.Text = dt.Rows[0][5].ToString();
                txtProfessionDefunt.Text = dt.Rows[0][6].ToString();
                comboSituationDefunt.Text = dt.Rows[0][7].ToString();
                combonationaliteDefunt.Text = dt.Rows[0][9].ToString();
            }
            catch
            {
                txtNomDefunt.Text = "";
                txtPrenomDefunt.Text ="";
                dateNaissDefunt.Value = DateTime.Now;
                txtAdresseResidenceDefunt.Text = "";
                comboVilleDefunt.SelectedIndex = 0;
                txtProfessionDefunt.Text = "";
                comboSituationDefunt.SelectedIndex =0;
                combonationaliteDefunt.SelectedIndex =0 ;
            }
        }
        private void Check_Defunt(object sender, EventArgs e)
        {
            if (txtNomDefunt.Focused)
                lblNomDefunt.Text = txtNomDefunt.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            if (txtPrenomDefunt.Focused)
                lblPrenomDefunt.Text = txtPrenomDefunt.Text.Trim() == ""? "Ce champ est obligatoire *":"";
            if (txtAdresseResidenceDefunt.Focused)
                lblAdresseResidenceDefunt.Text = txtAdresseResidenceDefunt.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            if (txtAdresseDeces.Focused)
                lblAdresseDecesDefunt.Text = txtAdresseDeces.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            if (txtProfessionDefunt.Focused)
                lblProfessionDefunt.Text = txtProfessionDefunt.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            if (txtCauseDecesDefunt.Focused)
                lblCauseDecesDefunt.Text = txtCauseDecesDefunt.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            foreach (Control crt in guna2TabControl1.Controls)
            {
                foreach (Control ct in crt.Controls)
                {
                    if (ct.GetType() == typeof(Guna.UI2.WinForms.Guna2TextBox))
                    {
                        if (ct.Text.Trim() == "")
                        {
                            MessageBox.Show("Tout les champs sont obligatoire", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }
            }

            d.cmd.CommandText = "insert into Deces values ('" + txtCinDefunt.Text + "','" + txtAdresseDeces.Text + "','" + dateDeces.Value.ToString() + "','" + txtCauseDecesDefunt.Text + "','" + txtRapport.Text + "','" + txtCinHomme.Text + "','" + txtCinFemme.Text + "','" + lblID.Text + "')";
            d.cmd.Connection = d.cnx;
            d.cmd.ExecuteNonQuery();
            Trace t = new Trace();
            t.Evenement = "Ajouté personne comme deces ";
            t.Details = "Ajouté personne comme deces  " + txtCinDefunt.Text;
            Program.liste.Add(t);
            SAPNaissance tt = new SAPNaissance();
            ReportNaissance crD = new ReportNaissance();
            crD.SetParameterValue(0, DateTime.Now.ToShortDateString());
            crD.SetParameterValue(1, txtPrenomDefunt.Text);
            crD.SetParameterValue(2, txtNomDefunt.Text);
            crD.SetParameterValue(3, dateNaissDefunt.Value.ToString());
            crD.SetParameterValue(4, txtAdresseResidenceDefunt.Text);
            crD.SetParameterValue(5, txtNomHomme.Text+" "+txtPrenomHomme);
            crD.SetParameterValue(6, txtNomFemme.Text + " " + txtPrenomFemme);
            crD.SetParameterValue(7, txtProfessionDefunt.Text);
            crD.SetParameterValue(8, txtAdresseResidenceDefunt.Text);
            crD.SetParameterValue(9, txtAdresseDeces.Text);
            tt.crystalReportViewer1.ReportSource = crD;
            tt.crystalReportViewer1.Refresh();
            tt.ShowDialog();
        }

        private void dateDeces_ValueChanged(object sender, EventArgs e)
        {
            if (dateDeces.Value > DateTime.Now)
            {
                MessageBox.Show("Verifie la date de deces ...", "Etat civile", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            d.cmd.CommandText = "select concat(year('" + dateDeces.Value.ToShortDateString() + "'),format(month('" + dateDeces.Value.ToShortDateString() + "'),'#00'),day('" + dateDeces.Value.ToShortDateString() + "'),next value for SDeces)";
            d.cmd.Connection = d.cnx;
            NumDeces.Text = (string)d.cmd.ExecuteScalar();
        }
    }
}
    