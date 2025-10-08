using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_argent
{
    public class Compte_bancaire
    {
        public int Identifiant { get; private set; }
        public decimal Solde { get; private set; } // financier ou scientifique en décimal
        public string Type { get; private set; }
        public string Numerocarte { get; private set; }

        public Compte_bancaire(int identifiant, decimal solde, string type, string numerocarte)
        {
            Identifiant = identifiant;
            Solde = solde;
            Type = type;
            Numerocarte = numerocarte;
        }

        public bool Depot_compte(decimal montant)
        {
            if (montant <= 0)
            {
                return false;
            }
            else
            {
                Solde += montant;
                return true;
            }

        }

        public bool Retrait_compte(decimal montant)
        {
            if (montant <= 0)
            {
                return false;
            }
            if (Solde < montant)
            {
                return false;
            }
            else
            {
                Solde -= montant;
                return true;
            }
        }

        public bool Virement_compte(Compte_bancaire destinataire, decimal montant)
        {
            if (destinataire == null)
            {
                return false;
            }
            if (montant <= 0)
            {
                return false;
            }
            if (Solde < montant)
            {
                return false;
            }
            else
            {
                Solde -= montant;
                destinataire.Solde += montant;
                return true;
            }
        }

        /*  public bool Prelevement_compte(Compte_bancaire expediteur, decimal montant)
          {
              if (expediteur == null)
              {
                  return false;
              }
              if (montant <= 0)
              {
                  return false;
              }
              if (expediteur.Solde < montant)
              {
                  return false;
              }
              else
              {
                  Solde += montant;
                  expediteur.Solde -= montant;
                  return true;

              }
            }*/
    }
}
