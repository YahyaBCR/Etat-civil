using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etat_civile
{
    class ADO
    {
        public SqlConnection cnx = new SqlConnection(@"Data Source=CASPER\SQLEXPRESS;Initial Catalog=Etat_Civile;Integrated Security=True");
        //public SqlConnection cnx = new SqlConnection(@"Data Source=MFDR0X\SQLEXPRESS;Initial Catalog=Etat_Civile;Integrated Security=True");
        public SqlCommand cmd = new SqlCommand();
        public DataTable dt = new DataTable();
        public SqlDataReader dr;

        public void Connecter()
        {
            if (cnx.State == ConnectionState.Closed || cnx.State == ConnectionState.Broken)
            {
                cnx.Open();
            }
        }
        public void Deconnecter()
        {
            if (cnx.State == ConnectionState.Open)
            {
                cnx.Close();
            }
        }

    }
}
