using System.Collections.Generic;
using TheIDcoTest.BalanceCalculator.Data.Models;
using TheIDcoTest.BalanceCalculator.Models;

namespace TheIDcoTest.BalanceCalculator
{
    public interface IBalanceCalculator
    {
        EndOfDayBalance[] CalculateBalances(Amount startingAmount, IEnumerable<Transaction> transactions);
    }
}