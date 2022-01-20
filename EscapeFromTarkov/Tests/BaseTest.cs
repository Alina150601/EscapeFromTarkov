using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace EscapeFromTarkov.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected const string _baseUrl = "https://www.escapefromtarkov.com/?lang=ru";
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(_baseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
