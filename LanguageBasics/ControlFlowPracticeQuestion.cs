using CSharpCodingPrep.Interfaces;

public class ControlFlowPracticeQuestion : IQuestion
{
    public void Run()
    {
        // TODO 1: Write an if/else if/else chain that takes an int 'temperature' (try 30)
        //         and prints "Hot" if >= 30, "Warm" if >= 20, "Cold" otherwise.
        int temperature = 30;
        if(temperature >= 30)
        {
            Console.WriteLine("Hot");
        }
        else if(temperature >= 20)
        {
            Console.WriteLine("Warm");
        }
        else
        {
            Console.WriteLine("Cold");
        }

        // TODO 2: Rewrite TODO 1's logic using a switch EXPRESSION with relational patterns
        //         (>=, etc.), storing the result in a string and printing it.
        string result = temperature switch
        {
            >= 30 => "Hot",
            >= 20 => "Warm",
            _ => "Cold"
        };
        Console.WriteLine(result);

        // TODO 3: Use a 'for' loop to print all EVEN numbers from 1 to 20 (inclusive)
        //         using 'continue' to skip odd numbers.
        for (int i = 1; i <= 20; i++)
        {
            if (i % 2 != 0)
            {
                continue; // skip odd numbers
            }
            Console.WriteLine(i);
        }

        // TODO 4: Use a 'do-while' loop that starts a counter at 10 with a condition
        //         requiring counter < 5, and prove it still executes once by printing
        //         a message inside the loop body.
        int counter = 10; // ALREADY 10 before loop starts — condition (counter < 5) is false immediately
        do
        {
            Console.WriteLine($"Do-while executes at least once, counter = {counter}");
            counter++;
        } while (counter < 5); // false from the start, but body already ran once

        // TODO 5: Create a nested for loop (outer 0-2, inner 0-2). Inside the inner loop,
        //         use 'break' when the inner index equals 1, and print "i={i}, j={j}"
        //         before the break check. Observe that break only stops the inner loop.
        for (int i = 0; i <= 2; i++)
        {
            for (int j = 0; j <= 2; j++)
            {
                if (j == 1)
                {
                    break; // stop inner loop, check happens BEFORE printing
                }
                Console.WriteLine($"i={i}, j={j}"); // print happens for j=0 only, then breaks
            }
        }

    }
}