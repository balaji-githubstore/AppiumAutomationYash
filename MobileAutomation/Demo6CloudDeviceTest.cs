using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobileAutomation
{
    [TestClass]
    public class Demo6
    {
        [TestMethod]
        //basic native app operation using xpath
        public void khanInvalidCredentialTest()
        {
            AppiumOptions caps = new AppiumOptions();
            // Set your BrowserStack access credentials
            caps.AddAdditionalCapability("browserstack.user", "dinakaranbalaji1");
            caps.AddAdditionalCapability("browserstack.key", "6yXRE4nK1fyvTHWA2kPD");

            // Set URL of the application under test
            caps.AddAdditionalCapability("app", "bs://5e43ce73e62cfbec36559eea60aa4c393be2591f");

            // Specify device and os_version
            caps.AddAdditionalCapability("device", "Samsung Galaxy S10e");
            caps.AddAdditionalCapability("os_version", "9.0");

            // Specify the platform name
            caps.PlatformName = "Android";

            // Set other BrowserStack capabilities
            caps.AddAdditionalCapability("project", "Khan Academy Project - Yash");
            caps.AddAdditionalCapability("build", "Khan Academy Build - Yash");
            caps.AddAdditionalCapability("name", "khan - sign in test - yash");


            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.FindElementByXPath("//*[@text='Dismiss']").Click();
            driver.FindElementByXPath("//*[@text='Sign in']").Click();
            driver.FindElementByXPath("//*[@text='Sign in']").Click();
            driver.FindElementByXPath("//*[@content-desc='Enter an e-mail address or username']").SendKeys("test@gmail.com");
            driver.FindElementByXPath("//*[contains(@text,'Pass')]").SendKeys("pass@123");

            if (driver.IsKeyboardShown())
            {
                driver.HideKeyboard();
            }

            //*[@text='Sign in' and @index='0']
            driver.FindElementByXPath("(//*[@text='Sign in'])[2]").Click();

            String actualError = driver.FindElementByXPath("//*[contains(@text,'issue')]").Text;
            Console.WriteLine(actualError);

            Thread.Sleep(5000);
            driver.Quit();
        }


        [TestMethod]
        //basic native app operation using xpath
        public void SampleAPKTest()
        {
            AppiumOptions caps = new AppiumOptions();
            // Set your BrowserStack access credentials
            caps.AddAdditionalCapability("browserstack.user", "dinakaranbalaji1");
            caps.AddAdditionalCapability("browserstack.key", "6yXRE4nK1fyvTHWA2kPD");

            // Set URL of the application under test
            caps.AddAdditionalCapability("app", "bs://c700ce60cf13ae8ed97705a55b8e022f13c5827c");

            // Specify device and os_version
            caps.AddAdditionalCapability("device", "Samsung Galaxy S10e");
            caps.AddAdditionalCapability("os_version", "9.0");

            // Specify the platform name
            caps.PlatformName = "Android";

            // Set other BrowserStack capabilities
            caps.AddAdditionalCapability("project", "Sample Project - Yash");
            caps.AddAdditionalCapability("build", "Sample Build - Yash");
            caps.AddAdditionalCapability("name", "Sample - test - yash");


            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.FindElementByXPath("//*[@content-desc='More options']").Click();
            Thread.Sleep(5000);
            driver.Quit();


        }

        [TestMethod]
        public void SampleiosTest()
        {
            AppiumOptions caps = new AppiumOptions();
            // Set your BrowserStack access credentials
            caps.AddAdditionalCapability("browserstack.user", "dinakaranbalaji1");
            caps.AddAdditionalCapability("browserstack.key", "6yXRE4nK1fyvTHWA2kPD");

            // Set URL of the application under test
            caps.AddAdditionalCapability("app", "bs://444bd0308813ae0dc236f8cd461c02d3afa7901d");

            // Specify device and os_version
            caps.AddAdditionalCapability("device", "iPhone 11 Pro");
            caps.AddAdditionalCapability("os_version", "13");

            // Specify the platform name
            caps.PlatformName = "iOS";

            // Set other BrowserStack capabilities
            caps.AddAdditionalCapability("project", "Sample ios Project - Yash");
            caps.AddAdditionalCapability("build", "Sample ios Build - Yash");
            caps.AddAdditionalCapability("name", "Sample - ios test - yash");

            IOSDriver<IWebElement> driver = new IOSDriver<IWebElement>(new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.FindElementByXPath("//XCUIElementTypeStaticText[@name='Text']").Click();

            driver.FindElementByXPath("//*[@value='Enter a text']").SendKeys("hello");

            Console.WriteLine(driver.PageSource);

            //click on UI Elements to go back 
            driver.FindElementByXPath("//XCUIElementTypeButton[@name='UI Elements']").Click();
            //driver.FindElementByXPath("(//*[@name='UI Elements'])[2]").Click();
            //driver.FindElementByXPath("(//*[@name='UI Elements'])[2]").Click();

            //driver.Navigate().Back();

            //click on alert
            driver.FindElementByXPath("//*[@name='Alert']").Click();

            ////get the text in the alert 
            string text = driver.FindElementByXPath("//*[contains(@name,'a native')]").Text;
            Console.WriteLine(text);

            ////click on ok
            driver.FindElementByXPath("//*[@name='OK']").Click();

            Thread.Sleep(5000);
            driver.Quit();
           

        }

    }


}
