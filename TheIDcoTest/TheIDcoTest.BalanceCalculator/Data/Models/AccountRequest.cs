using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TheIDcoTest.BalanceCalculator.Models
{
    [DataContract]
    public class AccountRequest
    {
        [DataMember(Name = "accounts")]
        public Account[] Accounts { get; set; }
    }
}
