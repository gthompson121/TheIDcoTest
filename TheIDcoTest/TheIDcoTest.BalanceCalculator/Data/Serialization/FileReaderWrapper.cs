using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TheIDcoTest.BalanceCalculator.Data.Serialization;

namespace TheIDcoTest.BalanceCalculator.Data
{
    public class FileReaderWrapper : IFileReaderWrapper
    {
        public string ReadAllText(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
