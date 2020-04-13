using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ValorantWatcher.Shared.Models;

namespace ValorantWatcher.DAL.Repositories
{
    public class ExampleRepository
    { 
        private string _mainUrl = "https://www.twitch.tv/";
        private static List<string> _streamUrls = null;
        private static ChromeDriver _driver = null;

        public ExampleRepository()
        {
            if (_driver == null)
            {
                _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                _driver.Manage().Window.Maximize();
            }

            if (_streamUrls == null)
            {
                _streamUrls = new List<string>();
            }
        }
        
        public void Open()
        {
            _driver.Navigate().GoToUrl(_mainUrl);
        }
        
        public void Close()
        {
            _driver.Close();
            _driver = null;
        }

        public void LogIn(User user)
        {
            _driver.Navigate().GoToUrl(_mainUrl);
            var loginButton = _driver.FindElementByCssSelector("button[data-a-target=\"login-button\"]");
            loginButton.Click();
            Thread.Sleep(3000);
            
            var usernameTextbox = _driver.FindElementById("login-username");
            var passwordTextbox = _driver.FindElementById("password-input");

            usernameTextbox.SendKeys(user.Name);
            passwordTextbox.SendKeys(user.Password);

            var submitButton = _driver.FindElementByCssSelector("button[data-a-target=\"passport-login-button\"]");
            submitButton.Click();

            Console.WriteLine("Enter the code sent to your email...");
            var code = Console.ReadLine().ToCharArray();

            var codeInputDiv = _driver.FindElementByCssSelector("div[aria-label=\"Verification code input\"]");
            var inputs = codeInputDiv.FindElements(By.CssSelector("input"));

            for (var i = 0; i < inputs.Count; i++)
            {
                inputs[i].SendKeys(code[i].ToString());
                Thread.Sleep(500);
            }
        }

        public void NavigateToValiantStreams()
        {
            var valorantUrl = $"{_mainUrl}directory/game/VALORANT?sort=VIEWER_COUNT&tl=c2542d6d-cd10-4532-919b-3d19f30a768b";
            _driver.Navigate().GoToUrl(valorantUrl);
            Thread.Sleep(10000);

            var directoryContainer = _driver.FindElementByCssSelector("div[data-target=\"directory-container\"]");
            var streamLinks = _driver.FindElements(By.CssSelector("a[data-a-target=\"preview-card-title-link\"]"));
            for (var i = 0; i < streamLinks.Count; i++)
            {
                var href = streamLinks[i].GetAttribute("href");
                var link = $"{href}";
                _streamUrls.Add(link);
            }
        }

        public void OutputStreamUrls()
        {
            foreach (var url in _streamUrls)
            {
                Console.WriteLine(url);
            }
        }

        public void OpenAllStreamUrls()
        {
            foreach (var link in _streamUrls)
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("window.open();");
                _driver.SwitchTo().Window(_driver.WindowHandles.Last());
                _driver.Navigate().GoToUrl(link);
                Thread.Sleep(500);
            }
        }
    }
}
