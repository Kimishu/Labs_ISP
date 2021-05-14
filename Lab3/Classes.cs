using System;

namespace Lab3
{
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

    public class Hero:IHelpful, IReturn<int,bool,string>
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
            Console.Write("Основной атрибут: ");
            Return(MainAtribute.Index, false, MainAtribute.Name);

            Console.WriteLine(" ------------------------------------------");
            Console.Write("|");
            Return(1, String.Format("{0,-9}", "Сила"));
            Console.Write("|" + String.Format("{0,-12}", Strength) + "|");
            Return(1, String.Format("{0,-14}", "Здоровье"));
            Console.WriteLine("|" + HP);
            Console.WriteLine(" ------------------------------------------");

            Console.Write("|");
            Return(2, String.Format("{0,-9}", "Ловкость"));
            Console.Write("|" + String.Format("{0,-12}", Agility) + "|");
            Return(2, String.Format("{0,-14}", "Броня"));
            Console.WriteLine("|" + Armor);
            Console.WriteLine(" ------------------------------------------");

            Console.Write("|");
            Return(3, String.Format("{0,-9}", "Интеллект"));
            Console.Write("|" + String.Format("{0,-12}", Intelligence) + "|");
            Return(3, String.Format("{0,-14}", "Мана"));
            Console.WriteLine("|" + Mana);
            Console.WriteLine(" ------------------------------------------");

            Console.Write("|" + String.Format("{0,-9}", "Тип атаки"));
            Console.Write("|" + String.Format("{0,-12}", AttackType) + "|");
            Console.Write(String.Format("{0,-14}", "Сопр. магии") + "|");
            Console.WriteLine(MagicalResist + "%");
            Console.WriteLine(" ------------------------------------------");

            Console.Write("|");
            Console.Write(String.Format("{0,-9}", "Атака"));
            Console.Write("|");
            Console.Write(String.Format("{0,-12}", Attack));
            Console.Write("|");
            Console.Write(String.Format("{0,-14}", "Сопр. эффектам") + "|");
            Console.WriteLine(EffectsResist);
            Console.WriteLine(" ------------------------------------------");


            Console.WriteLine("\n\nНажмите любую кнопку, чтобы выйти\n\n\n");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
