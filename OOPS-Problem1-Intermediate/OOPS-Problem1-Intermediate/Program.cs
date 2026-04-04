using System;

namespace OOPS3
{
    // 1. Interface → defines contract
    interface IPayment
    {
        void MakePayment();
    }

    // 2. Abstract class → payment processing logic
    abstract class PaymentGateway
    {
        public abstract double ProcessPayment();
    }

    // 3. Gateway types
    class UPIGateway : PaymentGateway
    {
        public override double ProcessPayment()
        {
            return 1000;
        }
    }

    class CardGateway : PaymentGateway
    {
        public override double ProcessPayment()
        {
            return 2000;
        }
    }

    // 4. Order class (HAS-A PaymentGateway)
    class Order : IPayment
    {
        protected string orderName;
        protected PaymentGateway gateway;

        public Order(string name, PaymentGateway g)
        {
            orderName = name;
            gateway = g;
        }

        public virtual void MakePayment()
        {
            Console.WriteLine($"Order: {orderName}");
            Console.WriteLine($"Payment Amount: {gateway.ProcessPayment()}");
        }
    }

    // 5. PremiumOrder (inherits Order)
    class PremiumOrder : Order
    {
        private bool isPriority;

        public PremiumOrder(string name, PaymentGateway g, bool priority)
            : base(name, g)
        {
            isPriority = priority;
        }

        public override void MakePayment()
        {
            Console.WriteLine("Premium Order Processing");
            Console.WriteLine($"Priority Delivery: {isPriority}");

            base.MakePayment(); // reuse parent logic
        }
    }

    // 6. Main
    class Program
    {
        static void Main(string[] args)
        {
            PaymentGateway g1 = new UPIGateway();
            PaymentGateway g2 = new CardGateway();

            IPayment o1 = new Order("Shoes", g1);
            IPayment o2 = new PremiumOrder("Laptop", g2, true);

            o1.MakePayment();
            Console.WriteLine();

            o2.MakePayment();
        }
    }
}