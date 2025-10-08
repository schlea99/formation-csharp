using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_argent
{
    public class Ecriture_fichier
    {
        public static void EcrireTransaction(string cheminsortie, List<Transactions> Transactions)
        {
            using (StreamWriter writer = new StreamWriter(cheminsortie))
            {
                writer.WriteLine("Etat des lieux des transactions");

                foreach (var transac in Transactions)
                {
                    writer.WriteLine($"{transac.NumeroTransaction};{transac.Statut}");
                }
            }
        }
    }
}


