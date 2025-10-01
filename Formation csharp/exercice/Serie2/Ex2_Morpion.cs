using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice

{
    public static class Morpion
    {
        public static void DisplayMorpion(char[,] grille)
        {
            // Affichage ligne titre
            Console.WriteLine("Affichage grille de morpion :");

            // Définition du tableau multidimensionnel pour la grille du morpion
            //  char[,] grille = new char [3,3];

            // On affiche ligne par ligne 
            for (int i = 0; i < 3; i++)
            {
                // Puis on affiche colonne par colonne pour chaque ligne
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(grille[i, j] + " ");
                }
                Console.WriteLine();
            }
            return;
        }

        public static int CheckMorpion(char[,] grille)
        {
            // On teste les diagonales 
            if ((grille[2, 0] is 'X' && grille[1, 1] is 'X' && grille[0, 2] is 'X') || (grille[0, 0] is 'X' && grille[1, 1] is 'X' && grille[2, 2] is 'X'))
            {
                Console.WriteLine("Le joueur 1 a gagné !");
                return 1;
            }

            if ((grille[2, 0] is 'O' && grille[1, 1] is 'O' && grille[0, 2] is 'O') || (grille[0, 0] is 'O' && grille[1, 1] is 'O' && grille[2, 2] is 'O'))
            {
                Console.WriteLine("Le joueur 2 a gagné !");
                return 2;
            }

            // On teste les lignes
            for (int i = 0; i < 3; i++)
            {
                // Dans le cas où le joueur 1 a gagné  
                if (grille[i, 0] is 'X' && grille[i, 1] is 'X' && grille[i, 2] is 'X')
                {
                    Console.WriteLine("Le joueur 1 a gagné !");
                    return 1;
                }
                // Dans le cas où le joueur 2 a gagné
                if (grille[i, 0] is 'O' && grille[i, 1] is 'O' && grille[i, 2] is 'O')
                {
                    Console.WriteLine("Le joueur 2 a gagné !");
                    return 2;
                }              

            }

            // On teste les colonnes 
            for (int j = 0; j < 3; j++)
            {
                // Dans le cas où le joueur 1 a gagné 
                if (grille[0, j] is 'X' && grille[1, j] is 'X' && grille[2, j] is 'X')
                {
                    Console.WriteLine("Le joueur 1 a gagné !");
                    return 1;
                }
                // Dans le cas où le joueur 2 a gagné
                if (grille[0, j] is 'O' && grille[1, j] is 'O' && grille[2, j] is 'O')
                {
                    Console.WriteLine("Le joueur 2 a gagné !");
                    return 2;
                }
            }

            // Dans le cas où la partie n'est pas finie
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grille[i, j] is '_')
                    {
                        Console.WriteLine("La partie n'est pas finie" );
                        return -1;
                    }
                }
            }
            // Dans le cas où aucun jouer n'a gagné
            Console.WriteLine("Pas de gagnant");
            return 0;

        }
    }
}
