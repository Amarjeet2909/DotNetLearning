using CSharpCodingPrep.Interfaces;

public class PolymorphismPracticeQuestion : IQuestion
{
    // TODO 1: Create a base class 'PaymentMethod' with:
    //         - a public virtual method Process(decimal amount) that prints
    //           "Processing payment of {amount}"
    //
    //         Create derived classes:
    //         - 'CreditCard' that overrides Process() to print base message first,
    //           then "Charging credit card with fees"
    //         - 'PayPal' that overrides Process() to print base message first,
    //           then "Processing via PayPal with 2% fee"
    //         - 'Bitcoin' that overrides Process() to print
    //           "Blockchain transaction initiated for {amount}" (NO base call - 
    //           completely different behavior)
    //
    //         Also create:
    //         - 'ApplePay' class that uses 'new' (NOT override) instead,
    //           printing "Apple Pay transaction (hidden method, not polymorphic)"
    class PaymentMethod
    {
        public virtual void Process(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount}");
        }
    }

    class CreditCard : PaymentMethod
    {
        public override void Process(decimal amount)
        {
            base.Process(amount);
            Console.WriteLine("Charging credit card with fees");
        }
    }

    class PayPal : PaymentMethod
    {
        public override void Process(decimal amount)
        {
            base.Process(amount);
            Console.WriteLine("Processing via PayPal with 2% fee");
        }
    }

    class BitCoin : PaymentMethod
    {
        public override void Process(decimal amount)
        {
            Console.WriteLine($"Blockchain transaction initiated for {amount}");
        }
    }

    class ApplePay : PaymentMethod
    {
        public new void Process(decimal amount)
        {
            Console.WriteLine($"Apple Pay transaction (hidden method, not polymorphic)");
        }
    }

    public void Run()
    {
        // TODO 2: Create an array of PaymentMethod[] with one of each type.
        //         Loop through and call Process(100) on each.
        //         Observe that:
        //         - CreditCard, PayPal, Bitcoin use polymorphic override (correct)
        //         - ApplePay uses hidden new method (so it prints base message
        //           when called through PaymentMethod type)
        //         Print a comment explaining why ApplePay's output is different.
        PaymentMethod[] paymentMethods = new PaymentMethod[]
        {
            new CreditCard(),
            new PayPal(),
            new BitCoin(),
            new ApplePay()
        };

        foreach(PaymentMethod method in paymentMethods)
        {
            method.Process(100);
        }
        Console.WriteLine("Note: ApplePay uses 'new' (method hiding), not 'override'.");
        Console.WriteLine("When called through PaymentMethod type, it uses the DECLARED type's Process(),");
        Console.WriteLine("not the ACTUAL type's. That's why ApplePay prints the base message.");
    }
}