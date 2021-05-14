
namespace Lab3
{
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
}
