namespace Be.Gilit.BankKata;

public class Account : IAccount
{
    private readonly Transactions _transactions;
    private readonly IPrinter _printer;
    private readonly IClock _clock;
    public Account(Transactions transactions, IPrinter printer, IClock clock)
    {
        _transactions = transactions;
        _printer = printer;
        _clock = clock;
    }
    public void Deposit(int amount)
    {
        _transactions.Add(new Transaction(amount,_clock.Now()));
    }

    public void Withdraw(int amount)
    {
        _transactions.Add(new Transaction(-amount,_clock.Now()));
    }

    public void PrintStatement()
    {
        _printer.Print(_transactions.GetAll());
    }
}

public class TransactionsRepository : Transactions
{
    private List<Transaction> _transactions = new();

    public void Add(Transaction transaction)
    {
        _transactions.Add(transaction);
    }

    public List<Transaction> GetAll()
    {
        return _transactions;
    }
}

public interface Transactions
{
    void Add(Transaction transaction);
    List<Transaction> GetAll();
}

public record Transaction(int amount, DateTime Date);