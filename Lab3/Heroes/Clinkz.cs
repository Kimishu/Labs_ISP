
namespace Lab3
{
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
}
