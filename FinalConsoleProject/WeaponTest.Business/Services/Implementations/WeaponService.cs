using WeaponTest.Business.Services.Interfaces;
using WeaponTest.Core.Models;

namespace WeaponTest.Business.Services.Implementations
{
    public class WeaponService : IWeaponService
    {
        public void Shoot(Weapon weapon)
        {
            if (weapon.CurrentAmmo > 0)
            {
                weapon.CurrentAmmo -= 1;
                Console.WriteLine("pew!");
            }
            else
            {
                Console.WriteLine("Not enough ammo! Please reload");
            }
        }

        public void Fire(Weapon weapon)
        {
            if (!weapon.FireModeAuto)
            {
                Console.WriteLine("You cant spray with single mode!");
                return;
            }
            if (weapon.CurrentAmmo > 0)
            {
                weapon.CurrentAmmo = 0;
                Console.WriteLine("Ratatatata!");
            }
            else
            {
                Console.WriteLine("Not enough ammo! Please reload");
            }
        }

        public void ChangeFireMode(Weapon weapon)
        {
            if (weapon.FireModeAuto)
            {
                weapon.FireModeAuto = false;
                Console.WriteLine("Weapon fire mode changed to single");
            }
            else
            {
                weapon.FireModeAuto = true;
                Console.WriteLine("Weapon fire mode changed to auto");
            }
           
        }

        public int GetRemainBulletCount(Weapon weapon)
        {
            return weapon.CurrentAmmo;
        }

        public void Reload(Weapon weapon)
        {
            if (weapon.CurrentAmmo < weapon.MagSize) 
            {
                weapon.CurrentAmmo = weapon.MagSize;
                Console.WriteLine("Weapon reloaded!");
            }
            else
            {
                Console.WriteLine("Weapon ammo is already full!");
                return;
            }
        }

    }
}
