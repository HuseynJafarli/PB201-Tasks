using WeaponTest.Core.Models;
using WeaponTest.Data.DataBase;

namespace WeaponTest.Business.Controller
{
    public static class Controller
    {
        public static void Creator()
        {
            Weapon weapon = new Weapon();
            Console.WriteLine("Welcome to the weapon tester!");
            Console.WriteLine("Please create an Ak!");

            ////setting name
            //Console.WriteLine("Enter weapon name:");
            //while (true)
            //{
            //    var temp = Console.ReadLine();
            //    if (!string.IsNullOrEmpty(temp))
            //    {
            //        weapon.Name = temp;
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Name can't be null or empty!");
            //        Console.WriteLine("Please enter a valid name:");
            //    }
            //}

            //setting magazine size
            weapon.MagSize = MagSizeSetter();
            //setting ammo count
            Console.WriteLine("Put some ammo:");
            while (weapon != null)
            {
                weapon.CurrentAmmo = EnterValidInt();
                if (weapon.CurrentAmmo >= 0 && weapon.CurrentAmmo <= weapon.MagSize)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Cant be negative or more than Mag Size");
                }
            }
            //setting fire mode
            Console.WriteLine("Select Fire mode (1 or 2):");
            Console.WriteLine("1.Auto");
            Console.WriteLine("2.Single");
            int fireMod;
            while (true)
            {
                fireMod = EnterValidInt();
                if (fireMod == 1)
                {
                    weapon.FireModeAuto = true;
                    break;
                }
                else if (fireMod == 2)
                {
                    weapon.FireModeAuto = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Please select valid option!");
                }
            }
            WeaponData.Weapons.Add(weapon);
            Console.WriteLine("Weapon created successfully!");
            Console.WriteLine("Returning to menu...");
            Thread.Sleep(1000);

        }
        public static Weapon SelectWeapon()
        {
            Console.WriteLine("Which weapon do you want to select?");
            WeaponData.Weapons.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Please select with integer Id:");
            int id = EnterValidInt();     
            return WeaponData.Weapons.Find(x => x.Id == id);
        }

        public static int EnterValidInt()
        {
            int number;
            bool isValidInput = false;

            do
            {
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out number))
                {
                    isValidInput = true;
                    return number;
                }
                else
                {
                    Console.WriteLine("That's not a valid integer. Please try again.");
                }
            } while (!isValidInput);
            return number;
        }
        public static int MagSizeSetter()
        {
            Console.WriteLine("Please select one of avalible Mags:");
            Console.WriteLine("""
                1.30
                2.35
                3.40
                """);
            while (true)
            {
                int chosenMag = EnterValidInt();
                if (chosenMag == 1)
                {
                    return 30;
                }
                else if (chosenMag == 2)
                {
                    return 35;
                }
                else if (chosenMag == 3)
                {
                    return 40;
                }
                else
                {
                    Console.WriteLine("Please select valid option!");
                }
            }

        }
    }
}
