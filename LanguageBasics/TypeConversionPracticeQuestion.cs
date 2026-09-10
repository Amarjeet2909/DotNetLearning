using CSharpCodingPrep.Interfaces;

public class TypeConversionPracticeQuestion : IQuestion
{
    public void Run()
    {
        // TODO 1: Declare a double with value 7.8. Cast it to int and print (observe truncation).
        //         Then use Convert.ToInt32 on the same value and print (observe rounding).
        double value1 = 7.8;
        int result1 = (int)value1;
        Console.WriteLine($"{result1}");
        int result2 = Convert.ToInt32(value1);
        Console.WriteLine($"{result2}");

        // TODO 2: Declare a string "256". Use int.Parse to convert it and print the result.
        string value2 = "256";
        int result3 = int.Parse(value2);
        Console.WriteLine($"{result3}");

        // TODO 3: Declare a string "not-a-number". Use int.TryParse to attempt conversion.
        //         Print whether it succeeded and the resulting value.
        string value3 = "not-a-number";
        bool result4 = int.TryParse(value3, out int result5);
        if (result4)
        {
            Console.WriteLine($"Converted successfully: {result5}");
        }
        else
        {
            Console.WriteLine($"Conversion failed (no exception thrown), default value: {result5}");
        }

        // TODO 4: Declare int.MaxValue. Add 1 to it normally (observe silent overflow) and print.
        //         Then wrap the same addition in a try/catch using 'checked()' and
        //         print a message when OverflowException is caught.
        int value6 = int.MaxValue;
        Console.WriteLine($"Observing silent overflow: {value6 + 1}");

        int result6 = 0;
        try
        {
            result6 = checked(value6 + 1);
        }
        catch(OverflowException)
        {
            Console.WriteLine("Overflow Exception occured");
        }
        Console.WriteLine($"Value after checked overflow (unassigned due to exception): {result6}");

        // TODO 5: Declare a double 15.5. Cast it directly to int (print truncation result).
        //         Then use (int)Math.Round(15.5) and print (observe proper rounding).
        double value7 = 15.5;
        int result7 = (int)value7;
        Console.WriteLine($"Direct cast (truncates): {result7}"); // 15

        int result8 = (int)Math.Round(value7);
        Console.WriteLine($"Math.Round then cast: {result8}"); // 16

        Console.WriteLine(Math.Round(15.5)); // 16
        Console.WriteLine(Math.Round(14.5)); // 14 (NOT 15! - banker's rounding)

        // To force standard "round half away from zero" rounding:
        Console.WriteLine(Math.Round(14.5, MidpointRounding.AwayFromZero)); // 15
    }
}