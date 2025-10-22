using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_argent
{
    public class Banque
    {
        // Bien les statics readonly
        public static readonly string CompteCourant = "Courant";
        public static readonly string CompteLivret = "Livret";

        // Il aurait été plus simple d'utiliser des dictionnaires avec l'identifiant comme clef
        private List<Compte_bancaire> ComptesBancaires;
        private List<Carte_bancaire> CartesBancaires;
        public List<Transactions> Transactions { get; set; }

        public Banque()
        {
            ComptesBancaires = new List<Compte_bancaire>();
            CartesBancaires = new List<Carte_bancaire>();
            Transactions = new List<Transactions>();
        }

        public void AccepterDonneesFichiers()
        {
            CartesBancaires = Lecture_fichiers.LireCarte(@"C:\Users\Formation\Desktop\CarteBancaire.csv");
            ComptesBancaires = Lecture_fichiers.LireCompte(@"C:\Users\Formation\Desktop\CompteBancaire.csv");
            Transactions = Lecture_fichiers.LireTransaction(@"C:\Users\Formation\Desktop\Transactions.csv");
        }

        public void AssocierComptecarte()
        {
            // Associer les comptes aux cartes 
            foreach (var carte in CartesBancaires)
            {
                foreach (var compte in ComptesBancaires)
                {
                    if (carte.Numerocarte == compte.Numerocarte)
                    {
                        carte.ListeComptesAssocies(compte.Identifiant);
                    }
                }
            }
        }


        public void TraiterTransactions()
        {
            foreach (var transac in Transactions)
            {
                bool statut = false;
                Compte_bancaire stockDest = null;
                Compte_bancaire stockExp = null;

                Carte_bancaire PlafondExp = null;

                Carte_bancaire carteExp = null;
                Carte_bancaire carteDest = null;

                // Cas d'un dépot d'argent : expéditeur environnement (0) vers destinateur compte connu 
                if (transac.IdExpediteur == 0 && (stockDest = ComptesBancaires.Find(cb => cb.Identifiant == transac.IdDestinataire)) != null)
                {
                    if ((carteDest = CartesBancaires.Find(num => num.Numerocarte == stockDest.Numerocarte)) != null)
                    {
                        stockDest.Depot_compte(transac.Montant);
                        statut = true;
                        transac.Statut = "OK";
                        carteDest.AjouterHistorique(transac);
                    }

                    else
                    {
                        transac.Statut = "KO";
                    }

                    Debug.WriteLine($"Transaction {transac.NumeroTransaction} : Statut {transac.Statut}");
                    Debug.WriteLine($"Depot d'argent - Compte destinataire {transac.IdDestinataire}, solde : {stockDest.Solde}");
                    Debug.WriteLine($"Montant transaction : {transac.Montant}");
                    Debug.WriteLine("");
                }

                // J'aurai plus utiliser 
                
                // Cas d'un retrait d'argent : expediteur compte connu vers destinataire environnement (0)
                if (transac.IdDestinataire == 0 && (stockExp = ComptesBancaires.Find(cb => cb.Identifiant == transac.IdExpediteur)) != null)
                {
                    // Beaucoup de if imbriqués - peut-être refactoriser
                    if ((carteExp = CartesBancaires.Find(num => num.Numerocarte == stockExp.Numerocarte)) != null)
                    {
                        if ((PlafondExp = CartesBancaires.Find(p => p.Plafond >= transac.Montant && p.Numerocarte == stockExp.Numerocarte)) != null)
                        {
                            if (PlafondExp.TotalTransactions(transac.Horodatage) + transac.Montant <= PlafondExp.Plafond && transac.Montant < stockExp.Solde)
                            {
                                stockExp.Retrait_compte(transac.Montant);
                                statut = true;
                                transac.Statut = "OK";
                                carteExp.AjouterHistorique(transac);
                            }
                            else
                            {
                                // Tu reviens au sommet et tu ne renvoies pas KO ici
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        // Pourquoi tu écris KO vu que tu l'as mis comme valeur par défaut mais OK
                        transac.Statut = "KO";
                    }

                    Debug.WriteLine($"Transaction {transac.NumeroTransaction} : Statut {transac.Statut}");
                    Debug.WriteLine($"Retrait d'argent - Compte expéditeur {transac.IdExpediteur}, solde : {stockExp.Solde} ");
                    Debug.WriteLine($"Montant transaction : {transac.Montant}");
                    Debug.WriteLine("");
                }

                // Cas d'un virement ou d'un prélèvement : expediteur compte connu et destinataire compte connu
                if ((stockExp = ComptesBancaires.Find(cb => cb.Identifiant == transac.IdExpediteur)) != null && (stockDest = ComptesBancaires.Find(cb => cb.Identifiant == transac.IdDestinataire)) != null)
                {
                    if ((carteExp = CartesBancaires.Find(num => num.Numerocarte == stockExp.Numerocarte)) != null && (carteDest = CartesBancaires.Find(num => num.Numerocarte == stockDest.Numerocarte)) != null)
                    {
                        if ((carteExp.Numerocarte == carteDest.Numerocarte) || (stockExp.Type == CompteCourant && stockDest.Type == CompteCourant))
                        {
                            if ((PlafondExp = CartesBancaires.Find(p => p.Plafond >= transac.Montant && p.Numerocarte == stockExp.Numerocarte)) != null)
                            {
                                if (PlafondExp.TotalTransactions(transac.Horodatage) + transac.Montant <= PlafondExp.Plafond && transac.Montant < stockExp.Solde)
                                {
                                    stockExp.Virement_compte(stockDest, transac.Montant);
                                    statut = true;
                                    transac.Statut = "OK";
                                    carteDest.AjouterHistorique(transac);
                                    carteExp.AjouterHistorique(transac);
                                }

                                else
                                {
                                    transac.Statut = "KO";
                                }
                            }
                        }
                    }
                    Debug.WriteLine($"Transaction {transac.NumeroTransaction} : Statut {transac.Statut}");
                    Debug.WriteLine($"Compte expéditeur {transac.IdExpediteur}, solde : {stockExp.Solde} ");
                    Debug.WriteLine($"Compte destinataire {transac.IdDestinataire}, solde : {stockDest.Solde}");
                    Debug.WriteLine($"Montant transaction : {transac.Montant}");
                    Debug.WriteLine("");

                }

            }
        }

    }
}
