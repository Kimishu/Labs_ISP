
namespace Lab3
{
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
}
