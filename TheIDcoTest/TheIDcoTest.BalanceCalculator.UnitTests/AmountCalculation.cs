using System;
using TheIDcoTest.BalanceCalculator.Models;
using Xunit;

namespace TheIDcoTest.BalanceCalculator.UnitTests
{
    public class AmountPolarityCalculation
    {
        [Fact]
        public void DebitIsNegative()
        {
            var amount = new Amount()
            {
                AmountInPennies = 123,
                BalancePolarity = BalancePolarity.Debit
            };

            Assert.True(amount.AmountInPenniesWithPolarity == -123);
        }

        [Fact]
        public void CreditIsPositive()
        {
            var amount = new Amount()
            {
                AmountInPennies = 123,
                BalancePolarity = BalancePolarity.Credit
            };

            Assert.True(amount.AmountInPenniesWithPolarity == 123);
        }

        [Fact]
        public void ZeroAsDebitIsZero()
        {
            var amount = new Amount()
            {
                AmountInPennies = 0,
                BalancePolarity = BalancePolarity.Debit
            };

            Assert.True(amount.AmountInPenniesWithPolarity == 0);
        }

        [Fact]
        public void ZeroAsCreditIsZero()
        {
            var amount = new Amount()
            {
                AmountInPennies = 0,
                BalancePolarity = BalancePolarity.Credit
            };

            Assert.True(amount.AmountInPenniesWithPolarity == 0);
        }
    }
}
