using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.IO;

namespace RSAEncrypt
{
    class RSAEnc
    {
        private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private RSAParameters _privateKey;
        private RSAParameters _publicKey;

        public RSAEnc()
        {
            _privateKey = csp.ExportParameters(true);
            _publicKey = csp.ExportParameters(false);
        }

       // public string PublicKeyString()
       // {
       //     var sw = new StringWriter();
       //     var xs = new XmlSerializer(typeof(RSAParameters));
       //     xs.Serialize(sw, _publicKey);
       //     return sw.ToString();
       // }

        public string Encrypt (string text)
        {
            csp.ImportParameters(_publicKey);
            var data = Encoding.Unicode.GetBytes(text);
            var cypher = csp.Encrypt(data, true);

            return Convert.ToBase64String(cypher);
        }

        public string Decrypt (string cypherText)
        {
            var dataBytes = Convert.FromBase64String(cypherText);
            csp.ImportParameters(_privateKey);
            var plainText = csp.Decrypt(dataBytes, true);
            return Encoding.Unicode.GetString(plainText);
        }


    }
}
