using System;
using demo_crawler_api.Utils;
using Xunit;

namespace demo_crawler_api_unit_test
{
    public class UrlValidatorTest
    {
        // For some reason the test runner in visual studio for mac seems to ignore all but the first inlinedata.
        // Works fine when running "dotnet test" in the terminal.
        [Theory]
        [InlineData("https://www.google.com")] // Valid
        [InlineData("http://www.google.se")] // Valid
        [InlineData("qweqwe")] // Invalid
        [InlineData("www.google.com")] // Invalid, missing protocol        
        public void TestValidUrls(string url)
        {
            Assert.True(UrlValidator.ValidateUrl(url));
        }       
    }
}
