namespace ConsoleApp1
{
    public class Car
    {
        public string Brand;
        public string Model;
        public double CurrentFuel;
        public double FuelPerKm;
        public double Millage;

        public void Drive(int km)
        {
            double requiredFuel = km * FuelPerKm;

            if (CurrentFuel >= requiredFuel)
            {
                Millage += km;
                CurrentFuel -= requiredFuel;
                Console.WriteLine($"{Brand} {Model} have driven {km}km . Millage: {Millage}km. Remaining fuel: {CurrentFuel} liters.");
            }
            else
            {
                Console.WriteLine("Not enough fuel.");
            }
        }

    }
}
