using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace OnlineShop.AutomatedUITests
{
    public class AutomatedUITests: IDisposable
    {
        //собираемся использовать метод Dispose, чтобы закрыть окно chrome, открытое ChromeDriver, а также удалить его.

        private readonly IWebDriver _driver;
        public AutomatedUITests()
        {
            _driver = new ChromeDriver();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        //первый тест пользовательского интерфейса
        [Fact]
        public void Create_WhenExecuted_ReturnsCreateView()
        {
            _driver.Navigate() // используем метод Navigate, чтобы указать драйверу, что нужно переместить браузер в другое место
                .GoToUrl("https://localhost:5001/Employees/Create"); //с помощью метода GoToUrl мы указываем это местоположение

            //После перехода браузера к запрошенному URL-адресу будут заполнены свойства Title и PageSource объекта _driver
            Assert.Equal("Сотрудники", _driver.Title);
            //Assert.Contains("Please provide a new employee data", _driver.PageSource);
        }

        //второй тест в котором мы проверяем, появляется ли сообщение об ошибке на экране, если мы заполняем некоторые поля ввода, а не все из них, и нажимает кнопку "Create":
        [Fact]
        public void Create_WrongModelData_ReturnsErrorMessage()
        {
            _driver.Navigate()
                .GoToUrl("https://localhost:5001/Employees/Create");
            _driver.FindElement(By.Id("Name"))
                .SendKeys("Test Employee");

            _driver.FindElement(By.Id("Age"))
                .SendKeys("34");

            _driver.FindElement(By.Id("Create"))
                .Click();

            var errorMessage = _driver.FindElement(By.Id("AccountNumber-error")).Text;

            Assert.Equal("Account number is required", errorMessage);
        }
    }
}
