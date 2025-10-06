using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_argent
{
    public class Lecture_fichiers
    {
        public static List<Compte_bancaire> CompteBancaire()
        {

            // Lecture fichier compte bancaire        
            using (FileStream f = File.OpenRead(@"C:\Users\Formation\Desktop\CompteBancaire.csv"))
            using (StreamReader rcompte = new StreamReader(f))
            {
                Console.WriteLine(rcompte.ReadLine());
                String line = rcompte.ReadLine();

                while (line != null)
                {
                    var champs = line.Split(';');                                 
                 
                    bool success = int.TryParse(champs[0], out int identifiant);
                    if ()
                        if (success)
                        {
                            Console.WriteLine($"Converted '{value}' to {number}.");
                        }
                        else
                        {
                            Console.WriteLine($"Attempted conversion of '{value ?? "<null>"}' faile
                

                                    decimal solde = champs[3];
                    string type = champs[2];
                    string numerocarte = champs[1];

                    line = rcompte.ReadLine();

                    //bool variable = true;



                 Compte_bancaire cptbancaire = new Compte_bancaire(identifiant, solde, type, numerocarte);    

                }
                

                


                    // if numero compte, if solde, if type, if numerocarte



                }
            }




        }





        public void CarteBancaire()
        {
            // Lecture fichier carte bancaire        
            using (FileStream f = File.OpenRead(@"C:\Users\Formation\Desktop\CarteBancaire.csv"))
            using (StreamReader rcarte = new StreamReader(f))
            {
                Console.WriteLine(rcarte.ReadLine());

                foreach (string line in )
                {
                    var champs = line.Split(';');

                    string numerocarte = champs[0];
                    int plafond = champs[1];
                }


            }
        }

        public void Transactions()
        {
            // Lecture fichier transactions       
            using (FileStream f = File.OpenRead(@"C:\Users\Formation\Desktop\Transactions.csv"))
            using (StreamReader rtransaction = new StreamReader(f))
            {
                Console.WriteLine(rtransaction.ReadLine());

                int numerotransaction = champs[0];
                DateTime horodatage = champs[1];
                decimal montant = champs[2];
                int idexpediteur = champs[3];
                int iddestinataire = champs[4];

            }
        }



    }



}






