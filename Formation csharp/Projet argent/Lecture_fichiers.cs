using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_argent
{
    public class Lecture_fichiers
    {
        public static List<Compte_bancaire> LireCompte(string cheminfichier)
        {
            List<Compte_bancaire> ComptesBancaires = new List<Compte_bancaire>();

            // Lecture fichier compte bancaire
            //cheminfichier = @"C:\Users\Formation\Desktop\CarteBancaire.csv";

            using (FileStream f = File.OpenRead(cheminfichier))
            using (StreamReader rcompte = new StreamReader(f))
            {
                // Console.WriteLine(rcompte.ReadLine());
                string line = rcompte.ReadLine();

                // Liste pour les identifiants déjà utilisés
                List<int> Id_Use = new List<int>();

                while (line != null)
                {
                    var champs = line.Split(';');

                    // déclaration de l'identifiant 
                    bool successid = int.TryParse(champs[0], out int identifiant);

                    if (successid)
                    {
                        Console.WriteLine($"Conversion {champs[0]} en {identifiant}");
                        successid = true;
                    }
                    else
                    {
                        successid = false;
                    }

                    // déclaration du solde
                    decimal solde = 0;

                    bool successSolde = decimal.TryParse(champs[3], NumberStyles.AllowCurrencySymbol, CultureInfo.CreateSpecificCulture("fr-FR"), out solde);

                    if (successSolde)
                    {
                        Console.WriteLine($"Conversion {champs[3]} en {solde}");
                        successSolde = true;
                    }
                    else
                    {
                        successSolde = false;
                    }

                    // déclaration du type de compte (livret ou compte)
                    string type = champs[2];

                    // déclaration du numéro de carte
                    string numerocarte = champs[1];

                    // vérification du format des champs
                    // identifiant : entier positif non nul et unique 
                    // solde : entier (le '.' en décimal est vérifié dans le try.parse)
                    // type : soit courant, soit livret                  

                    if (identifiant >= 0 && !Id_Use.Contains(identifiant))
                    {
                        if (type == Banque.CompteCourant || type == Banque.CompteLivret)
                        {
                            ComptesBancaires.Add(new Compte_bancaire(identifiant, solde, type, numerocarte));
                            Id_Use.Add(identifiant);
                        }
                    }
                    else
                    {
                        continue;
                    }

                    line = rcompte.ReadLine();
                }
            }

            return ComptesBancaires;
        }


        public static List<Carte_bancaire> LireCarte(string cheminfichier)
        {
            List<Carte_bancaire> CartesBancaires = new List<Carte_bancaire>();

            // Lecture fichier carte bancaire        
            // cheminfichier = @"C:\Users\Formation\Desktop\CarteBancaire.csv";

            using (FileStream f = File.OpenRead(cheminfichier))
            using (StreamReader rcarte = new StreamReader(f))
            {
                // Console.WriteLine(rcarte.ReadLine());
                string line = rcarte.ReadLine();

                // Liste pour les numéros de carte déjà utilisés
                List<string> Num_Use = new List<string>();

                while (line != null)
                {
                    var champs = line.Split(';');

                    // déclaration du numéro carte
                    string numerocarte = champs[0];

                    // déclaration plafond de la carte
                    int plafond = 500;

                    bool successPlafond = int.TryParse(champs[1], out plafond);

                    if (successPlafond)
                    {
                        Console.WriteLine($"Conversion {champs[1]} en {plafond}");
                        successPlafond = true;
                    }
                    else
                    {
                        successPlafond = false;
                    }

                    // vérification du format des champs
                    // numéro de carte : entier positif à 16 chiffres et unique 
                    // plafond : entre 500 et 3000 

                    if (numerocarte.Length == 16 && !Num_Use.Contains(numerocarte))
                    {
                        if (500 <= plafond && plafond <= 3000)
                        {
                            CartesBancaires.Add(new Carte_bancaire(numerocarte, plafond));
                            Num_Use.Add(numerocarte);

                        }
                    }
                    else
                    {
                        continue;
                    }

                    line = rcarte.ReadLine();
                }
            }
            return CartesBancaires;
        }

        public static List<Transactions> LireTransaction(string cheminfichier)
        {
            List<Transactions> Transactions = new List<Transactions>();

            // Lecture fichier transactions
            //cheminfichier = @"C:\Users\Formation\Desktop\Transactions.csv";

            using (FileStream f = File.OpenRead(cheminfichier))
            using (StreamReader rtransaction = new StreamReader(f))
            {
                //Console.WriteLine(rtransaction.ReadLine());
                string line = rtransaction.ReadLine();

                // Liste pour les numéros de transaction déjà utilisés
                List<int> Transac_Use = new List<int>();

                while (line != null)
                {
                    var champs = line.Split(';');

                    // déclaration numéro transaction 

                    bool successnum = int.TryParse(champs[0], out int numerotransaction);

                    if (successnum)
                    {
                        Console.WriteLine($"Conversion {champs[0]} en {numerotransaction}");
                        successnum = true;
                    }
                    else
                    {
                        successnum = false;
                    }

                    // déclaration date de transaction

                    bool successdate = DateTime.TryParseExact(champs[1], "DD/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime horodatage);

                    if (successdate)
                    {
                        Console.WriteLine($"Conversion {champs[1]} en {horodatage}");
                        successdate = true;
                    }
                    else
                    {
                        successdate = false;
                    }

                    // déclaration montant transaction                  
       
                    bool successMontant = decimal.TryParse(champs[2], NumberStyles.AllowCurrencySymbol, CultureInfo.CreateSpecificCulture("fr-FR"), out decimal montant);

                    if (successMontant)
                    {
                        Console.WriteLine($"Conversion {champs[2]} en {montant}");
                        successMontant = true;
                    }
                    else
                    {
                        successMontant = false;
                    }

                    // déclaration identifiant expéditeur 

                    bool successexp = int.TryParse(champs[3], out int idexpediteur);

                    if (successexp)
                    {
                        Console.WriteLine($"Conversion {champs[3]} en {idexpediteur}");
                        successexp = true;
                    }
                    else
                    {
                        successexp = false;
                    }

                    // déclaration identifiant destinataire 

                    bool successdes = int.TryParse(champs[4], out int iddestinataire);

                    if (successdes)
                    {
                        Console.WriteLine($"Conversion {champs[4]} en {iddestinataire}");
                        successdes = true;
                    }
                    else
                    {
                        successdes = false;
                    }

                    // vérification du format des champs

                    if (numerotransaction >= 0 && Transac_Use.Contains(numerotransaction))
                    {
                        if (iddestinataire >= 0 && idexpediteur >= 0)
                        {
                            if (montant >= 0)
                            {
                                Transactions.Add(new Transactions(numerotransaction, horodatage, montant, idexpediteur, iddestinataire));
                                Transac_Use.Add(numerotransaction);
                            }                                 
                        }
                    }
                    else
                    {
                        continue;
                    }

                    line = rtransaction.ReadLine();
                }
            }
            return Transactions;
        }

    }

}






