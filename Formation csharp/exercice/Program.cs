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

            //Search.BinarySearch(new int[] { 1, 2, 4, 5, 8, 16, 24, 35, 44, 55, 85 }, 55);
            //Search.BinarySearch(new int[] { 1, 2, 4, 5, 8, 16, 24, 35, 44, 55, 85 }, 6);

            //Série 3 - Exercice1
            //AdministrativeTasks.EliminateSeditiousThoughts("Nikolai, où as-tu caché mes dollars ? Je dois aller à l ouest ! L armée m appelle pour aller en Afghanistan", new string[] { "dollars", "Reagen", "Afghanistan", "ouest", "crime", "defaite" });
            //AdministrativeTasks.ControlFormat("M. Pl^nka Andrej 24");
            //AdministrativeTasks.ControlFormat("M. Plenka Andrej 24");
            //AdministrativeTasks.ControlFormat("M. Plenka A)drej 24");
            //AdministrativeTasks.ControlFormat("M. Plenka Andrej 245");
            //AdministrativeTasks.ControlFormat("M. Plenka Andrej a4");
            //AdministrativeTasks.ControlFormat("M. Plenkaaaaaaaaaaaaaaaa Andrej 24");
            //AdministrativeTasks.ControlFormat("MMMMM. Plenka Andrej 24");
            //AdministrativeTasks.ChangeDate("1996-02-28 : Appel suspect de M. Plenka le 1996-02-28");

            Cesar r = new Cesar();
            r.CesarCode("A B C");
            r.DecryptCesarCode("D E F");

            Console.ReadKey();

        }
    }
}

 