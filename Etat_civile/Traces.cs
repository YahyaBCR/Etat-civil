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
    public partial class Traces : UserControl
    {
        public Traces()
        {
            InitializeComponent();
        }
        ADO d = new ADO();
        private void Traces_Load(object sender, EventArgs e)
        {
            d.Connecter();
            Remplir();
        }
        void Remplir()
        {
            d.dt.Clear();
            d.cmd.CommandText = "select * from Trace where Date = '" + DateTime.Now.ToString() +"' ";
            d.cmd.Connection = d.cnx;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            guna2DataGridView1.DataSource = d.dt;
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == "")
            {
                Remplir();
                return;
            }
            Chercher();
        }
        DataTable dt = new DataTable();
        void Chercher()
        {
            dt.Clear();
            d.cmd.CommandText = "select offi.Id,Nom,Prenom,Type,tr.TimeEntrer,tr.TimeSortie,tr.Evenement,tr.Details,tr.Date from Officiers offi, Trace tr where offi.ID = tr.Id and (offi.Nom= '" + txtID.Text+"' or offi.Id = '"+txtID.Text+"' ) and Date = '"+guna2DateTimePicker1.Value.ToShortDateString()+"'";
            d.cmd.Connection = d.cnx;
            d.dr = d.cmd.ExecuteReader();
            dt.Load(d.dr);
            if (dt.Rows.Count > 0)
                guna2DataGridView1.DataSource = dt;
            else
                d.dt.Clear();
            d.dr.Close();
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Chercher();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblID.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                d.cmd.CommandText = "select Nom,Prenom,Type from Officiers where id = '" + lblID.Text + "'";
                d.cmd.Connection = d.cnx;
                d.dr = d.cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(d.dr);
                d.dr.Close();
                lblNom.Text = dt.Rows[0][0].ToString();
                lblPrenom.Text = dt.Rows[0][1].ToString();
                lblType.Text = dt.Rows[0][2].ToString();
            }
            catch
            {
                lblNom.Text = "";
                lblPrenom.Text = "";
                lblType.Text = "";
            }
            
        }
    }
}
