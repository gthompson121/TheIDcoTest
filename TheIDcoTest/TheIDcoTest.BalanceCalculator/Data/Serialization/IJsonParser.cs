using System;
using System.Collections.Generic;
using System.Text;

namespace TheIDcoTest.BalanceCalculator.Data.Serialization
{
    public interface IJsonParser
    {
        string GetData<T>(T o) where T : class;
        T ReadData<T>(string data) where T : class;
    }
}
