using System;
using NSubstitute;
using NUnit.Framework;

namespace Be.Gilit.BankKata.Tests;

public class AccountShould
{
   [Test]
   public void DepositMoney()
   {
      var cons = Substitute.For<IConsole>();
      var printer = new Printer(cons);
      var clock = Substitute.For<IClock>();
      var account = new Account(new TransactionsRepository(), printer,clock);
      
      clock.Now().Returns(new DateTime(2020, 08, 14));
      account.Deposit(500);
      account.PrintStatement();
      
      Received.InOrder(() =>
      {
          cons.Received().PrintLine("Date       ||  Amount || Balance");
          cons.Received().PrintLine("08/14/2020       ||   500  || 500");
      });
      
   }

   [Test]
   public void WithdrawMoney()
   {
       var cons = Substitute.For<IConsole>();
       var printer = new Printer(cons);
       var clock = Substitute.For<IClock>();
       var account = new Account(new TransactionsRepository(), printer,clock);


       clock.Now().Returns(new DateTime(2020, 08, 14));
       account.Withdraw(500);
       account.PrintStatement();
      
       Received.InOrder(() =>
       {
           cons.Received().PrintLine("Date       ||  Amount || Balance");
           cons.Received().PrintLine("08/14/2020       ||   -500  || -500");
       });
   }
}