using System.IO;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Winton.Extensions.Configuration.Consul.Parsers
{
    public class JsonConfigurationParserTests
    {
        private readonly JsonConfigurationParser _parser;

        public JsonConfigurationParserTests()
        {
            _parser = new JsonConfigurationParser();
        }

        public sealed class Parse : JsonConfigurationParserTests
        {
            [Theory]
            [InlineData("{\"Key\": \"Value\"}", "base/Key", "Value")]
            [InlineData("{\"parent\": {\"child\": \"Value\"} }", "base/parent:child", "Value")]
            private void ShouldParseSimpleJsonFromStream(string json, string key, string expectedValue)
            {
                using Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
                var result = _parser.Parse("base", stream);
                result[key].Should().Be(expectedValue);
            }
        }
    }
}