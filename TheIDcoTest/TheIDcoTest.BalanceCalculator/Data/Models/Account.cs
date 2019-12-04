using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using TheIDcoTest.BalanceCalculator.Data.Models;

namespace TheIDcoTest.BalanceCalculator.Models
{
    [DataContract]
    public class Account
    {
        [DataMember(Name = "accountId")]
        public int Id { get; set; }

        [DataMember(Name = "displayName")]
        public string Name { get; set; }

        [DataMember(Name = "balances")]
        public Balances Balances { get; set; }

        [DataMember(Name = "transactions")]
        public Transaction[] Transactions { get; set; }

        public EndOfDayBalance[] EndOfDayBalances { get; set; }

        public int TotalCredits
        {
            get
            {
                return Transactions == null ? 0 : Transactions.Where(t => t.BalancePolarity == BalancePolarity.Credit).Sum(t => t.AmountInPennies);
            }
        }

        public int TotalDebits
        {
            get
            {
                return Transactions == null ? 0 : Transactions.Where(t => t.BalancePolarity == BalancePolarity.Debit).Sum(t => t.AmountInPennies);
            }
        }
    }
}
