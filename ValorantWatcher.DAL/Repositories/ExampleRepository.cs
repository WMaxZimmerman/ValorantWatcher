using System;
using System.IO;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ValorantWatcher.DAL.Repositories
{
    public class ExampleRepository
    {
        private string _mainUrl = "https://www.twitch.tv/";
        private ChromeDriver _driver;

        public ExampleRepository()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }
        
        public string HelloWorld()
        {
            LogIn();
            _driver.Close();
            
            return "Hello World";
        }

        private void LogIn()
        {
            _driver.Navigate().GoToUrl(_mainUrl);
            var loginButton = _driver.FindElementByCssSelector("button[data-a-target=\"login-button\"]");
            loginButton.Click();
            Thread.Sleep(3000);
            
            var usernameTextbox = _driver.FindElementById("login-username");
            var passwordTextbox = _driver.FindElementById("password-input");

            usernameTextbox.SendKeys("");
            passwordTextbox.SendKeys("");

            var submitButton = _driver.FindElementByCssSelector("button[data-a-target=\"passport-login-button\"]");
            submitButton.Click();
            
            Thread.Sleep(10000);
        }

        private void NavigateToValiantStreams()
        {
            var valorantUrl = $"{_mainUrl}directory/game/VALORANT?sort=VIEWER_COUNT&tl=c2542d6d-cd10-4532-919b-3d19f30a768b";
            _driver.Navigate().GoToUrl(valorantUrl);
            // var link = driver.FindElement(By.PartialLinkText("TFS Test API"));
            // var jsToBeExecuted = $"window.scroll(0, {link.Location.Y});";
            // ((IJavaScriptExecutor)driver).ExecuteScript(jsToBeExecuted);
            var wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(1));
            Thread.Sleep(10000);
            // var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText("TFS Test API")));
            // clickableElement.Click();
        }
    }
}
