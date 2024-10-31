using System;
using System.Data;
using System.Windows.Forms;

namespace Etat_civile
{
    public partial class DeclarationDivorce : UserControl
    {
        public DeclarationDivorce()
        {
            InitializeComponent();
        }
        ADO d = new ADO();


        void Check_Text_Homme()
        {
            lblPrenomHomme.Text = txtPrenomHomme.Text == "" ? "Ce champ est obligatoire *" : "";
            lblNomHomme.Text = txtNomHomme.Text == "" ? "Ce champ est obligatoire *" : "";
            lblAdresseHomme.Text = txtAdresseHomme.Text == "" ? "Ce champ est obligatoire *" : "";
            lblProfessionHomme.Text = txtProfessionHomme.Text == "" ? "Ce champ est obligatoire *" : "";
            lblTeleHomme.Text = txtTelHomme.Text == "" ? "Ce champ est obligatoire *" : "";
            lblCinHomme.Text = txtCinHomme.Text == "" ? "Ce champ est obligatoire *" : "";
        }

        void Check_Text_Femme()
        {
            lblPrenomFemme.Text = txtPrenomFemme.Text == "" ? "Ce champ est obligatoire *" : "";
            lblNomFemme.Text = txtNomFemme.Text == "" ? "Ce champ est obligatoire *" : "";
            lblAdresseFemme.Text = txtAdresseFemme.Text == "" ? "Ce champ est obligatoire *" : "";
            lblProfessionFemme.Text = txtProfessionFemme.Text == "" ? "Ce champ est obligatoire *" : "";
            lblTeleFemme.Text = txtTelFemme.Text == "" ? "Ce champ est obligatoire *" : "";
            lblCinFemme.Text = txtCinFemme.Text == "" ? "Ce champ est obligatoire *" : "";
        }
        //int Existee()
        //{
        //    d.cmd.CommandText = "select * from Divorce where Num = '" + txtID.Text + "'";
        //    d.cmd.Connection = d.cnx;
        //    int i = (int)d.cmd.ExecuteScalar();
        //    return 0;
        //}
        private void btnSuivante_Click(object sender, EventArgs e)
        {
            foreach (Control crt in guna2TabControl10.Controls)
            {
                foreach (Control ct in crt.Controls)
                {
                    if (ct.GetType() == typeof(Guna.UI2.WinForms.Guna2TextBox))
                    {
                        if (ct.Text.Trim() == "")
                        {
                            MessageBox.Show("Tout les champs sont obligatoire", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Check_Text_Homme();
                            Check_Text_Femme();
                            return;
                        }
                    }
                }
            }
            if (Exist("Homme", txtCinHomme.Text) == 0)
            {
                d.cmd.CommandText = "insert into femme  values ('" + txtCinHomme.Text.Replace("'", " ") + "','" + txtNomHomme.Text.Replace("'", " ") + "','" + txtPrenomHomme.Text.Replace("'", " ") + "','" + dateNaissHomme.Value.ToShortDateString() + "'" +
                    ",'" + txtAdresseHomme.Text.Replace("'", " ") + "','" + comboVille.Text.Replace("'", " ") + "','" + txtProfessionHomme.Text.Replace("'", " ") + "','" + comboSituationHomme.Text.Replace("'", " ") + "','" + txtTelHomme.Text.Replace("'", " ") + "','" + comboNationalite1Homme.Text.Replace("'", " ") + "'" +
                    ",'" + comboNationalite2Homme.Text.Replace("'", " ") + "')";
                d.cmd.Connection = d.cnx;
                d.cmd.ExecuteNonQuery();
                Trace t = new Trace();
                t.Evenement = "Ajouté personne ";
                t.Details = "Ajouté personne sur la table Femme " + txtCinFemme.Text;
                Program.liste.Add(t);
            }
            if (Exist("Femme", txtCinFemme.Text) == 0)
            {
                d.cmd.CommandText = "insert into Homme values ('" + txtCinFemme.Text.Replace("'", " ") + "','" + txtNomFemme.Text.Replace("'", " ") + "','" + txtPrenomFemme.Text.Replace("'", " ") + "','" + dateNaissFemme.Value.ToShortDateString() + "'" +
                    ",'" + txtAdresseFemme.Text.Replace("'", " ") + "','" + comboVilleFemme.Text.Replace("'", " ") + "','" + txtProfessionFemme.Text.Replace("'", " ") + "','" + comboSituationFemme.Text.Replace("'", " ") + "','" + txtTelFemme.Text.Replace("'", " ") + "','" + comboNationalite1Femme.Text.Replace("'", " ") + "'" +
                    ",'" + comboNationalite2Femme.Text.Replace("'", " ") + "') ";
                d.cmd.Connection = d.cnx;
                d.cmd.ExecuteNonQuery();
                Trace t1 = new Trace();
                t1.Evenement = "Ajouté personne ";
                t1.Details = "Ajouté personne sur Homme :" + txtCinHomme.Text;
                Program.liste.Add(t1);
            }
            d.cmd.CommandText = "insert into Divorce values ((next value for Divorce_Id),'" + DateTime.Now.ToString() + "','" + comboLieu.Text + "','" + Type.Text + "','" + txtCinHomme.Text + "','" + txtCinFemme.Text + "','" + txtRapport.Text+ "','" + lblID.Text + "','"+ txtID.Text + "')";
            d.cmd.Connection = d.cnx;
            d.cmd.ExecuteNonQuery();
            Trace t3 = new Trace();
            t3.Evenement = "Ajouté personne ";
            t3.Details = "Ajouté deux personnes comme divorce avec CIN pour Femme "+txtCinFemme.Text+ " CIN pour Homme :"+txtCinHomme.Text ;
            Program.liste.Add(t3);
        }

        private void DeclarationDivorce_Load(object sender, EventArgs e)
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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
        }


