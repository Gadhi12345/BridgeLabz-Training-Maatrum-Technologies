using System;

namespace OOPSPRAC1
{
    // 1. Interface → defines behavior
    interface IVehicle
    {
        void Start();
    }

    // 2. Abstract class → cost logic
    abstract class RentalCost
    {
        public abstract double CalculateCost();
    }

    // 3. Cost types
    class HourlyCost : RentalCost
    {
        public override double CalculateCost()
        {
            return 1000;
        }
    }

    class DailyCost : RentalCost
    {
        public override double CalculateCost()
        {
            return 3000;
        }
    }

    // 4. Vehicle class (HAS-A RentalCost)
    class Vehicle : IVehicle
    {
        private string brand;
        private int speed;
        private RentalCost cost;

        public Vehicle(string b, int s, RentalCost c)
        {
            brand = b;
            Speed = s;   // use property (validation)
            cost = c;
        }

        // Encapsulation with validation
        public int Speed
        {
            get { return speed; }
            set
            {
                if (value < 0)
                {
                    speed = 0;
                    Console.WriteLine("Speed cannot be negative");
                }
                else if (value > 200)
                {
                    speed = 200;
                    Console.WriteLine("Speed cannot exceed 200");
                }
                else
                {
                    speed = value;
                }
            }
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Vehicle: {brand}");
            Console.WriteLine($"Speed: {speed} km/h");
        }

        public void ShowCost()
        {
            Console.WriteLine($"Rental Cost: {cost.CalculateCost()}");
        }

        public virtual void Start()
        {
            Console.WriteLine($"{brand} vehicle is starting...");
        }
    }

    // 5. Electric Vehicle (inherits Vehicle)
    class ElectricVehicle : Vehicle
    {
        private int batteryCapacity;

        public ElectricVehicle(string b, RentalCost c, int s, int battery)
            : base(b, s, c)
        {
            batteryCapacity = battery;
        }

        public override void Start()
        {
            Console.WriteLine($"Electric Vehicle starting with battery capacity: {batteryCapacity} kWh");
        }
    }

    // 6. Bike (implements interface)
    class Bike : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Bike is starting using self/kick start");
        }
    }

    // 7. Main
    class Program
    {
        static void Main(string[] args)
        {
            RentalCost r1 = new DailyCost();
            RentalCost r2 = new HourlyCost();

            IVehicle v1 = new ElectricVehicle("Tesla", r1, 150, 75);
            v1.Start();

            Console.WriteLine();

            Vehicle v2 = new Vehicle("Honda", 120, r2);
            v2.Start();
            v2.ShowDetails();
            v2.ShowCost();

            Console.WriteLine();

            IVehicle v3 = new Bike();
            v3.Start();
        }
    }
}