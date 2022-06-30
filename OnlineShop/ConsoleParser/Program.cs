using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleParser
{
    internal class Program
    {
        public class AutomatedUI : IDisposable
        {
            
            private readonly IWebDriver _driver;
            private readonly string HomeUrl;
            public AutomatedUI(string homeUrl)
            {
                _driver = new ChromeDriver();
                HomeUrl = homeUrl;
            }

            public void Dispose()
            {
                //_driver.Quit();
                //_driver.Dispose();
            }



            public void GoToUrl()
            {
                _driver
                    .Navigate() // используем метод Navigate, чтобы указать драйверу, что нужно переместить браузер в другое место
                    .GoToUrl(HomeUrl); //с помощью метода GoToUrl мы указываем это местоположение
                _driver.Manage().Window.Maximize();
                _driver.FindElement(By.Name("Name"))
                    .SendKeys("Test Employee");

                //_driver.FindElement(By.Name("Age"))
                //    .SendKeys("34");

                _driver.FindElement(By.ClassName("btn-outline-dark"))
                    .Click();

                var errors = _driver.FindElements(By.ClassName("field-validation-error"));
                List<string> messege = new List<string>();
                foreach (var error in errors)
                {
                    messege.Add(error.Text);

                }

            }

            public void KlikButton()
            {
                //_driver.FindElements();
            }



        }
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            AutomatedUI hhAutomatedUi = new AutomatedUI(@"https://localhost:5001/Employees/Create/");
            hhAutomatedUi.GoToUrl();
            //hhAutomatedUi.KlikButton();

        }
    }
}
