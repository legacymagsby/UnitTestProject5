using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject5
{
    [Binding]
    public class CBTSteps
    {
        protected RemoteWebDriver driver;

        // Your username and authkey here
        public string username = "daphnem@crossbrowsertesting.com";
        public string authkey = "u3a5e9a173dfe45a";
        RemoteSessionSettings caps = new RemoteSessionSettings();


        [Given(@"I navigate to the page ""(.*)""")]
        public void GivenINavigateToThePage(string p0)
        {
            //ScenarioContext.Current.Pending();
            caps.AddMetadataSetting("name", "SpecFlow Test");
            caps.AddMetadataSetting("username", username);
            caps.AddMetadataSetting("password", authkey);
            caps.AddMetadataSetting("browserName", "Chrome");
            caps.AddMetadataSetting("version", "72");
            caps.AddMetadataSetting("platform", "Windows 10");
            caps.AddMetadataSetting("screen_resolution", "1024x768");
            caps.AddMetadataSetting("record_video", "true");

            driver = new RemoteWebDriver(new Uri("http://hub.crossbrowsertesting.com:80/wd/hub"), caps, TimeSpan.FromSeconds(180));

            // Navigate to site
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(p0);
        }

        [Then(@"I see the page is loaded")]
        public void ThenISeeThePageIsLoaded()
        {
            //ScenarioContext.Current.Pending();
            Assert.AreEqual("Google", driver.Title);
            driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(15));
            driver.Quit();
        }


    }
}
