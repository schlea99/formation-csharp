using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice

{
    public static class TasksTables
    {
        public static int SumTab(int[] tab)
        {
            // Renvoi de la valeur -1 si résultat indéfini
            if (tab == null)
            {
                return -1;
            }
            else
            {
                // Calcul de la somme
                int somme = 0;
                for (int i = 0; i < tab.Length; i++)
                {
                    somme += tab[i];
                }
                Console.WriteLine("Somme des éléments d'un tableau :");
                Console.WriteLine($"tab : {}");
                Console.WriteLine($"Somme : {somme}");
                return somme; 
            }  
        }

        public static int[] OpeTab(int[] tab, char ope, int b)
        {
            //TODO
            return null;
        }

        public static int[] ConcatTab(int[] tab1, int[] tab2)
        {
            //TODO
            return null;
        }
    }
}
