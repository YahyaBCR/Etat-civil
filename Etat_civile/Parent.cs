using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etat_civile
{
    class Parent
    {
        public string CIN;
        public string Nom;
        public string Prenom;
        public string Ville;
        public string Addresse;
        public string Profession;
        public string Telephone;
        public string Genre;
        public string StatuFamiliale;

        public Parent(string cIN, string nom, string prenom,  string addresse, string profession, string telephone)
        {
            CIN = cIN;
            Nom = nom;
            Prenom = prenom;
            Addresse = addresse;
            Profession = profession;
            Telephone = telephone;
            //Genre = genre;
            //StatuFamiliale = statuFamiliale;
        }
    }

    class Naissance
    {
        public string Nom;
        public string Prenom;
        public string Ville;
        public string Addresse;

        public Naissance(string nom, string prenom, string ville, string addresse)
        {
            Nom = nom;
            Prenom = prenom;
            Ville = ville;
            Addresse = addresse;
        }
    }
}
