using System;
using System.Collections.Generic;
using System.Text;
using TheIDcoTest.BalanceCalculator.Models;

namespace TheIDcoTest.BalanceCalculator.Data.Reporting
{
    public interface IAccountRequestReporter
    {
        void ReportAccountRequestCalculations(AccountReportContent[] accounts);

        void ReportAccount(AccountReportContent accountContent);
    }
}
