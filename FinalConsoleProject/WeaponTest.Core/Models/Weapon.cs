namespace WeaponTest.Core.Models
{
    public class Weapon
    {
        private static int _count;
        public int Id { get; set; }
        public string Name { get; set; }
        public int MagSize { get; set; }
        public int CurrentAmmo { get; set; }
        public bool FireModeAuto { get; set; }

        public Weapon() 
        {
            _count++;
            Id = _count;
            Name = string.Concat("AK", Id.ToString());
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Mag Size: {MagSize}, Current Ammo: {CurrentAmmo}, Fire Mode: {(FireModeAuto == true ? "Auto" : "Single")}";
        }

    }
}
