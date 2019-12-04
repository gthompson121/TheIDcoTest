using System;
using System.Collections.Generic;
using System.Text;
using TheIDcoTest.BalanceCalculator.Data;
using TheIDcoTest.BalanceCalculator.Data.Serialization;
using TheIDcoTest.BalanceCalculator.Models;

namespace TheIDcoTest.BalanceCalculator
{
    public class AccountRequestAccess : IAccountRequestAccess
    {
        private readonly IJsonParser JsonParser;
        private readonly IFileReaderWrapper FileReaderWrapper;

        public AccountRequestAccess(
            IFileReaderWrapper fileReaderWrapper, 
            IJsonParser jsonParser)
        {
            this.JsonParser = jsonParser;
            this.FileReaderWrapper = fileReaderWrapper;
        }

        public AccountRequest GetAccountRequest(string fileName)
        {
            var contents = FileReaderWrapper.ReadAllText(fileName);
            return JsonParser.ReadData<AccountRequest>(contents);
        }
    }
}
