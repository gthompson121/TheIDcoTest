using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TheIDcoTest.BalanceCalculator.Models;
using Xunit;

namespace TheIDcoTest.BalanceCalculator.UnitTests
{
    public class BalanceCalculation
    {
        [Fact]
        public void CalculationWithPositiveBalance()
        {
            var calculator = new BalanceCalculator();
            var amount = new Amount() { AmountInPennies = 10, BalancePolarity = BalancePolarity.Credit };
            var now = DateTime.Now.Date;
            var transactions = new List<Transaction>()
            {
                new Transaction(){ AmountInPennies = 2, BalancePolarity = BalancePolarity.Debit, BookingDate = now.AddDays(-1)},
                new Transaction(){ AmountInPennies = 3, BalancePolarity = BalancePolarity.Debit, BookingDate = now.AddDays(-2)},
                new Transaction(){ AmountInPennies = 5, BalancePolarity = BalancePolarity.Credit, BookingDate = now.AddDays(-4)},
            };

            var result = calculator.CalculateBalances(amount, transactions);

            Assert.Equal(3, result.Length);

            var yesterday = result[0];
            var TwoDaysAgo = result[1];
            var FourDaysAgo = result[2];

            Assert.True(yesterday.Date == now.AddDays(-1));
            Assert.True(yesterday.AmountInPennies == 8);

            Assert.True(TwoDaysAgo.Date == now.AddDays(-2));
            Assert.True(TwoDaysAgo.AmountInPennies == 5);

            Assert.True(FourDaysAgo.Date == now.AddDays(-4));
            Assert.True(FourDaysAgo.AmountInPennies == 10);
        }

        [Fact]
        public void NoTransactionsExpectNoBalances()
        {
            var calculator = new BalanceCalculator();
            var amount = new Amount() { AmountInPennies = 10, BalancePolarity = BalancePolarity.Credit };
            var now = DateTime.Now.Date;
            var transactions = new List<Transaction>(){};

            var result = calculator.CalculateBalances(amount, transactions);

            Assert.Empty(result);
        }

        [Fact]
        public void CalculationWithNegativeBalance()
        {
            var calculator = new BalanceCalculator();
            var amount = new Amount() { AmountInPennies = 10, BalancePolarity = BalancePolarity.Credit };
            var now = DateTime.Now.Date;
            var transactions = new List<Transaction>()
            {
                new Transaction(){ AmountInPennies = 2, BalancePolarity = BalancePolarity.Debit, BookingDate = now.AddDays(-1)},
                new Transaction(){ AmountInPennies = 13, BalancePolarity = BalancePolarity.Debit, BookingDate = now.AddDays(-2)},
                new Transaction(){ AmountInPennies = 5, BalancePolarity = BalancePolarity.Debit, BookingDate = now.AddDays(-4)},
            };

            var result = calculator.CalculateBalances(amount, transactions);

            Assert.Equal(3, result.Length);

            var yesterday = result[0];
            var TwoDaysAgo = result[1];
            var FourDaysAgo = result[2];

            Assert.True(yesterday.Date == now.AddDays(-1));
            Assert.True(yesterday.AmountInPennies == 8);

            Assert.True(TwoDaysAgo.Date == now.AddDays(-2));
            Assert.True(TwoDaysAgo.AmountInPennies == -5);

            Assert.True(FourDaysAgo.Date == now.AddDays(-4));
            Assert.True(FourDaysAgo.AmountInPennies == -10);
        }
    }
}
