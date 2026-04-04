using System;

namespace OOPSPRB
{
    // 1. Interface → defines contract
    interface ICourse
    {
        void StartCourse();
    }

    // 2. Abstract class → common structure
    abstract class CourseFee
    {
        public abstract double GetFee();
    }

    // 3. Fee types
    class FreeCourse : CourseFee
    {
        public override double GetFee()
        {
            return 0;
        }
    }

    class PaidCourse : CourseFee
    {
        public override double GetFee()
        {
            return 500;
        }
    }

    // 4. Programming Course (HAS-A CourseFee)
    class ProgrammingCourse : ICourse
    {
        private string courseName;
        private CourseFee courseFee;

        public ProgrammingCourse(string name, CourseFee fee)
        {
            this.courseName = name;
            this.courseFee = fee;
        }

        public void StartCourse()
        {
            Console.WriteLine($"Programming Course: {courseName}");
            Console.WriteLine($"Course Fee: ₹{courseFee.GetFee()}");
        }
    }

    // 5. Design Course (HAS-A CourseFee)
    class DesignCourse : ICourse
    {
        private string courseName;
        private CourseFee courseFee;

        public DesignCourse(string name, CourseFee fee)
        {
            this.courseName = name;
            this.courseFee = fee;
        }

        public void StartCourse()
        {
            Console.WriteLine($"Design Course: {courseName}");
            Console.WriteLine($"Course Fee: ₹{courseFee.GetFee()}");
        }
    }

    // 6. Main
    class Program
    {
        static void Main(string[] args)
        {
            // Polymorphism
            CourseFee f1 = new FreeCourse();
            CourseFee f2 = new PaidCourse();

            ICourse c1 = new ProgrammingCourse("C#", f1);
            ICourse c2 = new DesignCourse("UI/UX", f2);

            c1.StartCourse();
            Console.WriteLine();

            c2.StartCourse();
        }
    }
}