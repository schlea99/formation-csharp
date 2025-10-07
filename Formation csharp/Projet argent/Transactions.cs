using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_argent
{
    public class Transactions
    {
        public int NumeroTransaction { get; set; }
        public DateTime Horodatage { get; set; }
        public decimal Montant { get; set; }      
        public int IdExpediteur { get; set; }
        public int IdDestinataire { get; set; }

        public Transactions(int numerotransaction, DateTime horodatage, decimal montant, int idexpediteur, int iddestinataire )
        {
            NumeroTransaction = numerotransaction;
            Horodatage = horodatage;
            Montant = montant;        
            IdExpediteur = idexpediteur;
            IdDestinataire = iddestinataire; 
        }



    }
}
