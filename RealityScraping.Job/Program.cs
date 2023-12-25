using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Microsoft.Playwright;

namespace RealityScraping.Job
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //IWebDriver driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("https://www.uol.com.br/splash/");
            //var title = driver.Title;
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            //var text = driver.FindElement(By.XPath("/html/body/div[4]/section/div/div/div[1]/div/div/a/div/h2")).Text;
            //driver.Quit();

            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync();
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://www.uol.com.br/splash/");
            await page.ScreenshotAsync(new()
            {
                Path = "screenshot.png"
            });
            var texto = await page.Locator("//html/body/div[4]/section/div/div/div[1]/div/div/a/div/h2").TextContentAsync();
            playwright.Dispose();
        }
    }
}
