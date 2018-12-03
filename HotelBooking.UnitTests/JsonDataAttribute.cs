using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace HotelBooking.UnitTests
{
    public class JsonDataAttribute : DataAttribute
    {
        private string _filePath;

        public JsonDataAttribute(string filePath)
        {
            _filePath = filePath;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var fileData = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<object[]>>(fileData);
        }
    }
}
