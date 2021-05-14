using System;
namespace Lab3

{
    class Program
    {
        static void Main()
        {
            HeroesData heroes = new HeroesData();
            int Count = 0;
            IHelpful hero = new Hero();
            Console.WriteLine("Выберите героя: ");
            hero.Menu(Count);
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        Console.Clear();
                        Console.WriteLine("Выберите героя: ");
                        Count++;
                        if (Count == 6)
                        {
                            Count = 0;
                            hero.Menu(Count);
                        }
                        else
                        {
                            hero.Menu(Count);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        Console.Clear();
                        Console.WriteLine("Выберите героя: ");
                        Count--;
                        if (Count < 0)
                        {
                            Count = 5;
                            hero.Menu(Count);
                        }
                        else
                        {
                            hero.Menu(Count);
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        hero.ChosenVariant(heroes, Count);
                        Main();
                        break;
                }
            }
        }
    }
}