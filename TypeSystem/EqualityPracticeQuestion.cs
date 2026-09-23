using CSharpCodingPrep.Interfaces;

public class EqualityPracticeQuestion : IQuestion
{
    private class Person
    {
        public string Name { get; set; } = string.Empty;
    }

    private class PersonByValue
    {
        public string Name { get; set; } = string.Empty;

        public override bool Equals(object? obj)
            => obj is PersonByValue other && Name == other.Name;

        public override int GetHashCode() => Name.GetHashCode();
    }

    public void Run()
    {
        // TODO 1:
        // Create two strings with same text and print:
        // (a) ==, (b) .Equals, (c) ReferenceEquals

        // TODO 2:
        // Create two Person objects with same Name and print:
        // (a) ==, (b) .Equals, (c) ReferenceEquals

        // TODO 3:
        // Create two PersonByValue objects with same Name and print:
        // (a) ==, (b) .Equals, (c) ReferenceEquals

        // TODO 4:
        // Assign Person p3 = p1 and print all three checks between p1 and p3.

        // TODO 5:
        // Add one comment line explaining:
        // Why p1.Equals(p2) differs between Person and PersonByValue.
    }
}