namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] originalArr = { 1, 2, 3, 4, 5 };

            Console.WriteLine($"Original array length: {originalArr.Length}");

            int[] resizedArr = ArrayResize(originalArr, 7);

            Console.WriteLine($"Resized array length: {resizedArr.Length}");


            //Car car = new Car();
            //car.Brand = "Ford";
            //car.Model = "Mustang";
            //car.CurrentFuel = 60;
            //car.FuelPerKm = 0.2;
            //car.Drive(50);
            //car.Drive(100);
            //car.Drive(500);
        }
        public static int[] ArrayResize(int[] array, int newSize)
        {
            if (newSize < 0)
                Console.WriteLine("Error occured.");

            int[] newArray = new int[newSize];
            int existingElements;
            if (array.Length < newSize)
            
                existingElements = array.Length;
            
            else
                existingElements = newSize;

            for (int i = 0; i < existingElements; i++)
            
                newArray[i] = array[i];
            

            return newArray;
        }

    }
}
