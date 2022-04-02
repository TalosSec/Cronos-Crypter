using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _2Simple_Crypter.Core
{
    public class Encryption
    {
        public byte[] Encrypt(byte[] payload, EncryptionType encryption, char[] key)
        {
            byte[] encrypted;

            if(encryption == EncryptionType.AES)
            {
                encrypted = AES_Encrypt(payload, key);
            }
            else
            {
                encrypted = XOR_Encrypt(payload, key);
            }

            return encrypted;
        }

        private byte[] AES_Encrypt(byte[] bytesToBeEncrypted, char[] encKey)
        {
            byte[] encryptedBytes = null;
            byte[] saltBytes = new byte[] { 026, 020, 202, 234, 136, 123, 069, 047 };
            using (MemoryStream ms = new MemoryStream())              
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    var passwordBytes = Encoding.UTF8.GetBytes(encKey);
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;
                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }
            return encryptedBytes;
        }

        private byte[] XOR_Encrypt(byte[] bytesToBeEncrypted, char[]key)
        {
            byte[] encryptedBytes = new byte[bytesToBeEncrypted.Length];

            for(int i = 0; i < bytesToBeEncrypted.Length; i++)
            {
                encryptedBytes[i] = ((byte)(bytesToBeEncrypted[i] ^ key[i % key.Length]));
            }

            return encryptedBytes;
        }
    }
}
