using System;

namespace Assignment3.Q1
{
    public interface ITransactionProcessor
    {
        void Process(Transaction transaction);
    }

    public class BankTransferProcessor : ITransactionProcessor
    {
        public void Process(Transaction t)
        {
            Console.WriteLine($"[BankTransfer] Processing {t.Amount:C} for '{t.Category}' on {t.Date:yyyy-MM-dd}.");
        }
    }

    public class MobileMoneyProcessor : ITransactionProcessor
    {
        public void Process(Transaction t)
        {
            Console.WriteLine($"[MobileMoney] Processing {t.Amount:C} for '{t.Category}' on {t.Date:yyyy-MM-dd}.");
        }
    }

    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction t)
        {
            Console.WriteLine($"[CryptoWallet] Processing {t.Amount:C} for '{t.Category}' on {t.Date:yyyy-MM-dd}.");
        }
    }
}
