using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice
{
    public static class Pyramid
    {
        public static void PyramidConstruction(int n, bool isSmooth)
        {
            // Nombre total de blocs au niveau N 
            int pyramide = 2 * n - 1;

            // On définit des niveaux j jusqu'à arriver au niveau n qui correspond à la base
            for (int j = 1; j <= n; j++)
            // Nombre de blocs pour un niveau j donné (1 <= j <= N)
            {
                int nb_bloc;
                nb_bloc = 2 * j - 1;
                //Console.WriteLine($" niveau {j} : {nb_bloc} bloc(s)");

                char signe;
                // Dans le cas de pyramide lisse, le signe est toujours +
                if (isSmooth is true)
                {

                    signe = '+';
                }
                // Dans le cas de pyramide strié, le signe est + pour les niveaux paires et - pour les niveaux impairs
                else
                {
                   if (j % 2 == 0)
                    {
                        signe = '-';
                    }
                   else
                    {
                        signe = '+';
                    }
                  
                }

                // Dessiner le niveau de la pyramide    
                Char [] niveau = new char [pyramide];

                // Ajouter des espaces pour faire la forme de la pyramide 
                int gauche = n - (j - 1);
                int droite = n + (j - 1);

                // Ajouter un caractère tant que l n'est pas égal à la base de la pyramide
                for (int l = 1; l <= pyramide; l++)
                {
                    // en fonction du niveau, on va ajouter soit un signe + ou -, soit un espace
                    if (l >= gauche && l <= droite)
                    {
                        niveau [l - 1] = signe;
                    }
                    else
                    {
                        niveau [l - 1] = ' ';
                    }

                }                            
                Console.WriteLine(niveau);                
            }
        }
       
    }
}
