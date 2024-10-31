using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etat_civile
{
    class Validation
    {
        public static bool CheckParent(Parent p )
        {
            if(p.Nom.Trim() == "" || p.Prenom.Trim() == "" || p.CIN.Trim() == "" || p.Telephone.Trim() == "" || p.Profession.Trim() == "" || p.Ville.Trim() == "" || p.Addresse.Trim() == "")
                return false;
            return true;
        }
        public static bool CheckNaiss(Naissance nais)
        {
            if (nais.Nom.Trim() == "" || nais.Prenom.Trim() == "" || nais.Addresse.Trim() == "" || nais.Ville.Trim() == "")
                return false;
            return true;
        }
    }
}
