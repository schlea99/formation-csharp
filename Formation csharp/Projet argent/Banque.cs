using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_argent
{
    public class Banque
    {
        public static readonly string CompteCourant = "Courant";
        public static readonly string CompteLivret = "Livret";

        public string Statut { get; set; }

        public List<Compte_bancaire> ComptesBancaires { get; private set; }
        public List<Carte_bancaire> CartesBancaires { get; private set; }
        public List<Transactions> Transactions { get; private set; }

        public Banque()
        {
            ComptesBancaires = new List<Compte_bancaire>();
            CartesBancaires = new List<Carte_bancaire>();
            Transactions = new List<Transactions>();
        }

        public void AccepterDonneesFichiers()
        {
            CartesBancaires = Lecture_fichiers.LireCarte(@"C:\Users\Formation\Desktop\CarteBancaire.csv");
            ComptesBancaires = Lecture_fichiers.LireCompte(@"C:\Users\Formation\Desktop\CarteBancaire.csv");
            Transactions = Lecture_fichiers.LireTransaction(@"C:\Users\Formation\Desktop\Transactions.csv");
        }


        public void TraiterTransaction()
        {
            foreach (var transac in Transactions)
            {
                Statut = "KO";
                Compte_bancaire stockDest = null;
                Compte_bancaire stockExp = null;

                // Cas d'un dépot d'argent : expéditeur environnement (0) vers destinateur compte connu 
                if (transac.IdExpediteur == 0 && (stockDest = ComptesBancaires.Find(cb => cb.Identifiant == transac.IdDestinataire)) != null)
                {
                    stockDest.Depot_compte(transac.Montant);
                    Statut = "OK";
                }

                // Cas d'un retrait d'argent : expediteur compte connu vers destinataire environnement (0)
                if (transac.IdDestinataire == 0 && (stockExp = ComptesBancaires.Find(cb => cb.Identifiant == transac.IdExpediteur)) != null)
                {
                    stockExp.Retrait_compte(transac.Montant);
                    Statut = "OK";
                }

                // Cas d'un virement : expediteur compte connu et destinataire compte connu
                if ((stockExp = ComptesBancaires.Find(cb => cb.Identifiant == transac.IdExpediteur)) != null && (stockDest = ComptesBancaires.Find(cb => cb.Identifiant == transac.IdDestinataire)) != null)
                {
                    stockExp.Virement_compte(stockDest, transac.Montant);
                    Statut = "OK";
                }

                // Ajouter à l'historique des transactions dans Carte_bancaire
                if (Statut == "OK")
                {
                    string numerocarte = stockExp.Numerocarte;
                    Carte_bancaire carte = CartesBancaires.Find


                    Carte_bancaire.AjouterHistorique(transac.Horodatage, transac.NumeroTransaction, transac.Montant);
                }






            }
        }
        // ajouter à l'historique de transactions (dans carte) 
        // Comptes associés cartes (dans carte)
        // vérifier si transaction possible : plafond non atteint ==> appeler carte; total transaction et 'solde suffisant (ok)' 
    }
}
