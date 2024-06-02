namespace HotelCalifornia
{ 
    internal class Car
    {
        private static int count;
        public int Id { get; }
        public string Brand { get; private set; }
        public string Model { get; private set; }

        public Enum Type { get; private set; }
        public Car(string brand, string model , Enum type)
        {
            Brand = brand;
            Model = model;
            Type = type;
            count++;
            Id = count;
        }

        public override string ToString()
        {
            return $"Car Id: {Id} , {Brand} {Model} {Type}";
        }
    }
}
