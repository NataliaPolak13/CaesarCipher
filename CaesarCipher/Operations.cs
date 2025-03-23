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
        private bool OnlyLetter(string text)
        {
            foreach (char letter in text)
            {
                if (!char.IsLetter(letter) && !char.IsWhiteSpace(letter))
                {
                    return false;
                }
            }
            return true;
        }

        public string DecryptText(string text)
        {
            char[] operationText = text.ToCharArray();
            var decryptedText = new System.Collections.Generic.List<char>();
            Operations operations = new Operations();
            int displacement = Operations.GetDisplacement();

            foreach (char character in operationText)
            {

                // C = (n - k) mod 26 n->numer litery k-> klucz

                var newChar = 0;

                int asciiCode = (int)character;
                if ((asciiCode >= 65 && asciiCode <= 90) || (asciiCode >= 97 && asciiCode <= 122))
                {
                    if ((asciiCode >= 65 && asciiCode <= 90))
                    {
                        newChar = ((asciiCode - 65 - displacement + 26) % 26) + 65;

                    }
                    else
                    {
                        newChar = ((asciiCode - 97 - displacement + 26) % 26) + 97;
                    }
                    decryptedText.Add((char)newChar);
                }
                else
                {
                    decryptedText.Add(character);
                }

            }

            string finalText = new string(decryptedText.ToArray());
            Console.WriteLine(finalText);
            return finalText;


        }
        public string EncryptText(string text)
        {
            char[] operationText = text.ToCharArray();
            var encryptedText = new System.Collections.Generic.List<char>();
            int displacement = Operations.GetDisplacement();


            foreach (char character in operationText)
            {

                // C = (n + k) mod 26 n->numer litery k-> klucz

                var newChar = 0;

                int asciiCode = (int)character;
                if ((asciiCode >= 65 && asciiCode <= 90) || (asciiCode >= 97 && asciiCode <= 122))
                {
                    if ((asciiCode >= 65 && asciiCode <= 90))
                    {
                        newChar = ((asciiCode - 65 + displacement) % 26) + 65;

                    }
                    else
                    {
                        newChar = ((asciiCode - 97 + displacement) % 26) + 97;
                    }
                    encryptedText.Add((char)newChar);
                }
                else
                {
                    encryptedText.Add(character);
                }

            }

            string finalText = new string(encryptedText.ToArray());
            Console.WriteLine(finalText);
            return finalText;


        }

    }
}
