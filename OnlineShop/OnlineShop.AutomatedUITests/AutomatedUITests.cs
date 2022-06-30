using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Xunit;

namespace OnlineShop.AutomatedUITests
{
    public class AutomatedUITests: IDisposable
    {
        //���������� ������������ ����� Dispose, ����� ������� ���� chrome, �������� ChromeDriver, � ����� ������� ���.
        private readonly IWebDriver _driver;// = new RemoteWebDriver(new Uri("http://127.0.0.1:5001"), new ChromeOptions());
        public AutomatedUITests()
        {
            _driver = new ChromeDriver();
        }

        public void Dispose()
        {
            //_driver.Quit();
            //_driver.Dispose();
        }

        //������ ���� ����������������� ����������
        [Fact]
        public void Create_WhenExecuted_ReturnsCreateView()
        {
            _driver.Navigate() // ���������� ����� Navigate, ����� ������� ��������, ��� ����� ����������� ������� � ������ �����
                .GoToUrl("https://localhost:5001/Employees/Create"); //� ������� ������ GoToUrl �� ��������� ��� ��������������

            //����� �������� �������� � ������������ URL-������ ����� ��������� �������� Title � PageSource ������� _driver
            Assert.Equal("����������� ������ ���������� - ��� \"���������������\"", _driver.Title);
            Assert.Contains("����������� ������ ����������", _driver.PageSource);
        }

        //���������� �� ��������� �� ������ �� ������,
        //���� �� ��������� ��������� ���� �����, � �� ��� �� ���, � �������� ������ "Create":
        [Fact]
        public void Create_WrongModelData_ReturnsErrorMessage()
        {
            _driver.Navigate()
                .GoToUrl("https://localhost:5001/Employees/Create");
            _driver.FindElement(By.Name("Name"))
                .SendKeys("Test Employee");

            _driver.FindElement(By.Name("Age"))
                .SendKeys("34");

            _driver.FindElement(By.ClassName("btn-outline-dark"))
                .Click();

            var errorMessage = _driver.FindElement(By.ClassName("field-validation-error")).Text;

            Assert.Equal("Account number is required", errorMessage);
        }


    }
}
