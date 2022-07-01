using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace OnlineShop.AutomatedUITests.Login
{
    public class LoginTests: IDisposable
    {
        private readonly IWebDriver _driver;

        public LoginTests()
        {
            _driver = new ChromeDriver();
        }
        public void Dispose()
        {
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
