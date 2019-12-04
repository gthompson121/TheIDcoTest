using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TheIDcoTest.BalanceCalculator.Models
{
    [DataContract]
    public class Transaction : Amount
    {
        [DataMember(Name = "bookingDate")]
        public DateTime BookingDate { get; set; }
    }
}
