using System;

namespace consoleWebAPI
{
    public class Descriptografando
    {
        public static char cifra(char ch, int key)
        {
            if (!char.IsLetter(ch))
                return ch;
            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);
        }


        public static string Encriptografar(string entrada, int key)
        {
            string saida = string.Empty;

            foreach (char ch in entrada)
                saida += cifra(ch, key);
            return saida;
        }

        public static string Descriptografar(string entrada, int key)
        {
            return Encriptografar(entrada, 26 - key);
        }
    }
} 