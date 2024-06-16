using WeaponTest.Business.Controller;
using WeaponTest.Business.Services.Implementations;
using WeaponTest.Business.Services.Interfaces;
using WeaponTest.Core.Models;

namespace WeaponTest.CA
{
    public class Program
    {
        static void Main(string[] args)
        {
            IWeaponService weaponService = new WeaponService();
            Weapon weapon = new Weapon();
            Controller.Creator(weapon);
            WeaponMenu(weaponService, weapon);
        }

        static void EditMenu(IWeaponService weaponService, Weapon weapon)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Edit menu!");

            while (true)
            {
                Console.WriteLine("""
                    1.Change Mag size
                    2.Change Ammo count
                    3.Go back to Weapon Menu
                    """);
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        int temp;
                        while (true)
                        {
                            Console.WriteLine("Please enter new mag size:");
                            temp = Controller.EnterValidInt();
                            if (temp < weapon.CurrentAmmo)
                            {
                                Console.WriteLine("Your cant fit all ammos to this mag!");
                                break;
                            }
                            else if (temp == weapon.MagSize)
                            {
                                Console.WriteLine("Mag that you entered have the same size with the previous!");
                                break;
                            }
                            else
                            {
                                weapon.MagSize = temp;
                                Console.WriteLine("Mag size changed successfully!");
                                break;
                            }
                        }
                        Console.WriteLine("Press any key to return to edit menu...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        int tempAmmo;
                        while (true)
                        {
                            Console.WriteLine("Please change the ammo count:");
                            tempAmmo = Controller.EnterValidInt();
                            if(tempAmmo == weapon.CurrentAmmo)
                            {
                                Console.WriteLine("Mag that you entered have the same size with the previous!");
                                break;
                            }
                            else if(tempAmmo > weapon.MagSize)
                            {
                                Console.WriteLine("Ammo count cant be more than mag size!");
                                break;
                            }
                            else
                            {
                                weapon.CurrentAmmo = tempAmmo;
                                Console.WriteLine("Ammo count changed successfully!");
                                break;
                            }
                        }
                        Console.WriteLine("Press any key to return to edit menu...");
                        Console.ReadKey();  
                        break;
                    case "3":
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid choice , try again!");
                        break;
                }
            }
        }

        static void WeaponMenu(IWeaponService weaponService, Weapon weapon)
        {
            bool exit = false;

            Console.WriteLine("Welcome to Weapon Menu!");
            while (!exit)
            {
                Console.WriteLine(
                    """
                0 - Get Info
                1 - Shoot 
                2 - Spray
                3 - Get Ammo
                4 - Reload
                5 - Change Fire Mode
                6 - Exit
                7 - Edit Weapon Features
                """
                    );
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        Console.Clear();
                        Console.WriteLine(weapon.ToString());
                        Console.WriteLine("Press any key to return to weapon menu...");
                        Console.ReadKey();
                        break;
                    case "1":
                        Console.Clear();
                        weaponService.Shoot(weapon);
                        Console.WriteLine("Press any key to return to weapon menu...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        weaponService.Fire(weapon);
                        Console.WriteLine("Press any key to return to weapon menu...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine($"You have {weaponService.GetRemainBulletCount(weapon)} ammo left!");
                        Console.WriteLine("Press any key to return to weapon menu...");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        weaponService.Reload(weapon);
                        Console.WriteLine("Press any key to return to weapon menu...");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        weaponService.ChangeFireMode(weapon);
                        Console.WriteLine("Press any key to return to weapon menu...");
                        Console.ReadKey();
                        break;
                    case "6":
                        Console.WriteLine("Exited successfully!");
                        exit = true;
                        break;
                    case "7":
                        EditMenu(weaponService, weapon);
                        break;
                    default:
                        Console.WriteLine("Invalid choice , try again!");
                        break;
                }
            }
        }
    }
}
