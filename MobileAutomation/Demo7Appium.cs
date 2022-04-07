using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
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
    public class Demo7Appium
    {
        [TestMethod]
        public void AppiumInBuiltMethodsTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("app", @"C:\Components\khan-academy-7-3-2.apk");
            option.AddAdditionalCapability("autoLaunch", "false");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.StartRecordingScreen();



            //package name
            if (driver.IsAppInstalled("com.ltts.myts"))
            {
                Console.WriteLine("yes");
                driver.ActivateApp("com.ltts.myts");
            }
            else
            {
                driver.InstallApp(@"C:\Components\Fetch Pet Care_v4.1.6_apkpure.com.apk");
            }

            Console.WriteLine(driver.DeviceTime);
            Console.WriteLine(driver.Capabilities);
            Console.WriteLine(driver.CurrentActivity);
            Console.WriteLine(driver.CurrentPackage);
            driver.LaunchApp();

            driver.BackgroundApp(TimeSpan.FromSeconds(3));



            driver.FindElementByXPath("//*[@content-desc='Settings']").Click();
            driver.FindElementByXPath("//*[@text='Sign in']").Click();

            string output = driver.StopRecordingScreen();

            File.WriteAllBytes("khan.mp4", Convert.FromBase64String(output));

            Thread.Sleep(5000);
            driver.Quit();
        }

        [TestMethod]
        public void AndroidUiCommands()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            
            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Dictionary<string, object> dic = new Dictionary<string, object>();
            //dic.Add("max", 2);
            //dynamic obj = driver.ExecuteScript("mobile: listSms", dic);
            //Console.WriteLine(obj);

            dynamic output= driver.ExecuteScript("mobile: batteryInfo");
            Console.WriteLine(output["level"]);
            Console.WriteLine(output["state"]);

            output= driver.ExecuteScript("mobile: deviceInfo");
            Console.WriteLine(output);
            Console.WriteLine(output["timeZone"]);
            
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("max", 2);
            dynamic result = driver.ExecuteScript("mobile: listSms", dic);
            Console.WriteLine(result);

            Console.WriteLine(result["items"][0]["body"]);
            Console.WriteLine(result["items"][1]["body"]);
            Console.WriteLine("------");
            foreach(dynamic item in result["items"])
            {
                Console.WriteLine(item["body"]);
            }
        }
    } 
}
