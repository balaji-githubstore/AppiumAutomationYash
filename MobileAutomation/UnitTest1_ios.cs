using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.MultiTouch;

namespace AppiumIosProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void HealthAppTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "ios");
            option.AddAdditionalCapability("deviceName", "iPhone 11");
            option.AddAdditionalCapability("bundleId", "com.apple.Health");
            option.AddAdditionalCapability("automationName", "XCUITest");


            IOSDriver<IWebElement> driver = new IOSDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.FindElementByXPath("//*[@name='Edit']").Click();
            driver.FindElementByXPath("//*[@name='All']").Click();

            //if count is 0 then only element in UI is picked as app source
            //Console.WriteLine(driver.FindElementsByXPath("//*[@name='Selenium']").Count);

            Size size = driver.Manage().Window.Size;

            Console.WriteLine(size);
            Console.WriteLine(size.Width);
            Console.WriteLine(size.Height);
            //scroll based on presence of element 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (driver.FindElementsByXPath("//*[@name='Selenium']").Count == 0)
            {
                TouchAction action = new TouchAction(driver);
                action.Press(size.Width / 2, size.Height * 0.75)
                    .Wait(1000).MoveTo(size.Width / 2, size.Height * 0.25)
                    .Release().Perform();
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElementByXPath("//*[@name='Selenium']").Click();

            Thread.Sleep(5000);
            driver.Quit();
        }

        [TestMethod]
        public void SauceTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "ios");
            option.AddAdditionalCapability("deviceName", "iPhone 11");
            option.AddAdditionalCapability("app", "/Users/balaji/Documents/Company/ios app/iOS.Simulator.SauceLabs.Mobile.Sample.app.2.7.1.app");
            option.AddAdditionalCapability("automationName", "XCUITest");

            IOSDriver<IWebElement> driver = new IOSDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.FindElementByXPath("//*[@value='Username']").SendKeys("standard_user");
            driver.FindElementByXPath("//*[@name='test-Password']").SendKeys("secret_sauce");
            driver.FindElementByXPath("//*[@name='test-LOGIN']").Click();

            driver.FindElementByName("test-ADD TO CART").Click();
            driver.FindElementByName("test-ADD TO CART").Click();
            driver.FindElementByName("test-ADD TO CART").Click();
            driver.FindElementByName("test-ADD TO CART").Click();

            driver.FindElementByXPath("//XCUIElementTypeOther[@name='test-Cart']").Click();

            //test-CHECKOUT
            Console.WriteLine(driver.FindElementsByXPath("//*[@name='test-CHECKOUT']").Count);
            Console.WriteLine(driver.FindElementByXPath("//*[@name='test-CHECKOUT']").Displayed);

            Size size = driver.Manage().Window.Size;

            //scroll based on visibilty 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (driver.FindElementByXPath("//*[@name='test-CHECKOUT']").Displayed == false)
            {
                TouchAction action = new TouchAction(driver);
                action.Press(size.Width / 2, size.Height * 0.75)
                    .Wait(1000).MoveTo(size.Width / 2, size.Height * 0.25)
                    .Release().Perform();
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.FindElementByXPath("//*[@name='test-CHECKOUT']").Click();

            //name=test-ADD TO CART
            Thread.Sleep(15000);
            driver.Quit();
        }


        [TestMethod]
        public void SauceXCUICommandsTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "ios");
            option.AddAdditionalCapability("deviceName", "iPhone 11");
            option.AddAdditionalCapability("app", "/Users/balaji/Documents/Company/ios app/iOS.Simulator.SauceLabs.Mobile.Sample.app.2.7.1.app");
            option.AddAdditionalCapability("automationName", "XCUITest");

            IOSDriver<IWebElement> driver = new IOSDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.FindElementByXPath("//*[@value='Username']").SendKeys("standard_user");
            driver.FindElementByXPath("//*[@name='test-Password']").SendKeys("secret_sauce");
            driver.FindElementByXPath("//*[@name='test-LOGIN']").Click();

            driver.FindElementByName("test-ADD TO CART").Click();
            driver.FindElementByName("test-ADD TO CART").Click();
            driver.FindElementByName("test-ADD TO CART").Click();
            driver.FindElementByName("test-ADD TO CART").Click();

            driver.FindElementByXPath("//XCUIElementTypeOther[@name='test-Cart']").Click();

            //test-CHECKOUT
            Console.WriteLine(driver.FindElementsByXPath("//*[@name='test-CHECKOUT']").Count);
            Console.WriteLine(driver.FindElementByXPath("//*[@name='test-CHECKOUT']").Displayed);

            //scroll based on visibilty
            //scroll using xcuicommands 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (driver.FindElementByXPath("//*[@name='test-CHECKOUT']").Displayed == false)
            {
                Dictionary<string, string> dic1 = new Dictionary<string, string>();
                dic1.Add("direction", "down");
                driver.ExecuteScript("mobile: scroll", dic1);
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);


            driver.FindElementByXPath("//*[@name='test-CHECKOUT']").Click();


            //driver.CloseApp();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("bundleId", "com.apple.Health");
            dynamic output = driver.ExecuteScript("mobile: launchApp", dic);
            //Console.WriteLine(output);

            Thread.Sleep(5000);
            driver.ExecuteScript("mobile: terminateApp", dic);
            Console.WriteLine(output);
            //Console.WriteLine(driver.Capabilities);


            //name=test-ADD TO CART
            //Thread.Sleep(15000);
            driver.Quit();
        }

        [TestMethod]
        public void RealDeviceTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "ios");
            option.AddAdditionalCapability("deviceName", "iPhone 11");
            option.AddAdditionalCapability("bundleId", "org.khanacademy.Khan-Academy");
            option.AddAdditionalCapability("automationName", "XCUITest");
            option.AddAdditionalCapability("udid", "417da800b3114ff6776f5c37c65974d071364376");

            IOSDriver<IWebElement> driver = new IOSDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.FindElementByIosNsPredicate("name=='Search'  and label=='Search'").Click();
            driver.FindElementByXPath("//XCUIElementTypeOther[@name='Math']/XCUIElementTypeButton[@name='Math']").Click();

            Thread.Sleep(5000);
            var elements = driver.FindElementsByXPath("//XCUIElementTypeButton");

            foreach (var ele in elements)
            {
                Console.WriteLine(ele.Text);
            }

            Dictionary<string, string> dic1 = new Dictionary<string, string>();
            dic1.Add("direction", "down");
            dic1.Add("name", "Get ready for 3rd grade");
            driver.ExecuteScript("mobile: scroll", dic1);

            Thread.Sleep(5000);
            driver.Quit();
        }


        ///name=="Search"  and label=="Search"
        //XCUIElementTypeOther[@name="Math"]/XCUIElementTypeButton
        //XCUIElementTypeOther[@name="Math"]/XCUIElementTypeButton[@name='Math']

        [TestMethod]
        public void HealthAppCommandTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "ios");
            option.AddAdditionalCapability("deviceName", "iPhone 11");
            option.AddAdditionalCapability("bundleId", "com.apple.Health");
            option.AddAdditionalCapability("automationName", "XCUITest");


            IOSDriver<IWebElement> driver = new IOSDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.FindElementByXPath("//*[contains(@name,'Selenium')]").Click();
            driver.FindElementByXPath("//*[@name='Add Data']").Click();

            IOSElement element= (IOSElement)driver.FindElementByXPath("//*[@name='Date']");

            Dictionary<string, object> cmd = new Dictionary<string, object>();
            cmd.Add("elementId",element.Id);

            driver.ExecuteScript("mobile: doubleTap", cmd);

        }

        [TestMethod]
        public void HealthApp2CommandTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "ios");
            option.AddAdditionalCapability("deviceName", "iPhone 11");
            option.AddAdditionalCapability("bundleId", "com.apple.Health");
            option.AddAdditionalCapability("automationName", "XCUITest");


            IOSDriver<IOSElement> driver = new IOSDriver<IOSElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.FindElementByXPath("//*[contains(@name,'Selenium')]").Click();
            driver.FindElementByXPath("//*[@name='Add Data']").Click();

            IOSElement element = driver.FindElementByXPath("//*[@name='Date']");

            Dictionary<string, object> cmd = new Dictionary<string, object>();
            cmd.Add("elementId", element.Id);


            driver.ExecuteScript("mobile: doubleTap", cmd);
        }

        [TestMethod]
        public void RealDevicePickerTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "ios");
            option.AddAdditionalCapability("deviceName", "iPhone 11");
            option.AddAdditionalCapability("bundleId", "com.apple.mobiletimer");
            option.AddAdditionalCapability("automationName", "XCUITest");
            option.AddAdditionalCapability("udid", "417da800b3114ff6776f5c37c65974d071364376");

            IOSDriver<IWebElement> driver = new IOSDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //*[@name='Timer']
            IOSElement element = (IOSElement)driver.FindElementByXPath("//XCUIElementTypePickerWheel");
            Dictionary<string, object> cmd = new Dictionary<string, object>();
            cmd.Add("elementId", element.Id);
            cmd.Add("order", "next");
            cmd.Add("offset", 0.15);


            driver.ExecuteScript("mobile: selectPickerWheelValue", cmd);
            driver.ExecuteScript("mobile: selectPickerWheelValue", cmd);
            driver.ExecuteScript("mobile: selectPickerWheelValue", cmd);

            element = (IOSElement)driver.FindElementByXPath("(//XCUIElementTypePickerWheel)[2]");
                
            //element = (IOSElement)driver.FindElementsByXPath("//XCUIElementTypePickerWheel")[1];
            cmd.Clear();
            cmd.Add("elementId", element.Id);
            cmd.Add("order", "next");
            cmd.Add("offset", 0.15);


            driver.ExecuteScript("mobile: selectPickerWheelValue", cmd);
            driver.ExecuteScript("mobile: selectPickerWheelValue", cmd);
            driver.ExecuteScript("mobile: selectPickerWheelValue", cmd);

            string value=element.GetAttribute("value");
            Console.WriteLine(value);

            element.SendKeys("9 min");

            element = (IOSElement)driver.FindElementByXPath("(//XCUIElementTypePickerWheel)[3]");
            element.SendKeys("5 sec");
        }
    }
}
