using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;

namespace SeleniumTestsOnContainers
{
    [TestClass]
    public class SeleniumTests
    {
        private RemoteWebDriver _driver;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            //var options = new ChromeOptions();
            
            //_driver = new ChromeDriver(".");
            //var remoteWebDriverUrl = TestContext.Properties["remoteWebDriverUrl"] as string;
            //_driver = new RemoteWebDriver(new Uri(remoteWebDriverUrl), options);
        }

        [TestMethod]
        public void PageLive_Test()
        {
            var options = new ChromeOptions();
            var remoteWebDriverUrl = TestContext.Properties["remoteWebDriverUrl"] as string;
            _driver = new RemoteWebDriver(new Uri(remoteWebDriverUrl), options);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.youtube.com/houssemdellai");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Assert.IsTrue(_driver.PageSource.Contains("Houssem Dellai"));
        }

        [TestMethod]
        public void GoogleTest()
        {
            FirefoxOptions options = new FirefoxOptions();
            var remoteWebDriverUrl = TestContext.Properties["remoteWebDriverUrl"] as string;
            _driver = new RemoteWebDriver(new Uri(remoteWebDriverUrl), options.ToCapabilities(), TimeSpan.FromMinutes(3));
            
            _driver.Navigate().GoToUrl("http://www.google.com");
            _driver.FindElement(By.Name("q")).SendKeys("Selenium");
            System.Threading.Thread.Sleep(5000);
            _driver.FindElement(By.Name("btnK")).Click();
            Assert.IsTrue(_driver.PageSource.Contains("Selenium"));
            //Assert.That(_driver.PageSource.Contains("Selenium"), Is.EqualTo(true),
            //                                "The text selenium doest not exist");
        }


    }
}
