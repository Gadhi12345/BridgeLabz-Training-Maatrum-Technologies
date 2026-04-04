using System;

namespace OOPS
{
    // 1. Interface → defines rule
    interface IRide
    {
        void BookRide();
    }

    // 2. Abstract class → defines common structure
    abstract class Fare
    {
        public abstract double CalculateFare();
    }

    // 3. Fare types (different implementations)
    class NormalFare : Fare
    {
        public override double CalculateFare()
        {
            return 300;
        }
    }

    class PremiumFare : Fare
    {
        public override double CalculateFare()
        {
            return 500;
        }
    }

    // 4. BikeRide class (implements interface)
    class BikeRide : IRide
    {
        private string brand;
        private Fare fare;   // HAS-A Fare

        // Constructor
        public BikeRide(string b, Fare f)
        {
            brand = b;
            fare = f;
        }

        public void BookRide()
        {
            Console.WriteLine($"Bike Ride booked for {brand}");
            Console.WriteLine($"Total Fare: ₹{fare.CalculateFare()}");
        }
    }

    // 5. CarRide class (separate class)
    class CarRide : IRide
    {
        private string brand;
        private Fare fare;   // HAS-A Fare

        public CarRide(string b, Fare f)
        {
            brand = b;
            fare = f;
        }

        public void BookRide()
        {
            Console.WriteLine($"Car Ride booked for {brand}");
            Console.WriteLine($"Total Fare: ₹{fare.CalculateFare()}");
        }
    }

    // 6. Main class
    class Program
    {
        static void Main(string[] args)
        {
            // Creating fare objects (polymorphism)
            Fare f1 = new NormalFare();
            Fare f2 = new PremiumFare();

            // Creating ride objects
            IRide r1 = new BikeRide("Adarsh", f1);
            IRide r2 = new CarRide("Rahul", f2);

            // Calling methods
            r1.BookRide();
            Console.WriteLine();

            r2.BookRide();
        }
    }
}