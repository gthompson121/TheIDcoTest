using System;
using System.Collections.Generic;
using System.Text;
using TheIDcoTest.BalanceCalculator.Models;
using System.Linq;

namespace TheIDcoTest.BalanceCalculator.Data
{
    public class AccountRequestCalculator : IAccountRequestCalculator
    {
        public AccountRequestCalculator(IBalanceCalculator balanceCalculator)
        {
            this.balanceCalculator = balanceCalculator;
        }

        private readonly IBalanceCalculator balanceCalculator;

        public AccountReportContent[] RunCalculatorForAccounts(Account[] accounts)
        {
            foreach(var account in accounts)
            {
                var currentBalance = account.Balances.Current;
                account.EndOfDayBalances = balanceCalculator.CalculateBalances(currentBalance, account.Transactions);
            }

            return accounts.Select(a => new AccountReportContent(a)).ToArray();
        }
    }
}
