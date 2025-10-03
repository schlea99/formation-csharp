using System.Collections.Generic;
using System.Linq;

namespace Bataille_Navale
{
    internal class Bateau
    {
        public string Nom { get; private set; }
        public int Taille { get; private set; }
        public List<Position> Positions { get; private set; }

        public Bateau(string nom, int taille, List<Position> position)
        {
            Nom = nom;
            Taille = taille;
            Positions = position;
        }

        /// <summary>
        /// Case à l'état touché si elle appartient au bateau
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Touché(int x, int y)
        {


            if()
            {
                Positions.RemoveAt(2);
                
            }


        }

        /// <summary>
        /// Le bateau est-il coulé ? 
        /// </summary>
        public bool EstCoulé()
        {

            return false;
        }

    }
}