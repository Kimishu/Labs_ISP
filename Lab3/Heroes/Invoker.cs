
namespace Lab3
{
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
}
