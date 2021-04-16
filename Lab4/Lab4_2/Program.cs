using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Lab4
{
    class Program
    {
        [DllImport("Mathematics.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Sum (int a, int b);

        [DllImport("Mathematics.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Multiply(int a, int b);

        [DllImport("Mathematics.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Divide(int a, int b);

        [DllImport("Mathematics.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Mod(int a, int b);

        [DllImport("Mathematics.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Pow(int a, int b);

        static void ChosenVariant(int Count, int a, int b)
        {
            switch (Count)
            {
                case 0:
                    Console.WriteLine($"{a} + {b} = " + Sum(a, b));
                    Console.ReadKey();
                    break;
                case 1:
                    Console.WriteLine($"{a} * {b} = " + Multiply(a, b));
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine($"{a} / {b} = " + Divide(a, b));
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine($"{a} % {b} = " + Mod(a, b));
                    Console.ReadKey();
                    break;
                case 4:
                    Console.WriteLine($"{a} ^ {b} = " + Pow(a, b));
                    Console.ReadKey();
                    break;   
            }
        }
        static void Variants(int Count)
        {
            string[] Variants = new string[6];
            Variants[0] = "Сумма";
            Variants[1] = "Умножение";
            Variants[2] = "Деление";
            Variants[3] = "Деление с остатком";
            Variants[4] = "Возведение в степень";
            Variants[5] = "Изменить переменные";

            for (int i = 0; i < Variants.Length; i++)
            {
                if (Count == i)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(Variants[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(Variants[i]);
                }
            }
        }
        static void Main()
        {
            int Count = 0;
                Console.WriteLine("Введите две переменные");
                Console.Write("a = ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("b = ");
                int b = Convert.ToInt32(Console.ReadLine());
                Thread.Sleep(3000);
                Console.Clear();
            Console.WriteLine("Выберите действие: ");
            Variants(Count);
            while (true)
            {
                
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        Console.Clear();
                        Console.WriteLine("Выберите действие: ");
                        Count++;
                        if (Count == 6)
                        {
                            Count = 0;
                            Variants(Count);
                        }
                        else
                        {
                            Variants(Count);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        Console.Clear();
                        Console.WriteLine("Выберите действие: ");
                        Count--;
                        if (Count < 0)
                        {
                            Count = 5;
                            Variants(Count);
                        }
                        else
                        {
                            Variants(Count);
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        if(Count == 5)
                        {
                            Main();
                        }
                        ChosenVariant(Count,a,b);
                        Thread.Sleep(2000);
                        Console.Clear();
                        Console.WriteLine("Выберите действие: ");
                        Variants(Count);
                        break;
                }
            }

               
            

        }
    }
}
