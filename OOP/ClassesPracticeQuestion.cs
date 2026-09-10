using CSharpCodingPrep.Interfaces;

public class ClassesPracticeQuestion : IQuestion
{
    // TODO 1: Define a private nested class 'Student' with fields for
    //         'Name' (string) and 'Marks' (int), a constructor that takes
    //         both as parameters, and a method 'AddMarks(int amount)' that
    //         increases Marks by the given amount.
    //         Expose Name and Marks as read-only properties (use '=>' syntax
    //         like the Car example).
    private class Student
    {
        private string _name;
        private int _marks;

        public Student(string name, int marks)
        {
            _name = name;
            _marks = marks;
        }

        public void AddMarks(int amount)
        {
            _marks += amount;
        }

        public string Name => _name;
        public int Marks => _marks;
    }

    public void Run()
    {
        // TODO 2: Create two Student objects with different names and initial marks.
        //         Call AddMarks on ONLY the first student.
        //         Print both students' Name and Marks BEFORE and AFTER the call,
        //         to prove the two objects are completely independent.
        Student S1 = new Student("Amarjeet", 90);
        Student S2 = new Student("Hari", 88);
        Console.WriteLine($"Marks Before Calling:- Student: {S1.Name} Marks: {S1.Marks} | Student: {S2.Name} Marks: {S2.Marks}");
        S1.AddMarks(10);
        Console.WriteLine($"Marks After Calling:- Student: {S1.Name} Marks: {S1.Marks} | Student: {S2.Name} Marks: {S2.Marks}");

    }
}