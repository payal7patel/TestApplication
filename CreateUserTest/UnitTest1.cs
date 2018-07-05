using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome; //to use google chrome browser.
using System;

namespace UserTest
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        string url = "http://localhost:21182/";

        [TestMethod]
        public void CreateUserTest()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

            var initialUserCount = driver.FindElement(By.Id("lblTotal"));
            var initialUserCountMessage = initialUserCount.Text;

            driver.FindElement(By.LinkText("Create New")).Click();

            var name = driver.FindElement(By.Id("Name"));
            name.SendKeys("test user");

            var emailAddress = driver.FindElement(By.Id("EmailAddress"));
            emailAddress.SendKeys("test@abc.com");

            var mobileNo = driver.FindElement(By.Id("MobileNo"));
            mobileNo.SendKeys("12345");

            var submitLink = driver.FindElement(By.Id("btnSubmit"));
            submitLink.Click();

            var totalUserCount = driver.FindElement(By.Id("lblTotal"));
            var totalUserCountMessage = totalUserCount.Text;

            Assert.AreEqual(Convert.ToInt32(totalUserCountMessage), Convert.ToInt32(initialUserCountMessage) + 1);

            driver.Quit();
        }

        [TestMethod]
        public void DetailsUserTest()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

            driver.FindElement(By.LinkText("Details")).Click();

            var name = driver.FindElement(By.Id("lblName"));

            var emailAddress = driver.FindElement(By.Id("lblEmailAddress"));

            var mobileNo = driver.FindElement(By.Id("lblMobile"));

            Assert.IsNotNull(name.Text);
            Assert.IsNotNull(emailAddress.Text);
            Assert.IsNotNull(mobileNo.Text);

            driver.Quit();
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

            var initialUserCount = driver.FindElement(By.Id("lblTotal"));
            var initialUserCountMessage = initialUserCount.Text;

            driver.FindElement(By.LinkText("Delete")).Click();

            var btnDelete = driver.FindElement(By.ClassName("btn-danger"));
            btnDelete.Click();

            var totalUserCount = driver.FindElement(By.Id("lblTotal"));
            var totalUserCountMessage = totalUserCount.Text;

            Assert.AreEqual(Convert.ToInt32(totalUserCountMessage), Convert.ToInt32(initialUserCountMessage) - 1);

            driver.Quit();
        }
    }
}
