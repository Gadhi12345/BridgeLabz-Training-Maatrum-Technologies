using System;

interface IMember
{
    void ShowMemberDetails();
}

// Abstract Class
public abstract class MembershipFee
{
    public abstract double CalculateFee(double duration);
}

// Fee Types
public class MonthlyPlan : MembershipFee
{
    public override double CalculateFee(double duration)
    {
        return duration * 1000;
    }
}

public class YearlyPlan : MembershipFee
{
    public override double CalculateFee(double duration)
    {
        return duration * 8000;
    }
}

// Base Class
public class Member
{
    private int memberId;
    private string memberName;
    private double duration;
    protected MembershipFee fee;

    // Encapsulation
    public double Duration
    {
        get { return duration; }
        set
        {
            if (value > 0)
                duration = value;
            else
                Console.WriteLine("Invalid duration");
        }
    }

    public Member(int id, string name, double dur, MembershipFee f)
    {
        memberId = id;
        memberName = name;
        Duration = dur;
        fee = f;
    }

    public void ShowDetails()
    {
        Console.WriteLine($"ID: {memberId}");
        Console.WriteLine($"Name: {memberName}");
        Console.WriteLine($"Duration: {duration}");
    }

    public void ShowTotalFee()
    {
        Console.WriteLine($"Total Fee: {fee.CalculateFee(duration)}");
    }

    public virtual void ShowMemberDetails()
    {
        Console.WriteLine("Member Details");
    }
}

// Derived Class
public class PremiumMember : Member, IMember
{
    private string trainerName;

    public PremiumMember(int id, string name, double dur, MembershipFee f, string trainer)
        : base(id, name, dur, f)
    {
        trainerName = trainer;
    }

    public override void ShowMemberDetails()
    {
        Console.WriteLine("Premium Member");
        Console.WriteLine($"Trainer: {trainerName}");
        base.ShowMemberDetails();
        ShowDetails();
        ShowTotalFee();
    }
}

// Separate Class (only interface)
public class BasicMember : IMember
{
    private string planType;

    public BasicMember(string type)
    {
        planType = type;
    }

    public void ShowMemberDetails()
    {
        Console.WriteLine("Basic Member");
        Console.WriteLine($"Plan: {planType}");
    }
}

// Main
class Program
{
    static void Main()
    {
        MembershipFee fee = new MonthlyPlan();

        IMember premium = new PremiumMember(1, "Adarsh", 6, fee, "John");
        premium.ShowMemberDetails();

        IMember basic = new BasicMember("Standard");
        basic.ShowMemberDetails();
    }
}