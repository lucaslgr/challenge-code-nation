using System;
using System.Security.Cryptography;
using System.Text;

namespace consoleWebAPI
{
    public class ToResume
    {
        public static string getResume(string palavra)
        {
            string hash;
            byte[] temp;

            SHA1 sha = new SHA1CryptoServiceProvider();
            // Uma implementação da classe abstrata SHA1
            temp = sha.ComputeHash(Encoding.UTF8.GetBytes(palavra));


            //storing hashed vale into byte data type
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < temp.Length; i++)
            {
                sb.Append(temp[i].ToString("x2"));
            }

            hash = sb.ToString();

            return hash;
        }
    }
}

