using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
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
    public class Demo3NativeAppTest
    {
        [TestMethod]
        //basic native app operation using xpath
        public void khanInvalidCredentialTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("app", @"C:\Components\khan-academy-7-3-2.apk");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
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
        public void OpenAppTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("appPackage", "org.khanacademy.android");
            option.AddAdditionalCapability("appActivity", "org.khanacademy.android.ui.library.MainActivity");

            //option.AddAdditionalCapability("noReset", true);

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            if (driver.FindElementsByXPath("//*[@text='Dismiss']").Count > 0)
            {
                driver.FindElementByXPath("//*[@text='Dismiss']").Click();
            }

            driver.FindElementByXPath("//*[@text='Sign in']").Click();

            Thread.Sleep(5000);
            driver.Quit();
        }

        [TestMethod]
        public void OpenZomatoAppTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("appPackage", "com.application.zomato");
            option.AddAdditionalCapability("appActivity", "com.application.zomato.activities.Splash");

            option.AddAdditionalCapability("noReset", true);

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [TestMethod]
        public void SignUpTest()
        {

            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("app", @"C:\Components\khan-academy-7-3-2.apk");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.FindElementByXPath("//*[@text='Dismiss']").Click();
            //click on settings icon
            driver.FindElementByXPath("//*[@content-desc='Settings']").Click();
            //click on sign in 
            driver.FindElementByXPath("//*[@text='Sign in']").Click();
            //click on sign up with email
            driver.FindElementByXPath("//*[@text='Sign up with email']").Click();

            driver.FindElementByAndroidUIAutomator("UiSelector().text(\"First name\")").SendKeys("Balaji");

            driver.FindElementByAndroidUIAutomator("UiSelector().textContains(\"Last\")").SendKeys("Dinakaran");

            //date - 2 aug 1999
            driver.FindElementByXPath("//*[@text='Birthday']").Click();

            driver.FindElementByXPath("//*[@resource-id='android:id/numberpicker_input']").Click();
            driver.FindElementByXPath("//*[@resource-id='android:id/numberpicker_input']").Clear();
            driver.FindElementByXPath("//*[@resource-id='android:id/numberpicker_input']").SendKeys("02");

            //month as Aug

            driver.FindElementByAndroidUIAutomator("UiSelector().resourceId(\"android:id/numberpicker_input\").instance(1)").Click();
            driver.FindElementByAndroidUIAutomator("UiSelector().resourceId(\"android:id/numberpicker_input\").instance(1)").Clear();
            driver.FindElementByAndroidUIAutomator("UiSelector().resourceId(\"android:id/numberpicker_input\").instance(1)").SendKeys("Aug");

            // year as 1999
            driver.FindElementByXPath("(//*[@resource-id='android:id/numberpicker_input'])[3]").Click();
            driver.FindElementByXPath("(//*[@resource-id='android:id/numberpicker_input'])[3]").Clear();
            driver.FindElementByXPath("(//*[@resource-id='android:id/numberpicker_input'])[3]").SendKeys("1999");

            driver.FindElementByXPath("//*[@text='OK']").Click();

            driver.FindElementByAndroidUIAutomator("UiSelector().descriptionContains(\"Email\")").SendKeys("ba@gmail.com");

            driver.FindElementByAndroidUIAutomator("UiSelector().description(\"Password\")").SendKeys("123");

            driver.FindElementByXPath("//*[@text='CREATE']").Click();
            //get the message shown
        }

        [TestMethod]
        public void SignUp2Test()
        {

            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("app", @"C:\Components\khan-academy-7-3-2.apk");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


            driver.FindElementByXPath("//*[@text='Dismiss']").Click();
            //click on settings icon
            driver.FindElementByXPath("//*[@content-desc='Settings']").Click();
            //click on sign in 
            driver.FindElementByXPath("//*[@text='Sign in']").Click();
            //click on sign up with email
            driver.FindElementByXPath("//*[@text='Sign up with email']").Click();

            driver.FindElementByAndroidUIAutomator("UiSelector().text(\"First name\")").SendKeys("Balaji");

            driver.FindElementByAndroidUIAutomator("UiSelector().textContains(\"Last\")").SendKeys("Dinakaran");

            //date - 2 aug 1999
            driver.FindElementByXPath("//*[@text='Birthday']").Click();


            List<String> colors = new List<string>();
            colors.Add("red");
            colors.Add("yellow");

            Console.WriteLine(colors.Count);
            Console.WriteLine(colors[0]);
            Console.WriteLine(colors.ElementAt(0));

            //
            // ReadOnlyCollection<IWebElement> elements = (ReadOnlyCollection<IWebElement>)driver.FindElementsByAndroidUIAutomator("//*[@resource-id='android:id/numberpicker_input']");
            ReadOnlyCollection<IWebElement> elements = driver.FindElementsByXPath("//*[@resource-id='android:id/numberpicker_input']");
            elements[0].Click();
            elements[0].Clear();
            elements[0].SendKeys("02");

            elements[1].Click();
            elements[1].Clear();
            elements[1].SendKeys("Aug");

            elements[2].Click();
            elements[2].Clear();
            elements[2].SendKeys("1999");

            IReadOnlyCollection<IWebElement> elements1 = driver.FindElementsByAndroidUIAutomator("UiSelector().resourceId(\"android:id/numberpicker_input\")");

            elements1.ElementAt(0).Click();
            elements1.ElementAt(0).Clear();
            elements1.ElementAt(0).SendKeys("02");

            elements1.ElementAt(1).Click();
            elements1.ElementAt(1).Clear();
            elements1.ElementAt(1).SendKeys("Aug");

            elements1.ElementAt(2).Click();
            elements1.ElementAt(2).Clear();
            elements1.ElementAt(2).SendKeys("2000");

            driver.FindElementByXPath("//*[@text='OK']").Click();

            driver.FindElementByAndroidUIAutomator("UiSelector().descriptionContains(\"Email\")").SendKeys("ba@gmail.com");

            driver.FindElementByAndroidUIAutomator("UiSelector().description(\"Password\")").SendKeys("123");

            driver.FindElementByXPath("//*[@text='CREATE']").Click();
            //get the message shown
        }

        [TestMethod]
        public void SignUp3Test()
        {

            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("app", @"C:\Components\khan-academy-7-3-2.apk");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.FindElementByXPath("//*[@text='Dismiss']").Click();
            //click on settings icon
            driver.FindElementByXPath("//*[@content-desc='Settings']").Click();
            //click on sign in 
            driver.FindElementByXPath("//*[@text='Sign in']").Click();
            //click on sign up with email
            driver.FindElementByXPath("//*[@text='Sign up with email']").Click();

            driver.FindElementByAndroidUIAutomator("UiSelector().text(\"First name\")").SendKeys("Balaji");

            driver.FindElementByAndroidUIAutomator("UiSelector().textContains(\"Last\")").SendKeys("Dinakaran");

            //date - 2 aug 1999
            driver.FindElementByXPath("//*[@text='Birthday']").Click();

            string dayXpath = "";
            string monthXpath = "";

            if(driver.FindElementByXPath("(//*[@resource-id='android:id/numberpicker_input'])[1]").Text.Length==2)
            {
                dayXpath = "(//*[@resource-id='android:id/numberpicker_input'])[1]";
                monthXpath = "(//*[@resource-id='android:id/numberpicker_input'])[2]";
            }
            else
            { 
                monthXpath = "(//*[@resource-id='android:id/numberpicker_input'])[1]";
                dayXpath = "(//*[@resource-id='android:id/numberpicker_input'])[2]";
            }

            //setting the day as 08 by checking the text 
            int count = 1;
            while(! driver.FindElementByXPath(dayXpath).Text.Equals("08") && count<=50)  // not 08
            {
                driver.FindElementByXPath(dayXpath).Click();
                driver.FindElementByXPath(dayXpath).Clear();
                driver.FindElementByXPath(dayXpath).SendKeys("08");
                count++;
            }
            

            //month as Aug

            driver.FindElementByXPath(monthXpath).Click();
            driver.FindElementByXPath(monthXpath).Clear();
            driver.FindElementByXPath(monthXpath).SendKeys("Aug");


            // year as 1999
            driver.FindElementByXPath("(//*[@resource-id='android:id/numberpicker_input'])[3]").Click();
            driver.FindElementByXPath("(//*[@resource-id='android:id/numberpicker_input'])[3]").Clear();
            driver.FindElementByXPath("(//*[@resource-id='android:id/numberpicker_input'])[3]").SendKeys("1999");

            driver.FindElementByXPath("//*[@text='OK']").Click();

            driver.FindElementByAndroidUIAutomator("UiSelector().descriptionContains(\"Email\")").SendKeys("ba@gmail.com");

            driver.FindElementByAndroidUIAutomator("UiSelector().description(\"Password\")").SendKeys("123");

            driver.FindElementByXPath("//*[@text='CREATE']").Click();
            //get the message shown
        }

    }
}
