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

        [Theory]
        [InlineData("alex", "12345678", "", "Не указан повторный пароль")]
        [InlineData("alex", "12345678", "1122222", "Проверочный пароль должен совпадать с паролем")]
        [InlineData("", "12345678", "12345678", "Не указан логин")]
        [InlineData("", "1234", "12345678", "Не указан логин")]
        public void Register_WrongModelData_ReturnsErrorMessage(string login, string password, string passwordConfirm, string textError)
        {
            _driver.Navigate().GoToUrl(url);
            _driver.FindElement(By.Name("Login")).SendKeys(login);
            _driver.FindElement(By.Name("Password")).SendKeys(password);
            _driver.FindElement(By.Name("PasswordConfirm")).SendKeys(passwordConfirm);
            _driver.FindElement(By.ClassName("btn-outline-dark")).Click();
            var errorMassage = _driver.FindElement(By.ClassName("field-validation-error")).Text;
            Assert.Equal(textError, errorMassage);
        }
    }
}
