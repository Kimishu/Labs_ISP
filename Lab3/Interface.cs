using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    interface IHelpful
    {
        public void Menu(int Count)
        {
            for (int i = 0; i < HeroesData.data.Length; i++)
            {
                if (Count == i)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(HeroesData.data[i].HeroName);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(HeroesData.data[i].HeroName);
                }
            }
        }
        public void ChosenVariant(HeroesData heroes, int Count)
        {
            Console.Clear();
            Console.WriteLine("Укажите нужный уровень:");
            switch (Count + 1)
            {
                case 1:
                    Abaddon hero1 = new Abaddon(heroes[0]);
                    hero1.HeroInfo(Convert.ToInt32(Console.ReadLine()));
                    break;
                case 2:
                    Tidehunter hero2 = new Tidehunter(heroes[1]);
                    hero2.HeroInfo(Convert.ToInt32(Console.ReadLine()));
                    break;
                case 3:
                    Meepo hero3 = new Meepo(heroes[2]);
                    hero3.HeroInfo(Convert.ToInt32(Console.ReadLine()));
                    break;
                case 4:
                    Clinkz hero4 = new Clinkz(heroes[3]);
                    hero4.HeroInfo(Convert.ToInt32(Console.ReadLine()));
                    break;
                case 5:
                    StormSpirit hero5 = new StormSpirit(heroes[4]);
                    hero5.HeroInfo(Convert.ToInt32(Console.ReadLine()));
                    break;
                case 6:
                    Invoker hero6 = new Invoker(heroes[5]);
                    hero6.HeroInfo(Convert.ToInt32(Console.ReadLine()));
                    break;
            }
        }
    }
    interface IReturn<T,D,S>
    {
        public void Return(T a1, D a2, S a3);
        public void Return(T b, S f);
    }
}
