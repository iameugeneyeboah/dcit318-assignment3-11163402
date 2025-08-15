using System;
using System.Collections.Generic;

namespace Assignment3.Q1
{
    public class FinanceApp
    {
        private readonly List<Transaction> _transactions = new();

        public void Run()
        {
            Console.WriteLine("===== QUESTION 1: Finance Management System =====\n");

            var account = new SavingsAccount("ACC-001", 1000m);

            var t1 = new Transaction(1, DateTime.Now, 150m, "Groceries");
            var t2 = new Transaction(2, DateTime.Now, 300m, "Utilities");
            var t3 = new Transaction(3, DateTime.Now, 1200m, "Entertainment");

            ITransactionProcessor p1 = new MobileMoneyProcessor();
            ITransactionProcessor p2 = new BankTransferProcessor();
            ITransactionProcessor p3 = new CryptoWalletProcessor();

            p1.Process(t1);
            p2.Process(t2);
            p3.Process(t3);

            account.ApplyTransaction(t1);
            account.ApplyTransaction(t2);
            account.ApplyTransaction(t3);

            _transactions.AddRange(new[] { t1, t2, t3 });

            Console.WriteLine();
        }
    }
}
