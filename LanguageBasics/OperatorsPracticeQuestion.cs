using CSharpCodingPrep.Interfaces;

public class OperatorsPracticeQuestion : IQuestion
{
    public void Run()
    {
        // TODO 1: Declare two ints, 15 and 4. Print the result of integer division,
        //         then print the accurate decimal division (cast one operand).

        int num1 = 15;
        int num2 = 4;
        int resultIntDiv = num1 / num2;
        Console.WriteLine("Integer Division Result: " + resultIntDiv);
        double resultDecimalDiv = (double)num1 / num2;
        Console.WriteLine("Decimal Division Result: " + resultDecimalDiv);

        // TODO 2: Declare a nullable string set to null.
        //         Write an if-check using && short-circuit evaluation to safely check
        //         if it's not null AND its length is greater than 0.
        //         Print an appropriate message in both branches.

        string? nullableString = null;
        if (nullableString != null && nullableString.Length > 0)
        {
            Console.WriteLine("string is not null and Length > 0");
        }
        else
        {
            Console.WriteLine("string is null and length not > 0");
        }

        // TODO 3: Declare an int starting at 10.
        //         Print the result of using POST-increment (x++) in a Console.WriteLine,
        //         then print the variable again to show its updated value.
        //         Repeat with a separate variable using PRE-increment (++x).

        int num_1 = 10;
        Console.WriteLine($"Post Increment: {num_1++}");
        Console.WriteLine($"Current Value {num_1}");
        int num_2 = 20;
        Console.WriteLine($"Pre Incremnt: {++num_2}");


        // TODO 4: Declare a nullable string set to null.
        //         Use the null-coalescing operator (??) to assign a fallback value
        //         "Guest" to a new variable, and print it.
        string? str1 = null;
        string result = str1 ?? "Guest";
        Console.WriteLine($"String value: {result}");

        // TODO 5: Use the ternary operator to check if a number (try 17) is even or odd,
        //         storing the result in a string variable, then print it.
        //         (Hint: use the modulo operator % from earlier)
        string ternaryResult = (17 % 2 == 0) ? "17 is Even" : "17 is Odd";
        Console.WriteLine($"Result of Ternary Operation: {ternaryResult}");
    }
}