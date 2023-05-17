using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Jenkins
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("TestJenkins")]

        public void OrgCreation()
        {
            IWebDriver driver = new ChromeDriver();
            string random = "" + RandomNum();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://localhost:8888/");
            driver.FindElement(By.Name("user_name")).SendKeys("admin");
            driver.FindElement(By.Name("user_password")).SendKeys("admin");
            driver.FindElement(By.Id("submitButton")).Click();
            driver.FindElement(By.XPath("//a[.='Leads']/parent::td/following-sibling::td/a[.='Organizations']")).Click();
            driver.FindElement(By.XPath("//img[@title='Create Organization...']")).Click();
            driver.FindElement(By.Name("accountname")).SendKeys("NewOrg" + random);
            driver.FindElement(By.XPath("//input[@title='Save [Alt+S]']")).Click();
            Thread.Sleep(1000);

        }
        public int RandomNum()
        {
            Random ran=new Random();
            int num=ran.Next(1, 100);
            return num;
        }
    }
}
