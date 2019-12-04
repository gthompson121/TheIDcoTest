using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using TheIDcoTest.BalanceCalculator.Data.Serialization;

namespace TheIDcoTest.BalanceCalculator
{
    public class JsonParser : IJsonParser
    {
        private readonly JsonSerializerSettings parserSettings;

        public JsonParser()
        {
            this.parserSettings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd HH:mm:ss.fff",
                NullValueHandling = NullValueHandling.Ignore
            };

            this.parserSettings.Converters.Add(new StringEnumConverter { NamingStrategy = new CamelCaseNamingStrategy() });
        }

        public string GetData<T>(T o) where T : class
        {
            return JsonConvert.SerializeObject(o, parserSettings);
        }

        public T ReadData<T>(string data) where T : class
        {
            return JsonConvert.DeserializeObject<T>(data, parserSettings);
        }
    }
}
