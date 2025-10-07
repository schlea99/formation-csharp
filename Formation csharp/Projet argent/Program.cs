using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_argent
{
    class Program
    {
        /* Questions projet Argent
         * Contraintes - 1. Les différentes opérations : 
         * dépot argent sur compte : 0 (environnement) -> compte destinataire
         * retrait argent du compte : compte expediteur -> 0 (environnement)
         * virement entre 2 comptes (3 choix) : compte courant id1 -> livret id1 //  livret id1 -> compte courant id1 // compte courant id1 -> compte courant id2 ou compte courant id2 -> compte courant id1 
         * dans l'exemple donné : courant 1 -> courant 2 // courant 2 -> courant 1 // courant 2 -> livret 21 // livret 21 -> courant 2 // courant 1 -> livret 11 // courant 1 -> livret 12 // livret 11 -> courant 1 // livret 12 -> courant 1 
         * suite : livret 11 -> livret 12 // livret 12 -> livret 11
         * prélèvement sur commpte : idem
         * 
         * Plafond - 
         * 1. Montant max virement autorisé le 17/04/25 : 380e
         * 2. Horodatage pour un virement de 400e : 22/04/25 10:50:11 (si aucune autre transaction n'a eu lieu après la dernière transaction du 16/04/25) montant max à 480e
         *    Horodatage pour un virement de 600e : 24/04/25 16:54:15 (si aucune autre transaction n'a eu lieu après la dernière transaction du 16/04/25) montant max à 830e
         */

        static void Main(string[] args)
        {
            Banque.Traiterlestarnsactions(); 
        }
    }
}
