using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using chores;
using System.Net.Http;
using System.Linq;
using System.Threading;
using System;

namespace Tests
{
    [SingleThreaded]
    public class Tests
    {
        private LiveWebApplicationFactory<Startup> server;
        private IWebDriver browser;
        private HttpClient client;

        [OneTimeSetUp]
        public void Setup()
        {
            server = new LiveWebApplicationFactory<Startup>();
            client = server.CreateClient();
            var options = new ChromeOptions();
            //options.AddArgument("--headless");
            browser = new ChromeDriver(options);
        }

        [Test]
        public void PageShowsAList()
        {
            browser.Navigate().GoToUrl(server.RootUri);

            var list = browser.FindElements(By.CssSelector(".list label")).ToArray();

            Assert.That(list, Has.Exactly(3).Items);

            Assert.Multiple(() => {
                Assert.That(list[0].Text, Is.EqualTo("Put on PJ's"));
                Assert.That(list[1].Text, Is.EqualTo("Dirty laundry in laundry basket"));
                Assert.That(list[2].Text, Is.EqualTo("Teeth brushed"));
            });
        }

        [Test]
        public void ToggleFirstListEntry() 
        {
            browser.Navigate().GoToUrl(server.RootUri);

            var checkboxes = browser.FindElements(By.CssSelector("input[type=checkbox]"));
            Assert.That(checkboxes, Has.Exactly(3).Items);

            var firstCheckbox = checkboxes.First();
            bool wasSelected = firstCheckbox.Selected;
            
            firstCheckbox.Click();

            Thread.Sleep(2000);
            
            browser.FindElement(By.CssSelector("input[type=submit]")).Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            
            var firstCheckboxAgain = browser.FindElement(By.CssSelector("input[type=checkbox]"));

            Assert.That(firstCheckboxAgain.Selected, Is.Not.EqualTo(wasSelected));
        }

        [OneTimeTearDown]
        public void CleanUp() 
        {
            browser.Dispose();
            server.Dispose();
        }
    }
}