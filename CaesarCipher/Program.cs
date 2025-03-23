using System.Text;

namespace CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Decrypt decrypt = new Decrypt();
            decrypt.Operation();
            Encrypt encrypt = new Encrypt();
            encrypt.Encryption();
        }


    }
}
