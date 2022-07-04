using System;
using AutoFixture;
using OnlineShop.Db.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace OnlineShop.AutomatedUITests
{
    public class LoginTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private Fixture fixture = new Fixture();

        private readonly string url = "https://localhost:5001/Login/Register";
        //private readonly string[] urlX = Environment.GetEnvironmentVariable("ASPNETCORE_URLS").Split(";");

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
        [InlineData("", "1234", "12345678", "Длина пароля должна быть от 8")]
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

        [Theory]
        [InlineData("12345678", "12345678")]
        [InlineData("11111111", "11111111")]
        public void Create_WrongModelData_ReturnsIndexViewWithNewEmployee(string password, string passwordConfirm)
        {
            var login = fixture.Create("Name");
            _driver.Navigate().GoToUrl(url);
            _driver.FindElement(By.Name("Login")).SendKeys(login);
            _driver.FindElement(By.Name("Password")).SendKeys(password);
            _driver.FindElement(By.Name("PasswordConfirm")).SendKeys(passwordConfirm);
            _driver.FindElement(By.ClassName("btn-outline-dark")).Click();

            Assert.Equal($"Авторизация - {MyConstant.NameOrganization}", _driver.Title);
            _driver.FindElement(By.Name("Login")).SendKeys(login);
            _driver.FindElement(By.Name("Password")).SendKeys(password);
            _driver.FindElement(By.ClassName("btn-outline-dark")).Click();

            Assert.Equal($"Личный кабинет - {MyConstant.NameOrganization}", _driver.Title);
            Assert.Contains(login, _driver.PageSource);
        }
    }
}
