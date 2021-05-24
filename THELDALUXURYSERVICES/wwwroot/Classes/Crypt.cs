using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace THELDALUXURYECOMMERCE.wwwroot.Classes
{
    public class Crypt
    {

        //function for ecrypting
        public static string Encrypt(string PlainText, string key = "bc12d&44£%^rruywtter")
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(PlainText);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        //function for decrypting
        public static string Decrypt(string input, string key = "bc12d&44£%^rruywtter")
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }


        //Ciphertext.Text = CryptoEngine.Encrypt(plaintext.Text, "sblw-3hn8-sqoy19");


        //decryptedtext.Text = CryptoEngine.Decrypt(Ciphertext.Text, "sblw-3hn8-sqoy19");  

       

                                                                               
    }
}
