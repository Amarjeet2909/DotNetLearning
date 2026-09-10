using CSharpCodingPrep.Interfaces;

public class RecordStructClassPracticeQuestion : IQuestion
{
    // Type 1: class (reference type, mutable)
    private class Customer
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    // Type 2: struct (value type, init-only properties here)
    private struct Location
    {
        public decimal Latitude { get; init; }
        public decimal Longitude { get; init; }
    }

    // Type 3: record (reference type by default, value-based equality)
    private record OrderSummary(string OrderId, string CustomerName, decimal Total);

    public void Run()
    {
        // ============================================
        // STEP 1: CLASS EQUALITY (should be False)
        // ============================================
        Customer customer1 = new Customer { Name = "Alice", Email = "alice@example.com" };
        Customer customer2 = new Customer { Name = "Alice", Email = "alice@example.com" };

        Console.WriteLine($"Class equality (expected False): {customer1 == customer2}");

        // STEP 2: CLASS MUTABILITY (allowed)
        customer1.Name = "Bob";
        Console.WriteLine($"Class mutability (expected Bob): {customer1.Name}");

        // ============================================
        // STEP 3: STRUCT EQUALITY (use .Equals, expected True)
        // ============================================
        Location location1 = new Location { Latitude = 40.7128m, Longitude = -74.0060m };
        Location location2 = new Location { Latitude = 40.7128m, Longitude = -74.0060m };

        Console.WriteLine($"Struct equality via Equals (expected True): {location1.Equals(location2)}");

        // STEP 4: STRUCT MUTABILITY TEST (not allowed with init-only after creation)
        // Uncomment to verify compile error:
        // location1.Latitude = 99m; // compile error
        Console.WriteLine("Struct init-only properties cannot be modified after initialization.");

        // ============================================
        // STEP 5: RECORD EQUALITY (should be True)
        // ============================================
        OrderSummary order1 = new OrderSummary("ORD001", "Alice", 100m);
        OrderSummary order2 = new OrderSummary("ORD001", "Alice", 100m);

        Console.WriteLine($"Record equality (expected True): {order1 == order2}");

        // STEP 6: RECORD NON-DESTRUCTIVE MUTATION with 'with'
        OrderSummary order3 = order1 with { Total = 150m };
        Console.WriteLine($"Original record total (expected 100): {order1.Total}");
        Console.WriteLine($"Copied record total (expected 150): {order3.Total}");

        // STEP 7: RECORD MUTABILITY TEST
        // NOTE: This positional record property is init-only by default.
        // Uncomment to verify compile error:
        // order1.Total = 200m; // compile error
        Console.WriteLine("Record positional properties are init-only by default.");
    }
}