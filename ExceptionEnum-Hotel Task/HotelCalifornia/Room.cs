namespace HotelCalifornia
{
    public class Room
    {
        public static int count;

        public bool IsAvailable;
        public int Id { get; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int PersonCapacity { get; set; }

        public Room(string name , double price , int personCapacity)
        {
            IsAvailable = true;
            count++;
            Id = count;
            Name = name;
            Price = price;
            PersonCapacity = personCapacity;
        }

        
        public string ShowInfo()
        {
            string availability = IsAvailable ? "This room is available" : "This room is not available";
            return $"Room {Name}'s Id: {Id} , Price: {Price} , Person Capacity: {PersonCapacity} , {availability}";
      
        }

        public override string ToString()
        {
            return ShowInfo();
        }
    }
}
