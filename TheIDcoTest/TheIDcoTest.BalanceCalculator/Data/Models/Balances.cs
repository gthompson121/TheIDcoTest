using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TheIDcoTest.BalanceCalculator.Models
{
    [DataContract]
    public class Balances
    {
        [DataMember(Name = "current")]
        public Amount Current { get; set; }

        [DataMember(Name = "available")]
        public Amount Available { get; set; }

    }
}
