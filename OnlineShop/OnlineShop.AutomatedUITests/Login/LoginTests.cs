using System;
using OnlineShop.Db.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace OnlineShop.AutomatedUITests.Login
{
    public class LoginTests: IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly string url = "https://localhost:5001/Login/Register";

        public LoginTests()
        {
            _driver = new ChromeDriver();
        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void Register_WhenExecuted_ReturnsCreateView()
        {
            _driver.Navigate().GoToUrl(url);
            Assert.Equal($"Регистрация - {MyConstant.NameOrganization}", _driver.Title);
            Assert.Contains("Регистрация", _driver.PageSource);
        }
    }
}
