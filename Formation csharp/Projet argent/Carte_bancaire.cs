using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_argent
{
    public class Carte_bancaire
    {
        public string Numerocarte { get; set; }
        public int Plafond { get; set; }

        public List<(DateTime horodatage, int numtransaction,decimal montant,string type)> Historique { get; set; } = new List<(DateTime, int, decimal,string)>();

        public List<int> ComptesAssocies { get; set; } = new List<int>();

        public Carte_bancaire(string numerocarte, int plafond)
        {
            Numerocarte = numerocarte;
            Plafond = plafond;
        }

        public void AjouterHistorique (DateTime horodatage, int numtransaction, decimal montant, string type)
        {
            Historique.Add((horodatage, numtransaction, montant, type));
        }

        public void ListeComptesAssocies (int identifiant)
        {
            ComptesAssocies.Add(identifiant);
        }

        // Total des transactions ne dépassant pas le plafond de débit de la carte (renouvelé tous les 10 jours)
        public decimal TotalTransactions(DateTime horodatage)
        {
            DateTime debutcomptage = horodatage.AddDays(-10);
            decimal somme = 0;

            foreach (var num in Historique)
            {
                if (num.horodatage >= debutcomptage && num.horodatage <= horodatage)
                {
                    somme += num.montant;
                }
            }
            return somme;
        }












    }
}
