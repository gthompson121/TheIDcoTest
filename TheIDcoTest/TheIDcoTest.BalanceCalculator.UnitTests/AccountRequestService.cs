using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TheIDcoTest.BalanceCalculator.Data;
using TheIDcoTest.BalanceCalculator.Data.Models;
using TheIDcoTest.BalanceCalculator.Models;
using Xunit;

namespace TheIDcoTest.BalanceCalculator.UnitTests
{
    public class AccountRequestCalculatorTests
    {
        [Fact]
        public void CalcBalanceForDays()
        {
            var mockDependancy = new Mock<IBalanceCalculator>();

            var now = DateTime.Now;
            var amount = new Amount() { AmountInPennies = 10, BalancePolarity = BalancePolarity.Credit };
            var transactions = new Transaction[2]
            {
                new Transaction(){ AmountInPennies = 2, BalancePolarity = BalancePolarity.Debit, BookingDate = now.AddDays(-1)},
                new Transaction(){ AmountInPennies = 3, BalancePolarity = BalancePolarity.Debit, BookingDate = now.AddDays(-2)},
            };
            
            var accountList = new Account[1] { new Account() { Balances = new Balances() { Current = amount }, Transactions = transactions } };

            var expectedBalances = new EndOfDayBalance[2]
            {
                new EndOfDayBalance() { AmountInPennies = 8, Date = now.AddDays(-1) },
                new EndOfDayBalance() { AmountInPennies = 5, Date = now.AddDays(-2) }
            };

            mockDependancy.Setup(x => x.CalculateBalances(amount, transactions)).Returns(expectedBalances);

            var accRequestCalculator = new AccountRequestCalculator(mockDependancy.Object);
            var result = accRequestCalculator.RunCalculatorForAccounts(accountList);

            Assert.Single(result);
            var singleResult = result[0];
            Assert.True(singleResult.TotalDebits == 5);
            Assert.True(singleResult.TotalCredits == 0);

            Assert.True(singleResult.EndOfDayBalances.Length == 2);
        }
    }
}
