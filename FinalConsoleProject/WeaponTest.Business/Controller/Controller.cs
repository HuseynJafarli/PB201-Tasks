using WeaponTest.Core.Models;

namespace WeaponTest.Business.Controller
{
    public static class Controller
    {
        public static void Creator(Weapon weapon)
        {
            Console.WriteLine("Welcome to the weapon tester!");
            Console.WriteLine("Please create a weapon!");
            Console.WriteLine("Enter weapon name:");
            while (true)
            {
                var temp = Console.ReadLine();
                if (!string.IsNullOrEmpty(temp))
                {
                    weapon.Name = temp;
                    break;
                }
                else
                {
                    Console.WriteLine("Name can't be null or empty!");
                    Console.WriteLine("Please enter a valid name:");
                }
            }
            Console.WriteLine("Enter weapon Mag Size:");
            weapon.MagSize = EnterValidInt();
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
            Console.WriteLine("Select Fire mode (1 or 2):");
            Console.WriteLine("1.Auto");
            Console.WriteLine("2.Single");
            var fireMod = EnterValidInt();
            while (true)
            {
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
                    fireMod = EnterValidInt();
                }
            }

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
    }
}
