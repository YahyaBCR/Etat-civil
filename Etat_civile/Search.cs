using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Etat_civile
{
    class Search
    {
        public static DataTable dt = new DataTable();
        public static DataTable dt2 = new DataTable();
        public static ADO d = new ADO();
        public static DataTable SearchPersonne(string cin, string type)
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
    }
}
