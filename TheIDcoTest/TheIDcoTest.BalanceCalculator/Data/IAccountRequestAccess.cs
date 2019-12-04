using TheIDcoTest.BalanceCalculator.Models;

namespace TheIDcoTest.BalanceCalculator
{
    public interface IAccountRequestAccess
    {
        AccountRequest GetAccountRequest(string fileName);
    }
}