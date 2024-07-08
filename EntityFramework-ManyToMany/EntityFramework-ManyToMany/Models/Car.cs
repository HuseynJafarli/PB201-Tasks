namespace EntityFramework_ManyToMany.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int MaxSpeed { get; set; }
        public int FuelTankCapacity { get; set; }
        public int Power { get; set; }
        public int DoorCount { get; set; }

        public int ModelId { get; set; }
        public Model Model { get; set; }

        public List<CarColor> CarColors { get; set; } = new List<CarColor>();
    }
}
