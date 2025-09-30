using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice
{
    public static class SpeakingClock
    {
        public static string GoodDay(int heure)
        {
                String message ="";
            
                if (heure >= 0 && heure < 6)
                {
                    message = "merveilleuse nuit !";
                }
                else if (heure >= 6 && heure < 12)
                {
                    message = "Bonne matinée !";
                }
                else if (heure == 12)
                {
                    message = "Bon appétit !";
                }
                else if (heure >= 13 && heure <= 18)
                {
                    message = "Profitez de votre après-midi !";
                }
                else if (heure > 18 && heure <= 23)
                {
                    message = "Passez une bonne soirée !";
                }
                else if (heure > 23)
                {
                    return string.Empty;
                }
            Console.WriteLine($"Il est {heure} H, {message}");
            return message;
            
        }
    }
}
