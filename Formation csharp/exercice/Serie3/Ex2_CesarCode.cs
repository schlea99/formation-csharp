using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice
{
    public class Cesar
    {
        private readonly char[,] _cesarTable;

        public Cesar()
        {
            _cesarTable = new char[,]
            {
                { 'A', 'D' },
                { 'B', 'E' },
                { 'C', 'F' },
                { 'D', 'G' },
                { 'E', 'H' },
                { 'F', 'I' },
                { 'G', 'J' },
                { 'H', 'K' },
                { 'I', 'L' },
                { 'J', 'M' },
                { 'K', 'N' },
                { 'L', 'O' },
                { 'M', 'P' },
                { 'N', 'Q' },
                { 'O', 'R' },
                { 'P', 'S' },
                { 'Q', 'T' },
                { 'R', 'U' },
                { 'S', 'V' },
                { 'T', 'W' },
                { 'U', 'X' },
                { 'V', 'Y' },
                { 'W', 'Z' },
                { 'X', 'A' },
                { 'Y', 'B' },
                { 'Z', 'C' }
            };
        }

        public string CesarCode(string line)
        {
            StringBuilder StrB = new StringBuilder();
            StrB.Append(line);

            // Code de départ
            Console.WriteLine($"Code : {line}");

            for (int i = 0; i < _cesarTable.GetLength(0); i++)
            {
                char r = _cesarTable[i, 0];
                
                foreach (char c in line)
                {
                    if(r == c)
                    {                                                                  
                        StrB.Replace(c, _cesarTable[i,1]);
                    }               
                }
            }
            Console.WriteLine($"Nouveau code : {StrB}");
            return string.Empty;
        }

        public string DecryptCesarCode(string line)
        {
            StringBuilder StrB = new StringBuilder();
            StrB.Append(line);

            // Code de départ
            Console.WriteLine($"Code : {line}");

            for (int j = 0; j < _cesarTable.GetLength(1); j++)
            {
                char r = _cesarTable[0, j];
                
                foreach (char c in line)
                {
                    if (r == c)
                    {
                        StrB.Replace(c, _cesarTable[1, j]);
                    }
                }
            }
            Console.WriteLine($"Nouveau code : {StrB}");         
            return string.Empty;
        }

        public string GeneralCesarCode(string line, int x)
        {
            //TODO
            return string.Empty;
        }

        public string GeneralDecryptCesarCode(string line, int x)
        {
            //TODO
            return string.Empty;
        }
    }
}