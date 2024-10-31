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
    public partial class DeclarationMariage : UserControl
    {
        public DeclarationMariage()
        {
            InitializeComponent();
        }
        ADO d = new ADO();
        private void DeclarationMariage_Load(object sender, EventArgs e)
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
            d.dr.Close();
            //((Control)this.tabFemme).Enabled = false;
            //((Control)this.tabTremoins).Enabled = false;
            //((Control)this.tabOfficer).Enabled = false;
        }

        private void txtCinTre1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCinHomme_TextChanged(object sender, EventArgs e)
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
                comboHommeNationalite1.Text = dt.Rows[0][9].ToString();
                comboHommeNationalite2.Text = dt.Rows[0][10].ToString();
                
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
                comboHommeNationalite1.SelectedIndex = 0;
                comboHommeNationalite2.SelectedIndex = 0;
                ProgHomme.Value = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
        }

        private void Check_Homme(object sender, EventArgs e)
        {
            if (txtPrenomHomme.Focused)
            {
                lblPrenomHomme.Text = txtPrenomHomme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            }

            if (txtNomHomme.Focused)
            {
                lblNomHomme.Text = txtNomHomme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            }
                
            if (txtAdresseHomme.Focused)
            {
                lblAdresseHomme.Text = txtAdresseHomme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            }
                
            if (txtProfessionHomme.Focused)
            {
                lblProfessionHomme.Text = txtProfessionHomme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            }
                
            if (txtTelHomme.Focused)
            {
                lblTelHomme.Text = txtTelHomme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            }
                
            if (txtCinHomme.Focused)
            {
                lblCinHomme.Text = txtCinHomme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            }
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            if (txtCinHomme.Text.Trim() != "" && txtPrenomHomme.Text.Trim() != "" && txtNomHomme.Text.Trim() != "" && txtAdresseHomme.Text.Trim() != "" && txtProfessionHomme.Text.Trim() != "" && txtTelHomme.Text.Trim() != "" && comboHommeNationalite1.Text != "Nationalité 1" && comboHommeNationalite2.Text != "Nationalité 2" && comboVilleHomme.Text != "Lieu de naissance" && txtNomPereHomme.Text.Trim() != "" && txtNomMereHomme.Text.Trim() != "")
            {
                ProgHomme.Value = 100;
                ((Control)this.tabFemme).Enabled = true;
                guna2TabControl1.SelectedTab = tabFemme;
            }
            else
            {
                MessageBox.Show("merci de remplir tous les champs","Erreur",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }



        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            if (txtCinFemme.Text.Trim() != "" && txtPrenomFemme.Text.Trim() != "" && txtNomFemme.Text.Trim() != "" && txtAdresseFemme.Text.Trim() != "" && txtProfessionFemme.Text.Trim() != "" && txtTelFemme.Text.Trim() != "" && comboFemmeNationalite1.Text != "Nationalité 1" && comboFemmeNationalite2.Text != "Nationalité 2" && comboVilleFemme.Text != "Lieu de naissance" && txtNomPereFemme.Text.Trim() !=  "" &&  txtNomMereFemme.Text.Trim() != "")
            {
                ProgFemme.Value = 100;
                ((Control)this.tabFemme).Enabled = true;
                guna2TabControl1.SelectedTab = tabTremoins;
            }
            else
            {
                MessageBox.Show("merci de remplir tous les champs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            if(txtCinTre1.Text.Trim() != "" && txtNomTre1.Text.Trim() != "" && txtPrenomTre1.Text.Trim() != "" && txtPrenomTre2.Text.Trim() != "" && txtNomTre2.Text.Trim() != "" && txtCinTre2.Text.Trim() != "" )
            {
                ProgTemoin.Value = 100;
                ((Control)this.tabFemme).Enabled = true;
                guna2TabControl1.SelectedTab = tabOfficer;
            }
            else
            {
                MessageBox.Show("merci de remplir tous les champs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            d.cmd.CommandText = "insert into Mariage values ('"+txtCinHomme.Text+txtCinFemme.Text+"','"+dateMariage.Value+"','"+txtLieuMariage.Text+"','"+TypeMariage.Text+"','"+txtCinHomme.Text+"','"+txtCinFemme.Text+"'," +
                "'"+lblID.Text+"','"+txtCinTre1.Text+"','"+txtNomTre1.Text+"','"+txtPrenomTre1.Text+"','"+comboGenreTr1.Text+"','"+txtCinTre2.Text+"'," +
                "'"+txtNomTre2.Text+"','"+txtPrenomTre2.Text+"','"+comboGenreTr2.Text+"','"+txtRapport.Text+"')";
            d.cmd.Connection = d.cnx;
            d.cmd.ExecuteNonQuery();
            ProgOff.Value = 100;
            SAPNaissance tt = new SAPNaissance();
            Mariage crD = new Mariage();
            //EPOUX
            crD.SetParameterValue(0, txtPrenomHomme.Text);
            crD.SetParameterValue(1, txtNomHomme.Text);
            crD.SetParameterValue(2, dateNaissHomme.Text);
            crD.SetParameterValue(3, txtNomPereHomme.Text);
            crD.SetParameterValue(4, txtNomMereHomme.Text);
            crD.SetParameterValue(5, txtAdresseHomme.Text);
            crD.SetParameterValue(6, txtProfessionHomme.Text);
            //General
            crD.SetParameterValue(7, dateMariage.Value.ToShortDateString());
            crD.SetParameterValue(8, txtLieuMariage.Text);
            //EPOUSE
            crD.SetParameterValue(9, txtPrenomFemme.Text);
            crD.SetParameterValue(10, txtNomFemme.Text);
            crD.SetParameterValue(11, dateNaissFemme.Text);
            crD.SetParameterValue(12, txtNomPereFemme.Text);
            crD.SetParameterValue(13, txtNomMereFemme.Text);
            crD.SetParameterValue(14, txtAdresseFemme.Text);
            crD.SetParameterValue(15, txtProfessionFemme.Text);
            tt.crystalReportViewer1.ReportSource = crD;
            tt.crystalReportViewer1.Refresh();
            tt.ShowDialog();


        }

        private void Check_Femme(object sender, EventArgs e)
        {
           if (txtPrenomFemme.Focused)
            {
                lblPrenomFemme.Text = txtPrenomFemme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            }

            if (txtNomFemme.Focused)
            {
                lblNomFemme.Text = txtNomFemme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            }

            if (txtAdresseFemme.Focused)
            {
                lblAdresseFemme.Text = txtAdresseFemme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            }

            if (txtProfessionFemme.Focused)
            {
                lblProfessionFemme.Text = txtProfessionFemme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            }

            if (txtTelFemme.Focused)
            {
                lblTelFemme.Text = txtTelFemme.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
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
                comboFemmeNationalite1.Text = dt.Rows[0][9].ToString();
                comboFemmeNationalite2.Text = dt.Rows[0][10].ToString();
        
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
                comboFemmeNationalite1.SelectedIndex = 0;
                comboFemmeNationalite2.SelectedIndex = 0;
                ProgFemme.Value = 0;
            }
        }
    }
}