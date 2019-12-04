using System;
using System.Collections.Generic;
using System.Text;
using TheIDcoTest.BalanceCalculator.Data.Reporting;

namespace TheIDcoTest.BalanceCalculator.Data
{
    public class AccountRequestService : IAccountRequestService
    {
        public AccountRequestService(
            IAccountRequestReporter accountRequestReporter,
            IAccountRequestAccess accountRequestAccess,
            IAccountRequestCalculator accountRequestCalculator
            )
        {
            this.accountRequestReporter = accountRequestReporter;
            this.accountRequestAccess = accountRequestAccess;
            this.accountRequestCalculator = accountRequestCalculator;
        }

        private readonly IAccountRequestReporter accountRequestReporter;
        private readonly IAccountRequestAccess accountRequestAccess;
        private readonly IAccountRequestCalculator accountRequestCalculator;

        public void ProcessAccountRequest(string fileName)
        {
            // Retrieve Account Request Data
            var accountRequest = accountRequestAccess.GetAccountRequest(fileName);

            // Run Account Request Calculations
            var accountCalculationList = accountRequestCalculator.RunCalculatorForAccounts(accountRequest.Accounts);

            // Output Account Request Calculations
            accountRequestReporter.ReportAccountRequestCalculations(accountCalculationList);
        }
    }
}
