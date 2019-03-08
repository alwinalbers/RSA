using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RSAEncrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine($"Text zum Verschlüsseln:");
            string message = Console.ReadLine();
            var rsa = new RSAEnc();
            var cypher = rsa.Encrypt(message);

            Console.WriteLine($"Crypted: \n{cypher}\n");            
            Console.WriteLine($"Decrypted:\n" +rsa.Decrypt(cypher));

        }
    }
}
