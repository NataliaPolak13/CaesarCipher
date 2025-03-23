using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    public class Operations
    {
        public string GetTextWithoutPolishCharacters()
        {
            while (true)
            {

                Console.Write("Podaj tekst. Wpisz stop po wpisaniu całości: ");
                string input = "";
                string line;

                while ((line = Console.ReadLine()) != "stop")
                {
                    input += line + Environment.NewLine;
                }

                return input;
                /*             var input = Console.ReadLine();

                         if (OnlyLetter(input))
                           {
                               return input;
                           }
                           else
                           {
                               Console.WriteLine("Twoj tekst nie zawiera tylko liter. Sprobuj ponownie.");
                               Thread.Sleep(1500);
                               Console.Clear();
                           }*/
            }

        }

        public static int GetDisplacement()
        {
            while (true)
            {
                Console.Write("Podaj przesuniecie: ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int displacement) && displacement > 0)
                {
                    return displacement;
                }
                else
                {
                    Console.WriteLine("Twoje przesunięcie nie jest liczba calkowita wieksza od 0. Sprobuj ponownie.");
                }
            }

        }
    }
}
