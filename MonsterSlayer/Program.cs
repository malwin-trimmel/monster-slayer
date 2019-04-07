using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterSlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo User! How many coins should your Hero start with?");
            string howMuchGold = Console.ReadLine();
            int heroGold = Convert.ToInt32(howMuchGold);

            Hero namelessHero = new Hero(heroGold);

            while (namelessHero.Coins > 0 || namelessHero.Weapons.Count > 0)
            {
                Console.WriteLine("Please enter your Command");
                string strCommand = Console.ReadLine();

                if (strCommand.Contains('+'))
                {
                    Weapon newWeapon = createWeapon(strCommand);

                    if (newWeapon != null)
                    {
                        namelessHero.AddWeapon(newWeapon);
                    }
                    
                }
                else if(strCommand.Contains('-'))
                {
                    Monster monster = createMonster(strCommand);
                    if (monster != null)
                    {
                        int strengthDiff = namelessHero.getStrength() - monster.Strength;
                        if (strengthDiff > 0)
                        {
                            Console.WriteLine($"Hero is stronger by {strengthDiff} points than Monster {monster.Name} - HERO WINS");
                            namelessHero.addCoins(monster.Loot);
                            namelessHero.reduceAllWeaponsDuarabilty(1);


                        }
                        else if (strengthDiff == 0)
                        {
                            Console.WriteLine($"Hero has same strength ({monster.Strength}) as Monster {monster.Name} - DRAW");
                            namelessHero.reduceAllWeaponsDuarabilty(1);
                        }
                        else
                        {
                            Console.WriteLine($"Hero is weaker by {Math.Abs(strengthDiff)} points than Monster {monster.Name} - HERO LOSES");
                            namelessHero.reduceAllWeaponsDuarabilty(1);
                            bool lostWeapon = namelessHero.loseRandomWeapon();

                            if (!lostWeapon)
                            {
                                Console.WriteLine("Hero loses coins instead of a weapon");
                                namelessHero.loseHalfCoins();
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Unkown Command");
                }

                Console.WriteLine($"Your Hero has {namelessHero.Coins} Coins and {namelessHero.Weapons.Count} Weapons!");
            }

            Console.WriteLine("Your Hero unforntaly died");
            Console.ReadKey();
        }

        static Weapon createWeapon(string strCommand)
        {
            string[] commandSlpit = strCommand.Split('+');

            return new Weapon(commandSlpit[0], Convert.ToInt32(commandSlpit[1]), Convert.ToInt32(commandSlpit[2]));
        }

        static Monster createMonster(string strCommand)
        {
            string[] commandSlpit = strCommand.Split('-');

            return new Monster(commandSlpit[0], Convert.ToInt32(commandSlpit[1]), Convert.ToInt32(commandSlpit[2]));
        }
    }
}
