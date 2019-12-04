using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TheIDcoTest.BalanceCalculator.Data.Models
{
    [DataContract]
    public class EndOfDayBalance
    {
        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public int AmountInPennies { get; set; }
    }
}
