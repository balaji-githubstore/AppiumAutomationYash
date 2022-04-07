using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobileAutomation
{
    [TestClass]
    public class Demo5AndroidAppTest
    {
        [TestMethod]
        public void TouchActionTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("app", @"C:\Components\khan-academy-7-3-2.apk");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            // driver.FindElementByXPath("//*[@text='Dismiss']").Click();
            //click on settings icon
            driver.FindElementByXPath("//*[@content-desc='Settings']").Click();

            //try with findelement and click --> use this otherwise tap 
            //driver.FindElementByXPath("//*[@text='OFF']").Click();

            //wait for correct screen 
            Thread.Sleep(3000);
            TouchAction action = new TouchAction(driver);
            //action.Tap(953, 839,5).Perform();
            // action.Tap(driver.FindElementByXPath("//*[@text='OFF']"), count:5).Perform();

            driver.PressKeyCode(AndroidKeyCode.Home);

            action.LongPress(driver.FindElementByXPath("//*[contains(@text,'Blue Li')]")).Perform();

            driver.FindElementByXPath("//*[contains(@text,'App info')]").Click();

            Thread.Sleep(3000);
            driver.Quit();
        }

        [TestMethod]
        public void HybridAppTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("appPackage", "com.ltts.myts");
            option.AddAdditionalCapability("appActivity", "android.support.customtabs.trusted.LauncherActivity");
            option.AddAdditionalCapability("chromedriverExecutable", @"C:\Components\chromedriver_win32\chromedriver.exe");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);

            //driver is controlling the below view 
            string context = driver.Context;
            Console.WriteLine(context);
            Console.WriteLine("--------------------");
            Thread.Sleep(5000);

            //all the context in the current screen
            ReadOnlyCollection<string> allViews = driver.Contexts;

            foreach (string view in allViews)
            {
                Console.WriteLine(view);
            }

            //switch to webview
            driver.Context = "WEBVIEW_chrome";

            string pageSource = driver.PageSource;

            //driver.ExecuteScript("document.querySelector('[type=email]').value='hello@gmail.com'");

            driver.FindElementByXPath("//*[@type='email']").SendKeys("hello@gmail.com");
            driver.FindElementByXPath("//*[@type='submit']").Click();

        }


        [TestMethod]
        public void HybridApp2Test()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("appPackage", "com.ltts.myts");
            option.AddAdditionalCapability("appActivity", "android.support.customtabs.trusted.LauncherActivity");
            option.AddAdditionalCapability("chromedriverExecutable", @"C:\Components\chromedriver_win32\chromedriver.exe");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //driver is controlling the below view 
            string context = driver.Context;
            Console.WriteLine(context);
            Console.WriteLine("--------------------");
            Thread.Sleep(5000);

            //all the context in the current screen
            ReadOnlyCollection<string> allViews = driver.Contexts;

            foreach (string view in allViews)
            {
                Console.WriteLine(view);
                driver.Context = view;
                if (driver.FindElementsByXPath("//*[@type='email']").Count > 0)
                {
                    break;
                }
            }

            string pageSource = driver.PageSource;

            driver.FindElementByXPath("//*[@type='email']").SendKeys("ltdina@gmail.com");
            driver.FindElementByXPath("//*[@type='submit']").Click();


            driver.Context = "NATIVE_APP";
            //allViews = driver.Contexts;

            //foreach (string view in allViews)
            //{
            //    Console.WriteLine(view);
            //    driver.Context = view;
            //    if (driver.FindElementsByXPath("//*[@text='Search']").Count > 0)
            //    {
            //        break;
            //    }
            //}
            driver.FindElementByXPath("//*[@text='Search']").Click();



        }


        
    }
}
