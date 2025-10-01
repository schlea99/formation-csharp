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
            if (tab == null || tab.Length ==0)
            {
                return -1;
            }
            else
            {
                // Déclaration de la somme
                int somme = 0;   

                // Affichage ligne titre
                Console.WriteLine("Somme des éléments d'un tableau :");

                // Affichage des élèments du tableau séparés par une virgule (ou on peut faire une fonction à part qui va afficher le tableau)
                Console.Write("tab : [");

                for (int i = 0; i < tab.Length; i++)
                {
                    // Affichage d'un élèment du tableau
                    Console.Write(tab[i]);

                    // Affichage de la virgule entre les éléments du tableau
                    if (i < tab.Length -1)
                    {
                        Console.Write(", ");
                    }             
                 
                    // Calcul de la somme des élèments du tableau
                    somme += tab[i];
                }  
                Console.Write("]");

                // Pour aller à la ligne
                Console.WriteLine(); 

                // Affichage de la somme
                Console.WriteLine($"Somme : {somme}");
                return somme; 
            }  
        }

        public static int[] OpeTab(int[] tab, char ope, int b)
        {
            // Renvoi d'un tableau vide 
            if (tab == null || tab.Length == 0 || (ope != '+' && ope != '-' && ope != '*'))
            {
                return null;
            }
            else
            {
                // Affichage ligne titre
                Console.WriteLine("Opération sur un tableau :");

                // Affichage des élèments du tableau séparés par une virgule 
                Console.Write("tab : [");

                for (int i = 0; i < tab.Length; i++)
                {
                    // Affichage d'un élèment du tableau
                    Console.Write(tab[i]);

                    // Affichage de la virgule entre les éléments du tableau
                    if (i < tab.Length - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write("]");

                // Pour aller à la ligne
                Console.WriteLine();

                // Affichage de l'opération effectuée
                Console.WriteLine($"ope : {ope} {b}");

                // Déclaration de la variable res pour avoir le résultat des opérations
                int[] res = new int[tab.Length];

                // Affichage des élèments du tableau 'Résultat' séparés par une virgule 
                Console.Write("res : [");

                for (int i = 0; i < tab.Length; i++)
                {
                    // Cas d'une addition 
                    if (ope == '+')
                    {
                        res[i] = tab[i] + b;

                        // Affichage d'un élèment du tableau
                        Console.Write(res[i]);

                        // Affichage de la virgule entre les éléments de la table
                        if (i < tab.Length - 1)
                        {
                            Console.Write(", ");
                        }
                    }

                    // Cas d'une soustraction
                    if (ope == '-')
                    {
                        res[i] = tab[i] - b;

                        // Affichage d'un élèment du tableau
                        Console.Write(res[i]);

                        // Affichage de la virgule entre les éléments de la table
                        if (i < tab.Length - 1)
                        {
                            Console.Write(", ");
                        }
                    }

                    // Cas d'une multiplication 
                    if (ope == '*')
                    {
                        res[i] = tab[i] * b;

                        // Affichage d'un élèment du tableau
                        Console.Write(res[i]);

                        // Affichage de la virgule entre les éléments de la table
                        if (i < tab.Length - 1)
                        {
                            Console.Write(", ");
                        }
                    }
                }
                Console.Write("]");
                return res;
            }
        }
        public static int[] ConcatTab(int[] tab1, int[] tab2)
        {
                // Affichage ligne titre
                Console.WriteLine("Concaténation de deux tableaux :");

                // On va d'abbord afficher les deux tableaux
                // Affichage des élèments du tableau 1 séparés par une virgule 
                Console.Write("tab1 : [");

                for (int i = 0; i < tab1.Length; i++)
                {
                    // Affichage d'un élèment du tableau
                    Console.Write(tab1[i]);

                    // Affichage de la virgule entre les éléments du tableau
                    if (i < tab1.Length - 1)
                    {
                        Console.Write(", ");
                    }                
                }
                Console.Write("]");

                // Pour aller à la ligne
                Console.WriteLine();


                // Affichage des élèments du tableau 2 séparés par une virgule 
                Console.Write("tab2 : [");

                for (int i = 0; i < tab2.Length; i++)
                {
                    // Affichage d'un élèment du tableau
                    Console.Write(tab2[i]);

                    // Affichage de la virgule entre les éléments du tableau
                    if (i < tab2.Length - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write("]");

                // Pour aller à la ligne
                Console.WriteLine();

                // Concaténation des tableaux 
                int[] tab3 = new int[tab1.Length + tab2.Length];

                // Copie du tableau 1 dans le tableau 3
                for(int i = 0; i < tab1.Length; i++)
                {
                    tab3[i] = tab1[i];
                }

                // Copie du tableau 2 dans le tableau 3   
                for (int j = 0; j < tab2.Length; j++)
                {
                    tab3[tab1.Length + j] = tab2[j];
                }

                // Affichage tableau concaténé            
                Console.Write("tab1 + tab2 : [");

                for (int l = 0; l < tab3.Length; l++)
                {
                    // Affichage d'un élèment du tableau
                    Console.Write(tab3[l]);

                    // Affichage de la virgule entre les éléments du tableau
                    if (l < tab3.Length - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write("]");

                // Pour aller à la ligne
                Console.WriteLine();
                return tab3;
         
                
               
        }
    }
}

