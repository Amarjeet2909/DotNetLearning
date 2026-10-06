using CSharpCodingPrep.Interfaces;

public class ArrayPracticeQuestion : IQuestion
{
    public void Run()
    {
        // ============================================================
        // TODO 1 — INDEXING AND LOOPING
        // ============================================================
        // Create an int array containing: 10, 20, 30, 40, 50.
        // Print its first element, last element, and Length.
        // Then use a FOR loop to print exactly:
        // Index 0: 10
        // Index 1: 20
        // Index 2: 30
        // Index 3: 40
        int[] array1 = { 10, 20, 30, 40, 50 };

        Console.WriteLine($"First: {array1[0]}");
        Console.WriteLine($"Last: {array1[array1.Length - 1]}");
        Console.WriteLine($"Length: {array1.Length}");

        for (int i = 0; i < array1.Length; i++)
        {
            Console.WriteLine($"Index {i}: {array1[i]}");
        }

        // ============================================================
        // TODO 2 — REFERENCE ASSIGNMENT
        // ============================================================
        // Create int[] firstArray containing: 1, 2, 3.
        // Create int[] secondArray = firstArray.
        // Set secondArray[0] = 99.
        // Print firstArray[0] and secondArray[0].
        // Expected: both print 99, because both variables reference one array.
        int[] firstArray = { 1, 2, 3 };
        int[] secondArray = firstArray;
        secondArray[0] = 99;
        Console.WriteLine(firstArray[0]);
        Console.WriteLine(secondArray[0]);

        // ============================================================
        // TODO 3 — INDEPENDENT ARRAY COPY
        // ============================================================
        // Create int[] original containing: 1, 2, 3.
        // Make a copy with: int[] copied = original[..];
        // Set copied[0] = 99.
        // Print original[0] and copied[0].
        // Expected: original prints 1; copied prints 99.
        int[] original = { 1, 2, 3 };
        int[] copied = original[..];
        copied[0] = 99;
        Console.WriteLine(original[0]);
        Console.WriteLine(copied[0]);

        // ============================================================
        // TODO 4 — SEARCH AND COMPLEXITY
        // ============================================================
        // Create int[] searchNumbers containing: 5, 10, 15, 20, 25.
        // Use foreach to search for target = 20.
        // Use a bool named found. Set it true and break when target is found.
        // Print: "Found target: True"
        // Add a comment explaining why an unsorted array search is O(n).
        int[] searchNumbers = { 5, 10, 15, 20, 25 };
        int target = 20;
        bool found = false;

        foreach (int number in searchNumbers)
        {
            if (number == target)
            {
                found = true;
                break;
            }
        }

        // Unsorted search is O(n) because the target may be absent or at the last index.
        Console.WriteLine($"Found target: {found}");

        // ============================================================
        // TODO 5 — RECTANGULAR ARRAY
        // ============================================================
        // Create a two-row, three-column rectangular array:
        // Row 0: 1, 2, 3
        // Row 1: 4, 5, 6
        // Print:
        // "Rows: 2"
        // "Columns: 3"
        // "Value at [1, 2]: 6"
        int[,] rectangularArray =
        {
            { 1, 2, 3 },
            { 4, 5, 6 }
        };

        Console.WriteLine($"Rows: {rectangularArray.GetLength(0)}");
        Console.WriteLine($"Columns: {rectangularArray.GetLength(1)}");
        Console.WriteLine($"Value at [1, 2]: {rectangularArray[1, 2]}");

        // ============================================================
        // TODO 6 — JAGGED ARRAY
        // ============================================================
        // Create a jagged array with three rows:
        // Row 0: 10, 20
        // Row 1: 30, 40, 50
        // Row 2: 60
        // Print:
        // "Row 0 length: 2"
        // "Row 1 last value: 50"
        // "Row 2 first value: 60"
        int[][] jaggedArray =
        [
            [10, 20],
            [30, 40, 50],
            [60]
        ];
        Console.WriteLine($"Row 0 length: {jaggedArray[0].Length}");
        Console.WriteLine($"Row 1 last value: {jaggedArray[1][jaggedArray[1].Length - 1]}");
        Console.WriteLine($"Row 2 first value: {jaggedArray[2][0]}");
    }
}