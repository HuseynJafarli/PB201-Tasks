namespace EntityFramework_ManyToMany.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Model> Models { get; set; } = new List<Model>();
    }
}
