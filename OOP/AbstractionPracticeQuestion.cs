using CSharpCodingPrep.Interfaces;

public class AbstractionPracticeQuestion : IQuestion
{
    // TODO 1: Create an abstract base class 'DatabaseConnection' with:
    //         - a protected property 'ConnectionString' { get; set; }
    //         - a concrete method Connect() that prints "Connecting to {ConnectionString}"
    //         - an abstract method Execute(string query) that derived classes must implement
    //
    //         Create an interface 'ILogger' with:
    //         - a method Log(string message)
    //
    //         Create derived class 'SqlServerConnection' that:
    //         - inherits from DatabaseConnection
    //         - implements ILogger
    //         - overrides Execute(string query) to print "Executing SQL: {query}"
    //         - implements Log(string message) to print "[SQL LOG] {message}"
    //
    //         Create another interface 'ITransaction' with:
    //         - a method BeginTransaction()
    //         - a method Commit()
    //
    //         Create another derived class 'OracleConnection' that:
    //         - inherits from DatabaseConnection
    //         - implements BOTH ILogger AND ITransaction
    //         - overrides Execute(string query) to print "Oracle executing: {query}"
    //         - implements Log, BeginTransaction, Commit
    abstract class DatabaseConnection
    {
        protected string ConnectionString { get; set; }

        public void Connect()
        {
            Console.WriteLine($"Connecting to {ConnectionString}");
        }

        public abstract void Execute(string query);
    }

    interface ILogger
    {
        void Log(string message);
    }

    class SqlServerConnection : DatabaseConnection, ILogger
    {
        public override void Execute(string query)
        {
            Console.WriteLine($"Executing SQL: {query}");
        }

        public void Log(string message)
        {
            Console.WriteLine($"[SQL LOG] {message}");
        }
    }

    interface ITransaction
    {
        public void BeginTransaction();
        public void Commit();
    }

    class OracleConnection : DatabaseConnection, ILogger, ITransaction
    {
        public override void Execute(string query)
        {
            Console.WriteLine($"Oracle executing: {query}");
        }

        public void Log(string message)
        {
            Console.WriteLine($"Log message: {message}");
        }

        public void BeginTransaction()
        {
            Console.WriteLine("Transaction is Starting");
        }

        public void Commit()
        {
            Console.WriteLine("Commiting the transaction");
        }
    }

    public void Run()
    {
        // TODO 2: Create a SqlServerConnection and an OracleConnection.
        //         - Call Connect() on each (inherited from abstract base)
        //         - Call Execute() on each (polymorphic override)
        //         - Call Log() on each through ILogger interface (polymorphic)
        //         - Call BeginTransaction() and Commit() on OracleConnection through ITransaction
        //         Demonstrate that both classes share base behavior (Connect) but have
        //         different Execute implementations, and different interfaces.
        SqlServerConnection sqlConnection = new SqlServerConnection();
        OracleConnection oracleConnection = new OracleConnection();
        sqlConnection.Connect();
        oracleConnection.Connect();
        sqlConnection.Execute("EXAMPLE_QUERY_1");
        oracleConnection.Execute("EXAMPLE_QUERY_2");
        sqlConnection.Log("Query Passed");
        oracleConnection.Log("Query Passed");
        oracleConnection.BeginTransaction();
        oracleConnection.Commit();
    }
}