using System;
using System.Collections.Generic;
using System.Text;

namespace TheIDcoTest.BalanceCalculator.Data.Serialization
{
    public interface IFileReaderWrapper
    {
        string ReadAllText(string filePath);
    }
}
