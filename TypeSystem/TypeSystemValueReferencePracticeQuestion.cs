using CSharpCodingPrep.Interfaces;

public class TypeSystemValueReferencePracticeQuestion : IQuestion
{
    private class Box
    {
        public int Value { get; set; }
    }

    public void Run()
    {
        // TODO 1: Value type assignment copy
        // - Create int a = 10, int b = a
        // - Set b = 99
        // - Print a and b (a should remain 10)
        int a = 10;
        int b = a;
        b = 99;
        Console.WriteLine(a);
        Console.WriteLine(b);

        // TODO 2: Reference type assignment copy of reference
        // - Create Box box1 = new Box { Value = 10 }
        // - Create Box box2 = box1
        // - Set box2.Value = 99
        // - Print box1.Value and box2.Value (both should be 99)
        Box box1 = new Box();
        box1.Value = 10;
        Box box2 = box1;
        box2.Value = 99;
        Console.WriteLine(box1.Value);
        Console.WriteLine(box2.Value);

        // TODO 3: Method call with value type
        // - Create int n = 5
        // - Call ChangeInt(n)
        // - Print n (should remain 5)
        int n = 5;
        ChangeInt(n);
        Console.WriteLine(n);

        // TODO 4: Method call with reference type
        // - Create Box box = new Box { Value = 7 }
        // - Call ChangeBox(box)
        // - Print box.Value (should become 777)
        Box box = new Box();
        box.Value = 7;
        ChangeBox(box);
        Console.WriteLine(box.Value);

        // TODO 5: String immutability demo
        // - Create s1 = "hello", s2 = s1
        // - Set s2 += " world"
        // - Print s1 and s2 (s1 unchanged)
        string s1 = "hello";
        string s2 = s1;
        s2 += " world";
        Console.WriteLine(s1);
        Console.WriteLine(s2);
    }

    private static void ChangeInt(int x)
    {
        x = 999;
    }

    private static void ChangeBox(Box b)
    {
        b.Value = 777;
    }
}