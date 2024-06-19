using WeaponTest.Business.Controller;
using WeaponTest.Business.Services.Implementations;
using WeaponTest.Business.Services.Interfaces;
using WeaponTest.Core.Models;
using WeaponTest.Data.DataBase;

namespace WeaponTest.CA
{
    public class Program
    {
        static void Main(string[] args)
        {
            IWeaponService weaponService = new WeaponService();
            Weapon selectedWeapon = null;
            MainMenu(weaponService, WeaponData.Weapons, ref selectedWeapon);
        }
        static void MainMenu(IWeaponService weaponService, List<Weapon> weapons, ref Weapon selectedWeapon)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("""
                    Main Menu:
                    1. Create Weapon
                    2. Select Weapon
                    3. Weapon Menu
                    4. Exit
                    """);
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Controller.Creator();
                        break;
                    case "2":
                        if (WeaponData.Weapons.Count == 0)
                        {
                            Console.WriteLine("Please create a weapon before selecting one!");
                            Console.WriteLine("Returning to menu...");
                            Thread.Sleep(1500);
                        }
                        else
                        {
                            selectedWeapon = Controller.SelectWeapon();
                            if (selectedWeapon == null)
                            {
                                Console.WriteLine("Selection failed. Press any key to return...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine($"Weapon {selectedWeapon.Id} selected successfully! Press any key to return...");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case "3":
                        if (selectedWeapon != null)
                        {
                            WeaponMenu(weaponService, selectedWeapon);
                        }
                        else
                        {
                            Console.WriteLine("No weapon selected. Please select a weapon first.");
                            Console.WriteLine("Returning to menu...");
                            Thread.Sleep(1500);
                        }
                        break;
                    case "4":
                        Console.WriteLine("Exited successfully!");
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice, try again!");
                        Console.WriteLine("Returning to menu...");
                        Thread.Sleep(1500);
                        break;
                }
            }
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
                            temp = Controller.MagSizeSetter();
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
                            if (tempAmmo == weapon.CurrentAmmo)
                            {
                                Console.WriteLine("Mag that you entered have the same size with the previous!");
                                break;
                            }
                            else if (tempAmmo > weapon.MagSize)
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
                        Console.Clear();
                        Console.WriteLine("Invalid choice , try again!");
                        Console.WriteLine("Returning to menu...");
                        Thread.Sleep(1500);
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
                        Console.Clear();
                        Console.WriteLine("Invalid choice , try again!");
                        Console.WriteLine("Returning to menu...");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }
    }
}
