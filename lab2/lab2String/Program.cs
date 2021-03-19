using System;
using System.Text;
namespace lab2String
{
    class Program
    {
        static void Main()
        {
            string str = Console.ReadLine();
            string[] words = str.Split((' '));
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (Char.IsPunctuation(words[i][j]))
                    {
                        words[i] = words[i][j] + words[i]+ " ";
                        break;
                    }
                }
            }
            for (int i = 0; i < words.Length; i++) 
            {
                Console.Write(words[i]);
            }
        }
    }
}
