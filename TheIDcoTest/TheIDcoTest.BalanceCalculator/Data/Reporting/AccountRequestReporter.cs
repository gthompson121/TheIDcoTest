using System;
using System.Collections.Generic;
using System.Text;
using TheIDcoTest.BalanceCalculator.Data.Serialization;
using TheIDcoTest.BalanceCalculator.Models;

namespace TheIDcoTest.BalanceCalculator.Data.Reporting
{
    public class AccountRequestReporter : IAccountRequestReporter
    {
        private readonly IJsonParser jsonParser;

        public AccountRequestReporter(IJsonParser jsonParser)
        {
            this.jsonParser = jsonParser;
        }

        public void ReportAccountRequestCalculations(AccountReportContent[] accounts)
        {
            foreach (var account in accounts) ReportAccount(account);
        }

        public void ReportAccount(AccountReportContent accountContent)
        {
            var reportJson = jsonParser.GetData<AccountReportContent>(accountContent);

            Console.WriteLine(reportJson);
        }
    }
}
