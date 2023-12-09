﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.Debugger;
using OpenQA.Selenium.Edge;

namespace GoogleMapsTesting.Helpers
{
    public class BrowserHelper
    {
        private Logger _logger;
        private string _location;
        private TimeSpan _timeout;

        public BrowserHelper(Logger logger, int timeout = 60)
        {
            _location = Path.GetDirectoryName(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "drivers"));
            _logger = logger;
            _timeout = new TimeSpan(0,0,timeout);
        }

        public enum BrowserType
        {
            Firefox,
            Chrome,
            Edge
        }

        private WebDriver ChromeBrowser()
        {
            ChromeOptions chromeOptions = new ChromeOptions()
            {
                LeaveBrowserRunning = false
            };
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService(_location);
            chromeDriverService.LogPath = Path.Combine(_logger.FilePath, "chromedriver.log");
            chromeDriverService.EnableVerboseLogging = true;
            return new ChromeDriver(chromeDriverService, chromeOptions, _timeout);
        }

        private EdgeDriver EdgeBrowser()
        {
            EdgeOptions edgeOptions = new EdgeOptions()
            {
                LeaveBrowserRunning = false
            };
            string edgeDriverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.Combine("drivers", "msedgedriver.exe"));
            System.Environment.SetEnvironmentVariable("webdriver.edge.driver", edgeDriverPath);
            EdgeDriverService edgeDriverService = EdgeDriverService.CreateDefaultService(_location);
            edgeDriverService.LogPath = Path.Combine(_logger.FilePath, "edgedriver.log");
            return new EdgeDriver(edgeDriverService, edgeOptions, _timeout);
        }

        public IWebDriver LoadBrowser(BrowserType browser)
        {
            IWebDriver? driver = null;
            switch (browser)
            {
                case BrowserType.Chrome:
                    driver = ChromeBrowser();
                    break;
                case BrowserType.Edge:
                    driver = EdgeBrowser();
                    break;
                //here should be the implementation of other types of browsers
            }
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
