
namespace Lab3
{
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
}
