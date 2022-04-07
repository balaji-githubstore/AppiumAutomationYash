using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobileAutomation
{
    [TestClass]
    public class Demo2WebAppTest
    {
        [TestMethod]
        public void HdfcLogintSimulateTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.EnableMobileEmulation("Nexus 5");

            ChromeDriver driver = new ChromeDriver(@"C:\Components\chromedriver_win32\", options);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Url = "https://netbanking.hdfcbank.com/netbanking/";
            driver.SwitchTo().Frame(driver.FindElementByXPath("//frame[contains(@src,'RSNBLogin')]"));
            driver.FindElementByXPath("//input[@name='fldLoginUserId']").SendKeys("test123");
            driver.FindElementByXPath("//a[text()='CONTINUE']").Click();
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(driver.FindElementByXPath("//frame[@name='login_page']"));
            driver.FindElementByXPath("//input[@id='fldPasswordDispId']").SendKeys("123");
        }


        [TestMethod]
        public void HdfcLogintTest()
        {
            DriverOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("browserName", "chrome");
            option.AddAdditionalCapability("chromedriverExecutable", @"C:\Components\chromedriver_win32\chromedriver.exe");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Url = "https://netbanking.hdfcbank.com/netbanking/";


            driver.SwitchTo().Frame(driver.FindElementByXPath("//frame[contains(@src,'RSNBLogin')]"));

            driver.FindElementByXPath("//input[@name='fldLoginUserId']").SendKeys("test123");

            driver.FindElementByXPath("//a[text()='CONTINUE']").Click();

            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(driver.FindElementByXPath("//frame[@name='login_page']"));

            driver.FindElementByXPath("//input[@id='fldPasswordDispId']").SendKeys("123");

            //if keyboard shown then hide it. 
            if (driver.IsKeyboardShown())
            {
                driver.HideKeyboard();
            }

            driver.FindElementByXPath("//a[normalize-space()='LOGIN']").Click();

            Console.WriteLine();

            string text = driver.SwitchTo().Alert().Text;
            Console.WriteLine(text);

            driver.SwitchTo().Alert().Accept();

            Thread.Sleep(3000);

            driver.Quit();
        }

        [TestMethod]
        public void WebAppTest1()
        {
            ChromeOptions options = new ChromeOptions();
            options.EnableMobileEmulation("Nexus 5");

            IWebDriver driver = new ChromeDriver(@"C:\Components\chromedriver_win32\", options);


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);

            //total view = 5 
            driver.Url = "http://google.com/";

            //DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            //wait.Timeout = TimeSpan.FromSeconds(60);
            //wait.IgnoreExceptionTypes(typeof(Exception));

            //while (wait.Until(d=>d.FindElements(By.XPath(""))).Count>0)
            //{
            //    wait.Until(d => d.FindElement(By.Id("hello"))).Click(); //delete icon click

            //    wait.Until(d => d.FindElement(By.Id("confirm"))).Click();
            //}

            bool check = false;
            for(int i = 0; i <=5; i++)
            {
                try
                {
                    try
                    {
                        driver.FindElement(By.Id("hello")).Click();
                        check = true;
                    }
                    catch (Exception ex)
                    {

                    }
                    

                }
                catch (Exception ex)
                {
                    i = i-1;
                }
            }


            //first xpath - 
            //30
            //
            //after click on edit 
            //driver.findelement("xpath").click();
            //action(ctrl+a+backspace)
            //driver.findelement("xpath").sendkeys(10).click();

        }
    }
}
