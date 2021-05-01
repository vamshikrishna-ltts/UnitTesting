using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public class BankAccount
    {
        public string Number { get; } 
        public string OwnerName { get; set; }
        public decimal Balance { 
            get 
            {
                decimal balance = 0;
                foreach(var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private static int accountNumberSeed = 1234567890;

        private List<Transaction> allTransactions = new List<Transaction>();
        public BankAccount(string name, decimal intialBal)
        {
            this.OwnerName = name;
            MakeDeposit(intialBal, DateTime.Now, "Intial Balance");
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
           
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);

        }
        public void MakeWithdrawl(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "amount withdrawl must be +ve");
            }
            if(Balance - amount < 0)
            {
                throw new InvalidOperationException("Insufficent balance");
            }

            var withdraw = new Transaction(-amount, date, note);
            allTransactions.Add(withdraw);
        }

        public string getTransactions()
        {
            var report = new StringBuilder();
            report.AppendLine("Date\t\t AMount \t\t NoteS\t\t AmountInWords");

            foreach(var transaction in allTransactions)
            {
                report.AppendLine($"{ transaction.Date.ToShortDateString()} \t {transaction.Amount} \t" + 
                    $"{transaction.Notes} \t\t\t {transaction.AmountInWords}");
            }
            return report.ToString();
        }
        }
}
