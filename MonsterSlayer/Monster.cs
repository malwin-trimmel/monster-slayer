namespace MonsterSlayer
{
    public class Monster
    {
        private string name;
        private int strength;
        private int loot;

        public Monster(string nameParam, int strengthParam, int lootParam)
        {
            name = nameParam;
            strength = strengthParam;
            loot = lootParam;
        }

        public string Name { get => name; }

        public int Strength { get => strength; }

        public int Loot { get => loot; }

    }
}