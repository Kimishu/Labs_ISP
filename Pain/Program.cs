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
        Console.WriteLine("Укажите нужный уровень:");
        switch (Count + 1)
        {
            case 1:
                Abaddon hero1 = new Abaddon(1,600,"Abaddon",55,2.8,660,291,23,23,18);
                hero1.HeroInfo(Convert.ToInt32(Console.ReadLine()));
                break;
            case 2:
                Tidehunter hero2 = new Tidehunter(1,600,"Tidehunter",55,2.5, 740, 291, 27, 15, 18); ;
                hero2.HeroInfo(Convert.ToInt32(Console.ReadLine()));
                break;
            case 3:
                Meepo hero3 = new Meepo(1,600,"Meepo",48, 6.8, 680,315,24 , 17, 20);
                hero3.HeroInfo(Convert.ToInt32(Console.ReadLine()));
                break;
            case 4:
                Clinkz hero4 = new Clinkz(1,600, "Clinkz",40,3.7 , 480, 291, 14, 22, 18);
                hero4.HeroInfo(Convert.ToInt32(Console.ReadLine()));
                break;
            case 5:
                StormSpirit hero5 = new StormSpirit(1,600, "Storm Spirit",55, 5.7,620 , 351, 21, 22, 23);
                hero5.HeroInfo(Convert.ToInt32(Console.ReadLine()));
                break;
            case 6:
                Invoker hero6 = new Invoker(1,600,"Invoker",46, 2.3, 560, 225, 18, 14, 15);
                hero6.HeroInfo(Convert.ToInt32(Console.ReadLine()));
                break;
        }
    }
}
abstract class HeroType : Hero
{
    public string AttackType;
    public string MainAtribute;
    public abstract void HeroInfo(int Level);
    
}
class Abaddon : HeroType
{
    public int Level;
    public int Gold;
    public double AtrStrength = 3;
    public double AtrAgility = 1.5;
    public double AtrIntelligence = 2;
    public double MainAtr = 3;
    
    
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
    public override void HeroInfo(int NewLevel)
    {
        Console.Clear();
        this.HP = HP + (NewLevel - Level) * 20 * AtrStrength;
        this.Strength = Strength + (AtrStrength * (NewLevel - Level));
        this.Agility = Agility + (AtrAgility * (NewLevel - Level));
        this.Intelligence = Intelligence + (AtrIntelligence * (NewLevel - Level));
        this.Mana = Mana + (NewLevel - Level) * 12 * AtrIntelligence;
        this.Armor = Math.Round(Armor + (NewLevel - Level) * 0.16666666666667 * AtrAgility);
        this.Attack = Attack + (NewLevel - Level) * MainAtr;
        this.Level = NewLevel;
        Console.Write("Вы выбрали героя ");
        Return(1, false, "Abaddon");
        Console.Write("Уровень: ");
        Return(4, false, Level.ToString());
        Console.WriteLine("Золото: " + Gold);
        Console.Write($"Основной атрибут: ");
        Return(1, false, MainAtribute);
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
        Console.WriteLine("|" + Armor+ String.Format("{0,4}", "|"));
        Console.WriteLine(" --------------------------------------------");
        Console.Write($"|");
        Return(3, String.Format("{0,-9}", "Интеллект"));
        Console.Write("|" + String.Format("{0,-12}", Intelligence) + "|");
        Return(3, String.Format("{0,-14}", "Мана"));
        Console.WriteLine("|" + Mana+ String.Format("{0,4}", "|"));
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
class Tidehunter : HeroType
{
    public int Level;
    public int Gold;
    public double AtrStrength = 3.5;
    public double AtrAgility = 1.5;
    public double AtrIntelligence = 1.7;
    public double MainAtr = 3.5;
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
    public override void HeroInfo(int NewLevel)
    {
        Console.Clear();
        this.HP = HP + (NewLevel - Level) * 20 * AtrStrength;
        this.Strength = Strength + (AtrStrength * (NewLevel - Level));
        this.Agility = Agility + (AtrAgility * (NewLevel - Level));
        this.Intelligence = Intelligence + (AtrIntelligence * (NewLevel - Level));
        this.Mana = Mana + (NewLevel - Level) * 12 * AtrIntelligence;
        this.Armor = Math.Round(Armor + (NewLevel - Level) * 0.16666666666667 * AtrAgility);
        this.Attack = Attack + (NewLevel - Level) * MainAtr;
        this.Level = NewLevel;
        Console.Write("Уровень: ");
        Return(4, false, Level.ToString());
        Console.Write($"Основной атрибут: ");
        Return(1, false, MainAtribute);
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
        Console.Write("|"+String.Format("{0,-9}", "Атака")+ "|");
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
class Meepo : HeroType
{
    public int Level;
    public int Gold;
    public double AtrStrength = 1.8;
    public double AtrAgility = 1.8;
    public double AtrIntelligence = 1.6;
    public double MainAtr = 1.8;
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
    public override void HeroInfo(int NewLevel)
    {
        Console.Clear();
        this.HP = HP + (NewLevel - Level) * 20 * AtrStrength;
        this.Strength = Strength + (AtrStrength * (NewLevel - Level));
        this.Agility = Agility + (AtrAgility * (NewLevel - Level));
        this.Intelligence = Intelligence + (AtrIntelligence * (NewLevel - Level));
        this.Mana = Mana + (NewLevel - Level) * 12 * AtrIntelligence;
        this.Armor = Math.Round(Armor + (NewLevel - Level) * 0.16666666666667 * AtrAgility);
        this.Attack = Attack + (NewLevel - Level) * MainAtr;
        this.Level = NewLevel;
        Console.Write("Уровень: ");
        Return(4, false, Level.ToString());
        Console.Write($"Основной атрибут: ");
        Return(2, false, MainAtribute);
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
class Clinkz : HeroType
{
    public int Level;
    public int Gold;
    public double AtrStrength = 2.2;
    public double AtrAgility = 2.7;
    public double AtrIntelligence = 2.2;
    public double MainAtr = 2.7;
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
    public override void HeroInfo(int NewLevel)
    {
        Console.Clear();
        this.HP = HP + (NewLevel - Level) * 20 * AtrStrength;
        this.Strength = Strength + (AtrStrength * (NewLevel - Level));
        this.Agility = Agility + (AtrAgility * (NewLevel - Level));
        this.Intelligence = Intelligence + (AtrIntelligence * (NewLevel - Level));
        this.Mana = Mana + (NewLevel - Level) * 12 * AtrIntelligence;
        this.Armor = Math.Round(Armor + (NewLevel - Level) * 0.16666666666667 * AtrAgility);
        this.Attack = Attack + (NewLevel - Level) * MainAtr;
        this.Level = NewLevel;
        Console.Write("Уровень: ");
        Return(4, false, Level.ToString());
        Console.Write($"Основной атрибут: ");
        Return(2, false, MainAtribute);
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
class StormSpirit : HeroType
{
    public int Level;
    public int Gold;
    public double AtrStrength = 2;
    public double AtrAgility =1.7;
    public double AtrIntelligence = 3.9;
    public double MainAtr = 3.9;
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
    public override void HeroInfo(int NewLevel)
    {
        Console.Clear();
        this.HP = HP + (NewLevel - Level) * 20 * AtrStrength;
        this.Strength = Strength + (AtrStrength * (NewLevel - Level));
        this.Agility = Agility + (AtrAgility * (NewLevel - Level));
        this.Intelligence = Intelligence + (AtrIntelligence * (NewLevel - Level));
        this.Mana = Mana + (NewLevel - Level) * 12 * AtrIntelligence;
        this.Armor = Math.Round(Armor + (NewLevel - Level) * 0.16666666666667 * AtrAgility);
        this.Attack = Attack + (NewLevel - Level) * MainAtr;
        this.Level = NewLevel;
        Console.Write("Уровень: ");
        Return(4, false, Level.ToString());
        Console.Write($"Основной атрибут: ");
        Return(3, false, MainAtribute);
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
class Invoker : HeroType
{
    public int Level;
    public int Gold;
    public double AtrStrength = 2.4;
    public double AtrAgility = 1.9;
    public double AtrIntelligence = 4.6;
    public double MainAtr = 4.6;
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
    public override void HeroInfo(int NewLevel)
    {
        Console.Clear();
        this.HP = HP + (NewLevel - Level) * 20 * AtrStrength;
        this.Strength = Strength + (AtrStrength * (NewLevel - Level));
        this.Agility = Agility + (AtrAgility * (NewLevel - Level));
        this.Intelligence = Intelligence + (AtrIntelligence * (NewLevel - Level));
        this.Mana = Mana + (NewLevel - Level) * 12 * AtrIntelligence;
        this.Armor = Math.Round(Armor + (NewLevel - Level) * 0.16666666666667 * AtrAgility);
        this.Attack = Attack + (NewLevel - Level) * MainAtr;
        this.Level = NewLevel;
        Console.Write("Уровень: ");
        Return(4, false, Level.ToString());
        Console.Write($"Основной атрибут: ");
        Return(3, false, MainAtribute);
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