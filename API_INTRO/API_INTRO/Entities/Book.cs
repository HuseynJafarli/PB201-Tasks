using System.Text.RegularExpressions;

namespace API_INTRO.Entities
{
    public class Book: BaseEntity
    {
        public string Name { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

    }
}
