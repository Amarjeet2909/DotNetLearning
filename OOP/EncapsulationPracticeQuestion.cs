using CSharpCodingPrep.Interfaces;

public class EncapsulationPracticeQuestion : IQuestion
{
    // TODO 1: Define a private nested class 'Product' with:
    //         - a private field '_price' (decimal)
    //         - a public auto-property 'Name' (get; private set;) (string)
    //         - a public property 'Price' with custom get/set: the 'set' must
    //           THROW an ArgumentException if the assigned value is <= 0
    //         - a constructor(string name, decimal price) that sets both
    //           (Name via the auto-property, Price via the validated property)
    //         - a method 'ApplyDiscount(decimal percentage)' that reduces Price
    //           by that percentage (e.g., 10 means reduce by 10%) - should also
    //           go through the property (not the private field directly)
    private class Product
    {
        private decimal _price;
        public string Name { get; private set; }
        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("The Price is less than equal to zero");
                }
                _price = value;
            }
        }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void ApplyDiscount(decimal percentage)
        {
            decimal reducedPrice = Price - ((Price * percentage) / 100);
            Price = reducedPrice;
        }
    }

    public void Run()
    {
        // TODO 2: Create a Product with a valid price. Print its Name and Price.
        //         Call ApplyDiscount(20) and print the new Price.
        //         Then, in a try/catch, attempt to create a SECOND Product with
        //         a price of -50, and print the caught exception's message.
        Product product1 = new Product("Book", 100);
        Console.WriteLine($"Name: {product1.Name} Price: {product1.Price}");
        product1.ApplyDiscount(20);
        Console.WriteLine($"New Price: {product1.Price}");

        try
        {
            Product product2 = new Product("Pen", -50);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}