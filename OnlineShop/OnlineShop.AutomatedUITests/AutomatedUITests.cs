using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace OnlineShop.AutomatedUITests
{
    public class AutomatedUITests: IDisposable
    {
        //���������� ������������ ����� Dispose, ����� ������� ���� chrome, �������� ChromeDriver, � ����� ������� ���.

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

        //������ ���� ����������������� ����������
        [Fact]
        public void Create_WhenExecuted_ReturnsCreateView()
        {
            _driver.Navigate() // ���������� ����� Navigate, ����� ������� ��������, ��� ����� ����������� ������� � ������ �����
                .GoToUrl("https://localhost:5001/Employees/Create"); //� ������� ������ GoToUrl �� ��������� ��� ��������������

            //����� �������� �������� � ������������ URL-������ ����� ��������� �������� Title � PageSource ������� _driver
            Assert.Equal("����������", _driver.Title);
            //Assert.Contains("Please provide a new employee data", _driver.PageSource);
        }

        //������ ���� � ������� �� ���������, ���������� �� ��������� �� ������ �� ������, ���� �� ��������� ��������� ���� �����, � �� ��� �� ���, � �������� ������ "Create":
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
