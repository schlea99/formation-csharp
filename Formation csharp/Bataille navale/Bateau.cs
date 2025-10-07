using System.Collections.Generic;
using System.Linq;

namespace Bataille_Navale
{
    public class Bateau
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
            // On passe à l'état Touché la case si elle est présente
            for (int i = 0; i < Positions.Count; i++)
            {
                if (Positions[i].X == x && Positions[i].Y == y)
                {
                    Positions[i].Touché();
                }
            }

            // Sécurité - passer à l'état Coulé les cases si toutes les cases sont "Touchées"
            if (EstCoulé())
            {
                for (int i = 0; i < Positions.Count; i++)
                {
                    Positions[i].Coulé();
                }
            }

            // ??
            /*
            if()
            {
                Positions.RemoveAt(2);
            }*/


        }

        /// <summary>
        /// Le bateau est-il coulé ? 
        /// </summary>
        public bool EstCoulé()
        {
            int count =0;
            foreach (Position position in Positions)
            {
                if (position.Statut != Position.Etat.Touché && position.Statut != Position.Etat.Coulé)
                {
                    count++;             
                }
            }
           
            if (count == Taille)
            {
                return true;
            }
            else 
            {
                 return true;
            }
        }

        /// <summary>
        /// Renvoie la position si celle-ci appartient au Bateau
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Position Cible(int x, int y) => Positions.Find(p => p.X == x && p.Y == y);

    }
}
