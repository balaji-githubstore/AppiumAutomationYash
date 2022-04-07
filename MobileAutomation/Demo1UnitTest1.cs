using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Threading;
//basic demo
namespace MobileAutomation
{
    [TestClass]
    public class Demo1AndroidAutomation
    {
        [TestMethod]
        public void InstallAppTest()
        {
            AppiumOptions option =new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("app", @"C:\Components\khan-academy-7-3-2.apk");
            //option.AddAdditionalCapability("udid", "emulator-5554");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"),option);

            Console.WriteLine(driver.PageSource);

            Thread.Sleep(5000);
            driver.Quit(); 

        }

        [TestMethod]
        public void WebAppTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("browserName", "chrome");

            //option.AddAdditionalCapability("chromedriverExecutable", @"C:\Components\chromedriver_win32\chromedriver.exe");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Url = "https://nasscom.in/about-us/contact-us"; //set

            //Console.WriteLine(driver.PageSource);
            //driver.FindElement(By.XPath("//a[contains(text(),'New User')]")).Click();

            driver.FindElementByXPath("//a[contains(text(),'New User')]").Click();
            driver.FindElementByXPath("//input[@id='edit-field-fname-reg']").SendKeys("bala");

            //enter lastname as dina
            //enter email address as di@yash.com
            //enter company name as yash
            //select Business focus as IT Consulting 
            //click register 
           

            Console.WriteLine(driver.Url); //get

            Thread.Sleep(5000);
            driver.Quit();
        }

    }
}