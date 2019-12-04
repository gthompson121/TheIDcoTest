using TheIDcoTest.BalanceCalculator.Models;

namespace TheIDcoTest.BalanceCalculator.Data
{
    public interface IAccountRequestCalculator
    {
        AccountReportContent[] RunCalculatorForAccounts(Account[] accounts);
    }
}