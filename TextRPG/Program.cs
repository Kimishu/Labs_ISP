using System;
using System.IO;
using System.Text;
using PlayerInfo;
using InventoryInfo;
using System.Collections.Generic;
using System.Linq;
using EnemyInfo;
using System.Threading;

namespace TextRPG
{
   
    class Program
    {
        static void Buy(int index)
        {
            Inventory bag = new Inventory();
            if(index == 1)
            {
                string[] BuyWeapon = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(),"Texts","WeaponsShop.txt"), Encoding.UTF8);
                for(int i=0; i < BuyWeapon.Length; i++)
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~");
                    Console.Write(StrCutter(BuyWeapon[i],"@Number:","@Name"));
                    Console.Write("Урон: ");
                    Console.WriteLine(StrCutter(BuyWeapon[i], "@Name", "@Damage:"));
                    Console.Write("Крит. урон: ");
                    Console.WriteLine(StrCutter(BuyWeapon[i], "@Damage:", "@CriticalDamage:"));
                    Console.Write("Стоимость: ");
                    Console.WriteLine(StrCutter(BuyWeapon[i], "@Cost:", "@End;"));
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~");
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Выберите оружие для покупки");
                string str = Console.ReadLine();
                int WeaponID = Convert.ToInt32(str) - 1;
                Console.ResetColor();
                for (int i = 0; i < BuyWeapon.Length; i++)
                {
                    if (BuyWeapon[i].Contains(str))
                    {
                        if(Player.Money < Convert.ToInt32(StrCutter(BuyWeapon[i], "@Cost:", "@End;"))){
                            bag.Add(i,1);
                        }
                        else
                        {
                            Console.WriteLine("У вас недостаточно средств!");
                            Console.WriteLine("Ваши монеты: " + Player.Money);
                        }
                    }
                }
            }
            if(index == 2)
            {

            }
            if(index == 3)
            {

            }
        }
        static void Shop()
        {
            Console.WriteLine("Добро пожаловать в мою лавку! Чего желаете?");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\n1.Купить оружие\n2.Купить зелье\n3.Создать оружие");
            Console.ResetColor();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Buy(1);
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    Buy(2);
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    Buy(3);
                    break;
            }
        }
        public static bool EnemyGeneration = false;
        public static void EnemyGen()
        {
            List<string> Enemies = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(),"Texts","Enemies.txt"), Encoding.UTF8).ToList();
            Random RandEnemy = new Random();
            int EnemyID = RandEnemy.Next(0, Enemies.Count);
            Enemy.Name = StrCutter(Enemies[EnemyID], "@Name:", "@HP:");
            Enemy.Damage = Convert.ToInt32(StrCutter(Enemies[EnemyID], "@Damage:", "@Mana:"));
            Enemy.HP = Convert.ToInt32(StrCutter(Enemies[EnemyID], "@HP:", "@Damage:"));
            Enemy.MaxHP = Enemy.HP;
            Enemy.Mana = Convert.ToInt32(StrCutter(Enemies[EnemyID], "@Mana:", "@Exp:"));
            Enemy.Exp = Convert.ToInt32(StrCutter(Enemies[EnemyID], "@Exp:", "@End;"));
            EnemyGeneration = true;
        }
        public static string StrCutter(string str, string start, string end)
        {
            return str.Substring(str.IndexOf(start) + start.Length, str.IndexOf(end) - (str.IndexOf(start) + start.Length));
        }
       public static string Finder(string str)
        {
            string[] FindWeapon1 = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(),"Texts","Weapons.txt"), Encoding.UTF8);
            string[] FindWeapon2 = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(),"Texts", "WeaponsShop.txt"), Encoding.UTF8);
            Random CritChance = new Random();
            int index = 0;
            

            for (int i = 0; i < FindWeapon1.Length; i++)
            {
                if (FindWeapon1[i].Contains(str))
                {
                     index = i;
                      
                }
                
            }
            if(CritChance.Next(0,4)== 3)
            {
                return StrCutter(FindWeapon1[index], "@CriticalDamage:", "@Durability:");
            }
            else
            {
                return StrCutter(FindWeapon1[index], "@Damage:", "@CriticalDamage:");
            }
        }

        static int ChooseWeapon()
        {
            
            List<string> Weapons = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(),"Texts","Inventory.txt"), Encoding.UTF8).ToList();
            int count = 0;
            for (int i = 0; i < Weapons.Count; i++)
            {
                count++;
                Console.WriteLine(count+". " + Weapons[i]);
               
            }
            Console.WriteLine("Кол-во предметов: "+ count +"\nВведите номер оружия, которым хотите атаковать: ");

            string str = Console.ReadLine();
            if(str == string.Empty)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Предмета с таким номером нет. Попробуйте ещё раз.");
                Console.ResetColor();
                Thread.Sleep(3000);
                Console.Clear();
                return ChooseWeapon();
            }
            int WeaponID = Convert.ToInt32(str)-1;
            if (WeaponID == count || WeaponID<0 ||WeaponID>count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Предмета с таким номером нет. Попробуйте ещё раз.");
                Console.ResetColor();
                Thread.Sleep(3000);
                Console.Clear();
                return ChooseWeapon();
            }
            return WeaponID;
        }
        static int ChooseSkill()
        {
            List<string> MagicSkills = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Texts", "MagicSkills.txt"), Encoding.UTF8).ToList();
            int count = 0;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
            for (int i = 0; i < MagicSkills.Count; i++)
            {
                count++;
                Console.Write(count + ". ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(StrCutter(MagicSkills[i],"@Name:","@Damage:"));
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(StrCutter(MagicSkills[i], "@Damage:", "@ManaCost:"));
                Console.ResetColor();
                Console.Write("Манакост: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(StrCutter(MagicSkills[i], "@ManaCost:", "@End;"));
                Console.ResetColor();
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");

            }
            Console.WriteLine("Кол-во заклинаний: " + count + "\nВыберите заклинание, которым хотите атаковать: ");
            string str = Console.ReadLine();
            int SkillID;
            if (!int.TryParse(str,out SkillID))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Предмета с таким номером нет. Попробуйте ещё раз.");
                Console.ResetColor();
                Thread.Sleep(3000);
                Console.Clear();
                return ChooseSkill();
            }
            
            if (SkillID == count || SkillID < 0 || SkillID > count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Заклинания с таким номером нет. Попробуйте ещё раз.");
                Console.ResetColor();
                Thread.Sleep(3000);
                Console.Clear();
                return SkillID;
            }
            return SkillID;
        }
        
        static void Fight()
        {
            List<string> ChosenWeapon = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(),"Texts","Inventory.txt"), Encoding.UTF8).ToList();
            int damage = 0, count = 0;
                Console.WriteLine("***Бой начинается!***");
            if (EnemyGeneration == false)
            {
                EnemyGen();
                EnemyGeneration = true;
            }
                Console.WriteLine("В этом бою сошлись " + Player.Name + " и " + Enemy.Name);
             
            Console.ReadKey();
            Console.Clear();
            for (; ;){
                if (Player.HP != 0)
                {

                    Console.WriteLine("Сейчас ваша очередь. Выберите действие:\n1.Информация о противнике\n2.Атаковать оружием\n3.Атаковать магией\n4.Сбежать");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            EnemyInf();
                        break;
                        case ConsoleKey.D2:
                        Console.Clear();
                        int WeaponID = ChooseWeapon();
                        Console.Clear();
                        Console.WriteLine("Вы выбрали " + ChosenWeapon[WeaponID] + " и атаковали им противника.");
                        damage = Convert.ToInt32(Finder(ChosenWeapon[WeaponID]));
                        Enemy.HP -= damage;
                        Console.Write("Вы нанесли противнику ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(damage);
                        Console.ResetColor();
                        Console.WriteLine(" урона");
                        Console.Write("Текущее здоровье противника: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (Enemy.HP <= 0)
                        {
                            Enemy.HP = 0;
                            Console.WriteLine(Enemy.HP);
                        }
                        else
                        {
                            Console.WriteLine(Enemy.HP);
                        }
                        Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("***Нажмите любую кнопку для продолжения!***");
                            Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        if (Enemy.HP <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Противник " + Enemy.Name + " побеждён!");
                            Console.WriteLine("Вы получили " + Enemy.Exp + " опыта");
                            Player.CurrentExperience += Enemy.Exp;
                            Player.CheckExp();
                            Player.HP = Player.MaxHP;
                            EnemyGeneration = false;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Победа!");
                            Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\n\n\nНажмите любую кнопку, чтобы продолжить.");
                                Console.ResetColor();
                            Console.ReadKey();
                            break;
                        }
                        break;
                      
                        case ConsoleKey.D3:
                        Console.Clear();
                        if (Player.Mana == -1)
                        {
                        Console.WriteLine("***Вы воин, а не маг! Используйте оружие!***");
                        }
                        else
                        {
                          ChooseSkill();
                        }
                        break;
                    }
                }
                if(Enemy.HP != 0)
                {
                    Console.WriteLine("Время атаки противника!");
                    Player.HP -= Enemy.Damage;
                    count++;
                    Console.Write("Противник нанёс Вам ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(Enemy.Damage);
                    Console.ResetColor();
                    Console.WriteLine(" урона");
                    Console.Write("Ваше текущее здоровье: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Player.HP);
                    Console.ResetColor();
                    if (Player.HP <= 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вы ПРОИГРАЛИ");
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\n\nНажмите любую кнопку, чтобы продолжить.");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                if(Enemy.HP <= 0 || Player.HP <= 0)
                {
                    break;
                }
            }
        }
        static void EnemyInf()
        {
            Console.WriteLine("Информация о противнике:");
            Console.WriteLine("Имя: " + Enemy.Name);
            Console.WriteLine("Урон: " + Enemy.Damage);
            Console.Write("Здоровье: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Enemy.HP+"/"+Enemy.MaxHP);
            Console.ResetColor();
            Console.Write("Мана: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Enemy.Mana);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\nНажмите любую кнопку, чтобы вернуться.");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
            Fight();
        }
        static void Lore()
        {
            if (Player.Race == "Человек")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("*Вы прибыли в заброшенное подземелье, куда ранее не добирались авантюристы.*\n*Победите всех врагов и восстановите былую силу!*");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Нажмите любую кнопку, чтобы продолжить.");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
                Fight();
            }
            Console.ReadKey();
            Console.Clear();
            Actions();
        }
        static void Inventory()
        {
            string[] line = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(),"Texts","Inventory.txt"), Encoding.UTF8);
            string[] AllWeapons = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(),"Texts","AllWeapons.txt"), Encoding.UTF8);
            int count = 1;
            for (int i = 0; i < line.Length; i++)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine(count+". "+line[i]);
                for (int j = 0; j < AllWeapons.Length; j++)
                {
                    if (AllWeapons[j].Contains(line[i]))
                    {
                        Console.Write("Урон: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(StrCutter(AllWeapons[j], "@Damage:", "@CriticalDamage:"));
                        Console.ResetColor();
                        Console.Write("Критический урон: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(StrCutter(AllWeapons[j], "@CriticalDamage:", "@End;"));
                        Console.ResetColor();
                    }
                }
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
                count++;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\nНажмите любую кнопку, чтобы продолжить.");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
            Actions();
        }
        static void Info()
        {
            Console.WriteLine("Информация о персонаже:");
            Console.WriteLine("Имя: " + Player.Name);
            Console.WriteLine("Уровень: " + Player.Level+" ["+Player.CurrentExperience+"/"+Player.Level*2+"]");
            Console.WriteLine("Раса: " + Player.Race);
            Console.WriteLine("Класс: " + Player.ClassPlayer);
            Console.Write("Здоровье: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Player.HP+"/"+Player.MaxHP);
            Console.ResetColor();
            Console.Write("Мана: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Player.Mana);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\nНажмите любую кнопку, чтобы вернуться.");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
            Actions();
        }
        static void Actions()
        {
            Console.WriteLine("1.Информация о персонаже\n2.Инвентарь\n3.В бой!\n4.В магазин");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Info();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    Inventory();
                    break;

                case ConsoleKey.D3:
                    Console.Clear();
                    Lore();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    Shop();
                    break;
                default:
                    Console.Clear();
                    Actions();
                    break;
            }
        }
        static void RaceChoose()
        {
            List<string> weapon = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(),"Texts","Weapons.txt"), Encoding.UTF8).ToList();
            Random randweapon = new Random();
            int WeaponID = randweapon.Next(0, weapon.Count);
            Inventory bag = new Inventory();
            Console.WriteLine("Выберите расу:\n1.Человек\n2.Нежить");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Player.Race = "Человек";
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Слуга: ");
                    Console.ResetColor();
                    Console.WriteLine("Вы были героем, который сражался против армии нежити, чтобы спасти своё королевство!\nВаше тело было уничтожено мощным заклинанием, но судьба оказалась благосклонна.");
                    Console.WriteLine("Введите ваше имя: ");
                    Player.Name = Console.ReadLine();
                    //Thread.Sleep(3000);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Слуга: ");
                    Console.ResetColor();
                    Console.WriteLine("Господин " + Player.Name + "! " + "Прошу прощения за мою грубость!");
                    //Сделать фичу
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Слуга: ");
                    Console.ResetColor();
                    Console.WriteLine("Вы с ума сошли?! Вы же не до конца восстановились, вы и правда собираетесь идти на поле боя?");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n1.Другого выбора нет.\n2.Отлежусь пару дней.");
                    Console.ResetColor();
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Слуга: ");
                            Console.ResetColor();
                            Console.WriteLine("Что ж, с Вами бесполезно спорить! Я нашёл для Вас " + StrCutter(weapon[WeaponID], "@Name:", "@Damage:") + ". " + "Примите его и отправляйтесь в подземелье. Вам нужно восстановить свои навыки!");
                            bag.Add(WeaponID, 0);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n\n\nНажмите любую кнопку, чтобы продолжить.");
                            Console.ResetColor();
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D2:
                            break;
                        default:
                            Console.Clear();

                            break;
                    }
                    Console.Clear();
                    Actions();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    Player.Race = "Скелет";
                    Console.WriteLine("В склепе было сыро. Вы чувствуете пустоту внутри себя, приподнимаясь. Взглянув на руки и своё тело Вам становится понятно, что вы вернулись к жизни. Замечательная новость!");
                    Console.ReadLine();
                    Console.Clear();
                    Actions();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
        static void Main()
        {
            Console.WindowWidth = 174;
            Console.WindowHeight = 54;
            Console.WriteLine("1.Начать игру\n2.Выход");
            Player.init();
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    RaceChoose();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Увидимся, авантюрист!");
                    Console.ResetColor();
                    System.IO.File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(),"Texts","Inventory.txt"), string.Empty);
                    Console.ReadKey();
                    break;
                default:
                    Console.Clear();
                    Main();
                    break;
            }
        }

    }
}

