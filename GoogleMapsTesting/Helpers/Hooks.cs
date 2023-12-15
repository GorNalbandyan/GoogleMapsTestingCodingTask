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

            foreach (var file in Directory.GetFiles(logger.FilePath))
            {
                if (file.ToLower().Contains("screenshot") || file.ToLower().Contains("scenario.log"))
                {
                    File.Delete(file);
                }

            }
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            Logger logger = objectContainer.Resolve<Logger>();
            IWebDriver webDriver = objectContainer.Resolve<IWebDriver>();
            if (scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
            {
                logger.LogWrite($"{TestContext.CurrentContext.Test.Name} test failed with {scenarioContext.TestError.Message} {scenarioContext.TestError.InnerException}");
            }
            var screenshot = Path.Combine(logger.FilePath, "Screenshot.png");
            Screenshot testScreenShot = ((ITakesScreenshot)webDriver).GetScreenshot();
            testScreenShot.SaveAsFile(screenshot, ScreenshotImageFormat.Png);
            foreach (var file in Directory.GetFiles(logger.FilePath))
            {
                if (file.ToLower().Contains("screenshot") || file.ToLower().Contains("log"))
                {
                    TestContext.AddTestAttachment(file);
                }

            }
            webDriver.Quit();
        }
    }

}
