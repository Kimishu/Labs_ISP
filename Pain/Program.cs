using System;

public class Hero
{
    public string HeroName;
    public double Armor;
    public double HP;
    public double Mana;
    public double Strength;
    public double Agility;
    public double Intelligence;
 
    public double Attack;

    public int EffectsResist;
    public int MagicalResist = 25;
    public virtual void Menu(int Count)
    {
        string[] Variants = new string[6];
        Variants[0] = "Abaddon";
        Variants[1] = "Tidehunter";
        Variants[2] = "Meepo";
        Variants[3] = "Clinkz";
        Variants[4] = "Storm Spirit";
        Variants[5] = "Invoker";


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
    public void Return(int index, bool SRank,string text)
    {
        switch (index)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Green;
                break;

            case 3:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
        }
        if (!SRank)
        {
            Console.WriteLine(text);
        }
        else
        {
            Console.Write(text);
        }
        Console.ResetColor();
    }
    public virtual void ChosenVariant(int Count)
    {
        string[] Variants = new string[6];
        Variants[0] = "Abaddon";
        Variants[1] = "Tidehunter";
        Variants[2] = "Meepo";
        Variants[3] = "Clinkz";
        Variants[4] = "Storm Spirit";
        Variants[5] = "Invoker";
        Console.Clear();
        //Console.Write("Вы выбрали героя ");
        //Return(1, false, "Abaddon");
        switch (Count + 1)
        {
            case 1:
               
                Abaddon hero1 = new Abaddon(1,600,"Abaddon",55,2.8,660,291,23,23,18);
                hero1.HeroInfo();
                break;
            case 2:
                Return(1, false, "Tidehunter");
                Tidehunter hero2 = new Tidehunter(1,600,"Tidehunter",55,2.5, 740, 291, 27, 15, 18); ;
                hero2.HeroInfo();
                break;
            case 3:
                Return(2, false, "Meepo");
                Meepo hero3 = new Meepo(1,600,"Meepo",48, 6.8, 680,315,24 , 17, 20); 
                hero3.HeroInfo();
                break;
            case 4:
                Return(2, false, "Clinkz");
                Clinkz hero4 = new Clinkz(1,600, "Clinkz",40,3.7 , 480, 291, 14, 22, 18); 
                hero4.HeroInfo();
                break;
            case 5:
                Return(3, false, "Storm Spirit");
                StormSpirit hero5 = new StormSpirit(1,600, "Storm Spirit",55, 5.7,620 , 351, 21, 22, 23);
                hero5.HeroInfo();
                break;
            case 6:
                Return(3, false, "Invoker");
                Invoker hero6 = new Invoker(1,600,"Invoker",46, 2.3, 560, 225, 18, 14, 15); 
                hero6.HeroInfo();
                break;
        }
    }
}
abstract class HeroType : Hero
{
    public string AttackType;
    public string MainAtribute;
    public abstract void HeroInfo();
    
}
class Abaddon : HeroType
{
    public int Level;
    public int NewLevel;
    public int Gold;
    public double AtrStrength = 3;
    public double AtrAgility = 1.5;
    public double AtrIntelligence = 2;
    public double MainAtr = 3;
    public int this[int index]
    {
        set
        {
            Gold = value;
        }
        get
        {
            return Gold;
        }
        
    }
    public Abaddon(int Level, int Gold, string HeroName, int Attack, double Armor, double HP, double Mana, double Strength, double Agility, double Intelligence)
    {
        this.Gold = Gold;
        this.Level = Level;
        this.HeroName = HeroName;
        this.Armor = Armor;
        this.HP = HP;
        this.Mana = Mana;
        this.Strength = Strength;
        this.Agility = Agility;
        this.Intelligence = Intelligence;
        this.MainAtribute = "Сила";
        this.AttackType = "Ближний бой";
        this.Attack = Attack;
    }
    public override void HeroInfo()
    {
        Console.Write("Вы выбрали героя ");
        Return(1, false, "Abaddon");
        int Count = 0;
        Console.Write("Уровень: ");
        Return(4, false, Level.ToString());
        Console.Write($"Основной атрибут: ");
        Return(1, false, MainAtribute);
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(1, true, String.Format("{0,-9}", "Сила"));
        Console.Write("|" + String.Format("{0,-12}", Strength) + "|");
        Return(1, true, String.Format("{0,-14}", "Здоровье"));
        Console.Write("|" + HP);
        Console.WriteLine(String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(2, true, String.Format("{0,-9}", "Ловкость"));
        Console.Write("|" + String.Format("{0,-12}", Agility) + "|");
        Return(2, true, String.Format("{0,-14}", "Броня"));
        Console.WriteLine("|" + Armor + String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(3, true, String.Format("{0,-9}", "Интеллект"));
        Console.Write("|" + String.Format("{0,-12}", Intelligence) + "|");
        Return(3, true, String.Format("{0,-14}", "Мана"));
        Console.WriteLine("|" + Mana + String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write("|");
        Console.Write(String.Format("{0,-9}", "Тип атаки") + "|");
        Console.Write(String.Format("{0,-12}", AttackType));
        Console.Write("|");
        Console.Write(String.Format("{0,-14}", "Сопр. магии") + "|");
        Console.Write(MagicalResist);
        Console.WriteLine(String.Format("{0,5}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write("|");
        Console.Write(String.Format("{0,-9}", "Атака"));
        Console.Write("|");
        Console.Write(String.Format("{0,-12}", Attack));
        Console.Write("|");
        Console.Write(String.Format("{0,-14}", "Сопр. эффектам") + "|");
        Console.Write(EffectsResist);
        Console.WriteLine(String.Format("{0,6}", "|"));
        Console.WriteLine(" --------------------------------------------");

        Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
        Console.ReadKey();
        Console.Clear();
        Menu(Count);
        while (true)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.DownArrow:
                    Console.Clear();
                    Count++;
                    if (Count == 4)
                    {
                        Count = 0;
                        Menu(Count);
                    }
                    else
                    {
                        Menu(Count);
                    }
                    break;
                case ConsoleKey.UpArrow:
                    Console.Clear();
                    Count--;
                    if (Count < 0)
                    {
                        Count = 3;
                        Menu(Count);
                    }
                    else
                    {
                        Menu(Count);
                    }
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    ChosenVariant(Count);
                    break;
            }
        }

    }

    public override void Menu(int Count)
    {
        string[] Variants = new string[4];
        Variants[0] = "Изменить количество золота";
        Variants[1] = "Изменить уровень";
        Variants[2] = "Информация о герое";
        Variants[3] = "Выход";
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

    public override void ChosenVariant(int Count)
    {
            switch (Count + 1)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Введите нужное количество золота: ");
                    this.Gold = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Menu(Count);
                    break;
                case 2:
                    Console.Clear();
                    Console.Write("Введите нужный уровень: ");
                while(NewLevel == Level || NewLevel<0 ) 
                {
                    this.NewLevel = Convert.ToInt32(Console.ReadLine());
                }
                    LevelUp(NewLevel,Level);
                    Console.Clear();
                    Menu(Count);
                break;
                case 3:
                    Console.Clear();
                    HeroInfo();
                    break;
                case 4:
                    break;

            }
    }
    public void LevelUp(int NewLevel, int Level)
    {
        this.HP = HP + (NewLevel - Level) * 20 * AtrStrength;
        this.Mana = Mana + (NewLevel - Level) * 12 * AtrIntelligence;
        this.Armor = Armor + (NewLevel - Level) * 0.16666666666667 * AtrAgility;
        this.Attack = Attack + (NewLevel - Level) * MainAtr;
        this.Level = NewLevel;
    }

}
class Tidehunter : HeroType
{
    public int Level { get; }
    public int Gold { get; }
    public Tidehunter(int Level, int Gold, string HeroName, double Attack, double Armor, int HP, int Mana, double Strength, double Agility, double Intelligence)
    {
        this.Gold = Gold;
        this.Level = Level;
        this.HeroName = HeroName;
        this.Armor = Armor;
        this.HP = HP;
        this.Mana = Mana;
        this.Strength = Strength;
        this.Agility = Agility;
        this.Intelligence = Intelligence;
        this.MainAtribute = "Сила";
        this.Attack = Attack;
        this.AttackType = "Ближний бой";
    }
    public override void HeroInfo()
    {
        Console.Write("Уровень: ");
        Return(4, false, Level.ToString());
        Console.Write($"Основной атрибут: ");
        Return(1, false, MainAtribute);
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(1, true, String.Format("{0,-9}", "Сила"));
        Console.Write("|" + String.Format("{0,-12}", Strength) + "|");
        Return(1, true, String.Format("{0,-14}", "Здоровье"));
        Console.Write("|" + HP);
        Console.WriteLine(String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(2, true, String.Format("{0,-9}", "Ловкость"));
        Console.Write("|" + String.Format("{0,-12}", Agility) + "|");
        Return(2, true, String.Format("{0,-14}", "Броня"));
        Console.WriteLine("|" + Armor + String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(3, true, String.Format("{0,-9}", "Интеллект"));
        Console.Write("|" + String.Format("{0,-12}", Intelligence) + "|");
        Return(3, true, String.Format("{0,-14}", "Мана"));
        Console.WriteLine("|" + Mana + String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write("|");
        Console.Write(String.Format("{0,-9}", "Тип атаки") + "|");
        Console.Write(String.Format("{0,-12}", AttackType));
        Console.Write("|");
        Console.Write(String.Format("{0,-14}", "Сопр. магии") + "|");
        Console.Write(MagicalResist);
        Console.WriteLine(String.Format("{0,5}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write("|");
        Console.Write(String.Format("{0,-9}", "Атака"));
        Console.Write("|");
        Console.Write(String.Format("{0,-12}", Attack));
        Console.Write("|");
        Console.Write(String.Format("{0,-14}", "Сопр. эффектам") + "|");
        Console.Write(EffectsResist);
        Console.WriteLine(String.Format("{0,6}", "|"));
        Console.WriteLine(" --------------------------------------------");

        Console.ReadKey();
        Console.Clear();
    }
}
class Meepo : HeroType
{
    public int Level { get; }
    public int Gold { get; }
    public Meepo(int Level, int Gold, string HeroName, double Attack, double Armor, int HP, int Mana, double Strength, double Agility, double Intelligence)
    {
        this.Gold = Gold;
        this.Level = Level;
        this.HeroName = HeroName;
        this.Armor = Armor;
        this.HP = HP;
        this.Mana = Mana;
        this.Strength = Strength;
        this.Agility = Agility;
        this.Intelligence = Intelligence;
        this.MainAtribute = "Ловкость";
        this.Attack = Attack;
        this.AttackType = "Ближний бой";
    }
    public override void HeroInfo()
    {
        Console.Write("Уровень: ");
        Return(4, false, Level.ToString());
        Console.Write($"Основной атрибут: ");
        Return(2, false, MainAtribute);
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(1, true, String.Format("{0,-9}", "Сила"));
        Console.Write("|" + String.Format("{0,-12}", Strength) + "|");
        Return(1, true, String.Format("{0,-14}", "Здоровье"));
        Console.Write("|" + HP);
        Console.WriteLine(String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(2, true, String.Format("{0,-9}", "Ловкость"));
        Console.Write("|" + String.Format("{0,-12}", Agility) + "|");
        Return(2, true, String.Format("{0,-14}", "Броня"));
        Console.WriteLine("|" + Armor + String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(3, true, String.Format("{0,-9}", "Интеллект"));
        Console.Write("|" + String.Format("{0,-12}", Intelligence) + "|");
        Return(3, true, String.Format("{0,-14}", "Мана"));
        Console.WriteLine("|" + Mana + String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write("|");
        Console.Write(String.Format("{0,-9}", "Тип атаки") + "|");
        Console.Write(String.Format("{0,-12}", AttackType));
        Console.Write("|");
        Console.Write(String.Format("{0,-14}", "Сопр. магии") + "|");
        Console.Write(MagicalResist);
        Console.WriteLine(String.Format("{0,5}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write("|");
        Console.Write(String.Format("{0,-9}", "Атака"));
        Console.Write("|");
        Console.Write(String.Format("{0,-12}", Attack));
        Console.Write("|");
        Console.Write(String.Format("{0,-14}", "Сопр. эффектам") + "|");
        Console.Write(EffectsResist);
        Console.WriteLine(String.Format("{0,6}", "|"));
        Console.WriteLine(" --------------------------------------------");

        Console.ReadKey();
        Console.Clear();
    }
}
class Clinkz : HeroType
{
    public int Level { get; }
    public int Gold { get; }
    public Clinkz(int Level, int Gold, string HeroName, double Attack, double Armor, int HP, int Mana, double Strength, double Agility, double Intelligence)
    {
        this.Gold = Gold;
        this.Level = Level;
        this.HeroName = HeroName;
        this.Armor = Armor;
        this.HP = HP;
        this.Mana = Mana;
        this.Strength = Strength;
        this.Agility = Agility;
        this.Intelligence = Intelligence;
        this.MainAtribute = "Ловкость";
        this.Attack = Attack;
        this.AttackType = "Дальний бой";
    }
    public override void HeroInfo()
    {
        Console.Write("Уровень: ");
        Return(4, false, Level.ToString());
        Console.Write($"Основной атрибут: ");
        Return(2, false, MainAtribute);
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(1, true, String.Format("{0,-9}", "Сила"));
        Console.Write("|" + String.Format("{0,-12}", Strength) + "|");
        Return(1, true, String.Format("{0,-14}", "Здоровье"));
        Console.Write("|" + HP);
        Console.WriteLine(String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(2, true, String.Format("{0,-9}", "Ловкость"));
        Console.Write("|" + String.Format("{0,-12}", Agility) + "|");
        Return(2, true, String.Format("{0,-14}", "Броня"));
        Console.WriteLine("|" + Armor + String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(3, true, String.Format("{0,-9}", "Интеллект"));
        Console.Write("|" + String.Format("{0,-12}", Intelligence) + "|");
        Return(3, true, String.Format("{0,-14}", "Мана"));
        Console.WriteLine("|" + Mana + String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write("|");
        Console.Write(String.Format("{0,-9}", "Тип атаки") + "|");
        Console.Write(String.Format("{0,-12}", AttackType));
        Console.Write("|");
        Console.Write(String.Format("{0,-14}", "Сопр. магии") + "|");
        Console.Write(MagicalResist);
        Console.WriteLine(String.Format("{0,5}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write("|");
        Console.Write(String.Format("{0,-9}", "Атака"));
        Console.Write("|");
        Console.Write(String.Format("{0,-12}", Attack));
        Console.Write("|");
        Console.Write(String.Format("{0,-14}", "Сопр. эффектам") + "|");
        Console.Write(EffectsResist);
        Console.WriteLine(String.Format("{0,6}", "|"));
        Console.WriteLine(" --------------------------------------------");

        Console.ReadKey();
        Console.Clear();
    }
}
class StormSpirit : HeroType
{
    public int Level { get; }
    public int Gold { get; }
    public StormSpirit(int Level, int Gold, string HeroName, double Attack, double Armor, int HP, int Mana, double Strength, double Agility, double Intelligence)
    {
        this.Gold = Gold;
        this.Level = Level;
        this.HeroName = HeroName;
        this.Armor = Armor;
        this.HP = HP;
        this.Mana = Mana;
        this.Strength = Strength;
        this.Agility = Agility;
        this.Intelligence = Intelligence;
        this.MainAtribute = "Интеллект";
        this.Attack = Attack;
        this.AttackType = "Дальний бой";
    }
    public override void HeroInfo()
    {
        Console.Write("Уровень: ");
        Return(4, false, Level.ToString());
        Console.Write($"Основной атрибут: ");
        Return(3, false, MainAtribute);
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(1, true, String.Format("{0,-9}", "Сила"));
        Console.Write("|" + String.Format("{0,-12}", Strength) + "|");
        Return(1, true, String.Format("{0,-14}", "Здоровье"));
        Console.Write("|" + HP);
        Console.WriteLine(String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(2, true, String.Format("{0,-9}", "Ловкость"));
        Console.Write("|" + String.Format("{0,-12}", Agility) + "|");
        Return(2, true, String.Format("{0,-14}", "Броня"));
        Console.WriteLine("|" + Armor + String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(3, true, String.Format("{0,-9}", "Интеллект"));
        Console.Write("|" + String.Format("{0,-12}", Intelligence) + "|");
        Return(3, true, String.Format("{0,-14}", "Мана"));
        Console.WriteLine("|" + Mana + String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write("|");
        Console.Write(String.Format("{0,-9}", "Тип атаки") + "|");
        Console.Write(String.Format("{0,-12}", AttackType));
        Console.Write("|");
        Console.Write(String.Format("{0,-14}", "Сопр. магии") + "|");
        Console.Write(MagicalResist);
        Console.WriteLine(String.Format("{0,5}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write("|");
        Console.Write(String.Format("{0,-9}", "Атака"));
        Console.Write("|");
        Console.Write(String.Format("{0,-12}", Attack));
        Console.Write("|");
        Console.Write(String.Format("{0,-14}", "Сопр. эффектам") + "|");
        Console.Write(EffectsResist);
        Console.WriteLine(String.Format("{0,6}", "|"));
        Console.WriteLine(" --------------------------------------------");

        Console.ReadKey();
        Console.Clear();
    }
}
class Invoker : HeroType
{
    public int Level { get; }
    public int Gold { get; }
    public Invoker(int Level, int Gold,string HeroName, double Attack, double Armor, int HP, int Mana, double Strength, double Agility, double Intelligence)
    {
        this.Gold = Gold;
        this.Level = Level;
        this.HeroName = HeroName;
        this.Armor = Armor;
        this.HP = HP;
        this.Mana = Mana;
        this.Strength = Strength;
        this.Agility = Agility;
        this.Intelligence = Intelligence;
        this.MainAtribute = "Интеллект";
        this.Attack = Attack;
        this.AttackType = "Дальний бой";
    }
    public override void HeroInfo()
    {
        Console.Write("Уровень: ");
        Return(4, false, Level.ToString());
        Console.Write($"Основной атрибут: ");
        Return(3, false, MainAtribute);
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(1, true, String.Format("{0,-9}", "Сила"));
        Console.Write("|" + String.Format("{0,-12}", Strength) + "|");
        Return(1, true, String.Format("{0,-14}", "Здоровье"));
        Console.Write("|" + HP);
        Console.WriteLine(String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(2, true, String.Format("{0,-9}", "Ловкость"));
        Console.Write("|" + String.Format("{0,-12}", Agility) + "|");
        Return(2, true, String.Format("{0,-14}", "Броня"));
        Console.WriteLine("|" + Armor + String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(3, true, String.Format("{0,-9}", "Интеллект"));
        Console.Write("|" + String.Format("{0,-12}", Intelligence) + "|");
        Return(3, true, String.Format("{0,-14}", "Мана"));
        Console.WriteLine("|" + Mana + String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write("|");
        Console.Write(String.Format("{0,-9}", "Тип атаки") + "|");
        Console.Write(String.Format("{0,-12}", AttackType));
        Console.Write("|");
        Console.Write(String.Format("{0,-14}", "Сопр. магии") + "|");
        Console.Write(MagicalResist);
        Console.WriteLine(String.Format("{0,5}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write("|");
        Console.Write(String.Format("{0,-9}", "Атака"));
        Console.Write("|");
        Console.Write(String.Format("{0,-12}", Attack));
        Console.Write("|");
        Console.Write(String.Format("{0,-14}", "Сопр. эффектам") + "|");
        Console.Write(EffectsResist);
        Console.WriteLine(String.Format("{0,6}", "|"));
        Console.WriteLine(" --------------------------------------------");

        Console.ReadKey();
        Console.Clear();
    }
}
namespace Lab3
{
    class Program
    {
        static void Main()
        {
            int Count = 0;
            Hero hero = new Hero();
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
                        hero.ChosenVariant(Count);
                        Main();
                        break;
                }
            }
        }
    }
}