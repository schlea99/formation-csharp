using System;
using System.Text;
using System.Text.RegularExpressions;

namespace exercice
{
    public static class AdministrativeTasks
    {
        public static string EliminateSeditiousThoughts(string text, string[] prohibitedTerms)
        {
            StringBuilder StrB = new StringBuilder();
            StrB.Append(text);

            // Mots interrdits 
            Console.WriteLine($"Censure des mots suivants : [ {prohibitedTerms} ]");

            // Ecriture du texte d'entrée 
            Console.WriteLine("Texte d'entrée :");
            Console.WriteLine($"{text}");

            // Caviardage des mots interdits 
            foreach (string word in prohibitedTerms)
            {
                string caviardage = new string('X', word.Length);
                StrB.Replace(word, caviardage);
            }

            // Ecriture du texte en sortie
            Console.WriteLine("Texte de sortie :");
            string textefinal = StrB.ToString();
            Console.WriteLine($"{textefinal}");

            return string.Empty;
        }

        public static bool ControlFormat(string line)
        {
            // Affichage 
            Console.WriteLine("Recensement des résidents");

            // Division de la ligne en plusieurs sous-chaines de caractères, séparés par des espaces 
            string[] info = line.Split(' ');

            // J'associe les différentes informations à un indice dans le tableau
            string civilite = info[0];
            string nom = info[1];
            string prenom = info[2];
            string age = info[3];

            // Affichage ligne
            Console.WriteLine($"Ligne : [{line}]");

            // Caractères alphabétiques 
            string pattern = @"^[A-Za-z\s]+$";

            // Caractères numériques
            string patt = @"^\d{2}$";

            // Vérificication longueur de l'information
            if (civilite.Length > 4 || !(civilite is "M." || civilite is "Mme." || civilite is "Mlle"))
            {
                Console.WriteLine("Format KO civilité");
                return false;
            }

            if (nom.Length > 12 || !(Regex.IsMatch(nom, pattern)))
            {
                Console.WriteLine("Format KO nom");
                return false;
            }

            if (prenom.Length > 12 || !(Regex.IsMatch(prenom, pattern)))
            {
                Console.WriteLine("Format KO prénom");
                return false;
            }
                  
            if (age.Length > 2 || !(Regex.IsMatch(age, patt)))
            {
                Console.WriteLine("Format KO age");
                return false;
            }
           
            else 
            {
                Console.WriteLine("Format OK");
                return true;
            }
            
        }


        public static string ChangeDate(string report)
        {
            Console.WriteLine("Correction des dates");
            Console.WriteLine("Rapport en entrée :");
            Console.WriteLine($"{report}");

            string date = @"\d{4}-\d{2}-\d{2}";

            //string date = @"\b(?<year>\d{4})-(?<month>-\d{2})-(?<day>\d{2})\b";
            //string format = "${day}.${month}.${year}";

            string newdate = null;

            // On partitionne pour éviter que le programme crash
            try
            {
                foreach (Match match in Regex.Matches(report, date))
                {
                    newdate = Regex.Replace(report, date, DateTime.Parse(match.Value).ToString("dd.MM.yy"), RegexOptions.None);
                    Console.WriteLine("Rapport en sortie :");
                    Console.WriteLine($"{newdate}");
                    return newdate;
                }
            }

            catch (RegexMatchTimeoutException)
            {
                return string.Empty;
            }

            return string.Empty;

        }
    }
}





