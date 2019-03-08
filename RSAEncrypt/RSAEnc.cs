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
        public RSAEnc()
        {
            _privateKey = csp.ExportParameters(true);
            _publicKey = csp.ExportParameters(false);
        }

        private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private RSAParameters _privateKey;
        private RSAParameters _publicKey;

        public string Encrypt (string text)
        {
            var data = Encoding.UTF8.GetBytes(text);
            var cypher = csp.Encrypt(data, true);

            return Convert.ToBase64String(cypher);
        }

        public string Decrypt (string cypherText)
        {
            var dataBytes = Convert.FromBase64String(cypherText);
            var plainText = csp.Decrypt(dataBytes, true);
            return Encoding.UTF8.GetString(plainText);
        }
        
        // public string PublicKeyString()
        // {
        //     var sw = new StringWriter();
        //     var xs = new XmlSerializer(typeof(RSAParameters));
        //     xs.Serialize(sw, _publicKey);
        //     return sw.ToString();
        // }
    }
}
