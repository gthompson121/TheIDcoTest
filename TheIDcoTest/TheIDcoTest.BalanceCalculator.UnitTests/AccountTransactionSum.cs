using System;
using System.Collections.Generic;
using System.Text;
using TheIDcoTest.BalanceCalculator.Models;
using Xunit;

namespace TheIDcoTest.BalanceCalculator.UnitTests
{
    public class AccountTransactionSum
    {
        [Fact]
        public void NoDebitTransactionsZeroTotal()
        {
            var account = new Account()
            {
                Transactions = new Transaction[1] 
                {
                    new Transaction() { AmountInPennies = 123, BalancePolarity = BalancePolarity.Credit }
                }
            };

            Assert.True(account.TotalDebits == 0);
        }

        [Fact]
        public void NoCreditTransactionsZeroTotal()
        {
            var account = new Account()
            {
                Transactions = new Transaction[1]
                {
                    new Transaction() { AmountInPennies = 123, BalancePolarity = BalancePolarity.Debit }
                }
            };

            Assert.True(account.TotalCredits == 0);
        }

        [Fact]
        public void TotalDebitTransactions()
        {
            var account = new Account()
            {
                Transactions = new Transaction[3]
                {
                    new Transaction() { AmountInPennies = 250, BalancePolarity = BalancePolarity.Debit },
                    new Transaction() { AmountInPennies = 555, BalancePolarity = BalancePolarity.Credit },
                    new Transaction() { AmountInPennies = 80, BalancePolarity = BalancePolarity.Debit }
                }
            };

            Assert.True(account.TotalDebits == 330);
        }

        [Fact]
        public void TotalCreditTransactions()
        {
            var account = new Account()
            {
                Transactions = new Transaction[3]
                {
                    new Transaction() { AmountInPennies = 70, BalancePolarity = BalancePolarity.Credit },
                    new Transaction() { AmountInPennies = 555, BalancePolarity = BalancePolarity.Credit },
                    new Transaction() { AmountInPennies = 80, BalancePolarity = BalancePolarity.Debit }
                }
            };

            Assert.True(account.TotalCredits == 625);
        }

        [Fact]
        public void NullTransactionTotal()
        {
            var account = new Account()
            {
            };

            Assert.True(account.TotalCredits == 0);
            Assert.True(account.TotalDebits == 0);
        }
    }
}
