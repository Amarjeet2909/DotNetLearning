using CSharpCodingPrep.Interfaces;

public class NullableTypesPracticeQuestion : IQuestion
{
    public void Run()
    {
        // TODO 1:
        // Create int? score = null
        // Print score.HasValue and score.GetValueOrDefault()
        int? score = null;
        Console.WriteLine(score.HasValue);
        Console.WriteLine(score.GetValueOrDefault());

        // TODO 2:
        // Assign score = 95
        // Print score.HasValue and score.Value
        score = 95;
        Console.WriteLine(score.HasValue);
        Console.WriteLine(score.Value);

        // TODO 3:
        // Create string? name = null
        // Safely print name length using ?. and ?? (should print 0)
        string? name = null;


        // TODO 4:
        // Create string? city = null
        // Use ??= to assign "Bengaluru" only if null
        // Print city

        // TODO 5:
        // Create a helper method:
        // static int SafeLength(string? input) => input?.Length ?? 0;
        // Call it with null and "hello", print both outputs
    }
}