using System;
using System.Collections.Generic;

namespace MonsterSlayer
{
    public class Hero
    {
        private static Random random = new Random();

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

        public void clearAllBrokenWeapons()
        {
            List<Weapon> okWeapons = new List<Weapon>();

            foreach (Weapon nowWeapon in weapons)
            {
                if (!nowWeapon.isBroken())
                {
                    okWeapons.Add(nowWeapon);
                }
            }

            weapons = okWeapons;
        }

        public void clearAllOpWeapons(int ToHighDamage, int ToHighDurabilty)
        {
            List<Weapon> okWeapons = new List<Weapon>();

            foreach (Weapon nowWeapon in weapons)
            {
                if (nowWeapon.Damage < ToHighDamage && nowWeapon.Durabitly < ToHighDurabilty)
                {
                    okWeapons.Add(nowWeapon);
                }
            }

            weapons = okWeapons;
        }

        public int getStrength()
        {
            clearAllBrokenWeapons();

            int allWeaponDamage = 0;

            foreach (Weapon weapon in Weapons)
            {
                allWeaponDamage = weapon.Damage + allWeaponDamage;
            }

            return allWeaponDamage;
        }

        public void reduceAllWeaponsDuarabilty(int reduktion)
        {
            foreach (Weapon weapon in Weapons)
            {
                weapon.reduceDurabiltly(reduktion); 
            }

            clearAllBrokenWeapons();
        }

        public void addCoins(int moreCoins)
        {
            if (moreCoins > 0)
            {
                coins = coins + moreCoins;
            }
            else
            {
                Console.WriteLine("Can't add negative coins");
            }
        }

        public bool loseRandomWeapon()
        {
            if (weapons.Count > 0)
            {
                int randomNumber = random.Next(0, weapons.Count);
                Weapon removeWeapon = weapons[randomNumber];
                weapons.RemoveAt(randomNumber);

                Console.WriteLine($"Hero lost {removeWeapon.Name}!");

                return true;
            }
            else
            {
                Console.WriteLine("Hero has no weapons to lose");

                return false;
            }
        }

        public void loseHalfCoins()
        {
            coins = coins / 2;
        }
    }
}