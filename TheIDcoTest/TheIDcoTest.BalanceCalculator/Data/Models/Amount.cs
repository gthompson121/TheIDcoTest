using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TheIDcoTest.BalanceCalculator.Models
{
    [DataContract]
    public class Amount
    {
        [DataMember(Name = "amount")]
        public int AmountInPennies { get; set; }

        [DataMember(Name = "creditDebitIndicator")]
        public BalancePolarity BalancePolarity { get; set; }

        public int AmountInPenniesWithPolarity
        {
            get { return BalancePolarity == BalancePolarity.Credit ? AmountInPennies : AmountInPennies * -1; }
        }
    }
}
