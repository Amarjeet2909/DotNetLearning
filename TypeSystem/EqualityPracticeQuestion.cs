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
        string string1 = "Amarjeet";
        string string2 = "Amarjeet";
        Console.WriteLine(string1 ==  string2);
        Console.WriteLine(string1.Equals(string2));
        Console.WriteLine(ReferenceEquals(string1, string2));

        // TODO 2:
        // Create two Person objects with same Name and print:
        // (a) ==, (b) .Equals, (c) ReferenceEquals
        Person person1 = new Person();
        person1.Name = "Amarjeet";
        Person person2 = new Person();
        person2.Name = "Amarjeet";
        Console.WriteLine(person1 == person2);
        Console.WriteLine(person1.Equals(person2));
        Console.WriteLine(ReferenceEquals(person1, person2));

        // TODO 3:
        // Create two PersonByValue objects with same Name and print:
        // (a) ==, (b) .Equals, (c) ReferenceEquals
        PersonByValue personByValue1 = new PersonByValue();
        PersonByValue personByValue2 = new PersonByValue();
        personByValue1.Name = "Amarjeet";
        personByValue2.Name = "Amarjeet";
        Console.WriteLine(personByValue1 == personByValue2);
        Console.WriteLine(personByValue1.Equals(personByValue2));
        Console.WriteLine(ReferenceEquals(personByValue1, personByValue2));

        // TODO 4:
        // Assign Person p3 = p1 and print all three checks between p1 and p3.
        Person person3 = person1;
        Console.WriteLine(person3 == person1);
        Console.WriteLine(person3.Equals(person1));
        Console.WriteLine(ReferenceEquals(person3, person1));

        // TODO 5:
        // Add one comment line explaining:
        // Why p1.Equals(p2) differs between Person and PersonByValue.

        // Person does not override Equals(), so it inherits object.Equals(),
        // which compares object references.
        //
        // PersonByValue overrides Equals() and compares the Name property values.
        // Therefore, two different PersonByValue objects with the same Name are equal.
    }
}