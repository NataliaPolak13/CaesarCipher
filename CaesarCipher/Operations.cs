using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CaesarCipher
{
    public class Operations
    {
        public string GetTextWithoutPolishCharacters()
        {

            Console.Write("Podaj tekst. Zakończenie wpisywania to pusta linia: ");
            string input = "";
            string? line;

            while (true)
            {
                line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;
                input += line + Environment.NewLine;
            }

            return input;

        }  
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
/*        private bool OnlyLetter(string text)
        {
            foreach (char letter in text)
            {
                if (!char.IsLetter(letter) && !char.IsWhiteSpace(letter))
                {
                    return false;
                }
            }
            return true;
        }*/

        public string OperationsWithText(string text, int x)
        {
            char[] operationText = text.ToCharArray();
            var newText = new System.Collections.Generic.List<char>();
            int displacement = Operations.GetDisplacement();


            foreach (char character in operationText)
            {

                // C = (n + k) mod 26 n->numer litery k-> klucz -> szyfrowanie
                // C = (n - k) mod 26 n->numer litery k-> klucz -> deszyfrowanie

                int newChar = 0;

                int asciiCode = (int)character;
                if ((asciiCode >= 65 && asciiCode <= 90) || (asciiCode >= 97 && asciiCode <= 122))
                {
                    if ((asciiCode >= 65 && asciiCode <= 90))
                    {
                        newChar = ((asciiCode - 65 + (displacement*x)+26) % 26) + 65;

                    }
                    else
                    {
                        newChar = ((asciiCode - 97 + (displacement*x)+26) % 26) + 97;
                    }
                    newText.Add((char)newChar);
                }
                else
                {
                    newText.Add(character);
                }

            }

            string finalText = new string(newText.ToArray());
            Console.WriteLine(finalText);
            return finalText;

        
        }

    }
}
