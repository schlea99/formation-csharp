using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_argent
{
    public class Carte_bancaire
    {
        public string Numerocarte { get; private set; }
        public int Plafond { get; private set; }

        public List<Transactions> Historique { get; set; } = new List<Transactions>();

        public List<int> ComptesAssocies { get; set; } = new List<int>();

        public Carte_bancaire(string numerocarte, int plafond)
        {
            Numerocarte = numerocarte;
            Plafond = plafond;
        }

        public void AjouterHistorique(Transactions historiquetransac) 
        {          
            Historique.Add(historiquetransac);     
        }

        public void ListeComptesAssocies(int identifiant)
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
                if (num.Horodatage >= debutcomptage && num.Horodatage <= horodatage && num.IdExpediteur != 0 && !ComptesAssocies.Contains(num.IdDestinataire))
                {
                    somme += num.Montant;
                }
            }
            return somme;
        }












    }
}
