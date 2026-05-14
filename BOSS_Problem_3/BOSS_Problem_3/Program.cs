using System;

interface IParking
{
    void ShowParkingDetails();
}

public abstract class Fee
{
    public abstract double CalculateFee(int hours);
}

public class HourlyFee : Fee
{
    public override double CalculateFee(int hours)
    {
        return hours * 50;
    }
}

public class FreeParking : Fee
{
    public override double CalculateFee(int hours)
    {
        return 0;
    }
}

public class Vehicle
{
    private int vehicleNumber;
    private int hoursParked;
    protected Fee fee;

    public int HoursParked
    {
        get { return hoursParked; }
        set
        {
            if (value > 0)
                hoursParked = value;
            else
                Console.WriteLine("Minimum 1 hour required");
        }
    }

    public Vehicle(int num, int hrs, Fee f)
    {
        vehicleNumber = num;
        HoursParked = hrs;
        fee = f;
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Vehicle No: {vehicleNumber}");
        Console.WriteLine($"Hours: {hoursParked}");
    }

    public void ShowTotalFee()
    {
        Console.WriteLine($"Fee: {fee.CalculateFee(hoursParked)}");
    }

    public virtual void ShowParkingDetails()
    {
        Console.WriteLine("Vehicle Parking Details");
    }
}

public class Car : Vehicle, IParking
{
    private string carType;

    public Car(int num, int hrs, Fee f, string type) : base(num, hrs, f)
    {
        carType = type;
    }

    public override void ShowParkingDetails()
    {
        Console.WriteLine("Car Parking");
        Console.WriteLine($"Type: {carType}");
        base.ShowParkingDetails();
        ShowDetails();
        ShowTotalFee();
    }
}

public class Bike : IParking
{
    private string brand;

    public Bike(string b)
    {
        brand = b;
    }

    public void ShowParkingDetails()
    {
        Console.WriteLine("Bike Parking");
        Console.WriteLine($"Brand: {brand}");
    }
}

class Program
{
    static void Main()
    {
        Fee f = new HourlyFee();

        IParking car = new Car(1234, 3, f, "SUV");
        car.ShowParkingDetails();

        IParking bike = new Bike("Yamaha");
        bike.ShowParkingDetails();
    }
}
