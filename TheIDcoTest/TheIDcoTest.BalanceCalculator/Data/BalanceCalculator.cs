using System;
using System.Collections.Generic;
using System.Text;
using TheIDcoTest.BalanceCalculator.Data.Models;
using TheIDcoTest.BalanceCalculator.Models;
using System.Linq;

namespace TheIDcoTest.BalanceCalculator
{
    public class BalanceCalculator : IBalanceCalculator
    {
        public EndOfDayBalance[] CalculateBalances(Amount startingAmount, IEnumerable<Transaction> transactions)
        {
            if (transactions == null || transactions.Count() == 0) return new EndOfDayBalance[0];

            var startDate = transactions.OrderBy(t => t.BookingDate).First().BookingDate;
            var endDate = transactions.OrderBy(t => t.BookingDate).Last().BookingDate;

            var balanceList = new List<EndOfDayBalance>();
            int rollingBalance = startingAmount.AmountInPenniesWithPolarity;
            for (DateTime date = endDate; date >= startDate; date = date.AddDays(-1))
            {
                if(transactions.Any(t=>t.BookingDate.Date == date.Date))
                {
                    var daysTransactions = transactions.Where(t => t.BookingDate.Date == date.Date);
                    rollingBalance = CalculateDaysBalance(rollingBalance, daysTransactions);
                    balanceList.Add(new EndOfDayBalance() { Date = date, AmountInPennies = rollingBalance });
                }
            }

            return balanceList.ToArray();
        }

        public int CalculateDaysBalance(int daysBalance, IEnumerable<Transaction> daysTransactions)
        {
            var todaysTransactionTotal = daysTransactions.Sum(t => t.AmountInPenniesWithPolarity);

            return daysBalance += todaysTransactionTotal;
        }
    }
}
