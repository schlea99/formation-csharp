using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice

{
    public static class Search
    {
        public static int LinearSearch(int[] tableau, int valeur)
        {
            if (tableau.Length == 0)
            {
                Console.WriteLine("L'indice : -1");
                return -1;
            }
            else
            {
                for (int i = 0; i < tableau.Length - 1; i++)
                {
                    if (valeur == tableau[i])
                    {
                        Console.WriteLine($"L'indice est : {i}");
                        return valeur; 
                    } 
                }
            }                                            
            Console.WriteLine("L'indice : -1");
            return -1;                                                    
        }

        public static int BinarySearch(int[] tableau, int valeur)
        {
            // borne gauche
            int gauche = 0;
            // borne droite
            int droite = tableau.Length - 1;

            while (gauche <= droite)
            {
                // indice du milieu
                int milieu = (gauche + droite) / 2;

                if (tableau[milieu] == valeur)
                {
                    Console.WriteLine($"L'indice est : {milieu}");
                    return milieu;
                }
                if (tableau[milieu] < milieu)
                {
                    Console.WriteLine($"La valeur est plus grande que l'indice {milieu}, aller vers la gauche");
                    gauche = milieu + 1;
                }
                else
                {
                    Console.WriteLine($"La valeur est plus petite que l'indice {milieu}, aller vers la droite");
                    droite = milieu - 1;
                }
            }
            Console.WriteLine("La valeur n'est pas présente dans le tableau, l'indice est : -1");
            return -1;
        }
    }
}
