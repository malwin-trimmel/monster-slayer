namespace MonsterSlayer
{
    public class Weapon
    {
        private string name;
        private int damage;
        private int durabilty;

        public Weapon(string nameParam, int damageParam, int durabiltyParam)
        {
            name = nameParam;
            damage = damageParam;
            durabilty = durabiltyParam;
        }

        public string Name { get => name; }

        public int Damage { get => damage; }

        public int Durabitly { get => durabilty;  }

        public void reduceDurabiltly(int reduktion)
        {
            durabilty = durabilty - reduktion;
        }

        public bool isBroken()
        {
            return durabilty <= 0;
        }
    }
}