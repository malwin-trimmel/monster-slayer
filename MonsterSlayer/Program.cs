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

            Hero strangerHero = new Hero(heroGold);

            while (strangerHero.Coins > 0 || strangerHero.Weapons.Count > 0)
            {
                Console.WriteLine("Please enter your Command");
                string strCommand = Console.ReadLine();

                if (strCommand.Contains('+'))
                {
                    Weapon newWeapon = createWeapon(strCommand);

                    if (newWeapon != null)
                    {
                        strangerHero.AddWeapon(newWeapon);
                    }
                    
                }
                else
                {
                    Console.WriteLine("Unkown Command");
                }

                Console.WriteLine($"Your Hero has {strangerHero.Coins} Coins and {strangerHero.Weapons.Count} Weapons!");
            }

            Console.WriteLine("Your Hero unforntaly died");
            Console.ReadKey();
        }

        static Weapon createWeapon(string strCommand)
        {
            string[] commandSlpit = strCommand.Split('+');

            return new Weapon(commandSlpit[0], Convert.ToInt32(commandSlpit[1]), Convert.ToInt32(commandSlpit[2]));
        }
    }
}
