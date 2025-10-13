using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Or.Models
{
    public class Beneficiaire
    {
        // Propriétaire du compte qui veut faire un virement à un bénéficiaire
        public long NumCarteCompte { get; set; }
        // Identifiant compte bénéficiaire
        public int IdtCptBenef { get; set; }

        public long NumCarteBenef { get; set; }
        public string PrenomBenef { get; set; }
        public string NomBenef { get; set; }
        public TypeCompte TypeDuCompte { get; set; }


        /*public Beneficiaire(long numCarte, int idtCompte, long numcarteClient, string prenomClient, string nomClient, TypeCompte typeCompte)
        {
            NumCarteCompte = numCarte;
            IdtCompte = idtCompte;
            NumCarteBenef = numcarteClient;
            PrenomBenef = prenomClient;
            NomBenef = nomClient;
            TypeDuCompte = typeCompte;
        }*/

        public Beneficiaire()
        {
        }
    }
}
