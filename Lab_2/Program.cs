using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Program
    {
        private static Dictionary<char, char> letterMapping = new Dictionary<char, char>()
       {
           {'Щ', 'A' },
           {'ь', 'd' },
           {'Ю', 'B' },
           {'Я', 'C' },
       };

        static void Main(string[] args)
        {
            Encrypt();
            Decrypt();
        }

        public static void Encrypt()
        {
            var text = File.ReadAllText("Прізвище1.txt");


            var result = new StringBuilder();

            foreach (var letter in text)
            {
                if(letterMapping.Keys.Contains(letter))
                {
                    result.Append(letterMapping[letter]);
                }
                else
                {
                    result.Append((char)(letter + 3));
                }
            }

            File.WriteAllText("Прізвище2.txt", result.ToString());

        }

        public static void Decrypt()
        {
            var text = File.ReadAllText("Прізвище2.txt");

            var result = new StringBuilder();

            foreach (var letter in text)
            {
                if (letterMapping.Values.Contains(letter))
                {
                    result.Append(letterMapping.FirstOrDefault(f => f.Value == letter).Key);
                }
                else
                {
                    result.Append((char)(letter - 3));
                }
            }

            File.WriteAllText("Прізвище3.txt", result.ToString());
        }
    }
}
