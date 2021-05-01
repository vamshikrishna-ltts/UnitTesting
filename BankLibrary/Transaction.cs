using System;
using System.Collections.Generic;
using System.Text;
using Humanizer;
namespace BankLibrary
{
    public class Transaction
    {
        public decimal Amount { get; }

        public string AmountInWords { get
            {
                return ((int)Amount).ToWords();
            } 
        }
        public DateTime Date { get;}

        public string Notes;

        public Transaction(decimal amount, DateTime date, string note)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
        }
    }
}
