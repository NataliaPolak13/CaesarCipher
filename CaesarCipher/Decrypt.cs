using System;
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
}
