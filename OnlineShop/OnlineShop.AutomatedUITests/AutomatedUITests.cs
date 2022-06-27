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

        //������ �������� ����
        [Fact]
        public void Create_WhenExecuted_ReturnsCreateView()
        {
            _driver.Navigate() // ���������� ����� Navigate, ����� ������� ��������, ��� ����� ����������� ������� � ������ �����
                .GoToUrl("https://localhost:5001/OnlineShop/Create"); //� ������� ������ GoToUrl �� ��������� ��� ��������������

            //����� �������� �������� � ������������ URL-������ ����� ��������� �������� Title � PageSource ������� _driver
            Assert.Equal("Create - EmployeesApp", _driver.Title); 
            Assert.Contains("Please provide a new employee data", _driver.PageSource);
        }
    }
}
