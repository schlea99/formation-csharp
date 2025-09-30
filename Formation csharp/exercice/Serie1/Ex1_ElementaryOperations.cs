using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice
{
    public static class ElementaryOperations
    {
        public static void BasicOperation(int a, int b, char operation)
        {
          int c;
            if (operation != '*' && operation != '/' && operation != '+' && operation != '-')
            {
                Console.WriteLine("Opération invalide");
            }

            if ((a == 0 || b == 0) && (operation == '*' || operation == '/'))
            {
                Console.WriteLine("Opération invalide");
            }
            
            
            if (operation == '+')
            {
                c = a + b ;
                Console.WriteLine($"{a} + {b} = {c}");
            }
            if (operation == '-')
            {
                c = a - b;
                Console.WriteLine($"{a} - {b} = {c}");
            }
            if (operation == '*' && a != 0 && b != 0)
            {
                c = a * b;
                Console.WriteLine($"{a} * {b} = {c}");
            }
            if (operation == '/' && a != 0 && b != 0)
            {
                c = a / b;
                Console.WriteLine($"{a} / {b} = {c}");
            }
        }

        public static void IntegerDivision(int a, int b)
        {
            int q;
            int r;
            if (a != 0 && b != 0)
            {
                q = a / b;
                r = a % b;

                if (r != 0)
                {
                    Console.WriteLine($"{a} = {q} * {b} + {r}");
                }
                if (r == 0)
                {
                    Console.WriteLine($"{a} = {q} * {b}");
                }
            }
            if (a == 0 || b == 0)
                {
                    Console.WriteLine($"{a} : {b} = opération invalide");
                }
            
        }

        public static void Pow(int a, int b)
        {
            double q;
            if (b > 0)
            {
                q = Math.Pow(a,b); 
                Console.WriteLine($"{a} ^ {b} = {q}");
            }

            if (b <= 0)
            {
                Console.WriteLine($"{a} ^ {b} = opération invalide");
            }
        }
    }
}
