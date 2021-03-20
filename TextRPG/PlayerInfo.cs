using System;

namespace PlayerInfo
{
    public class Player
    {
        static Random rnd = new Random();

        public static int HP;
        public static int MaxHP;
        public static int Mana;
        public static int MaxMana;
        public static string Name;
        public static string ClassPlayer;
        public static string Race;
        public static int Level = 1;
        public static int CurrentExperience = 0;
        public static int Money =0;
        public static void init()
        {
            HP = rnd.Next(20, 31);
            MaxHP = HP;
            Mana = rnd.Next(-1, 1);
            MaxMana = Mana;
            if (Mana == -1)
            {
                ClassPlayer = "Воин";
            }
            else
            {
                Mana = rnd.Next(10, 21);
                ClassPlayer = "Маг";
                MaxMana = Mana;
            }
        }

        public static void CheckExp()
        {
            if(CurrentExperience >= Level*2)
            {
                CurrentExperience -= Level * 2;
                Level++;
                MaxHP+=5;
                HP = MaxHP;
                
                if(ClassPlayer == "Маг")
                {
                    MaxMana+= 5;
                    Mana = MaxMana;
                }
            }
        }

    }
}