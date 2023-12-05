using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static GoogleMapsTesting.Helpers.BrowserHelper;

namespace GoogleMapsTesting.Helpers
{
    [Binding]
    internal class TestHooks
    {
        public static BrowserType browser;
        private readonly IObjectContainer objectContainer;
        public static IWebDriver webDriver;
        public static Logger logger;

        public TestHooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void StartBrowser()
        {
            logger = new Logger(TestContext.CurrentContext.Test.FullName);
            webDriver = new BrowserHelper(logger).LoadBrowser(new SettingsHelper().Browser);
            objectContainer.RegisterInstanceAs<Logger>(logger);
            objectContainer.RegisterInstanceAs<IWebDriver>(webDriver);
            objectContainer.Resolve<SettingsHelper>();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Logger logger = objectContainer.Resolve<Logger>();
            IWebDriver webDriver = objectContainer.Resolve<IWebDriver>();
            var screenshot = Path.Combine(logger.FilePath, "Screenshot.png");
            Screenshot testScreenShot = ((ITakesScreenshot)webDriver).GetScreenshot();
            testScreenShot.SaveAsFile(screenshot, ScreenshotImageFormat.Png);
            foreach (var file in Directory.GetFiles(logger.FilePath))
            webDriver.Dispose();
            webDriver.Quit();
        }
    }

}
