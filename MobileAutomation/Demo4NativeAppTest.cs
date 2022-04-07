using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobileAutomation
{
    [TestClass]
    public class Demo4NativeAppTest
    {
        [TestMethod]
        public void KhanSwipeTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("app", @"C:\Components\khan-academy-7-3-2.apk");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            if (driver.FindElementsByXPath("//*[@text='Dismiss']").Count > 0)
            {
                driver.FindElementByXPath("//*[@text='Dismiss']").Click();
            }

            //search using content desc
            //driver.FindElementByAccessibilityId("Search tab").Click();  

            //search using resource-id
            driver.FindElementById("org.khanacademy.android:id/tab_bar_button_search").Click();

            driver.FindElementByXPath("//*[@text='Arts and humanities']").Click();


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (driver.FindElementsByXPath("//*[@text='Art of Asia']").Count == 0)
            {
                TouchAction action = new TouchAction(driver);
                action.Press(1003, 1043).Wait(1000).MoveTo(1003, 731).Release().Perform();
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElementByXPath("//*[@text='Art of Asia']").Click();

            //swipe and click
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (driver.FindElementsByXPath("//*[contains(@text,'Hima')]").Count == 0)
            {
                TouchAction action = new TouchAction(driver);
                action.Press(1003, 1043).Wait(1000).MoveTo(1003, 731).Release().Perform();
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElementByXPath("//*[contains(@text,'Hima')]").Click();

            //swipe and click on Cabinet for storing offerings 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (driver.FindElementsByXPath("//*[contains(@text,'storing offer')]").Count == 0)
            {
                TouchAction action = new TouchAction(driver);
                action.Press(1003, 1043).Wait(1000).MoveTo(1003, 731).Release().Perform();
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElementByXPath("//*[contains(@text,'storing offer')]").Click();
        }

        [TestMethod]
        public void KhanSwipeUpdateTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("app", @"C:\Components\khan-academy-7-3-2.apk");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            if (driver.FindElementsByXPath("//*[@text='Dismiss']").Count > 0)
            {
                driver.FindElementByXPath("//*[@text='Dismiss']").Click();
            }

            //search using content desc
            driver.FindElementByAccessibilityId("Search tab").Click();

            driver.FindElementByXPath("//*[@text='Arts and humanities']").Click();


            Size size = driver.Manage().Window.Size;

            Console.WriteLine(size);
            Console.WriteLine(size.Width);
            Console.WriteLine(size.Height);

            double x1 = size.Width / 2;
            double y1 = size.Height * 0.75;

            double x2 = size.Width / 2;
            double y2 = size.Height * 0.25;

            Console.WriteLine(x1);
            Console.WriteLine(y1);
            Console.WriteLine(x2);
            Console.WriteLine(y2);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (driver.FindElementsByXPath("//*[@text='Art of Asia']").Count == 0)
            {
                TouchAction action = new TouchAction(driver);
                action.Press(x1, y1).Wait(1000).MoveTo(x2, y2).Release().Perform();
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElementByXPath("//*[@text='Art of Asia']").Click();



        }

        [TestMethod]
        public void KhanSwipeUiScrollableTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("app", @"C:\Components\khan-academy-7-3-2.apk");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            if (driver.FindElementsByXPath("//*[@text='Dismiss']").Count > 0)
            {
                driver.FindElementByXPath("//*[@text='Dismiss']").Click();
            }

            //search using content desc
            driver.FindElementByAccessibilityId("Search tab").Click();

            driver.FindElementByXPath("//*[@text='Arts and humanities']").Click();

            string visible_text = "Asia";

            driver.FindElementByAndroidUIAutomator(
                                        "new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().textContains(\"" + visible_text + "\").instance(0))").Click();
            visible_text = "Hima";

            driver.FindElementByAndroidUIAutomator(
                                        "new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().textContains(\"" + visible_text + "\").instance(0))").Click();

        }

        [TestMethod]
        public void KhanSwipeUiCommandsTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("app", @"C:\Components\khan-academy-7-3-2.apk");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            if (driver.FindElementsByXPath("//*[@text='Dismiss']").Count > 0)
            {
                driver.FindElementByXPath("//*[@text='Dismiss']").Click();
            }

            driver.FindElementByAccessibilityId("Search tab").Click();
            driver.FindElementByXPath("//*[@text='Arts and humanities']").Click();

            //add arguments 
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("strategy", "-android uiautomator");
            dic.Add("selector", "UiSelector().textContains(\"Asia\")");

            //execute mobile scroll command based on arguments 
            driver.ExecuteScript("mobile: scroll", dic);

            //click on Art Of Asia
            driver.FindElementByXPath("//*[@text='Art of Asia']").Click();

            dic.Clear();

            dic = new Dictionary<string, object>();
            //dic.Add("strategy", "xpath");
            //dic.Add("selector", By.XPath("//*[contains(@text,'Hima')]"));
            dic.Add("strategy", "-android uiautomator");
            dic.Add("selector", "UiSelector().textContains(\"Hima\")");

            //execute mobile scroll command based on arguments 
            driver.ExecuteScript("mobile: scroll", dic);


            driver.FindElementByXPath("//*[contains(@text,'Hima')]").Click();
        }


        [TestMethod]
        public void listSmsTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("app", @"C:\Components\khan-academy-7-3-2.apk");
            option.AddAdditionalCapability("app", @"C:\Components\khan-academy-7-3-2.apk");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("max", 2);
            object obj=  driver.ExecuteScript("mobile: listSms", dic);
            Console.WriteLine(obj);
            //string sms = Convert.ToString(obj);
            //Console.WriteLine(driver.ExecuteScript("mobile: listSms", dic));

            //dynamic output= driver.ExecuteScript("mobile: listSms", dic);

            //Console.WriteLine(output["Items"]);
            //Console.WriteLine(output[0].Value);
            //Console.WriteLine(output[0].Value[1]);
        }

        [TestMethod]
        public void KhanSwipeAdbTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("app", @"C:\Components\khan-academy-7-3-2.apk");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //if (driver.FindElementsByXPath("//*[@text='Dismiss']").Count > 0)
            //{
            //    driver.FindElementByXPath("//*[@text='Dismiss']").Click();
            //}

            //driver.FindElementById("org.khanacademy.android:id/tab_bar_button_search").Click();

            //driver.FindElementByXPath("//*[@text='Arts and humanities']").Click();

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("command", "input touchscreen swipe 1000 500 1000 200");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (driver.FindElementsByXPath("//*[@text='Art of Asia']").Count == 0)
            {
               
                driver.ExecuteScript("mobile: shell", dic);
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElementByXPath("//*[@text='Art of Asia']").Click();
        }



        [TestMethod]
        public void OpenApp1Test()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("appPackage", "com.medplus.mobile.android");
            option.AddAdditionalCapability("appActivity", "com.medplus.mobile.android.MainActivity");

            option.AddAdditionalCapability("noReset", true);

            AndroidDriver <IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //add arguments 
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("strategy", "-android uiautomator");
            dic.Add("selector", "UiSelector().textContains(\"Flexi\")");

            //execute mobile scroll command based on arguments 
            driver.ExecuteScript("mobile: scroll", dic);

            //click on Art Of Asia
            driver.FindElementByAndroidUIAutomator("UiSelector().textContains(\"Flexi\")").Click();

            driver.FindElementByAndroidUIAutomator("UiSelector().textContains(\"Sort\")").Click();

            //driver.FindElementByAndroidUIAutomator("UiSelector().textContains(\"PERSONAL\")").Click();
            Thread.Sleep(5000);

            //266, 1844
            //not stable to run in different 
            TouchAction action = new TouchAction(driver);
            action.Tap(266, 1844, 1).Perform();
            
            //action.Tap(x: 266, y: 1844, count: 1).Perform();

            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
