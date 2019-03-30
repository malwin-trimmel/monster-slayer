using System;
using System.Collections.Generic;

namespace MonsterSlayer
{
    public class Hero
    {
        private int coins;
        private List<Weapon> weapons = new List<Weapon>();

        public Hero(int coinsParam)
        {
            coins = coinsParam;
        }

        public int Coins { get => coins; }

        public List<Weapon> Weapons { get => new List<Weapon>(weapons); }

        public void AddWeapon(Weapon newWeapon)
        {
            int weaponCost = newWeapon.Damage + newWeapon.Durabitly;

            if (coins >= weaponCost)
            {
                weapons.Add(newWeapon);
                coins = coins - weaponCost;
            }
            else
            {
                Console.WriteLine($"Hero can't afford the Weapon: {newWeapon.Name}");
            }
        }
    }
}