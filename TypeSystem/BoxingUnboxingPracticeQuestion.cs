using CSharpCodingPrep.Interfaces;
using System.Collections;

public class BoxingUnboxingPracticeQuestion : IQuestion
{
    public void Run()
    {
        // TODO 1:
        // Create int n = 42
        // Box it into object boxed
        // Unbox back to int and print all values
        int n = 42;
        object box1 = n;
        int unbox = (int)box1;
        Console.WriteLine(n);
        Console.WriteLine(box1);
        Console.WriteLine(unbox);

        // TODO 2:
        // Create object boxedInt = 100
        // Correctly unbox to int first, then assign to long
        // Print the final long value
        object boxedInt = 100;
        int unboxInt = (int)boxedInt;
        long unboxLong = (long)unboxInt;
        Console.WriteLine(unboxLong);

        // TODO 3:
        // Demonstrate invalid unboxing in try/catch:
        // object boxedValue = 10;
        // try casting directly to long -> catch InvalidCastException and print message
        object boxedValue = 10;
        try
        {
            long tryUnbox = (long)boxedValue;
        }
        catch(InvalidCastException ex)
        {
            Console.WriteLine(ex.Message);
        }

        // TODO 4:
        // Use ArrayList (non-generic) and add 3 ints
        // Read them back as ints and print sum
        // (This demonstrates boxing/unboxing in old collections)
        ArrayList arrayList = new ArrayList() { 1, 2, 3};
        int sum1 = 0;
        foreach (int num1 in arrayList)
        {
            sum1 += num1;
        }
        Console.WriteLine(sum1);

        // TODO 5:
        // Use List<int> with same values and print sum
        // Add a comment: this avoids boxing for int elements
        List<int> num2 = new List<int>() { 1, 2, 3 };
        int sum2 = 0;
        foreach(int i in num2)
        {
            sum2 += i;
        }
        Console.WriteLine(sum2);

    }
}