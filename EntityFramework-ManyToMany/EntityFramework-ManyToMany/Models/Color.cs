namespace EntityFramework_ManyToMany.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CarColor> CarColors { get; set; } = new List<CarColor>();

    }
}
