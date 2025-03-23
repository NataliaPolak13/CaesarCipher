using CaesarCipher;
using System;
using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;

public class Decrypt
{
	
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
    public void Operation()
    {
        Operations operations = new Operations();
        string text = operations.GetTextWithoutPolishCharacters();
        DecryptText(text);

    }
}
