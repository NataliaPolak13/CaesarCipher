using System;
using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;

public class Decrypt
{
	public string GetTextWithoutPolishCharacters()
	{
        while (true)
        {

            Console.Write("Podaj tekst do odszyfrowania szyfrem cezara, Wpisz stop po wpisaniu całości tekstu: ");
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

    public int GetDisplacement()
	{
        while (true) {
            Console.Write("Podaj przesuniecie potrzebne do odszyfrowania tekstu: ");
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
    public string DecryptText(string text)
    {
        char[] operationText = text.ToCharArray();
        char[] exclusionSet = { 'ą', 'ę', 'ć', 'ź', 'ż', 'ś', 'ł', 'ó', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', ',', '!', '-', ' ', '?', '\n', '(', ')'};

        var decryptedText = new System.Collections.Generic.List<char>();

        int displacement = GetDisplacement();

        foreach (char character in operationText)
        {
            if (exclusionSet.Contains(character))
            {
                decryptedText.Add(character);
            }
            else
            {
                // C = (n - k) mod 26 n->numer litery k-> klucz

                var newChar = 0;

                int asciiCode = (int)character;
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
        }
        string finalText = new string(decryptedText.ToArray());
        Console.WriteLine(finalText);
        return finalText;


    }
    public void Decryption()
    {
        string text = GetTextWithoutPolishCharacters();
        DecryptText(text);

    }
}
