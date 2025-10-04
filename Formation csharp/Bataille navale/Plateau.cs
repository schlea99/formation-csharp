using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static Bataille_Navale.Position;

namespace Bataille_Navale
{
    internal class Plateau
    {
        public Position[,] PlateauJeu { get; set; }

        public List<Bateau> Bateaux { get; set; }

        public Plateau(int taille)
        {
            PlateauJeu = new Position[10, 10];
            Bateaux = new List<Bateau>()
            {
               new Bateau("A", 5, new List<Position>()),
               new Bateau("B", 4, new List<Position>()),
               new Bateau("C", 3, new List<Position>()),
               new Bateau("D", 3, new List<Position>()),
               new Bateau("E", 2, new List<Position>())
            };
        }

        public void CreationPlateau()
        {
            // Initialisation des positions à l'état caché 'O'
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    PlateauJeu[x, y] = new Position(x, y);
                }
            }
        }

        public void LancementPartie()
        {
            // Pourquoi avoir supprimé le code fourni ??
            //int cpt = 0;
            //while (!FindePartie())

            int cpt = 0;
            while (!FindePartie())
            {
                Console.Clear();
                AfficherPlateau();

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Quelle case visez-vous : (format: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("ligne");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(",");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("colonne");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(")");
                Console.WriteLine();

                string val = Console.ReadLine();
                string[] position = val.Split(',', '.');

                if (int.TryParse(position[0], out int pos1) && position.Length == 2 && int.TryParse(position[1], out int pos2) && pos1 >= 1 && pos1 <= 10 && pos2 >= 1 && pos2 <= 10)
                {
                    cpt++;
                    Viser(pos1 - 1, pos2 - 1);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            AfficherPlateau();
            Console.Write($"GG {cpt} coups effectués !");
        }

        /// <summary>
        /// Peut-on placer le navire sur la grille sans qu'il dépasse les bords et qu'il ne touche les autres bateaux ? 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="taille"></param>
        /// <param name="estVertical"></param>
        /// <returns></returns>
        /// 

        // On corrigera cette partie tous ensemble
        private bool PlacerBateau(int x, int y, int taille, bool estVertical)
        {
            // Pour le placement aléatoire des bateaux
            Random rand = new Random();

            // Positionnement bateaux         
            foreach (Bateau b in Bateaux)
            {
                bool place = false;
                while (!place)
                {
                    // x, y et estvertical fournis en paramètres, pas besoin ici de les demander.
                    x = rand.Next(10);
                    y = rand.Next(10);
                    bool estvertical = (rand.Next(2) == 0);

                    if (estVertical)
                    {
                        // Il y a de l'idée, mais tu pourrais le faire avant. 
                        if (x + b.Taille < 10)
                        {
                            for (int i = x; i < x + b.Taille; i++)
                            {
                                /*if ((x, y) != Etat.Caché)
                                {
                                    return false;
                                }*/
                            }

                        }
                    }


                    if (!estVertical)
                    {
                        if (y + b.Taille < 10)
                        {
                            for (int j = y; j < y + b.Taille; j++)
                            {
                                /*if (b.Positions != Position.Etat.Caché)
                                {
                                    return false;
                                }*/
                            }
                        }
                    }

                    else
                    {
                        return true;
                    }
                }
                Console.WriteLine($"Le bateau {b.Nom} de taille {b.Taille} est correctement placé à la position {b.Positions} !");

            }
            return false;
        }



        /// <summary>
        /// Choix de la case (x , y) 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>

        public void Viser(int x, int y)
        {
            foreach (Bateau b in Bateaux)
            {
                // Appel méthode de bateau
                b.Touché(x, y);

                if (b.Cible(x,y) == null)
                {
                    // Dans le vide
                    PlateauJeu[x, y].Plouf();
                }

                foreach (Position p in b.Positions)
                {
                    bool touché = false;

                    while (!touché)
                    {
                        // Pourquoi demander la position à l'utilisateur ???
                        // Choisir la position visée - x et y sont fournis
                        Console.Write("Entrez une position X entre 0 et 10 :");
                        x = int.Parse(Console.ReadLine());
                        Console.Write("Entrez une position Y entre 0 et 10 :");
                        y = int.Parse(Console.ReadLine());



                    }
                }
            }

        }

        /// <summary>
        /// Affichage de l'état de la grille et de la situation de la partie
        /// </summary>
        public void AfficherPlateau()
        {
            List<Position> list = new List<Position>();
            foreach (Bateau b in Bateaux)
            {
                list.AddRange(b.Positions);
                Console.WriteLine($"{b.Nom}: {b.Taille} de long, coulé: {b.EstCoulé()}");
            }

            foreach (Position p in list)
            {
                PlateauJeu.SetValue(p, p.X, p.Y);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   1 2 3 4 5 6 7 8 9 10");
            int cpt = 0, tmp = 0;
            foreach (Position p in PlateauJeu)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                if (p.X != tmp || cpt == 0)
                {
                    if (cpt > 0)
                    {
                        Console.WriteLine();
                    }
                    Console.Write(string.Format("{0,-3}", ++cpt));
                }

                ConsoleColor foreground;
                switch (p.Statut)
                {
                    case Position.Etat.Plouf:
                        foreground = ConsoleColor.Blue;
                        break;
                    case Position.Etat.Touché:
                        foreground = ConsoleColor.Red;
                        break;
                    case Position.Etat.Coulé:
                        foreground = ConsoleColor.Green;
                        break;
                    default:
                        foreground = ConsoleColor.White;
                        break;
                }
                Console.ForegroundColor = foreground;
                Console.Write((char)p.Statut + " ");

                tmp = p.X;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        /// <summary>
        /// La partie est-elle finie ? 
        /// </summary>
        /// <returns></returns>
        internal bool FindePartie()
        {

            return false;
        }
    }
}
}
