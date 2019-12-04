using Microsoft.Extensions.DependencyInjection;
using System;
using TheIDcoTest.BalanceCalculator.Data;
using TheIDcoTest.BalanceCalculator.Data.Reporting;
using TheIDcoTest.BalanceCalculator.Data.Serialization;

namespace TheIDcoTest.BalanceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddScoped<IAccountRequestService, AccountRequestService>()
            .AddScoped<IAccountRequestAccess, AccountRequestAccess>()
            .AddScoped<IAccountRequestCalculator, AccountRequestCalculator>()
            .AddScoped<IAccountRequestReporter, AccountRequestReporter>()
            .AddSingleton<IJsonParser, JsonParser>()
            .AddScoped<IBalanceCalculator, BalanceCalculator>()
            .AddScoped<IFileReaderWrapper, FileReaderWrapper>()
            .BuildServiceProvider();


            //do the actual work here
            string fileName = "Account.json";
            if (args.Length == 1) fileName = args[0];

            var bar = serviceProvider.GetService<IAccountRequestService>();
            bar.ProcessAccountRequest(fileName);
        }
    }
}