        private void txtCinHomme_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtNomHomme.Text = SearchPersonne(txtCinHomme.Text, "Homme").Rows[0][1].ToString();
                txtPrenomHomme.Text = SearchPersonne(txtCinHomme.Text, "Homme").Rows[0][2].ToString();
                dateNaissHomme.Value = (DateTime)SearchPersonne(txtCinHomme.Text, "Homme").Rows[0][3];
                txtAdresseHomme.Text = SearchPersonne(txtCinHomme.Text, "Homme").Rows[0][4].ToString();
                comboVille.Text = SearchPersonne(txtCinHomme.Text, "Homme").Rows[0][5].ToString();
                txtProfessionHomme.Text = SearchPersonne(txtCinHomme.Text, "Homme").Rows[0][6].ToString();
                comboSituationHomme.Text = SearchPersonne(txtCinHomme.Text, "Homme").Rows[0][7].ToString();
                txtTelHomme.Text = SearchPersonne(txtCinHomme.Text, "Homme").Rows[0][8].ToString();
                comboNationalite1Homme.Text = SearchPersonne(txtCinHomme.Text, "Homme").Rows[0][9].ToString();
                comboNationalite2Homme.Text = SearchPersonne(txtCinHomme.Text, "Homme").Rows[0][10].ToString();
            }
            catch
            {
                txtNomHomme.Text = "";
                txtPrenomHomme.Text = "";
                txtAdresseHomme.Text = "";
                comboVille.SelectedIndex = 0;
                txtProfessionHomme.Text = "";
                comboSituationHomme.SelectedIndex = 0;
                txtTelHomme.Text = "";
                comboNationalite1Homme.SelectedIndex = 0;
                comboNationalite2Homme.SelectedIndex = 0;
            }
        }
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        public DataTable SearchPersonne(string cin, string type)
        {
            d.Connecter();
            if (type == "Homme")
            {
                dt.Clear();
                d.cmd.CommandText = "select top 1 * from Homme where CIN like '" + cin.Replace("'", " ") + "'";
                d.cmd.Connection = d.cnx;
                d.dr = d.cmd.ExecuteReader();
                dt.Load(d.dr);
                d.dr.Close();
            }
            else
            {
                dt2.Clear();
                d.cmd.CommandText = "select top 1 * from Femme where CIN like '" + cin.Replace("'", " ") + "'";
                d.cmd.Connection = d.cnx;
                d.dr = d.cmd.ExecuteReader();
                dt2.Load(d.dr);
                d.dr.Close();
                return dt2;
            }
            return dt;
        }

        int Exist(string table, string cin)
        {
            d.cmd.CommandText = "select count(*) from  [" + table + "] where CIN = '" + cin + "'";
            d.cmd.Connection = d.cnx;
            return (int)d.cmd.ExecuteScalar();
        }

        private void txtCinFemme_TextChanged_1(object sender, EventArgs e)
        {
            if (txtCinFemme.Text.Trim() == "")
            {
                lblCinFemme.Text = "Ce champ est obligatoire *";
            }
            else
                lblCinFemme.Text = "";
            try
            {
                txtNomFemme.Text = SearchPersonne(txtCinFemme.Text, "Femme").Rows[0][1].ToString();
                txtPrenomFemme.Text = SearchPersonne(txtCinFemme.Text, "Femme").Rows[0][2].ToString();
                dateNaissFemme.Value = (DateTime)SearchPersonne(txtCinFemme.Text, "Femme").Rows[0][3];
                txtAdresseFemme.Text = SearchPersonne(txtCinFemme.Text, "Femme").Rows[0][4].ToString();
                comboVilleFemme.Text = SearchPersonne(txtCinFemme.Text, "Femme").Rows[0][5].ToString();
                txtProfessionFemme.Text = SearchPersonne(txtCinFemme.Text, "Femme").Rows[0][6].ToString();
                comboSituationFemme.Text = SearchPersonne(txtCinFemme.Text, "Femme").Rows[0][7].ToString();
                txtTelFemme.Text = SearchPersonne(txtCinFemme.Text, "Femme").Rows[0][8].ToString();
                comboNationalite1Femme.Text = SearchPersonne(txtCinFemme.Text, "Femme").Rows[0][9].ToString();
                comboNationalite2Femme.Text = SearchPersonne(txtCinFemme.Text, "Femme").Rows[0][10].ToString();
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
                lblPrenomHomme.Text = txtPrenomHomme.Text == "" ? "Ce champ est obligatoire *" : "";
            if (txtNomHomme.Focused)
                lblNomHomme.Text = txtNomHomme.Text == "" ? "Ce champ est obligatoire *" : "";
            if (txtAdresseHomme.Focused)
                lblAdresseHomme.Text = txtAdresseHomme.Text == "" ? "Ce champ est obligatoire *" : "";
            if (txtProfessionHomme.Focused)
                lblProfessionHomme.Text = txtProfessionHomme.Text == "" ? "Ce champ est obligatoire *" : "";
            if (txtTelHomme.Focused)
                lblTeleHomme.Text = txtTelHomme.Text == "" ? "Ce champ est obligatoire *" : "";
            if (txtCinHomme.Focused)
                lblCinHomme.Text = txtCinHomme.Text == "" ? "Ce champ est obligatoire *" : "";
        }

        private void Check_Femme(object sender, EventArgs e)
        {
            if (txtPrenomFemme.Focused)
                lblPrenomFemme.Text = txtPrenomFemme.Text == "" ? "Ce champ est obligatoire *" : "";
            if (txtNomFemme.Focused)
                lblNomFemme.Text = txtNomFemme.Text == "" ? "Ce champ est obligatoire *" : "";
            if (txtAdresseFemme.Focused)
                lblAdresseFemme.Text = txtAdresseFemme.Text == "" ? "Ce champ est obligatoire *" : "";
            if (txtProfessionFemme.Focused)
                lblProfessionFemme.Text = txtProfessionFemme.Text == "" ? "Ce champ est obligatoire *" : "";
            if (txtTelFemme.Focused)
                lblTeleFemme.Text = txtTelFemme.Text == "" ? "Ce champ est obligatoire *" : "";
            if (txtCinFemme.Focused)
                lblCinFemme.Text = txtCinFemme.Text == "" ? "Ce champ est obligatoire *" : "";
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                d.dt.Clear();
                d.cmd.CommandText = "select * from Mariage where Num = '"+txtID.Text+"' ";
                d.cmd.Connection = d.cnx;
                d.dr = d.cmd.ExecuteReader();
                d.dt.Load(d.dr);
                d.dr.Close();
                lblCinHommeInfo.Text = d.dt.Rows[0][4].ToString();
                lblCinFemmeInfo.Text = d.dt.Rows[0][5].ToString();
                lblDateMariage.Text = d.dt.Rows[0][1].ToString();
                lblLieuMariage.Text = d.dt.Rows[0][2].ToString();
                lblCinTre1.Text = d.dt.Rows[0][7].ToString();
                lblCinTre2.Text = d.dt.Rows[0][11].ToString();
                lblNomTre1.Text = d.dt.Rows[0][8].ToString();
                lblNomTre2.Text = d.dt.Rows[0][12].ToString();
                lblPrenomTre1.Text = d.dt.Rows[0][9].ToString();
                lblPrenomTre2.Text = d.dt.Rows[0][13].ToString();
                lblIDOfficier.Text = d.dt.Rows[0][6].ToString();
                lblRapportInfo.Text = d.dt.Rows[0][15].ToString();
                txtCinHomme.Text = lblCinHommeInfo.Text;
                txtCinFemme.Text = lblCinFemmeInfo.Text;

            }
            catch
            {
                lblCinHommeInfo.Text = "";
                lblCinFemmeInfo.Text = "";
                lblDateMariage.Text = "";
                lblLieuMariage.Text = "";
                lblCinTre1.Text = "";
                lblCinTre2.Text = "";
                lblNomTre1.Text = "";
                lblNomTre2.Text = "";
                lblPrenomTre1.Text = "";
                lblPrenomTre2.Text = "";
                lblIDOfficier.Text = "";
                lblRapportInfo.Text = "";
                txtCinHomme.Text = "";
                txtCinFemme.Text = "";
            }
        }
    }
}