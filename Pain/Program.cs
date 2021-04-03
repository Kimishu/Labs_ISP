using System;


public class AttributeResolver
{
    public string Name { get; }
    public int Index { get; }

    /// <summary>
    /// Возвращает индекс атрибут и его название в человеческом виде
    /// <para>1 - Сила</para>
    /// <para>2 - Ловкость</para>
    /// <para>3 - Интеллект</para>
    /// </summary>
    public AttributeResolver(int index)
    {
        switch (index)
        {
            case 1:
                Name = "Сила";
                break;
            case 2:
                Name = "Ловкость";
                break;
            case 3:
                Name = "Интеллект";
                break;
        }
        Index = index;
    }
}
public class HeroData
{
    public int Level { get; set; }
    public int Gold { get; set; }
    public string HeroName { get; set; }
    public int Attack { get; set; }
    public double Armor { get; set; }
    public double HP { get; set; }
    public double Mana { get; set; }
    public double Strength { get; set; }
    public double Agility { get; set; }
    public double Intelligence { get; set; }

    public HeroData(int Level, int Gold, string HeroName, int Attack, double Armor, double HP, double Mana, double Strength, double Agility, double Intelligence)
    {
        this.Level = Level;
        this.Gold = Gold;
        this.HeroName = HeroName;
        this.Attack = Attack;
        this.Armor = Armor;
        this.HP = HP;
        this.Mana = Mana;
        this.Strength = Strength;
        this.Agility = Agility;
        this.Intelligence = Intelligence;
    }
}

public class HeroesData
{
    public static HeroData[] data;
    public HeroesData()
    {
        data = new HeroData[]
        {
            new HeroData(1, 600, "Abaddon",      55, 2.8, 660, 291, 23, 23, 18),
            new HeroData(1, 600, "Tidehunter",   55, 2.5, 740, 291, 27, 15, 18),
            new HeroData(1, 600, "Meepo",        48, 6.8, 680, 315, 24, 17, 20),
            new HeroData(1, 600, "Clinkz",       40, 3.7, 480, 291, 14, 22, 18),
            new HeroData(1, 600, "Storm Spirit", 55, 5.7, 620, 351, 21, 22, 23),
            new HeroData(1, 600, "Invoker",      46, 2.3, 560, 225, 18, 14, 15)
        };
    }

