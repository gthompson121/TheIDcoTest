using System.Runtime.Serialization;
using TheIDcoTest.BalanceCalculator.Data.Models;

namespace TheIDcoTest.BalanceCalculator.Models
{
    [DataContract]
    public class AccountReportContent
    {
        public AccountReportContent(Account account)
        {
            EndOfDayBalances = account.EndOfDayBalances;
            TotalCredits = account.TotalCredits;
            TotalDebits = account.TotalDebits;
        }

        [DataMember(Name = "EndOfDayBalances")]
        public EndOfDayBalance[] EndOfDayBalances { get; set; }

        [DataMember(Name = "TotalCredits")]
        public int TotalCredits { get; set; }

        [DataMember(Name = "TotalDebits")]
        public int TotalDebits { get; set; }
    }
}