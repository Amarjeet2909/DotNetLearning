using CSharpCodingPrep.Interfaces;

public class ConstructorsPracticeQuestion : IQuestion
{
    // TODO 1: Define a private nested class 'BankAccount' with:
    //         - a private static field '_totalAccountsCreated' (int, starts at 0)
    //         - private fields '_accountHolder' (string) and '_balance' (decimal)
    //         - a primary constructor(string accountHolder, decimal initialBalance)
    //           that assigns both fields AND increments the static counter
    //         - an overloaded constructor(string accountHolder) that chains to
    //           the primary constructor with an initial balance of 0
    //         - read-only properties AccountHolder and Balance
    //         - a public static method GetTotalAccounts() returning the static count
    private class BankAccount
    {
        private static int _totalAccountsCreated = 0;
        private string _accountHolder;
        private decimal _balance;

        public BankAccount(string accountHolder, decimal initialBalance)
        {
            _accountHolder = accountHolder;
            _balance = initialBalance;
            _totalAccountsCreated++;
        }

        public BankAccount(string accountHolder) : this(accountHolder, 0) { }

        public static int GetTotalAccounts() => _totalAccountsCreated;
        public string AccountHolder => _accountHolder;
        public decimal Balance => _balance;
    }

    public void Run()
    {
        // TODO 2: Create 2 BankAccount objects - at least one using each constructor
        //         overload. Print each account's holder name and balance.
        //         Then print the total number of accounts created using the
        //         static method, accessed via the CLASS NAME (not an instance).
        BankAccount account1 = new BankAccount("Amarjeet", 1000);
        BankAccount account2 = new BankAccount("Hari");
        Console.WriteLine($"Name: {account1.AccountHolder} Balance: {account1.Balance}");
        Console.WriteLine($"Name: {account2.AccountHolder} Balance: {account2.Balance}");
        int totalAccountsCreated = BankAccount.GetTotalAccounts();
        Console.WriteLine($"Total Account Created: {totalAccountsCreated}");
    }
}