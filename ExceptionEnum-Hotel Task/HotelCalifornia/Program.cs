namespace HotelCalifornia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Room room1 = new("Room1" , 50 , 2);
            Room room2 = new("Room2", 100, 4);
            Hotel hotel = new("HotelCalifornia");
            hotel.AddRoom(room1);
            hotel.AddRoom(room2);
            Console.WriteLine(room1.ToString());
            hotel.MakeReservation(0);
            hotel.MakeReservation(1);
            Console.WriteLine(room1.ToString());
            Console.WriteLine(room2.ToString());

            try
            {
                hotel.MakeReservation(null);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NotAvailableException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                hotel.MakeReservation(1);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NotAvailableException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
