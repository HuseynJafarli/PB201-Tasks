namespace WeaponTest.Core.Models
{
    public class Weapon
    {
        public string Name { get; set; }
        public int MagSize { get; set; }
        public int CurrentAmmo { get; set; }
        public bool FireModeAuto { get; set; }


        public override string ToString()
        {
            return $"Name: {Name}, Mag Size: {MagSize}, Current Ammo: {CurrentAmmo}, Fire Mode: {(FireModeAuto == true ? "Auto" : "Single")}";
        }

    }
}
