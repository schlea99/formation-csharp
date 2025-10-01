using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Série 2 - Tests Exercice 1
            //TasksTables.SumTab(new int[] { 1, 10, 20, 5 });
            //TasksTables.SumTab(new int[] { -1, 10, -20, 5 });     
            //TasksTables.SumTab(new int[] { });

            //TasksTables.OpeTab(new int[] { 1, 10, 20, 5 }, '+', 4);
            //TasksTables.OpeTab(new int[] { 1, 10, 20, 5 }, '-', 4);
            //TasksTables.OpeTab(new int[] { 1, 10, 20, 5 }, '*', 4);
            //TasksTables.OpeTab(new int[] { 1, 10, 20, 5 }, '/', 4);
            //TasksTables.OpeTab(new int[] { }, '*', 4);

            //TasksTables.ConcatTab(new int [] { 1, 10, 20, 5 }, new int [] { 2, 40, 10, 3 });
            //TasksTables.ConcatTab(new int [] { 1, 10, 20, 5 }, new int [] { });

            //Série 2 - Tests Exercice 2
            //Morpion.CheckMorpion(new char[,] 
            //    { 
            //    { 'X', 'O', 'X' }, 
            //    { 'X', 'X', 'O' }, 
            //    { '_', 'O', 'X' } 
            //    });

            //Série 2 - Tests Exercice 3
            //Search.LinearSearch(new int[] { 1, 4, -5, 78, -5 }, -2);
            //Search.LinearSearch(new int[] { 1, 4, -5, 78, -5 }, 78);

            Search.BinarySearch(new int[] { 1, 2, 4, 5, 8, 16, 24, 35, 44, 55, 85 }, 55);
            Search.BinarySearch(new int[] { 1, 2, 4, 5, 8, 16, 24, 35, 44, 55, 85 }, 6);
            Console.ReadKey();

        }
    }
}

 