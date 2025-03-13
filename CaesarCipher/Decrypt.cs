using System;
using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;

public class Decrypt
{
	public string GetTextWithoutPolishCharacters()
	{
        while (true)
        {

            Console.Write("Podaj tekst do odszyfrowania szyfrem cezara: ");
            var input = Console.ReadLine();

            if (OnlyLetter(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Twoj tekst nie zawiera tylko liter. Sprobuj ponownie.");
                Thread.Sleep(1500);
                Console.Clear();
            }
        }

	}
    private bool OnlyLetter(string text)
    {
        foreach (char letter in text)
        {
            if (!char.IsLetter(letter))
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
        char[] exclusionSet = { 'ą', 'ę', 'ć', 'ź', 'ż', 'ś', 'ł', 'ó'};

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
                int asciiCode = (int)character;
                asciiCode += displacement;
                decryptedText.Add((char)asciiCode);

            }
        }
        string finalText = new string(decryptedText.ToArray());
        return finalText;


    }
}
