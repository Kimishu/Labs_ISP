using System;
using System.Threading;
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
           
            try
            {
                int Level = Convert.ToInt32(Console.ReadLine());
                
                if (Level <= 0 || Level > 30)
                {
                    throw new Exception("Невозможное значение. Level [1;30]");
                }
                HeroType hero;
                switch (Count + 1)
                {
                    case 1:
                        hero = new Abaddon(heroes[0]);
                        break;
                    case 2:
                        hero = new Tidehunter(heroes[1]);
                        break;
                    case 3:
                        hero = new Meepo(heroes[2]);
                        break;
                    case 4:
                        hero = new Clinkz(heroes[3]);
                        break;
                    case 5:
                        hero = new StormSpirit(heroes[4]);
                        break;
                    case 6:
                        hero = new Invoker(heroes[5]);
                        break;
                    default:
                        throw new Exception("Выбран невозможный герой.");
                }
                hero.HeroInfo(Level);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
                Thread.Sleep(1500);
                Console.Clear();
            }

        }
    }
    interface IReturn<T,D,S>
    {
        public void Return(T a1, D a2, S a3);
        public void Return(T b, S f);
    }
}
