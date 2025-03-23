using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaesarCipher;

namespace CaesarCipher
{
    public class Menu
    {
        public int RunMenu()
        {
            Operations operations = new Operations();
            string text = operations.GetTextWithoutPolishCharacters();

            var menu = new Dictionary<int, (string, Action)>
            {
                { 1, ("Zaszyfruj tekst", () => operations.EncryptText(text)) },
                { 2, ("Zdeszyfruj tekst", () => operations.DecryptText(text)) },
                { 3, ("Wyjdź z programu", () => Environment.Exit(0)) }
            };

            while (true)
            {
                foreach ( var key in menu )
                {
                    Console.WriteLine($"{ key.Key }. {key.Value.Item1}");
                }

                Console.Write("Wybierz opcję: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && menu.ContainsKey(choice))
                {
                    menu[choice].Item2.Invoke(); 
                    return choice;
                }
                else
                {
                    Console.WriteLine("Błędny wybór, spróbuj ponownie.");
                }

            }
        }

    }
}
