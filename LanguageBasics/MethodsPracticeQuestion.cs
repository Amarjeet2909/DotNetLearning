using CSharpCodingPrep.Interfaces;

public class MethodsPracticeQuestion : IQuestion
{
    public class BankAccount
    {
        public int Balance = 0;
    }

    public void Run()
    {
        // TODO 1: Write a method 'SwapValues' using 'ref' parameters that swaps
        //         two int variables. Call it with values 10 and 20, and print
        //         both variables before and after the call to prove the swap worked.
        int var1 = 10;
        int var2 = 20;

        void SwapValues(ref int num1, ref int num2)
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }

        Console.WriteLine($"Values before swap var1: {var1}, var2: {var2}");
        SwapValues(ref var1, ref var2);
        Console.WriteLine($"Values after swap var1: {var1}, var2: {var2}");

        // TODO 2: Write a method 'TryGetSquareRoot' that takes a double and an
        //         'out double result' parameter. It should return false (and set
        //         result to 0) if the input is negative, otherwise return true
        //         and set result to Math.Sqrt(input). Test it with both a valid
        //         input (16) and an invalid input (-4), printing appropriate messages.
        double validInput = 16;
        double invalidInput = -4;

        bool tryGetSquareRoot(double input, out double squareRoot)
        {
            if(input < 0)
            {
                squareRoot = 0;
                return false;
            }
            squareRoot = Math.Sqrt(input);
            return true;

        }
        double result;
        bool validResult = tryGetSquareRoot(validInput, out result);
        Console.WriteLine($"Calling tryGetSquareRoot with input: {validInput}:- Returns: {validResult}, SquareRoot: {result}");
        bool invalidResult = tryGetSquareRoot(invalidInput, out result);
        Console.WriteLine($"Calling tryGetSquareRoot with invalid input: {invalidInput}:- Returns: {invalidResult}, SquareRoot: {result}");

        // TODO 3: Write a method 'PrintTotal' using 'params int[]' that accepts
        //         any number of integers and prints their sum. Call it three times:
        //         with 2 numbers, with 5 numbers, and with zero arguments.
        void PrintTotal(params int[] input)
        {
            int sum = 0;
            foreach (int number in input) // rename for clarity - this IS the value already
            {
                sum += number; // just add the value directly
            }
            Console.WriteLine($"Sum of given numbers is: {sum}");
        }
        PrintTotal();
        PrintTotal(3, 4);
        PrintTotal(2, 3, 5);

        // TODO 4: Create a small class 'BankAccount' with a public int 'Balance' field.
        //         Write a method 'Deposit' that takes a BankAccount object (no ref/out)
        //         and adds 100 to its Balance field. Call it and prove that the
        //         original object's Balance changed (demonstrating the reference-type
        //         pass-by-value nuance).
        void Deposit(BankAccount account)
        {
            account.Balance += 100;
        }
        BankAccount account = new BankAccount();
        Console.WriteLine($"Balance before: {account.Balance}");
        Deposit(account);
        Console.WriteLine($"Balance after: {account.Balance}");

    }
}