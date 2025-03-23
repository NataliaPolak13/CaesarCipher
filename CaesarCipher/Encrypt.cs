using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    public class Encrypt
    {
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
        public void Encryption()
        {
            Operations operations = new Operations();
            string text = operations.GetTextWithoutPolishCharacters();
            EncryptText(text);

        }
    }
}