    public HeroData this[int index]
    {
        get
        {
            return data[index];
        }
    }
}

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
    public void Return(int index, bool SRank, string text)
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
        Console.WriteLine(text);
        Console.ResetColor();
    }
    public void Return(int index, string text)
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
        Console.Write(text);
        Console.ResetColor();
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
abstract class HeroType : Hero
{
    public string AttackType;
    public AttributeResolver MainAtribute;
    public int Level;
    public int Gold;
    public abstract double AtrStrength { get; }
    public abstract double AtrAgility { get; }
    public abstract double AtrIntelligence { get; }
    public abstract double MainAtr { get; }
    public void HeroInfo(int NewLevel)
    {
        Console.Clear();
        HP += (NewLevel - Level) * 20 * AtrStrength;
        Strength += AtrStrength * (NewLevel - Level);
        Agility += Agility + (AtrAgility * (NewLevel - Level));
        Intelligence += AtrIntelligence * (NewLevel - Level);
        Mana += (NewLevel - Level) * 12 * AtrIntelligence;
        Armor = Math.Round(Armor + (NewLevel - Level) * 0.16666666666667 * AtrAgility);
        Attack += (NewLevel - Level) * MainAtr;
        Level = NewLevel;
        Console.Write("Вы выбрали героя ");
        Return(MainAtribute.Index, false, HeroName);
        Console.Write("Уровень: ");
        Return(4, false, Level.ToString());
        Console.WriteLine("Золото: " + Gold);
        Console.Write($"Основной атрибут: ");
        Return(MainAtribute.Index, false, MainAtribute.Name);
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(1, String.Format("{0,-9}", "Сила"));
        Console.Write("|" + String.Format("{0,-12}", Strength) + "|");
        Return(1, String.Format("{0,-14}", "Здоровье"));
        Console.Write("|" + HP);
        Console.WriteLine(String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(2, String.Format("{0,-9}", "Ловкость"));
        Console.Write("|" + String.Format("{0,-12}", Agility) + "|");
        Return(2, String.Format("{0,-14}", "Броня"));
        Console.WriteLine("|" + Armor + String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(3, String.Format("{0,-9}", "Интеллект"));
        Console.Write("|" + String.Format("{0,-12}", Intelligence) + "|");
        Return(3, String.Format("{0,-14}", "Мана"));
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
    }

}
class Abaddon : HeroType
{
    public override double AtrStrength => 3;
    public override double AtrAgility => 1.5;
    public override double AtrIntelligence => 2;
    public override double MainAtr => 3;


    public Abaddon(HeroData data)
    {
        Gold = data.Gold;
        Level = data.Level;
        HeroName = data.HeroName;
        Armor = data.Armor;
        HP = data.HP;
        Mana = data.Mana;
        Strength = data.Strength;
        Agility = data.Agility;
        Intelligence = data.Intelligence;
        MainAtribute = new AttributeResolver(1);
        AttackType = "Ближний бой";
        Attack = data.Attack;
    }
}
class Tidehunter : HeroType
{
    public override double AtrStrength => 3.5;
    public override double AtrAgility => 1.5;
    public override double AtrIntelligence => 1.7;
    public override double MainAtr => 3.5;
    public Tidehunter(HeroData data)
    {
        Gold = data.Gold;
        Level = data.Level;
        HeroName = data.HeroName;
        Armor = data.Armor;
        HP = data.HP;
        Mana = data.Mana;
        Strength = data.Strength;
        Agility = data.Agility;
        Intelligence = data.Intelligence;
        MainAtribute = new AttributeResolver(1);
        AttackType = "Ближний бой";
        Attack = data.Attack;
    }
}
class Meepo : HeroType
{
    public override double AtrStrength => 1.8;
    public override double AtrAgility => 1.8;
    public override double AtrIntelligence => 1.6;
    public override double MainAtr => 1.8;
    public Meepo(HeroData data)
    {
        Gold = data.Gold;
        Level = data.Level;
        HeroName = data.HeroName;
        Armor = data.Armor;
        HP = data.HP;
        Mana = data.Mana;
        Strength = data.Strength;
        Agility = data.Agility;
        Intelligence = data.Intelligence;
        MainAtribute = new AttributeResolver(2);
        AttackType = "Ближний бой";
        Attack = data.Attack;
    }
}
class Clinkz : HeroType
{
    public override double AtrStrength => 2.2;
    public override double AtrAgility => 2.7;
    public override double AtrIntelligence => 2.2;
    public override double MainAtr => 2.7;
    public Clinkz(HeroData data)
    {
        Gold = data.Gold;
        Level = data.Level;
        HeroName = data.HeroName;
        Armor = data.Armor;
        HP = data.HP;
        Mana = data.Mana;
        Strength = data.Strength;
        Agility = data.Agility;
        Intelligence = data.Intelligence;
        MainAtribute = new AttributeResolver(2);
        AttackType = "Дальний бой";
        Attack = data.Attack;
    }
}
class StormSpirit : HeroType
{
    public override double AtrStrength => 2;
    public override double AtrAgility => 1.7;
    public override double AtrIntelligence => 3.9;
    public override double MainAtr => 3.9;
    public StormSpirit(HeroData data)
    {
        Gold = data.Gold;
        Level = data.Level;
        HeroName = data.HeroName;
        Armor = data.Armor;
        HP = data.HP;
        Mana = data.Mana;
        Strength = data.Strength;
        Agility = data.Agility;
        Intelligence = data.Intelligence;
        MainAtribute = new AttributeResolver(3);
        AttackType = "Дальний бой";
        Attack = data.Attack;
    }
}
class Invoker : HeroType
{
    public override double AtrStrength => 2.4;
    public override double AtrAgility => 1.9;
    public override double AtrIntelligence => 4.6;
    public override double MainAtr => 4.6;
    public Invoker(HeroData data)
    {
        Gold = data.Gold;
        Level = data.Level;
        HeroName = data.HeroName;
        Armor = data.Armor;
        HP = data.HP;
        Mana = data.Mana;
        Strength = data.Strength;
        Agility = data.Agility;
        Intelligence = data.Intelligence;
        MainAtribute = new AttributeResolver(3);
        AttackType = "Дальний бой";
        Attack = data.Attack;
    }
}
namespace Lab3
{
    class Program
    {
        static void Main()
        {
            HeroesData heroes = new HeroesData(); // init
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
                        hero.ChosenVariant(heroes, Count);
                        Main();
                        break;
                }
            }
        }
    }
}