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
    public partial class DeclarationDeNaissance : UserControl
    {
        public DeclarationDeNaissance()
        {
            InitializeComponent();
        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        int indice = 0;
        void Naviguer(int ind,char oper)
        {
            if(oper == '-')
            {
                if (indice > 4)
                    ind = 4;
                ind--;
                guna2TabControl1.SelectedIndex = ind;
                indice = ind;
            }
            else
            {
                if (ind < -1)
                    ind = -1;
                ind++;
                guna2TabControl1.SelectedIndex = ind;
                indice = ind;
            }
        }


        private void btnSuivante_Click(object sender, EventArgs e)
        {
            foreach(Control crt in guna2TabControl1.Controls)
            {
                foreach(Control ct in crt.Controls)
                {
                    if (ct.GetType() == typeof(Guna.UI2.WinForms.Guna2TextBox))
                    {
                        if (ct.Text.Trim() == "")
                        {
                            MessageBox.Show("Tout les champs sont obligatoire", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                            lblPrenomObli.Text = txtPrenomdeNai.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblNomObli.Text = txtNomdeNais.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblNum.Text = txtNumBulletin.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblAdrsseObli.Text = txtAdresseNai.Text == "" ? "Ce champ est obligatoire *" : "";

                            lblPrenomPere.Text = txtPrenomPere.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblNomPere.Text = txtNomPere.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblAddressePere.Text = txtAdressePere.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblProfessionPere.Text = txtProfessionPere.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblTelPere.Text = txtTelPere.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblCinPere.Text = txtCinPere.Text == "" ? "Ce champ est obligatoire *" : "";


                            lblPrenomMere.Text = txtPrenomMere.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblNomMere.Text = txtNomMere.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblAddresseMere.Text = txtAdresseMere.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblProfessionMere.Text = txtProfessionMere.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblTeleMere.Text = txtTelMere.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblCinMere.Text = txtCinMere.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblVilleMere.Text = comboVilleMere.Text == "" ? "Ce champ est obligatoire *" : "";

                            lblPrenomDeclarant.Text = txtPrenomDeclarant.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblNomDeclarant.Text = txtNomDeclarant.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblAddresseDeclarant.Text = txtAddressDeclarant.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblProfessionDeclarant.Text = txtProfessionDeclarant.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblTeleDeclarant.Text = txtTelDeclarant.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblCinDeclarant.Text = txtCinDeclarant.Text == "" ? "Ce champ est obligatoire *" : "";
                            lblVilleDeclarant.Text = comboVilleDeclarant.Text == "" ? "Ce champ est obligatoire *" : "";
                            return;
                        }
                    }
                }
            }
            d.cmd.CommandText = "select Count(*) from DeclarationNaissance WHERE N_Bulletin = '" + txtNumBulletin.Text + "' ";
            d.cmd.Connection = d.cnx;
            int reslt = (int)d.cmd.ExecuteScalar();
            if(reslt == 0)
            {
                if (Existe(txtCinMere.Text, "Femme") == 0)
                {
                    int state = 0;
                    if (RadioMereVivant.Checked)
                        state = 1;
                    d.cmd.CommandText = "insert into femme  values ('" + txtCinMere.Text.Replace("'", " ") + "','" + txtNomMere.Text.Replace("'", " ") + "','" + txtPrenomMere.Text.Replace("'", " ") + "','" + dateNaissMere.Value.ToShortDateString() + "'" +
                        ",'" + txtAdresseMere.Text.Replace("'", " ") + "','" + comboVilleMere.Text.Replace("'", " ") + "','" + txtProfessionMere.Text.Replace("'", " ") + "','" + comboSituationMere.Text.Replace("'", " ") + "','" + txtTelMere.Text.Replace("'", " ") + "','" + comboPayMere.Text.Replace("'", " ") + "'" +
                        ",'" + comboMereNationalite2.Text.Replace("'", " ") + "') insert into Mere values ('" + txtCinMere.Text + "'," + state + ") ";
                    d.cmd.Connection = d.cnx;
                    d.cmd.ExecuteNonQuery();
                    Trace t1 = new Trace();
                    t1.Evenement = "Ajouté personne";
                    t1.Details = "Ajouté personne sur la table Femme et mére avec CIN  " + txtCinMere.Text;
                    Program.liste.Add(t1);
                }
                if (Existe(txtCinPere.Text, "Homme") == 0)
                {
                    int state = 0;
                    if (RadioMereVivant.Checked)
                        state = 1;
                    d.cmd.CommandText = "insert into Homme values ('" + txtCinPere.Text.Replace("'", " ") + "','" + txtNomPere.Text.Replace("'", " ") + "','" + txtPrenomPere.Text.Replace("'", " ") + "','" + dateNaissPere.Value.ToShortDateString() + "'" +
                        ",'" + txtAdressePere.Text.Replace("'", " ") + "','" + comboVillePere.Text.Replace("'", " ") + "','" + txtProfessionPere.Text.Replace("'", " ") + "','" + comboSituationPere.Text.Replace("'", " ") + "','" + txtTelPere.Text.Replace("'", " ") + "','" + comboPayPere.Text.Replace("'", " ") + "'" +
                        ",'" + comboPereNationalite2.Text.Replace("'", " ") + "') insert into Pere values ('" + txtCinPere.Text + "'," + state + ")  ";
                    d.cmd.Connection = d.cnx;
                    d.cmd.ExecuteNonQuery();
                    Trace t2 = new Trace();
                    t2.Evenement = "Ajouté personne";
                    t2.Details = "Ajouté personne sur la table Homme et Pére avec CIN  " + txtCinPere.Text;
                    Program.liste.Add(t2);
                }

                d.cmd.CommandText = "insert into Declarant values ('" + txtCinDeclarant.Text.Replace("'", " ") + "','" + txtNomDeclarant.Text.Replace("'", " ") + "','" + txtPrenomDeclarant.Text.Replace("'", " ")
                    + "','" + comboSexeDeclarant.Text.Replace("'", " ") + "','" + comboPaysDeclarant.Text.Replace("'", " ") + "','" + comboVilleDeclarant.Text.Replace("'", " ") + "','" + txtAddressDeclarant.Text.Replace("'", " ") + "','" + txtTelDeclarant.Text.Replace("'", " ") + "'" +
                    ",'" + txtProfessionDeclarant.Text.Replace("'", " ") + "','" + dateNaissanceDeclarant.Value.ToShortDateString() + "')";
                d.cmd.Connection = d.cnx;
                d.cmd.ExecuteNonQuery();
                Trace t = new Trace();
                t.Evenement = "Ajouté personne comme deces ";
                t.Details = "Ajouté personne comme Declarant avec CIN  : " + txtCinDeclarant.Text;
                Program.liste.Add(t);
                string date = dateDeNaissancedeNai.Value.ToShortDateString();
                d.cmd.CommandText = "insert into DeclarationNaissance values ('" + txtNumBulletin.Text + "','" + txtNomdeNais.Text.Replace("'", " ") + "','" + txtPrenomdeNai.Text.Replace("'", " ") + "','" + comboSexe.Text.Replace("'", " ") + "'" +
                    ",'" + comboPays.Text.Replace("'", " ") + "','" + comboVilleNaissance.Text.Replace("'", " ") + "','" + txtAdresseNai.Text.Replace("'", " ") + "','" + comboNationalite1.Text.Replace("'", " ") + "','" + comboNationnalite2.Text.Replace("'", " ") + "','" + date + "'" +
                    ",'" + txtCinPere.Text.Replace("'", " ") + "','" + txtCinMere.Text.Replace("'", " ") + "','" + txtCinDeclarant.Text.Replace("'", " ") + "','" + lblID.Text.Replace("'", " ") + "','" + DateTime.Now.ToShortDateString() + "','" + comboType.Text.Replace("'", " ") + "','" + txtRapport.Text.Replace("'", " ") + "')";
                d.cmd.Connection = d.cnx;
                d.cmd.ExecuteNonQuery();
                Trace t3 = new Trace();
                t3.Evenement = "Ajouté personne ";
                t3.Details = "Ajouté personne sur le registre de etat civile avec N° bulletin  :" + txtNumBulletin.Text;
                Program.liste.Add(t3);
                SAPNaissance tt = new SAPNaissance();
                ActeNaissance crD = new ActeNaissance();
                crD.SetParameterValue(0, DateTime.Now.ToShortDateString());
                crD.SetParameterValue(0, txtPrenomdeNai.Text);
                crD.SetParameterValue(0, txtNomdeNais.Text);
                crD.SetParameterValue(0, txtAdresseNai.Text);
                crD.SetParameterValue(0, dateDeNaissancedeNai.Text);
                crD.SetParameterValue(0, comboNationalite1.Text);
                crD.SetParameterValue(0, txtNomPere.Text + " " + txtPrenomPere.Text);
                crD.SetParameterValue(0, txtNomMere.Text + " " + txtPrenomMere.Text);
                tt.crystalReportViewer1.ReportSource = crD;
                tt.crystalReportViewer1.Refresh();
                tt.ShowDialog();
            }
            else
            {
                d.cmd.CommandText = "select d.DateDeclaration,d.Prenom,d.Nom,d.AdresseResidence,d.DateNaissance,d.Nationalite1, h.Nom,h.Prenom,f.Nom,f.Prenom from DeclarationNaissance d,Homme h,Femme f where d.CIN_Mere = f.CIN and d.CIN_Pere = h.CIN and d.N_Bulletin = '"+txtNumBulletin.Text+"'";
                d.cmd.Connection = d.cnx;
                d.dr = d.cmd.ExecuteReader();
                d.dt.Load(d.dr);
                SAPNaissance tt = new SAPNaissance();
                ActeNaissance crD = new ActeNaissance();
                crD.SetParameterValue(0, DateTime.Now.ToShortDateString());
                crD.SetParameterValue(0, txtPrenomdeNai.Text);
                crD.SetParameterValue(0, txtNomdeNais.Text);
                crD.SetParameterValue(0, txtAdresseNai.Text);
                crD.SetParameterValue(0, dateDeNaissancedeNai.Text);
                crD.SetParameterValue(0, comboNationalite1.Text);
                crD.SetParameterValue(0, txtNomPere.Text + " " + txtPrenomPere.Text);
                crD.SetParameterValue(0, txtNomMere.Text + " " + txtPrenomMere.Text);
                tt.crystalReportViewer1.ReportSource = crD;
                tt.crystalReportViewer1.Refresh();
                tt.ShowDialog();
                d.dr.Close();
            }
            //Trace t3 = new Trace();
            //t3.Evenement = "Ajouté personne ";
            //t3.Details = "Ajouté personne sur le registre de etat civile avec N° bulletin  :" + txtNumBulletin.Text;
            //Program.liste.Add(t3);
            //SAPNaissance tt = new SAPNaissance();
            //ReportNaissance crD = new ReportNaissance();
            //crD.SetParameterValue(0,DateTime.Now.ToShortDateString());
            //crD.SetParameterValue(0, txtPrenomdeNai.Text);
            //crD.SetParameterValue(0, txtNomdeNais.Text);
            //crD.SetParameterValue(0, txtAdresseNai.Text);
            //crD.SetParameterValue(0, dateDeNaissancedeNai.Text);
            //crD.SetParameterValue(0, comboNationalite1.Text);
            //crD.SetParameterValue(0, txtNomPere.Text+" "+txtPrenomPere.Text);
            //crD.SetParameterValue(0, txtNomMere.Text+" "+txtPrenomMere.Text);
            //tt.crystalReportViewer1.ReportSource = crD;
            //tt.crystalReportViewer1.Refresh();
            //tt.ShowDialog();
        }
        int Existe(string CIN, string sexe)
        {
            if(sexe == "Homme")
            {
                d.cmd.CommandText = "select count(*) from Homme where CIN = '" + CIN + "'";
                d.cmd.Connection = d.cnx;
                return (int)d.cmd.ExecuteScalar();
            }
            else
            {
                d.cmd.CommandText = "select count(*) from Femme where CIN = '" + CIN + "'";
                d.cmd.Connection = d.cnx;
                return (int)d.cmd.ExecuteScalar();
            }
            //return 0;
        }
        ADO d = new ADO();
        private void txtNumBulletin_TextChanged(object sender, EventArgs e)
        {
            if (txtNumBulletin.Text.Trim() != "")
            {
                lblNum.Text = "";
            }
            else
            {
                lblNum.Text = "Ce champ est obligatoire *";
            }
        }

        private void txtNomdeNais_TextChanged(object sender, EventArgs e)
        {
            if (txtNomdeNais.Text.Trim() != "")
            {
                lblNomObli.Text = "";
            }
            else
            {
                lblNomObli.Text = "Ce champ est obligatoire *";
            }
        }

        private void txtPrenomdeNai_TextChanged(object sender, EventArgs e)
        {
            
            if (txtPrenomdeNai.Text.Trim() != "")
            {
                lblPrenomObli.Text = "";
            }
            else
            {
                lblPrenomObli.Text = "Ce champ est obligatoire *";
            }
        }


        private void txtAdresseNai_TextChanged(object sender, EventArgs e)
        {
            if (txtAdresseNai.Text.Trim() != "")
            {
                lblAdrsseObli.Text = "";
            }
            else
            {
                lblAdrsseObli.Text = "Ce champ est obligatoire *";
            }
        }

        private void checkVivantMere_Click(object sender, EventArgs e)
        {

        }

        private void DeclarationDeNaissance_Load(object sender, EventArgs e)
        {
            d.Connecter();
            lblID.Text = Form1.IDUser;
            d.cmd.CommandText = "select Nom, Prenom from Officiers where ID = '" + lblID.Text + "'";
            d.cmd.Connection = d.cnx;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            d.dr.Close();
            lblNom.Text = d.dt.Rows[0][0].ToString();
            lblPrenom.Text = d.dt.Rows[0][1].ToString();
            lblDate.Text = DateTime.Now.ToString();
        }

        private void dateDeNaissancedeNai_ValueChanged(object sender, EventArgs e)
        {
            d.cmd.CommandText = "select concat(year('" + dateDeNaissancedeNai.Value.ToShortDateString() + "'),format(month('" + dateDeNaissancedeNai.Value.ToShortDateString() + "'),'#00'),day('" + dateDeNaissancedeNai.Value.ToShortDateString() + "'),next value for S1)";
            d.cmd.Connection = d.cnx;
            txtNumBulletin.Text = (string)d.cmd.ExecuteScalar();
        }

        private void tabOfficer_Click(object sender, EventArgs e)
        {

        }
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        public DataTable SearchPersonne(string cin,string type)
        {
            d.Connecter();
            if(type == "Pere")
            {
                dt.Clear();
                d.cmd.CommandText = "select top 1 * from Homme  where Homme.CIN like '" + cin.Replace("'", " ") + "%'";
                d.cmd.Connection = d.cnx;
                d.dr = d.cmd.ExecuteReader();
                dt.Load(d.dr);
                d.dr.Close();
            }
            else
            {
                dt2.Clear();
                d.cmd.CommandText = "select top 1 * from Femme where Femme.CIN like '" + cin.Replace("'"," ") + "%'";
                d.cmd.Connection = d.cnx;
                d.dr = d.cmd.ExecuteReader();
                dt2.Load(d.dr);
                d.dr.Close();
                return dt2;
            }
            return dt;
        }

        void ViderPere()
        {
            comboPayPere.SelectedIndex = 42;
            comboPereNationalite2.SelectedIndex = 42;
            comboVillePere.SelectedIndex = 0;
            txtNomPere.Text = "";
            txtPrenomPere.Text = "";
            dateNaissPere.Value = DateTime.Now;
            txtAdressePere.Text = "";
            comboVillePere.Text = "";
            txtProfessionPere.Text = "";
            comboSituationPere.SelectedIndex = 0;
            txtTelPere.Text = "";
            RadioPereDeces.Checked = false;
            RadioPereVivant.Checked = false;
            dt.Clear();
            //SearchPersonne("").Clear();
        }
        void ViderMere()
        {
            comboPayMere.SelectedIndex = 42;
            comboMereNationalite2.SelectedIndex = 42;
            comboVilleMere.SelectedIndex = 0;
            txtNomMere.Text = "";
            txtPrenomMere.Text = "";
            dateNaissMere.Value = DateTime.Now;
            txtAdresseMere.Text = "";
            comboVilleMere.Text = "";
            txtProfessionMere.Text = "";
            comboSituationMere.SelectedIndex = 0;
            txtTelMere.Text = "";
            RadioMereDeces.Checked = false;
            RadioMereVivant.Checked = false;
            dt2.Clear();
            //SearchPersonne("").Clear();
        }

        private void guna2CustomRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtCinDeclarant.Text = txtCinPere.Text;
            txtNomDeclarant.Text = txtNomPere.Text;
            txtPrenomDeclarant.Text = txtPrenomPere.Text;
            comboVilleDeclarant.Text = comboVillePere.Text;
            comboPaysDeclarant.Text = comboPayPere.Text;
            comboVilleDeclarant.Text = comboSituationPere.Text;
            txtAddressDeclarant.Text = txtAdressePere.Text;
            txtTelDeclarant.Text = txtTelPere.Text;
            txtProfessionDeclarant.Text = txtProfessionPere.Text;
            dateNaissanceDeclarant.Value = dateNaissPere.Value;
            comboSexeDeclarant.Text = "Homme";
        }

        private void guna2CustomRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtCinDeclarant.Text = txtCinMere.Text;
            txtNomDeclarant.Text = txtNomMere.Text;
            txtPrenomDeclarant.Text = txtPrenomMere.Text;
            comboVilleDeclarant.Text = comboVilleMere.Text;
            comboPaysDeclarant.Text = comboPayMere.Text;
            comboVilleDeclarant.Text = comboSituationMere.Text;
            txtAddressDeclarant.Text = txtAdresseMere.Text;
            txtTelDeclarant.Text = txtTelMere.Text;
            txtProfessionDeclarant.Text = txtProfessionMere.Text;
            dateNaissanceDeclarant.Value = dateNaissMere.Value;
            comboSexeDeclarant.Text = "Femme";
        }

        private void guna2CustomRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtCinDeclarant.Text = "";
            txtNomDeclarant.Text = "";
            txtPrenomDeclarant.Text = "";
            comboVilleDeclarant.SelectedIndex= 0;
            comboPaysDeclarant.SelectedIndex = 42;
            comboVilleDeclarant.SelectedIndex= 0;
            txtAddressDeclarant.Text = "";
            txtTelDeclarant.Text = "";
            txtProfessionDeclarant.Text = "";
            dateNaissanceDeclarant.Value = DateTime.Now;
            comboSexeDeclarant.Text = "Homme";
        }

        private void Check_1(object sender, EventArgs e)
        {
            lblPrenomPere.Text = txtPrenomPere.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            lblNomPere.Text = txtNomPere.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            lblAddressePere.Text = txtAdressePere.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            lblProfessionPere.Text = txtProfessionPere.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            lblTelPere.Text = txtTelPere.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            
        }

        private void Check_2(object sender, EventArgs e)
        {
            lblPrenomMere.Text = txtPrenomMere.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            lblNomMere.Text = txtNomMere.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            lblProfessionMere.Text = txtProfessionMere.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            lblAddresseMere.Text = txtAdresseMere.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            lblTeleMere.Text = txtTelMere.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
        }

        private void Check_3(object sender, EventArgs e)
        {
            lblPrenomDeclarant.Text = txtPrenomDeclarant.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            lblNomDeclarant.Text = txtNomDeclarant.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            lblProfessionDeclarant.Text = txtProfessionDeclarant.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            lblAddresseDeclarant.Text = txtAddressDeclarant.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            lblTeleDeclarant.Text = txtTelDeclarant.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
            lblCinDeclarant.Text = txtCinDeclarant.Text.Trim() == "" ? "Ce champ est obligatoire *" : "";
        }

        private void txtCinPere_TextChanged_1(object sender, EventArgs e)
        {
            if (txtCinPere.Text.Trim() == "")
            {
                ViderPere();
                return;
            }
            if (SearchPersonne(txtCinPere.Text, "Pere").Rows.Count != 1)
            {
                ViderPere();
                return;
            }
            try
            {
                RadioPereDeces.Checked = false;
                RadioPereVivant.Checked = false;
                txtNomPere.Text = SearchPersonne(txtCinPere.Text, "Pere").Rows[0][1].ToString();
                txtPrenomPere.Text = SearchPersonne(txtCinPere.Text, "Pere").Rows[0][2].ToString();
                dateNaissPere.Value = (DateTime)SearchPersonne(txtCinPere.Text, "Pere").Rows[0][3];
                txtAdressePere.Text = SearchPersonne(txtCinPere.Text, "Pere").Rows[0][4].ToString();
                comboVillePere.Text = SearchPersonne(txtCinPere.Text, "Pere").Rows[0][5].ToString();
                txtProfessionPere.Text = SearchPersonne(txtCinPere.Text, "Pere").Rows[0][6].ToString();
                comboSituationPere.Text = SearchPersonne(txtCinPere.Text, "Pere").Rows[0][7].ToString();
                txtTelPere.Text = SearchPersonne(txtCinPere.Text, "Pere").Rows[0][8].ToString();
                comboPayPere.Text = SearchPersonne(txtCinPere.Text, "Pere").Rows[0][9].ToString();
                comboPereNationalite2.Text = SearchPersonne(txtCinPere.Text, "Pere").Rows[0][10].ToString();
                if (SearchPersonne(txtCinPere.Text, "Pere").Rows[0][12].ToString() == "1")
                    RadioPereDeces.Checked = true;
                else
                    RadioPereVivant.Checked = true;
            }
            catch
            {

            }
            
        }

        private void txtCinMere_TextChanged(object sender, EventArgs e)
        {
            if (txtCinMere.Text.Trim() == "")
            {
                ViderMere();
                return;
            }
            if (SearchPersonne(txtCinMere.Text, "Mere").Rows.Count != 1)
            {
                ViderMere();
                return;
            }
            try
            {
                RadioPereDeces.Checked = false;
                RadioPereVivant.Checked = false;
                txtNomMere.Text = SearchPersonne(txtCinMere.Text, "Mere").Rows[0][1].ToString();
                txtPrenomMere.Text = SearchPersonne(txtCinMere.Text, "Mere").Rows[0][2].ToString();
                dateNaissMere.Value = (DateTime)SearchPersonne(txtCinMere.Text, "Mere").Rows[0][3];
                txtAdresseMere.Text = SearchPersonne(txtCinMere.Text, "Mere").Rows[0][4].ToString();
                comboVilleMere.Text = SearchPersonne(txtCinMere.Text, "Mere").Rows[0][5].ToString();
                txtProfessionMere.Text = SearchPersonne(txtCinMere.Text, "Mere").Rows[0][6].ToString();
                comboSituationMere.Text = SearchPersonne(txtCinMere.Text, "Mere").Rows[0][7].ToString();
                txtTelMere.Text = SearchPersonne(txtCinMere.Text, "Mere").Rows[0][8].ToString();
                comboPayMere.Text = SearchPersonne(txtCinMere.Text, "Mere").Rows[0][9].ToString();
                comboMereNationalite2.Text = SearchPersonne(txtCinMere.Text, "Mere").Rows[0][10].ToString();
                if (SearchPersonne(txtCinMere.Text, "Mere").Rows[0][12].ToString() == "1")
                    RadioMereDeces.Checked = true;
                else
                    RadioMereVivant.Checked = true;
            }
            catch
            {

            }
            
        }
    }
   
}