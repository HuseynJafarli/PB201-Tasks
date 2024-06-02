namespace HotelCalifornia
{
    public class Hotel
    {
        private Room[] rooms = [];
        public string Name { get; }

        public Hotel(string name)
        {
            Name = name;
        }
        public void AddRoom(Room room)
        {
            Array.Resize(ref rooms, rooms.Length + 1);
            rooms[rooms.Length - 1] = room;
            Console.WriteLine($"Room {room.Id} was added to our hotel\n");
        }

        public void MakeReservation(int? roomId)
        {
            if (roomId == null)
            {
                throw new NullReferenceException("Id cannot be null");
            }

            if (roomId >= 0 && roomId < rooms.Length)
            {
                if (rooms[roomId.Value].IsAvailable)
                {
                    rooms[roomId.Value].IsAvailable = false;
                    Console.WriteLine($"You just booked the room with name {rooms[roomId.Value].Name}!");
                }
                else
                {
                    throw new NotAvailableException($"{rooms[roomId.Value].Name} is not available");
                }
            }
            else
            {
                Console.WriteLine("Room Id is out of boundries");
            }
        }
    }
}
