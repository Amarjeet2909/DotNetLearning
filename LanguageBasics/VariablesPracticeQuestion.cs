using CSharpCodingPrep.Interfaces;

public class VariablesPracticeQuestion : IQuestion
{
    public void Run()
    {
        // TODO 1: Declare a decimal variable named 'accountBalance' with value 1500.75 and print it.

        decimal accountBalance = 1500.75m;
        Console.WriteLine("Decimal Variable: Account Balance " + accountBalance);

        // TODO 2: Declare two double variables, add them (0.1 + 0.2), and print the result Observe the precision issue.

        double a = 0.1;
        double b = 0.2;
        Console.WriteLine("Adding Two DOuble Variable: " + (a + b));

        // TODO 3: Declare the same two values (0.1 and 0.2) as decimals and add them Print and compare with TODO 2's result.
        decimal c = 0.1m;
        decimal d = 0.2m;
        Console.WriteLine("Adding Two Decimal Values: " + (c + d));

        // TODO 4: Use 'var' to declare an int, a string, and a decimal. Print all three using string interpolation.
        var e = 1;
        var f = "Amarjeet";
        var g = 0.1m;
        Console.WriteLine($"Declared Following as var -> int: {e}, string: {f}, decimal: {g}");

        // TODO 5: Declare an int variable using 'default' and print it. Declare a string variable using 'default' and print it (observe null/empty output).
        int h = default;
        string? i = default;
        Console.WriteLine("int value declared using default keyword " + h);
        Console.WriteLine("string value declared using default keyword " + i);

        // NOTE: Writing like $"" is called string interpolation. It allows you to embed variables directly in the string using {}. It's more readable than concatenation with + and it's a modern C# practice
        // Always use string? if the value can be null instead of just string to avoid nullability warnings in C# 8.0 and later. ith Nullable Reference Types enabled, 'string' means
        // "never null" to the compiler.
    }
}