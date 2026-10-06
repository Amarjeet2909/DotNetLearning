using CSharpCodingPrep.Interfaces;

public class CoreCollectionsPracticeQuestion : IQuestion
{
    public void Run()
    {
        // ============================================================
        // TODO 1 — LIST<T>
        // ============================================================
        // Create List<string> named tasks with:
        // "Learn C#", "Practice Arrays", "Review OOP"
        //
        // Add "Learn Collections".
        // Remove "Practice Arrays".
        // Print exactly:
        // Task count: 3
        // First task: Learn C#
        // Then print every remaining task using foreach.
        List<string> tasks =
        [
            "Learn C#",
            "Practice Arrays",
            "Review OOP"
        ];
        tasks.Add("Learn Collections");
        tasks.Remove("Practice Arrays");
        Console.WriteLine($"Task count: {tasks.Count}");
        Console.WriteLine($"First task: {tasks[0]}");
        foreach(string task in tasks)
        {
            Console.WriteLine(task);
        }

        // ============================================================
        // TODO 2 — DICTIONARY<TKey, TValue>
        // ============================================================
        // Create Dictionary<int, string> named employees:
        // 101 -> "Amarjeet"
        // 102 -> "Hari"
        // 103 -> "Priya"
        //
        // Safely find employee ID 102 with TryGetValue.
        // Print: Employee 102: Hari
        //
        // Safely try ID 999 with TryGetValue.
        // Print: Employee 999 was not found.
        //
        // Add a comment: dictionary lookup by key is O(1) on average.
        Dictionary<int, string> employees = new()
        {
            {101, "Amarjeet"},
            {102, "Hari"},
            {103, "Priya"}
        };
        employees.TryGetValue(102, out string? name1);
        Console.WriteLine($"Employee 102: {name1}");
        if(employees.TryGetValue(999, out string? name2))
        {
            Console.WriteLine($"Employee 999: {name2}");
        }
        else
        {
            Console.WriteLine($"Employee 999 was not found.");
        }
        // dictionary lookup by key is O(1) on average.

        // ============================================================
        // TODO 3 — HASHSET<T>
        // ============================================================
        // Create HashSet<string> named skills.
        // Add: "C#", ".NET", "SQL", "C#" (duplicate).
        //
        // Store the result of the second "C#" Add call in bool wasDuplicateAdded.
        // Print:
        // C# duplicate added: False
        // Has SQL: True
        // Skill count: 3
        HashSet<string> skills = new();
        skills.Add("C#");
        skills.Add(".NET");
        skills.Add("SQL");
        bool wasDuplicateAdded = skills.Add("C#");
        Console.WriteLine($"C# duplicate added: {wasDuplicateAdded}");
        Console.WriteLine($"Has SQL: {skills.Contains("SQL")}");
        Console.WriteLine($"Skill count: {skills.Count}");

        // ============================================================
        // TODO 4 — QUEUE<T>
        // ============================================================
        // Create Queue<string> named supportTickets.
        // Enqueue: "TICKET-1", "TICKET-2", "TICKET-3".
        //
        // Dequeue one ticket into variable processedTicket.
        // Print:
        // Processed ticket: TICKET-1
        // Next ticket: TICKET-2
        // Remaining tickets: 2
        Queue<string> supportTickets = new();
        supportTickets.Enqueue("TICKET-1");
        supportTickets.Enqueue("TICKET-2");
        supportTickets.Enqueue("TICKET-3");

        string processedTicket = supportTickets.Dequeue();
        Console.WriteLine($"Processed ticket: {processedTicket}");
        Console.WriteLine($"Next ticket: {supportTickets.Peek()}");
        Console.WriteLine($"Remaining tickets: {supportTickets.Count}");

        // ============================================================
        // TODO 5 — STACK<T>
        // ============================================================
        // Create Stack<string> named browserHistory.
        // Push: "Home", "Products", "Checkout".
        //
        // Pop one page into variable currentPage.
        // Print:
        // Current page after Pop: Checkout
        // Previous page: Products
        // Remaining pages: 2
        Stack<string> browserHistory = new();
        browserHistory.Push("Home");
        browserHistory.Push("Products");
        browserHistory.Push("Checkout");

        string currentPage = browserHistory.Pop();
        Console.WriteLine($"Current page after Pop: {currentPage}");
        Console.WriteLine($"Previous page: {browserHistory.Peek()}");
        Console.WriteLine($"Remaining pages: {browserHistory.Count}");
    }
}