using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using chores;
using System.Net.Http;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        private LiveWebApplicationFactory<Startup> server;
        private IWebDriver browser;
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            server = new LiveWebApplicationFactory<Startup>();
            client = server.CreateClient();
            var options = new ChromeOptions();
            options.AddArgument("--headless");
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

        [TearDown]
        public void CleanUp() 
        {
            browser.Dispose();
        }
    }
}