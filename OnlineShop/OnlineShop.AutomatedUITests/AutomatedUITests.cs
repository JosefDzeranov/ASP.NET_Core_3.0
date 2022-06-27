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

        //первый тестовый тест
        [Fact]
        public void Create_WhenExecuted_ReturnsCreateView()
        {
            _driver.Navigate() // используем метод Navigate, чтобы указать драйверу, что нужно переместить браузер в другое место
                .GoToUrl("https://localhost:5001/OnlineShop/Create"); //с помощью метода GoToUrl мы указываем это местоположение

            //После перехода браузера к запрошенному URL-адресу будут заполнены свойства Title и PageSource объекта _driver
            Assert.Equal("Create - EmployeesApp", _driver.Title); 
            Assert.Contains("Please provide a new employee data", _driver.PageSource);
        }
    }
}
