namespace Be.Gilit.BankKata;

public class Printer : IPrinter
{
    private readonly IConsole _console;
    private readonly string HEADER = "Date       ||  Amount || Balance";

    public Printer(IConsole console)
    {
        _console = console;
    }

    public void Print(List<Transaction> transactions)
    {
       _console.PrintLine(HEADER);
       var balance = 0;
       foreach (var transaction in transactions)
       {
           balance += transaction.amount;
           _console.PrintLine($"{transaction.Date:d}       ||   {transaction.amount}  || {balance}");
       }
    }
}